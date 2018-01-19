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
    public partial class FrmRemarks : Form
    {
        public String Remarks { get; set; }

        public FrmRemarks()
        {
            InitializeComponent();
        }

        private void FrmRemarks_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Remarks = richTextBox1.Text;
        }
    }
}
