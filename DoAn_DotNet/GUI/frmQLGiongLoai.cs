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

namespace DoAn_DotNet.GUI
{
    public partial class frmQLGiongLoai : Form
    {
        private bool isThem = false;
        private bool isThemLoai = false;
        private string maGiong = ""; // Mã giống cũ
        GiongBLL gBLL = new GiongBLL();

        private string maLoai = ""; // Mã Loài cũ
        LoaiBLL lBLL = new LoaiBLL();
        public frmQLGiongLoai()
        {
            InitializeComponent();
        }

        private void frmQLGiongLoai_Load(object sender, EventArgs e)
        {
            BatTat(false);
            BatTatLoai(false);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            //Load cbo MaLoai displayname TenLoai
            gBLL.HienThiVaoComboBox(cboMaLoai);

            //Load bảng Giống
            gBLL.HienThiVaoDGV(bN, dataGridView1, cboMaLoai, txtMaGiong, txtTenGiong, numSoLuongTon, txtMoTa, "");

            //Load bảng loài
            lBLL.HienThiVaoDGV(bN1, dataGridView2, txtMaLoai, txtTenLoai,"");
        }

        //Load thông báo
        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        public void BatTat(bool tt)
        {
            //Bảng Giống
            cboMaLoai.Enabled = tt;
            txtMaGiong.Enabled = tt;
            txtTenGiong.Enabled = tt;
            numSoLuongTon.Enabled = tt;
            txtMoTa.Enabled = tt;

            btnLuu.Enabled = tt;
            btnHuy.Enabled = tt;

            btnThem.Enabled = !tt;
            btnSua.Enabled = !tt;
            btnXoa.Enabled = !tt;
        }

        public void BatTatLoai(bool tt)
        {
            //Bảng loài
            txtMaLoai.Enabled = tt;
            txtTenLoai.Enabled = tt;

            btnLuuLoai.Enabled = tt;
            btnHuyLoai.Enabled = tt;

            btnThemLoai.Enabled = !tt;
            btnSuaLoai.Enabled = !tt;
            btnXoaLoai.Enabled = !tt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = true;
            txtMaGiong.Enabled = false;
            txtMaGiong.Text = "";
            txtTenGiong.Text = "";
            txtMoTa.Text = "";
            cboMaLoai.SelectedIndex = 0;

            txtTenGiong.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BatTat(true);
            isThem = false;
            maGiong = txtMaGiong.Text;
            txtMaGiong.Enabled = false;
            txtTenGiong.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá giống " + txtTenGiong.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                GiongDTO info = new GiongDTO();
                info.MaGiong = Convert.ToInt32(txtMaGiong.Text);
                if (gBLL.Xoa(info))
                {
                    this.Alert("Xoá giống thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá giống thất bại", frmCustomTB.enmType.Error);
                }

            }

            // Tải lại lưới
            frmQLGiongLoai_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTat(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboMaLoai.Text.Trim() == "")
                this.Alert("Vui lòng chọn loài", frmCustomTB.enmType.Error);
            else if (txtTenGiong.Text.Trim() == "")
                this.Alert("Tên giống không được bỏ trống", frmCustomTB.enmType.Error);
            else if (txtMoTa.Text.Trim() == "")
                this.Alert("Mô tả thú cưng không được bỏ trống", frmCustomTB.enmType.Error);
            else
            {
                GiongDTO info = new GiongDTO();
                info.MaLoai = Convert.ToInt32(cboMaLoai.SelectedValue);
                info.TenGiong = txtTenGiong.Text.Trim();
                info.MoTa = txtMoTa.Text.Trim();
                info.SoLuongTon = Convert.ToInt32(numSoLuongTon.Value);

                if (isThem)
                {
                    if (gBLL.Them(info))
                    {
                        this.Alert("Thêm giống thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Thêm giống thất bại", frmCustomTB.enmType.Error);
                    }
                }  
                else
                {
                    if (gBLL.Sua(info, Convert.ToInt32(maGiong)))
                    {
                        this.Alert("Sửa giống thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Sửa giống thất bại", frmCustomTB.enmType.Error);
                    }
                }
                    

                // Tải lại lưới
                frmQLGiongLoai_Load(sender, e);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmQLGiongLoai_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            gBLL.HienThiVaoDGV(bN, dataGridView1, cboMaLoai, txtMaGiong, txtTenGiong, numSoLuongTon, txtMoTa,  txtTuKhoa.Text);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ GIỐNG, LOÀI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
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
                    GiongBLL giongBLL = new GiongBLL();
                    GiongDTO giong = new GiongDTO();
                    giong.MaLoai = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    giong.MaGiong = Convert.ToInt32(sheet.Cells[cellRowIndex, 2].Value);
                    giong.TenGiong = sheet.Cells[cellRowIndex, 3].Value;
                    giong.SoLuongTon = Convert.ToInt32(sheet.Cells[cellRowIndex, 4].Value);
                    giong.MoTa = sheet.Cells[cellRowIndex, 5].Value;

                    giongBLL.Them(giong);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmQLGiongLoai_Load(sender, e);
                this.Alert("Nhập dữ liệu từ file excel thành công", frmCustomTB.enmType.Success);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSGiong";

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
                this.Alert("Xuất ra file excel thành công", frmCustomTB.enmType.Success);
                System.Diagnostics.Process.Start(file.FileName);
            }
        }

        //Bảng Loài//================================================

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            BatTatLoai(true);
            isThemLoai = true;
            txtMaLoai.Enabled = false;
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";

            txtTenLoai.Focus();
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            BatTatLoai(true);
            isThemLoai = false;
            maLoai = txtMaLoai.Text;
            txtMaLoai.Enabled = false;
            txtTenLoai.Focus();
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xoá loài " + txtTenLoai.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                LoaiDTO info = new LoaiDTO();
                info.MaLoai = Convert.ToInt32(txtMaLoai.Text);
                if (lBLL.Xoa(info))
                {
                    this.Alert("Xoá loài thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá loài thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmQLGiongLoai_Load(sender, e);
        }

        private void btnHuyLoai_Click(object sender, EventArgs e)
        {
            BatTatLoai(false);
        }

        private void btnLuuLoai_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text.Trim() == "")
                MessageBox.Show("Bạn chưa nhập tên loài", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
             else
            {
                LoaiDTO info = new LoaiDTO();

                info.TenLoai = txtTenLoai.Text.Trim();

                if (isThemLoai)
                {
                    if (lBLL.Them(info))
                    {
                        this.Alert("Thêm loài thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Thêm loài thất bại", frmCustomTB.enmType.Error);
                    }
                } 
                else
                {
                    if (lBLL.Sua(info, Convert.ToInt32(maLoai)))
                    {
                        this.Alert("Sửa loài thành công", frmCustomTB.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Sửa loài thất bại", frmCustomTB.enmType.Error);
                    }
                }
                    

                // Tải lại lưới
                frmQLGiongLoai_Load(sender, e);
            }
        }

        private void btnTaiLaiLoai_Click(object sender, EventArgs e)
        {
            frmQLGiongLoai_Load(sender, e);
            this.Alert("Load bảng thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiemLoai_Click(object sender, EventArgs e)
        {
            lBLL.HienThiVaoDGV(bN1, dataGridView2, txtMaLoai, txtTenLoai, txtTuKhoaLoai.Text);
        }

        private void txtTuKhoaLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemLoai_Click(sender, e);
            }
        }

        private void btnNhapExcelLoai_Click(object sender, EventArgs e)
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
                    LoaiBLL loaiBLL = new LoaiBLL();
                    LoaiDTO loai = new LoaiDTO();
                    loai.MaLoai = Convert.ToInt32(sheet.Cells[cellRowIndex, 1].Value);
                    loai.TenLoai = sheet.Cells[cellRowIndex, 2].Value;

                    loaiBLL.Them(loai);

                    cellRowIndex++;
                }
                while (sheet.Cells[cellRowIndex, 1].Value2 != null);

                workbook.Close();
                excel.Quit();
                frmQLGiongLoai_Load(sender, e);
                this.Alert("Nhập dữ liệu từ file Excel thành công", frmCustomTB.enmType.Success);
            }
        }

        private void btnXuatExcelLoai_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSLoai";

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

        private void btnDongLoai_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng không ?", "QUẢN LÝ GIỐNG, LOÀI", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
