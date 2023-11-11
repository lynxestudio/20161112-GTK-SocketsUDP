using System;
using Gtk;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace GtkSamples.Networking.UDPClient
{
    public class MainWindow : Gtk.Window
    {
        VBox mainLayout = new VBox();
		HBox buttonBox = new HBox();
       Table tableLayout = new Table(4,2,false);
	   SpinButton spbtnPort = new SpinButton(7D, 10000D, 1D);
	   Entry txtHostName = new Entry();
	   TextView txtLog = new TextView();
	   Button btnRequest = new Button("Request");
	   Button btnClose = new Button("Close");
		Label lblMsg = new Label("Output ");
		int portToReceive = 0;

		public MainWindow():base(WindowType.Toplevel)
        {
            this.Title = "UDP GTK# Chat Example";
            this.DeleteEvent += new DeleteEventHandler(OnWindowDelete);
			this.btnClose.Clicked += new EventHandler(Close);
			this.btnRequest.Clicked += new EventHandler(Request);
            mainLayout.BorderWidth = 8;
			tableLayout.RowSpacing = 6;
			tableLayout.ColumnSpacing = 6;
			tableLayout.Attach(new Label("Port to connect "), 0, 1, 0, 1);
			spbtnPort.Numeric = true;
			tableLayout.Attach(spbtnPort, 1, 2, 0, 1);
			tableLayout.Attach(new Label("IP/Hostname"), 0, 1, 1, 2);
			tableLayout.Attach(txtHostName, 1,2, 1, 2);
			tableLayout.Attach(new Label("Response"), 0, 1, 2, 3);
			txtLog.SetSizeRequest(199,66);
			tableLayout.Attach(txtLog, 1, 2, 2, 3);
			buttonBox.Spacing = 6;
			buttonBox.PackStart(btnRequest, true, true, 0);
			buttonBox.PackStart(btnClose, true, true, 0);

            mainLayout.PackStart(tableLayout,false,true,0);
			mainLayout.PackStart(buttonBox, false, true, 0);
			mainLayout.Add(lblMsg);
            this.Add(mainLayout);
            this.ShowAll();
        }

		protected void OnWindowDelete(object o, DeleteEventArgs args)
		{
			System.Environment.Exit(Environment.ExitCode);
		}

		protected void Close(object o, EventArgs args)
		{
			System.Environment.Exit(Environment.ExitCode);
		}

		protected void Request(object o, EventArgs args)
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
					txtLog.Buffer.Text = text;
				}
				catch (System.Exception ex)
				{
					lblMsg.Text += ex.Message;
				}
				finally
				{
					//step 5 Close the Socket
					client.Close();
				}
			}
		}

    }
}