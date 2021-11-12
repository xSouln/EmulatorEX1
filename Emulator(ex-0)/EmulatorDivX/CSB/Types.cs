using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class CSB
    {
        public partial class Types
        {
            public enum EActions : ushort
            {
                GetState = 4000,
                GetUpdate,
                GetFirmware,
                GetRequestById,

                SetCurtain = 5000,
                SetSecuretyLoop,
                SetIndicatorXRay1,
                SetIndicatorXRay2,
                SetResolution,
                SetTriggerIgnore,
                SetHandler,
                SetTriggerMask,
                SetPortsMasks,

                TryTriggerReset = 6000,
                TrySelfTest,

                Confirmation = 7000
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
                ERROR_POSITION,
                COUNT
            }

            public enum EState : byte { Disable, Enable }
            public enum EActionSetValue : byte { Disable, Enable }
            public enum ETriggerState : ushort { Disable, Enable }
            public enum ESensorsG : byte
            {
                Free_0 = 1 << 0,
                Free_1 = 1 << 1,
                Free_2 = 1 << 2,
                Reserved = 1 << 3,
                CurtainOpen = 1 << 4,
                Free_5 = 1 << 5,
                Free_6 = 1 << 6,
                Free_7 = 1 << 7
            }
            public enum ESensorsA : byte
            {
                SecurityLoop = 1 << 0,
                CurtainClose = 1 << 1,
                CurtainIndicator = 1 << 2,
                XRay_2 = 1 << 3,
                XRay_1 = 1 << 4,
                XRayGenerator = 1 << 5,
                WatchdogGenerator = 1 << 6,
                XRayResolutionKey = 1 << 7
            }
            public enum EInterlocks : byte
            {
                Stop = 1 << 0,
                //Free_1 = 1 << 1,
                Casing = 1 << 2,
                BackCover = 1 << 3,
                SideCover2 = 1 << 4,
                SideCover1 = 1 << 5,
                Door2 = 1 << 6,
                Door1 = 1 << 7
            }
            public enum EPinsOut : byte
            {
                Free_0 = 1 << 0,
                IndicatorCurtain = 1 << 1,
                LockResolution = 1 << 2,
                Curtain = 1 << 3,
                SecurityLoop = 1 << 4,
                TurnSamplePosSystem = 1 << 5,
                IndicatorXRay_2 = 1 << 6,
                IndicatorXRay_1 = 1 << 7
            }
            public enum ESelfTestErrors : byte
            {
                CurtainClose = 1 << 0,
                CurtainOpen = 1 << 1,
                IndicatorCurtainOff = 1 << 2,
                IndicatorCurtainOn = 1 << 3,
                IndicatorXRay_1_Off = 1 << 4,
                IndicatorXRay_1_On = 1 << 5,
                IndicatorXRay_2_Off = 1 << 6,
                IndicatorXRay_2_On = 1 << 7
            }
            public enum EResolutions : byte
            {
                ToggleIndicatorCurtain = 1 << 0,
                XRayResolution = 1 << 1,
                IgnoreResolutionKey = 1 << 2,
                Lock = 1 << 3,
                ServiceMode = 1 << 4
            }
            public enum ETriggers : ushort
            {
                SelfTest = 1 << 0,
                Interlocks = 1 << 1,
                CurtainOpen = 1 << 2,
                CurtainClose = 1 << 3,
                IndicatorCurtain = 1 << 4,
                IndicatorXRay_1 = 1 << 5,
                IndicatorXRay_2 = 1 << 6,
                SecurityLoop = 1 << 7,
                WatchdogGenerator = 1 << 8
            }
            public enum EHandler : byte
            {
                EnablingSafetyRing = 1 << 0,
                Warning = 1 << 1,
                SelfTest = 1 << 2,
                SelfTestComplite = 1 << 3,
                CurtainDisabling = 1 << 4
            }
            public enum eErrorsResponse : ushort
            {
                ACCEPT = 0,
                ERROR_DATA,
                ERROR_CONTENT_SIZE,
                ERROR_REQUEST,
                ERROR_RESOLUTION,
                UNKNOWN_COMMAND
            }
            public struct PortsMaskT
            {
                public EInterlocks Interlock;
                public EPinsOut Control;
                public ESensorsA SensorsA;
                public ESensorsG SensorsG;
            }
            public struct RequestSetPortsMaskT
            {
                public PortsMaskT State;
                public EActionSetValue Action;
            }
            public struct RequestSetResolutionT
            {
                public EResolutions State;
                public EActionSetValue Action;
            }
            public struct ErrorResponseT
            {
                public EActions Action;
                public eErrorsResponse Error;
            }
            public struct RequestSetTriggerT
            {
                public ETriggers State;
                public ETriggerState Action;
            }
            public struct RequestSetCurtainT
            {
                public EState State;
                public EActionSetValue Action;
                public ushort Time;
            }
            public struct RequestSetHandlerT
            {
                public EHandler State;
                public EActionSetValue Action;
            }
            public struct StateT
            {
                public EHandler Handler;
                public EInterlocks Interlocks;
                public ESensorsA SensorsA;
                public ESensorsG SensorG;
                public EPinsOut Control;

                public ESelfTestErrors SelfTestErrors;
                public EResolutions Resolution;
                public EInterlocks InterlockIgnore;

                public PortsMaskT PortsMask;

                public ETriggers Trigger;
                public ETriggers TriggerTotal;
                public ETriggers TriggerIgnore;
                public ETriggers TriggerMask;
            }
        }
    }
}
