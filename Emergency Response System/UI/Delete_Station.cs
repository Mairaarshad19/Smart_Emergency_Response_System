using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.DL;
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class Delete_Station : Form
    {
        public Delete_Station()
        {
            InitializeComponent();
        }
        public event EventHandler StationDeleted;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int stationId = Convert.ToInt32(txtStationId.Text.Trim());

                StationDL.DeleteStation(stationId);

                StationDL.GetDistinctStationNames();

                StationDeleted?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Station deleted successfully!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting station: " + ex.Message);

            }
        }

        private void txtStationId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
             form.ShowDialog();
        }

        private void Delete_Station_Load(object sender, EventArgs e)
        {

        }
    }
}
