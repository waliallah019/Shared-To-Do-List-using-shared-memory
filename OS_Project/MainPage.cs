using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class MainPage : Form
    {
        public static string UserName = "";
        Dashboard dashboard = new Dashboard();
        public MainPage()
        {
            InitializeComponent();
            dashboard.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            string Username = username.Text.Trim();
            string Password = password.Text.Trim();
            UserName = Username;
            if (ValidateCredentials(Username, Password, out string firstName, out string lastName))
            {
                MessageBox.Show($"Signed in as: {firstName} {lastName}");
                this.Hide();
            
                dashboard.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool ValidateCredentials(string username, string password, out string firstName, out string lastName)
        {
            firstName = string.Empty;
            lastName = string.Empty;

            string filePath = "accounts.txt";

            if (!File.Exists(filePath))
            {
                return false;
            }

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 5 && parts[3] == username && parts[4] == password)
                {
                    firstName = parts[0];
                    lastName = parts[1];
                    return true;
                }
            }

            return false;
        }
    }
}

