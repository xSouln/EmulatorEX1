using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xLib.UI_Propertys;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class DivX
    {
        public partial class Collections
        {
            public static ObservableCollection<UI_Property> Propertys { get; set; } = new ObservableCollection<UI_Property>
            {
                new UI_Property(){ Name = "Interlocks:" },
                CSB.Interlocks.Door1,
                CSB.Interlocks.Door2,
                CSB.Interlocks.Stop,
                CSB.Interlocks.Casing,
                CSB.Interlocks.BackCover,
                CSB.Interlocks.SideCover1,
                CSB.Interlocks.SideCover2,
                new UI_Property(){ },

                new UI_Property(){ Name = "Pins out:" },
                CSB.PinsOut.Curtain,
                CSB.PinsOut.IndicatorCurtain,
                CSB.PinsOut.IndicatorXRay1,
                CSB.PinsOut.IndicatorXRay2,
                CSB.PinsOut.LockResolution,
                CSB.PinsOut.SecurityLoop,
                CSB.PinsOut.TurnSamplePosSystem,
                new UI_Property(){ },

                new UI_Property(){ Name = "Handler:" },
                CSB.Handler.SelfTestComplite,
                CSB.Handler.SelfTestEnable,
                CSB.Handler.EnablingSafetyRing,
                CSB.Handler.Warning,
                new UI_Property(){ },
            };

            static Collections()
            {
                foreach (UI_Property property in Propertys) { property.Update(); }
            }
        }
    }
}
