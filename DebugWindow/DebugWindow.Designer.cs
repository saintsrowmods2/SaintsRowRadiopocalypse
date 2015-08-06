namespace DebugWindow
{
    partial class DebugWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayerWarpGetCurrentButton = new System.Windows.Forms.Button();
            this.WarpPlayerButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.WarpPlayerZ = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.WarpPlayerY = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.WarpPlayerX = new System.Windows.Forms.NumericUpDown();
            this.PlayerPositionLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.GOOHVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BeGatButton = new System.Windows.Forms.Button();
            this.BeKinzieButton = new System.Windows.Forms.Button();
            this.EnterPlanetZinButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarpPlayerZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarpPlayerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarpPlayerX)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 5;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PlayerWarpGetCurrentButton);
            this.groupBox1.Controls.Add(this.WarpPlayerButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.WarpPlayerZ);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.WarpPlayerY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.WarpPlayerX);
            this.groupBox1.Controls.Add(this.PlayerPositionLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player position";
            // 
            // PlayerWarpGetCurrentButton
            // 
            this.PlayerWarpGetCurrentButton.Location = new System.Drawing.Point(6, 58);
            this.PlayerWarpGetCurrentButton.Name = "PlayerWarpGetCurrentButton";
            this.PlayerWarpGetCurrentButton.Size = new System.Drawing.Size(75, 23);
            this.PlayerWarpGetCurrentButton.TabIndex = 10;
            this.PlayerWarpGetCurrentButton.Text = "Get Current";
            this.PlayerWarpGetCurrentButton.UseVisualStyleBackColor = true;
            this.PlayerWarpGetCurrentButton.Click += new System.EventHandler(this.PlayerWarpGetCurrentButton_Click);
            // 
            // WarpPlayerButton
            // 
            this.WarpPlayerButton.Location = new System.Drawing.Point(87, 58);
            this.WarpPlayerButton.Name = "WarpPlayerButton";
            this.WarpPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.WarpPlayerButton.TabIndex = 9;
            this.WarpPlayerButton.Text = "Warp";
            this.WarpPlayerButton.UseVisualStyleBackColor = true;
            this.WarpPlayerButton.Click += new System.EventHandler(this.WarpPlayerButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Z:";
            // 
            // WarpPlayerZ
            // 
            this.WarpPlayerZ.DecimalPlaces = 2;
            this.WarpPlayerZ.Location = new System.Drawing.Point(327, 32);
            this.WarpPlayerZ.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.WarpPlayerZ.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.WarpPlayerZ.Name = "WarpPlayerZ";
            this.WarpPlayerZ.Size = new System.Drawing.Size(120, 20);
            this.WarpPlayerZ.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y:";
            // 
            // WarpPlayerY
            // 
            this.WarpPlayerY.DecimalPlaces = 2;
            this.WarpPlayerY.Location = new System.Drawing.Point(178, 32);
            this.WarpPlayerY.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.WarpPlayerY.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.WarpPlayerY.Name = "WarpPlayerY";
            this.WarpPlayerY.Size = new System.Drawing.Size(120, 20);
            this.WarpPlayerY.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X:";
            // 
            // WarpPlayerX
            // 
            this.WarpPlayerX.DecimalPlaces = 2;
            this.WarpPlayerX.Location = new System.Drawing.Point(29, 32);
            this.WarpPlayerX.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.WarpPlayerX.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.WarpPlayerX.Name = "WarpPlayerX";
            this.WarpPlayerX.Size = new System.Drawing.Size(120, 20);
            this.WarpPlayerX.TabIndex = 3;
            // 
            // PlayerPositionLabel
            // 
            this.PlayerPositionLabel.AutoSize = true;
            this.PlayerPositionLabel.Location = new System.Drawing.Point(6, 16);
            this.PlayerPositionLabel.Name = "PlayerPositionLabel";
            this.PlayerPositionLabel.Size = new System.Drawing.Size(84, 13);
            this.PlayerPositionLabel.TabIndex = 2;
            this.PlayerPositionLabel.Text = "Current Position:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GOOHVersionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1039, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // GOOHVersionLabel
            // 
            this.GOOHVersionLabel.Name = "GOOHVersionLabel";
            this.GOOHVersionLabel.Size = new System.Drawing.Size(1024, 17);
            this.GOOHVersionLabel.Spring = true;
            this.GOOHVersionLabel.Text = "SRVersion";
            this.GOOHVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.EnterPlanetZinButton);
            this.groupBox2.Controls.Add(this.BeKinzieButton);
            this.groupBox2.Controls.Add(this.BeGatButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 89);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player customization";
            // 
            // BeGatButton
            // 
            this.BeGatButton.Location = new System.Drawing.Point(6, 19);
            this.BeGatButton.Name = "BeGatButton";
            this.BeGatButton.Size = new System.Drawing.Size(75, 23);
            this.BeGatButton.TabIndex = 0;
            this.BeGatButton.Text = "Be Gat";
            this.BeGatButton.UseVisualStyleBackColor = true;
            // 
            // BeKinzieButton
            // 
            this.BeKinzieButton.Location = new System.Drawing.Point(6, 48);
            this.BeKinzieButton.Name = "BeKinzieButton";
            this.BeKinzieButton.Size = new System.Drawing.Size(75, 23);
            this.BeKinzieButton.TabIndex = 1;
            this.BeKinzieButton.Text = "Be Kinzie";
            this.BeKinzieButton.UseVisualStyleBackColor = true;
            // 
            // EnterPlanetZinButton
            // 
            this.EnterPlanetZinButton.Location = new System.Drawing.Point(87, 48);
            this.EnterPlanetZinButton.Name = "EnterPlanetZinButton";
            this.EnterPlanetZinButton.Size = new System.Drawing.Size(156, 23);
            this.EnterPlanetZinButton.TabIndex = 2;
            this.EnterPlanetZinButton.Text = "Planet Zin";
            this.EnterPlanetZinButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Image as Designed";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 600);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DebugWindow";
            this.Text = "Debug Window";
            this.Load += new System.EventHandler(this.DebugWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WarpPlayerZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarpPlayerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarpPlayerX)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button WarpPlayerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown WarpPlayerZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown WarpPlayerY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown WarpPlayerX;
        private System.Windows.Forms.Label PlayerPositionLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel GOOHVersionLabel;
        private System.Windows.Forms.Button PlayerWarpGetCurrentButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BeKinzieButton;
        private System.Windows.Forms.Button BeGatButton;
        private System.Windows.Forms.Button EnterPlanetZinButton;
        private System.Windows.Forms.Button button1;
    }
}