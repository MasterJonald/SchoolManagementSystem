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
    public partial class FrmStudentPersonalInfo : Form
    {
        SqlConnection sqlconn { get; set; }

        public FrmStudentPersonalInfo()
        {
            InitializeComponent();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            ViewStudentPersonalInfo();
        }

        private void ViewStudentPersonalInfo()
        {
            string query = "SELECT StudentNo, FirstName, LastName," +
                "MiddleName from StudentPersonalInfo";
            DataTable dataTable = new DataTable();

            sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlconn);

            sqlDa.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlconn.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult dr2;

            FrmAddStudentPersonalInfo frmAddStudentInfo = new FrmAddStudentPersonalInfo();
            DialogResult dr = frmAddStudentInfo.ShowDialog(this);

            while (dr == DialogResult.OK)
            {
                ViewStudentPersonalInfo();
                dr2 = frmAddStudentInfo.ShowDialog(this);

                if (dr2 == DialogResult.Cancel)
                {
                    break;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string studentNumber = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            FrmAddStudentPersonalInfo frmAddStudentInfo = new FrmAddStudentPersonalInfo(studentNumber);
            frmAddStudentInfo.ShowDialog(this);
            ViewStudentPersonalInfo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string studentNumber = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

            FrmAddStudentPersonalInfo frmAddStudentInfo = new FrmAddStudentPersonalInfo(studentNumber);
            frmAddStudentInfo.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewStudentPersonalInfo();
        }
    }
}
