namespace battleships.Battleship;

public class Model
{
    private int tableSize;
    private Player[] players;
    private Rules rules;
    private int activePlayer;

    public Model(int tableSize)
    {
        this.tableSize = tableSize;
        players = new Player[2];
        rules = Rules.Instance;
    }

    public void NewGame()
    {
        players[0] = new Player("Player 1", rules.ShipNumbers[tableSize].ToList(), new Table(tableSize));
        players[1] = new Player("Player 2", rules.ShipNumbers[tableSize].ToList(), new Table(tableSize));
        
        activePlayer = 0;
    }

}