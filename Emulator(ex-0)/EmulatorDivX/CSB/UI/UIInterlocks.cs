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
        public class UIInterlocks
        {
            private EInterlocks state;

            public UI_Property<bool, EInterlocks> Stop = new UI_Property<bool, EInterlocks> { Name = "STOP", Request = EInterlocks.Stop, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EInterlocks> Casing = new UI_Property<bool, EInterlocks> { Name = "Кожух ИРИ", Request = EInterlocks.Casing, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EInterlocks> BackCover = new UI_Property<bool, EInterlocks> { Name = "Задняя крышка", Request = EInterlocks.BackCover, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EInterlocks> SideCover1 = new UI_Property<bool, EInterlocks> { Name = "Боковая крышка 1", Request = EInterlocks.SideCover1, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EInterlocks> SideCover2 = new UI_Property<bool, EInterlocks> { Name = "Боковая крышка 2", Request = EInterlocks.SideCover2, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EInterlocks> Door1 = new UI_Property<bool, EInterlocks> { Name = "Дверь сенсор 1", Request = EInterlocks.Door1, BackgroundValueRule = Rule1 };
            public UI_Property<bool, EInterlocks> Door2 = new UI_Property<bool, EInterlocks> { Name = "Дверь сенсор 2", Request = EInterlocks.Door2, BackgroundValueRule = Rule1 };

            private static Brush Rule1(UI_Property<bool, EInterlocks> property)
            {
                return property.Value ? UI_Property.RED : UI_Property.GREEN;
            }

            public UIInterlocks()
            {
                Stop.EventSelection += EventClick;
                Casing.EventSelection += EventClick;
                BackCover.EventSelection += EventClick;
                SideCover1.EventSelection += EventClick;
                SideCover2.EventSelection += EventClick;
                Door1.EventSelection += EventClick;
                Door2.EventSelection += EventClick;
            }

            private void EventClick(UI_Property<bool, EInterlocks> arg)
            {
                arg.Value ^= true;
                if (arg.Value) { state |= arg.Request; }
                else { state &= ~arg.Request; }
            }

            public static bool IsEnable(EInterlocks state, EInterlocks request) { return (request & state) == request; }

            public EInterlocks Value
            {
                get { return state; }
                set
                {
                    state = value;
                    Stop.Value = IsEnable(value, EInterlocks.Stop);
                    Casing.Value = IsEnable(value, EInterlocks.Casing);
                    BackCover.Value = IsEnable(value, EInterlocks.BackCover);
                    SideCover1.Value = IsEnable(value, EInterlocks.SideCover1);
                    SideCover2.Value = IsEnable(value, EInterlocks.SideCover2);
                    Door1.Value = IsEnable(value, EInterlocks.Door1);
                    Door2.Value = IsEnable(value, EInterlocks.Door2);
                }
            }
        }
    }
}
