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

namespace Emergency_Response_System.UI
{
    public partial class FindCoverage : Form
    {
        public FindCoverage()
        {
            InitializeComponent();
            LoadStationsIntoComboBox();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCoverage_Click(object sender, EventArgs e)
        {
            
                
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadStationsIntoComboBox()
        {
            comboBoxStations.Items.Clear();

            foreach (var name in StationDL.GetDistinctStationNames())
            {
                comboBoxStations.Items.Add(name);
            }
        }

        private void FindCoverage_Load(object sender, EventArgs e)
        {

        }

        private void btnCoverage_Click_1(object sender, EventArgs e)
        {
            // Load data
            StationManager.LoadStations(); 
            IntersectionManager.LoadIntersections(); 
            RoadManager.LoadRoads(); 
            CityGraph graph = RoadManager.BuildGraph(); 
            string selectedStation = comboBoxStations.SelectedItem?.ToString(); 
            if (string.IsNullOrEmpty(selectedStation)) 
            { 
                MessageBox.Show("Please select a station first."); 
                return;
            }
            int sourceIntersectionId = StationManager.GetMappedIntersectionId(selectedStation); 
            int sourceIndex = graph.GetIndexById(sourceIntersectionId); 
            if (sourceIndex == -1) 
            { 
                MessageBox.Show("Station not mapped to any intersection in graph."); 
                return;
            }
            double[] dist = Dijkstra.Run(graph, sourceIndex); 
            double threshold = 10.0; 
            gridCoverage.Rows.Clear(); 
            gridCoverage.Columns.Clear(); 
            gridCoverage.Columns.Add("intersection", "Intersection"); 
            gridCoverage.Columns.Add("time", "Time (min)"); 
            for (int i = 0; i < graph.Count; i++) 
            { 
                if (dist[i] <= threshold) 
                { 
                    string name = graph.Intersections[i].Name;
                    string time = dist[i].ToString("F1"); 
                    gridCoverage.Rows.Add(name, time);
                } 
            }
        }

        private void gridCoverage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
