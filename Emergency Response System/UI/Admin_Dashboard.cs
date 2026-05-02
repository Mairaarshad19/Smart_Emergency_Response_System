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
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new EmergencyCall();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Manage_Ambulance();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new ManagingStation();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new AmbulanceDispatch();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new AmbulanceLocation();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var form = new EmergencyLocation();
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var form = new FindAmbulanciesAtLocation();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var form = new FindCoverage();
            form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //var form = new MainForm();
            //form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var form = new FilterEmergencies();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var form = new PickFastestAmbulance();
            form.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var form = new FindNearestAmbulance();
            form.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new LoginForm();
            form.ShowDialog();
        }
    }
}
