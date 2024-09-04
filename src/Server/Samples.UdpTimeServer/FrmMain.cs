using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Samples.UdpTimeServer
{
    public partial class FrmMain : Form
    {
        int serverPort = 1;
        delegate void SetTextDelegate(string s);
        delegate void EnableGuiDelegate(bool b);

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            EnableGui(false);
            try
            {
                Thread worker = new Thread(Run);
                worker.IsBackground = true;
                worker.Start();
            }
            catch (Exception ex)
            {
                SetText(ex.Message);
            }
        }

        void Run()
        {
            serverPort = Convert.ToInt32(sbtnPort.Value);
            uint mins = Convert.ToUInt32(sbtnMinsToRun.Value);
            DateTime timeToStart = DateTime.Now;
            DateTime timeToStop = DateTime.Now.AddMinutes(mins);
            //Step 1 create the udpClient
            UdpClient udpClient = new UdpClient();
            StringBuilder buf = new StringBuilder();
            buf.AppendFormat("UDP Server running at port {0}\n",serverPort);
            buf.AppendFormat("Server starting at {0}\n", timeToStart.ToString());
            buf.AppendFormat("Server will stop at {0}\n", timeToStop.ToString());
            SetText(buf.ToString());
            do
            {
                StringBuilder response = new StringBuilder();
                response.AppendLine("Sending the current datetime to client");
                response.AppendLine("The current date is ");
                response.AppendLine(DateTime.Now.ToLongDateString() + Environment.NewLine);
                response.AppendLine("the current time is");
                response.AppendLine(DateTime.Now.ToLongTimeString() + Environment.NewLine);
                //step 2 create the remote endpoint to send the data.
                IPEndPoint IPremoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort);
                //step 3 convert the string data to a byte array and sends it
                byte[] data = Encoding.UTF8.GetBytes(response.ToString());
                udpClient.Send(data, data.Length, IPremoteEP);
            } while (DateTime.Now < timeToStop);
            udpClient.Close();
            SetText("[ Server Closed at ] " + DateTime.Now.ToString());
            EnableGui(true);
        }

        void SetText(string s)
        {
            if (Output.InvokeRequired)
            {
                SetTextDelegate del = new SetTextDelegate(SetText);
                this.Invoke(del, new object[] { s });
            }
            else
                Output.Text += s + Environment.NewLine;
        }

        void EnableGui(bool b)
        {
            if (btnStart.InvokeRequired)
            {
                EnableGuiDelegate del = new EnableGuiDelegate(EnableGui);
                this.Invoke(del, new object[] { b });
            }
            else
                btnStart.Enabled = b;
        }
    }
}
