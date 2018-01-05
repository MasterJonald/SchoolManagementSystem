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
        private string SubjectCode { get; set; }

        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }
        
        public FrmAddSubject(string subjectCode)
        {
            InitializeComponent();

            txtSubjectCode.Enabled = false;
            this.SubjectCode = subjectCode;
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
            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            Sqlcomm.ExecuteNonQuery();
            Sqlconn.Close();
        }

        private void SetSubjectInformation()
        {
            string query = string.Format("SELECT * FROM Subject WHERE SubjectCode = '{0}'", this.SubjectCode);
            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

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
            Sqlconn = new SqlConnection(connectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand("SELECT Description FROM GradeLevel", Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

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
