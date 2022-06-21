using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using BLL;
using DTO;
using DoAn_DotNet.Custom;
using System.Text.RegularExpressions;
using System.Globalization;

namespace DoAn_DotNet.GUI
{
    public partial class frmKhachHang : Form
    {
        private bool isThem = false;
        private string maKhach = ""; // Mã khách hàng cũ
        public static int maQuyen = BLL.NhanVienBLL.frmKhachHangmaQuyen; //Mã quyền
        KhachHangBLL khBLL = new KhachHangBLL();

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dataGridView1.AutoGenerateColumns = false;
            khBLL.HienThiVaoDGV2(bN,dataGridView1,txtMaKhach,txtTenKhach,txtTaiKhoan,txtMatKhau,dtpNgaySinh,dtpNgayTao,chkGioiTinh,txtEmail,txtSDT,txtDiaChi,"");
        }

        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }
        public void BatTat(bool tt)
        {

            txtMaKhach.Enabled = tt;
            txtTenKhach.Enabled = tt;
            txtTaiKhoan.Enabled = tt;
            txtMatKhau.Enabled = tt;
            dtpNgayTao.Enabled = tt;
            chkGioiTinh.Enabled = tt;
            dtpNgaySinh.Enabled = tt;
            txtEmail.Enabled = tt;
            txtSDT.Enabled = tt;
            txtDiaChi.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            dataGridView1.Enabled = !tt;
            btnThem.Enabled = !tt;
            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaKhach.Enabled = false;
            txtMaKhach.Text = "";
            txtTenKhach.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            chkGioiTinh.Checked = false;
            dtpNgayTao.Enabled = false;
            dtpNgayTao.Value = DateTime.Now;
            dtpNgaySinh.Value = DateTime.Now;
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtMaKhach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maKhach = txtMaKhach.Text;
            txtMaKhach.Enabled = false;


            txtTenKhach.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng " + txtTenKhach.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                KhachHangDTO info = new KhachHangDTO();
                info.MaKH = Convert.ToInt32(txtMaKhach.Text);

                if (khBLL.Xoa(info))
                {
                    this.Alert("Xoá khách hàng thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá khách hàng thất bại", frmCustomTB.enmType.Error);
                }
                
                
            }

            // Tải lại lưới
            frmKhachHang_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
        }
        private bool IsValidEmail(string eMail)
        {
            if (string.IsNullOrWhiteSpace(eMail))
                return false;

            try
            {
                //Đọc tên miền email
                eMail = Regex.Replace(eMail, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                //Kiểm tra miền của email và chuẩn hoá nó
                string DomainMapper(Match match)
                {
                    // Sử dụng lớp IdnMapping để chuyển đổi tên miền Unicode.
                    var idn = new IdnMapping();
                    // Kéo ra và xử lý tên miền (ném ArgumentException vào không hợp lệ)
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(eMail,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
                return false;
            string sMailPattern = @"^((09(\d){8})|(03(\d){8})|(08(\d){8})|(07(\d){8})|(05(\d){8}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKhach.Text.Trim() == "")
                this.Alert("Tên khách hàng không được bỏ trống", frmCustomTB.enmType.Error);
            else if (txtTaiKhoan.Text.Trim() == "")
                this.Alert("Tài khoản không được bỏ trống", frmCustomTB.enmType.Error);
            else if (txtMatKhau.Text.Length < 8)
                this.Alert("Mật khẩu quá ngắn", frmCustomTB.enmType.Error);
            else if (txtDiaChi.Text.Trim() == "")
                this.Alert("Địa chỉ không được bỏ trống", frmCustomTB.enmType.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                this.Alert("Email không đúng định dạng", frmCustomTB.enmType.Error);
            else if (txtSDT.Text.Trim() == "")
                this.Alert("Số điện thoại không được bỏ trống", frmCustomTB.enmType.Error);
            else if (IsValidVietNamPhoneNumber(txtSDT.Text)==false)
                this.Alert("Số điện thoại không đúng định dạng", frmCustomTB.enmType.Error);
            else
            {
                KhachHangDTO info = new KhachHangDTO();
                NhanVienBLL tk = new NhanVienBLL();
                string encrypt_pass = Encrypt.Instance.MD5Encrypt(txtMatKhau.Text);
                info.HoTen = txtTenKhach.Text.Trim();
                info.TaiKhoan = txtTaiKhoan.Text.Trim();
                info.MatKhau = encrypt_pass;
                info.NgaySinh = dtpNgaySinh.Value;
                info.CreateDate = dtpNgayTao.Value;
                info.Email = txtEmail.Text.Trim();
                info.DienThoai = txtSDT.Text.Trim();
                info.GioiTinh = chkGioiTinh.Checked ? "Nữ" : "Nam";
                info.Address = txtDiaChi.Text.Trim();

                if (isThem)
                {
                    if (khBLL.Them(info))
                    {
                        this.Alert("Thêm khách hàng thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Thêm khách hàng thất bại", frmCustomTB.enmType.Error);
                    }
                }   
                else
                {
                    if (khBLL.Sua(info, Convert.ToInt32(maKhach)))
                    {
                        this.Alert("Sửa khách hàng thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Sửa khách hàng thất bại", frmCustomTB.enmType.Error);
                    }
                }
                    

                // Tải lại lưới
                frmKhachHang_Load(sender, e);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ KHÁCH HÀNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            khBLL.HienThiVaoDGV2(bN, dataGridView1, txtMaKhach, txtTenKhach, txtTaiKhoan, txtMatKhau, dtpNgaySinh, dtpNgayTao, chkGioiTinh, txtEmail, txtSDT, txtDiaChi, txtTuKhoa.Text);
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void btnNhapExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _Application excel = new Microsoft.Office.Interop.Excel.Application();
                _Workbook workbook = excel.Workbooks.Open(file.FileName);
                _Worksheet sheet = workbook.ActiveSheet;

                // Dòng bắt đầu là dòng 2 (trừ tiêu đề)
                int cellRowIndex = 2;
                do
                {
                    KhachHangBLL khachBLL = new KhachHangBLL();
                    KhachHangDTO khach = new KhachHangDTO();
                    khach.MaKH = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    khach.HoTen = sheet.Cells[cellRowIndex, 2].Value;
                    khach.TaiKhoan = sheet.Cells[cellRowIndex, 3].Value;
                    khach.MatKhau = sheet.Cells[cellRowIndex, 4].Value;
                    khach.Email = sheet.Cells[cellRowIndex, 5].Value;
                    khach.Address = sheet.Cells[cellRowIndex, 6].Value;
                    khach.DienThoai = sheet.Cells[cellRowIndex, 7].Value.ToString();
                    khach.GioiTinh = sheet.Cells[cellRowIndex, 8].Value;
                    khach.NgaySinh = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 9].Value));
                    khach.CreateDate = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 10].Value));

                    khachBLL.Them(khach);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmKhachHang_Load(sender, e);
                this.Alert("Đã nhập thành công dữ liệu từ tập tin Excel!", frmCustomTB.enmType.Success);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSKhachHang";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dataGridView1.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dataGridView1.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            int cellRowIndex = 2;
            int cellColIndex = 1;
            for (int d = 0; d < dataGridView1.Rows.Count; d++)
            {
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    sheet.Cells[cellRowIndex, cellColIndex] = dataGridView1.Rows[d].Cells[c].Value.ToString();
                    cellColIndex++;
                }
                cellColIndex = 1;
                cellRowIndex++;
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                this.Alert("Danh sách đã được xuất ra tập tin Excel!", frmCustomTB.enmType.Success);
                System.Diagnostics.Process.Start(file.FileName);
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colGioiTinh")
            {
                if ((string)e.Value == "Nữ")
                    e.Value = "Nữ";
                else
                    e.Value = "Nam";
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column4")
            {
                e.Value = "••••••••••";
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
