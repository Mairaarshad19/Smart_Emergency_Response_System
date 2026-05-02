using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Web.WebView2.WinForms;

namespace Emergency_Response_System.UI
{
    public partial class Google_Map : Form
    {
        public Google_Map()
        {
            InitializeComponent();
        }

        private async void search_data_Click(object sender, EventArgs e)
        {
            try
            {
                string city = txt_city.Text.Trim();
                double latitude, longitude;

                // Validate latitude
                if (!double.TryParse(txt_lat.Text, out latitude))
                {
                    MessageBox.Show("Please enter a valid latitude");
                    return;
                }

                // Validate longitude
                if (!double.TryParse(txt_long.Text, out longitude))
                {
                    MessageBox.Show("Please enter a valid longitude");
                    return;
                }

                // Validate ranges
                if (latitude < -90 || latitude > 90)
                {
                    MessageBox.Show("Latitude must be between -90 and 90");
                    return;
                }

                if (longitude < -180 || longitude > 180)
                {
                    MessageBox.Show("Longitude must be between -180 and 180");
                    return;
                }

                // Build Google Maps URL
                string url;

                if (!string.IsNullOrWhiteSpace(city))
                {
                    url = $"https://www.google.com/maps?q={Uri.EscapeDataString(city)}";
                }
                else
                {
                    url = $"https://www.google.com/maps?q={latitude},{longitude}";
                }

                // Ensure WebView2 is initialized
                await webView21.EnsureCoreWebView2Async();
                webView21.Dock = DockStyle.Fill;


                // Navigate inside SplitContainer Panel2
                webView21.Source = new Uri(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
