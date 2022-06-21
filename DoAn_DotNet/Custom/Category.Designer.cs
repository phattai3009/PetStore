
namespace DoAn_DotNet.Custom
{
    partial class Category
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pic_TC = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTenTC = new System.Windows.Forms.Label();
            this.picTrangThai = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_TC)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 10);
            this.panel1.TabIndex = 0;
            // 
            // pic_TC
            // 
            this.pic_TC.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_TC.FillColor = System.Drawing.Color.Transparent;
            this.pic_TC.ImageRotate = 0F;
            this.pic_TC.Location = new System.Drawing.Point(0, 0);
            this.pic_TC.Name = "pic_TC";
            this.pic_TC.Size = new System.Drawing.Size(105, 67);
            this.pic_TC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_TC.TabIndex = 8;
            this.pic_TC.TabStop = false;
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblGiaBan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblGiaBan.Location = new System.Drawing.Point(425, 0);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(146, 67);
            this.lblGiaBan.TabIndex = 11;
            this.lblGiaBan.Text = "lblGiaBan";
            this.lblGiaBan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMoTa);
            this.panel2.Controls.Add(this.lblTenTC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(105, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 67);
            this.panel2.TabIndex = 10;
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMoTa.Location = new System.Drawing.Point(4, 27);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(308, 37);
            this.lblMoTa.TabIndex = 3;
            this.lblMoTa.Text = "lblMoTa";
            // 
            // lblTenTC
            // 
            this.lblTenTC.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTC.Location = new System.Drawing.Point(3, 0);
            this.lblTenTC.Name = "lblTenTC";
            this.lblTenTC.Size = new System.Drawing.Size(311, 27);
            this.lblTenTC.TabIndex = 2;
            this.lblTenTC.Text = "lblTenTC";
            // 
            // picTrangThai
            // 
            this.picTrangThai.Dock = System.Windows.Forms.DockStyle.Right;
            this.picTrangThai.ImageRotate = 0F;
            this.picTrangThai.Location = new System.Drawing.Point(858, 0);
            this.picTrangThai.Name = "picTrangThai";
            this.picTrangThai.Size = new System.Drawing.Size(23, 67);
            this.picTrangThai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrangThai.TabIndex = 12;
            this.picTrangThai.TabStop = false;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.picTrangThai);
            this.Controls.Add(this.lblGiaBan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pic_TC);
            this.Controls.Add(this.panel1);
            this.Name = "Category";
            this.Size = new System.Drawing.Size(881, 77);
            this.MouseEnter += new System.EventHandler(this.Category_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Category_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pic_TC)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox pic_TC;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTenTC;
        private Guna.UI2.WinForms.Guna2PictureBox picTrangThai;
    }
}
