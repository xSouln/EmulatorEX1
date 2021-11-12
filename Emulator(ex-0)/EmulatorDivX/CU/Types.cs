using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class CU
    {
        public class Types
        {
            public enum EActions : ushort
            {
                Error,

                GetState = 100,
                GetFirmware,
                GetById,

                SetTriggerIgnore = 1000,
                SetResolutions,
                SetHandler,
                SetSafetyRing,
                SetTriggerMask,
                SetOptions,

                TryTriggerReset = 2000,

                EvtPowerDisabling = 2500,

                Confirmation = 3000,
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

            public enum EErrorUpdate : byte
            {
                ES1 = (1 << 0),
                ES2 = (1 << 1),
                ES3 = (1 << 2),
                CSB = (1 << 3),
                POA = (1 << 4),
                CK = (1 << 5),
                SCS = (1 << 6),
                SC = (1 << 7)
            }

            public enum ESensors : byte
            {
                Power_24V_CSB = (1 << 0),
                Power_48V = (1 << 1),
                Power_24V = (1 << 2),
                Power_12V = (1 << 3),
                IndicatorOn = (1 << 4)
            }

            public enum EPeripheryState : ushort
            {
                Relay_1 = (1 << 0),
                Relay_2 = (1 << 1),
                RelaySafetyRing = (1 << 2),
                IndicatorOn = (1 << 3),
                IndicatorStandby = (1 << 4),
                IndicatorLock = (1 << 5),
                IndicatorAdd = (1 << 6),

                PowerInable = (1 << 7),
                IndicatorOnIsBlink = (1 << 8)
            }

            public enum ETriggers : ushort
            {
                UpdateError = (1 << 0),
                PowerError = (1 << 1),
                Block_POA = (1 << 2),
                Block_CSB = (1 << 3),
                Watchdog = (1 << 4),

                Power_24V_CSB = (1 << 5),
                Power_48V = (1 << 6),
                Power_24V = (1 << 7),
                Power_12V = (1 << 8),
                IndicatorOn = (1 << 9)
            }

            public enum EHandler : ushort
            {
                PowerEnabling = (1 << 0),
                PowerDisabling = (1 << 1),
                PowerReset = (1 << 2),
                CSB_Started = (1 << 3),
                CSB_Bootloader = (1 << 4),

                CommunicationControl = (1 << 5),
                BootStarted = (1 << 6)
            }

            public enum EResolutions : ushort
            {
                CommunicationControl = 1 << 0
            }

            public enum EActionSetValue : ushort
            {
                Disable,
                Enable
            }

            public struct OptionsT
            {
                public ushort WatchdogTimeout;
            }

            public struct RequestSetResolutionsT
            {
                public EResolutions State;
                public EActionSetValue Action;
            }

            public struct RequestSetTriggerT
            {
                public ETriggers State;
                public EActionSetValue Action;
            }

            public struct RequestSetHandlerT
            {
                public EHandler State;
                public EActionSetValue Action;
            }

            public struct StateT
            {
                public EErrorUpdate ErrorUpdate;
                public ESensors Sensors;

                public EResolutions Resolutions;
                public EPeripheryState Periphery;

                public ETriggers Trigger;
                public ETriggers TriggerTotal;
                public ETriggers TriggerIgnore;
                public ETriggers TriggerMask;

                public EHandler Handler;
            }
        }
    }
}
