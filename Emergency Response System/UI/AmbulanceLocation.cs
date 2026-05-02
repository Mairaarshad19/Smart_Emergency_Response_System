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
using MySqlX.XDevAPI.Relational;

namespace Emergency_Response_System.UI
{
    public partial class AmbulanceLocation : Form
    {
        private MapControl mapControl;

        public AmbulanceLocation()
        {
            InitializeComponent();
            mapControl = new MapControl();
            mapControl.Dock = DockStyle.Fill;
            this.Controls.Add(mapControl);
            LookupManager.LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txt_id.Text, out id))
            {
                MessageBox.Show("Please enter a valid numeric Ambulance ID.");
                return;
            }

            AmbulanceBL ambulance = LookupManager.GetAmbulanceById(id);
            if (ambulance != null)
            {
                lblResult.Text = $"Ambulance {ambulance.ambulance_id} - {ambulance.plate_number} - Status: {ambulance.status}";
                mapControl.ShowAmbulanceOnMap(ambulance);
            }
            else
            {
                MessageBox.Show("Ambulance not found.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }

        private void AmbulanceLocation_Load(object sender, EventArgs e)
        {

        }
    }
}

