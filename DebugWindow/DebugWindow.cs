using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugWindow
{
    public partial class DebugWindow : Form
    {
        public static DebugWindow Window;

        public static void Start()
        {
            ThreadStart ts = new ThreadStart(Start_Thread);
            Thread t = new Thread(ts);
            t.Name = "DebugWindow thread";
            t.IsBackground = false;
            t.Start();
        }

        private static void Start_Thread()
        {
            Window = new DebugWindow();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            Application.Run(Window);
        }

        public DebugWindow()
        {
            InitializeComponent();
        }

        private void DebugWindow_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            GOOHVersionLabel.Text = "GOOH Version: " + UnmanagedInterface.SRVersion;
            PlayerPositionLabel.Text = String.Format("Current Position: (X: {0}, Y: {1}, Z: {2})", GameState.PlayerX, GameState.PlayerY, GameState.PlayerZ);
        }

        private void WarpPlayerButton_Click(object sender, EventArgs e)
        {
            Actions.WarpPlayerAction action = new Actions.WarpPlayerAction((float)WarpPlayerX.Value, (float)WarpPlayerY.Value, (float)WarpPlayerZ.Value);
            UnmanagedInterface.QueueAction(action);
        }

        private void PlayerWarpGetCurrentButton_Click(object sender, EventArgs e)
        {
            WarpPlayerX.Value = (decimal)GameState.PlayerX;
            WarpPlayerY.Value = (decimal)GameState.PlayerY;
            WarpPlayerZ.Value = (decimal)GameState.PlayerZ;
        }
    }
}
