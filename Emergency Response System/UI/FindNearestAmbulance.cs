using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.BL.Emergency_Response_System.BL;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.UI
{
    public partial class FindNearestAmbulance : Form
    {
        public FindNearestAmbulance()
        {
            InitializeComponent();
        }

        private void btnCoverage_Click(object sender, EventArgs e)
        {
            AmbulanceLinkedList list = new AmbulanceLinkedList();
            foreach (var amb in AmbulanceDL.GetAllAmbulances())
            {
                list.Add(amb);
            }
            double emergencyLat = Convert.ToDouble(txtlat.Text);
            double emergencyLon = Convert.ToDouble(txtlong.Text);
            AmbulanceBL nearest = AmbulanceFinder.FindNearestAmbulance(list, emergencyLat, emergencyLon);
            if (nearest != null)
            {
                MessageBox.Show($"Nearest ambulance: {nearest.plate_number} at station {nearest.station_id}");
            }
            else
            {
                MessageBox.Show("No available ambulances found.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }

        private void FindNearestAmbulance_Load(object sender, EventArgs e)
        {

        }
    }
}
