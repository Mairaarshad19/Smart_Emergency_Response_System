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
using Emergency_Response_System.UI;
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class FindAmbulanciesAtLocation : Form
    {
        public FindAmbulanciesAtLocation()
        {
            InitializeComponent();
            LoadIntersections();
        }

        public void LoadIntersections()
        {
            cmbId.Items.Clear();
            foreach (var inter in IntersectionDL.GetAllIntersections())
            {
                cmbId.Items.Add($"{inter.Id} - {inter.Name}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cmbId.SelectedItem == null)
            {
                MessageBox.Show("Please select an intersection.");
                return;
            }

            // Extract intersectionId from "Id - Name"
            string selectedText = cmbId.SelectedItem.ToString();
            string[] parts = selectedText.Split('-');
            int intersectionId = Convert.ToInt32(parts[0].Trim());

            // Get emergencies as Queue
            Queue<EmergencyBL> emergenciesQueue = EmergencyManager.SearchEmergenciesByLocation(intersectionId);

            // Convert Queue to List for binding
            var emergenciesList = emergenciesQueue.ToList();

            // Bind to DataGridView
            dgvEmergencies.DataSource = emergenciesList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }

        private void FindAmbulanciesAtLocation_Load(object sender, EventArgs e)
        {

        }

        //for displaying in the map
        //var emergenciesList = emergenciesQueue.ToList();

        //mapControl.ShowEmergenciesOnMap(emergenciesList);
    }

}



