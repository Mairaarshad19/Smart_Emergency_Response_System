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
        public event Action OnAmbulanceChanged;
        public Delete_Ambulance()
        {
            InitializeComponent();
        }

        private void Delete_Ambulance_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ambulanceId = Convert.ToInt32(txtAmbulanceId.Text.Trim());

                int rowsAffected = AmbulanceDL.DeleteAmbulance(ambulanceId);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Ambulance deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh grid
                    ambulancesGrid.DataSource = null;
                    ambulancesGrid.DataSource = AmbulanceDL.GetAllAmbulances();
                }
                else
                {
                    MessageBox.Show("No ambulance found with that ID.", "Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting ambulance: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
