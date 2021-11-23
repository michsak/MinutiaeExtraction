
namespace FutronicFingerPrint.Forms
{
    partial class UserRegistrationForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEnrollRight = new System.Windows.Forms.Button();
            this.btnEnrollLeft = new System.Windows.Forms.Button();
            this.checkBoxRL = new System.Windows.Forms.CheckBox();
            this.checkBoxRR = new System.Windows.Forms.CheckBox();
            this.checkBoxRM = new System.Windows.Forms.CheckBox();
            this.checkBoxRI = new System.Windows.Forms.CheckBox();
            this.checkBoxRT = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxLL = new System.Windows.Forms.CheckBox();
            this.checkBoxLR = new System.Windows.Forms.CheckBox();
            this.checkBoxLM = new System.Windows.Forms.CheckBox();
            this.checkBoxLI = new System.Windows.Forms.CheckBox();
            this.checkBoxLT = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picturePassport = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridAttendance = new System.Windows.Forms.DataGridView();
            this.btnUpdateData = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassport)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLastname);
            this.groupBox1.Controls.Add(this.txtFirstname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Data";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(16, 151);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(284, 23);
            this.txtLastname.TabIndex = 5;
            this.txtLastname.TextChanged += new System.EventHandler(this.txtLastname_TextChanged);
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(16, 97);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(284, 23);
            this.txtFirstname.TabIndex = 4;
            this.txtFirstname.TextChanged += new System.EventHandler(this.txtFirstname_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(16, 44);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(284, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.picturePassport);
            this.groupBox2.Location = new System.Drawing.Point(427, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 201);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Biometric Data";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnEnrollRight);
            this.groupBox4.Controls.Add(this.btnEnrollLeft);
            this.groupBox4.Controls.Add(this.checkBoxRL);
            this.groupBox4.Controls.Add(this.checkBoxRR);
            this.groupBox4.Controls.Add(this.checkBoxRM);
            this.groupBox4.Controls.Add(this.checkBoxRI);
            this.groupBox4.Controls.Add(this.checkBoxRT);
            this.groupBox4.Controls.Add(this.checkBox6);
            this.groupBox4.Controls.Add(this.checkBox7);
            this.groupBox4.Controls.Add(this.checkBox8);
            this.groupBox4.Controls.Add(this.checkBox9);
            this.groupBox4.Controls.Add(this.checkBox10);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.checkBoxLL);
            this.groupBox4.Controls.Add(this.checkBoxLR);
            this.groupBox4.Controls.Add(this.checkBoxLM);
            this.groupBox4.Controls.Add(this.checkBoxLI);
            this.groupBox4.Controls.Add(this.checkBoxLT);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(161, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 177);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fingerprints";
            // 
            // btnEnrollRight
            // 
            this.btnEnrollRight.Location = new System.Drawing.Point(60, 133);
            this.btnEnrollRight.Name = "btnEnrollRight";
            this.btnEnrollRight.Size = new System.Drawing.Size(32, 23);
            this.btnEnrollRight.TabIndex = 11;
            this.btnEnrollRight.Text = "...";
            this.btnEnrollRight.UseVisualStyleBackColor = true;
            this.btnEnrollRight.Click += new System.EventHandler(this.btnEnrollRight_Click);
            // 
            // btnEnrollLeft
            // 
            this.btnEnrollLeft.Location = new System.Drawing.Point(7, 133);
            this.btnEnrollLeft.Name = "btnEnrollLeft";
            this.btnEnrollLeft.Size = new System.Drawing.Size(32, 23);
            this.btnEnrollLeft.TabIndex = 11;
            this.btnEnrollLeft.Text = "...";
            this.btnEnrollLeft.UseVisualStyleBackColor = true;
            this.btnEnrollLeft.Click += new System.EventHandler(this.btnEnrollLeft_Click);
            // 
            // checkBoxRL
            // 
            this.checkBoxRL.AutoSize = true;
            this.checkBoxRL.Location = new System.Drawing.Point(70, 112);
            this.checkBoxRL.Name = "checkBoxRL";
            this.checkBoxRL.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRL.TabIndex = 10;
            this.checkBoxRL.UseVisualStyleBackColor = true;
            // 
            // checkBoxRR
            // 
            this.checkBoxRR.AutoSize = true;
            this.checkBoxRR.Location = new System.Drawing.Point(70, 95);
            this.checkBoxRR.Name = "checkBoxRR";
            this.checkBoxRR.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRR.TabIndex = 10;
            this.checkBoxRR.UseVisualStyleBackColor = true;
            // 
            // checkBoxRM
            // 
            this.checkBoxRM.AutoSize = true;
            this.checkBoxRM.Location = new System.Drawing.Point(70, 78);
            this.checkBoxRM.Name = "checkBoxRM";
            this.checkBoxRM.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRM.TabIndex = 10;
            this.checkBoxRM.UseVisualStyleBackColor = true;
            // 
            // checkBoxRI
            // 
            this.checkBoxRI.AutoSize = true;
            this.checkBoxRI.Location = new System.Drawing.Point(70, 61);
            this.checkBoxRI.Name = "checkBoxRI";
            this.checkBoxRI.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRI.TabIndex = 10;
            this.checkBoxRI.UseVisualStyleBackColor = true;
            // 
            // checkBoxRT
            // 
            this.checkBoxRT.AutoSize = true;
            this.checkBoxRT.Location = new System.Drawing.Point(70, 45);
            this.checkBoxRT.Name = "checkBoxRT";
            this.checkBoxRT.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRT.TabIndex = 10;
            this.checkBoxRT.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(-442, -125);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(-442, -142);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(-442, -159);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(15, 14);
            this.checkBox8.TabIndex = 7;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(-442, -175);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(15, 14);
            this.checkBox9.TabIndex = 8;
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(-442, -192);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(15, 14);
            this.checkBox10.TabIndex = 9;
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "R";
            // 
            // checkBoxLL
            // 
            this.checkBoxLL.AutoSize = true;
            this.checkBoxLL.Location = new System.Drawing.Point(15, 112);
            this.checkBoxLL.Name = "checkBoxLL";
            this.checkBoxLL.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLL.TabIndex = 4;
            this.checkBoxLL.UseVisualStyleBackColor = true;
            // 
            // checkBoxLR
            // 
            this.checkBoxLR.AutoSize = true;
            this.checkBoxLR.Location = new System.Drawing.Point(15, 95);
            this.checkBoxLR.Name = "checkBoxLR";
            this.checkBoxLR.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLR.TabIndex = 4;
            this.checkBoxLR.UseVisualStyleBackColor = true;
            // 
            // checkBoxLM
            // 
            this.checkBoxLM.AutoSize = true;
            this.checkBoxLM.Location = new System.Drawing.Point(15, 78);
            this.checkBoxLM.Name = "checkBoxLM";
            this.checkBoxLM.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLM.TabIndex = 4;
            this.checkBoxLM.UseVisualStyleBackColor = true;
            // 
            // checkBoxLI
            // 
            this.checkBoxLI.AutoSize = true;
            this.checkBoxLI.Location = new System.Drawing.Point(15, 62);
            this.checkBoxLI.Name = "checkBoxLI";
            this.checkBoxLI.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLI.TabIndex = 4;
            this.checkBoxLI.UseVisualStyleBackColor = true;
            // 
            // checkBoxLT
            // 
            this.checkBoxLT.AutoSize = true;
            this.checkBoxLT.Location = new System.Drawing.Point(15, 45);
            this.checkBoxLT.Name = "checkBoxLT";
            this.checkBoxLT.Size = new System.Drawing.Size(15, 14);
            this.checkBoxLT.TabIndex = 4;
            this.checkBoxLT.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Passport";
            // 
            // picturePassport
            // 
            this.picturePassport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePassport.Location = new System.Drawing.Point(7, 36);
            this.picturePassport.Name = "picturePassport";
            this.picturePassport.Size = new System.Drawing.Size(148, 159);
            this.picturePassport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePassport.TabIndex = 0;
            this.picturePassport.TabStop = false;
            this.picturePassport.DoubleClick += new System.EventHandler(this.picturePassport_DoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridAttendance);
            this.groupBox3.Location = new System.Drawing.Point(12, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 275);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attndance records";
            // 
            // dataGridAttendance
            // 
            this.dataGridAttendance.AllowUserToAddRows = false;
            this.dataGridAttendance.AllowUserToDeleteRows = false;
            this.dataGridAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAttendance.Location = new System.Drawing.Point(3, 19);
            this.dataGridAttendance.Name = "dataGridAttendance";
            this.dataGridAttendance.ReadOnly = true;
            this.dataGridAttendance.RowTemplate.Height = 25;
            this.dataGridAttendance.Size = new System.Drawing.Size(770, 253);
            this.dataGridAttendance.TabIndex = 0;
            // 
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(313, 225);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateData.TabIndex = 2;
            this.btnUpdateData.Text = "Update";
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(416, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // UserRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserRegistrationForm";
            this.Text = "User Registration";
            this.Load += new System.EventHandler(this.UserRegistrationForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePassport)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAttendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridAttendance;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picturePassport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxLL;
        private System.Windows.Forms.CheckBox checkBoxLR;
        private System.Windows.Forms.CheckBox checkBoxLM;
        private System.Windows.Forms.CheckBox checkBoxLI;
        private System.Windows.Forms.CheckBox checkBoxLT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnrollRight;
        private System.Windows.Forms.Button btnEnrollLeft;
        private System.Windows.Forms.CheckBox checkBoxRL;
        private System.Windows.Forms.CheckBox checkBoxRR;
        private System.Windows.Forms.CheckBox checkBoxRM;
        private System.Windows.Forms.CheckBox checkBoxRI;
        private System.Windows.Forms.CheckBox checkBoxRT;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.Button btnUpdateData;
        private System.Windows.Forms.Button btnSave;
    }
}