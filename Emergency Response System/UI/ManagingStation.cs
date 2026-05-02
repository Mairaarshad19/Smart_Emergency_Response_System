using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class ManagingStation : Form
    {
        private CityGraph cityGraph;

        public ManagingStation()
        {
            InitializeComponent();
            cityGraph = RoadManager.BuildGraph();
            RefreshStationGrid();
            LoadIntersections();
        }

        public event EventHandler StationUpdated;

        private void ManagingStation_Load(object sender, EventArgs e)
        {
        }

        private void RefreshStationGrid()
        {
            gridStations.DataSource = null;
            gridStations.Rows.Clear();

            StationManager.ForEachSorted(station =>
            {
                gridStations.Rows.Add(
                    station.station_id,
                    station.name,
                    station.IntersectionId,
                    station.latitude,
                    station.longitude
                );
            });

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Validation
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    cmbIntersection.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(txtLatitude.Text) ||
                    string.IsNullOrWhiteSpace(txtLongitude.Text) ||
                    string.IsNullOrWhiteSpace(plate_no.Text))
                    {
                        MessageBox.Show("Please enter Name, select Intersection, Latitude, Longitude and  Plate No");
                        return;
                    }

                string name = txtName.Text;
                int intersectionId = Convert.ToInt32(cmbIntersection.SelectedItem);
                double lat = Convert.ToDouble(txtLatitude.Text);
                double lng = Convert.ToDouble(txtLongitude.Text);
                string plateNo = plate_no.Text;
                StationManager.CreateStation(cityGraph, name, intersectionId, lat, lng, plateNo);

                // ✅ Refresh grid
                RefreshStationGrid();

                MessageBox.Show("Station added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding station: " + ex.Message);
            }
        }



        // ✅ Search Station
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtStationId.Text);
                StationBL s = StationManager.GetById(id);

                if (s != null)
                {
                    MessageBox.Show($"Found: {s.name} (Intersection {s.IntersectionId})");

                    foreach (DataGridViewRow row in gridStations.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) == id) // first column = StationId
                        {
                            row.Selected = true;
                            gridStations.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Station not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching station: " + ex.Message);
            }
        }

        private void LoadIntersections()
        {
            try
            {
                // Get all intersections (LinkedList)
                LinkedList<IntersectionBL> intersections = IntersectionDL.GetAllIntersections();

                // Clear existing items
                cmbIntersection.Items.Clear();

                // Add IDs manually
                foreach (var intersection in intersections)
                {
                    cmbIntersection.Items.Add(intersection.Id);
                }

                cmbIntersection.SelectedIndex = -1; // no selection by default
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading intersections: " + ex.Message);
            }
        }


        // ✅ Update Station
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int stationId = Convert.ToInt32(txtStationId.Text);

                StationManager.UpdateStation(stationId, s =>
                {
                    s.name = txtName.Text;

                    // ✅ IntersectionId should come from the combo box, not the station id
                    if (cmbIntersection.SelectedItem != null)
                    {
                        s.IntersectionId = Convert.ToInt32(cmbIntersection.SelectedItem);
                        // or Convert.ToInt32(cmbIntersection.SelectedValue) if you bound with ValueMember
                    }

                    s.latitude = Convert.ToDouble(txtLatitude.Text);
                    s.longitude = Convert.ToDouble(txtLongitude.Text);
                    s.plate_no = plate_no.Text;
                });

                RefreshStationGrid();
                MessageBox.Show("Station updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating station: " + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtStationId.Text);

                bool removed = StationManager.DeleteStation(id);
                if (removed)
                {
                    RefreshStationGrid();
                    MessageBox.Show("Station deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Station not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting station: " + ex.Message);
            }
        }

        // ✅ Show Ambulances per Station
        private void noofamb_Click(object sender, EventArgs e)
        {

        }

        private void gridStations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
