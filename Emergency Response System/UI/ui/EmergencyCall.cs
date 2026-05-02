using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Org.BouncyCastle.Asn1.Cmp;

namespace Emergency_Response_System.UI
{
    public partial class EmergencyCall : Form
    {
        public EmergencyCall()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        EmergencyPriorityQueue emergencyQueue = new EmergencyPriorityQueue();
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                // Collect values from form controls
                string callerName = txtname.Text.Trim();
                string callerPhone = txtphone.Text.Trim();
                decimal longitude = Convert.ToDecimal(txtlongitude.Text.Trim());
                decimal latitude = Convert.ToDecimal(txtlatitude.Text.Trim());
                string severity = cmbseverity.SelectedItem?.ToString();
                string description = txtdescription.Text.Trim();
                string status= cmbstatus.SelectedItem?.ToString();

                // Create EmergencyBL object
                EmergencyBL emergency = new EmergencyBL
                {
                    caller_name = callerName,
                    caller_phone = callerPhone,
                    longitude = longitude,
                    latitude = latitude,
                    severity = severity,
                    description = description,
                    status = status
                };

                // Validate before saving
                if (!emergency.IsValid())
                {
                    MessageBox.Show("Please fill all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save to database
                EmergencyDL.AddEmergency(emergency);
                emergencyQueue.Enqueue(emergency);

                MessageBox.Show("Emergency call added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally clear form after insert
                txtname.Clear();
                txtphone.Clear();
                txtlongitude.Clear();
                txtlatitude.Clear();
                txtdescription.Clear();
                cmbseverity.SelectedIndex = -1;
                cmbstatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding emergency: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Dashboard();
            form.ShowDialog();

        }
    }
}
