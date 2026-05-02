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
using Emergency_Response_System.Managers;
using MySqlX.XDevAPI.Relational;

namespace Emergency_Response_System.UI
{
    public partial class EmergencyLocation : Form
    {
        private MapControl mapControl;
        public EmergencyLocation()
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
                MessageBox.Show("Please enter a valid numeric Emergency ID.");
                return;
            }

            EmergencyBL emergency = LookupManager.GetEmergencyById(id);
            if (emergency != null)
            {
                lblResult.Text = $"Emergency {emergency.emergency_id} - {emergency.description}";
                mapControl.ShowEmergencyOnMap(emergency); 
            }
            else
            {
                MessageBox.Show("Emergency not found.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }

        private void EmergencyLocation_Load(object sender, EventArgs e)
        {

        }
    }

}


