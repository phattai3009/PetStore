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
    public partial class frmNhaCungCap : Form
    {
        private bool isThem = false;
        private string maNCC = ""; // Mã NCC cũ
        NhaCungCapBLL NCCbll = new NhaCungCapBLL();
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            BatTat(false);
            dataGridView1.AutoGenerateColumns = false;
            NCCbll.HienThiVaoDGV(bN, dataGridView1, txtMaNCC, txtTenNCC, txtEmail, txtSDT, txtDiaChi,"");
        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        public void BatTat(bool tt)
        {
            txtMaNCC.Enabled = tt;
            txtTenNCC.Enabled = tt;
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
            txtMaNCC.Enabled = false;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNCC.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maNCC = txtMaNCC.Text;
            txtMaNCC.Enabled = false;


            txtTenNCC.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp " + txtTenNCC.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NCCbll.XoaLinq(Convert.ToInt32(txtMaNCC.Text)))
                {
                    this.Alert("Xoá nhà cung cấp thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá nhà cung cấp thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmNhaCungCap_Load(sender, e);
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
            if (txtTenNCC.Text.Trim() == "")
                this.Alert("Vui lòng nhập tên nhà cung cấp", frmCustomTB.enmType.Error);
            else if (txtTenNCC.Text.Length > 200)
                this.Alert("Tên nhà cung cấp không quá 200 ký tự", frmCustomTB.enmType.Error);
            else if (txtDiaChi.Text.Trim() == "")
                this.Alert("Vui lòng nhập địa chỉ", frmCustomTB.enmType.Error);
            else if (IsValidEmail(txtEmail.Text) == false)
                this.Alert("Email không đúng định dạng", frmCustomTB.enmType.Error);
            else if (IsValidVietNamPhoneNumber(txtSDT.Text) == false)
                this.Alert("Số điện thoại không đúng định dạng", frmCustomTB.enmType.Error);
            else
            {
                if (isThem)
                {
                    if (NCCbll.ThemLinq(txtTenNCC.Text, txtSDT.Text, txtEmail.Text, txtDiaChi.Text))
                    {
                        this.Alert("Thêm nhà cung cấp thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Thêm nhà cung cấp thất bại", frmCustomTB.enmType.Error);
                    }
                }
                else
                {
                    if (NCCbll.UpdateLinq(Convert.ToInt32(maNCC), txtTenNCC.Text, txtSDT.Text, txtEmail.Text, txtDiaChi.Text))
                    {
                        this.Alert("Sửa nhà cung cấp thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Sửa nhà cung cấp thất bại", frmCustomTB.enmType.Error);
                    }
                }

                // Tải lại lưới
                frmNhaCungCap_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            // Tải lại lưới
            frmNhaCungCap_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NCCbll.HienThiVaoDGV(bN, dataGridView1, txtMaNCC, txtTenNCC, txtEmail, txtSDT, txtDiaChi, txtTuKhoa.Text);
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
                    NhaCungCapBLL nccBLL = new NhaCungCapBLL();
                    NhaCungCapDTO ncc = new NhaCungCapDTO();
                    ncc.MaNCC = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    ncc.TenNCC = sheet.Cells[cellRowIndex, 2].Value;
                    ncc.Phone = sheet.Cells[cellRowIndex, 3].Value.ToString();
                    ncc.Email = sheet.Cells[cellRowIndex, 4].Value;
                    ncc.Address = sheet.Cells[cellRowIndex, 5].Value;
                    

                    nccBLL.Them(ncc);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmNhaCungCap_Load(sender, e);
                this.Alert("Đã nhập thành công dữ liệu từ tập tin Excel!", frmCustomTB.enmType.Success);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSNhaCungCap";

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

        private void txtTuKhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                this.Alert("Vui lòng nhập số", frmCustomTB.enmType.Success);
            }
        }
    }
}
