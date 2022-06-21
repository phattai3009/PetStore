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
using System.Globalization;
using System.Text.RegularExpressions;

namespace DoAn_DotNet.GUI
{
    public partial class frmQLDonHang : Form
    {
        private string maDH = ""; // Mã đơn hàng cũ
        private string maDHCT = "";
        private string maTCCu = "";
        DonHangBLL dhBLL = new DonHangBLL();

        ChiTietDonHangBLL ctBLL = new ChiTietDonHangBLL();
        public frmQLDonHang()
        {
            InitializeComponent();
        }

        private void frmQLDonHang_Load(object sender, EventArgs e)
        {
            //Bảng đơn hàng
            BatTat(false);
            dhBLL.HienThiVaoDGV3(bN, dataGridView1,txtMaDH,
                                txtID,dtpNgayTao,txtMaKH,
                                txtHoTen,txtEmail,txtDienThoai,
                                txtDiaChi,txtTongTien,checkBox1,"");
            //Bảng chi tiết hoá đơn
            BatTatCT(false);

            ctBLL.HienThiVaoDGV2(bindingNavigator1, dataGridView2, cboDH, txtMaTC, txtTenTC, txtGiaBan, "");
            dataGridView1.Columns["Column9"].DefaultCellStyle.Format = "c0";

            dataGridView2.Columns["Column14"].DefaultCellStyle.Format = "c0";
            dataGridView2.Columns["Column16"].DefaultCellStyle.Format = "c0";
        }

        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        public void BatTat(bool tt)
        {
            txtMaDH.Enabled = tt;
            txtMaKH.Enabled = tt;
            txtID.Enabled = tt;
            txtHoTen.Enabled = tt;
            txtEmail.Enabled = tt;
            txtDienThoai.Enabled = tt;
            txtDiaChi.Enabled = tt;
            dtpNgayTao.Enabled = tt;
            txtTongTien.Enabled = tt;
            checkBox1.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        public void BatTatCT(bool tt)
        {
            cboDH.Enabled = tt;
            txtTenTC.Enabled = tt;
            txtGiaBan.Enabled = tt;

            txtMaTC.Enabled = tt;
            btnXoaCT.Enabled = !tt;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            maDH = txtMaDH.Text;
            txtMaDH.Enabled = false;
            txtID.Enabled = false;
            txtMaKH.Enabled = false;
            txtTongTien.Enabled = false;


            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá đơn hàng " + txtMaDH.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DonHangDTO info = new DonHangDTO();
                info.MaDH = Convert.ToInt32(txtMaDH.Text);
                if (dhBLL.Xoa(info))
                {
                    this.Alert("Xoá đơn hàng thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá đơn hàng thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmQLDonHang_Load(sender, e);
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
            if (txtMaKH.Text.Trim() == "")
                this.Alert("Mã khách hàng không được để trống", frmCustomTB.enmType.Error);
            else if (txtHoTen.Text.Trim() == "")
                this.Alert("Ten người nhận không được bỏ trống", frmCustomTB.enmType.Error);
            //else if (txtEmail.Text.Trim() == "")
            //    this.Alert("Email không được bỏ trống", frmCustomTB.enmType.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                MessageBox.Show("Email không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtDiaChi.Text.Trim() == "")
                this.Alert("Địa chỉ giao hàng không được bỏ trống", frmCustomTB.enmType.Error);
            else if (IsValidVietNamPhoneNumber(txtDienThoai.Text)==false)
                this.Alert("Số điện thoại không đúng định dạng", frmCustomTB.enmType.Error);
            else

            {
                DonHangDTO info = new DonHangDTO();

                info.MaNV = Convert.ToInt32(txtID.Text);
                info.CreatedDate = dtpNgayTao.Value;
                info.MaKH = Convert.ToInt32(txtMaKH.Text);
                info.NguoiNhan = txtHoTen.Text;
                info.Email = txtEmail.Text;
                info.Phone = txtDienThoai.Text;
                info.Address = txtDiaChi.Text;
                info.TongTien = Convert.ToDecimal(null);
                info.TrangThai = checkBox1.Checked ? 1 : 0;

                if (dhBLL.SuaDonHang(info, Convert.ToInt32(maDH)))
                {
                    this.Alert("Sửa đơn hàng thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Sửa đơn hàng thất bại", frmCustomTB.enmType.Error);
                }

                // Tải lại lưới
                frmQLDonHang_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmQLDonHang_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            dhBLL.HienThiVaoDGV3(bN, dataGridView1, txtMaDH,
                                txtID, dtpNgayTao, txtMaKH,
                                txtHoTen, txtEmail, txtDienThoai,
                                txtDiaChi, txtTongTien, checkBox1, txtTuKhoa.Text);
        }

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }


        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSDonHang";

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
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ DƠN HÀNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        //Bảng chi tiết hoá đơn

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá chi tiết đơn hàng " + cboDH.SelectedValue + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                ChiTietDonHangDTO info = new ChiTietDonHangDTO();
                info.MaDH = Convert.ToInt32(cboDH.SelectedValue);
                info.MaTC = Convert.ToInt32(txtMaTC.Text);
                if (ctBLL.XoaChiTiet(info))
                {
                    this.Alert("Xoá chi tiết đơn hàng thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá chi tiết đơn hàng thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmQLDonHang_Load(sender, e);
        }


        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            frmQLDonHang_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiemCT_Click(object sender, EventArgs e)
        {
            ctBLL.HienThiVaoDGV2(bindingNavigator1, dataGridView2, cboDH, txtMaTC, txtTenTC, txtGiaBan, txtTuKhoaCT.Text);

        }

        private void txtTuKhoaCT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemCT_Click(sender, e);
            }
        }

        private void btnXuatExcelCT_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSChiTietDonHang";

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

        private void btnDongCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ DƠN HÀNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập sô", frmCustomTB.enmType.Success);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column10")
            {
                if (e.Value.ToString() == "1")
                    e.Value = "Đã thanh toán";
                else
                    e.Value = "Chưa thanh toán";
            }
        }
    }
}
