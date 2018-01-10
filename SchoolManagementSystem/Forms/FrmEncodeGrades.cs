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
using System.Diagnostics;
using System.Configuration;

namespace SchoolManagementSystem.Forms
{
    public partial class FrmEncodeGrades : Form
    {
        private SqlConnection Sqlconn;
        private SqlCommand Sqlcomm;


        public FrmEncodeGrades()
        {
            InitializeComponent();
            PopulateComboBoxWithGradeLevel();
        }

        private void FrmEncodeGrades_Load(object sender, EventArgs e)
        {
            txtStudentNumber.Enabled = false;
            btnBrowse.Enabled = false;
        }

        private void PopulateComboBoxWithGradeLevel()
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand("SELECT Description FROM GradeLevel", Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                cmbGradeLevel.Items.Add(sqlReader[0].ToString());
            }

            sqlReader.Close();
            Sqlconn.Close();
        }

        private void PopulateComboBoxWithSubject()
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand("SELECT Description FROM Subject WHERE GradeLevelID = '"+lblGradeLevelID.Text+"'", Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                cmbSubject.Items.Add(sqlReader[0].ToString());
            }

            sqlReader.Close();
            Sqlconn.Close();
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSubject.Items.Clear();
            cmbSubject.Text = "";
            lblSubjectCode.Text = "SUBJECTCODE";

            string query = "SELECT GradeLevelID FROM GradeLevel WHERE Description = '" + cmbGradeLevel.Text + "'";

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            lblGradeLevelID.Text = Sqlcomm.ExecuteScalar().ToString();
            Sqlconn.Close();

            PopulateComboBoxWithSubject();
        }

        private void rbtnPerStudent_CheckedChanged(object sender, EventArgs e)
        {
            txtStudentNumber.Enabled = true;
            btnBrowse.Enabled = true;
            cmbSubject.Enabled = false;
        }

        private void rbntPerGradeLevel_CheckedChanged(object sender, EventArgs e)
        {
            txtStudentNumber.Enabled = false;
            btnBrowse.Enabled = false;
            cmbSubject.Enabled = true;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string query = "";

            if (rbtnPerGradeLevel.Checked)
            {
                query = string.Format("SELECT StudentRecord.RecordNo, StudentRecord.StudentNo, (LastName + ', ' + FirstName + ' ' + MiddleName) AS Name, " +
                    "CASE WHEN FirstQuarter <> 0 THEN FirstQuarter ELSE NULL END AS [1st Quarter], " +
                    "CASE WHEN SecondQuarter <> 0 THEN SecondQuarter ELSE NULL END AS [2nd Quarter], " +
                    "CASE WHEN ThirdQuarter <> 0 THEN ThirdQuarter ELSE NULL END AS [3rd Quarter], " +
                    "CASE WHEN FourthQuarter <> 0 THEN FourthQuarter ELSE NULL END AS [4th Quarter] FROM StudentRecord " +
                    "INNER JOIN StudentPersonalInfo ON StudentRecord.StudentNo = StudentPersonalInfo.StudentNo " +
                    "INNER JOIN GradeLevel ON GradeLevel.GradeLevelID = StudentRecord.GradeLevelID " +
                    "INNER JOIN Subject ON Subject.GradeLevelID = GradeLevel.GradeLevelID " +
                    "LEFT JOIN StudentGrade ON StudentGrade.StudentRecordNo = StudentRecord.RecordNo " +
                    "AND StudentGrade.SubjectCode = Subject.SubjectCode " +
                    "WHERE Subject.SubjectCode = '{0}' And Subject.Active = 1 AND StudentRecord.SchoolYear = {1} " +
                    "ORDER BY LastName", 
                    lblSubjectCode.Text, Convert.ToInt16(GlobalVariable.SchoolYear));

                ViewToDataGrid(query);
                dataGridView1.Columns[0].Visible = false; //RecordNo
                dataGridView1.Columns[1].Visible = false; //StudentNo
            }
            else if (rbtnPerStudent.Checked)
            {
                query = string.Format("SELECT StudentRecord.RecordNo, Subject.SubjectCode, Subject.Description, " +
                    "FirstQuarter AS [1st Quarter], SecondQuarter AS [2nd Quarter], " +
                    "ThirdQuarter AS [3rd Quarter], FourthQuarter AS [4th Quarter] FROM StudentRecord " +
                    "INNER JOIN StudentPersonalInfo ON StudentRecord.StudentNo = StudentPersonalInfo.StudentNo " +
                    "INNER JOIN GradeLevel ON GradeLevel.GradeLevelID = StudentRecord.GradeLevelID " +
                    "INNER JOIN Subject ON Subject.GradeLevelID = GradeLevel.GradeLevelID " +
                    "LEFT JOIN StudentGrade ON StudentGrade.StudentRecordNo = StudentRecord.RecordNo " +
                    "AND StudentGrade.SubjectCode = Subject.SubjectCode " +
                    "WHERE StudentRecord.StudentNo = {0} And Subject.Active = 1 AND StudentRecord.SchoolYear = {1}",
                    txtStudentNumber.Text, Convert.ToInt16(GlobalVariable.SchoolYear));

                ViewToDataGrid(query);
                dataGridView1.Columns[0].Visible = false; //RecordNo
                dataGridView1.Columns[1].Visible = false; //SubjectCode

            }
        }

        private void ViewToDataGrid(string query)
        {
            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            Sqlconn.Close();
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbSubject.Items.Clear();

            string query = "SELECT SubjectCode FROM Subject WHERE Description = '" + cmbSubject.Text + "'";

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            lblSubjectCode.Text = Sqlcomm.ExecuteScalar().ToString();
            Sqlconn.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT SR.StudentNo, (LastName + ',' + FirstName + ' ' + MiddleName) AS Name, * " +
                "FROM StudentRecord AS SR INNER JOIN StudentPersonalInfo AS SP " +
                "ON SP.StudentNo = SR.StudentNo WHERE GradeLevelID = {0} AND SchoolYear = {1}",
                lblGradeLevelID.Text, GlobalVariable.SchoolYear);

            FrmBrowse frmBrowse = new FrmBrowse(query);
            DialogResult dr = frmBrowse.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtStudentNumber.Text = frmBrowse.ReturnValueFirstColumn;
                lblStudentName.Text = frmBrowse.ReturnValueSecondColumn;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbtnPerGradeLevel.Checked)
            {
                SaveGradePerGradeLevel();
            }

            else if (rbtnPerStudent.Checked)
            {
                SaveGradePerStudent();
            }
        }

        private void SaveGradePerGradeLevel()
        {
            string recordNo;
            string studentNo;

            double firstQuarter;
            double secondQuarter;
            double thirdQuarter;
            double fourthQuarter;
            string query;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                recordNo = dataGridView1.Rows[x].Cells[0].Value.ToString();
                studentNo = dataGridView1.Rows[x].Cells[1].Value.ToString();

                firstQuarter = dataGridView1.Rows[x].Cells[3].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value) : 0;
                secondQuarter = dataGridView1.Rows[x].Cells[4].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value) : 0;
                thirdQuarter = dataGridView1.Rows[x].Cells[5].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value) : 0;
                fourthQuarter = dataGridView1.Rows[x].Cells[6].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[6].Value) : 0;

                query = string.Format("INSERT INTO StudentGrade VALUES ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7})",
                    recordNo, studentNo, lblSubjectCode.Text, cmbSubject.Text, firstQuarter, secondQuarter, thirdQuarter, fourthQuarter);

                UpdateDatabase(query);
            }
        }

        private void SaveGradePerStudent()
        {
            string recordNo;
            string subjectCode;
            string subjectDescription;

            double firstQuarter;
            double secondQuarter;
            double thirdQuarter;
            double fourthQuarter;
            string query;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                recordNo = dataGridView1.Rows[x].Cells[0].Value.ToString();
                subjectCode = dataGridView1.Rows[x].Cells[1].Value.ToString();
                subjectDescription = dataGridView1.Rows[x].Cells[2].Value.ToString();

                firstQuarter = dataGridView1.Rows[x].Cells[3].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value) : 0;
                secondQuarter = dataGridView1.Rows[x].Cells[4].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value) : 0;
                thirdQuarter = dataGridView1.Rows[x].Cells[5].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value) : 0;
                fourthQuarter = dataGridView1.Rows[x].Cells[6].Value.ToString() != "" ?
                    Convert.ToDouble(dataGridView1.Rows[x].Cells[6].Value) : 0;

                query = string.Format("INSERT INTO StudentGrade VALUES ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7})",
                    recordNo, txtStudentNumber.Text, subjectCode, cmbSubject.Text, firstQuarter, secondQuarter, thirdQuarter, fourthQuarter);

                UpdateDatabase(query);
            }
        }

        private void UpdateDatabase(string query)
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            Sqlcomm.ExecuteNonQuery();
            Sqlconn.Close();
        }
    }
}
