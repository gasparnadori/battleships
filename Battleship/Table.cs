namespace battleships.Battleship;

public class Table
{
    public int Size { get; private set; }
    public Ship?[,] _Table { get; private set; }
    public ShootResult[,] Hits {get; private set; }
    
    public Table(int size)
    {
        Size = size;
        _Table = new Ship[size, size];
        Hits = new ShootResult[size, size];
    }

    public bool PlaceShip(Ship ship)
    {
        var locations = ship.GetLocation();
        var buffer = ship.GetBuffer();

        //remain on table
        foreach (var coord in locations)
        {
            if (coord.Item1 < 0 || coord.Item2 < 0 || coord.Item1 >= Size || coord.Item2 >= Size)
            {
                return false;
            }
        }

        //check for ships in buffer
        foreach (var coord in buffer)
        {
            if (coord.Item1 >= 0 && coord.Item1 < Size && coord.Item2 >= 0 && coord.Item2 < Size)
            {
                if (_Table[coord.Item1, coord.Item2] != null)
                {
                    return false;
                }
            }
        }
        
        //place ship if correct
        foreach (var coord in locations)
        {
            _Table[coord.Item1, coord.Item2] = ship;
        }
        return true;
    }

    public ShootResult ShotAt((int, int) coord)
    {
        var target = _Table[coord.Item1, coord.Item2];

        if (target == null) return ShootResult.Miss;
        
        target.GetHit();

        if (target.IsSunk()) return ShootResult.Sunk;

        return ShootResult.Hit;
    }

    public int SonarAt((int, int) coord)
    {
        //ship pointers in a 3x3 square
        int count = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (coord.Item1 + x >= 0 && coord.Item1 + x < Size && coord.Item2 + y >= 0 && coord.Item2 < Size)
                {
                    if (_Table[coord.Item1 + x, coord.Item2 + y] != null) count++;
                }
            }
        }
        return count;
    }
}