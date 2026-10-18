namespace battleships.Battleship;

public class Player
{
    public string Name { get; private set; }
    public List<Ship> Ships { get; private set; }
    public Queue<int> ShipsToPlace  { get; private set; }
    public Table OwnTable { get;  private set; }
    public ShootResult?[,] OppTable { get; private set; }
    public int SonarCooldown { get; set; }
    
    public Player(string name, List<int> shipSizes, Table ownTable)
    {
        Name = name;
        Ships = new List<Ship>();
        ShipsToPlace = new Queue<int>(shipSizes);
        OwnTable = ownTable;
        OppTable = new ShootResult?[OwnTable.Size, OwnTable.Size];
        SonarCooldown = 0;
    }

    public bool PlaceShip(int x, int y, char orientation)
    {
        //all ships placed
        if (ShipsToPlace.Count==0) return false;

        int size = ShipsToPlace.Peek();
        Ship ship = new Ship(size, (x, y), orientation);
        
        bool canPlaced = OwnTable.PlaceShip(ship);

        if (canPlaced)
        {
            Ships.Add(ship);
            ShipsToPlace.Dequeue();
        }
        return canPlaced;
    }

    public ShootResult Shoot(int x, int y, Player opponent)
    {
        ShootResult result=opponent.OwnTable.ShotAt((x, y));
        OppTable[x, y] = result;
        return result;
    }

    public int Sonar(int x, int y, Player opponent)
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