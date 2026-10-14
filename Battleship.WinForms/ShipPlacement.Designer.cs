using System.ComponentModel;

namespace battleships.Battleship.WinForms;

partial class ShipPlacement
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShipPlacement));
        rotateBtn = new System.Windows.Forms.Button();
        doneBtn = new System.Windows.Forms.Button();
        playerLabel = new System.Windows.Forms.Label();
        shipLabel = new System.Windows.Forms.Label();
        orientationLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // rotateBtn
        // 
        rotateBtn.BackColor = System.Drawing.Color.Transparent;
        rotateBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
        rotateBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
        rotateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        rotateBtn.Font = new System.Drawing.Font("Unispace", 11.999998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        rotateBtn.ForeColor = System.Drawing.Color.Transparent;
        rotateBtn.Location = new System.Drawing.Point(21, 610);
        rotateBtn.Name = "rotateBtn";
        rotateBtn.Size = new System.Drawing.Size(125, 42);
        rotateBtn.TabIndex = 0;
        rotateBtn.Text = "Rotate (R)";
        rotateBtn.UseVisualStyleBackColor = false;
        rotateBtn.Click += button1_Click;
        // 
        // doneBtn
        // 
        doneBtn.BackColor = System.Drawing.Color.Transparent;
        doneBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
        doneBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSeaGreen;
        doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        doneBtn.Font = new System.Drawing.Font("Unispace", 11.999998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        doneBtn.ForeColor = System.Drawing.Color.Transparent;
        doneBtn.Location = new System.Drawing.Point(1139, 610);
        doneBtn.Name = "doneBtn";
        doneBtn.Size = new System.Drawing.Size(125, 42);
        doneBtn.TabIndex = 1;
        doneBtn.Text = "Done!";
        doneBtn.UseVisualStyleBackColor = false;
        doneBtn.Click += doneBtn_Click;
        // 
        // playerLabel
        // 
        playerLabel.BackColor = System.Drawing.Color.Transparent;
        playerLabel.Font = new System.Drawing.Font("Unispace", 15.749998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        playerLabel.ForeColor = System.Drawing.Color.IndianRed;
        playerLabel.Location = new System.Drawing.Point(15, 17);
        playerLabel.Name = "playerLabel";
        playerLabel.Size = new System.Drawing.Size(359, 38);
        playerLabel.TabIndex = 2;
        playerLabel.Text = "label1";
        // 
        // shipLabel
        // 
        shipLabel.BackColor = System.Drawing.Color.Transparent;
        shipLabel.Font = new System.Drawing.Font("Unispace", 15.749998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        shipLabel.ForeColor = System.Drawing.Color.LightGray;
        shipLabel.Location = new System.Drawing.Point(15, 68);
        shipLabel.Name = "shipLabel";
        shipLabel.Size = new System.Drawing.Size(349, 38);
        shipLabel.TabIndex = 3;
        shipLabel.Text = "label1";
        // 
        // orientationLabel
        // 
        orientationLabel.BackColor = System.Drawing.Color.Transparent;
        orientationLabel.Font = new System.Drawing.Font("Unispace", 15.749998F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        orientationLabel.ForeColor = System.Drawing.Color.LightGray;
        orientationLabel.Location = new System.Drawing.Point(314, 68);
        orientationLabel.Name = "orientationLabel";
        orientationLabel.Size = new System.Drawing.Size(349, 38);
        orientationLabel.TabIndex = 4;
        orientationLabel.Text = "label1";
        // 
        // ShipPlacement
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(1289, 677);
        Controls.Add(orientationLabel);
        Controls.Add(shipLabel);
        Controls.Add(playerLabel);
        Controls.Add(doneBtn);
        Controls.Add(rotateBtn);
        DoubleBuffered = true;
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "ShipPlacement";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label orientationLabel;

    private System.Windows.Forms.Label shipLabel;

    private System.Windows.Forms.Label playerLabel;

    private System.Windows.Forms.Button doneBtn;

    private System.Windows.Forms.Button rotateBtn;

    #endregion
}