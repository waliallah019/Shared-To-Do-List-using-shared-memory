using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void createAccount_Click(object sender, EventArgs e)
        {
            string FirstName = firstName.Text.Trim();
            string LastName = lastName.Text.Trim();
            string PhoneNo = phoneNo.Text.Trim();
            string username = usernameText.Text.Trim();
            string password = passwordText.Text.Trim();

            if (ValidateInputs(FirstName, LastName, PhoneNo, username, password))
            {
                SaveDataToFile(FirstName, LastName, PhoneNo, username, password);
                MessageBox.Show("Account created successfully!");
            }
        }

        private bool ValidateInputs(string firstName, string lastName, string phoneNo, string username, string password)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("First name is required.");
                return false;
            }

            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Last name is required.");
                return false;
            }

            if (string.IsNullOrEmpty(phoneNo) || !Regex.IsMatch(phoneNo, @"^\d+$"))
            {
                MessageBox.Show("Valid phone number is required.");
                return false;
            }

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.");
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.");
                return false;
            }

            return true;
        }

        private void SaveDataToFile(string firstName, string lastName, string phoneNo, string username, string password)
        {
            string data = $"{firstName},{lastName},{phoneNo},{username},{password}";
            string filePath = "accounts.txt";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(data);
            }
        }
  
    private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
