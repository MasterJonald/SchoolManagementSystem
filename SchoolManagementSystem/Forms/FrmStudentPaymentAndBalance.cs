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
    public partial class FrmStudentPaymentAndBalance : Form
    {
        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }

        public FrmStudentPaymentAndBalance()
        {
            InitializeComponent();
        }
        
        private void FrmStudentPaymentAndBalance_Load(object sender, EventArgs e)
        {
            ViewBalance();
        }

        private void ViewBalance()
        {
            string query = "SELECT * FROM Balance";
            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            Sqlconn.Close();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dr = dataTable.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["Description"].ToString());
                listitem.SubItems.Add(dr["Balance"].ToString());
                listitem.SubItems.Add(dr["DatePosted"].ToString());
                listView1.Items.Add(listitem);
            }

            listView1.View = View.Details;
        }
    }
}
