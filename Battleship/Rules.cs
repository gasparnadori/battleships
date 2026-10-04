namespace battleships.Battleship;

public sealed class Rules
{
    public Dictionary<int, int[]> ShipNumbers { get; private set; }
    
    private Rules()
    {
        this.ShipNumbers = new Dictionary<int, int[]>();
        ShipNumbers.Add(8, [4, 3, 2, 2]);
        ShipNumbers.Add(10, [5, 4, 3, 3, 2]);
        ShipNumbers.Add(12, [5, 4, 4, 3, 2]);
    }

    public static Rules Instance { get; private set; } = new();
}