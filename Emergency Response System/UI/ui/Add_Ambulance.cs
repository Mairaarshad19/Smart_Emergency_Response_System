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
using Emergency_Response_System.UI;

namespace Emergency_Response_System.UI
{
    public partial class Add_Ambulance : Form
    {
        public Add_Ambulance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect values from form controls
                int stationId = Convert.ToInt32(txtstation.Text.Trim());
                string plateNumber = txtplateno.Text.Trim();
                string equipment = txtequipment.Text.Trim();
                string status = cmbstatus.SelectedItem?.ToString() ?? "Available";

                // Create AmbulanceBL object
                AmbulanceBL ambulance = new AmbulanceBL
                {
                    station_id = stationId,
                    plate_number = plateNumber,
                    equipment = equipment,
                    status = status
                };

                // Validate before saving
                if (string.IsNullOrEmpty(plateNumber))
                {
                    MessageBox.Show("Plate number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save to database
                AmbulanceDL.AddAmbulance(ambulance);

                MessageBox.Show("Ambulance added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshAmbulanceGrid();
                // Optionally clear form after insert
                txtstation.Clear();
                txtplateno.Clear();
                txtequipment.Clear();
                cmbstatus.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding ambulance: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Add_Ambulance_Load(object sender, EventArgs e)
        {

        }

        private void ambulancesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void RefreshAmbulanceGrid()
        {
            ambulancesGrid.DataSource = null; // clear old binding
            ambulancesGrid.DataSource = AmbulanceDL.GetAllAmbulances(); // reload from DB
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Ambulance updateForm = new Update_Ambulance();
            updateForm.OnAmbulanceChanged += RefreshAmbulanceGrid;
            updateForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Ambulance deleteForm = new Delete_Ambulance();
            deleteForm.OnAmbulanceChanged += RefreshAmbulanceGrid;
            deleteForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AmbulanceManager.LoadAmbulances();

            // Create hash table
            HashTable<int, AmbulanceBL> ambulanceTable = new HashTable<int, AmbulanceBL>(20);

            // Insert ambulances from manager
            foreach (var amb in AmbulanceManager.Ambulances)
            {
                ambulanceTable.Insert(amb.ambulance_id, amb);
            }

            // Search by ID from textbox
            if (int.TryParse(search_by_id.Text.Trim(), out int searchedId))
            {
                AmbulanceBL foundAmb = ambulanceTable.Search(searchedId);

                if (foundAmb != null)
                {
                    MessageBox.Show($"Found ambulance: {foundAmb.plate_number}");
                }
                else
                {
                    MessageBox.Show("Ambulance not found!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric ID.");
            }
        }
    }
}
