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

namespace SchoolManagementSystem.Forms
{
    public partial class FrmAddStudentRecord : Form
    {
        private int RecordNo { get; set; }
        private double TuitionFee { get; set; } = 0;
        private double EntranceFee { get; set; } = 0;
        private double TotalBalance { get; set; } = 0;

        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }
        
        //For updating records
        public FrmAddStudentRecord(int recordNo, string studentNumber)
        {
            InitializeComponent();
            this.Text = "EDIT-STUDENT";
            this.RecordNo = recordNo;
            btnEnrollAndSave.Text = "Save";
            txtStudentNumber.Text = studentNumber;

            btnBrowseStudent.Enabled = false;

            SetStudentRecordInformation(recordNo);
            SetEntranceFee();
            SetTuitionFee();
            ViewSubjects();

        }

        //For adding new records
        public FrmAddStudentRecord()
        {
            InitializeComponent();
            this.Text = "ENROLL-STUDENT";
            btnEnrollAndSave.Text = "Enroll";

            lblStatus.Visible = false;
            cmbStatus.Visible = false;
        }

        private void FrmAddStudentRecord_Load(object sender, EventArgs e)
        {
            lblSchoolYear.Text = GlobalVariable.SchoolYear;
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

        private void SetStudentRecordInformation(int recordNo)
        {
            string query = "SELECT SP.StudentNo, SP.FirstName, SP.LastName, SP.MiddleName," +
                "SP.Gender, SP.DateOfBirth, SP.ImagePath, SR.GradeLevelID, SR.Status, SR.StudentType " +
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
                cmbStatus.Text = sqlReader[8].ToString();
                cmbStudentType.Text = sqlReader[9].ToString();
            }
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTuitionFee();
            ViewSubjects();
        }

        private void SetTuitionFee()
        {
            string query;

            query = "SELECT GradeLevelID FROM GradeLevel WHERE Description = '" + cmbGradeLevel.Text + "'";
            lblGradeLevelID.Text = GetOneData(query);

            query = "SELECT TuitionFee FROM GradeLevel WHERE GradeLevelID = '" + lblGradeLevelID.Text + "'";
            TuitionFee = double.Parse(GetOneData(query));
            this.TotalBalance = this.TuitionFee + this.EntranceFee;
            lblTotalBalance.Text = TotalBalance.ToString();
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
            //Select students with no records in current year.
            string query = "SELECT * FROM StudentPersonalInfo SP " +
                "WHERE NOT EXISTS (SELECT StudentNo FROM StudentRecord SR WHERE SchoolYear = "+GlobalVariable.SchoolYear+" " +
                "AND SP.StudentNo = SR.StudentNo)";

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
            List<string> queries = new List<string>();

            if (this.Text.Contains("ENROLL"))
            {
                EnrollStudent();
            }

            else if (this.Text.Contains("EDIT"))
            {
                EditStudentRecord();
            }
        }

        private void EditStudentRecord()
        {
            SqlTransaction SqlTrans = null;
            try
            {
                Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
                Sqlconn.Open();
                SqlTrans = Sqlconn.BeginTransaction();

                Sqlcomm = new SqlCommand();
                Sqlcomm.Connection = Sqlconn;
                Sqlcomm.Transaction = SqlTrans;

                string updateStudentRecord = string.Format("UPDATE StudentRecord SET GradeLevelID = {0}, Status = '{1}', " +
                        "StudentType = '{2}' WHERE RecordNo = {3} ",
                       lblGradeLevelID.Text, cmbStatus.Text, cmbStudentType.Text, this.RecordNo);
                Sqlcomm.CommandText = updateStudentRecord;
                Sqlcomm.ExecuteNonQuery();

                if (cmbStatus.Text == "ENROLLED")
                {
                    string updateBalanceTuitionFee = string.Format("UPDATE Balance SET Balance = {0} " +
                            "WHERE StudentRecordNo = {1} AND Description = 'TUITION FEE' ",
                            this.TuitionFee, this.RecordNo);
                    Sqlcomm.CommandText = updateBalanceTuitionFee;
                    Sqlcomm.ExecuteNonQuery();

                    //If student is set to old, we have to delete the entrance fee.
                    if (this.EntranceFee == 0)
                    {
                        string deleteBalanceEntranceFee = "DELETE FROM Balance WHERE StudentRecordNo = " + this.RecordNo + " " +
                            "AND Description = 'ENTRANCE FEE' ";
                        Sqlcomm.CommandText = deleteBalanceEntranceFee;
                        Sqlcomm.ExecuteNonQuery();
                    }

                    //If student is set to new, we have to add entrance fee.
                    else
                    {
                        string query = "SELECT COUNT(1) FROM Balance WHERE StudentRecordNo = "+this.RecordNo+" AND " +
                            "Description = 'ENTRANCE FEE'";

                        if (CheckIfOldEntranceFeeExists(query) == false)
                        {
                            string inserStudentEntranceFee = string.Format("INSERT INTO Balance VALUES ({0}, '{1}', {2}, '{3}', NULL, NULL, NULL)",
                                this.RecordNo, "ENTRANCE FEE", EntranceFee, DateTime.Now.ToShortDateString());
                            Sqlcomm.CommandText = inserStudentEntranceFee;
                            Sqlcomm.ExecuteNonQuery();
                        }
                    }
                }
                
                SqlTrans.Commit();
            }

            catch (SqlException ex)
            {
                //Insert Error Log Here
                MessageBox.Show(ex.Message);
                SqlTrans.Rollback();
            }
        }

        private bool CheckIfOldEntranceFeeExists(string query)
        {
            //Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            //Sqlconn.Open();

            Sqlcomm.CommandText = query;
            int count = Convert.ToInt16(Sqlcomm.ExecuteScalar());
            //Sqlconn.Close();

            if (count == 0)
            {
                return false;
            }

            return true;
        }

        private void EnrollStudent()
        {
            SqlTransaction SqlTrans = null;
            try
            {
                Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
                Sqlconn.Open();
                SqlTrans = Sqlconn.BeginTransaction();

                Sqlcomm = new SqlCommand();
                Sqlcomm.Connection = Sqlconn;
                Sqlcomm.Transaction = SqlTrans;

                //Save the studentrecord first, it will create a RecordNo; RecordNo column is auto-increment.
                string insertStudentRecord = string.Format("INSERT INTO StudentRecord VALUES('{0}', {1}, '{2}', '{3}', {4})",
                       txtStudentNumber.Text, lblGradeLevelID.Text, "ENROLLED", cmbStudentType.Text, GlobalVariable.SchoolYear);
                Sqlcomm.CommandText = insertStudentRecord;
                Sqlcomm.ExecuteNonQuery();

                //Get the recordNo of the statement above.
                string getStudentRecordNo = string.Format("SELECT RecordNo FROM StudentRecord WHERE StudentNo = '{0}' AND " +
                        "SchoolYear = {1}", txtStudentNumber.Text, GlobalVariable.SchoolYear);
                Sqlcomm.CommandText = getStudentRecordNo;
                this.RecordNo = Convert.ToInt32(Sqlcomm.ExecuteScalar());

                //Use the recordNo variable, and insert student balance with Tuition Fee
                string insertStudentBalance = string.Format("INSERT INTO Balance VALUES ({0}, '{1}', {2}, '{3}', NULL, NULL, NULL)",
                        this.RecordNo, "TUITION FEE", TuitionFee, DateTime.Now.ToShortDateString());
                Sqlcomm.CommandText = insertStudentBalance;
                Sqlcomm.ExecuteNonQuery();

                if (EntranceFee != 0)
                {
                    //Use the recordNo variable, and insert student balance with Entrance Fee
                    string inserStudentEntranceFee = string.Format("INSERT INTO Balance VALUES ({0}, '{1}', {2}, '{3}', NULL, NULL, NULL)",
                        this.RecordNo, "ENTRANCE FEE", EntranceFee, DateTime.Now.ToShortDateString());
                    Sqlcomm.CommandText = inserStudentEntranceFee;
                    Sqlcomm.ExecuteNonQuery();
                }
                
                SqlTrans.Commit();

                ViewPaymentForm();
            }

            catch (SqlException ex)
            {
                //Insert Error Log Here
                MessageBox.Show(ex.Message);
                SqlTrans.Rollback();
            }
        }

        private void ViewPaymentForm()
        {
            DialogResult dr = MessageBox.Show("Student has been successfully enrolled. Would you like to add payment for student balance?", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                FrmPayment frmPayment = new FrmPayment(this.RecordNo);
                frmPayment.ShowDialog(this);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStudentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEntranceFee();
        }

        private void SetEntranceFee()
        {
            EntranceFee = cmbStudentType.Text == "NEW STUDENT" || cmbStudentType.Text == "TRANSFEREE" ? 1000.00 : 0.00;
            this.TotalBalance = this.TuitionFee + this.EntranceFee;
            lblTotalBalance.Text = TotalBalance.ToString();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewPaymentForm();
        }
    }
}
