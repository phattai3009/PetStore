using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using System.Data;
namespace BLL
{
    public class DoiTraBLL
    {
        DoiTraDAO data = new DoiTraDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaDT,
                                  TextBox txtMaDH,
                                  TextBox txtMaNV,
                                  DateTimePicker ngayDoi,
                                  RichTextBox txtLyDo,
                                  RichTextBox txtTinhTrang,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DoiTra();
            else
                bS1.DataSource = data.DoiTra(tuKhoa);

            txtMaDT.DataBindings.Clear();
            txtMaDT.DataBindings.Add("Text", bS1, "MaDT", false, DataSourceUpdateMode.Never);

            txtMaDH.DataBindings.Clear();
            txtMaDH.DataBindings.Add("Text", bS1, "MaDH", false, DataSourceUpdateMode.Never);

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bS1, "MaNV", false, DataSourceUpdateMode.Never);

            ngayDoi.DataBindings.Clear();
            ngayDoi.DataBindings.Add("Value", bS1, "NgayDoi", false, DataSourceUpdateMode.Never);

            txtLyDo.DataBindings.Clear();
            txtLyDo.DataBindings.Add("Text", bS1, "LyDo", false, DataSourceUpdateMode.Never);

            txtTinhTrang.DataBindings.Clear();
            txtTinhTrang.DataBindings.Add("Text", bS1, "TinhTrangThuCung", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public DataTable DoiTra()
        {
            return data.DoiTra();
        }

        public DataTable KiemTraMaDHBiDoi(int maDH)
        {
            return data.KiemTraMaDHBiDoi(maDH);
        }

        public DataTable KiemTraMaDHTraHang(int maDH)
        {
            return data.KiemTraMaDHTraHang(maDH);
        }


        public bool Them(DoiTraDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(DoiTraDTO info, int maDT)
        {
            if (data.Sua(info, maDT))
            {
                return true;
            }
            return false;
        }

        public bool Xoa(DoiTraDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }
    }
}
