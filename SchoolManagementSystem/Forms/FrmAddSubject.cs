using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Diagnostics;


namespace SchoolManagementSystem
{
    public partial class FrmAddSubject : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
        private string subjectCode { get; set; }

        private SqlConnection sqlconn { get; set; }
        private SqlCommand sqlcomm { get; set; }
        
        public FrmAddSubject(string subjectCode)
        {
            InitializeComponent();

            txtSubjectCode.Enabled = false;
            this.subjectCode = subjectCode;
            this.Text = "EDIT-SUBJECT";
            SetSubjectInformation();
        }

        public FrmAddSubject()
        {
            InitializeComponent();
            this.Text = "ADD-SUBJECT";
        }

        private void FrmAddSubject_Load(object sender, EventArgs e)
        {
            PutGradeLevelDescriptionToComboBox();
            cmbGradeLevel.Text = cmbGradeLevel.Items[0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query;
            bool active = chkActive.Checked == true ? true : false;
            
            if (this.Text.Contains("ADD"))
            {
                query = string.Format("INSERT INTO Subject VALUES('{0}', '{1}', '{2}', '{3}')",
                        txtSubjectCode.Text, txtDescription.Text, cmbGradeLevel.Text, active);
                UpdateDatabase(query);
                return;
            }

            else if (this.Text.Contains("EDIT"))
            {
                query = string.Format("UPDATE Subject SET Description = '{0}', GradeLevel = '{1}', Active = '{2}' " +
                "WHERE SubjectCode = {3}", txtDescription.Text, cmbGradeLevel.Text, active, txtSubjectCode.Text);
                UpdateDatabase(query);
            }
        }

        private void UpdateDatabase(string query)
        {
            sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
        }

        private void SetSubjectInformation()
        {
            string query = string.Format("SELECT * FROM Subject WHERE SubjectCode = '{0}'", this.subjectCode);
            sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            sqlcomm = new SqlCommand(query, sqlconn);
            SqlDataReader sqlReader = sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                txtSubjectCode.Text = sqlReader[0].ToString();
                txtDescription.Text = sqlReader[1].ToString();
                cmbGradeLevel.Text = sqlReader[2].ToString();
                chkActive.Checked = sqlReader[3].ToString() == "True" ? true : false;
            }
        }

        private void PutGradeLevelDescriptionToComboBox()
        {
            sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            sqlcomm = new SqlCommand("SELECT Description FROM GradeLevel", sqlconn);
            SqlDataReader sqlReader = sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                cmbGradeLevel.Items.Add(sqlReader[0].ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
