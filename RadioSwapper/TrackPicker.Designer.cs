namespace RadioSwapper
{
    partial class TrackPicker
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelPickingButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.TrackNumberBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DurationPicker = new System.Windows.Forms.NumericUpDown();
            this.BrowseOpenDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DurationPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(424, 91);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelPickingButton
            // 
            this.CancelPickingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelPickingButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelPickingButton.Location = new System.Drawing.Point(343, 91);
            this.CancelPickingButton.Name = "CancelPickingButton";
            this.CancelPickingButton.Size = new System.Drawing.Size(75, 23);
            this.CancelPickingButton.TabIndex = 1;
            this.CancelPickingButton.Text = "Cancel";
            this.CancelPickingButton.UseVisualStyleBackColor = true;
            this.CancelPickingButton.Click += new System.EventHandler(this.CancelPickingButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Location = new System.Drawing.Point(262, 91);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 2;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // TrackNumberBox
            // 
            this.TrackNumberBox.Location = new System.Drawing.Point(95, 12);
            this.TrackNumberBox.Name = "TrackNumberBox";
            this.TrackNumberBox.ReadOnly = true;
            this.TrackNumberBox.Size = new System.Drawing.Size(323, 20);
            this.TrackNumberBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Track number:";
            // 
            // FileNameBox
            // 
            this.FileNameBox.Location = new System.Drawing.Point(95, 38);
            this.FileNameBox.Name = "FileNameBox";
            this.FileNameBox.Size = new System.Drawing.Size(323, 20);
            this.FileNameBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "File:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(424, 36);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 7;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Duration (ms):";
            // 
            // DurationPicker
            // 
            this.DurationPicker.Location = new System.Drawing.Point(95, 64);
            this.DurationPicker.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.DurationPicker.Name = "DurationPicker";
            this.DurationPicker.Size = new System.Drawing.Size(323, 20);
            this.DurationPicker.TabIndex = 10;
            // 
            // BrowseOpenDialog
            // 
            this.BrowseOpenDialog.Filter = "Common files|*.wem;*.mp3;*.ogg;*.mp4;*.m4a;*.flac|Wwise audio files|*.wem|Audio f" +
    "iles|*.mp3;*.mp4;*.flac;*.m4a;*.ogg|All files|*.*";
            this.BrowseOpenDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.BrowseOpenDialog_FileOk);
            // 
            // TrackPicker
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelPickingButton;
            this.ClientSize = new System.Drawing.Size(511, 126);
            this.Controls.Add(this.DurationPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackNumberBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CancelPickingButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TrackPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pick track {0}";
            ((System.ComponentModel.ISupportInitialize)(this.DurationPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelPickingButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TextBox TrackNumberBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DurationPicker;
        private System.Windows.Forms.OpenFileDialog BrowseOpenDialog;
    }
}