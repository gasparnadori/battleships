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
        sonarBtn = new System.Windows.Forms.Button();
        sonarCooldownLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // turnLabel
        // 
        turnLabel.BackColor = System.Drawing.Color.Transparent;
        turnLabel.Font = new System.Drawing.Font("Unispace", 15.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        turnLabel.ForeColor = System.Drawing.Color.IndianRed;
        turnLabel.Location = new System.Drawing.Point(50, 20);
        turnLabel.Name = "turnLabel";
        turnLabel.Size = new System.Drawing.Size(350, 38);
        turnLabel.TabIndex = 0;
        turnLabel.Text = "Player 1's turn";
        // 
        // shipsRemainingLabel
        // 
        shipsRemainingLabel.BackColor = System.Drawing.Color.Transparent;
        shipsRemainingLabel.Font = new System.Drawing.Font("Unispace", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        shipsRemainingLabel.ForeColor = System.Drawing.Color.LightGray;
        shipsRemainingLabel.Location = new System.Drawing.Point(650, 20);
        shipsRemainingLabel.Name = "shipsRemainingLabel";
        shipsRemainingLabel.Size = new System.Drawing.Size(350, 38);
        shipsRemainingLabel.TabIndex = 1;
        shipsRemainingLabel.Text = "Ships remaining: 5";
        // 
        // ownBoardLabel
        // 
        ownBoardLabel.BackColor = System.Drawing.Color.Transparent;
        ownBoardLabel.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        ownBoardLabel.ForeColor = System.Drawing.Color.LightGray;
        ownBoardLabel.Location = new System.Drawing.Point(50, 80);
        ownBoardLabel.Name = "ownBoardLabel";
        ownBoardLabel.Size = new System.Drawing.Size(300, 30);
        ownBoardLabel.TabIndex = 2;
        ownBoardLabel.Text = "YOUR BOARD";
        // 
        // oppBoardLabel
        // 
        oppBoardLabel.BackColor = System.Drawing.Color.Transparent;
        oppBoardLabel.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        oppBoardLabel.ForeColor = System.Drawing.Color.LightGray;
        oppBoardLabel.Location = new System.Drawing.Point(650, 80);
        oppBoardLabel.Name = "oppBoardLabel";
        oppBoardLabel.Size = new System.Drawing.Size(300, 30);
        oppBoardLabel.TabIndex = 3;
        oppBoardLabel.Text = "OPPONENT BOARD";
        // 
        // sonarBtn
        // 
        sonarBtn.BackColor = System.Drawing.Color.Transparent;
        sonarBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
        sonarBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        sonarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        sonarBtn.Font = new System.Drawing.Font("Unispace", 11.25F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        sonarBtn.ForeColor = System.Drawing.Color.Transparent;
        sonarBtn.Location = new System.Drawing.Point(1139, 580);
        sonarBtn.Name = "sonarBtn";
        sonarBtn.Size = new System.Drawing.Size(125, 42);
        sonarBtn.TabIndex = 4;
        sonarBtn.Text = "Sonar";
        sonarBtn.UseVisualStyleBackColor = false;
        sonarBtn.Click += sonarBtn_Click;
        // 
        // sonarCooldownLabel
        // 
        sonarCooldownLabel.BackColor = System.Drawing.Color.Transparent;
        sonarCooldownLabel.Font = new System.Drawing.Font("Unispace", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        sonarCooldownLabel.ForeColor = System.Drawing.Color.LightGray;
        sonarCooldownLabel.Location = new System.Drawing.Point(1139, 626);
        sonarCooldownLabel.Name = "sonarCooldownLabel";
        sonarCooldownLabel.Size = new System.Drawing.Size(125, 25);
        sonarCooldownLabel.TabIndex = 5;
        sonarCooldownLabel.Text = "Ready";
        sonarCooldownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // GameBoard
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.DarkSlateGray;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(1289, 677);
        Controls.Add(sonarCooldownLabel);
        Controls.Add(sonarBtn);
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
    private System.Windows.Forms.Button sonarBtn;
    private System.Windows.Forms.Label sonarCooldownLabel;
}