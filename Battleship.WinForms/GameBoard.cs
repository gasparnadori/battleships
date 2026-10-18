namespace battleships.Battleship.WinForms;

public partial class GameBoard : Form
{
    private Model _model;
    private int _size;
    private int _activePlayer;
    private Button[,] _ownGrid;
    private Button[,] _oppGrid;
    private bool _sonarMode;

    public GameBoard(Model model)
    {
        InitializeComponent();

        _model = model;
        _size = _model.TableSize;
        _activePlayer = _model.ActivePlayer;
        _sonarMode = false;
        _ownGrid = new Button[_size, _size];
        _oppGrid = new Button[_size, _size];

        BuildGrids();
        RefreshDisplay();
    }

    private void BuildGrids()
    {
        int cellSize = 35;
        int ownMarginX = 50;
        int oppMarginX = 650;
        int marginY = 120;

        _ownGrid = new Button[_size, _size];
        _oppGrid = new Button[_size, _size];

        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                // Left grid: own table
                Button ownBtn = new Button();
                ownBtn.Size = new Size(cellSize, cellSize);
                ownBtn.Location = new Point(ownMarginX + col * cellSize, marginY + row * cellSize);
                ownBtn.FlatStyle = FlatStyle.Flat;
                ownBtn.BackColor = Color.DarkSlateGray;
                ownBtn.Enabled = false;
                this.Controls.Add(ownBtn);
                _ownGrid[col, row] = ownBtn;

                // Right grid: opp table
                Button oppBtn = new Button();
                oppBtn.Size = new Size(cellSize, cellSize);
                oppBtn.Location = new Point(oppMarginX + col * cellSize, marginY + row * cellSize);
                oppBtn.FlatStyle = FlatStyle.Flat;
                oppBtn.BackColor = Color.DarkSlateGray;
                oppBtn.Tag = (col, row);
                oppBtn.Click += OppCell_Click;
                this.Controls.Add(oppBtn);
                _oppGrid[col, row] = oppBtn;
            }
        }
    }

    private void OppCell_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        var (col, row) = ((int, int))btn.Tag;

        Player attacker = _model.Players[_activePlayer];
        Player defender = _model.Players[1 - _activePlayer];

        if (_sonarMode)
        {
            int count = attacker.Sonar(col, row, defender);
            if (count == -1)
            {
                MessageBox.Show("Sonar is on cooldown!");
            }
            else
            {
                MessageBox.Show($"Sonar detected {count} ship cell(s) nearby!");
                _sonarMode = false;
                SwitchTurn();
            }
            return;
        }

        ShootResult result = attacker.Shoot(col, row, defender);

        if (result == ShootResult.Miss)
        {
            btn.BackColor = Color.LightSkyBlue;
        }
        else if (result == ShootResult.Hit)
        {
            btn.BackColor = Color.Orange;
        }
        else if (result == ShootResult.Sunk)
        {
            btn.BackColor = Color.Red;
            var sunkShip = defender.OwnTable._Table[col, row];
            if (sunkShip != null)
            {
                foreach (var loc in sunkShip.GetLocation())
                {
                    attacker.OppTable[loc.Item1, loc.Item2] = ShootResult.Sunk;
                    _oppGrid[loc.Item1, loc.Item2].BackColor = Color.Red;
                }
            }
        }
        btn.Enabled = false;

        if (defender.ShipsRemaining() == 0)
        {
            MessageBox.Show($"{attacker.Name} wins!");
            StartMenu menu = new StartMenu();
            menu.Show();
            this.Close();
            return;
        }

        SwitchTurn();
    }

    private void SwitchTurn()
    {
        _model.Players[_activePlayer].DecreaseCooldown();
        _activePlayer = 1 - _activePlayer;
        _sonarMode = false;

        MessageBox.Show($"Hand the screen to your opponent");
        RefreshDisplay();
    }

    private void RefreshDisplay()
    {
        Player me = _model.Players[_activePlayer];
        Player opp = _model.Players[1 - _activePlayer];

        turnLabel.Text = $"{me.Name}'s turn";
        turnLabel.ForeColor = _activePlayer == 0 ? Color.IndianRed : Color.DarkSlateBlue;
        shipsRemainingLabel.Text = $"Ships remaining: {opp.ShipsRemaining()}";
        sonarBtn.Text = "Sonar";
        if (me.SonarCooldown > 0)
        {
            sonarCooldownLabel.Text = $"Cooldown: {me.SonarCooldown}";
            sonarCooldownLabel.ForeColor = Color.IndianRed;
            sonarBtn.Enabled = false;
        }
        else
        {
            sonarCooldownLabel.Text = "Ready";
            sonarCooldownLabel.ForeColor = Color.LightGreen;
            sonarBtn.Enabled = true;
        }

        //Redraw own table
        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                var hit = opp.OppTable[col, row];
                if (hit == ShootResult.Hit || hit == ShootResult.Sunk)
                {
                    _ownGrid[col, row].BackColor = Color.Red;
                }
                else if (hit == ShootResult.Miss)
                {
                    _ownGrid[col, row].BackColor = Color.LightSkyBlue;
                }
                else if (me.OwnTable._Table[col, row] != null)
                {
                    _ownGrid[col, row].BackColor = Color.DarkSlateBlue;
                }
                else
                {
                    _ownGrid[col, row].BackColor = Color.DarkSlateGray;
                }
            }
        }

        //Redraw opp table
        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                var prev = me.OppTable[col, row];
                if (prev == null)
                {
                    _oppGrid[col, row].BackColor = Color.DarkSlateGray;
                    _oppGrid[col, row].Enabled = true;
                }
                else
                {
                    _oppGrid[col, row].Enabled = false;
                    if (prev == ShootResult.Miss) _oppGrid[col, row].BackColor = Color.LightSkyBlue;
                    else if (prev == ShootResult.Hit) _oppGrid[col, row].BackColor = Color.Orange;
                    else if (prev == ShootResult.Sunk) _oppGrid[col, row].BackColor = Color.Red;
                }
            }
        }
    }

    private void sonarBtn_Click(object sender, EventArgs e)
    {
        Player me = _model.Players[_activePlayer];
        if (me.SonarCooldown > 0)
        {
            MessageBox.Show("Sonar is on cooldown!");
            return;
        }

        _sonarMode = !_sonarMode;
        if (_sonarMode)
        {
            MessageBox.Show("Click a cell on the opponent board to use sonar.");
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StartMenu menu=new StartMenu();
        if (MessageBox.Show("Save before exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            using SaveFileDialog dialog = new();
            dialog.Filter = "Battleship Save (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _model.ActivePlayer = _activePlayer;
                    _model.Save(dialog.FileName);
                    MessageBox.Show("Game saved!");
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Failed to save: " + ex.Message);
                }
            }
            menu.Show();
            this.Close();
        }
        else
        {
            menu.Show();
            this.Close();
        }
    }

    private void saveBtn_Click(object sender, EventArgs e)
    {
        using SaveFileDialog dialog = new();
        dialog.Filter = "Battleship Save (*.txt)|*.txt";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _model.ActivePlayer = _activePlayer;
                _model.Save(dialog.FileName);
                MessageBox.Show("Game saved!");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Failed to save: " + ex.Message);
            }
        }
    }
}