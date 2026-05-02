using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.UI
{
    public partial class AmbLocation : Form
    {
        private MapControl mapControl;
        public AmbLocation()
        {
            InitializeComponent();
            mapControl = new MapControl();
            mapControl.Dock = DockStyle.Fill;
            this.Controls.Add(mapControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txt_id.Text, out int ambulanceId))
            {
                var location = AmbulanceDL.GetAmbulanceLocation(ambulanceId); 
                if (location != null && location.Status == "Dispatched") 
                {
                    mapControl.ShowAmbulanceLocation(location.Latitude, location.Longitude);
                }
                else 
                { 
                    MessageBox.Show("Ambulance not found or not dispatched.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }

        private void AmbLocation_Load(object sender, EventArgs e)
        {

        }
    }

}

