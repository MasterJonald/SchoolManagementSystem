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
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

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
            //Palitan ng SQL Parameter para hindi prone sa SQL Injection
            string query = "SELECT * FROM Admin WHERE UserName = @userName and Password = @password";

            sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            sqlconn.Open();

            var userNameParam = new SqlParameter("userName", SqlDbType.VarChar);
            userNameParam.Value = txtUserName.Text;

            var passwordParam = new SqlParameter("password", SqlDbType.VarChar);
            passwordParam.Value = txtPassword.Text;

            sqlcomm = new SqlCommand(query, sqlconn);
            sqlcomm.Parameters.Add(userNameParam);
            sqlcomm.Parameters.Add(passwordParam);

            SqlDataReader sqlReader = sqlcomm.ExecuteReader();

            int result = 0;
            while (sqlReader.Read())
            {
                result++;
            }

            if (result == 0)
            {
                MessageBox.Show("Login Failed");
                return;
            }

            MessageBox.Show("Login Successfully");
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FrmSubject frmSub = new SchoolManagementSystem.FrmSubject();
            frmSub.Show();

            this.Close();
        }
    }
}
