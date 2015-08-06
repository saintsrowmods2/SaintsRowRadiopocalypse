using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct FLVector
    {
        [FieldOffset(0x00)]
        public float X;

        [FieldOffset(0x04)]
        public float Y;

        [FieldOffset(0x08)]
        public float Z;
    }
}
