using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem.Forms
{
    public partial class FrmBackground : Form
    {
        public FrmBackground()
        {
            InitializeComponent();
        }

        private void FrmBackground_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            this.SendToBack(); 
            frmLogin.Show();
        }
    }
}
