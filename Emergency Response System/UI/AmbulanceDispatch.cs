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
using Emergency_Response_System.DL;
using Emergency_Response_System.Managers;
using Emergency_Response_System.Helpers;
using static System.Collections.Specialized.BitVector32;
using Emergency_Response_System.BL.Emergency_Response_System.BL;

namespace Emergency_Response_System.UI
{
    public partial class AmbulanceDispatch : Form
    {
        public AmbulanceDispatch() 
        { 
            InitializeComponent();
            LoadStartAndEndIds();
        }
        private void LoadStartAndEndIds()
        {
            cmbStart.Items.Clear();
            cmbEnd.Items.Clear();

            // Load stations
            foreach (var station in StationDL.GetAllStations())
            {
                cmbStart.Items.Add($"{station.station_id} - {station.name} (Int {station.IntersectionId})");
            }

            // Load emergencies
            foreach (var emergency in EmergencyDL.GetAllEmergencies())
            {
                cmbEnd.Items.Add($"{emergency.emergency_id} - {emergency.severity} (Int {emergency.intersection_id})");
            }
        }




        private void btnCoverage_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void cmbEmergencyIntersection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AmbulanceDispatch_Load(object sender, EventArgs e)
        {
        }

        private void cmbSeverity_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbStart.SelectedItem == null || cmbEnd.SelectedItem == null)
            {
                MessageBox.Show("Please select both a start station and an emergency.");
                return;
            }

            // Parse intersection IDs from combo box text
            string startText = cmbStart.SelectedItem.ToString();
            string endText = cmbEnd.SelectedItem.ToString();

            int startId = int.Parse(startText.Split(new[] { "Int" }, StringSplitOptions.None)[1].Trim(')', ' '));
            int endId = int.Parse(endText.Split(new[] { "Int" }, StringSplitOptions.None)[1].Trim(')', ' '));

            // Now you can compute route
            var roads = RoadDL.GetAllRoadsDetails();
            var intersectionsDL = new IntersectionDL(); // if you have GetMaxId implemented
            int maxId = IntersectionDL.GetMaxId();
            var graph = new GraphBL(maxId);

            foreach (var r in roads)
            {
                graph.AddDirected(r.FromIntersectionId, r.ToIntersectionId, r.TravelTimeMinutes, r.TrafficFactor, r.Status, r.Name, r.DistanceKm);
                graph.AddDirected(r.ToIntersectionId, r.FromIntersectionId, r.TravelTimeMinutes, r.TrafficFactor, r.Status, r.Name, r.DistanceKm);
            }

            var routeManager = new RouteManager();
            var result = routeManager.ComputeRoute(startId, endId, graph);

            lblEta.Text = result.TotalMinutes + " min";
            lblDistance.Text = result.TotalDistanceKm.ToString("0.0") + " km";
            listDirections.Items.Clear();
            foreach (var s in result.Steps)
            {
                listDirections.Items.Add($"{s.RoadName}: {s.DistanceKm:0.0} km, {s.SegmentMinutes:0} min (from {s.From} → {s.To})");
            }
        }

        private void listDirections_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }
    }
}
