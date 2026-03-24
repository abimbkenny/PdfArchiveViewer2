using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfArchiveViewer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Hardcoded credentials
            string correctUser = "admin";
            string correctPass = "password123";

            if (txtUsername.Text == correctUser && txtPassword.Text == correctPass)
            {
                // If correct, hide this form and show the main viewer
                this.Hide();
                Form1 mainViewer = new Form1();
                mainViewer.ShowDialog(); // Use ShowDialog so the app stays open

                // Close the application once the main viewer is closed
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Access Denied",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
