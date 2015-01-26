using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ThomasJepp.SaintsRow;
using ThomasJepp.SaintsRow.Packfiles;
using ThomasJepp.SaintsRow.Soundbanks.Streaming;

namespace RadioSwapper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            foreach (ListViewItem item in TrackList.Items)
            {
                item.Tag = true;
            }
        }

        private void TrackList_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = TrackList.SelectedItems[0];
            int trackNo = int.Parse(item.Text);
            string fileName = item.SubItems[1].Text;
            int duration = int.Parse(item.SubItems[2].Text);
            bool originalItem = (bool)item.Tag;

            TrackPicker picker = new TrackPicker(trackNo, fileName, duration, originalItem);
            DialogResult dr = picker.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                item.Text = picker.TrackNo.ToString();
                item.SubItems[1].Text = picker.FileName;
                item.SubItems[2].Text = picker.Duration.ToString();
                item.Tag = picker.OriginalItem;
            }
        }

        uint[] idList = { 324988913, 85680141, 361499031, 74446416, 67568313, 425254467, 472559082, 110939651, 70986557, 510391909, 190504143 };

        private void BuildSwap_Click(object sender, EventArgs e)
        {
            List<int> durations = new List<int>();

            string gamePath = Utility.GetGamePath(Game.SaintsRowGatOutOfHell);

            if (gamePath == null)
            {
                MessageBox.Show("Unable to locate your Saints Row: Gat Out Of Hell.");
                return;
            }

            string soundsCommonPath = Path.Combine(gamePath, "packfiles", "pc", "cache", "sounds_common.vpp_pc");

            StreamingSoundbank originalBank = null;

            using (Stream stream = File.OpenRead(soundsCommonPath))
            {
                using (IPackfile packfile = Packfile.FromStream(stream, false))
                {
                    foreach (var entry in packfile.Files)
                    {
                        if (entry.Name == "radio_genx_media.bnk_pc")
                        {
                            Stream soundbankStream = entry.GetStream();
                            originalBank = new StreamingSoundbank(soundbankStream);
                        }
                    }
                }
            }

            if (!Directory.Exists("out"))
                Directory.CreateDirectory("out");

            using (StreamingSoundbank bank = new StreamingSoundbank())
            {
                bank.Header.WwiseBankId = 1161617427;
                for (int i = 0; i < TrackList.Items.Count; i++)
                {
                    uint id = idList[i];
                    ListViewItem item = TrackList.Items[i];

                    int trackNo = int.Parse(item.Text);
                    string fileName = item.SubItems[1].Text;
                    int duration = int.Parse(item.SubItems[2].Text);
                    durations.Add(duration);
                    bool originalItem = (bool)item.Tag;

                    if (originalItem)
                    {
                        Stream s = originalBank.Files[i].GetAudioStream();
                        bank.AddFile(id, s);
                    }
                    else
                    {
                        Stream s = File.OpenRead(fileName);
                        bank.AddFile(id, s);
                    }
                }

                if (File.Exists("out/radio_genx_media.bnk_pc"))
                    File.Delete("out/radio_genx_media.bnk_pc");

                MemoryStream mbnkStream = new MemoryStream();

                using (Stream bnkStream = File.OpenWrite("out/radio_genx_media.bnk_pc"))
                {
                    bank.Save(bnkStream, mbnkStream);
                }
                mbnkStream.Seek(0, SeekOrigin.Begin);

                string soundbootPath = Path.Combine(gamePath, "packfiles", "pc", "cache", "soundboot.vpp_pc");
                using (ThomasJepp.SaintsRow.Packfiles.Version0A.Packfile newSoundboot = new ThomasJepp.SaintsRow.Packfiles.Version0A.Packfile(false))
                {
                    newSoundboot.IsCompressed = true;
                    newSoundboot.IsCondensed = true;

                    using (Stream oldSoundbootStream = File.OpenRead(soundbootPath))
                    {
                        using (IPackfile packfile = Packfile.FromStream(oldSoundbootStream, false))
                        {
                            foreach (var entry in packfile.Files)
                            {
                                if (entry.Name == "radio_genx_media.mbnk_pc")
                                    newSoundboot.AddFile(mbnkStream, entry.Name);
                                else
                                    newSoundboot.AddFile(entry.GetStream(), entry.Name);
                            }
                        }

                        if (File.Exists("out/soundboot.vpp_pc"))
                            File.Delete("out/soundboot.vpp_pc");

                        using (Stream soundbootStream = File.Open("out/soundboot.vpp_pc", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read))
                        {
                            newSoundboot.Save(soundbootStream);
                            soundbootStream.Flush();
                        }
                    }
                }
            }

            string template = File.ReadAllText(Path.Combine(Program.ExeLocation, "genx_radio.xtbl.template"));
            string xtblData = String.Format(template, durations[0], durations[1], durations[2], durations[3], durations[4], durations[5], durations[6], durations[7], durations[8], durations[9], durations[10]);
            if (File.Exists("out/genx_radio.xtbl"))
                File.Delete("out/genx_radio.xtbl");
            File.WriteAllText("out/genx_radio.xtbl", xtblData);

            MessageBox.Show("Finished building new soundbank.");
        }
    }
}
