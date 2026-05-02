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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = SeriesChartType.Doughnut;
            chart1.Series[0].Points.AddXY("High Severity", 26.6);
            chart1.Series[0].Points.AddXY("Others", 73.4);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void emergenciesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ambulancesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
