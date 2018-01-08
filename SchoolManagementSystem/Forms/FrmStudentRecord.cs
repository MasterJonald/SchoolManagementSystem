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
    public partial class FrmStudentRecord : Form
    {

        SqlConnection sqlconn { get; set; }

        public FrmStudentRecord()
        {
            InitializeComponent();
        }

        private void FrmStudentRecord_Load(object sender, EventArgs e)
        {
            ViewStudentRecord();
        }

        private void ViewStudentRecord()
        {
            string query = "SELECT * FROM StudentRecord";
            DataTable dataTable = new DataTable();

            sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlconn);

            sqlDa.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlconn.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string recordNo = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string studentNumber = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

            FrmAddStudentRecord frmAddStudentRecord = new FrmAddStudentRecord(recordNo, studentNumber);
            frmAddStudentRecord.ShowDialog(this);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string recordNo = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            string studentNumber = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

            FrmAddStudentRecord frmAddStudentRecord = new FrmAddStudentRecord(recordNo, studentNumber);
            frmAddStudentRecord.ShowDialog(this);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult dr2;

            FrmAddStudentRecord frmAddStudentRecord = new FrmAddStudentRecord();
            DialogResult dr = frmAddStudentRecord.ShowDialog(this);

            while (dr == DialogResult.OK)
            {
                ViewStudentRecord();
                dr2 = frmAddStudentRecord.ShowDialog(this);

                if (dr2 == DialogResult.Cancel)
                {
                    break;
                }
            }
        }
    }
}
