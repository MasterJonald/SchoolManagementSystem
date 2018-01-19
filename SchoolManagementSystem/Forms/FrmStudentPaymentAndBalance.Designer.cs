namespace SchoolManagementSystem.Forms
{
    partial class FrmStudentPaymentAndBalance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStudentNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBalanceTotal = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkViewVoidedBalance = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkViewVoidedPayment = new System.Windows.Forms.CheckBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPaymentTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnPayBalance = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCalculateRemainingBalance = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(113, 139);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 21;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(113, 109);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(127, 20);
            this.txtMiddleName.TabIndex = 19;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(113, 50);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(127, 20);
            this.txtLastName.TabIndex = 18;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(113, 80);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(127, 20);
            this.txtFirstName.TabIndex = 17;
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Location = new System.Drawing.Point(113, 24);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(127, 20);
            this.txtStudentNumber.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Gender:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Middle Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "First Name:";
            // 
            // lblStudentNo
            // 
            this.lblStudentNo.AutoSize = true;
            this.lblStudentNo.Location = new System.Drawing.Point(10, 24);
            this.lblStudentNo.Name = "lblStudentNo";
            this.lblStudentNo.Size = new System.Drawing.Size(61, 13);
            this.lblStudentNo.TabIndex = 15;
            this.lblStudentNo.Text = "Student No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total: ";
            // 
            // lblBalanceTotal
            // 
            this.lblBalanceTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceTotal.Location = new System.Drawing.Point(290, 183);
            this.lblBalanceTotal.Name = "lblBalanceTotal";
            this.lblBalanceTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblBalanceTotal.Size = new System.Drawing.Size(106, 20);
            this.lblBalanceTotal.TabIndex = 23;
            this.lblBalanceTotal.Text = "0.00";
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.AutoArrange = false;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.Maroon;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 19);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(385, 156);
            this.listView1.TabIndex = 24;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkViewVoidedBalance);
            this.panel1.Controls.Add(this.lblBalanceTotal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(282, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 213);
            this.panel1.TabIndex = 26;
            // 
            // chkViewVoidedBalance
            // 
            this.chkViewVoidedBalance.Location = new System.Drawing.Point(22, 185);
            this.chkViewVoidedBalance.Name = "chkViewVoidedBalance";
            this.chkViewVoidedBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkViewVoidedBalance.Size = new System.Drawing.Size(124, 17);
            this.chkViewVoidedBalance.TabIndex = 26;
            this.chkViewVoidedBalance.Text = "View Voided";
            this.chkViewVoidedBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkViewVoidedBalance.UseVisualStyleBackColor = true;
            this.chkViewVoidedBalance.CheckedChanged += new System.EventHandler(this.chkViewVoidedBalance_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(277, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "___________";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chkViewVoidedPayment);
            this.panel2.Controls.Add(this.listView2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblPaymentTotal);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(282, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 213);
            this.panel2.TabIndex = 27;
            // 
            // chkViewVoidedPayment
            // 
            this.chkViewVoidedPayment.Location = new System.Drawing.Point(22, 184);
            this.chkViewVoidedPayment.Name = "chkViewVoidedPayment";
            this.chkViewVoidedPayment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkViewVoidedPayment.Size = new System.Drawing.Size(124, 17);
            this.chkViewVoidedPayment.TabIndex = 27;
            this.chkViewVoidedPayment.Text = "View Voided";
            this.chkViewVoidedPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkViewVoidedPayment.UseVisualStyleBackColor = true;
            this.chkViewVoidedPayment.CheckedChanged += new System.EventHandler(this.chkViewVoidedPayment_CheckedChanged);
            // 
            // listView2
            // 
            this.listView2.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView2.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView2.AutoArrange = false;
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.ForeColor = System.Drawing.Color.Maroon;
            this.listView2.FullRowSelect = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(14, 17);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(385, 156);
            this.listView2.TabIndex = 25;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView2_ColumnWidthChanging);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(223, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Total: ";
            // 
            // lblPaymentTotal
            // 
            this.lblPaymentTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentTotal.Location = new System.Drawing.Point(290, 180);
            this.lblPaymentTotal.Name = "lblPaymentTotal";
            this.lblPaymentTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPaymentTotal.Size = new System.Drawing.Size(102, 20);
            this.lblPaymentTotal.TabIndex = 23;
            this.lblPaymentTotal.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(277, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "___________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(302, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Balance Details";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(302, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Payment Details";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnCalculateRemainingBalance);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.btnVoid);
            this.panel3.Controls.Add(this.btnPayBalance);
            this.panel3.Location = new System.Drawing.Point(12, 297);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 213);
            this.panel3.TabIndex = 30;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 35);
            this.button3.TabIndex = 24;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 128);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 35);
            this.button2.TabIndex = 23;
            this.button2.Text = "Print Preview";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnVoid
            // 
            this.btnVoid.Location = new System.Drawing.Point(17, 87);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(136, 35);
            this.btnVoid.TabIndex = 22;
            this.btnVoid.Text = "Void";
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // btnPayBalance
            // 
            this.btnPayBalance.Location = new System.Drawing.Point(17, 5);
            this.btnPayBalance.Name = "btnPayBalance";
            this.btnPayBalance.Size = new System.Drawing.Size(136, 35);
            this.btnPayBalance.TabIndex = 21;
            this.btnPayBalance.Text = "Pay Balance";
            this.btnPayBalance.UseVisualStyleBackColor = true;
            this.btnPayBalance.Click += new System.EventHandler(this.btnPayBalance_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtMiddleName);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cmbGender);
            this.panel4.Controls.Add(this.txtStudentNumber);
            this.panel4.Controls.Add(this.txtFirstName);
            this.panel4.Controls.Add(this.txtLastName);
            this.panel4.Controls.Add(this.lblStudentNo);
            this.panel4.Location = new System.Drawing.Point(12, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(253, 213);
            this.panel4.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Student Info";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(225, 29);
            this.label11.TabIndex = 33;
            this.label11.Text = "STUDENT BALANCE";
            // 
            // btnCalculateRemainingBalance
            // 
            this.btnCalculateRemainingBalance.Location = new System.Drawing.Point(17, 46);
            this.btnCalculateRemainingBalance.Name = "btnCalculateRemainingBalance";
            this.btnCalculateRemainingBalance.Size = new System.Drawing.Size(136, 35);
            this.btnCalculateRemainingBalance.TabIndex = 25;
            this.btnCalculateRemainingBalance.Text = "Remaining Balance";
            this.btnCalculateRemainingBalance.UseVisualStyleBackColor = true;
            this.btnCalculateRemainingBalance.Click += new System.EventHandler(this.btnCalculateRemainingBalance_Click);
            // 
            // FrmStudentPaymentAndBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 531);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Name = "FrmStudentPaymentAndBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStudentPaymentAndBalance";
            this.Load += new System.EventHandler(this.FrmStudentPaymentAndBalance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStudentNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBalanceTotal;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPaymentTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPayBalance;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkViewVoidedBalance;
        private System.Windows.Forms.CheckBox chkViewVoidedPayment;
        private System.Windows.Forms.Button btnCalculateRemainingBalance;
    }
}