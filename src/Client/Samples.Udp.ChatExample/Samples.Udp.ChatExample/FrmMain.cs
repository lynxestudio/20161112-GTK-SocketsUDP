using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Samples.Udp.ChatExample
{
    public partial class FrmChat : Form
    {
        int portToReceive = 0;

        public FrmChat()
        {
            InitializeComponent();
        }

        private void btnCloseClick(object sender, EventArgs e)
        {
            System.Environment.Exit(Environment.ExitCode);
        }

        private void btnRequestClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHostName.Text))
            {
                lblMsg.Text += "Hostname null";
            }
            else
            {
                portToReceive = Convert.ToInt32(spbtnPort.Text);
                //step 1 Create a UdpClient and specifies a port number to bind
                UdpClient client = new UdpClient(portToReceive);
                string text = null;
                try
                {
                    //step 2 Create the IPEndPoint to receive the byte array
                    IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                    //step 3 Get the byte array
                    byte[] data = client.Receive(ref anyIP);
                    //step 4 Convert the byte array to string
                    text = Encoding.UTF8.GetString(data);
                    txtLog.Text = text;
                }
                catch (Exception ex)
                {
                    lblMsg.Text += ex.Message;
                }
                finally {
                    //step 5 Close the socket
                    client.Close();
                }
            }
        }

    }
}
