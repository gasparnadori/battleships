namespace battleships.Battleship;

public class Player
{
    public string Name { get; private set; }
    public List<Ship> Ships { get; private set; }
    private Queue<int> _shipsToPlace;
    public Table OwnTable { get;  private set; }
    public ShootResult?[,] OppTable { get; private set; }
    public int SonarCooldown { get; private set; }
    
    public Player(string name, List<int> shipSizes, Table ownTable)
    {
        Name = name;
        Ships = new List<Ship>();
        _shipsToPlace = new Queue<int>(shipSizes);
        OwnTable = ownTable;
        OppTable = new ShootResult?[OwnTable.Size, OwnTable.Size];
        SonarCooldown = 0;
    }

    public bool PlaceShip(int x, int y, char orientation)
    {
        //all ships placed
        if (_shipsToPlace.Count==0) return false;

        int size = _shipsToPlace.Peek();
        Ship ship = new Ship(size, (x, y), orientation);
        
        bool canPlaced = OwnTable.PlaceShip(ship);

        if (canPlaced)
        {
            Ships.Add(ship);
            _shipsToPlace.Dequeue();
        }
        return canPlaced;
    }

    public ShootResult Shoot(int x, int y, Player opponent)
    {
        ShootResult result=opponent.OwnTable.ShotAt((x, y));
        OppTable[x, y] = result;
        return result;
    }

    public int Soanr(int x, int y, Player opponent)
    {
        if (SonarCooldown > 0) return -1;
        
        int result=opponent.OwnTable.SonarAt((x, y));
        SonarCooldown = 3;
        
        return result;
    }
    
    public void DecreaseCooldown()
    {
        if (SonarCooldown > 0) SonarCooldown--;
    }

    public int ShipsRemaining()
    {
        return Ships.Count(s => !s.IsSunk());
    }
}