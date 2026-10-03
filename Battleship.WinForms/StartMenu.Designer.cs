using System.ComponentModel;

namespace battleships.Battleship.WinForms;

partial class StartMenu
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartMenu));
        title = new System.Windows.Forms.Label();
        newGameBtn = new System.Windows.Forms.Button();
        loadBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // title
        // 
        title.BackColor = System.Drawing.Color.Transparent;
        title.Font = new System.Drawing.Font("Unispace", 36F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        title.ForeColor = System.Drawing.Color.LightGray;
        title.Location = new System.Drawing.Point(295, 149);
        title.Name = "title";
        title.Size = new System.Drawing.Size(318, 79);
        title.TabIndex = 0;
        title.Text = "Battleship";
        title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // newGameBtn
        // 
        newGameBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        newGameBtn.BackColor = System.Drawing.Color.Transparent;
        newGameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        newGameBtn.Font = new System.Drawing.Font("Unispace", 20.249998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        newGameBtn.ForeColor = System.Drawing.Color.LightGray;
        newGameBtn.Location = new System.Drawing.Point(182, 359);
        newGameBtn.Name = "newGameBtn";
        newGameBtn.Size = new System.Drawing.Size(201, 64);
        newGameBtn.TabIndex = 1;
        newGameBtn.Text = "New game";
        newGameBtn.UseVisualStyleBackColor = false;
        newGameBtn.Click += newGameBtn_Click;
        // 
        // loadBtn
        // 
        loadBtn.BackColor = System.Drawing.Color.Transparent;
        loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        loadBtn.Font = new System.Drawing.Font("Unispace", 20.249998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        loadBtn.ForeColor = System.Drawing.Color.LightGray;
        loadBtn.Location = new System.Drawing.Point(480, 359);
        loadBtn.Name = "loadBtn";
        loadBtn.Size = new System.Drawing.Size(201, 64);
        loadBtn.TabIndex = 2;
        loadBtn.Text = "Load game";
        loadBtn.UseVisualStyleBackColor = false;
        // 
        // StartMenu
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(905, 533);
        Controls.Add(loadBtn);
        Controls.Add(newGameBtn);
        Controls.Add(title);
        DoubleBuffered = true;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Battleship";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button loadBtn;

    private System.Windows.Forms.Button newGameBtn;

    private System.Windows.Forms.Label title;

    #endregion
}