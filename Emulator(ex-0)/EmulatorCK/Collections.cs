using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xLib.UI_Propertys;

namespace Emulator_ex_0_.EmulatorCK
{
    public partial class CK
    {
        public class Collections
        {
            public static ObservableCollection<UI_Property> Propertys { get; set; } = new ObservableCollection<UI_Property>
            {
                CK.MotorState.PeriodTotal,
                CK.MotorState.PositionTotal,
                CK.MotorState.PeriodRequest,
                CK.MotorState.PositionRequest,
                CK.MotorState.MotionTotalIndex,
                CK.MotorState.MotionPointsCount,
                CK.MotorState.Difference,
                CK.MotorState.ReducedHeight,
                CK.MotorState.MoveTime,
                CK.MotorState.StepsPassed,
                CK.MotorState.Pulses,
            };

            static Collections()
            {
                foreach (UI_Property property in Propertys) { property.Update(); }
            }
        }
    }
}
