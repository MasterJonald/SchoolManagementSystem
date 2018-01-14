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
    public partial class FrmPayment : Form
    {
        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }
        private int RecordNo { get; set; }

        public FrmPayment(int recordNo)
        {
            InitializeComponent();
            this.RecordNo = recordNo;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string query = string.Format("INSERT INTO Payment VALUES ({0}, '{1}', '{2}', '{3}', {4}, NULL, NULL, NULL)",
                this.RecordNo, cmbDescription.Text, cmbPaymentType.Text, DateTime.Now.ToShortDateString(), txtAmount.Text);

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query , Sqlconn);
            Sqlcomm.ExecuteNonQuery();
            Sqlconn.Close();
        }

        private void FrmPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
