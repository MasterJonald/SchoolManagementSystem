namespace SchoolManagementSystem.Forms
{
    partial class FrmEncodeGrades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbGradeLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtStudentNumber = new System.Windows.Forms.TextBox();
            this.lblStudentNo = new System.Windows.Forms.Label();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rbtnPerGradeLevel = new System.Windows.Forms.RadioButton();
            this.rbtnPerStudent = new System.Windows.Forms.RadioButton();
            this.lblGradeLevelID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSchoolYear = new System.Windows.Forms.Label();
            this.lblSubjectCode = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(2, 246);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(496, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // cmbGradeLevel
            // 
            this.cmbGradeLevel.FormattingEnabled = true;
            this.cmbGradeLevel.Location = new System.Drawing.Point(110, 102);
            this.cmbGradeLevel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbGradeLevel.Name = "cmbGradeLevel";
            this.cmbGradeLevel.Size = new System.Drawing.Size(120, 21);
            this.cmbGradeLevel.TabIndex = 13;
            this.cmbGradeLevel.SelectedIndexChanged += new System.EventHandler(this.cmbGradeLevel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Grade Level:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(236, 167);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 22);
            this.btnBrowse.TabIndex = 17;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtStudentNumber
            // 
            this.txtStudentNumber.Location = new System.Drawing.Point(110, 167);
            this.txtStudentNumber.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtStudentNumber.Multiline = true;
            this.txtStudentNumber.Name = "txtStudentNumber";
            this.txtStudentNumber.Size = new System.Drawing.Size(128, 21);
            this.txtStudentNumber.TabIndex = 16;
            // 
            // lblStudentNo
            // 
            this.lblStudentNo.AutoSize = true;
            this.lblStudentNo.Location = new System.Drawing.Point(16, 176);
            this.lblStudentNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentNo.Name = "lblStudentNo";
            this.lblStudentNo.Size = new System.Drawing.Size(84, 13);
            this.lblStudentNo.TabIndex = 15;
            this.lblStudentNo.Text = "Student Number";
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(110, 141);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(120, 21);
            this.cmbSubject.TabIndex = 18;
            this.cmbSubject.SelectedIndexChanged += new System.EventHandler(this.cmbSubject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Subject";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(110, 193);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(96, 31);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rbtnPerGradeLevel
            // 
            this.rbtnPerGradeLevel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnPerGradeLevel.Checked = true;
            this.rbtnPerGradeLevel.Location = new System.Drawing.Point(35, 23);
            this.rbtnPerGradeLevel.Name = "rbtnPerGradeLevel";
            this.rbtnPerGradeLevel.Size = new System.Drawing.Size(185, 20);
            this.rbtnPerGradeLevel.TabIndex = 22;
            this.rbtnPerGradeLevel.TabStop = true;
            this.rbtnPerGradeLevel.Text = "Per Grade Level";
            this.rbtnPerGradeLevel.UseVisualStyleBackColor = true;
            this.rbtnPerGradeLevel.CheckedChanged += new System.EventHandler(this.rbntPerGradeLevel_CheckedChanged);
            // 
            // rbtnPerStudent
            // 
            this.rbtnPerStudent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbtnPerStudent.Location = new System.Drawing.Point(35, 45);
            this.rbtnPerStudent.Name = "rbtnPerStudent";
            this.rbtnPerStudent.Size = new System.Drawing.Size(185, 20);
            this.rbtnPerStudent.TabIndex = 23;
            this.rbtnPerStudent.Text = "Per Student";
            this.rbtnPerStudent.UseVisualStyleBackColor = true;
            this.rbtnPerStudent.CheckedChanged += new System.EventHandler(this.rbtnPerStudent_CheckedChanged);
            // 
            // lblGradeLevelID
            // 
            this.lblGradeLevelID.AutoSize = true;
            this.lblGradeLevelID.Location = new System.Drawing.Point(239, 108);
            this.lblGradeLevelID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGradeLevelID.Name = "lblGradeLevelID";
            this.lblGradeLevelID.Size = new System.Drawing.Size(32, 13);
            this.lblGradeLevelID.TabIndex = 24;
            this.lblGradeLevelID.Text = "GLID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "School Year:";
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.Location = new System.Drawing.Point(423, 23);
            this.lblSchoolYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(31, 13);
            this.lblSchoolYear.TabIndex = 26;
            this.lblSchoolYear.Text = "2017";
            // 
            // lblSubjectCode
            // 
            this.lblSubjectCode.AutoSize = true;
            this.lblSubjectCode.Location = new System.Drawing.Point(239, 143);
            this.lblSubjectCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubjectCode.Name = "lblSubjectCode";
            this.lblSubjectCode.Size = new System.Drawing.Size(85, 13);
            this.lblSubjectCode.TabIndex = 27;
            this.lblSubjectCode.Text = "SUBJECTCODE";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(7, 224);
            this.lblStudentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(93, 13);
            this.lblStudentName.TabIndex = 28;
            this.lblStudentName.Text = "STUDENT NAME";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(197, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 31);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmEncodeGrades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 510);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.lblSubjectCode);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGradeLevelID);
            this.Controls.Add(this.rbtnPerStudent);
            this.Controls.Add(this.rbtnPerGradeLevel);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtStudentNumber);
            this.Controls.Add(this.lblStudentNo);
            this.Controls.Add(this.cmbGradeLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FrmEncodeGrades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEncodeGrades";
            this.Load += new System.EventHandler(this.FrmEncodeGrades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbGradeLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtStudentNumber;
        private System.Windows.Forms.Label lblStudentNo;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton rbtnPerGradeLevel;
        private System.Windows.Forms.RadioButton rbtnPerStudent;
        private System.Windows.Forms.Label lblGradeLevelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSchoolYear;
        private System.Windows.Forms.Label lblSubjectCode;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Button btnSave;
    }
}