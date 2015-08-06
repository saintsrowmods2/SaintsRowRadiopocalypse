using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow.Structs
{
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct PlayerWarpParams
    {
        [FieldOffset(0x00)]
        public IntPtr pp;

        [FieldOffset(0x04)]
        public FLVector DestinationPosition;

        [FieldOffset(0x10)]
        public FLMatrix DestinationOrientation;

        [FieldOffset(0x34)]
        [MarshalAs(UnmanagedType.I1)]
        public bool CheckUp;

        [FieldOffset(0x35)]
        [MarshalAs(UnmanagedType.I1)]
        public bool WarpFollowers;

        [FieldOffset(0x36)]
        [MarshalAs(UnmanagedType.I1)]
        public bool ExitVehicle;

        [FieldOffset(0x38)]
        public UInt16 ARHandle;

        [FieldOffset(0x3A)]
        [MarshalAs(UnmanagedType.I1)]
        public bool ResetCameraOrientation;

        [FieldOffset(0x3B)]
        [MarshalAs(UnmanagedType.I1)]
        public bool ExitInterface;

        [FieldOffset(0x3C)]
        [MarshalAs(UnmanagedType.I1)]
        public bool FadeOutBefore;

        [FieldOffset(0x3D)]
        [MarshalAs(UnmanagedType.I1)]
        public bool FadeInAfter;

        [FieldOffset(0x3E)]
        [MarshalAs(UnmanagedType.I1)]
        public bool StickToGround;
    }
}
