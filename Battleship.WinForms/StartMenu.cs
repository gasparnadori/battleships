namespace battleships.Battleship.WinForms;

public partial class StartMenu : Form
{
    public StartMenu()
    {
        InitializeComponent();
    }

    private void newGameBtn_Click(object sender, EventArgs e)
    {
        GameSetup gameSetup = new GameSetup();
        gameSetup.Show();

        this.Hide();
    }
}