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

namespace Emergency_Response_System.UI
{
    public partial class AmbulancesInStation : Form
    {
        public AmbulancesInStation()
        {
            InitializeComponent();
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
    }
}
