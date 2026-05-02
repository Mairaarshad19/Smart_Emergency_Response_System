using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.UI
{
    public partial class Delete_Ambulance : Form
    {
        public event EventHandler OnAmbulanceChanged;
        public static LinkedList<AmbulanceBL> ambulances = new LinkedList<AmbulanceBL>();

        public Delete_Ambulance()
        {
            InitializeComponent();
        }

        private void Delete_Ambulance_Load(object sender, EventArgs e)
        {
            // ✅ Load active ambulances into grid when form opens
            LoadGrid();
        }

        // ✅ Load only active ambulances from DB
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

        // ✅ Helper to bind grid manually from LinkedList
        private void LoadGrid()
        {
            ambulancesGrid.Rows.Clear();
            ambulancesGrid.Columns.Clear();

            // Define columns once
            ambulancesGrid.Columns.Add("ambulance_id", "Ambulance ID");
            ambulancesGrid.Columns.Add("station_id", "Station ID");
            ambulancesGrid.Columns.Add("plate_number", "Plate Number");
            ambulancesGrid.Columns.Add("equipment", "Equipment");
            ambulancesGrid.Columns.Add("status", "Status");
            ambulancesGrid.Columns.Add("current_latitude", "Latitude");
            ambulancesGrid.Columns.Add("current_longitude", "Longitude");

            // Add rows from LinkedList
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
                int ambulanceId = Convert.ToInt32(txtAmbulanceId.Text.Trim());

                int rowsAffected = AmbulanceDL.MarkInactive(ambulanceId);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ambulance marked inactive successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ✅ Refresh grid with active ambulances only
                    LoadGrid();

                    // Fire event for parent form if needed
                    OnAmbulanceChanged?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("No ambulance found with that ID.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error marking ambulance inactive: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }
    }
}
