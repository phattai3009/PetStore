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
    public partial class frmQLDoiTra : Form
    {
        DoiTraBLL bllDT = new DoiTraBLL();
        public frmQLDoiTra()
        {
            InitializeComponent();
        }

        private void frmQLDoiTra_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            bllDT.HienThiVaoDGV(bN, dataGridView1, txtMaDT, txtMaDH, txtMaNV, dtpNgayDoi, txtLyDo, txtTinhTrang, "");
        }

        public void Alert(string msg, frmCustomTB.enmType type)
        {
            frmCustomTB frm = new frmCustomTB();
            frm.showAlert(msg, type);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa đơn đổi trả " + txtMaDT.Text + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DoiTraDTO info = new DoiTraDTO();
                info.MaDT =Convert.ToInt32(txtMaDT.Text);
                bllDT.Xoa(info);

                if (bllDT.Xoa(info))
                {
                    this.Alert("Xoá đơn đổi trả thành công", frmCustomTB.enmType.Success);
                }
                else
                {
                    this.Alert("Xoá đơn đổi trả thất bại", frmCustomTB.enmType.Error);
                }
            }

            // Tải lại lưới
            frmQLDoiTra_Load(sender, e);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            frmQLDoiTra_Load(sender, e);
            this.Alert("Load đơn đổi trả thành công", frmCustomTB.enmType.Success);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            bllDT.HienThiVaoDGV(bN, dataGridView1, txtMaDT, txtMaDH, txtMaNV, dtpNgayDoi, txtLyDo, txtTinhTrang, txtTuKhoa.Text);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DSDoiTra";

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
    }
}
