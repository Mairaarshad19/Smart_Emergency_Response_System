using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class Manage_Ambulance : Form
    {
        public static LinkedList<AmbulanceBL> ambulances = new LinkedList<AmbulanceBL>();

        public Manage_Ambulance()
        {
            InitializeComponent();
            LoadGrid();
        }

        public static LinkedList<AmbulanceBL> LoadActiveAmbulances()
        {
            ambulances.Clear();

            string query = "SELECT * FROM ambulances WHERE is_active = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                AmbulanceBL amb = new AmbulanceBL(
                    Convert.ToInt32(row["ambulance_id"]),
                    Convert.ToInt32(row["station_id"]),
                    row["plate_number"].ToString(),
                    row["equipment"] == DBNull.Value ? "" : row["equipment"].ToString(),
                    row["status"].ToString(),
                    row["current_latitude"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["current_latitude"]),
                    row["current_longitude"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["current_longitude"])
                );

                ambulances.AddLast(amb);
            }

            return ambulances;
        }

        private void LoadGrid()
        {
            ambulancesGrid.Rows.Clear();
            ambulancesGrid.Columns.Clear();

            ambulancesGrid.Columns.Add("ambulance_id", "Ambulance ID");
            ambulancesGrid.Columns.Add("station_id", "Station ID");
            ambulancesGrid.Columns.Add("plate_number", "Plate Number");
            ambulancesGrid.Columns.Add("equipment", "Equipment");
            ambulancesGrid.Columns.Add("status", "Status");
            ambulancesGrid.Columns.Add("current_latitude", "Latitude");
            ambulancesGrid.Columns.Add("current_longitude", "Longitude");

            foreach (var amb in LoadActiveAmbulances())
            {
                ambulancesGrid.Rows.Add(
                    amb.ambulance_id,
                    amb.station_id,
                    amb.plate_number,
                    amb.equipment,
                    amb.status,
                    amb.current_latitude,
                    amb.current_longitude
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int stationId;
                if (!int.TryParse(txtstation.Text.Trim(), out stationId))
                {
                    MessageBox.Show("Station ID must be a number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string plateNumber = txtplateno.Text.Trim();
                string equipment = txtequipment.Text.Trim();
                string status = cmbstatus.SelectedItem?.ToString() ?? "Available";

                double latitude;
                if (!double.TryParse(txtLatitude.Text.Trim(), out latitude))
                {
                    MessageBox.Show("Latitude must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double longitude;
                if (!double.TryParse(txtLongitude.Text.Trim(), out longitude))
                {
                    MessageBox.Show("Longitude must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AmbulanceBL ambulance = new AmbulanceBL
                {
                    station_id = stationId,
                    plate_number = plateNumber,
                    equipment = equipment,
                    status = status,
                    current_latitude = latitude,
                    current_longitude = longitude
                };

                if (!ambulance.IsValid())
                {
                    MessageBox.Show("Plate number and status are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AmbulanceDL.AddAmbulance(ambulance);

                MessageBox.Show("Ambulance added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGrid();

                txtstation.Clear();
                txtplateno.Clear();
                txtequipment.Clear();
                txtLatitude.Clear();
                txtLongitude.Clear();
                cmbstatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding ambulance: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Manage_Ambulance_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        public void RefreshAmbulanceGrid()
        {
            LoadGrid(); // ✅ reload grid with active ambulances only
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Ambulance updateForm = new Update_Ambulance();
            updateForm.OnAmbulanceChanged += (s, args) => RefreshAmbulanceGrid();
            updateForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Ambulance deleteForm = new Delete_Ambulance();
            deleteForm.OnAmbulanceChanged += (s, args) => RefreshAmbulanceGrid();
            deleteForm.ShowDialog();
        }

        private void Manage_Ambulance_Load_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }
    }
}
