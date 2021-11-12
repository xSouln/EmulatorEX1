using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xLib;
using xLib.Transceiver;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class POA
    {
        public partial class Types
        {
            public enum EActions : ushort
            {
                GetState = 8000,
                GetFirmware,
                GetRequestById,

                SetMaxTemp = 9000,
                SetCoolPwm,

                TryPumpEnable = 10000,

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

            public unsafe struct FirmwareVersionT : IContentSeter
            {
                public fixed byte Data[10];

                public unsafe object SetContent(xContent content)
                {
                    this = *(FirmwareVersionT*)content.Obj;
                    return this;
                }
            }

            public enum EControl : byte
            {
                RadiatorFan = 1 << 0,
                WaterPump = 1 << 1,
                CoolingFan = 1 << 2,
                SafetyRing = 1 << 3,
                Beep = 1 << 4,
                RadiatorFanEn = 1 << 5,
                Free_6 = 1 << 6,
                Free_7 = 1 << 7
            }

            public enum ESensors : byte
            {
                WaterTap1 = 1 << 0,
                WaterTap2 = 1 << 1,
                StreamValve = 1 << 2,
                KeyDryer = 1 << 3,
                WaterLevel = 1 << 4,
                Free_5 = 1 << 5,
                Free_6 = 1 << 6,
                Free_7 = 1 << 7
            }

            public struct ReportT
            {
                public byte Addres;
                public EControl Control;
                public ESensors Sensors;
                public byte TempExternalCirculation;
                public byte TempInternalCirculation;
                public byte WaterFlow;
                public byte Free_6;
                public byte CoolerDutyCycleOn;
                public byte CoolerDutyCycleOff;
                public byte Crc;
            }
        }
    }
}
