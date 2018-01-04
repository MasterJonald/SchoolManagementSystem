using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

//For Debug.WriteLine
using System.Diagnostics;
using System.IO;

namespace SchoolManagementSystem
{
    public partial class Form1 : Form
    {
        private String SourceImagePath { get; set; }
        private String DestinationImagePath { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CopyFileToNewLocation();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CopyFileToNewLocation();

            string query = string.Format("INSERT INTO StudentPersonalInformation VALUES ('{0}', '{1}', '{2}','{3}', '{4}', '{5}',{6}, '{7}', '{8}', '{9}')",
                txtStudentNumber.Text, txtFirstName.Text, txtLastName.Text, txtMiddleName.Text,
                txtAddress.Text, cmbGender.Text, txtAge.Text, dateTimePicker1.Value, txtPlaceOfBirth.Text, DestinationImagePath);

            using (SqlConnection sqlconn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString))
            {
                using (SqlCommand sqlcomm = new SqlCommand(query, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                }
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                String imgLoc = "";

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png";
                //dlg.Title = "SELECT Employee Picture";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    studentImage.ImageLocation = imgLoc;
                    SourceImagePath = imgLoc;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void CopyFileToNewLocation()
        {
            if (this.SourceImagePath == null || this.SourceImagePath == "")
            {
                return;
            }

            string fileName = Path.GetFileName(this.SourceImagePath);
            string fileNewName = txtStudentNumber.Text + Path.GetExtension(this.SourceImagePath);

            string sourcePath = Path.GetDirectoryName(this.SourceImagePath);
            string targetPath = ConfigurationManager.AppSettings["ImageDestination"].ToString();

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileNewName);


            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
            this.DestinationImagePath = destFile;
        }
    }
}
