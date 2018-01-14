namespace SchoolManagementSystem.Forms
{
    partial class FrmAddStudentRecord
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
            this.txtStudentNumber = new System.Windows.Forms.TextBox();
            this.lblStudentInformation = new System.Windows.Forms.Label();
            this.lblStudentNo = new System.Windows.Forms.Label();
            this.btnEnrollAndSave = new System.Windows.Forms.Button();
            this.btnBrowseStudent = new System.Windows.Forms.Button();
            this.cmbGradeLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.dtPickerDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.studentImage = new System.Windows.Forms.PictureBox();
            this.lblTotalBalance = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblGradeLevelID = new System.Windows.Forms.Label();
            this.cmbStudentType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Enabled = false;
            this.txtStudentNumber.Location = new System.Drawing.Point(112, 86);
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(201, 20);
            this.txtStudentNumber.TabIndex = 4;
            // 
            // lblStudentInformation
            // 
            this.lblStudentInformation.AutoSize = true;
            this.lblStudentInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentInformation.Location = new System.Drawing.Point(247, 30);
            this.lblStudentInformation.Name = "lblStudentInformation";
            this.lblStudentInformation.Size = new System.Drawing.Size(326, 20);
            this.lblStudentInformation.TabIndex = 2;
            this.lblStudentInformation.Text = "STUDENT RECORDS AND PAYMENTS";
            // 
            // lblStudentNo
            // 
            this.lblStudentNo.AutoSize = true;
            this.lblStudentNo.Location = new System.Drawing.Point(22, 90);
            this.lblStudentNo.Name = "lblStudentNo";
            this.lblStudentNo.Size = new System.Drawing.Size(84, 13);
            this.lblStudentNo.TabIndex = 3;
            this.lblStudentNo.Text = "Student Number";
            // 
            // btnEnrollAndSave
            // 
            this.btnEnrollAndSave.BackColor = System.Drawing.Color.Red;
            this.btnEnrollAndSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnEnrollAndSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnrollAndSave.ForeColor = System.Drawing.Color.White;
            this.btnEnrollAndSave.Location = new System.Drawing.Point(409, 499);
            this.btnEnrollAndSave.Name = "btnEnrollAndSave";
            this.btnEnrollAndSave.Size = new System.Drawing.Size(109, 32);
            this.btnEnrollAndSave.TabIndex = 11;
            this.btnEnrollAndSave.Text = "Enroll";
            this.btnEnrollAndSave.UseVisualStyleBackColor = false;
            this.btnEnrollAndSave.Click += new System.EventHandler(this.btnEnrollAndSave_Click);
            // 
            // btnBrowseStudent
            // 
            this.btnBrowseStudent.Location = new System.Drawing.Point(315, 86);
            this.btnBrowseStudent.Name = "btnBrowseStudent";
            this.btnBrowseStudent.Size = new System.Drawing.Size(25, 20);
            this.btnBrowseStudent.TabIndex = 12;
            this.btnBrowseStudent.Text = "...";
            this.btnBrowseStudent.UseVisualStyleBackColor = true;
            this.btnBrowseStudent.Click += new System.EventHandler(this.btnBrowseStudent_Click);
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.FormattingEnabled = true;
            this.cmbGradeLevel.Location = new System.Drawing.Point(452, 86);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(121, 21);
            this.cmbGradeLevel.TabIndex = 13;
            this.cmbGradeLevel.SelectedIndexChanged += new System.EventHandler(this.cmbGradeLevel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Grade Level:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "ENROLLED",
            "FAILED",
            "LFR"});
            this.cmbStatus.Location = new System.Drawing.Point(452, 143);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 15;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(406, 148);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            this.lblStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Student Name:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Enabled = false;
            this.txtStudentName.Location = new System.Drawing.Point(112, 113);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(219, 20);
            this.txtStudentName.TabIndex = 18;
            // 
            // dtPickerDateOfBirth
            // 
            this.dtPickerDateOfBirth.CustomFormat = "MMMMdd, yyyy";
            this.dtPickerDateOfBirth.Enabled = false;
            this.dtPickerDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPickerDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerDateOfBirth.Location = new System.Drawing.Point(112, 167);
            this.dtPickerDateOfBirth.Name = "dtPickerDateOfBirth";
            this.dtPickerDateOfBirth.Size = new System.Drawing.Size(219, 20);
            this.dtPickerDateOfBirth.TabIndex = 24;
            this.dtPickerDateOfBirth.Value = new System.DateTime(2018, 1, 2, 18, 20, 46, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Date of Birth:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Gender:";
            // 
            // studentImage
            // 
            this.studentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.studentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentImage.Location = new System.Drawing.Point(619, 48);
            this.studentImage.Name = "studentImage";
            this.studentImage.Size = new System.Drawing.Size(133, 116);
            this.studentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.studentImage.TabIndex = 20;
            this.studentImage.TabStop = false;
            // 
            // lblTotalBalance
            // 
            this.lblTotalBalance.AutoSize = true;
            this.lblTotalBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBalance.ForeColor = System.Drawing.Color.Red;
            this.lblTotalBalance.Location = new System.Drawing.Point(472, 174);
            this.lblTotalBalance.Name = "lblTotalBalance";
            this.lblTotalBalance.Size = new System.Drawing.Size(32, 13);
            this.lblTotalBalance.TabIndex = 23;
            this.lblTotalBalance.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(372, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Total Balance: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(623, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "School Year:";
            // 
            // cmbGender
            // 
            this.cmbGender.Enabled = false;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
            this.cmbGender.Location = new System.Drawing.Point(113, 140);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 27;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(757, 275);
            this.dataGridView1.TabIndex = 28;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.Red;
            this.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPreview.ForeColor = System.Drawing.Color.White;
            this.btnPrintPreview.Location = new System.Drawing.Point(524, 499);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(109, 32);
            this.btnPrintPreview.TabIndex = 29;
            this.btnPrintPreview.Text = "Print Preview";
            this.btnPrintPreview.UseVisualStyleBackColor = false;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(639, 499);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 32);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolYear.Location = new System.Drawing.Point(702, 18);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(35, 13);
            this.lblSchoolYear.TabIndex = 31;
            this.lblSchoolYear.Text = "2017";
            // 
            // lblGradeLevelID
            // 
            this.lblGradeLevelID.AutoSize = true;
            this.lblGradeLevelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradeLevelID.Location = new System.Drawing.Point(579, 90);
            this.lblGradeLevelID.Name = "lblGradeLevelID";
            this.lblGradeLevelID.Size = new System.Drawing.Size(36, 13);
            this.lblGradeLevelID.TabIndex = 32;
            this.lblGradeLevelID.Text = "GLID";
            // 
            // cmbStudentType
            // 
            this.cmbStudentType.FormattingEnabled = true;
            this.cmbStudentType.Items.AddRange(new object[] {
            "OLD STUDENT",
            "NEW STUDENT",
            "TRANSFEREE"});
            this.cmbStudentType.Location = new System.Drawing.Point(452, 113);
            this.cmbStudentType.Name = "cmbStudentType";
            this.cmbStudentType.Size = new System.Drawing.Size(121, 21);
            this.cmbStudentType.TabIndex = 34;
            this.cmbStudentType.SelectedIndexChanged += new System.EventHandler(this.cmbStudentType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(372, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Student Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 36;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAddStudentRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 548);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbStudentType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblGradeLevelID);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.lblTotalBalance);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.dtPickerDateOfBirth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.studentImage);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbGradeLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseStudent);
            this.Controls.Add(this.btnEnrollAndSave);
            this.Controls.Add(this.txtStudentNumber);
            this.Controls.Add(this.lblStudentInformation);
            this.Controls.Add(this.lblStudentNo);
            this.Name = "FrmAddStudentRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmStudentRecord";
            this.Load += new System.EventHandler(this.FrmAddStudentRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.Label lblStudentInformation;
        private System.Windows.Forms.Label lblStudentNo;
        private System.Windows.Forms.Button btnEnrollAndSave;
        private System.Windows.Forms.Button btnBrowseStudent;
        private System.Windows.Forms.ComboBox cmbGradeLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtPickerDateOfBirth;
        private System.Windows.Forms.PictureBox studentImage;
        private System.Windows.Forms.Label lblTotalBalance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblGradeLevelID;
        private System.Windows.Forms.ComboBox cmbStudentType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}