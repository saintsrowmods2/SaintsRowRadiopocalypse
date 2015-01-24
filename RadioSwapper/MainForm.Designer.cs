namespace RadioSwapper
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "radio_genx_media.bnk_pc_00001.wem",
            "228176"}, -1);
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "radio_genx_media.bnk_pc_00002.wem",
            "198000"}, -1);
            System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem(new string[] {
            "3",
            "radio_genx_media.bnk_pc_00003.wem",
            "189600"}, -1);
            System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem(new string[] {
            "4",
            "radio_genx_media.bnk_pc_00004.wem",
            "200200"}, -1);
            System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem(new string[] {
            "5",
            "radio_genx_media.bnk_pc_00005.wem",
            "221160"}, -1);
            System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem(new string[] {
            "6",
            "radio_genx_media.bnk_pc_00006.wem",
            "219550"}, -1);
            System.Windows.Forms.ListViewItem listViewItem29 = new System.Windows.Forms.ListViewItem(new string[] {
            "7",
            "radio_genx_media.bnk_pc_00007.wem",
            "238561"}, -1);
            System.Windows.Forms.ListViewItem listViewItem30 = new System.Windows.Forms.ListViewItem(new string[] {
            "8",
            "radio_genx_media.bnk_pc_00008.wem",
            "201760"}, -1);
            System.Windows.Forms.ListViewItem listViewItem31 = new System.Windows.Forms.ListViewItem(new string[] {
            "9",
            "radio_genx_media.bnk_pc_00009.wem",
            "224810"}, -1);
            System.Windows.Forms.ListViewItem listViewItem32 = new System.Windows.Forms.ListViewItem(new string[] {
            "10",
            "radio_genx_media.bnk_pc_00010.wem",
            "234390"}, -1);
            System.Windows.Forms.ListViewItem listViewItem33 = new System.Windows.Forms.ListViewItem(new string[] {
            "11",
            "radio_genx_media.bnk_pc_00011.wem",
            "199100"}, -1);
            this.TrackList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BuildSwap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TrackList
            // 
            this.TrackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.TrackList.FullRowSelect = true;
            this.TrackList.GridLines = true;
            this.TrackList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.TrackList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem23,
            listViewItem24,
            listViewItem25,
            listViewItem26,
            listViewItem27,
            listViewItem28,
            listViewItem29,
            listViewItem30,
            listViewItem31,
            listViewItem32,
            listViewItem33});
            this.TrackList.Location = new System.Drawing.Point(12, 12);
            this.TrackList.MultiSelect = false;
            this.TrackList.Name = "TrackList";
            this.TrackList.Size = new System.Drawing.Size(767, 251);
            this.TrackList.TabIndex = 0;
            this.TrackList.UseCompatibleStateImageBehavior = false;
            this.TrackList.View = System.Windows.Forms.View.Details;
            this.TrackList.ItemActivate += new System.EventHandler(this.TrackList_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Track";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File";
            this.columnHeader2.Width = 602;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Duration (ms)";
            this.columnHeader3.Width = 100;
            // 
            // BuildSwap
            // 
            this.BuildSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildSwap.Location = new System.Drawing.Point(704, 269);
            this.BuildSwap.Name = "BuildSwap";
            this.BuildSwap.Size = new System.Drawing.Size(75, 23);
            this.BuildSwap.TabIndex = 1;
            this.BuildSwap.Text = "Build";
            this.BuildSwap.UseVisualStyleBackColor = true;
            this.BuildSwap.Click += new System.EventHandler(this.BuildSwap_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 304);
            this.Controls.Add(this.BuildSwap);
            this.Controls.Add(this.TrackList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Radio Swapper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView TrackList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button BuildSwap;
    }
}

