using System.ComponentModel;

namespace battleships.Battleship.WinForms;

partial class GameSetup
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSetup));
        label1 = new System.Windows.Forms.Label();
        tableSize = new System.Windows.Forms.Label();
        button4 = new System.Windows.Forms.Button();
        btn8 = new System.Windows.Forms.RadioButton();
        btn10 = new System.Windows.Forms.RadioButton();
        btn12 = new System.Windows.Forms.RadioButton();
        SuspendLayout();
        // 
        // label1
        // 
        label1.BackColor = System.Drawing.Color.Transparent;
        label1.Font = new System.Drawing.Font("Unispace", 36F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.LightGray;
        label1.Location = new System.Drawing.Point(295, 149);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(318, 79);
        label1.TabIndex = 0;
        label1.Text = "Battleship";
        // 
        // tableSize
        // 
        tableSize.BackColor = System.Drawing.Color.Transparent;
        tableSize.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        tableSize.ForeColor = System.Drawing.Color.LightGray;
        tableSize.Location = new System.Drawing.Point(295, 212);
        tableSize.Name = "tableSize";
        tableSize.Size = new System.Drawing.Size(318, 79);
        tableSize.TabIndex = 1;
        tableSize.Text = "Table size:";
        tableSize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        // 
        // button4
        // 
        button4.BackColor = System.Drawing.Color.IndianRed;
        button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        button4.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        button4.Location = new System.Drawing.Point(293, 454);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(335, 48);
        button4.TabIndex = 5;
        button4.Text = "Start the battle!";
        button4.UseVisualStyleBackColor = false;
        // 
        // btn8
        // 
        btn8.Appearance = System.Windows.Forms.Appearance.Button;
        btn8.BackColor = System.Drawing.Color.Transparent;
        btn8.FlatAppearance.BorderSize = 0;
        btn8.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)64)));
        btn8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btn8.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        btn8.ForeColor = System.Drawing.Color.Transparent;
        btn8.Location = new System.Drawing.Point(245, 328);
        btn8.Name = "btn8";
        btn8.Size = new System.Drawing.Size(116, 54);
        btn8.TabIndex = 6;
        btn8.TabStop = true;
        btn8.Text = "8x8";
        btn8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        btn8.UseVisualStyleBackColor = false;
        // 
        // btn10
        // 
        btn10.Appearance = System.Windows.Forms.Appearance.Button;
        btn10.BackColor = System.Drawing.Color.Transparent;
        btn10.FlatAppearance.BorderSize = 0;
        btn10.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)64)));
        btn10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        btn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btn10.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        btn10.ForeColor = System.Drawing.Color.Transparent;
        btn10.Location = new System.Drawing.Point(388, 328);
        btn10.Name = "btn10";
        btn10.Size = new System.Drawing.Size(116, 54);
        btn10.TabIndex = 7;
        btn10.TabStop = true;
        btn10.Text = "10x10";
        btn10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        btn10.UseVisualStyleBackColor = false;
        // 
        // btn12
        // 
        btn12.Appearance = System.Windows.Forms.Appearance.Button;
        btn12.BackColor = System.Drawing.Color.Transparent;
        btn12.FlatAppearance.BorderSize = 0;
        btn12.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)((byte)0)), ((int)((byte)64)), ((int)((byte)64)));
        btn12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        btn12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btn12.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        btn12.ForeColor = System.Drawing.Color.Transparent;
        btn12.Location = new System.Drawing.Point(543, 328);
        btn12.Name = "btn12";
        btn12.Size = new System.Drawing.Size(116, 54);
        btn12.TabIndex = 8;
        btn12.TabStop = true;
        btn12.Text = "12x12";
        btn12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        btn12.UseVisualStyleBackColor = false;
        // 
        // GameSetup
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(905, 533);
        Controls.Add(btn12);
        Controls.Add(btn10);
        Controls.Add(btn8);
        Controls.Add(button4);
        Controls.Add(tableSize);
        Controls.Add(label1);
        DoubleBuffered = true;
        ForeColor = System.Drawing.Color.Transparent;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Battleship";
        ResumeLayout(false);
    }

    private System.Windows.Forms.RadioButton btn10;
    private System.Windows.Forms.RadioButton btn12;

    private System.Windows.Forms.RadioButton btn8;

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Label tableSize;

    private System.Windows.Forms.Label label1;

    #endregion
}