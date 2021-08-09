using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlukeTest.Models
{
    class MySocketConnecter : IDisposable
    {
        public MySocketConnecter()
        {
            ReceiveTimeout = 120 * 1000;
            IP = "192.168.42.132";
            Port = 6363;
        }
        public MySocketConnecter(string ip, int port)
        {
            ReceiveTimeout = 120 * 1000;
            this.IP = ip;
            this.Port = port;
        }
        public string IP { get; set; }
        public int Port { get; set; }

        /// <summary>
        ///         
        // 摘要:
        //     取得或設定值，指定的這段時間之後同步 Overload:System.Net.Sockets.Socket.Receive 會逾時呼叫。
        //
        // 傳回:
        //     逾時值 (以毫秒為單位)。 預設值是 0，表示無限逾時期間。 指定-1 也表示無限逾時期間。
        //
        // 例外狀況:
        //   T:System.Net.Sockets.SocketException:
        //     嘗試存取通訊端時發生錯誤。
        //
        //   T:System.ObjectDisposedException:
        //     System.Net.Sockets.Socket 已關閉。
        //
        //   T:System.ArgumentOutOfRangeException:
        //     設定作業指定的值是小於-1。
        /// </summary>
        public int ReceiveTimeout { get; set; }

        public Socket socket { get; set; }



        public void Open()
        {
            if (socket == null)
            {
                socket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);
            }
            var ipaddr = IPAddress.Parse(IP);
            IPEndPoint remoteEP = new IPEndPoint(ipaddr, Port);

            socket.Connect(remoteEP);
        }

        public void Close()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();

        }

        public void Dispose()
        {
            try
            {
                if (socket == null)
                    return;
                if (socket.Connected)
                    this.Close();
                socket.Dispose();
                socket = null;

            }
            catch (Exception ex)
            {

            }
        }

        public string Send(string Command)
        {
            byte[] msg_bytes;
            //string command = $"?XU{Environment.NewLine}";
            string command = $"{Command}{Environment.NewLine}";
            msg_bytes = Encoding.ASCII.GetBytes(command);


            // Send the data through the socket.  
            //errmsg.AppendLine($"send...{command}");
            int bytesSent = socket.Send(msg_bytes);
            //return bytesSent;

            byte[] bytes = new byte[1024];
            // Receive the response from the remote device.  
            //errmsg.AppendLine($"Receive...");
            int bytesRec = socket.Receive(bytes);
            //errmsg.AppendLine($"Receive {bytesRec} bytes.");
            string ResponseString = Encoding.ASCII.GetString(bytes);
            return ResponseString;

        }

        /// <summary>
        /// 僅測試連線，測完釋放。 若要使用 SocketConnecter 要自行 Open/Close
        /// </summary>
        /// <param name="DeviceName"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public bool TestConnection(out string DeviceName,
            out string Temp, out string Unit,
            out string ErrMsg
            )
        {
            DeviceName = "";
            ErrMsg = "";
            Temp = "";
            Unit = "";
            bool rst = false;
            try
            {
                rst = SendCommand(IP, Port, "?XU", 10,
                      out DeviceName, out ErrMsg);
                if (rst)
                {
                    if (DeviceName.Length > 3)
                    {
                        if (DeviceName.Substring(0, 3) == "!XU")
                        {
                            DeviceName = DeviceName.Substring(3);
                        }
                    }
                }

                var temp = "";
                rst = SendCommand(IP, Port, "?T", 10,
                      out temp, out ErrMsg);
                if (rst)
                {
                    if (temp.Substring(0, 2) == "!T")
                    {
                        temp = temp.Substring(2);
                    }
                }
                Temp = temp;

                var unit = "";
                rst = SendCommand(IP, Port, "?U", 10,
                      out unit, out ErrMsg);
                if (rst)
                {
                    if (unit.Substring(0, 2) == "!U")
                    {
                        unit = temp.Substring(2);
                    }
                }
                Unit = unit;


            }
            catch (Exception ex)
            {
                ErrMsg = $"{ex.Message}{ex.InnerException}";
            }

            return rst;
        }

        /// <summary>
        /// For TestConnection
        /// </summary>
        /// <param name="IP">IP</param>
        /// <param name="Port">Port</param>
        /// <param name="Command">命令</param>
        /// <param name="TimeOut">逾時(秒)</param>
        /// <param name="response_str">回應</param>
        /// <param name="ErrMsg">錯誤訊息</param>
        bool SendCommand(string IP, int Port,
            string Command, int TimeOut,
            out string response_str, out string ErrMsg)
        {
            bool success = false;
            response_str = "";
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
                using (Socket socket = new Socket(AddressFamily.InterNetwork,
                     SocketType.Stream, ProtocolType.Tcp))
                {

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
                        string command = $"{Command}{Environment.NewLine}";
                        msg_bytes = Encoding.ASCII.GetBytes(command);


                        // Send the data through the socket.  
                        //errmsg.AppendLine($"send...{command}");
                        int bytesSent = socket.Send(msg_bytes);


                        byte[] bytes = new byte[1024];
                        // Receive the response from the remote device.  
                        //errmsg.AppendLine($"Receive...");
                        int bytesRec = socket.Receive(bytes);
                        //errmsg.AppendLine($"Receive {bytesRec} bytes.");
                        var rtn = Encoding.ASCII.GetString(bytes);
                        //errmsg.AppendLine($"={bytesRec}");

                        //Console.WriteLine("Echoed test = {0}",
                        //    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                        // Release the socket.  
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                        response_str = rtn;
                        success = true;
                    }
                    catch (ArgumentNullException ane)
                    {
                        //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                        errmsg.AppendLine($"ArgumentNullException : {ane.Message}{ane.InnerException}");
                    }
                    catch (SocketException se)
                    {
                        //Console.WriteLine("SocketException : {0}", se.ToString());
                        errmsg.AppendLine($"SocketException : {se.Message}{se.InnerException}");
                    }
                    catch (Exception e)
                    {
                        //Console.WriteLine("Unexpected exception : {0}", e.ToString());
                        errmsg.AppendLine($"Unexpected exception : {e.Message}{e.InnerException}");
                    }

                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                errmsg.AppendLine($"操作失敗:{e}");
            }
            ErrMsg = $"{errmsg}";
            return success;
        }

    }
}
