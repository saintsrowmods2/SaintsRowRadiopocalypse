using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow
{
    public static class UnmanagedInterface
    {
        public static GOOHVersion SRVersion { get; private set; }
        private static Queue<Actions.IGameAction> ActionQueue = new Queue<Actions.IGameAction>();

        public static void QueueAction(Actions.IGameAction action)
        {
            lock (ActionQueue)
            {
                ActionQueue.Enqueue(action);
            }
        }

        public static void CreateDebugWindow(int srVersion)
        {
            Log("DebugWindow", "Creating DebugWindow...\n");
            SRVersion = (GOOHVersion)srVersion;
            DebugWindow.Start();
        }

        public static void UpdateWindow()
        {
            lock (ActionQueue)
            {
                while (ActionQueue.Count > 0)
                {
                    var action = ActionQueue.Dequeue();
                    action.DoAction();
                }
            }
        }

        public static void Log(string source, string format, params object[] args)
        {
            string message = String.Format(format, args);

            NativeMethods.WriteToLog(source, message);
        }
    }
}
