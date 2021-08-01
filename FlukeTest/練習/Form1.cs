using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlukeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string response_str = "";
                string errmsg = "";
                StartClient(txtIP.Text.Trim(),
                    int.Parse(txtPort.Text.Trim()),
                    int.Parse(txtTimeout.Text.Trim()),
                    out response_str,
                    out errmsg);
                txtReponse.Text = response_str;
                txtError.Text = errmsg;
            }
            catch (Exception ex)
            {
                txtError.Text = $"{ex}";
            }
        }

        void StartClient(string IP, int Port, int TimeOut,
            out string response_str, out string ErrMsg)
        {
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
                errmsg.AppendLine($"ip:{ipaddr}");
                errmsg.AppendLine($"port:{Port}");
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
                    errmsg.AppendLine($"connect...");
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
                    string command = $"{txtCommand.Text}{Environment.NewLine}";
                    msg_bytes = Encoding.ASCII.GetBytes(command);


                    // Send the data through the socket.  
                    errmsg.AppendLine($"send...{command}");
                    int bytesSent = socket.Send(msg_bytes);


                    byte[] bytes = new byte[1024];
                    // Receive the response from the remote device.  
                    errmsg.AppendLine($"Receive...");
                    int bytesRec = socket.Receive(bytes);
                    errmsg.AppendLine($"Receive {bytesRec} bytes.");
                    response_str = Encoding.ASCII.GetString(bytes);
                    errmsg.AppendLine($"={bytesRec}");

                    //Console.WriteLine("Echoed test = {0}",
                    //    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                }
                catch (ArgumentNullException ane)
                {
                    //Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    errmsg.AppendLine($"ArgumentNullException : {ane}");
                }
                catch (SocketException se)
                {
                    //Console.WriteLine("SocketException : {0}", se.ToString());
                    errmsg.AppendLine($"SocketException : {se}");
                }
                catch (Exception e)
                {
                    //Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    errmsg.AppendLine($"Unexpected exception : {e}");
                }

            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                errmsg.AppendLine($"{e}");
            }
            ErrMsg = $"{errmsg}";
        }
    }
}
