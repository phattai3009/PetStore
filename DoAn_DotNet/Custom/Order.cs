using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace DoAn_DotNet.Custom
{
    public partial class Order : UserControl
    {
        public Order()
        {
            InitializeComponent();
        }

        #region Properties
        private Image pic_DH;
        private int maDH;
        private decimal tongTien;
        private Image pic_trangThai;

        [Category("Custom Props")]
        public Image Pic_DH { get => pic_DH; set { pic_DH = value; picDH.Image = value; } }

        [Category("Custom Props")]
        public int MaDH { get => maDH; set { maDH = value; lblMaDH.Text = value.ToString(); } }

        [Category("Custom Props")]
        public decimal TongTien { get => tongTien; set { tongTien = value; lblTongTien.Text = value.ToString("c0"); } }

        [Category("Custom Props")]
        public Image Pic_trangThai { get => pic_trangThai; set { pic_trangThai = value; picTrangThai.Image = value; } }

        #endregion

        private void Order_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void Order_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 128, 128);
        }
    }
}
