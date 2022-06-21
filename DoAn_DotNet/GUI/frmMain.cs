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
using DAL;
using DTO;
using DoAn_DotNet.Custom;
using System.Runtime.InteropServices;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmMain : Form
    {
        frmDangNhap fDN = null;

        const int Quyen_ThongThuong = 0;
        const int Quyen_QuanLy = 1;
        const int Quyen_NhanVien = 2;

        public static int maNV = BLL.NhanVienBLL.frmMainmaNV;
        public static string hoVaTen = BLL.NhanVienBLL.frmMainhoVaTen;
        public static int quyenHan = BLL.NhanVienBLL.frmMainquyenHan;

        private Button currentButton;
        private Random random;
        private int tempIndex;

        private Form activeForm;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public frmMain()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChilForm.Visible = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void setVaiTro(int vaitro)
        {

            switch (vaitro)
            {
                // Khách đã được cài đặt dưới default;
                case Quyen_QuanLy:
                    // Đăng nhập vai trò quản lý
                    HienThiThoiGian();
                    lblHoTen.Text = "Quản lý: " + hoVaTen;
                    panelQL.Visible = false;
                    break;
                case Quyen_NhanVien:
                    // Đăng nhập vai trò nhân viên
                    HienThiThoiGian();
                    lblHoTen.Text = "Nhân viên: " + hoVaTen;
                    btnQuanLy.Visible = false;
                    panelQL.Visible = false;
                    break;
                default:
                    // Chưa đăng nhập
                    hoVaTen = "";

                    break;
            }
        }

        private void HienThiThoiGian()
        {
            DateTime t = DateTime.Now;
            lblTimeNow.Text = "Đồng hồ: " + t.ToString("HH:mm:ss dd-MM-yyyy");
        }

        private Color chonMau()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index) //Nếu có màu đã chọn thì chọn màu khác
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActButton(object btnSender)
        {
            //Chọn màu
            //Thay đổi màu nền
            //Thay đổi màu font chữ
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisButton();
                    Color color = chonMau();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    panelTop.BackColor = color;
                    panelLogo.BackColor = ThemeColor.DoiMauPanelLogo(color, -0.3);
                    btnCloseChilForm.Visible = true;

                }
            }
        }

        //Hiểu màu trả về màu mặc định
        private void DisButton()
        {
            foreach (Control prevBtn in panelMenu.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(40, 80, 120);
                    prevBtn.ForeColor = Color.White;
                    prevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                }
            }
            foreach (Control prevBtn in panelQL.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(40, 80, 120);
                    prevBtn.ForeColor = Color.White;
                    prevBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                }
            }
        }

        private void openChilForm(Form chilForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel2.Visible = false;
            ActButton(btnSender);
            activeForm = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            this.pnHome.Controls.Add(chilForm);
            this.pnHome.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
            panel1.Visible = false;
            lblChilForm.Text = chilForm.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HienThiThoiGian();
        }

        private void panelQuanLy(bool tt)
        {
            panelQL.Visible = tt;
            panelQL.Enabled = tt;
        }



        private void btnDonHang_Click(object sender, EventArgs e)
        {
            openChilForm(new frmSell(), sender);
        }

        private void btnQLThuCung_Click(object sender, EventArgs e)
        {
            openChilForm(new frmProduct(), sender);
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            openChilForm(new frmKhachHang(), sender);
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            openChilForm(new frmDoiMK(), sender);
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            setVaiTro(Quyen_ThongThuong);
            if (fDN == null || fDN.IsDisposed)
                fDN = new frmDangNhap();
            if (fDN.ShowDialog() == DialogResult.OK)
            {
                if (fDN.txtTenDangNhap.Text.Trim() == "")
                {
                    MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmMain_Load(sender, e);
                }
                else if (fDN.txtMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Mật khẩu viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmMain_Load(sender, e);
                }
                else
                {
                    NhanVienBLL tk = new NhanVienBLL();
                    string encrypt_pass = Encrypt.Instance.MD5Encrypt(fDN.txtMatKhau.Text);
                    if (tk.DangNhap(fDN.txtTenDangNhap.Text.Trim(), encrypt_pass))
                    {
                        maNV = BLL.NhanVienBLL.frmMainmaNV;
                        hoVaTen = BLL.NhanVienBLL.frmMainhoVaTen;
                        quyenHan = BLL.NhanVienBLL.frmMainquyenHan;
                        // Đăng nhập thành công
                        if (quyenHan == Quyen_QuanLy)
                        {
                            setVaiTro(Quyen_QuanLy);
                            LoadThongTinTong();
                            DoanhThuCuaHang();
                            fDN.txtMatKhau.Clear();

                        }
                        else if (quyenHan == Quyen_NhanVien)
                        {
                            setVaiTro(Quyen_NhanVien);
                            LoadThongTinTong();
                            DoanhThuCuaHang();
                            fDN.txtMatKhau.Clear();
                        }
                        else
                            setVaiTro(Quyen_ThongThuong);
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        frmMain_Load(sender, e);
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Reset()
        {
            DisButton();
            lblChilForm.Text = "HOME";
            panelTop.BackColor = Color.FromArgb(40, 65, 100);
            panelLogo.BackColor = Color.FromArgb(40, 65, 100);
            currentButton = null;
            btnCloseChilForm.Visible = false;
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel2.Visible = true;
        }

        private void btnCloseChilForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
            LoadThongTinTong();
            DoanhThuCuaHang();
            panel1.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                this.WindowState = FormWindowState.Normal;
             
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDetailUser_Click(object sender, EventArgs e)
        {
            openChilForm(new frmDetailUser(), sender);
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            ActButton(sender);
            panelQL.Enabled = true;
            panelQL.Visible = true;
        }

        private void btnQLGiongLoai_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmQLGiongLoai(), sender);
        }

        private void btnQLUser_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmQLUserAdmin(), sender);
        }

        private void btnQLDonHang_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmQLDonHang(), sender);

        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng Xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
                Application.Restart();
            }
        }

        private void LoadThongTinTong()
        {
            DataTable dt = new DataTable();
            try
            {
                NhanVienBLL user =  new NhanVienBLL();
                NhanVienDAO ds = new NhanVienDAO();
                if (user.LayThongTinTong(maNV, DateTime.Today.Month, DateTime.Today.Year)==false)
                {
                    dt = ds.LayThongTinTong(maNV, DateTime.Today.Month, DateTime.Today.Year);
                    DataRow row = dt.Rows[0];
                    lblSoThuCung.Text = row["SoThuCung"].ToString();
                    lblSoDonHang.Text = row["SoHoaDon"].ToString();
                    lblSoTKKH.Text = row["SoKhachHang"].ToString();

                    CultureInfo info = new CultureInfo("vi-VN");
                    double doanhthu = (double)row["DoanhThu"];
                    lblDoanhThu.Text = doanhthu.ToString("c0", info);
                }

            }
            catch
            {
                lblSoThuCung.Text = lblSoDonHang.Text = lblSoTKKH.Text = lblDoanhThu.Text = "  " + "Lỗi";
            }
        }

        private void DoanhThuCuaHang()
        {
            lsvDoanhThu.Items.Clear();
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            try
            {
                DataTable dt = new DataTable();
                NhanVienDAO ds = new NhanVienDAO();

                dt = ds.BaoCaoDoanhThuCuaHang(maNV, DateTime.Today.Month, DateTime.Today.Year);
                if (dt != null)
                {
                    CultureInfo info = new CultureInfo("vi-VN");
                    int i = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        ListViewItem item = new ListViewItem();
                        DateTime t = (DateTime)row["NgayBan"];
                        item.Text = i.ToString();
                        item.SubItems.Add(t.ToString("dd-MM-yyyy"));
                        decimal doanhthu = (decimal)row["DoanhThu"];
                        item.SubItems.Add(doanhthu.ToString("c0", info));
                        chart1.Series[0].Points.AddXY(t.ToString("dd-MM-yyyy"), doanhthu.ToString("c0",info));
                        lsvDoanhThu.Items.Add(item);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnQLDoanhThu_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmQLThongKe(), sender);
        }

        private void btnQLNhapHang_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmQLNhapHang(), sender);
        }

        private void btnQLNCC_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmNhaCungCap(), sender);
        }

        private void btnQLDDM_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmDonDatMua(), sender);
        }

        private void btnQLDoiTra_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmOrder(), sender);
        }

        private void btnDoiTra_Click(object sender, EventArgs e)
        {
            panelQuanLy(false);
            openChilForm(new frmQLDoiTra(), sender);
        }
    }
}
