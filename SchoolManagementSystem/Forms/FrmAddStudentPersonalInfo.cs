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
    public partial class FrmAddStudentPersonalInfo : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        private String SourceImagePath { get; set; }
        private String DestinationImagePath { get; set; }

        SqlConnection sqlconn { get; set; }
        SqlCommand sqlcomm { get; set; }

        public FrmAddStudentPersonalInfo(string studentNumber)
        {
            InitializeComponent();
            this.Text = "EDIT-STUDENT";
            txtStudentNumber.Text = studentNumber;
            this.txtStudentNumber.Enabled = false;
            
            SetStudentInformation(studentNumber);
        }

        public FrmAddStudentPersonalInfo()
        {
            InitializeComponent();
            this.Text = "ADD-NEW-STUDENT";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //CopyFileToNewLocation();
        }

        private void SetStudentInformation(string studentNumber)
        {
            string query = string.Format("SELECT * FROM StudentPersonalInfo WHERE StudentNo = '{0}'",
                studentNumber);
            sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            sqlcomm = new SqlCommand(query, sqlconn);
            SqlDataReader sqlReader = sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                txtStudentNumber.Text = sqlReader[0].ToString();
                txtFirstName.Text = sqlReader[1].ToString();
                txtLastName.Text = sqlReader[2].ToString();
                txtMiddleName.Text = sqlReader[3].ToString();
                txtAddress.Text = sqlReader[4].ToString();
                cmbGender.Text = sqlReader[5].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(sqlReader[6]);
                txtPlaceOfBirth.Text = sqlReader[7].ToString();
                studentImage.ImageLocation = Application.StartupPath +  sqlReader[8].ToString();

                DestinationImagePath = Application.StartupPath + sqlReader[8].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query;

            if (this.Text.Contains("ADD"))
            {
                CopyFileToNewLocation();

                query = string.Format("INSERT INTO StudentPersonalInfo VALUES ('{0}', '{1}', '{2}','{3}', '{4}', '{5}','{6}', '{7}', '{8}')",
                     txtStudentNumber.Text, txtFirstName.Text, txtLastName.Text, txtMiddleName.Text,
                     txtAddress.Text, cmbGender.Text.Trim(), dateTimePicker1.Value, 
                     txtPlaceOfBirth.Text, DestinationImagePath);

                UpdateDatabase(query);
            }

            else if(this.Text.Contains("EDIT"))
            {
                CopyFileToNewLocation();

                query = string.Format("UPDATE StudentPersonalInfo SET FirstName = '{0}', LastName = '{1}'," +
                    "MiddleName = '{2}', Address = '{3}', Gender = '{4}', DateOfBirth = '{5}', PlaceOfBirth = '{6}', " +
                    "ImagePath = '{7}' WHERE StudentNo = '{8}'",
                    txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, txtAddress.Text,
                    cmbGender.Text.Trim(), dateTimePicker1.Value, txtPlaceOfBirth.Text, DestinationImagePath, 
                    txtStudentNumber.Text);
                UpdateDatabase(query);
            }
        }

        private void UpdateDatabase(string query )
        {
            sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            sqlconn.Open();

            sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.ExecuteNonQuery();

            sqlconn.Close();
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
            //string targetPath = ConfigurationManager.AppSettings["ImageDestination"].ToString();
            string targetPath = Application.StartupPath + @"\StudentPhoto";

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
            this.DestinationImagePath = @"\StudentPhoto\" + fileNewName;
        }
    }
}
