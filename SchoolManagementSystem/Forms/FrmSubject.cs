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

namespace SchoolManagementSystem
{

    public partial class FrmSubject : Form
    {
        //private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

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
            string query = "SELECT SubjectCode, Description, GradeLevel," +
                "CASE WHEN Active = 1 THEN 'Active' ELSE 'Inactive' END AS Active  FROM Subject";
            DataTable dataTable = new DataTable();

            sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
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
            DialogResult dr2;

            FrmAddSubject frmAddSub = new FrmAddSubject();
            DialogResult dr = frmAddSub.ShowDialog(this);

            while (dr == DialogResult.Yes)
            {
                ViewSubject();
                dr2 = frmAddSub.ShowDialog(this);

                if (dr2 == DialogResult.Cancel)
                {
                    break;
                }
            }
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
