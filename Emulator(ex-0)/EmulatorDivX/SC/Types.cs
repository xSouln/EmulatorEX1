using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class SC
    {
        public partial class Types
        {
            public enum EActions : ushort
            {
                GetState = 12000,
                GetStateL,
                GetFirmware,
                GetRequestById,

                SetOptionsMotor1 = 13000,
                SetOptionsMotor2,
                SetOptionsMotor3,
                SetTotalSample,
                SetSample,
                SetMode,

                TryReturn = 14000,
                TryRotationStop,
                TryRotationStart,
                TrySelectSample,
                TryReadOptions,

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

            public enum EState_1 : byte
            {
                frstRXD = (1 << 0),
                UPD = (1 << 1),
                Dir_fwrd = (1 << 2),
                Dir_bckwrd = (1 << 3),
                DC_fwrd = (1 << 4),
                DC_bckwrd = (1 << 5),
                packetINrc = (1 << 6),
                Adr_rc = (1 << 7),
            }

            public enum EState_2 : byte
            {
                frstRXD = (1 << 0),
                UPD = (1 << 1),
                Dir_fwrd = (1 << 2),
                Dir_bckwrd = (1 << 3),
                DC_fwrd = (1 << 4),
                DC_bckwrd = (1 << 5),
                packetINrc = (1 << 6),
                Adr_rc = (1 << 7),
            }

            public enum EHandler : byte
            {
                SetAmperageError = (1 << 0),
                RotationStopped = (1 << 1),
                Return = (1 << 2),
                SampleIsSet = (1 << 3),
                SampleRotate = (1 << 4),
                SetSample = (1 << 5),
                SetLiftUp = (1 << 6),
                SetLiftDown = (1 << 7)
            }

            public enum ESensors : byte
            {
                Sensor_1 = (1 << 0),
                Sensor_2 = (1 << 1),
                Sensor_3 = (1 << 2),
                Sensor_4 = (1 << 3),
                Sensor_5 = (1 << 4),
                Sensor_6 = (1 << 5),
                Sensor_7 = (1 << 6),
                Sensor_8 = (1 << 7)
            }

            public enum EMode : uint
            {
                StatusL = (1 << 0)
            }

            public enum EModeAction : uint
            {
                Disable,
                Enable
            }

            public enum ESampleSensors : byte
            {
                Sample_1 = (1 << 0) ^ 0xff,
                Sample_2 = (1 << 1) ^ 0xff,
                Sample_3 = (1 << 2) ^ 0xff,
                Sample_4 = (1 << 3) ^ 0xff,
                Sample_5 = (1 << 4) ^ 0xff,
                Sample_6 = (1 << 5) ^ 0xff,
                Sample_7 = (1 << 6) ^ 0xff,
                Sample_8 = (1 << 7) ^ 0xff,
            }


            public struct ReportT
            {
                public byte address;
                public byte command;
                public ESensors sensors_state;
                public byte divider;
                public EHandler handler;
                public EState_2 state_2;
                public byte errors;
                public byte error_drv;
                public ESampleSensors sample_position;
                public byte Crc;
            }

            public struct ReportLT
            {
                public byte address;
                public byte command;
                public byte free_2;
                public EState_1 state_1;
                public byte period_l;
                public byte period_h;
                public byte errors;
                public EState_2 state_2;
                public EHandler handler;
                public byte Crc;
            }

            public struct RotationOptionsT
            {
                public byte Divider;
                public byte Direction;
                public ushort Speed;
                public float ReducedSpeed;
            }

            public struct EepromOptionsT
            {
                public byte Divider;
                public byte SpeedL;
                public byte SpeedH;
            }

            public struct LiftOptionsT
            {
                public byte Divider;
                public byte Rotation;
                public ushort Speed;
                public float ReducedSpeed;
            }

            public struct OptionsT
            {
                public RotationOptionsT Rotation;
                public RotationOptionsT SaveRotation;
                public LiftOptionsT Lift;
                public EMode Mode;
            }

            public struct StatusT
            {
                public ushort State;
                public ushort Request;
            }

            public struct RequestSetModeT
            {
                public EMode Mode;
                public EModeAction Action;
            }
        }
    }
}
