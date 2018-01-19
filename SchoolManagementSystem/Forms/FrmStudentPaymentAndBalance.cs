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
        private int StudentRecordNo { get; set; }

        private SqlConnection Sqlconn { get; set; }
        private SqlCommand Sqlcomm { get; set; }

        public FrmStudentPaymentAndBalance(int studentRecordNo)
        {
            InitializeComponent();
            this.StudentRecordNo = studentRecordNo;
        }
        
        private void FrmStudentPaymentAndBalance_Load(object sender, EventArgs e)
        {
            SetStudentRecordInformation();
            ViewBalance();
            ViewPayment();
        }

        private void AddColumnForBalance()
        {
            listView1.Columns.Add("Balance No", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Date Posted", 90, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 130, HorizontalAlignment.Left);
            listView1.Columns.Add("Amount", 105, HorizontalAlignment.Left);
        }

        private void AddColumnForPayment()
        {
            listView2.Columns.Add("Payment No", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("Date Posted", 90, HorizontalAlignment.Left);
            listView2.Columns.Add("Description", 130, HorizontalAlignment.Left);
            listView2.Columns.Add("Payment Type", 105, HorizontalAlignment.Left);
            listView2.Columns.Add("Amount", 105, HorizontalAlignment.Left);
        }

        private void AddColumnForBalanceVoided()
        {
            listView1.Columns.Add("Balance No", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Date Voided", 90, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 130, HorizontalAlignment.Left);
            listView1.Columns.Add("Remarks", 105, HorizontalAlignment.Left);
            listView1.Columns.Add("Amount", 105, HorizontalAlignment.Left);
        }

        private void AddColumnForPaymentVoided()
        {
            listView2.Columns.Add("Payment No", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("Date Voided", 90, HorizontalAlignment.Left);
            listView2.Columns.Add("Description", 130, HorizontalAlignment.Left);
            listView2.Columns.Add("Payment Type", 105, HorizontalAlignment.Left);
            listView2.Columns.Add("Remarks", 105, HorizontalAlignment.Left);
            listView2.Columns.Add("Amount", 105, HorizontalAlignment.Left);
        }

        private void GetBalanceRow()
        {
            string query = "SELECT BalanceNo, DatePosted, Description, Amount FROM Balance " +
                "WHERE StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 0 ";
            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            Sqlconn.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["BalanceNo"].ToString());
                listItem.SubItems.Add(Convert.ToDateTime(row["DatePosted"]).ToShortDateString());
                listItem.SubItems.Add(row["Description"].ToString());
                listItem.SubItems.Add(row["Amount"].ToString());
                listView1.Items.Add(listItem);
            }

            string balanceTotal = "SELECT SUM(Amount) FROM Balance WHERE " +
                "StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 0 ";
            lblBalanceTotal.Text = GetAmountTotal(balanceTotal).ToString();
        }

        private void GetPaymentRow()
        {
            string query = "SELECT PaymentNo, DatePosted, Description, PaymentType, Amount FROM Payment " +
                "WHERE StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 0 ";

            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            Sqlconn.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["PaymentNo"].ToString());
                listItem.SubItems.Add(Convert.ToDateTime(row["DatePosted"]).ToShortDateString());
                listItem.SubItems.Add(row["Description"].ToString());
                listItem.SubItems.Add(row["PaymentType"].ToString());
                listItem.SubItems.Add(row["Amount"].ToString());
                listView2.Items.Add(listItem);
            }

            string paymentTotal = "SELECT SUM(Amount) FROM Payment WHERE " +
                "StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 0 ";
            lblPaymentTotal.Text = GetAmountTotal(paymentTotal).ToString();
        }

        private void GetBalanceRowVoided()
        {
            string query = "SELECT BalanceNo, DateVoided, Description, VoidRemarks, Amount FROM Balance " +
                "WHERE StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 1 ";

            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            Sqlconn.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["BalanceNo"].ToString());
                listItem.SubItems.Add(Convert.ToDateTime(row["DateVoided"]).ToShortDateString());
                listItem.SubItems.Add(row["Description"].ToString());
                listItem.SubItems.Add(row["VoidRemarks"].ToString());
                listItem.SubItems.Add(row["Amount"].ToString());
                listView1.Items.Add(listItem);
            }

            string paymentTotal = "SELECT SUM(Amount) FROM Balance WHERE " +
                 "StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 1 ";
            lblBalanceTotal.Text = GetAmountTotal(paymentTotal).ToString();
        }

        private void GetPaymentRowVoided()
        {
            string query = "SELECT PaymentNo, DateVoided, Description, PaymentType, VoidRemarks, Amount FROM Payment " +
                "WHERE StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 1 ";

            DataTable dataTable = new DataTable();

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            SqlDataAdapter sqlDa = new SqlDataAdapter(query, Sqlconn);

            sqlDa.Fill(dataTable);
            Sqlconn.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem listItem = new ListViewItem(row["PaymentNo"].ToString());
                listItem.SubItems.Add(Convert.ToDateTime(row["DateVoided"]).ToShortDateString());
                listItem.SubItems.Add(row["Description"].ToString());
                listItem.SubItems.Add(row["PaymentType"].ToString());
                listItem.SubItems.Add(row["VoidRemarks"].ToString());
                listItem.SubItems.Add(row["Amount"].ToString());
                listView2.Items.Add(listItem);
            }

            string paymentTotal = "SELECT SUM(Amount) FROM Payment WHERE " +
                 "StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 1 ";
            lblPaymentTotal.Text = GetAmountTotal(paymentTotal).ToString();
        }
        
        private void ViewBalance()
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            AddColumnForBalance();
            GetBalanceRow();
        }

        private void ViewPayment()
        {
            listView2.Columns.Clear();
            listView2.Items.Clear();

            AddColumnForPayment();
            GetPaymentRow();
        }

        private void ViewBalanceVoided()
        {
            listView1.Columns.Clear();
            listView1.Items.Clear();

            AddColumnForBalanceVoided();
            GetBalanceRowVoided();
        }

        private void ViewPaymentVoided()
        {
            listView2.Columns.Clear();
            listView2.Items.Clear();

            AddColumnForPaymentVoided();
            GetPaymentRowVoided();
        }
        
        private double GetAmountTotal(string query)
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            if (Sqlcomm.ExecuteScalar().ToString() == "")
            {
                Sqlconn.Close();
                return 0;
            }

            double amount = Convert.ToDouble(Sqlcomm.ExecuteScalar());
            Sqlconn.Close();

            return amount;
        }

        private void SetStudentRecordInformation()
        {
            string query = "SELECT SP.StudentNo, SP.FirstName, SP.LastName, SP.MiddleName," +
                "SP.Gender, SP.DateOfBirth, SP.ImagePath, SR.GradeLevelID, SR.Status, SR.StudentType " +
                "FROM StudentRecord AS SR INNER JOIN StudentPersonalInfo AS SP ON SR.StudentNo = SP.StudentNo " +
                "INNER JOIN GradeLevel AS GL ON GL.GradeLevelID = SR.GradeLevelID " +
                "WHERE SR.RecordNo = " + this.StudentRecordNo + "";

            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();

            Sqlcomm = new SqlCommand(query, Sqlconn);
            SqlDataReader sqlReader = Sqlcomm.ExecuteReader();

            while (sqlReader.Read())
            {
                txtStudentNumber.Text = sqlReader["StudentNo"].ToString();
                txtFirstName.Text = sqlReader["FirstName"].ToString();
                txtLastName.Text = sqlReader["LastName"].ToString();
                txtMiddleName.Text = sqlReader["MiddleName"].ToString();
                cmbGender.Text = sqlReader["Gender"].ToString();
            }

            sqlReader.Close();
            Sqlconn.Close();
        }

        private void chkViewVoidedPayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewVoidedPayment.Checked)
            {
                ViewPaymentVoided();
            }
            else
            {
                ViewPayment();
            }
        }

        private void chkViewVoidedBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewVoidedBalance.Checked)
            {
                ViewBalanceVoided();
            }
            
            else
            {
                ViewBalance();
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }

        private void btnPayBalance_Click(object sender, EventArgs e)
        {
            FrmPayment frmPayment = new FrmPayment(this.StudentRecordNo);

            DialogResult dr = frmPayment.ShowDialog();

            if (dr == DialogResult.OK)
            {
                ViewPayment();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listView2_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView2.Columns[e.ColumnIndex].Width;
        }

        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && chkViewVoidedBalance.Checked)
            {
                return;
            }

            if (listView2.SelectedItems.Count > 0 && chkViewVoidedPayment.Checked)
            {
                return;
            }

            if (listView1.SelectedItems.Count == 0 && listView2.SelectedItems.Count == 0)
            {
                return;
            }

            DialogResult dr =MessageBox.Show("Do you want to continue?", 
                "Void", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                return;
            }

            if (listView1.SelectedItems.Count > 0)
            {
                FrmRemarks frmRemarks = new FrmRemarks();
                dr = frmRemarks.ShowDialog();

                string remarks = frmRemarks.Remarks;
                int balanceNo = Convert.ToInt32(listView1.SelectedItems[0].Text);

                string query = string.Format("UPDATE Balance SET Voided = 1, DateVoided = '{0}', VoidRemarks = '{1}' " +
                    "WHERE BalanceNo = {2} ",
                    DateTime.Now.ToShortDateString(), remarks, balanceNo);
                VoidTransaction(query);
                ViewBalance();
            }

            else if (listView2.SelectedItems.Count > 0)
            {
                FrmRemarks frmRemarks = new FrmRemarks();
                dr = frmRemarks.ShowDialog();

                string remarks = frmRemarks.Remarks;
                int paymentNo = Convert.ToInt32(listView2.SelectedItems[0].Text);

                string query = string.Format("UPDATE Payment SET Voided = 1, DateVoided = '{0}', VoidRemarks = '{1}' " +
                    "WHERE PaymentNo = {2} ",
                    DateTime.Now.ToShortDateString(), remarks, paymentNo);
                VoidTransaction(query);
                ViewPayment();
            }
        }

        private void VoidTransaction(string query)
        {
            Sqlconn = new SqlConnection(GlobalVariable.ConnectionString);
            Sqlconn.Open();
            Sqlcomm = new SqlCommand(query, Sqlconn);

            Sqlcomm.ExecuteNonQuery();
            Sqlconn.Close();
        }

        private void btnCalculateRemainingBalance_Click(object sender, EventArgs e)
        {
            string strBalanceTotal = "SELECT SUM(Amount) FROM Balance WHERE " +
                "StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 0 ";
            double totalBalance = GetAmountTotal(strBalanceTotal);

            string strPaymentTotal = "SELECT SUM(Amount) FROM Payment WHERE " +
                "StudentRecordNo = " + this.StudentRecordNo + " AND Voided = 0 ";
            double totalPayment = GetAmountTotal(strPaymentTotal);

            MessageBox.Show("Remaining balance: " + (totalBalance - totalPayment),
                "Student Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
