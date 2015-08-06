using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow.Actions
{
    public class WarpPlayerAction : IGameAction
    {
        private float X, Y, Z;

        public WarpPlayerAction(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public ActionType Type
        {
            get { return ActionType.WarpPlayer; }
        }

        public void DoAction()
        {
            UnmanagedInterface.Log("DebugWindow", "Warping player to X: {0}, Y: {1}, Z: {2}\n", X, Y, Z);

            Structs.PlayerWarpParams warpParams = new Structs.PlayerWarpParams();
            warpParams.pp = GameState.PlayerAddress;
            warpParams.DestinationPosition = new Structs.FLVector();
            warpParams.DestinationPosition.X = X;
            warpParams.DestinationPosition.Y = Y;
            warpParams.DestinationPosition.Z = Z;
            warpParams.DestinationOrientation = new Structs.FLMatrix();
            warpParams.DestinationOrientation.rvec = new Structs.FLVector();
            warpParams.DestinationOrientation.uvec = new Structs.FLVector();
            warpParams.DestinationOrientation.fvec = new Structs.FLVector();
            warpParams.CheckUp = true;
            warpParams.WarpFollowers = true;
            warpParams.ExitVehicle = true;
            warpParams.ARHandle = (UInt16)(GameState.PlayerAddress.ToInt32());
            warpParams.ResetCameraOrientation = true;
            warpParams.ExitInterface = true;
            warpParams.FadeOutBefore = true;
            warpParams.FadeInAfter = true;
            warpParams.StickToGround = true;

            SRMethods.PlayerWarp(warpParams);

            UnmanagedInterface.Log("DebugWindow", "Warped player.\n", X, Y, Z);
        }
    }
}
