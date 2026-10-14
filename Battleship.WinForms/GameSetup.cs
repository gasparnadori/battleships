namespace battleships.Battleship.WinForms;

public partial class GameSetup : Form
{
    public GameSetup()
    {
        InitializeComponent();
    }

    private void startBtn_Click(object sender, EventArgs e)
    {
        int size = 10;
        if(btn8.Checked) size = 8;
        else if(btn12.Checked) size = 12;
        
        Model model = new Model(size);
        ShipPlacement placement = new ShipPlacement(model);
        placement.Show();
        
        this.Close();
    }
}