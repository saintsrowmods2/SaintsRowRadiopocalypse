using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioSwapper
{
    public partial class TrackPicker : Form
    {
        public int TrackNo { get; private set; }
        public string FileName { get; private set; }
        public int Duration { get; private set; }
        public bool OriginalItem { get; private set; }

        public TrackPicker(int trackNo, string filename, int duration, bool originalItem)
        {
            InitializeComponent();

            TrackNo = trackNo;
            FileName = filename;
            Duration = duration;
            OriginalItem = originalItem;

            this.Text = String.Format("Pick track {0}", TrackNo);
            TrackNumberBox.Text = TrackNo.ToString();
            if (!OriginalItem)
                FileNameBox.Text = FileName;
            DurationPicker.Value = (decimal)Duration;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            FileName = String.Format("radio_genx_media.bnk_pc_{0:D5}.wem", TrackNo);
            switch (TrackNo)
            {
                case 1: Duration = 228176; break;
                case 2: Duration = 198000; break;
                case 3: Duration = 189600; break;
                case 4: Duration = 200200; break;
                case 5: Duration = 221160; break;
                case 6: Duration = 219550; break;
                case 7: Duration = 238561; break;
                case 8: Duration = 201760; break;
                case 9: Duration = 224810; break;
                case 10: Duration = 234390; break;
                case 11: Duration = 199100; break;
            }
            OriginalItem = true;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (FileNameBox.Text != "")
            {
                OriginalItem = false;
            }

            if (!OriginalItem)
            {
                FileName = FileNameBox.Text;
                Duration = (int)DurationPicker.Value;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelPickingButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            BrowseOpenDialog.ShowDialog();
        }

        private void BrowseOpenDialog_FileOk(object sender, CancelEventArgs e)
        {
            string filename = BrowseOpenDialog.FileName;

            ProcessStartInfo psi = new ProcessStartInfo(Path.Combine(Program.ExeLocation, "ogg-info.exe"), "\"" + filename + "\"");
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            p.Start();
            p.WaitForExit();
            string output = p.StandardOutput.ReadToEnd();
            string[] lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            decimal sampleRate = decimal.Parse(lines[0]);
            decimal samples = decimal.Parse(lines[1]);
            decimal duration = (samples / sampleRate) * 1000;

            duration = Math.Ceiling(duration);
            DurationPicker.Value = duration;

            FileNameBox.Text = filename;
        }
    }
}
