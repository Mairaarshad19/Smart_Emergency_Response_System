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
using Org.BouncyCastle.Asn1.Cmp;

namespace Emergency_Response_System.UI
{
    public partial class Update_Ambulance : Form
    {
        public Update_Ambulance()
        {
            InitializeComponent();
        }
        public event Action OnAmbulanceChanged;

        private void button1_Click(object sender, EventArgs e)
        {   
            try
            {
                int ambulanceId = Convert.ToInt32(txtAmbid.Text.Trim());
                int stationId = Convert.ToInt32(txtstationid.Text.Trim());
                string plateNo = txtplateno.Text.Trim();
                string equipment = txtEquipment.Text.Trim();
                string status = cmbstatus.SelectedItem?.ToString() ?? "Available";

                // Create updated object
                AmbulanceBL ambulance = new AmbulanceBL
                {
                    ambulance_id = ambulanceId,
                    station_id = stationId,
                    plate_number = plateNo,
                    equipment = equipment,
                    status = status
                };

                // Call DL method
                AmbulanceDL.UpdateAmbulance(ambulance);
                OnAmbulanceChanged?.Invoke(); // fire event
                this.Close();

                MessageBox.Show("Ambulance updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating ambulance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Ambulance_Load(object sender, EventArgs e)
        {

        }
    }
}
