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

namespace Emergency_Response_System.UI
{
    public partial class ManagingStation : Form
    {
        public ManagingStation()
        {
            InitializeComponent();
            StationDL.GetAllStations();

            LoadStationsGrid();
        }
        public event EventHandler StationUpdated;
        private void ManagingStation_Load(object sender, EventArgs e)
        {

        }

        private void LoadStationsGrid()
        {
            var stationList = new List<StationBL>(StationManager.Stations);

            gridStations.AutoGenerateColumns = true;
            gridStations.DataSource = null;
            gridStations.DataSource = stationList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname.Text.Trim();
                decimal latitude = Convert.ToDecimal(txtlat.Text.Trim());
                decimal longitude = Convert.ToDecimal(txtlong.Text.Trim());

                StationBL newStation = new StationBL(0, name, latitude, longitude, DateTime.Now);

                StationDL.AddStation(newStation);

                StationDL.GetAllStations();

                LoadStationsGrid();
                StationUpdated?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Station added successfully!");
                txtname.Clear();
                txtlat.Clear();
                txtlong.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding station: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            StationManager.LoadStations();
            HashTable<int, StationBL> stationTable = new HashTable<int, StationBL>(20);

            foreach (var station in StationManager.Stations)
            {
                stationTable.Insert(station.station_id, station);
            }

            if (int.TryParse(search_by_id.Text.Trim(), out int searchedId))
            {
                StationBL foundStation = stationTable.Search(searchedId);

                if (foundStation != null)
                {
                    MessageBox.Show($"Found station: {foundStation.station_id}");
                }
                else
                {
                    MessageBox.Show("Station not found!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Station updateForm = new Update_Station();

            updateForm.StationUpdated += UpdateForm_StationUpdated;

            updateForm.ShowDialog();
        }
        private void UpdateForm_StationUpdated(object sender, EventArgs e)
        {
            StationManager.LoadStations();   // reload from DB
            LoadStationsGrid();              // refresh grid
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Station deleteForm = new Delete_Station();

            deleteForm.StationDeleted += UpdateForm_StationUpdated;

            deleteForm.ShowDialog();
        }

        private void noofamb_Click(object sender, EventArgs e)
        {

            var counts = StationDL.GetAmbulanceCountPerStation();

            gridCount.Rows.Clear();
            gridCount.Columns.Clear();

            gridCount.Columns.Add("station_id", "Station ID");
            gridCount.Columns.Add("name", "Station Name");
            gridCount.Columns.Add("ambulance_count", "Ambulance Count");

            foreach (var (stationId, name, count) in counts)
            {
                gridCount.Rows.Add(stationId, name, count);
            }
        }

        private void search_by_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCoverage_Click(object sender, EventArgs e)
        {
 
        }
    }
}
