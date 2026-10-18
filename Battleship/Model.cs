using System.Text;
using battleships.Persistence;
using FileAccess = battleships.Persistence.FileAccess;

namespace battleships.Battleship;

public class BattleshipEventArgs : EventArgs
{
    public ShootResult Result { get; }
    public BattleshipEventArgs(ShootResult result) 
    { 
        Result = result; 
    }
}

public class Model
{
    public int TableSize {get; private set;}
    public Player[] Players { get; private set; }
    public Rules Rules { get;private set; }
    public int ActivePlayer {get; set;}
    private bool _placementPhase;

    public event EventHandler OnPlacementStarted;
    public event EventHandler OnPlayerChanged;
    public event EventHandler OnGameStarted;
    public event EventHandler<BattleshipEventArgs> OnTableUpdate;
    public event EventHandler<int> OnSonarUsed;
    public event EventHandler OnGameOver;  

    private readonly IFileAccess _fileAccess;

    public Model(int tableSize, IFileAccess? fileAccess = null)
    {
        this.TableSize = tableSize;
        Players = new Player[2];
        Rules = Rules.Instance;
        _placementPhase = false;
        _fileAccess = fileAccess ?? new FileAccess();
    }

    public void NewGame()
    {
        Players[0] = new Player("Player 1", Rules.ShipNumbers[TableSize].ToList(), new Table(TableSize));
        Players[1] = new Player("Player 2", Rules.ShipNumbers[TableSize].ToList(), new Table(TableSize));
        
        ActivePlayer = 0;
        
        OnPlacementStarted?.Invoke(this, EventArgs.Empty);
        _placementPhase = true;
    }

    public bool PlaceShip(int x, int y, char orient)
    {
        if (Players[ActivePlayer].PlaceShip(x, y, orient))
        {
            //player 2 finished
            if (ActivePlayer == 1 && Players[ActivePlayer].Ships.Count == Rules.ShipNumbers[TableSize].Length)
            {
                _placementPhase = false;
                OnGameStarted?.Invoke(this, EventArgs.Empty);
                OnPlayerChanged?.Invoke(this, EventArgs.Empty);
                ActivePlayer = 0;
                
            }
            //player 1 finished
           else if (ActivePlayer ==0 && Players[ActivePlayer].Ships.Count == Rules.ShipNumbers[TableSize].Length) 
            {
                ActivePlayer = 1;
                OnPlayerChanged?.Invoke(this, EventArgs.Empty);
            }
            return true;
        }
        return false;
    }

    public bool PlayerShoots(int x, int y)
    {
        if( x<0 || x >= TableSize || y<0 || y>= TableSize || Players[ActivePlayer].OppTable[x,y] != null) return false;
        
        ShootResult result = Players[ActivePlayer].Shoot(x,y, Players[(ActivePlayer+1)%2]);
        OnTableUpdate?.Invoke(this, new BattleshipEventArgs(result));

        if (Players[(ActivePlayer + 1) % 2].ShipsRemaining() == 0)
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
            return true;
        }

        Players[ActivePlayer].DecreaseCooldown();
        ActivePlayer = (ActivePlayer + 1) % 2;
        OnPlayerChanged?.Invoke(this, new BattleshipEventArgs(result));
        return true;
    }

    public bool PlayerSonar(int x, int y)
    {
        if (Players[ActivePlayer].SonarCooldown > 0) return false;
        if( x<0 || x >= TableSize || y<0 || y>= TableSize) return false;

        int count = Players[ActivePlayer].Sonar(x, y, Players[(ActivePlayer + 1) % 2]);
        OnSonarUsed?.Invoke(this, count);
        ActivePlayer = (ActivePlayer + 1) % 2;
        OnPlayerChanged?.Invoke(this, EventArgs.Empty);
        
        return true;
    }

    public void Save(string path)
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine(TableSize.ToString());
        sb.AppendLine(ActivePlayer.ToString());

        for (int p = 0; p < 2; p++)
        {
            Player player = Players[p];
            
            sb.AppendLine(player.SonarCooldown.ToString());
            sb.AppendLine(player.Ships.Count.ToString());

            foreach (Ship ship in player.Ships)
            {
                sb.AppendLine($"{ship.Size} {ship.StartLocation.Item1} {ship.StartLocation.Item2} {ship.Orientation} {ship.Life}");
            }

            for (int row = 0; row < TableSize; row++)
            {
                for (int col = 0; col < TableSize; col++)
                {
                    var hit = player.OppTable[col, row];
                    switch (hit)
                    {
                        case ShootResult.Hit:
                            sb.Append('H');
                            break;
                        case ShootResult.Miss:
                            sb.Append('M');
                            break;
                        case ShootResult.Sunk:
                            sb.Append('S');
                            break;
                        default:
                            sb.Append('.');
                            break;
                    }
                }
                sb.AppendLine();
            }
        }
        _fileAccess.Save(path, sb.ToString());
    }

    public static Model Load(string path, IFileAccess? fileAcces = null)
    {
        fileAcces ??= new FileAccess();
        string content = fileAcces.Load(path);
        
        using StringReader reader = new(content);
        
        int size = int.Parse(reader.ReadLine()!);
        int activePlayer = int.Parse(reader.ReadLine()!);
        
        Model model = new Model(size, fileAcces);
        model.Players[0]=new Player("Player 1", new List<int>(), new Table(size));
        model.Players[1]=new Player("Player 2", new List<int>(), new Table(size));
        model.ActivePlayer=activePlayer;
        
        for (int p = 0; p < 2; p++)
        {
            Player player = model.Players[p];
            
            player.SonarCooldown=int.Parse(reader.ReadLine()!);
            int shipCount=int.Parse(reader.ReadLine()!);

            for (int i = 0; i < shipCount; i++)
            {
                string[] parts=reader.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int shipSize=int.Parse(parts[0]);
                int x=int.Parse(parts[1]);
                int y=int.Parse(parts[2]);
                char orentation=char.Parse(parts[3]);
                int life=int.Parse(parts[4]);
                
                Ship ship=new Ship(shipSize,(x,y),orentation);
                while (ship.Life > life) ship.GetHit();
                
                player.OwnTable.PlaceShip(ship);
                player.Ships.Add(ship);
            }         

            for (int row = 0; row < size; row++)
            {
                string line = reader.ReadLine()!;
                
                for (int col = 0; col < size; col++)
                {
                    switch (line[col])
                    {
                        case 'H':
                            player.OppTable[col, row] = ShootResult.Hit;
                            break;
                        case 'M':
                            player.OppTable[col, row] = ShootResult.Miss;
                            break;
                        case 'S':
                            player.OppTable[col, row] = ShootResult.Sunk;
                            break;
                        default:
                            player.OppTable[col, row] = null;
                            break;
                    }
                }
            }
        }
        return model;
    }
}