namespace GPS_Simulator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TextBox tbCentreLat;
        private System.Windows.Forms.TextBox tbCentreLng;
        private System.Windows.Forms.TextBox tbRadius;
        private System.Windows.Forms.Label lblCentreLat;
        private System.Windows.Forms.Label lblCentreLng;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnStop;
        

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbCentreLat = new System.Windows.Forms.TextBox();
            this.tbCentreLng = new System.Windows.Forms.TextBox();
            this.tbRadius = new System.Windows.Forms.TextBox();
            this.lblCentreLat = new System.Windows.Forms.Label();
            this.lblCentreLng = new System.Windows.Forms.Label();
            this.lblRadius = new System.Windows.Forms.Label();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer();

            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();

            // chart
            this.chart.Location = new System.Drawing.Point(10, 100);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(1130, 430);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart";
            this.chart.Series.Add("trajectory");

            // tbCentreLat
            this.tbCentreLat.Location = new System.Drawing.Point(100, 50);
            this.tbCentreLat.Name = "tbCentreLat";
            this.tbCentreLat.Size = new System.Drawing.Size(100, 20);
            this.tbCentreLat.TabIndex = 2;

            // tbCentreLng
            this.tbCentreLng.Location = new System.Drawing.Point(300, 50);
            this.tbCentreLng.Name = "tbCentreLng";
            this.tbCentreLng.Size = new System.Drawing.Size(100, 20);
            this.tbCentreLng.TabIndex = 3;

            // tbRadius
            this.tbRadius.Location = new System.Drawing.Point(500, 50);
            this.tbRadius.Name = "tbRadius";
            this.tbRadius.Size = new System.Drawing.Size(100, 20);
            this.tbRadius.TabIndex = 4;

            // lblCentreLat
            this.lblCentreLat.AutoSize = true;
            this.lblCentreLat.Location = new System.Drawing.Point(20, 50);
            this.lblCentreLat.Name = "lblCentreLat";
            this.lblCentreLat.Size = new System.Drawing.Size(70, 13);
            this.lblCentreLat.TabIndex = 5;
            this.lblCentreLat.Text = "Centre Latitude";

            // lblCentreLng
            this.lblCentreLng.AutoSize = true;
            this.lblCentreLng.Location = new System.Drawing.Point(200, 50);
            this.lblCentreLng.Name = "lblCentreLng";
            this.lblCentreLng.Size = new System.Drawing.Size(75, 13);
            this.lblCentreLng.TabIndex = 6;
            this.lblCentreLng.Text = "Centre Longitude";

            // lblRadius
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(450, 50);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(43, 13);
            this.lblRadius.TabIndex = 7;
            this.lblRadius.Text = "Radius";

            // btnSimulate
            this.btnSimulate.Location = new System.Drawing.Point(600, 50);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(75, 23);
            this.btnSimulate.TabIndex = 8;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);

            // btnStop
            this.btnStop.Location = new System.Drawing.Point(700, 50);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.lblCentreLng);
            this.Controls.Add(this.lblCentreLat);
            this.Controls.Add(this.tbRadius);
            this.Controls.Add(this.tbCentreLng);
            this.Controls.Add(this.tbCentreLat);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.Text = "GPS Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
