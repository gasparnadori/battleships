namespace battleships.Battleship;

public class Ship
{
    
    public int Size {get; private set;}
    public int Life { get; private set; }
    public char Orientation { get; private set; }  // vertical: v - hprizontal: h
    public (int,int) StartLocation { get; private set; }  // (x,y) tuple

    public Ship(int size, (int, int) startLocation, char orientation)
    {
        Size = size;
        StartLocation = startLocation;
        Orientation = orientation;
        Life = size;
    }

    public (int,int)[] GetLocation()
    {
        (int,int)[] location = new (int,int)[Size];
        location[0] = StartLocation;

        if (Orientation == 'v')
        {
            for (int i = 1; i < Size; i++)
            {
                location[i] = (StartLocation.Item1, StartLocation.Item2+i);
            }
        }
        else if (Orientation == 'h')
        {
            for (int i = 1; i < Size; i++)
            {
                location[i] = (StartLocation.Item1+i, StartLocation.Item2);
            }
        }
        return  location;
    }

    public List<(int,int)> GetBuffer()
    {
        HashSet<(int, int)> buffer = new HashSet<(int, int)>();
        var locations = GetLocation();

        foreach (var coord in locations)
        {
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    buffer.Add((coord.Item1 + x, coord.Item2 + y));
                }
            }
        }
        return buffer.ToList();
    }

    public bool CheckHit((int, int) coordinates)
    {
        var location = GetLocation();
        for (int i = 0; i < location.Count() ; i++)
        {
            if(location[i] == coordinates) return true;
        }
        return false;
    }
    
    public void GetHit()
    {
        Life--;
    }
    
    public bool IsSunk()
    { 
         return Life <= 0;
    }
}