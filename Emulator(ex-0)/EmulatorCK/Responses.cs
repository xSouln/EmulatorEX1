using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xLib;
using xLib.Sources;
using xLib.Transceiver;
using static Emulator_ex_0_.EmulatorCK.CK.Types;

namespace Emulator_ex_0_.EmulatorCK
{
    public partial class CK
    {
        public class Responses : xResponseBuilder
        {
            public const string REQ = "#REQ::";
            public const string RES = "#RES::";
            public const string END = "\r";

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

            private static unsafe void transmite<TResponse, TAction>(xAction<bool, byte[]> transmiter, TResponse response, in TAction action) where TResponse : unmanaged where TAction : unmanaged
            {
                List<byte> data = new List<byte>();
                ResponseInfoT info = new ResponseInfoT { Action = (ushort)(object)action, Size = (ushort)sizeof(TResponse) };
                add_data(data, RES);
                add_data(data, &info, sizeof(ResponseInfoT));
                add_data(data, &response, sizeof(TResponse));
                add_data(data, END);

                transmiter?.Invoke(data.ToArray());
            }

            private static unsafe void transmite<TAction>(xAction<bool, byte[]> transmiter, byte[] response, in TAction action) where TAction : unmanaged
            {
                List<byte> data = new List<byte>();
                ResponseInfoT info = new ResponseInfoT { Action = (ushort)(object)action, Size = (ushort)response.Length };
                add_data(data, RES);
                add_data(data, &info, sizeof(ResponseInfoT));
                add_data(data, response);
                add_data(data, END);

                transmiter?.Invoke(data.ToArray());
            }

            public class Response<TResult, TAction> : xResponse<TResult, TAction> where TResult : xResponseResult, new()
            {
                public Response(List<xResponse> responses, TAction action) : base(responses, action)
                {
                    Header = REQ;
                    Name = "CK." + action;
                }
            }

            public unsafe class Get
            {
                public Get() { }

                public static Response<xResponseResult, EActions> Control = new Response<xResponseResult, EActions>(list, EActions.GetControl)
                {
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, new ControlT(), response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };

                public static Response<xResponseResult, EActions> MotorState = new Response<xResponseResult, EActions>(list, EActions.GetMotorState)
                {
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, CK.MotorState.Value, response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };

                public static Response<xResponseResult, EActions> Options = new Response<xResponseResult, EActions>(list, EActions.GetOptions)
                {
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, new OptionsT(), response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };

                public static Response<xResponseResult, EActions> Info = new Response<xResponseResult, EActions>(list, EActions.GetInfo)
                {
                    EventReceive = (response, result) =>
                    {
                        transmite(((xTcpServer.ClientStream)response.Context).Send, new InfoT(), response.Action);
                        xTracer.Message("response: " + response.Name);
                        return true;
                    }
                };
            }
        }
    }
}
