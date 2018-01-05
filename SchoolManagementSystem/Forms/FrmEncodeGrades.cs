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
using System.Configuration;

namespace SchoolManagementSystem.Forms
{
    public partial class FrmEncodeGrades : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;

        public FrmEncodeGrades()
        {
            InitializeComponent();
        }

        private void FrmEncodeGrades_Load(object sender, EventArgs e)
        {

        }
    }
}
