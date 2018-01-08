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
        public String RecordNo { get; set; }

        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }
        

        public FrmAddStudentRecord(string recordNo, string studentNumber)
        {
            InitializeComponent();
            this.Text = "EDIT-STUDENT";
            this.RecordNo = recordNo;
            btnEnrollAndSave.Text = "Save";
            btnBrowseStudent.Visible = false;

            txtStudentNumber.Text = studentNumber;
            txtStudentNumber.Enabled = false;
            txtStudentName.Enabled = false;
            cmbGender.Enabled = false;
            dtPickerDateOfBirth.Enabled = false;

            SetStudentRecordInformation(recordNo);
            ViewSubjects();
        }

        public FrmAddStudentRecord()
        {
            InitializeComponent();
            btnEnrollAndSave.Text = "Save";
        }

        private void FrmAddStudentRecord_Load(object sender, EventArgs e)
        {
            PutGradeLevelDescriptionToComboBox();
            cmbGradeLevel.Text = cmbGradeLevel.Items[0].ToString();
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
                txtStudentName.Text = string.Format("{0} {1}, {2}", sqlReader[1].ToString(), sqlReader[2].ToString(), 
                    sqlReader[3].ToString());
                cmbGender.Text = sqlReader[4].ToString();
                dtPickerDateOfBirth.Value = Convert.ToDateTime(sqlReader[5].ToString());
                studentImage.ImageLocation = Application.StartupPath + sqlReader[6].ToString();
                lblGradeLevelID.Text = sqlReader[7].ToString();
                lblTuitionFee.Text = sqlReader[8].ToString();
                cmbStatus.Text = sqlReader[9].ToString();
            }
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT GradeLevelID FROM GradeLevel WHERE Description = '" + cmbGradeLevel.Text + "'";

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            lblGradeLevelID.Text = Sqlcomm.ExecuteScalar().ToString();
            Sqlconn.Close();
        }

        private void ViewSubjects()
        {
            string query = "SELECT SubjectCode, Subject.Description, TimeFrom, TimeTo FROM Subject " +
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
    }
}
