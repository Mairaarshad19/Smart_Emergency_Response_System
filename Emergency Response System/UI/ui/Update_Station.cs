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
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class Update_Station : Form
    {
        public Update_Station()
        {
            InitializeComponent();
        }
        public event EventHandler StationUpdated;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int stationId = Convert.ToInt32(txtStationId.Text.Trim());
                string name = txtname.Text.Trim();
                decimal latitude = Convert.ToDecimal(txtlat.Text.Trim());
                decimal longitude = Convert.ToDecimal(txtlong.Text.Trim());

                StationBL updatedStation = new StationBL(stationId, name, latitude, longitude, DateTime.Now);

                StationDL.UpdateStation(updatedStation);

                StationManager.LoadStations();

                // Raise event to notify Form A
                StationUpdated?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Station updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating station: " + ex.Message);
            }
        }

        private void Update_Station_Load(object sender, EventArgs e)
        {

        }
    }
}
