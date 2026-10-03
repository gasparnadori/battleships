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
        8 = new System.Windows.Forms.RadioButton();
        radioButton1 = new System.Windows.Forms.RadioButton();
        10 = new System.Windows.Forms.RadioButton();
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
        tableSize.Location = new System.Drawing.Point(293, 227);
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
        button4.Location = new System.Drawing.Point(278, 473);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(335, 48);
        button4.TabIndex = 5;
        button4.Text = "Start battle!";
        button4.UseVisualStyleBackColor = false;
        // 
        // 8
        // 
        8.Appearance = System.Windows.Forms.Appearance.Button;
        8.BackColor = System.Drawing.Color.Transparent;
        8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        8.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        8.ForeColor = System.Drawing.SystemColors.ControlLight;
        8.Location = new System.Drawing.Point(195, 340);
        8.Name = "8";
        8.Size = new System.Drawing.Size(149, 63);
        8.TabIndex = 6;
        8.TabStop = true;
        8.Text = "8x8";
        8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        8.UseVisualStyleBackColor = false;
        // 
        // radioButton1
        // 
        radioButton1.Appearance = System.Windows.Forms.Appearance.Button;
        radioButton1.BackColor = System.Drawing.Color.Transparent;
        radioButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        radioButton1.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        radioButton1.ForeColor = System.Drawing.SystemColors.ControlLight;
        radioButton1.Location = new System.Drawing.Point(565, 340);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new System.Drawing.Size(149, 63);
        radioButton1.TabIndex = 7;
        radioButton1.TabStop = true;
        radioButton1.Text = "12x12";
        radioButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        radioButton1.UseVisualStyleBackColor = false;
        // 
        // 10
        // 
        10.Appearance = System.Windows.Forms.Appearance.Button;
        10.BackColor = System.Drawing.Color.Transparent;
        10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        10.Font = new System.Drawing.Font("Unispace", 21.75F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        10.ForeColor = System.Drawing.SystemColors.ControlLight;
        10.Location = new System.Drawing.Point(378, 340);
        10.Name = "10";
        10.Size = new System.Drawing.Size(149, 63);
        10.TabIndex = 8;
        10.TabStop = true;
        10.Text = "10x10";
        10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        10.UseVisualStyleBackColor = false;
        // 
        // GameSetup
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(905, 533);
        Controls.Add(10);
        Controls.Add(radioButton1);
        Controls.Add(8);
        Controls.Add(button4);
        Controls.Add(tableSize);
        Controls.Add(label1);
        DoubleBuffered = true;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Battleship";
        ResumeLayout(false);
    }

    private System.Windows.Forms.RadioButton radioButton1;

    private System.Windows.Forms.Button button4;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.Label tableSize;

    private System.Windows.Forms.Label label1;

    #endregion
}