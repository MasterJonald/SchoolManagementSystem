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

namespace SchoolManagementSystem.Forms
{
    public partial class FrmAddStudentRecord : Form
    {
        private String RecordNo { get; set; }

        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }
        
        //For updating records
        public FrmAddStudentRecord(string recordNo, string studentNumber)
        {
            InitializeComponent();
            this.Text = "EDIT-STUDENT";
            this.RecordNo = recordNo;
            btnEnrollAndSave.Text = "Save";
            txtStudentNumber.Text = studentNumber;

            btnBrowseStudent.Enabled = false;
            txtStudentNumber.Enabled = false;
            txtStudentName.Enabled = false;
            cmbGender.Enabled = false;
            dtPickerDateOfBirth.Enabled = false;

            SetStudentRecordInformation(recordNo);
            ViewSubjects();

        }

        //For adding new records
        public FrmAddStudentRecord()
        {
            InitializeComponent();
            this.Text = "ENROLL-STUDENT";
            btnEnrollAndSave.Text = "Enroll";
        }

        private void FrmAddStudentRecord_Load(object sender, EventArgs e)
        {
            PutGradeLevelDescriptionToComboBox();
        }

        private void PutGradeLevelDescriptionToComboBox()
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand("SELECT Description FROM GradeLevel", Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                cmbGradeLevel.Items.Add(sqlReader[0].ToString());
            }
        }

        private void SetStudentRecordInformation(string recordNo)
        {
            string query = "SELECT SP.StudentNo, SP.FirstName, SP.LastName, SP.MiddleName," +
                "SP.Gender, SP.DateOfBirth, SP.ImagePath, SR.GradeLevelID, GL.TuitionFee, SR.Status " +
                "FROM StudentRecord AS SR INNER JOIN StudentPersonalInfo AS SP ON SR.StudentNo = SP.StudentNo " +
                "INNER JOIN GradeLevel AS GL ON GL.GradeLevelID = SR.GradeLevelID " + 
                "WHERE SR.RecordNo = " + recordNo + "";

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                txtStudentNumber.Text = sqlReader[0].ToString();
                txtStudentName.Text = string.Format("{0} {1} {2}", sqlReader[1].ToString(), sqlReader[2].ToString(), 
                    "," + sqlReader[3].ToString());
                cmbGender.Text = sqlReader[4].ToString();
                dtPickerDateOfBirth.Value = Convert.ToDateTime(sqlReader[5].ToString());
                studentImage.ImageLocation = Application.StartupPath + sqlReader[6].ToString();
                lblGradeLevelID.Text = sqlReader[7].ToString();
                cmbGradeLevel.Text = GetOneData("SELECT Description FROM GradeLevel WHERE GradeLevelID = '"+lblGradeLevelID.Text+"'");
                lblTuitionFee.Text = sqlReader[8].ToString();
                cmbStatus.Text = sqlReader[9].ToString();
            }
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query;

            query   = "SELECT GradeLevelID FROM GradeLevel WHERE Description = '" + cmbGradeLevel.Text + "'";
            lblGradeLevelID.Text = GetOneData(query);

            query = "SELECT TuitionFee FROM GradeLevel WHERE GradeLevelID = '"+lblGradeLevelID.Text+"'";
            lblTuitionFee.Text = GetOneData(query);

            ViewSubjects();
        }

        private String GetOneData(string query)
        {
            string data;

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            data = Sqlcomm.ExecuteScalar().ToString();
            Sqlconn.Close();

            return data;
        }

        private void ViewSubjects()
        {
            string query = "SELECT SubjectCode, Subject.Description, TimeFrom, TimeTo, TeachersName FROM Subject " +
                "INNER JOIN GradeLevel ON GradeLevel.GradeLevelID = Subject.GradeLevelID " +
                "WHERE Subject.GradeLevelID = "+lblGradeLevelID.Text+" AND Active = 1";

            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            Sqlconn.Close();
        }

        private void btnBrowseStudent_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM StudentPersonalInfo";

            FrmBrowse frmBrowse = new FrmBrowse(query);
            DialogResult dr = frmBrowse.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtStudentNumber.Text = frmBrowse.ReturnValueFirstColumn;
            }

            SetStudentPersonalInfo();
        }

        private void SetStudentPersonalInfo()
        {
            string query = "SELECT StudentNo, FirstName, LastName, MiddleName, Gender, DateOfBirth, ImagePath " +
                "FROM StudentPersonalInfo WHERE StudentNo = '"+txtStudentNumber.Text+"'";

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                txtStudentNumber.Text = sqlReader[0].ToString();
                txtStudentName.Text = string.Format("{0} {1} {2}", sqlReader[1].ToString(), "," + sqlReader[2].ToString(),
                    sqlReader[3].ToString());
                cmbGender.Text = sqlReader[4].ToString();
                dtPickerDateOfBirth.Value = Convert.ToDateTime(sqlReader[5].ToString());
                studentImage.ImageLocation = Application.StartupPath + sqlReader[6].ToString();
            }
        }

        private void btnEnrollAndSave_Click(object sender, EventArgs e)
        {
            string query = "";

            if (this.Text.Contains("ENROLL"))
            {
                query = string.Format("INSERT INTO StudentRecord (StudentNo, GradeLevelID, Status, SchoolYear) " +
                    "VALUES('{0}', {1}, '{2}', {3})",
                    txtStudentNumber.Text, lblGradeLevelID.Text, cmbStatus.Text, lblSchoolYear.Text);

                //string updateBalanceQuery = string.Format("INSERT INTO Balance ({0}, '{1}', {2}, {3}, NULL, NULL, NULL)",
                //    RecordNo, "ENROLLMENT", lblTuitionFee.Text, DateTime.Now.ToShortDateString());

                //UpdateDatabase(updateBalanceQuery);
            }

            else if (this.Text.Contains("EDIT"))
            {
                query = string.Format("UPDATE StudentRecord SET GradeLevelID = {0}, Status = {1}",
                    lblGradeLevelID.Text, cmbStatus.Text);
            }

            UpdateDatabase(query);
        }

        private void UpdateDatabase(string query)
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            Sqlcomm.ExecuteNonQuery();

            Sqlconn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewPaymentForm()
        {

        }
    }
}
