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
    public partial class FrmMainMenu : Form
    {
        private DialogResult dr;

        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmStudentPersonalInfo frmInfo = new FrmStudentPersonalInfo();
            dr = frmInfo.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                frmInfo.Close();
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmStudentRecord frmStudentRecord = new FrmStudentRecord();
            dr = frmStudentRecord.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //FrmStudentPaymentAndBalance frmInfo = new FrmStudentPaymentAndBalance();
            //dr = frmInfo.ShowDialog();

            //if (dr == DialogResult.Cancel)
            //{
            //    this.Show();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmEncodeGrades frmEncodeGrades = new FrmEncodeGrades();
            dr = frmEncodeGrades.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSubject frmSubject = new FrmSubject();
            dr = frmSubject.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
