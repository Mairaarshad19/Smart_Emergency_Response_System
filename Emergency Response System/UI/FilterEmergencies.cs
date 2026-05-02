using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class FilterEmergencies : Form
    {
        public FilterEmergencies()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*string selected = cmbId.SelectedItem.ToString();
            int emergencyIntersection = Convert.ToInt32(selected.Split('-')[0].Trim());

            AmbulanceBL[] prioritizedAmbulances = AmbulanceManager.GetPrioritizedAmbulances(cityGraph, emergencyIntersection);

            // Bind array to grid
            dgvAmbulances.DataSource = null;
            dgvAmbulances.DataSource = prioritizedAmbulances;

            // Pick fastest available
            AmbulanceBL fastest = null;
            for (int i = 0; i < prioritizedAmbulances.Length; i++)
            {
                if (string.Equals(prioritizedAmbulances[i].status, "Available", StringComparison.OrdinalIgnoreCase))
                {
                    fastest = prioritizedAmbulances[i];
                    break;
                }
            }

            if (fastest != null)
            {
                MessageBox.Show($"Fastest ambulance: {fastest.plate_number}, ETA: {fastest.EtaMinutes} minutes.");
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvEmergencies.DataSource = SortManager.GetPrioritizedEmergencies();
        }

        private void dgvEmergencies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ShowPrioritizedData_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }
    }
}
