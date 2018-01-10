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
    public partial class FrmBrowse : Form
    {
        public String ReturnValueFirstColumn { get; set; }
        public String ReturnValueSecondColumn { get; set;  }

        private SqlConnection Sqlconn;
        public FrmBrowse(string query)
        {
            InitializeComponent();
            ViewInformation(query);
        }

        private void FrmBrowse_Load(object sender, EventArgs e)
        {
            
        }

        private void ViewInformation(string query)
        {
            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            Sqlconn.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
             ReturnValueFirstColumn = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReturnValueFirstColumn = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            ReturnValueSecondColumn = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

            this.DialogResult = DialogResult.OK;
        }
    }
}
