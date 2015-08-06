using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DebugWindow
{
    public static class NativeMethods
    {
        [DllImport("xinput1_3.dll", CharSet=CharSet.Unicode)]
        public static extern void WriteToLog([MarshalAs(UnmanagedType.LPWStr)]string source, [MarshalAs(UnmanagedType.LPWStr)]string message);
    }
}
