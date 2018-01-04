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
using System.Diagnostics;

namespace SchoolManagementSystem
{
    public partial class FrmSubject : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        SqlConnection sqlconn { get; set; }

        public FrmSubject()
        {
            InitializeComponent();
        }

        private void FrmSubject_Load(object sender, EventArgs e)
        {
            ViewSubject();
        }

        private void ViewSubject()
        {
            string query = "select SubjectCode, Description, GradeLevel," +
                "case when Active = 1 then 'Active' else 'Inactive' end as Active  from subject";
            DataTable dataTable = new DataTable();

            sqlconn = new SqlConnection(connectionString);
            sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlconn);

            sqlDa.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlconn.Close();
        }
        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string subjectCode = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            FrmAddSubject frmAddSub = new FrmAddSubject(subjectCode);
            frmAddSub.ShowDialog(this);
        }
        
        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmAddSubject frmAddSub = new FrmAddSubject();
            frmAddSub.ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string subjectCode = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            FrmAddSubject frmAddSub = new FrmAddSubject(subjectCode);
            frmAddSub.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewSubject();
        }
    }
}
