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
    private int _activePlayer;
    private bool _placementPhase;

    public event EventHandler OnPlacementStarted;
    public event EventHandler OnPlayerChanged;
    public event EventHandler OnGameStarted;
    public event EventHandler<BattleshipEventArgs> OnTableUpdate;
    public event EventHandler<int> OnSonarUsed;
    public event EventHandler OnGameOver;  

    public Model(int tableSize)
    {
        this.TableSize = tableSize;
        Players = new Player[2];
        Rules = Rules.Instance;
        _placementPhase = false;
    }

    public void NewGame()
    {
        Players[0] = new Player("Player 1", Rules.ShipNumbers[TableSize].ToList(), new Table(TableSize));
        Players[1] = new Player("Player 2", Rules.ShipNumbers[TableSize].ToList(), new Table(TableSize));
        
        _activePlayer = 0;
        
        OnPlacementStarted?.Invoke(this, EventArgs.Empty);
        _placementPhase = true;
    }

    bool PlaceShip(int x, int y, char orient)
    {
        if (Players[_activePlayer].PlaceShip(x, y, orient))
        {
            //player 2 finished
            if (_activePlayer == 1 && Players[_activePlayer].Ships.Count == Rules.ShipNumbers[TableSize].Length)
            {
                _placementPhase = false;
                OnGameStarted?.Invoke(this, EventArgs.Empty);
                OnPlayerChanged?.Invoke(this, EventArgs.Empty);
                _activePlayer = 0;
                
            }
            //player 1 finished
           else if (_activePlayer ==0 && Players[_activePlayer].Ships.Count == Rules.ShipNumbers[TableSize].Length) 
            {
                _activePlayer = 1;
                OnPlayerChanged?.Invoke(this, EventArgs.Empty);
            }
            return true;
        }
        return false;
    }

    bool PlayerShoots(int x, int y)
    {
        if( x<0 || x >= TableSize || y<0 || y>= TableSize || Players[_activePlayer].OppTable[x,y] == null) return false;
        
        ShootResult result = Players[_activePlayer].Shoot(x,y, Players[(_activePlayer+1)%2]);
        OnTableUpdate?.Invoke(this, new BattleshipEventArgs(result));

        if (Players[(_activePlayer + 1) % 2].ShipsRemaining() == 0)
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
            return true;
        }

        Players[_activePlayer].DecreaseCooldown();
        _activePlayer = (_activePlayer + 1) % 2;
        OnPlayerChanged?.Invoke(this, new BattleshipEventArgs(result));
        return true;
    }

    bool PlayerSonar(int x, int y)
    {
        if (Players[_activePlayer].SonarCooldown > 0) return false;
        if( x<0 || x >= TableSize || y<0 || y>= TableSize) return false;

        int count = Players[_activePlayer].Sonar(x, y, Players[(_activePlayer + 1) % 2]);
        OnSonarUsed?.Invoke(this, count);
        _activePlayer = (_activePlayer + 1) % 2;
        OnPlayerChanged?.Invoke(this, EventArgs.Empty);
        
        return true;
    }

}