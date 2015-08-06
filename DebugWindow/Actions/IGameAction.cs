using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugWindow.Actions
{
    public interface IGameAction
    {
        ActionType Type { get; }
        void DoAction();
    }
}
