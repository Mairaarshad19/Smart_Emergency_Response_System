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
            LoadIntersections();
        }

        private void label7_Click(object sender, EventArgs e)
        {


        }
        private void LoadIntersections()
        {
            var intersections = IntersectionDL.GetAllIntersections();
            cmbIntersection.Items.Clear();

            foreach (var i in intersections)
            {
                cmbIntersection.Items.Add(i.Id);
            }
            cmbIntersection.SelectedIndex = -1;
        }


        EmergencyPriorityQueue emergencyQueue = new EmergencyPriorityQueue();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string callerName = txtname.Text.Trim();
                string callerPhone = txtphone.Text.Trim();
                decimal longitude = Convert.ToDecimal(txtlongitude.Text.Trim());
                decimal latitude = Convert.ToDecimal(txtlatitude.Text.Trim());
                string severity = cmbseverity.SelectedItem?.ToString();
                string description = txtdescription.Text.Trim();
                string status = cmbstatus.SelectedItem?.ToString();

                // ✅ Get intersection from ComboBox
                if (cmbIntersection.SelectedItem == null)
                {
                    MessageBox.Show("Please select an intersection.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int intersectionId = Convert.ToInt32(cmbIntersection.SelectedItem);

                EmergencyBL emergency = new EmergencyBL
                {
                    caller_name = callerName,
                    caller_phone = callerPhone,
                    longitude = longitude,
                    latitude = latitude,
                    severity = severity,
                    description = description,
                    status = status,
                    intersection_id = intersectionId   // ✅ set FK
                };

                if (!emergency.IsValid())
                {
                    MessageBox.Show("Please fill all required fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EmergencyDL.AddEmergency(emergency);
                emergencyQueue.Enqueue(emergency);

                MessageBox.Show("Emergency call added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form
                txtname.Clear();
                txtphone.Clear();
                txtlongitude.Clear();
                txtlatitude.Clear();
                txtdescription.Clear();
                cmbseverity.SelectedIndex = -1;
                cmbstatus.SelectedIndex = -1;
                cmbIntersection.SelectedIndex = -1;
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
            var form = new Admin_Dashboard();
            form.ShowDialog();

        }

        private void EmergencyCall_Load(object sender, EventArgs e)
        {

        }
    }
}
