using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using xLib.UI_Propertys;
using static Emulator_ex_0_.EmulatorDivX.CSB.Types;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class CSB
    {
        public class UIPinsOut
        {
            private EPinsOut state;

            public UI_Property<bool, EPinsOut> IndicatorCurtain = new UI_Property<bool, EPinsOut> { Name = "Индикатор шторки", Request = EPinsOut.IndicatorCurtain, BackgroundValueRule = Rule2 };
            public UI_Property<bool, EPinsOut> LockResolution = new UI_Property<bool, EPinsOut> { Name = "Открытие дверки", Request = EPinsOut.LockResolution, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EPinsOut> Curtain = new UI_Property<bool, EPinsOut> { Name = "Шторка", Request = EPinsOut.Curtain, BackgroundValueRule = Rule2 };
            public UI_Property<bool, EPinsOut> SecurityLoop = new UI_Property<bool, EPinsOut> { Name = "Петля безопастности", Request = EPinsOut.SecurityLoop, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EPinsOut> TurnSamplePosSystem = new UI_Property<bool, EPinsOut> { Name = "Реле", Request = EPinsOut.TurnSamplePosSystem, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EPinsOut> IndicatorXRay1 = new UI_Property<bool, EPinsOut> { Name = "Индикатор рентген 1", Request = EPinsOut.IndicatorXRay_1, BackgroundValueRule = Rule2 };
            public UI_Property<bool, EPinsOut> IndicatorXRay2 = new UI_Property<bool, EPinsOut> { Name = "Индикатор рентген 2", Request = EPinsOut.IndicatorXRay_2, BackgroundValueRule = Rule2 };

            private static Brush Rule1(UI_Property<bool, EPinsOut> property)
            {
                return property.Value ? UI_Property.GREEN : UI_Property.RED;
            }

            private static Brush Rule2(UI_Property<bool, EPinsOut> property)
            {
                return property.Value ? UI_Property.RED : UI_Property.GREEN;
            }

            public UIPinsOut()
            {
                IndicatorCurtain.EventSelection += EventSelection;
                LockResolution.EventSelection += EventSelection;
                Curtain.EventSelection += EventSelection;
                SecurityLoop.EventSelection += EventSelection;
                TurnSamplePosSystem.EventSelection += EventSelection;
                IndicatorXRay1.EventSelection += EventSelection;
                IndicatorXRay2.EventSelection += EventSelection;
            }

            private void EventSelection(UI_Property<bool, EPinsOut> arg)
            {
                arg.Value ^= true;
                if (arg.Value) { state |= arg.Request; }
                else { state &= ~arg.Request; }
            }

            private bool IsEnable(EPinsOut request) { return (request & state) == request; }

            public EPinsOut Value
            {
                set
                {
                    state = value;

                    Curtain.Value = IsEnable(EPinsOut.Curtain);
                    IndicatorCurtain.Value = IsEnable(EPinsOut.IndicatorCurtain);
                    SecurityLoop.Value = IsEnable(EPinsOut.SecurityLoop);
                    TurnSamplePosSystem.Value = IsEnable(EPinsOut.TurnSamplePosSystem);
                    IndicatorXRay1.Value = IsEnable(EPinsOut.IndicatorXRay_1);
                    IndicatorXRay2.Value = IsEnable(EPinsOut.IndicatorXRay_2);
                    LockResolution.Value = IsEnable(EPinsOut.LockResolution);
                }
                get { return state; }
            }
        }
    }
}
