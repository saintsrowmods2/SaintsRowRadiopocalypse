using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow
{
    public static class Memory
    {
        public static int ReadInt32(int address)
        {
            return ReadInt32(new IntPtr(address));
        }

        public static int ReadInt32(IntPtr address)
        {
            byte[] buf = new byte[4];
            Marshal.Copy(address, buf, 0, buf.Length);
            return BitConverter.ToInt32(buf, 0);
        }


        public static float ReadFloat(int address)
        {
            return ReadFloat(new IntPtr(address));
        }

        public static float ReadFloat(IntPtr address)
        {
            byte[] buf = new byte[4];
            Marshal.Copy(address, buf, 0, buf.Length);
            return BitConverter.ToSingle(buf, 0);
        }
    }
}
