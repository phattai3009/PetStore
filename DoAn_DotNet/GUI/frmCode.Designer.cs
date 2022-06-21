
namespace DoAn_DotNet.GUI
{
    partial class frmCode
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txt_url_DroidCam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_cam = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_cam)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hình ảnh từ Carema:";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(495, 10);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 28);
            this.btn_Connect.TabIndex = 11;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txt_url_DroidCam
            // 
            this.txt_url_DroidCam.Location = new System.Drawing.Point(62, 13);
            this.txt_url_DroidCam.Margin = new System.Windows.Forms.Padding(4);
            this.txt_url_DroidCam.Name = "txt_url_DroidCam";
            this.txt_url_DroidCam.Size = new System.Drawing.Size(424, 22);
            this.txt_url_DroidCam.TabIndex = 10;
            this.txt_url_DroidCam.Text = "http://192.168.1.17:4747/video";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "URL: ";
            // 
            // pic_cam
            // 
            this.pic_cam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_cam.Location = new System.Drawing.Point(7, 68);
            this.pic_cam.Margin = new System.Windows.Forms.Padding(4);
            this.pic_cam.Name = "pic_cam";
            this.pic_cam.Size = new System.Drawing.Size(588, 396);
            this.pic_cam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_cam.TabIndex = 8;
            this.pic_cam.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 475);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.txt_url_DroidCam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_cam);
            this.Name = "frmCode";
            this.Text = "Quét Mã QR";
            ((System.ComponentModel.ISupportInitialize)(this.pic_cam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txt_url_DroidCam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_cam;
        private System.Windows.Forms.Timer timer1;
    }
}