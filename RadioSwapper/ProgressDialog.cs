using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RadioSwapper
{
    public partial class ProgressDialog : Form
    {
        private Thread Thread;
        private Action<ProgressDialog> Action;

        public ProgressDialog()
        {
            InitializeComponent();
        }


        public void RunTask(bool useShowDialog, Action<ProgressDialog> action)
        {
            ThreadStart ts = new ThreadStart(ThreadStart);
            Thread = new Thread(ts);
            Action = action;
            if (useShowDialog)
                this.ShowDialog();
            else
                this.Show();
        }

        private void ThreadStart()
        {
            Action(this);
        }

        private void ProgressDialog_Shown(object sender, EventArgs e)
        {
            Thread.Start();
        }

        private bool Closing = false;

        private void ProgressDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Closing)
                e.Cancel = true;
        }

        private delegate void SimpleDelegate();

        private delegate void StringDelegate(string text);

        public void SetTitle(string title, params object[] parameters)
        {
            string text = String.Format(title, parameters);
            this.Invoke(new StringDelegate(SetTitle_Internal), text);
        }

        private void SetTitle_Internal(string title)
        {
            this.Text = title;
        }

        public void SetText(string text, params object[] parameters)
        {
            text = String.Format(text, parameters);
            this.Invoke(new StringDelegate(SetText_Internal), text);
        }

        private void SetText_Internal(string text)
        {
            ProgressLabel.Text = text;
        }

        public void SetProgressBarSettings(int minimum, int maximum, int step, ProgressBarStyle style)
        {
            this.Invoke(new SetProgressBarSettings_Delegate(SetProgressBarSettings_Internal), minimum, maximum, step, style);
        }

        private delegate void SetProgressBarSettings_Delegate(int minimum, int maximum, int step, ProgressBarStyle style);
        private void SetProgressBarSettings_Internal(int minimum, int maximum, int step, ProgressBarStyle style)
        {
            CurrentProgress.Minimum = minimum;
            CurrentProgress.Maximum = maximum;
            CurrentProgress.Step = step;
            CurrentProgress.Style = style;
            CurrentProgress.Value = minimum;
        }

        public void Step()
        {
            this.Invoke(new SimpleDelegate(CurrentProgress.PerformStep));
        }

        public void CloseDialog()
        {
            Closing = true;
            this.Invoke(new SimpleDelegate(this.Close));
        }
    }
}
