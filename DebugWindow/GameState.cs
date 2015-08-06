using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow
{
    public static class GameState
    {
        public static IntPtr PlayerAddress
        {
            get
            {
                switch (UnmanagedInterface.SRVersion)
                {
                    case GOOHVersion.Prerelease:
                        return new IntPtr(Memory.ReadInt32(0x02F7E94C));
                    case GOOHVersion.SteamPatch2:
                        return new IntPtr(Memory.ReadInt32(0x02E597FC));
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public static float PlayerX
        {
            get
            {
                if (PlayerAddress.ToInt32() == 0)
                    return 0;

                return Memory.ReadFloat((PlayerAddress + 0x8C) + 0);
            }
        }
        public static float PlayerY
        {
            get
            {
                if (PlayerAddress.ToInt32() == 0)
                    return 0;

                return Memory.ReadFloat((PlayerAddress + 0x8C) + 4);
            }
        }
        public static float PlayerZ
        {
            get
            {
                if (PlayerAddress.ToInt32() == 0)
                    return 0;

                return Memory.ReadFloat((PlayerAddress + 0x8C) + 8);
            }
        }
    }
}
