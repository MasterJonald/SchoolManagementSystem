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

namespace SchoolManagementSystem
{
    public partial class FrmAddSubject : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }
        
        public FrmAddSubject(string subjectCode)
        {
            InitializeComponent();

            txtSubjectCode.Enabled = false;
            this.Text = "EDIT-SUBJECT";
            SetSubjectInformation(subjectCode);

            PopulateComboBoxWithGradeLevel();
            SetGradeLevelDescription();
        }

        public FrmAddSubject()
        {
            InitializeComponent();
            this.Text = "ADD-SUBJECT";

            PopulateComboBoxWithGradeLevel();
            cmbGradeLevel.Text = cmbGradeLevel.Items[0].ToString();
        }

        private void FrmAddSubject_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query;
            bool active = chkActive.Checked == true ? true : false;
            
            if (this.Text.Contains("ADD"))
            {
                query = string.Format("INSERT INTO Subject VALUES('{0}', '{1}', {2}, '{3}', '{4}', '{5}', '{6}')",
                        txtSubjectCode.Text, txtDescription.Text, lblGradeLevelID.Text, dtTimeFrom.Value,
                        dtTimeTo.Value, txtTeachersName.Text, active);
                UpdateDatabase(query);
                return;
            }

            else if (this.Text.Contains("EDIT"))
            {
                query = string.Format("UPDATE Subject SET Description = '{0}', GradeLevelID = {1}, TimeFrom = '{2}', " +
                        "TimeTo = '{3}', TeachersName = '{4}', Active = '{5}' WHERE SubjectCode = '{6}'", 
                        txtDescription.Text, lblGradeLevelID.Text, dtTimeFrom.Value.ToShortTimeString(), 
                        dtTimeTo.Value.ToShortTimeString(), txtTeachersName.Text, active, txtSubjectCode.Text);
                UpdateDatabase(query);
            }
          }

        private void UpdateDatabase(string query)
        {
            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            Sqlcomm.ExecuteNonQuery();
            Sqlconn.Close();
        }

        private void SetSubjectInformation(string subjectCode)
        {
            string query = string.Format("SELECT * FROM Subject WHERE SubjectCode = '{0}'", subjectCode);
            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                txtSubjectCode.Text = sqlReader[0].ToString();
                txtDescription.Text = sqlReader[1].ToString();
                lblGradeLevelID.Text = sqlReader[2].ToString();
                dtTimeFrom.Value = Convert.ToDateTime(sqlReader[3].ToString());
                dtTimeTo.Value = Convert.ToDateTime(sqlReader[4].ToString());
                txtTeachersName.Text = sqlReader[5].ToString();
                chkActive.Checked = sqlReader[6].ToString() == "True" ? true : false;
            }

            sqlReader.Close();
            Sqlconn.Close();
        }

        private void PopulateComboBoxWithGradeLevel()
        {
            Sqlconn = new SqlConnection(connectionString);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT GradeLevelID FROM GradeLevel WHERE Description = '"+cmbGradeLevel.Text+"'";
            
            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            lblGradeLevelID.Text = Sqlcomm.ExecuteScalar().ToString();
            Sqlconn.Close();
        }

        private void SetGradeLevelDescription()
        {
            string query = "SELECT Description FROM GradeLevel WHERE GradeLevelID = '" + lblGradeLevelID.Text + "'";

            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            cmbGradeLevel.Text = Sqlcomm.ExecuteScalar().ToString();
            Sqlconn.Close();
        }
    }
}
