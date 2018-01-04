using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace SchoolManagementSystem.Forms
{
    public partial class FrmLogin : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        SqlConnection sqlconn { get; set; }
        SqlCommand sqlcomm { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName;

            //Palitan ng SQL Parameter para hindi prone sa SQL Injection
            string query = string.Format("SELECT * FROM Admin WHERE UserName = '{0}' AND Password = '{1}'",
                txtUserName.Text, txtPassword.Text);
            
            sqlconn = new SqlConnection(connectionString);
            sqlcomm = new SqlCommand(query, sqlconn);

            userName = sqlcomm.ExecuteReader().ToString();
            sqlconn.Close();

            if (userName == "")
            {
                MessageBox.Show("FAILED");
                return;
            }

            MessageBox.Show("Login Succefully");
        }
    }
}
