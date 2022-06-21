using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_DotNet.GUI
{
    public partial class frmDangNhap : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void lblQuenMK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên qua số điện thoại: 035 997 5249 \n(gặp Đinh Phát Tài)!", "Quên mật khẩu?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "Đăng Nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(sender, e);
        }

        private void txtTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "Tài Khoản")
            {
                txtTenDangNhap.Text = "";
                txtTenDangNhap.ForeColor = Color.White;
            }
        }

        private void txtTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                txtTenDangNhap.Text = "Tài Khoản";
                txtTenDangNhap.ForeColor = Color.White;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Mật Khẩu")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.White;
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Mật Khẩu";
                txtMatKhau.ForeColor = Color.White;
                txtMatKhau.UseSystemPasswordChar = false;
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void picMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frmDangNhap_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
