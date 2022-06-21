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
using DTO;
using DoAn_DotNet.Custom;

namespace DoAn_DotNet.GUI
{
    public partial class frmDoiMK : Form
    {
        frmDangNhap fDN = new frmDangNhap();

        string taiKhoan = BLL.NhanVienBLL.frmDoiMKtaiKhoan;
        int maNV = BLL.NhanVienBLL.frmDoiMKmaNV;

        public frmDoiMK()
        {
            InitializeComponent();
        }
        private void LamMoi()
        {
            txtMatKhauCu.Text = txtMatKhauMoi.Text = txtXacNhan.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "Đổi Mật Khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMatKhauCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Kiểm tra đầu vào Enter
            {
                txtMatKhauMoi.Focus();
            }
        }

        private void txtXacNhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Kiểm tra đầu vào Enter
            {
                btnCapNhat.PerformClick();
            }
        }

        private void txtMatKhauMoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//Kiểm tra đầu vào Enter
            {
                txtXacNhan.Focus();
            }
        }

        private void frmThayDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatKhauMoi.Text.Length < 8)
                    this.Alert("Mật khẩu mới quá ngắn", frmCustomTB.enmType.Error);
                else if (txtXacNhan.Text.Length == 0)
                    this.Alert("Vui lòng nhập mật khẩu xác nhận", frmCustomTB.enmType.Error);
                else if (txtMatKhauMoi.Text == txtXacNhan.Text)
                {
                    NhanVienBLL tk = new NhanVienBLL();
                    string encrypt_mkcu = Encrypt.Instance.MD5Encrypt(txtMatKhauCu.Text);
                    if (tk.DangNhap(taiKhoan, encrypt_mkcu))
                    {
                        if (MessageBox.Show("Bạn có muốn thay đổi Mật khẩu?", "Thông báo", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string encrypt_mkmoi = Encrypt.Instance.MD5Encrypt(txtMatKhauMoi.Text);
                            if (tk.DoiMK(maNV, encrypt_mkmoi))
                            {
                                this.Alert("Thay đổi mật khẩu thành công", frmCustomTB.enmType.Success);
                                LamMoi();
                                txtMatKhauCu.Focus();
                            }
                            else
                            {
                                this.Alert("Thay đổi mật khẩu thất bại", frmCustomTB.enmType.Error);
                            }
                        }
                    }
                    else
                    {
                        this.Alert("Mật khẩu cũ không chính xác", frmCustomTB.enmType.Error);
                    }
                }
                else
                {
                    this.Alert("Mật khẩu mới không khớp", frmCustomTB.enmType.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

    }
}
