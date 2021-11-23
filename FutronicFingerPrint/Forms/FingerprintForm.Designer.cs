
namespace FutronicFingerPrint.Forms
{
    partial class FingerprintForm
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnCaptureLittle = new System.Windows.Forms.Button();
            this.btnCaptureRing = new System.Windows.Forms.Button();
            this.btnCaptureMiddle = new System.Windows.Forms.Button();
            this.btnCaptureIndex = new System.Windows.Forms.Button();
            this.btnCaptureThumb = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureLittle = new System.Windows.Forms.PictureBox();
            this.pictureRing = new System.Windows.Forms.PictureBox();
            this.pictureMiddle = new System.Windows.Forms.PictureBox();
            this.pictureIndex = new System.Windows.Forms.PictureBox();
            this.pictureThumb = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picturePreview = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLittle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureThumb)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(687, 477);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // btnCaptureLittle
            // 
            this.btnCaptureLittle.Location = new System.Drawing.Point(566, 252);
            this.btnCaptureLittle.Name = "btnCaptureLittle";
            this.btnCaptureLittle.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureLittle.TabIndex = 14;
            this.btnCaptureLittle.Text = "Capture";
            this.btnCaptureLittle.UseVisualStyleBackColor = true;
            this.btnCaptureLittle.Click += new System.EventHandler(this.btnCaptureLittle_Click);
            // 
            // btnCaptureRing
            // 
            this.btnCaptureRing.Location = new System.Drawing.Point(429, 213);
            this.btnCaptureRing.Name = "btnCaptureRing";
            this.btnCaptureRing.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureRing.TabIndex = 15;
            this.btnCaptureRing.Text = "Capture";
            this.btnCaptureRing.UseVisualStyleBackColor = true;
            this.btnCaptureRing.Click += new System.EventHandler(this.btnCaptureRing_Click);
            // 
            // btnCaptureMiddle
            // 
            this.btnCaptureMiddle.Location = new System.Drawing.Point(299, 194);
            this.btnCaptureMiddle.Name = "btnCaptureMiddle";
            this.btnCaptureMiddle.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureMiddle.TabIndex = 16;
            this.btnCaptureMiddle.Text = "Capture";
            this.btnCaptureMiddle.UseVisualStyleBackColor = true;
            this.btnCaptureMiddle.Click += new System.EventHandler(this.btnCaptureMiddle_Click);
            // 
            // btnCaptureIndex
            // 
            this.btnCaptureIndex.Location = new System.Drawing.Point(172, 213);
            this.btnCaptureIndex.Name = "btnCaptureIndex";
            this.btnCaptureIndex.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureIndex.TabIndex = 17;
            this.btnCaptureIndex.Text = "Capture";
            this.btnCaptureIndex.UseVisualStyleBackColor = true;
            this.btnCaptureIndex.Click += new System.EventHandler(this.btnCaptureIndex_Click);
            // 
            // btnCaptureThumb
            // 
            this.btnCaptureThumb.Location = new System.Drawing.Point(44, 280);
            this.btnCaptureThumb.Name = "btnCaptureThumb";
            this.btnCaptureThumb.Size = new System.Drawing.Size(75, 23);
            this.btnCaptureThumb.TabIndex = 18;
            this.btnCaptureThumb.Text = "Capture";
            this.btnCaptureThumb.UseVisualStyleBackColor = true;
            this.btnCaptureThumb.Click += new System.EventHandler(this.btnCaptureThumb_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Little Finger";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ring Finger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Middle Finger";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Index Finger";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Thumb";
            // 
            // pictureLittle
            // 
            this.pictureLittle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureLittle.Location = new System.Drawing.Point(552, 106);
            this.pictureLittle.Name = "pictureLittle";
            this.pictureLittle.Size = new System.Drawing.Size(106, 130);
            this.pictureLittle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLittle.TabIndex = 4;
            this.pictureLittle.TabStop = false;
            // 
            // pictureRing
            // 
            this.pictureRing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureRing.Location = new System.Drawing.Point(415, 67);
            this.pictureRing.Name = "pictureRing";
            this.pictureRing.Size = new System.Drawing.Size(106, 130);
            this.pictureRing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureRing.TabIndex = 5;
            this.pictureRing.TabStop = false;
            // 
            // pictureMiddle
            // 
            this.pictureMiddle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureMiddle.Location = new System.Drawing.Point(285, 48);
            this.pictureMiddle.Name = "pictureMiddle";
            this.pictureMiddle.Size = new System.Drawing.Size(106, 130);
            this.pictureMiddle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMiddle.TabIndex = 6;
            this.pictureMiddle.TabStop = false;
            // 
            // pictureIndex
            // 
            this.pictureIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureIndex.Location = new System.Drawing.Point(158, 67);
            this.pictureIndex.Name = "pictureIndex";
            this.pictureIndex.Size = new System.Drawing.Size(106, 130);
            this.pictureIndex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureIndex.TabIndex = 7;
            this.pictureIndex.TabStop = false;
            // 
            // pictureThumb
            // 
            this.pictureThumb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureThumb.Location = new System.Drawing.Point(30, 134);
            this.pictureThumb.Name = "pictureThumb";
            this.pictureThumb.Size = new System.Drawing.Size(106, 130);
            this.pictureThumb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureThumb.TabIndex = 8;
            this.pictureThumb.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picturePreview);
            this.groupBox1.Location = new System.Drawing.Point(694, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 205);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // picturePreview
            // 
            this.picturePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePreview.Location = new System.Drawing.Point(6, 22);
            this.picturePreview.Name = "picturePreview";
            this.picturePreview.Size = new System.Drawing.Size(149, 175);
            this.picturePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePreview.TabIndex = 4;
            this.picturePreview.TabStop = false;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(304, 427);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 20;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // FingerprintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 477);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCaptureLittle);
            this.Controls.Add(this.btnCaptureRing);
            this.Controls.Add(this.btnCaptureMiddle);
            this.Controls.Add(this.btnCaptureIndex);
            this.Controls.Add(this.btnCaptureThumb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureLittle);
            this.Controls.Add(this.pictureRing);
            this.Controls.Add(this.pictureMiddle);
            this.Controls.Add(this.pictureIndex);
            this.Controls.Add(this.pictureThumb);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FingerprintForm";
            this.ShowInTaskbar = false;
            this.Text = "Fingerprint Enrollment";
            this.Load += new System.EventHandler(this.FingerprintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLittle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureThumb)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnCaptureLittle;
        private System.Windows.Forms.Button btnCaptureRing;
        private System.Windows.Forms.Button btnCaptureMiddle;
        private System.Windows.Forms.Button btnCaptureIndex;
        private System.Windows.Forms.Button btnCaptureThumb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureLittle;
        private System.Windows.Forms.PictureBox pictureRing;
        private System.Windows.Forms.PictureBox pictureMiddle;
        private System.Windows.Forms.PictureBox pictureIndex;
        private System.Windows.Forms.PictureBox pictureThumb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picturePreview;
        private System.Windows.Forms.Button btnDone;
    }
}