using System;   
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow
{
    public static class SRMethods
    {
        private delegate void player_warp(IntPtr warpParams);

        private static IntPtr playerWarpPtr = IntPtr.Zero;
        public static void PlayerWarp(Structs.PlayerWarpParams warpParams)
        {
            if (playerWarpPtr == IntPtr.Zero)
            {
                playerWarpPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Structs.PlayerWarpParams)));
                Marshal.StructureToPtr<Structs.PlayerWarpParams>(warpParams, playerWarpPtr, false);
            }
            else
            {
                Marshal.StructureToPtr<Structs.PlayerWarpParams>(warpParams, playerWarpPtr, true);
            }

            IntPtr functionPtr = IntPtr.Zero;

            switch (UnmanagedInterface.SRVersion)
            {
                case GOOHVersion.Prerelease:
                    functionPtr = new IntPtr(0x00C05620);
                    break;
                case GOOHVersion.SteamPatch2:
                    functionPtr = new IntPtr(0x00B1CC10);
                    break;
                default:
                    throw new NotImplementedException();
            }

            var nativeFunc = Marshal.GetDelegateForFunctionPointer<player_warp>(functionPtr);
            nativeFunc(playerWarpPtr);
        }
    }
}
