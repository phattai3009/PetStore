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
    public partial class frmQLUserAdmin : Form
    {
        private bool isThem = false;
        private bool isThemQuyen = false;
        private string maNV = ""; // Mã nhân viên cũ
        NhanVienBLL userBLL = new NhanVienBLL();

        private string maQuyen = ""; // Mã Quyền cũ
        PhanQuyenBLL pBLL = new PhanQuyenBLL();
        public frmQLUserAdmin()
        {
            InitializeComponent();
        }

        private void frmUserAdmin_Load(object sender, EventArgs e)
        {
            BatTat(false);
            BatTatQuyen(false);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            //load cbo
            userBLL.HienThiVaoComboBox(cboMaQuyen);
            //load bảng User
            userBLL.HienThiVaoDGV(bN, dataGridView1, txtID, txtTaiKhoan, txtMatKhau, txtHoTen, txtCMND, dtpNgaySinh, dtpNgayTao, txtDiaChi, txtEmail, txtDienThoai, cboMaQuyen, txtTienLuong, "");
            dataGridView1.Columns["Column12"].DefaultCellStyle.Format = "c0";
            //load bảng phân quyền
            pBLL.HienThiVaoDGV(bN1, dataGridView2, txtMaQuyen, txtTenQuyen, "");
        }

        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }
        public void BatTat(bool tt)
        {

            txtID.Enabled = tt;
            txtHoTen.Enabled = tt;
            txtTaiKhoan.Enabled = tt;
            txtMatKhau.Enabled = tt;
            dtpNgayTao.Enabled = tt;
            dtpNgaySinh.Enabled = tt;
            txtEmail.Enabled = tt;
            txtDienThoai.Enabled = tt;
            txtDiaChi.Enabled = tt;
            txtTienLuong.Enabled = tt;
            txtMaQuyen.Enabled = tt;
            txtCMND.Enabled = tt;
            cboMaQuyen.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            dataGridView1.Enabled = !tt;
            btnThem.Enabled = !tt;
            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        public void BatTatQuyen(bool tt)
        {

            txtMaQuyen.Enabled = tt;
            txtTenQuyen.Enabled = tt;

            btnLuuQuyen.Enabled = tt;
            btnHuyQuyen.Enabled = tt;

            btnThemQuyen.Enabled = !tt;
            btnSuaQuyen.Enabled = !tt;
            btnXoaQuyen.Enabled = !tt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtID.Enabled = false;
            txtID.Text = "";
            dtpNgayTao.Enabled = false;

            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtCMND.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgaySinh.Value = DateTime.Now;
            txtEmail.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtTienLuong.Text = "3000000";
            cboMaQuyen.SelectedIndex = 0;


            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maNV = txtID.Text;
            txtID.Enabled = false;
            dtpNgayTao.Enabled = false;

            txtTienLuong.DataBindings[0].FormattingEnabled = false;

            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa user " + txtHoTen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                NhanVienDTO info = new NhanVienDTO();
                info.MaNV = Convert.ToInt32(txtID.Text);
                if (userBLL.Xoa(info))
                {
                    this.Alert("Xoá nhân viên thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá nhân viên thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmUserAdmin_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
            txtTienLuong.DataBindings[0].FormattingEnabled = true;
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
            if (txtHoTen.Text.Trim() == "")
                this.Alert("Họ tên không được bỏ trống", frmCustomTB.enmType.Error);
            else if (txtHoTen.Text.Length > 50)
                this.Alert("Họ tên không được quá 50 ký tự", frmCustomTB.enmType.Error);
            else if (txtTaiKhoan.Text.Trim() == "")
                this.Alert("Tài khoản không được bỏ trống", frmCustomTB.enmType.Error);
            else if (txtMatKhau.Text.Length < 8)
                this.Alert("Mật khẩu quá ngắn", frmCustomTB.enmType.Error);
            else if (txtDiaChi.Text.Trim() == "")
                this.Alert("Địa chỉ không được bỏ trống", frmCustomTB.enmType.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                this.Alert("Email không đúng định dạng", frmCustomTB.enmType.Error);
            else if (txtDienThoai.Text.Trim() == "")
                this.Alert("Số điện thoại không được bỏ trống", frmCustomTB.enmType.Error);
            else if (IsValidVietNamPhoneNumber(txtDienThoai.Text)==false)
                this.Alert("Số điện thoại không đúng định dạng", frmCustomTB.enmType.Error);
            else if (txtCMND.Text.Trim() == "")
                this.Alert("CMND không được bỏ trống", frmCustomTB.enmType.Error);
            else if (txtCMND.Text.Length > 15)
                this.Alert("CMND không được quá 15 ký tự", frmCustomTB.enmType.Error);
            else if (cboMaQuyen.Text.Trim() == "")
                this.Alert("Bạn chưa chọn quyền cho nhân viên", frmCustomTB.enmType.Error);
            else if (userBLL.KiemTraTaoTaiKhoan(txtTaiKhoan.Text).Count > 0)
                this.Alert("Tài khoản đã có trong hệ thống", frmCustomTB.enmType.Error);
            else
            {
                NhanVienDTO info = new NhanVienDTO();
                NhanVienBLL tk = new NhanVienBLL();
                string encrypt_pass = Encrypt.Instance.MD5Encrypt(txtMatKhau.Text);

                info.HoTen = txtHoTen.Text.Trim();
                info.UserName = txtTaiKhoan.Text.Trim();
                info.Password = encrypt_pass;
                info.NgaySinh = dtpNgaySinh.Value;
                info.Cmnd = txtCMND.Text.Trim();
                info.CreateDate = dtpNgayTao.Value;
                info.Email = txtEmail.Text.Trim();
                info.Phone = txtDienThoai.Text.Trim();
                info.MaQuyen = Convert.ToInt32(cboMaQuyen.SelectedValue);
                info.Address = txtDiaChi.Text.Trim();
                info.TienLuong = Convert.ToDecimal(txtTienLuong.Text);
                if (isThem)
                {
                    if (userBLL.Them(info))
                    {
                        this.Alert("Thêm nhân viên thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Thêm nhân viên thất bại", frmCustomTB.enmType.Error);
                    }
                    txtTienLuong.DataBindings[0].FormattingEnabled = true;
                }
                else
                {
                    if (userBLL.Sua(info, Convert.ToInt32(maNV)))
                    {
                        this.Alert("Sửa nhân viên thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Sửa nhân viên thất bại", frmCustomTB.enmType.Error);
                    }
                    txtTienLuong.DataBindings[0].FormattingEnabled = true;
                }

                // Tải lại lưới
                frmUserAdmin_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmUserAdmin_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            userBLL.HienThiVaoDGV(bN, dataGridView1, txtID, txtTaiKhoan, txtMatKhau, txtHoTen, txtCMND, dtpNgaySinh, dtpNgayTao, txtDiaChi, txtEmail, txtDienThoai, cboMaQuyen, txtTienLuong, txtTuKhoa.Text);
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
                    NhanVienBLL uaBLL = new NhanVienBLL();
                    NhanVienDTO ua = new NhanVienDTO();
                    ua.MaNV = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    ua.UserName = sheet.Cells[cellRowIndex, 2].Value;
                    ua.Password = sheet.Cells[cellRowIndex, 3].Value;
                    ua.HoTen = sheet.Cells[cellRowIndex, 4].Value;
                    ua.Cmnd = sheet.Cells[cellRowIndex, 5].Value.ToString();
                    ua.NgaySinh = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 6].Value));
                    ua.Address = sheet.Cells[cellRowIndex, 7].Value;
                    ua.Email = sheet.Cells[cellRowIndex, 8].Value;
                    ua.Phone = sheet.Cells[cellRowIndex, 9].Value.ToString();
                    ua.CreateDate = Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", sheet.Cells[cellRowIndex, 10].Value));
                    ua.MaQuyen = Convert.ToInt32(sheet.Cells[cellRowIndex, 11].Value);
                    ua.TienLuong = Convert.ToDecimal(sheet.Cells[cellRowIndex, 12].Value);

                    uaBLL.Them(ua);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmUserAdmin_Load(sender, e);
                this.Alert("Đã nhập thành công dữ liệu từ tập tin Excel!", frmCustomTB.enmType.Success);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSUserAdmin";

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

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ USER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Bảng phân quyền============================================

        private void btnThemQuyen_Click(object sender, EventArgs e)
        {
            BatTatQuyen(true);
            isThemQuyen = true;
            txtMaQuyen.Enabled = false;
            txtMaQuyen.Text = "";
            txtTenQuyen.Text = "";

            txtTenQuyen.Focus();
        }

        private void btnSuaQuyen_Click(object sender, EventArgs e)
        {
            BatTatQuyen(true);
            isThemQuyen = false;
            maQuyen = txtMaQuyen.Text;
            txtMaQuyen.Enabled = false;
            txtTenQuyen.Focus();
        }

        private void btnXoaQuyen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá quyền " + txtTenQuyen.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                PhanQuyenDTO info = new PhanQuyenDTO();
                info.MaQuyen = Convert.ToInt32(txtMaQuyen.Text);
                if (pBLL.Xoa(info))
                {
                    this.Alert("Xoá quyền thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá quyền thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmUserAdmin_Load(sender, e);
        }

        private void btnHuyQuyen_Click(object sender, EventArgs e)
        {
            BatTatQuyen(false);
        }

        private void btnLuuQuyen_Click(object sender, EventArgs e)
        {
            if (txtTenQuyen.Text.Trim() == "")
                this.Alert("Tên quyền không được bỏ trống", frmCustomTB.enmType.Error);
            else
            {
                PhanQuyenDTO info = new PhanQuyenDTO();
                info.TenQuyen = txtTenQuyen.Text.Trim();

                if (isThemQuyen)
                {
                    if (pBLL.Them(info))
                    {
                        this.Alert("Thêm quyền thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Thêm quyền thất bại", frmCustomTB.enmType.Error);
                    }
                }
                else
                {
                    
                    if (pBLL.Sua(info, Convert.ToInt32(maQuyen)))
                    {
                        this.Alert("Sửa quyền thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Sửa quyền thất bại", frmCustomTB.enmType.Error);
                    }
                }


                // Tải lại lưới
                frmUserAdmin_Load(sender, e);
            }
        }

        private void btnTaiLaiQuyen_Click(object sender, EventArgs e)
        {
            frmUserAdmin_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiemQuyen_Click(object sender, EventArgs e)
        {
            pBLL.HienThiVaoDGV(bN1, dataGridView2, txtMaQuyen, txtTenQuyen, txtTuKhoaQuyen.Text);
        }

        private void txtTuKhoaQuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemQuyen_Click(sender, e);
            }
        }

        private void btnNhapExcelQuyen_Click(object sender, EventArgs e)
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
                    PhanQuyenBLL quyenBLL = new PhanQuyenBLL();
                    PhanQuyenDTO quyen = new PhanQuyenDTO();
                    quyen.MaQuyen = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    quyen.TenQuyen = sheet.Cells[cellRowIndex, 2].Value;

                    quyenBLL.Them(quyen);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmUserAdmin_Load(sender, e);
                this.Alert("Đã nhập thành công dữ liệu từ tập tin Excel!", frmCustomTB.enmType.Success);
            }
        }

        private void btnXuatExcelQuyen_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSPhanQuyen";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dataGridView2.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dataGridView2.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            int cellRowIndex = 2;
            int cellColIndex = 1;
            for (int d = 0; d < dataGridView2.Rows.Count; d++)
            {
                for (int c = 0; c < dataGridView2.Columns.Count; c++)
                {
                    sheet.Cells[cellRowIndex, cellColIndex] = dataGridView2.Rows[d].Cells[c].Value.ToString();
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

        private void btnDongQuyen_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ USER", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column11")
            {
                if (e.Value.ToString() == "1")
                    e.Value = "Quản Lý";
                else
                    e.Value = "Nhân Viên";
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column3")
            {
                e.Value = "••••••••••";
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập số", frmCustomTB.enmType.Error);
            }

        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập số", frmCustomTB.enmType.Error);
            }
        }
    }
}
