
namespace FutronicFingerPrint.Forms
{
    partial class AttendanceLogs
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
            this.dataGridLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridLogs
            // 
            this.dataGridLogs.AllowUserToAddRows = false;
            this.dataGridLogs.AllowUserToDeleteRows = false;
            this.dataGridLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLogs.Location = new System.Drawing.Point(0, 0);
            this.dataGridLogs.Name = "dataGridLogs";
            this.dataGridLogs.ReadOnly = true;
            this.dataGridLogs.RowTemplate.Height = 25;
            this.dataGridLogs.Size = new System.Drawing.Size(800, 450);
            this.dataGridLogs.TabIndex = 0;
            // 
            // AttendanceLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridLogs);
            this.Name = "AttendanceLogs";
            this.Text = "Attendance Logs";
            this.Load += new System.EventHandler(this.AttendanceLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridLogs;
    }
}