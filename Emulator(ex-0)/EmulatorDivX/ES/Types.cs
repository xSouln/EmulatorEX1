using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class ES
    {
        public partial class Types
        {
            public enum EActions : ushort
            {
                GetStateSensor1 = 16000,
                GetStateSensor2,
                GetStateSensor3,
                GetRequestById
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

            public struct ValueT
            {
                public byte HighRegister;
                public byte LowRegister;
            }

            public struct ReportT
            {
                public byte Address;
                public byte Info;
                public byte Free_2;
                public byte Free_3;
                public ValueT Temperature;
                public ValueT Humidity;
                public byte Free_8;
                public byte Crc;
            }
        }
    }
}
