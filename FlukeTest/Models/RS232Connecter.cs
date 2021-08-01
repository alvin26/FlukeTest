using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlukeTest.Models
{
    public class RS232Connecter : IDisposable
    {
        public SerialPort serialPort { get; set; }
        //StringBuilder msg;
        public RS232Connecter(string ComPortName)
        {
            //msg = new StringBuilder();
            serialPort = new SerialPort();

            serialPort.Encoding = Encoding.ASCII;
            //serialPort.Encoding = Encoding.GetEncoding(28591);
            serialPort.RtsEnable = false;
            serialPort.DtrEnable = false;
            serialPort.ReadBufferSize = 8192;
            serialPort.ParityReplace = 63;
            serialPort.ReceivedBytesThreshold = 1;
            serialPort.DiscardNull = false;
            //serialPort.DataReceived += serialDataReceived;
            serialPort.DataReceived += serialDataReceivedEventHandler;
            //serialPort.ErrorReceived += serialErrorReceived;
            serialPort.ErrorReceived += serialErrorReceivedEventHandler;
            serialPort.PortName = ComPortName;
            serialPort.DataBits = 8;
            serialPort.NewLine = "\r\n";
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.Handshake = Handshake.None;
            serialPort.BaudRate = 9600;

            serialPort.ReadTimeout = 10 * 1000;
            serialPort.WriteTimeout = 10 * 1000;
        }
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

        public SerialDataReceivedEventHandler serialDataReceivedEventHandler;
        public SerialErrorReceivedEventHandler serialErrorReceivedEventHandler;

        /// <summary>
        /// 一旦 close, 就要重新 new 一個來用
        /// </summary>
        public void Close()
        {
            serialPort.Close();
        }

        public void Open()
        {
            //msg.Clear();
            serialPort.Open();
        }

        public string Send(string Command)
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            // send „?T“ with EOL sequence
            serialPort.WriteLine(Command);
            //serialPort.WriteLine($"?XU");
            //serialPort.WriteLine($"?T");
            return serialPort.ReadLine();
        }

        public bool TestConnection(out string DeviceName, out string ErrMsg)
        {
            DeviceName = "";
            ErrMsg = "";
            bool success = false;
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }

                if (serialPort.IsOpen)
                {
                    // send „?T“ with EOL sequence
                    serialPort.WriteLine($"?XU");
                    //serialPort.WriteLine($"?T");
                    DeviceName = serialPort.ReadLine();
                    serialPort.Close();
                    success = true;
                }

                //備註
                //每個物件只能有一個開啟 SerialPort 的連接。
                //任何應用程式的最佳作法是在呼叫方法之後
                //等候一段時間 Close ，然後再嘗試呼叫 Open 方法，
                //因為埠可能無法立即關閉。

            }
            catch (Exception ex)
            {
                ErrMsg = $"{ex.Message}{ex.InnerException}";
            }
            return success;
        }

        public void Dispose()
        {
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();
                serialPort.Dispose();
                serialPort = null;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
