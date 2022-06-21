using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn_DotNet.GUI;
using BLL;

namespace DoAn_DotNet.Custom
{
    public partial class Category : UserControl
    {
        public Category()
        {
            InitializeComponent();
        }

        #region Properties
        private int maTC;
        private string tenTC;
        private decimal giaBan;
        private Image trangThai;
        private Image anh;
        private string moTa;
        ThuCungBLL bllThuCung = new ThuCungBLL();

        [Category("Custom Props")]
        public int MaTC { get => maTC; set => maTC = value; }

        [Category("Custom Props")]
        public string TenTC { get => tenTC; set { tenTC = value; lblTenTC.Text = value; } }

        [Category("Custom Props")]
        public decimal GiaBan { get => giaBan; set { giaBan = value; lblGiaBan.Text = value.ToString("c0"); } }

        [Category("Custom Props")]
        public Image TrangThai { get => trangThai; set { trangThai = value; picTrangThai.Image = value; } }

        [Category("Custom Props")]
        public Image Anh { get => anh; set { anh = value; pic_TC.Image = value; } }

        [Category("Custom Props")]
        public string MoTa { get => moTa; set { moTa = value; lblMoTa.Text = value.ToString(); } }


        #endregion

        private void Category_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 128, 128);
        }

        private void Category_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá thú cưng " + TenTC + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (bllThuCung.XoaLinq(MaTC) == true)
                {
                    MessageBox.Show("Xoá thú cưng thành công", "Xoá thú cưng", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Xoá thú cưng thất bại", "Xoá thú cưng", MessageBoxButtons.OK);
                }
            }
        }
    }
}
