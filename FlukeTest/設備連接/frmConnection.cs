
using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using FlukeTest.Models;

namespace FlukeTest
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();
            defaultBtnBackColor = btnTestConn.BackColor;
            IsOK = false;
        }

        //public object Connecter { get; set; }
        public string setting { get; set; }

        /// <summary>
        /// 乙太網
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            tabConn.SelectedTab = tabEth;
        }

        Color defaultBtnBackColor;

        /// <summary>
        /// 乙太試連接
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestConn_Click(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            bool success = false;
            string ResponseString = "";
            string errmsg = "";
            StringBuilder ipsetting = new StringBuilder();
            btnTestConn.BackColor = defaultBtnBackColor;
            Application.DoEvents();
            try
            {
                //StartClient(txtIP.Text.Trim(),
                //    int.Parse(txtPort.Text.Trim()),
                //    out success,
                //    out ResponseString,
                //    out errmsg);



                MySocketConnecter socket_test = new MySocketConnecter();
                socket_test.IP = txtIP.Text.Trim();
                socket_test.Port = int.Parse(txtPort.Text.Trim());
                var dec_name = "";
                success = socket_test.TestConnection(out dec_name, out errmsg);
                if (success)
                {
                    ipsetting.AppendLine("KIND=IP");
                    ipsetting.AppendLine($"IP={socket_test.IP}");
                    ipsetting.AppendLine($"PORT={socket_test.Port}");
                    this.setting = $"{ipsetting}";

                    if (!string.IsNullOrWhiteSpace(dec_name))
                    {
                        if (dec_name.Length > 2)
                        {
                            dec_name = dec_name.Substring(3);
                        }
                    }
                    txtDeviceName.Text = dec_name;
                    btnTestConn.BackColor = Color.LightGreen;

                    btnOK.Enabled = true;
                }
                else
                {
                    btnTestConn.BackColor = Color.Red;
                    MessageBox.Show(this, $"{errmsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                //txtError.Text = $"{ex}";
                MessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void StartClient(string IP, int Port,
             out bool ConnSuccess,
             out string ResponseString,
             out string ErrMsg
            )
        {
            ErrMsg = "";
            ResponseString = "";
            ConnSuccess = false;
            string commandStr = $"?XU{Environment.NewLine}";
            int TimeOut = 5; //秒
                             //string response_str = "";
            ErrMsg = "";
            StringBuilder errmsg = new StringBuilder();
            // Data buffer for incoming data.  
            //byte[] bytes = new byte[1024];

            // Connect to a remote device.  

            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];

                var ipaddr = IPAddress.Parse(IP);
                //errmsg.AppendLine($"ip:{ipaddr}");
                //errmsg.AppendLine($"port:{Port}");
                IPEndPoint remoteEP = new IPEndPoint(ipaddr, Port);

                // Create a TCP/IP  socket.  
                Socket socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                socket.ReceiveTimeout = TimeOut * 1000;
                //Socket sender = new Socket(ipAddress.AddressFamily,
                //    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    //errmsg.AppendLine($"connect...");
                    socket.Connect(remoteEP);


                    //byte[] bytes1 = new byte[1024];
                    //// Receive the response from the remote device.  
                    //errmsg.AppendLine($"Receive...");
                    //int bytesRec1 = socket.Receive(bytes1);
                    //errmsg.AppendLine($"Receive {bytesRec1} bytes.");



                    //Console.WriteLine("Socket connected to {0}",
                    //    sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] msg_bytes;
                    string command = $"?XU{Environment.NewLine}";
                    msg_bytes = Encoding.ASCII.GetBytes(command);


                    // Send the data through the socket.  
                    //errmsg.AppendLine($"send...{command}");
                    int bytesSent = socket.Send(msg_bytes);


                    byte[] bytes = new byte[1024];
                    // Receive the response from the remote device.  
                    //errmsg.AppendLine($"Receive...");
                    int bytesRec = socket.Receive(bytes);
                    //errmsg.AppendLine($"Receive {bytesRec} bytes.");
                    ResponseString = Encoding.ASCII.GetString(bytes);
                    //errmsg.AppendLine($"={bytesRec}");

                    //Console.WriteLine("Echoed test = {0}",
                    //    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                }
                catch (ArgumentNullException ane)
                {
                    //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    //errmsg.AppendLine($"ArgumentNullException : {ane}");
                    ErrMsg += ane.Message;
                }
                catch (SocketException se)
                {
                    //Console.WriteLine("SocketException : {0}", se.ToString());
                    //errmsg.AppendLine($"SocketException : {se}");
                    ErrMsg += se.Message;
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    //errmsg.AppendLine($"Unexpected exception : {e}");
                    ErrMsg += e.Message;
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //errmsg.AppendLine($"{e}");
                ErrMsg += e.Message;
            }
            //ErrMsg = $"{errmsg}";
        }

        /// <summary>
        /// RS232
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tabConn.SelectedTab = tabRS232;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// USB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsb_Click(object sender, EventArgs e)
        {
            try
            {
                tabConn.SelectedTab = tabUSB;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// 重新搜尋序列埠 COM Port
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            RefreshCOMPorts(lbxComs);
        }
        void RefreshCOMPorts(ListBox box)
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                box.Items.Clear();
                box.Items.AddRange(ports);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}{ex.InnerException}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabConn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = false;
            TabControl _tab = sender as TabControl;
            if (_tab == null)
            {
                return;
            }
            else if (_tab.SelectedTab == tabRS232)
            {
                RefreshCOMPorts(lbxComs);
            }
            else if (_tab.SelectedTab == tabUSB)
            {
                RefreshCOMPorts(lbxUsb);
            }

        }

        StringBuilder msg = new StringBuilder();
        private void lbxComs_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232TestConnect(sender);
        }

        SerialPort CreateSerialPort(string ComPortName)
        {
            SerialPort serial = null;
            try
            {
                serial = new SerialPort(ComPortName);

            }
            catch (Exception ex)
            {
                if (serial != null)
                    serial.Dispose();
                serial = null;
            }

            return serial;
        }

        void RS232TestConnect(object sender)
        {
            var _msg = "";
            btnOK.Enabled = false;
            StringBuilder rs232setting = new StringBuilder();
            ListBox list = sender as ListBox;
            if (list == null)
            {
                return;
            }
            try
            {

                msg.Clear();
                btnOK.Enabled = false;
                TxtRS232Msg.Clear();
                var com = $"{list.SelectedItem}";
                _msg = $"選擇了 {com}";
                msg.AppendLine(_msg);

                // setup
                using (SerialPort serialPort = new SerialPort())
                {

                    serialPort.Encoding = Encoding.ASCII;
                    //serialPort.Encoding = Encoding.GetEncoding(28591);
                    serialPort.RtsEnable = false;
                    serialPort.DtrEnable = false;
                    serialPort.ReadBufferSize = 8192;
                    serialPort.ParityReplace = 63;
                    serialPort.ReceivedBytesThreshold = 1;
                    serialPort.DiscardNull = false;
                    //serialPort.DataReceived += serialDataReceived;
                    //serialPort.DataReceived += serialDataReceivedEventHandler;
                    //serialPort.ErrorReceived += serialErrorReceived;
                    //serialPort.ErrorReceived += serialErrorReceivedEventHandler;
                    serialPort.PortName = com;
                    serialPort.DataBits = 8;
                    serialPort.NewLine = "\r\n";
                    serialPort.StopBits = System.IO.Ports.StopBits.One;
                    serialPort.Parity = System.IO.Ports.Parity.None;
                    serialPort.Handshake = Handshake.None;
                    serialPort.BaudRate = 9600;

                    // set events
                    //serialDataReceivedEventHandler = serialDataReceived;
                    //serialErrorReceivedEventHandler = serialErrorReceived;

                    if (!serialPort.IsOpen)
                    {
                        serialPort.Open();
                    }
                    serialPort.ReadTimeout = 10 * 1000;
                    serialPort.WriteTimeout = 10 * 1000;
                    if (serialPort.IsOpen)
                    {
                        // send „?T“ with EOL sequence
                        serialPort.WriteLine($"?XU");
                        //serialPort.WriteLine($"?T");
                        var rec_msg = serialPort.ReadLine();
                        if (!string.IsNullOrWhiteSpace(rec_msg))
                        {
                            if (rec_msg.Length > 2)
                            {
                                rec_msg = rec_msg.Substring(3);
                            }
                        }
                        serialPort.WriteLine($"?U");
                        var unit = serialPort.ReadLine();
                        serialPort.WriteLine($"?T");
                        var temp = serialPort.ReadLine();

                        rs232setting.AppendLine("KIND=RS232/USB");
                        rs232setting.AppendLine($"COMPORT_NAME={com}");
                        setting = $"{rs232setting}";
                        btnOK.Enabled = true;

                        _msg = $"連接成功,設備名稱:{rec_msg}, 溫度:{temp} {unit}";
                        msg.AppendLine(_msg);
                        MessageBox.Show(this, _msg, "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        serialPort.Close();
                    }

                    //備註
                    //每個物件只能有一個開啟 SerialPort 的連接。
                    //任何應用程式的最佳作法是在呼叫方法之後
                    //等候一段時間 Close ，然後再嘗試呼叫 Open 方法，
                    //因為埠可能無法立即關閉。
                }

            }
            catch (Exception ex)
            {


                _msg = $"連接失敗:{ex.Message}{ex.InnerException}";
                msg.AppendLine(_msg);
                MessageBox.Show(this, _msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                TxtRS232Msg.Text = $"{msg}";
            }
        }

        // receive event
        //private void serialDataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    string rec = serialPort.ReadExisting();
        //    Console.WriteLine(rec);
        //    msg.AppendLine($"DataReceived:{rec}");
        //}

        //// error event
        //private void serialErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        //{
        //    // here handle errors
        //    msg.AppendLine($"ErrorReceived:{e}");
        //}



        public bool IsOK { get; set; }

        // define COM port and events
        //private SerialPort serialPort;
        private string comPortName;


        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            Close();
        }


        /// <summary>
        /// cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RefreshCOMPorts(lbxUsb);
        }

        private void lbxUsb_SelectedIndexChanged(object sender, EventArgs e)
        {
            RS232TestConnect(sender);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {


        }
        //private SerialDataReceivedEventHandler serialDataReceivedEventHandler;
        //private SerialErrorReceivedEventHandler serialErrorReceivedEventHandler;





    }
}
