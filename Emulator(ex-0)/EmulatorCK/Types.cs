using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator_ex_0_.EmulatorCK
{
    public partial class CK
    {
        public class Types
        {
            public enum EActions : ushort
            {
                //============================
                System = 17000,

                GetById = 17200,
                GetDRVState,
                GetHandler,
                GetOptions,
                GetMotorState,
                GetInfo,
                GetControl,
                //============================
                SetHandler = 17400,
                SetOptions,
                SetPosition,
                SetRequests,
                SetMoutionSteps,
                //============================
                Try = 17600,
                TryClear,
                TryMotionStart,
                TryStop,
                TryResetSteps,
                //============================
                EvtPositionSet = 17800,
                EvtStopped,
                //============================
                Conformition = 17900
                //============================
            }

            public enum EErrors : byte
            {
                ACCEPT = 0,
                ERROR_DATA,
                ERROR_CONTENT_SIZE,
                ERROR_REQUEST,
                ERROR_RESOLUTION,
                UNKNOWN_COMMAND,
                BUSY,
                OUTSIDE,
                ERROR_ACTION,
                ERROR_POSITION
            }

            public enum EActionSetHandler : uint
            {
                Reset,
                Set
            }

            public enum EActionSetMotorState : uint
            {
                Reset,
                Set
            }

            public enum EActionSetMotionSteps : uint
            {
                Set,
                Insert,
                Remove
            }

            public enum EActionTryMoveTo : uint
            {
                Down,
                Upp
            }

            public enum EActionTryClear : uint
            {
                ClearMotion,
            }

            public enum EHandler : uint
            {
                MotorIsEnable = (1 << 0),
                MotorEnabling = (1 << 1),
                MotorDisabling = (1 << 2),

                PositionIsSet = (1 << 3),
                UpdatePeriod = (1 << 4),
                MotionVector = (1 << 5),

                RequestScanStepCount = (1 << 6),
                ScanStepCountIsEnable = (1 << 7),
                SensorUppIsFree = (1 << 8),
                SensorUppAccept = (1 << 9),
                SensorDownAccept = (1 << 10),
            }

            public enum ERequests : uint
            {
                StartMotionVector = (1 << 0)
            }

            public enum EDRVState : uint
            {
                SensorUpp = (1 << 0),
                SensorDown = (1 << 1),

                DrvEnable = (1 << 2),
                DrvDirect = (1 << 3),
                DrvDivider = ((1 << 4) | (1 << 5) | (1 << 6)),
                DrvReset = (1 << 7),
            }

            public struct MotorStateT
            {
                public EHandler Handler;
                public EDRVState DRVState;

                public float PeriodTotal;
                public float PeriodRequest;

                public int PositionTotal;
                public int PositionRequest;

                public int Difference;

                public uint MotionTotalIndex;
                public uint MotionHandlerIndex;
                public uint MotionPointsCount;

                public float ReducedHeight;

                public uint MoveTime;
                public uint StepsPassed;
                public uint Pulses;
            }

            public struct InfoT
            {
                public uint StepsCount;
                public float StepSize;

                public uint PWM_Frequency;
                public uint PWM_Prescaler;
                public float PWM_Const;

                public float Height;
                public uint MotionPointsCountMax;
            }

            public struct ControlT
            {
                public float FallingPeriod;
                public float Increment;
                public float Decrement;
                public float PeriodRequest;
                public float PeriodTotal;

                public uint RacingSteps;
                public uint FallingSteps;
            }

            public struct MotionPropertysT
            {
                public uint PointCount;
                public uint SamplingTime;
                public float TotalScanTime;

                public float MinHeight;
                public float MaxHeight;
            }

            public struct RequestSetOptionsT
            {
                public OptionsT Value;
            }

            public struct RequestSetHandlerT
            {
                public EHandler Value;
                public EActionSetHandler Action;
            }

            public unsafe struct RequestSetMotionStepsT
            {
                public uint StartIndex;
                public uint PointsCount;
                public EActionSetMotionSteps Action;
                public fixed uint Points[32];
            }

            /// <summary>
            /// StartPeriod - начальный период вращения (шаг/секунда)
            /// Increment - инкремент StartPeriod
            /// RacingK - (Increment = Increment * RacingK)
            /// StopPeriod - период остановки
            /// Amperage ток драйвера
            /// </summary>
            public struct OptionsT
            {
                public float RacingK;
                public float Increment;
                public float StartPeriod;

                public float FallingK;
                public float Decrement;
                public float StopPeriod;

                public ushort Divider;
                public ushort EnableDelay;
                public ushort DisableDelay;
                public ushort Amperage;
            }

            /// <summary>
            /// Position - запрашиваемая позиция (в шагах)
            /// Period - запрашиваемый период вращения (шаг/секунда)
            /// Action - не учитывается
            /// </summary>
            public unsafe struct RequestSetPositionT
            {
                public OptionsT Options;
                public int Position;
                public float Period;
                public uint Action;
            }

            /// <summary>
            /// StartPeriod - период начала остановки (шаг/секунда)
            /// StopPeriod - период остановки (шаг/секунда)
            /// Decrement - декремент StartPeriod
            /// </summary>
            public unsafe struct RequestTryStopT
            {
                public float FallingK;
                public float Decrement;

                public float StartPeriod;
                public float StopPeriod;

                public ushort Divider;
                public ushort DisableDelay;
            }

            public unsafe struct RequestSetRequestsT
            {
                public ERequests Value;
            }

            public unsafe struct RequestTryClearT
            {
                public EActionTryClear Value;
            }
        }
    }
}
