using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.UI;

namespace Emergency_Response_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string Password = txtPassword.Text;
            string selectedRole = txtRole.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(selectedRole))
            {
                MessageBox.Show("Please enter name, password, and select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(Password);
            // Authenticate user from DB
            UserBL user = UserDL.AuthenticateUser(name, hashedPassword, selectedRole);

            if (user != null)
            {
                MessageBox.Show($"{user.role} login successful!");

                if (user.role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var form = new Admin_Dashboard();
                    form.ShowDialog();
                }
                else if (user.role.Equals("Operator", StringComparison.OrdinalIgnoreCase))
                {
                    var form = new OperatorDashboard();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Role not recognized. Please contact system administrator.",
                                    "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials or role. Please try again.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // convert to hex
                }
                return builder.ToString();
            }
        }
    }
}
