using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GPS_Simulator
{
    public partial class Form1 : Form
    {
        const long EARTH_RADIUS_MTR = 6367500;

        double centre_lat = 0.0, centre_lng = 0.0, radius_mtr = 0.0;
        double x;
        bool forward = true;
        System.Windows.Forms.Timer timer;  // Ensure there's only one definition here

        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();  // Initialize timer in the constructor
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Code to be executed on every timer tick
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(drawCircle);
        }

        double degree2rad(double degree)
        {
            return (Math.PI / 180.0) * degree;
        }

        double rad2degree(double rad)
        {
            return (180.0 / Math.PI) * rad;
        }

        void drawCircle(object sender, EventArgs e)
        {
            double lat_max_limit = 0.0, lat_min_limit = 100.0;
            double lng_max_limit = 0.0, lng_min_limit = 100.0;
            double centre_lat_rad = degree2rad(centre_lat);
            double centre_lng_rad = degree2rad(centre_lng);
            if (forward)
            {
                if (x <= radius_mtr)
                {
                    double y = Math.Pow(Math.Pow(radius_mtr, 2) - Math.Pow(x, 2), 0.5);
                    double lat = centre_lat_rad + (y / EARTH_RADIUS_MTR);
                    double delta_lat = lat - centre_lat_rad;
                    //longitude(x_in_rad)
                    double lng = centre_lng_rad + (x / ((Math.Cos(centre_lat_rad) - Math.Sin(centre_lat_rad) * delta_lat) * EARTH_RADIUS_MTR));
                    lat = rad2degree(lat);
                    lng = rad2degree(lng);
                    lat_max_limit = Math.Max(lat, lat_max_limit);
                    lat_min_limit = Math.Min(lat, lat_min_limit);
                    lng_max_limit = Math.Max(lng, lng_max_limit);
                    lng_min_limit = Math.Min(lng, lng_min_limit);

                    chart.Series["trajectory"].Points.AddXY(x, y);
                    x += 0.01;
                }
                else
                {
                    forward = false;
                    x = radius_mtr;
                }
            }
            else
            {
                if (x >= -radius_mtr)
                {
                    double y = -Math.Pow(Math.Pow(radius_mtr, 2) - Math.Pow(x, 2), 0.5);
                    double lat = centre_lat_rad + (y / EARTH_RADIUS_MTR);
                    double delta_lat = lat - centre_lat_rad;
                    //longitude(x_in_rad)
                    double lng = centre_lng_rad + (x / ((Math.Cos(centre_lat_rad) - Math.Sin(centre_lat_rad) * delta_lat) * EARTH_RADIUS_MTR));
                    lat = rad2degree(lat);
                    lng = rad2degree(lng);
                    lat_max_limit = Math.Max(lat, lat_max_limit);
                    lat_min_limit = Math.Min(lat, lat_min_limit);
                    lng_max_limit = Math.Max(lng, lng_max_limit);
                    lng_min_limit = Math.Min(lng, lng_min_limit);
                    chart.Series["trajectory"].Points.AddXY(x, y);
                    x -= 0.01;
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        void drawCircle(double centre_lat, double centre_lng, double radius_mtr)
        {
            double lat_max_limit = 0.0, lat_min_limit = 100.0;
            double lng_max_limit = 0.0, lng_min_limit = 100.0;
            double centre_lat_rad = degree2rad(centre_lat);
            double centre_lng_rad = degree2rad(centre_lng);
            for (double x = -radius_mtr; x <= radius_mtr; x += 0.01)
            {
                double y = Math.Pow(Math.Pow(radius_mtr, 2) - Math.Pow(x, 2), 0.5);
                double lat = centre_lat_rad + (y / EARTH_RADIUS_MTR);
                double delta_lat = lat - centre_lat_rad;
                //longitude(x_in_rad)
                double lng = centre_lng_rad + (x / ((Math.Cos(centre_lat_rad) - Math.Sin(centre_lat_rad) * delta_lat) * EARTH_RADIUS_MTR));
                lat = rad2degree(lat);
                lng = rad2degree(lng);
                lat_max_limit = Math.Max(lat, lat_max_limit);
                lat_min_limit = Math.Min(lat, lat_min_limit);
                lng_max_limit = Math.Max(lng, lng_max_limit);
                lng_min_limit = Math.Min(lng, lng_min_limit);
                chart.Series["trajectory"].Points.AddXY(lat, lng);
            }
            for (double x = radius_mtr; x >= -radius_mtr; x -= 0.01)
            {
                double y = -Math.Pow(Math.Pow(radius_mtr, 2) - Math.Pow(x, 2), 0.5);
                double lat = centre_lat_rad + (y / EARTH_RADIUS_MTR);
                double delta_lat = lat - centre_lat_rad;
                //longitude(x_in_rad)
                double lng = centre_lng_rad + (x / ((Math.Cos(centre_lat_rad) - Math.Sin(centre_lat_rad) * delta_lat) * EARTH_RADIUS_MTR));
                lat = rad2degree(lat);
                lng = rad2degree(lng);
                lat_max_limit = Math.Max(lat, lat_max_limit);
                lat_min_limit = Math.Min(lat, lat_min_limit);
                lng_max_limit = Math.Max(lng, lng_max_limit);
                lng_min_limit = Math.Min(lng, lng_min_limit);
                chart.Series["trajectory"].Points.AddXY(lat, lng);
            }
            chart.ChartAreas[0].AxisX.Minimum = lat_min_limit;
            chart.ChartAreas[0].AxisX.Maximum = lat_max_limit;
            chart.ChartAreas[0].AxisY.Minimum = lng_min_limit;
            chart.ChartAreas[0].AxisY.Maximum = lng_max_limit;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.000";
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.000";
        }

        /*private void btnSimulate_Click(object sender, EventArgs e)
        {
            if (chart.Series.IndexOf("trajectory") != -1)
            {
                chart.Series["trajectory"].Points.Clear();
            }
            else
            {
                MessageBox.Show("The series 'trajectory' was not found in the chart.");
            }

            // Read data from user
            try
            {
                centre_lat = Double.Parse(tbCentreLat.Text);
                centre_lng = Double.Parse(tbCentreLng.Text);
                radius_mtr = Double.Parse(tbRadius.Text);
                if (radius_mtr <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius_mtr", "Radius must be greater than zero.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter coordinates and radius correctly");
                return;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message); // Display the error if the radius is out of range
                return;
            }

            timer.Interval = 1;
            x = -radius_mtr;
            chart.ChartAreas[0].AxisX.Minimum = -radius_mtr;
            chart.ChartAreas[0].AxisX.Maximum = +radius_mtr;
            chart.ChartAreas[0].AxisY.Minimum = -radius_mtr;
            chart.ChartAreas[0].AxisY.Maximum = +radius_mtr;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "0.000";
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "0.000";
            timer.Start();
        }*/
        private void btnSimulate_Click(object sender, EventArgs e)
        {
            // Ensure the series exists and is cleared
            var trajectorySeries = chart.Series.FindByName("trajectory");
            if (trajectorySeries == null)
            {
                trajectorySeries = new Series("trajectory");
                trajectorySeries.ChartType = SeriesChartType.Line;  // Set chart type as necessary
                chart.Series.Add(trajectorySeries);
            }
            else
            {
                trajectorySeries.Points.Clear();
            }

            // Read and validate user input
            try
            {
                centre_lat = Double.Parse(tbCentreLat.Text);
                centre_lng = Double.Parse(tbCentreLng.Text);
                radius_mtr = Double.Parse(tbRadius.Text);

                if (radius_mtr <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius_mtr", "Radius must be greater than zero.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for coordinates and radius.");
                return;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (chart.ChartAreas.Count == 0)
            {
                chart.ChartAreas.Add(new ChartArea("Default"));
            }
            // Ensure the chart area exists
            if (chart.ChartAreas.Count > 0)
            {
                var chartArea = chart.ChartAreas[0];

                // Set axis limits to accommodate negative values
                chartArea.AxisX.Minimum = -radius_mtr;
                chartArea.AxisX.Maximum = radius_mtr;
                chartArea.AxisY.Minimum = -radius_mtr;
                chartArea.AxisY.Maximum = radius_mtr;
                chartArea.AxisX.LabelStyle.Format = "0.000";
                chartArea.AxisY.LabelStyle.Format = "0.000";
            }
            else
            {
                MessageBox.Show("No chart areas available. Please check the chart configuration.");
                return;
            }

            // Configure and start the simulation
            timer.Interval = 1;
            x = -radius_mtr;
            timer.Tick += new EventHandler(drawCircle);
            timer.Start();
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }
    }
}
