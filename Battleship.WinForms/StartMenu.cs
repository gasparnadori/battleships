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

    private void qiut_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void loadBtn_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFile = new OpenFileDialog();
        openFile.Filter="Battleship Save (*.txt)|*.txt";

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            try
            {
                Model model=Model.Load(openFile.FileName);
                GameBoard board=new GameBoard(model);
                board.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}