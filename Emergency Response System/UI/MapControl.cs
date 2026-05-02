using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using global::Emergency_Response_System.Managers;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using Emergency_Response_System.BL;
using Emergency_Response_System.Managers;
using System.IO;
using Microsoft.Web.WebView2.Core;

namespace Emergency_Response_System.UI
{
    public partial class MapControl : UserControl
    {
        public event Action<double, double> StationLocationSelected;
        public MapControl()
        {
            InitializeComponent();
            LoadMap();
        }
        public async void LoadMap()
        {
            await webView21.EnsureCoreWebView2Async();

            string path = Path.Combine(Application.StartupPath, "map.html");
            webView21.Source = new Uri("file:///" + path.Replace("\\", "/"));
            webView21.Dock = DockStyle.Fill;

            webView21.CoreWebView2.WebMessageReceived += (s, e) =>
            {
                var coords = JsonConvert.DeserializeObject<Coords>(e.WebMessageAsJson);
                StationLocationSelected?.Invoke(coords.latitude, coords.longitude);
            };
        }
        private class Coords
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public async void AddMarker(double lat, double lng, string label)
        {
            string js = $"L.marker([{lat}, {lng}]).addTo(map).bindPopup('{label}');";
            await webView21.CoreWebView2.ExecuteScriptAsync(js);
        }

        public async void DrawCoverage(double lat, double lng, int kmRadius)
        {
            string js = $"L.circle([{lat}, {lng}], {{ radius: {kmRadius * 1000}, color: 'blue' }}).addTo(map);";
            await webView21.CoreWebView2.ExecuteScriptAsync(js);
        }

        public async void ShowAmbulanceLocation(double latitude, double longitude)
        {
            string url = $"https://www.google.com/maps?q={latitude},{longitude}";
            await webView21.EnsureCoreWebView2Async();
            webView21.Source = new Uri(url);
            webView21.Dock = DockStyle.Fill;
        }


        /*public async void ShowEmergenciesOnMap(IEnumerable<EmergencyBL> emergencies)
        {
            // Start with base URL
            string url = "https://www.google.com/maps/dir/";

            // Append each emergency’s coordinates
            foreach (var e in emergencies)
            {
                url += $"{e.latitude},{e.longitude}/";
            }

            // Load into WebView2
            await webView21.EnsureCoreWebView2Async();
            webView21.Source = new Uri(url);
        }
        */
        private void webView21_Click(object sender, EventArgs e)
        {

        }
        public async void ShowEmergencyOnMap(EmergencyBL emergency)
        {
            string url = $"https://www.google.com/maps?q={emergency.latitude},{emergency.longitude}";
            webView21.Source = new Uri(url);
        }
        public async void ShowAmbulanceOnMap(AmbulanceBL ambulance)
        {
            string url = $"https://www.google.com/maps?q={ambulance.current_latitude},{ambulance.current_longitude}";
            webView21.Source = new Uri(url);
        }

    }
}
