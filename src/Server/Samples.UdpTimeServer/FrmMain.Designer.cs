namespace Samples.UdpTimeServer
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.sbtnPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.sbtnMinsToRun = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sbtnPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbtnMinsToRun)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port ";
            // 
            // sbtnPort
            // 
            this.sbtnPort.Location = new System.Drawing.Point(67, 12);
            this.sbtnPort.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.sbtnPort.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.sbtnPort.Name = "sbtnPort";
            this.sbtnPort.ReadOnly = true;
            this.sbtnPort.Size = new System.Drawing.Size(73, 24);
            this.sbtnPort.TabIndex = 1;
            this.sbtnPort.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minutes to run (max 10)";
            // 
            // sbtnMinsToRun
            // 
            this.sbtnMinsToRun.Location = new System.Drawing.Point(348, 12);
            this.sbtnMinsToRun.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sbtnMinsToRun.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sbtnMinsToRun.Name = "sbtnMinsToRun";
            this.sbtnMinsToRun.ReadOnly = true;
            this.sbtnMinsToRun.Size = new System.Drawing.Size(69, 24);
            this.sbtnMinsToRun.TabIndex = 3;
            this.sbtnMinsToRun.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Silver;
            this.btnStart.Location = new System.Drawing.Point(436, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 32);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // Output
            // 
            this.Output.AcceptsReturn = true;
            this.Output.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Output.Location = new System.Drawing.Point(0, 57);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(522, 162);
            this.Output.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 219);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.sbtnMinsToRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sbtnPort);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "UDP Time server";
            ((System.ComponentModel.ISupportInitialize)(this.sbtnPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbtnMinsToRun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sbtnPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown sbtnMinsToRun;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox Output;
    }
}

