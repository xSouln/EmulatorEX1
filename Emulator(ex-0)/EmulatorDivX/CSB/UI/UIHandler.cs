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
        public class UIHandler
        {
            private EHandler state;

            public UI_Property<bool, EHandler> EnablingSafetyRing = new UI_Property<bool, EHandler> { Name = nameof(EnablingSafetyRing), Request = EHandler.EnablingSafetyRing, BackgroundValueRule = Rule2 };
            public UI_Property<bool, EHandler> Warning = new UI_Property<bool, EHandler> { Name = nameof(Warning), Request = EHandler.Warning, BackgroundValueRule = Rule2 };
            public UI_Property<bool, EHandler> SelfTestEnable = new UI_Property<bool, EHandler> { Name = nameof(SelfTestEnable), Request = EHandler.SelfTest, BackgroundValueRule = Rule2 };
            public UI_Property<bool, EHandler> SelfTestComplite = new UI_Property<bool, EHandler> { Name = nameof(SelfTestComplite), Request = EHandler.SelfTestComplite, BackgroundValueRule = Rule1 };

            private static Brush Rule1(UI_Property<bool, EHandler> property)
            {
                return property.Value ? UI_Property.GREEN : UI_Property.RED;
            }

            private static Brush Rule2(UI_Property<bool, EHandler> property)
            {
                return property.Value ? UI_Property.RED : UI_Property.GREEN;
            }

            public UIHandler()
            {
                EnablingSafetyRing.EventSelection += EventClick;
                Warning.EventSelection += EventClick;
                SelfTestEnable.EventSelection += EventClick;
                SelfTestComplite.EventSelection += EventClick;
            }

            private void EventClick(UI_Property<bool, EHandler> arg)
            {
                arg.Value ^= true;
                if (arg.Value) { state |= arg.Request; }
                else { state &= ~arg.Request; }
            }

            public static bool IsEnable(EHandler state, EHandler request) { return (request & state) == request; }

            public EHandler Value
            {
                get { return state; }
                set
                {
                    state = value;
                    EnablingSafetyRing.Value = IsEnable(value, EHandler.EnablingSafetyRing);
                    Warning.Value = IsEnable(value, EHandler.Warning);
                    SelfTestEnable.Value = IsEnable(value, EHandler.SelfTest);
                    SelfTestComplite.Value = IsEnable(value, EHandler.SelfTestComplite);
                }
            }
        }
    }
}
