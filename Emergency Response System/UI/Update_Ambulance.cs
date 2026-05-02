using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.UI
{
    public partial class Update_Ambulance : Form
    {
        public Update_Ambulance()
        {
            InitializeComponent();
            LoadGrid(); // show data immediately
        }

        public event EventHandler OnAmbulanceChanged;
        public static LinkedList<AmbulanceBL> ambulances = new LinkedList<AmbulanceBL>();

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
                int ambulanceId = Convert.ToInt32(txtAmbid.Text.Trim());
                int stationId = Convert.ToInt32(txtstationid.Text.Trim());
                string plateNo = txtplateno.Text.Trim();
                string equipment = txtEquipment.Text.Trim();
                string status = cmbstatus.SelectedItem?.ToString() ?? "Available";

                double latitude = Convert.ToDouble(txtLatitude.Text.Trim());
                double longitude = Convert.ToDouble(txtLongitude.Text.Trim());

                AmbulanceBL ambulance = new AmbulanceBL
                {
                    ambulance_id = ambulanceId,
                    station_id = stationId,
                    plate_number = plateNo,
                    equipment = equipment,
                    status = status,
                    current_latitude = latitude,
                    current_longitude = longitude
                };

                if (!ambulance.IsValid())
                {
                    MessageBox.Show("Plate number and status are required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AmbulanceDL.UpdateAmbulance(ambulance);

                MessageBox.Show("Ambulance updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Notify parent form to refresh
                OnAmbulanceChanged?.Invoke(this, EventArgs.Empty);

                this.Close(); // close after update
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating ambulance: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Ambulance_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
