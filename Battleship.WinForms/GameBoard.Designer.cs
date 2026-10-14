using System.ComponentModel;

namespace battleships.Battleship.WinForms;

partial class GameBoard
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
        turnLabel = new System.Windows.Forms.Label();
        shipsRemainingLabel = new System.Windows.Forms.Label();
        ownBoardLabel = new System.Windows.Forms.Label();
        oppBoardLabel = new System.Windows.Forms.Label();
        statusLabel = new System.Windows.Forms.Label();
        sonarBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // turnLabel
        // 
        turnLabel.BackColor = System.Drawing.Color.Transparent;
        turnLabel.Font = new System.Drawing.Font("Unispace", 15.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        turnLabel.ForeColor = System.Drawing.Color.IndianRed;
        turnLabel.Location = new System.Drawing.Point(25, 20);
        turnLabel.Name = "turnLabel";
        turnLabel.Size = new System.Drawing.Size(400, 38);
        turnLabel.TabIndex = 0;
        turnLabel.Text = "Player 1's Turn";
        // 
        // shipsRemainingLabel
        // 
        shipsRemainingLabel.BackColor = System.Drawing.Color.Transparent;
        shipsRemainingLabel.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        shipsRemainingLabel.ForeColor = System.Drawing.Color.LightGray;
        shipsRemainingLabel.Location = new System.Drawing.Point(440, 22);
        shipsRemainingLabel.Name = "shipsRemainingLabel";
        shipsRemainingLabel.Size = new System.Drawing.Size(550, 38);
        shipsRemainingLabel.TabIndex = 1;
        shipsRemainingLabel.Text = "Ships remaining: 5";
        // 
        // ownBoardLabel
        // 
        ownBoardLabel.BackColor = System.Drawing.Color.Transparent;
        ownBoardLabel.Font = new System.Drawing.Font("Unispace", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        ownBoardLabel.ForeColor = System.Drawing.Color.Silver;
        ownBoardLabel.Location = new System.Drawing.Point(140, 75);
        ownBoardLabel.Name = "ownBoardLabel";
        ownBoardLabel.Size = new System.Drawing.Size(400, 32);
        ownBoardLabel.TabIndex = 2;
        ownBoardLabel.Text = "YOUR FLEET (Defense)";
        // 
        // oppBoardLabel
        // 
        oppBoardLabel.BackColor = System.Drawing.Color.Transparent;
        oppBoardLabel.Font = new System.Drawing.Font("Unispace", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        oppBoardLabel.ForeColor = System.Drawing.Color.Silver;
        oppBoardLabel.Location = new System.Drawing.Point(750, 75);
        oppBoardLabel.Name = "oppBoardLabel";
        oppBoardLabel.Size = new System.Drawing.Size(400, 32);
        oppBoardLabel.TabIndex = 3;
        oppBoardLabel.Text = "TARGET GRID (Attack)";
        // 
        // statusLabel
        // 
        statusLabel.BackColor = System.Drawing.Color.Transparent;
        statusLabel.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        statusLabel.ForeColor = System.Drawing.Color.LightGray;
        statusLabel.Location = new System.Drawing.Point(25, 615);
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new System.Drawing.Size(800, 40);
        statusLabel.TabIndex = 4;
        statusLabel.Text = "Status: Select a target on the opponent's grid.";
        // 
        // sonarBtn
        // 
        sonarBtn.BackColor = System.Drawing.Color.Transparent;
        sonarBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
        sonarBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        sonarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        sonarBtn.Font = new System.Drawing.Font("Unispace", 11.25F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        sonarBtn.ForeColor = System.Drawing.Color.Transparent;
        sonarBtn.Location = new System.Drawing.Point(1060, 605);
        sonarBtn.Name = "sonarBtn";
        sonarBtn.Size = new System.Drawing.Size(200, 45);
        sonarBtn.TabIndex = 5;
        sonarBtn.Text = "Sonar (S)";
        sonarBtn.UseVisualStyleBackColor = false;
        sonarBtn.Click += sonarBtn_Click;
        // 
        // GameBoard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSlateGray;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(1289, 677);
        Controls.Add(sonarBtn);
        Controls.Add(statusLabel);
        Controls.Add(oppBoardLabel);
        Controls.Add(ownBoardLabel);
        Controls.Add(shipsRemainingLabel);
        Controls.Add(turnLabel);
        DoubleBuffered = true;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "GameBoard";
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label turnLabel;
    private System.Windows.Forms.Label shipsRemainingLabel;
    private System.Windows.Forms.Label ownBoardLabel;
    private System.Windows.Forms.Label oppBoardLabel;
    private System.Windows.Forms.Label statusLabel;
    private System.Windows.Forms.Button sonarBtn;
}