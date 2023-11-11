using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Gtk;
using System.Threading;


namespace GtkSamples.Networking.UDPTimeServer
{
	public class MainWindow : Gtk.Window
	{
		VBox mainLayout = new VBox();
		Button btnStart = new Button("Start");
		HBox controlBox = new HBox();

		SpinButton sbtnPort = new SpinButton(7D, 10000D, 1D);
		SpinButton sbtnMinsToRun = new SpinButton(1D,11D,1D);
		TextView txtLog = new TextView();
		Label txtSend = new Label();
		Label lblMsg = new Label("Output: ");
		int serverPort = 1;

		public MainWindow() : base(WindowType.Toplevel)
		{
			this.Title = "UDP Time Server";
			this.SetDefaultSize(366,111);
			this.DeleteEvent += new DeleteEventHandler(OnWindowDelete);
			this.btnStart.Clicked += new EventHandler(Start);
			mainLayout.BorderWidth = 8;

			controlBox.BorderWidth = 8;
			controlBox.Spacing = 6;
            controlBox.PackStart(new Label("Port 1-10000"),false,true,0);
			sbtnMinsToRun.ClimbRate = 1D;
			sbtnMinsToRun.Numeric = true;
            controlBox.PackStart(sbtnPort,true,true,0);
			controlBox.PackStart(new Label("Minutes to run (max 11)"),false,true,0);
			sbtnMinsToRun.ClimbRate = 1D;
			sbtnMinsToRun.Numeric = true;
			controlBox.PackStart(sbtnMinsToRun, true, true, 0);
            controlBox.PackStart(btnStart,false,false,0);
			mainLayout.PackStart(controlBox,false,true,0);
            mainLayout.PackStart(txtLog,true,true,0);
			this.Add(mainLayout);
            this.ShowAll();
		}

		protected void OnWindowDelete(object o,DeleteEventArgs args)
		{
			System.Environment.Exit(Environment.ExitCode);
		}

		protected void Start(object o,EventArgs args)
		{
			try
			{
				Thread worker = new Thread(Run);
				worker.IsBackground = true;
				worker.Start();	
			}
			catch (System.Exception ex)
			{
				txtLog.Buffer.Text += ex.Message;
			}
		}

		void Run()
		{
				controlBox.Hide();
				serverPort = Convert.ToInt32(sbtnPort.Text);
				uint mins = Convert.ToUInt32(sbtnMinsToRun.Text);
				DateTime timeToStart = DateTime.Now;
				DateTime timeToStop = DateTime.Now.AddMinutes(mins);
				//Step 1 create the UdpClient
				UdpClient udpClient = new UdpClient();
				StringBuilder buf = new StringBuilder();
				buf.AppendFormat("UDP Server running at port {0}\n", serverPort);
				buf.AppendFormat("Server starting at {0}\n", timeToStart.ToString());
				buf.AppendFormat("Server will stop at {0}\n", timeToStop.ToString());
				txtLog.Buffer.Text = buf.ToString();
				do
				{
				StringBuilder response = new StringBuilder();
				response.AppendLine("Sending the current datetime to client");
				response.AppendLine("The current date is ");
				response.AppendLine(DateTime.Now.ToLongDateString());
				response.AppendLine("the current time is ");
				response.AppendLine(DateTime.Now.ToLongTimeString());
				//step 2 create the remote endpoint to send the data.
				IPEndPoint IPremoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"),serverPort);
				//step 3 convert the string data to a byte array and sends it
				byte[] data = Encoding.UTF8.GetBytes(response.ToString());
				udpClient.Send(data,data.Length,IPremoteEP);
				} while (DateTime.Now < timeToStop);
				udpClient.Close();
			txtLog.Buffer.Text += "Server stopping at " + DateTime.Now.ToString();
		}
	}
}
