
namespace DoAn_DotNet.Custom
{
    partial class Order
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
            this.picTrangThai = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblMaDH = new System.Windows.Forms.Label();
            this.picDH = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 10);
            this.panel1.TabIndex = 0;
            // 
            // picTrangThai
            // 
            this.picTrangThai.Dock = System.Windows.Forms.DockStyle.Right;
            this.picTrangThai.ImageRotate = 0F;
            this.picTrangThai.Location = new System.Drawing.Point(256, 0);
            this.picTrangThai.Name = "picTrangThai";
            this.picTrangThai.Size = new System.Drawing.Size(23, 73);
            this.picTrangThai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTrangThai.TabIndex = 7;
            this.picTrangThai.TabStop = false;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(89, 44);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(83, 17);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "lblTongTien";
            // 
            // lblMaDH
            // 
            this.lblMaDH.AutoSize = true;
            this.lblMaDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaDH.Location = new System.Drawing.Point(88, 11);
            this.lblMaDH.Name = "lblMaDH";
            this.lblMaDH.Size = new System.Drawing.Size(75, 20);
            this.lblMaDH.TabIndex = 5;
            this.lblMaDH.Text = "lblMaDH";
            // 
            // picDH
            // 
            this.picDH.Dock = System.Windows.Forms.DockStyle.Left;
            this.picDH.ImageRotate = 0F;
            this.picDH.Location = new System.Drawing.Point(0, 0);
            this.picDH.Name = "picDH";
            this.picDH.Size = new System.Drawing.Size(82, 73);
            this.picDH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDH.TabIndex = 4;
            this.picDH.TabStop = false;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.picTrangThai);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.lblMaDH);
            this.Controls.Add(this.picDH);
            this.Controls.Add(this.panel1);
            this.Name = "Order";
            this.Size = new System.Drawing.Size(279, 83);
            this.MouseEnter += new System.EventHandler(this.Order_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Order_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picTrangThai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2PictureBox picTrangThai;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblMaDH;
        private Guna.UI2.WinForms.Guna2PictureBox picDH;
    }
}
