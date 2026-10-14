namespace battleships.Battleship.WinForms;

public partial class ShipPlacement : Form
{
    private Model _model;
    private int _size;
    private int _playerNumber;
    private Player _currentPlayer;
    private Button[,] _board;
    private char _orientation;
    private Queue<int> _ships;
    private int _currentShipSize;
    

    private void SetupBoard()
    {
        int cellSize = 40;
        int marginX = 50;
        int marginY = 100;
        
        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                Button btn = new Button();
                btn.Size = new Size(cellSize, cellSize);
                btn.Location = new Point(marginX+col*cellSize, marginY+row*cellSize);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.DarkSlateGray;
                btn.Tag = (row, col);

                btn.Click += Cell_Click;
                
                this.Controls.Add(btn);
                _board[row, col] = btn;
            }
        }
    }

    private void Cell_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        var (row, col) = ((int,int))btn.Tag;
        
        bool succes =_currentPlayer.PlaceShip(col, row, _orientation);

        if (succes)
        {
            HighlightShip(row, col, _orientation);
            Advance();
        }
        else
        {
            MessageBox.Show("Invalid placement");
        }
    }

    private void HighlightShip(int row, int col, char orientation)
    {
        if (orientation == 'v')
        {
            for (int i = 0; i < _currentShipSize; i++)
            {
                _board[row + i, col].BackColor = Color.DarkSlateBlue;
            }
        }
        else if (orientation == 'h')
        {
            for (int i = 0; i < _currentShipSize; i++)
            {
                _board[row, col + i].BackColor = Color.DarkSlateBlue;
            }
        }
    }

    private void Advance()
    {
        _ships.Dequeue(); 
        if (_ships.Count > 0)
        {
            _currentShipSize = _ships.Peek();
            shipLabel.Text = $"Current ship: size {_currentShipSize}";
        }
        else
        {
            FinishPlacement();
        }
    }

    private void FinishPlacement()
    {
        if (_playerNumber == 0)
        {
            MessageBox.Show("Player 2 places ships now");
            
            _currentPlayer=_model.Players[1];
            _playerNumber = 1;
            playerLabel.Text="Player 2 placing ships";
            
            foreach (var shipSize in _model.Rules.ShipNumbers[_size])
            {
                _ships.Enqueue(shipSize);
            }
            
            _currentShipSize = _ships.Peek();
            shipLabel.Text = $"Current ship: size {_currentShipSize}";

            playerLabel.ForeColor=Color.DarkSlateBlue;
            doneBtn.ForeColor=Color.Transparent;
            
            //recolor grid
            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    _board[row,col].BackColor = Color.DarkSlateGray;
                }
            }
        }
        else
        {

            GameBoard gameBoard = new GameBoard(_model);
            gameBoard.Show();
            this.Close();
        }
    }
    
    
    public ShipPlacement(Model model)
    {
        InitializeComponent();
        
        _model = model;
        _size = _model.TableSize;
        _model.NewGame();
        
        _board = new Button[_size, _size];
        _ships = new Queue<int>(_model.Rules.ShipNumbers[_size]);
        _currentShipSize = _ships.Peek();
        _orientation = 'h';
        _playerNumber = 0;
        _currentPlayer = _model.Players[0];

        playerLabel.Text = "Player 1 placing ships";
        playerLabel.ForeColor=Color.IndianRed;
        doneBtn.ForeColor = Color.Gray;
        orientationLabel.Text = $"Orientation: {_orientation}";
        shipLabel.Text = $"Current ship: size {_currentShipSize}";
        
        SetupBoard();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if(_orientation=='v') _orientation = 'h';
        else if(_orientation=='h') _orientation = 'v';
        orientationLabel.Text = $"Orientation: {_orientation}";
    }
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.R)
        {
            _orientation = _orientation == 'h' ? 'v' : 'h';
            orientationLabel.Text = $"Orientation: {_orientation}";
            return true;  // "I handled this key, don't pass it on"
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void doneBtn_Click(object sender, EventArgs e)
    {
        if(_ships.Count > 0)
        {
            MessageBox.Show("Finish placement first");
        }
        else
        {
            GameBoard gameBoard = new GameBoard(_model);
            gameBoard.Show();
            this.Close();
        }
    }
}