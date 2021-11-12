using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xLib;
using xLib.Sources;
using xLib.Transceiver;
using xLib.xWindows;
using Emulator_ex_0_.EmulatorDivX;
using xLib.UI_Propertys;
using Emulator_ex_0_.EmulatorCK;

namespace Emulator_ex_0_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private xTcpServer tcp_server;
        public MainWindow()
        {
            xSupport.Context = this;

            InitializeComponent();

            //MenuTerminal.Click += WindowTerminal.OpenClick;
            //MenuTcp.Click += WindowTcpServer.OpenClick;

            tcp_server = new xTcpServer() { EventReceivePacket = EventReceivePacket };

            WindowTcpServer.TcpServer = tcp_server;
            WindowTcpServer.Propertys = new System.Collections.ObjectModel.ObservableCollection<object>
            {
                tcp_server.Propertys.Ip,
                tcp_server.Propertys.Port,
                tcp_server.Propertys.QueueSize,
                tcp_server.Propertys.Connections
            };

            ListViewPtopertys.ItemsSource = WindowTcpServer.Propertys;
            ListViewLog.ItemsSource = xTracer.Notes;

            ButConnection.DataContext = tcp_server.Propertys.ButConnection;

            new CU.Responses.Get();
            new CSB.Responses.Get();
            new POA.Responses.Get();
            new ES.Responses.Get();
            new SC.Responses.Get();
            new CK.Responses.Get();

            ListViewPropertysDivX.ItemsSource = DivX.Collections.Propertys;
            ListViewPropertysCK.ItemsSource = CK.Collections.Propertys;

            Closed += MainWindowClosed;
        }

        private void MainWindowClosed(object sender, EventArgs e)
        {
            tcp_server.Stop();

            WindowTerminal.Dispose();
            WindowTcpServer.Dispose();
        }

        public static void EventReceivePacket(xReceiverData ReceiverData)
        {
            string convert = "";
            string temp = "";
            ResponseT response;
            unsafe { response = *(ResponseT*)ReceiverData.Content.Obj; }
            int obj_size;

            if (response.Prefix.Start == xResponse.START_CHARECTER)
            {
                xContent content;
                unsafe
                {
                    if (ReceiverData.Content.Size < sizeof(ResponseT)) { ReceiverData.xRx.Response = xRxResponse.Storage; return; }
                    obj_size = ReceiverData.Content.Size - sizeof(ResponseT);

                    if (obj_size < response.Info.Size) { ReceiverData.xRx.Response = xRxResponse.Storage; return; }
                    if (obj_size > response.Info.Size) { xTracer.Message("error content size"); goto error; }

                    content = ReceiverData.Content;
                    content.Obj += sizeof(ResponseT);
                    content.Size -= sizeof(ResponseT);
                }

                if (CU.Responses.Get.Identification(ReceiverData.xRx.Context, response, content)) { goto end; };
                if (CSB.Responses.Get.Identification(ReceiverData.xRx.Context, response, content)) { goto end; };
                if (POA.Responses.Get.Identification(ReceiverData.xRx.Context, response, content)) { goto end; };
                if (ES.Responses.Get.Identification(ReceiverData.xRx.Context, response, content)) { goto end; };
                if (SC.Responses.Get.Identification(ReceiverData.xRx.Context, response, content)) { goto end; };

                //if (CK.Responses.Identification(ReceiverData.xRx.Context, response, content)) { goto end; };

                xTracer.Message("receive: " + xConverter.GetString(ReceiverData.Content));
                goto end;
            }
        error:
            unsafe
            {
                convert = xConverter.GetString(ReceiverData.Content.Obj, ReceiverData.Content.Size);
                try { temp = xConverter.GetString(ReceiverData.Content.Obj, ReceiverData.Content.Size); }
                catch { temp = "Encoding error"; }
                xTracer.Message("Trace: " + temp + " {" + convert + "}");
            }

        end: ReceiverData.xRx.Response = xRxResponse.Accept;
        }

        private void ButConnection_Click(object sender, RoutedEventArgs e)
        {
            if (tcp_server != null)
            {
                if (tcp_server.IsStarted) { tcp_server.Stop(); }
                else { tcp_server.Start(); }
            }
        }

        private void ListViewPropertysDivX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewPropertysDivX.SelectedValue != null && ListViewPropertysDivX.SelectedValue is UI_Property property) { property.Select(); }
            ListViewPropertysDivX.SelectedValue = null;
        }
    }
}
