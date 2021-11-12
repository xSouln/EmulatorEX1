﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xLib;
using xLib.Sources;
using xLib.Transceiver;
using static Emulator_ex_0_.EmulatorDivX.ES.Types;

namespace Emulator_ex_0_.EmulatorDivX
{
    public partial class ES
    {
        public unsafe class Responses : xResponseBuilder
        {
            public const string END = "\r";

            private static unsafe void transmite<TResponse, TAction>(xAction<bool, byte[]> transmiter, string header, TResponse response, in TAction action) where TResponse : unmanaged where TAction : unmanaged
            {
                List<byte> data = new List<byte>();
                ResponseInfoT info = new ResponseInfoT { Action = (ushort)(object)action, Size = (ushort)sizeof(TResponse) };
                add_data(data, header);
                add_data(data, &info, sizeof(ResponseInfoT));
                add_data(data, &response, sizeof(TResponse));
                add_data(data, END);

                transmiter?.Invoke(data.ToArray());
            }

            private static unsafe void transmite<TAction>(xAction<bool, byte[]> transmiter, string header, byte[] response, in TAction action) where TAction : unmanaged
            {
                List<byte> data = new List<byte>();
                ResponseInfoT info = new ResponseInfoT { Action = (ushort)(object)action, Size = (ushort)response.Length };
                add_data(data, header);
                add_data(data, &info, sizeof(ResponseInfoT));
                add_data(data, response);
                add_data(data, END);

                transmiter?.Invoke(data.ToArray());
            }

            public unsafe class Get
            {
                public const string REQ = "#GET::";
                public const string RES = "#RES::";

                public static List<xResponse> list = new List<xResponse>() { };

                public static unsafe bool Identification(object context, ResponseT response, xContent content)
                {
                    if (xConverter.Compare(REQ, &response.Prefix, sizeof(ResponsePrefixT)))
                    {
                        foreach (xResponse alement in list)
                        {
                            if (alement is IResponseAction<EActions> info && info.Action == (EActions)response.Info.Action)
                            {
                                alement.Receive(context, content);
                                return true;
                            }
                        }
                    }
                    return false;
                }

                public Get() { }

                public static xResponse<xResponseResult, EActions> StateSensor1 = new xResponse<xResponseResult, EActions>(list, EActions.GetStateSensor1)
                {
                    Header = REQ,
                    Name = "ES." + nameof(EActions.GetStateSensor1),
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, RES, new ReportT(), response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };

                public static xResponse<xResponseResult, EActions> StateSensor2 = new xResponse<xResponseResult, EActions>(list, EActions.GetStateSensor2)
                {
                    Header = REQ,
                    Name = "ES." + nameof(EActions.GetStateSensor2),
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, RES, new ReportT(), response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };

                public static xResponse<xResponseResult, EActions> StateSensor3 = new xResponse<xResponseResult, EActions>(list, EActions.GetStateSensor3)
                {
                    Header = REQ,
                    Name = "ES." + nameof(EActions.GetStateSensor3),
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, RES, new ReportT(), response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };
            }
        }
    }
}
