using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Emulator_ex_0_.EmulatorDivX.CSB.Types;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class CSB
    {
        public static UIHandler Handler = new UIHandler();
        public static UIInterlocks Interlocks = new UIInterlocks();
        public static UIPinsOut PinsOut = new UIPinsOut();

        public static StateT State
        {
            set
            {
                Handler.Value = value.Handler;
                Interlocks.Value = value.Interlocks;
                PinsOut.Value = value.Control;
            }
            get
            {
                StateT state = new StateT
                {
                    Interlocks = Interlocks.Value,
                    Handler = Handler.Value,
                    Control = PinsOut.Value
                };

                return state;
            }
        }
    }
}
