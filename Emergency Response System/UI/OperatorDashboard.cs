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

namespace Emergency_Response_System.UI
{
    public partial class OperatorDashboard : Form
    {
        public OperatorDashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            form.ShowDialog();
        }

        private void OperatorDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new EmergencyCall();
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

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new AmbulanceDispatch();
            form.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var form = new FindNearestAmbulance();
            form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var form = new PickFastestAmbulance();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new AmbulanceDispatch();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form = new AmbulanceLocation();
            form.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var form = new FilterEmergencies();
            form.ShowDialog();
        }
    }
}
