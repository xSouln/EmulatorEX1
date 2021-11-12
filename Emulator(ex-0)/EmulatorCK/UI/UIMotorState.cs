using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xLib.UI_Propertys;
using static Emulator_ex_0_.EmulatorCK.CK.Types;

namespace Emulator_ex_0_.EmulatorCK.UI
{
    public class UIMotorState
    {
        private MotorStateT state = new MotorStateT();

        public UI_Property<float, object> PeriodTotal = new UI_Property<float, object> { Name = nameof(PeriodTotal) };
        public UI_Property<float> PeriodRequest = new UI_Property<float> { Name = nameof(PeriodRequest), IsWritable = true };

        public UI_Property<int, object> PositionTotal = new UI_Property<int, object> { Name = nameof(PositionTotal) };
        public UI_Property<int> PositionRequest = new UI_Property<int> { Name = nameof(PositionRequest), IsWritable = true };

        public UI_Property<int, object> Difference = new UI_Property<int, object> { Name = nameof(Difference) };

        public UI_Property<uint> MotionTotalIndex = new UI_Property<uint> { Name = nameof(MotionTotalIndex), IsWritable = true };
        public UI_Property<uint, object> MotionHandlerIndex = new UI_Property<uint, object> { Name = nameof(MotionHandlerIndex) };
        public UI_Property<uint, object> MotionPointsCount = new UI_Property<uint, object> { Name = nameof(MotionPointsCount) };

        public UI_Property<double, object> ReducedHeight = new UI_Property<double, object> { Name = nameof(ReducedHeight) };
        public UI_Property<double, object> MoveTime = new UI_Property<double, object> { Name = nameof(MoveTime) };

        public UI_Property<uint, object> StepsPassed = new UI_Property<uint, object> { Name = nameof(StepsPassed) };
        public UI_Property<uint, object> Pulses = new UI_Property<uint, object> { Name = nameof(Pulses) };
        public UI_Property<double> ReducedStepsPassed = new UI_Property<double> { Name = nameof(ReducedStepsPassed) };

        public UIMotorState()
        {

        }

        public MotorStateT Value
        {
            set
            {
                PositionTotal.Value = value.PositionTotal;
                PeriodTotal.Value = value.PeriodTotal;

                PositionRequest.Value = value.PositionRequest;
                PeriodRequest.Value = value.PeriodRequest;

                Difference.Value = value.Difference;

                MotionTotalIndex.Value = value.MotionTotalIndex;
                MotionHandlerIndex.Value = value.MotionHandlerIndex;
                MotionPointsCount.Value = value.MotionPointsCount;

                ReducedHeight.Value = Math.Round((double)value.ReducedHeight / 1000, 3);
                MoveTime.Value = Math.Round((double)value.MoveTime / 1000, 1);

                StepsPassed.Value = value.StepsPassed;
                Pulses.Value = value.Pulses;
            }
            get => new MotorStateT()
            {
                PeriodTotal = PeriodTotal.Value,
                PeriodRequest = PeriodRequest.Value,

                PositionTotal = PositionTotal.Value,
                PositionRequest = PositionRequest.Value,

                Difference = Difference.Value,

                MotionTotalIndex = MotionTotalIndex.Value,
                MotionHandlerIndex = MotionHandlerIndex.Value,
                MotionPointsCount = MotionPointsCount.Value,

                ReducedHeight = (float)(ReducedHeight.Value * 1000),
                MoveTime = (uint)(MoveTime.Value * 1000),

                StepsPassed = StepsPassed.Value,
                Pulses = Pulses.Value
            };
        }
    }
}
