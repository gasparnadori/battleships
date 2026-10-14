namespace battleships.Battleship.WinForms;

public partial class GameBoard : Form
{
    private readonly Model _model;
    private readonly int _size;
    private int _activePlayer;
    private bool _sonarMode;
    private Button[,] _ownGrid;
    private Button[,] _oppGrid;
    private ToolTip _coordToolTip;

    public GameBoard(Model model)
    {
        InitializeComponent();

        _model = model;
        _size = _model.TableSize;
        _activePlayer = 0;
        _sonarMode = false;
        _ownGrid = new Button[_size, _size];
        _oppGrid = new Button[_size, _size];
        _coordToolTip = new ToolTip();

        SetupGrids();
        RefreshDisplay();
    }

    /// <summary>
    /// Creates the dynamic 2D grids of buttons for both players in code (inline),
    /// since their dimensions (8x8, 10x10, 12x12) depend on the table size selected at runtime.
    /// </summary>
    private void SetupGrids()
    {
        int cellSize = _size == 12 ? 34 : (_size == 10 ? 38 : 42);
        int gridPixelSize = _size * cellSize;

        // Horizontally center both boards in their respective halves (left half ~340, right half ~950)
        int leftStartX = 340 - (gridPixelSize / 2);
        int rightStartX = 950 - (gridPixelSize / 2);
        int startY = 130 + (430 - gridPixelSize) / 2;

        for (int row = 0; row < _size; row++)
        {
            for (int col = 0; col < _size; col++)
            {
                string coordName = $"{(char)('A' + col)}{row + 1}";

                // Left grid: Current player's own fleet (defense - read-only)
                Button ownBtn = new Button
                {
                    Size = new Size(cellSize, cellSize),
                    Location = new Point(leftStartX + col * cellSize, startY + row * cellSize),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.DarkSlateGray,
                    Font = new Font("Unispace", 10F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Enabled = false,
                    Tag = (col, row)
                };
                ownBtn.FlatAppearance.BorderSize = 1;
                ownBtn.FlatAppearance.BorderColor = Color.SlateGray;
                _coordToolTip.SetToolTip(ownBtn, $"Own: {coordName}");

                this.Controls.Add(ownBtn);
                _ownGrid[col, row] = ownBtn;

                // Right grid: Opponent's waters (attack - clickable)
                Button oppBtn = new Button
                {
                    Size = new Size(cellSize, cellSize),
                    Location = new Point(rightStartX + col * cellSize, startY + row * cellSize),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.DarkSlateGray,
                    Font = new Font("Unispace", 10F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand,
                    Tag = (col, row)
                };
                oppBtn.FlatAppearance.BorderSize = 1;
                oppBtn.FlatAppearance.BorderColor = Color.SlateGray;
                oppBtn.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
                oppBtn.Click += OppCell_Click;
                _coordToolTip.SetToolTip(oppBtn, $"Target: {coordName}");

                this.Controls.Add(oppBtn);
                _oppGrid[col, row] = oppBtn;
            }
        }
    }

    private void OppCell_Click(object? sender, EventArgs e)
    {
        if (sender is not Button btn) return;
        if (btn.Tag is not (int col, int row)) return;

        Player attacker = _model.Players[_activePlayer];
        Player defender = _model.Players[1 - _activePlayer];
        string targetCoord = $"{(char)('A' + col)}{row + 1}";

        // Handle Sonar Mode
        if (_sonarMode)
        {
            _sonarMode = false;
            sonarBtn.BackColor = Color.Transparent;

            int count = attacker.Sonar(col, row, defender);
            if (count == -1)
            {
                statusLabel.Text = "Sonar is currently on cooldown!";
                return;
            }

            statusLabel.Text = $"Sonar at {targetCoord}: {count} ship cell(s) detected!";
            statusLabel.Refresh();

            MessageBox.Show(
                $"Sonar ping at {targetCoord} detected {count} ship cell(s) in the surrounding 3x3 area!",
                "Sonar Ping Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            SwitchTurn();
            return;
        }

        // Standard Shoot action
        ShootResult result = attacker.Shoot(col, row, defender);

        // If the shot sunk a ship, reveal all cells of that ship on attacker's opponent grid
        if (result == ShootResult.Sunk)
        {
            var sunkShip = defender.OwnTable._Table[col, row];
            if (sunkShip != null)
            {
                foreach (var (x, y) in sunkShip.GetLocation())
                {
                    attacker.OppTable[x, y] = ShootResult.Sunk;
                    UpdateOppCellButton(_oppGrid[x, y], ShootResult.Sunk);
                }
            }
        }
        else
        {
            UpdateOppCellButton(btn, result);
        }

        // Update status feedback
        switch (result)
        {
            case ShootResult.Miss:
                statusLabel.Text = $"Miss at {targetCoord}!";
                break;
            case ShootResult.Hit:
                statusLabel.Text = $"HIT at {targetCoord}!";
                break;
            case ShootResult.Sunk:
                statusLabel.Text = $"DIRECT HIT! Enemy ship SUNK at {targetCoord}!";
                break;
        }

        // Force UI update before dialog halts execution
        btn.Refresh();
        statusLabel.Refresh();
        shipsRemainingLabel.Text = $"Your Ships: {attacker.ShipsRemaining()} | Enemy Ships: {defender.ShipsRemaining()}";
        shipsRemainingLabel.Refresh();

        // Check victory condition
        if (defender.ShipsRemaining() == 0)
        {
            RefreshDisplay();
            GameOver(attacker);
            return;
        }

        SwitchTurn();
    }

    private void UpdateOppCellButton(Button btn, ShootResult result)
    {
        btn.Enabled = false;
        switch (result)
        {
            case ShootResult.Miss:
                btn.BackColor = Color.SteelBlue;
                btn.Text = "•";
                btn.ForeColor = Color.LightSkyBlue;
                break;
            case ShootResult.Hit:
                btn.BackColor = Color.Orange;
                btn.Text = "✕";
                btn.ForeColor = Color.White;
                break;
            case ShootResult.Sunk:
                btn.BackColor = Color.Red;
                btn.Text = "✕";
                btn.ForeColor = Color.White;
                break;
        }
    }

    private void SwitchTurn()
    {
        _model.Players[_activePlayer].DecreaseCooldown();
        _activePlayer = 1 - _activePlayer;
        _sonarMode = false;

        MessageBox.Show(
            $"Hand the screen to {_model.Players[_activePlayer].Name} and click OK.",
            "Pass the Screen",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        RefreshDisplay();
    }

    private void RefreshDisplay()
    {
        Player me = _model.Players[_activePlayer];
        Player opp = _model.Players[1 - _activePlayer];

        turnLabel.Text = $"{me.Name}'s Turn";
        turnLabel.ForeColor = _activePlayer == 0 ? Color.IndianRed : Color.CornflowerBlue;

        shipsRemainingLabel.Text = $"Your Ships: {me.ShipsRemaining()} | Enemy Ships: {opp.ShipsRemaining()}";

        if (me.SonarCooldown > 0)
        {
            sonarBtn.Text = $"Sonar (CD: {me.SonarCooldown})";
            sonarBtn.Enabled = false;
            sonarBtn.ForeColor = Color.Gray;
            sonarBtn.BackColor = Color.Transparent;
        }
        else
        {
            sonarBtn.Text = "Sonar (S)";
            sonarBtn.Enabled = true;
            sonarBtn.ForeColor = Color.White;
            sonarBtn.BackColor = Color.Transparent;
        }

        statusLabel.Text = "Status: Select a target on the opponent's grid.";

        // Refresh Own Grid (player's ships and incoming enemy fire)
        for (int r = 0; r < _size; r++)
        {
            for (int c = 0; c < _size; c++)
            {
                Button btn = _ownGrid[c, r];
                var incomingShot = opp.OppTable[c, r];

                if (incomingShot == ShootResult.Sunk)
                {
                    btn.BackColor = Color.Red;
                    btn.Text = "✕";
                    btn.ForeColor = Color.White;
                }
                else if (incomingShot == ShootResult.Hit)
                {
                    btn.BackColor = Color.Orange;
                    btn.Text = "✕";
                    btn.ForeColor = Color.White;
                }
                else if (incomingShot == ShootResult.Miss)
                {
                    btn.BackColor = Color.SteelBlue;
                    btn.Text = "•";
                    btn.ForeColor = Color.LightSkyBlue;
                }
                else if (me.OwnTable._Table[c, r] != null)
                {
                    btn.BackColor = Color.DarkSlateBlue; // Intact ship cell
                    btn.Text = "";
                }
                else
                {
                    btn.BackColor = Color.DarkSlateGray; // Open water
                    btn.Text = "";
                }
            }
        }

        // Refresh Opponent Grid (shots current player has taken)
        for (int r = 0; r < _size; r++)
        {
            for (int c = 0; c < _size; c++)
            {
                Button btn = _oppGrid[c, r];
                var myShot = me.OppTable[c, r];

                if (myShot == null)
                {
                    btn.Enabled = true;
                    btn.BackColor = Color.DarkSlateGray;
                    btn.Text = "";
                }
                else
                {
                    btn.Enabled = false;
                    UpdateOppCellButton(btn, myShot.Value);
                }
            }
        }
    }

    private void sonarBtn_Click(object? sender, EventArgs e)
    {
        Player attacker = _model.Players[_activePlayer];
        if (attacker.SonarCooldown > 0)
        {
            MessageBox.Show(
                $"Sonar is on cooldown! ({attacker.SonarCooldown} turn(s) remaining)",
                "Sonar Cooldown",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        _sonarMode = !_sonarMode;
        if (_sonarMode)
        {
            sonarBtn.BackColor = Color.SteelBlue;
            statusLabel.Text = "Sonar ACTIVE: Click any cell on the opponent grid to scan a 3x3 area.";
        }
        else
        {
            sonarBtn.BackColor = Color.Transparent;
            statusLabel.Text = "Sonar cancelled. Select a cell to shoot.";
        }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.S)
        {
            sonarBtn_Click(this, EventArgs.Empty);
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void GameOver(Player winner)
    {
        MessageBox.Show(
            $"{winner.Name} has sunk all enemy ships and won the battle!",
            "Victory!",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        StartMenu menu = new StartMenu();
        menu.Show();
        this.Close();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        // Ensure application exits if game board was closed directly
        if (Application.OpenForms.Count == 0 || (Application.OpenForms.Count == 1 && Application.OpenForms[0] == this))
        {
            Application.Exit();
        }
    }
}