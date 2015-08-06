using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x24)]
    public struct FLMatrix
    {
        [FieldOffset(0x00)]
        public FLVector rvec;

        [FieldOffset(0x0C)]
        public FLVector uvec;

        [FieldOffset(0x18)]
        public FLVector fvec;
    }
}
