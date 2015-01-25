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
using System.Xml;

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

        private string FileToConvert;
        private string ConvertedFile;
        
        private const string wwise32bit = @"C:\Program Files\Audiokinetic\Wwise v2012.2 build 4419\Authoring\Win32\Release\bin\WwiseCLI.exe";
        private const string wwise64bit = @"C:\Program Files (x86)\Audiokinetic\Wwise v2012.2 build 4419\Authoring\Win32\Release\bin\WwiseCLI.exe";

        private void DoConversion(ProgressDialog dialog)
        {
            dialog.SetProgressBarSettings(0, 100, 10, ProgressBarStyle.Marquee);
            dialog.SetTitle("Converting file...");
            dialog.SetText("Converting file...");

            string filename = FileToConvert;

            string tempDir = Path.Combine(Program.ExeLocation, "temp");
            string convertedDir = Path.Combine(Program.ExeLocation, "converted");

            string wwisePath = "";

            if (File.Exists(wwise32bit))
            {
                wwisePath = wwise32bit;
            }
            else if (File.Exists(wwise64bit))
            {
                wwisePath = wwise64bit;
            }
            
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            if (!Directory.Exists(convertedDir))
                Directory.CreateDirectory(convertedDir);

            string tempWavPath = Path.Combine(tempDir, Path.ChangeExtension(Path.GetFileName(filename), "wav"));
            string wemPath = Path.Combine(convertedDir, "Windows", Path.ChangeExtension(Path.GetFileName(filename), "wem"));

            if (File.Exists(wemPath))
            {
                filename = wemPath;
            }
            else
            {
                string projectPath = Path.Combine(Program.ExeLocation, "wwise", "Test.wproj");
                string sourcesPath = Path.Combine(tempDir, "settings.wsources");

                string ffmpegParams = String.Format("-i \"{0}\" \"{1}\"", filename, tempWavPath);

                if (File.Exists(tempWavPath))
                    File.Delete(tempWavPath);

                if (File.Exists(wemPath))
                    File.Delete(wemPath);

                ProcessStartInfo ffmpeg_psi = new ProcessStartInfo(Path.Combine(Program.ExeLocation, "ffmpeg.exe"), ffmpegParams);
                ffmpeg_psi.CreateNoWindow = true;
                ffmpeg_psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process ffmpeg = Process.Start(ffmpeg_psi);
                ffmpeg.WaitForExit();

                if (File.Exists(sourcesPath))
                    File.Delete(sourcesPath);

                using (Stream sourcesStream = File.OpenWrite(sourcesPath))
                {
                    using (XmlWriter writer = XmlWriter.Create(sourcesStream))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("ExternalSourcesList");
                        writer.WriteAttributeString("SchemaVersion", "1");
                        writer.WriteAttributeString("Root", tempDir);
                        writer.WriteStartElement("Source");
                        writer.WriteAttributeString("Path", Path.GetFileName(tempWavPath));
                        writer.WriteAttributeString("Conversion", "Default Conversion Settings");
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }

                ProcessStartInfo wwise_psi = new ProcessStartInfo(wwisePath, String.Format("\"{0}\" -ConvertExternalSources Windows \"{1}\" -ExternalSourcesOutput \"{2}\"", projectPath, sourcesPath, convertedDir));
                wwise_psi.CreateNoWindow = true;
                wwise_psi.WindowStyle = ProcessWindowStyle.Hidden;
                Process wwise = Process.Start(wwise_psi);
                wwise.WaitForExit();

                if (File.Exists(tempWavPath))
                    File.Delete(tempWavPath);

                filename = wemPath;
            }

            dialog.CloseDialog();

            ConvertedFile = filename;
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = BrowseOpenDialog.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string filename = BrowseOpenDialog.FileName;

                string extension = Path.GetExtension(filename);
                if (extension != ".wem")
                {
                    if (!File.Exists(wwise32bit) && !File.Exists(wwise64bit))
                    {
                        MessageBox.Show("Could not find a Wwise installation.\nYou need Wwise v2012.2 build 4419 installed to use audio that is not in wem format.");
                        return;
                    }

                    ProgressDialog dialog = new ProgressDialog();
                    FileToConvert = filename;
                    dialog.RunTask(true, DoConversion);
                    filename = ConvertedFile;
                }

                DurationPicker.Value = DurationCalculator.GetDuration(filename);

                FileNameBox.Text = filename;

            }
        }

        private void BrowseOpenDialog_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}
