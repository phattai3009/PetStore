using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Windows.Forms;
using System.Data;

namespace BLL
{
    public class DonHangBLL
    {
        DonHangDAO data = new DonHangDAO();
        ThuCungDAO ctDAO = new ThuCungDAO();
        public void HienThiVaoDGV(
                                  DataGridView dGV
                                  )
        {
            BindingSource bS = new BindingSource();
            bS.DataSource = data.DonHang_MaDH();

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(
                                  DataGridView dGV,
                                  DateTimePicker frmDate,
                                  DateTimePicker toDate
                                  )
        {
            BindingSource bS = new BindingSource();
            if (frmDate.ToString() == "" && frmDate.ToString() == "")
            {
                bS.DataSource = data.DonHang_CTDH();
            }
            else
                bS.DataSource = data.DonHang_CTDH(frmDate.Value,toDate.Value);


            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV3(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaDH,
                                  TextBox txtMaNV,
                                  DateTimePicker dtpNgayTao,
                                  TextBox txtMaKH,
                                  TextBox txtNguoiNhan,
                                  TextBox txtEmail,
                                  TextBox txtSDT,
                                  TextBox txtDiaChi,
                                  TextBox txtTongTien,
                                  CheckBox chkTinhTrang,
                                   string tuKhoa)
        {
            BindingSource bS = new BindingSource();
            if (tuKhoa == "")
                bS.DataSource = data.DonHang();
            else
                bS.DataSource = data.DonHang_SoDT(tuKhoa);

            txtMaDH.DataBindings.Clear();
            txtMaDH.DataBindings.Add("Text", bS, "MaDH", false, DataSourceUpdateMode.Never);

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", bS, "MaNV", false, DataSourceUpdateMode.Never);

            dtpNgayTao.DataBindings.Clear();
            dtpNgayTao.DataBindings.Add("Value", bS, "CreatedDate", false, DataSourceUpdateMode.Never);

            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", bS, "MaKH", false, DataSourceUpdateMode.Never);

            txtNguoiNhan.DataBindings.Clear();
            txtNguoiNhan.DataBindings.Add("Text", bS, "NguoiNhan", false, DataSourceUpdateMode.Never);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS, "Email", false, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bS, "Phone", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "Address", false, DataSourceUpdateMode.Never);

            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", bS, "TongTien", false, DataSourceUpdateMode.Never);
            txtTongTien.DataBindings[0].FormattingEnabled = true;
            txtTongTien.DataBindings[0].FormatString = "c0";

            chkTinhTrang.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS, "TrangThai", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = 1;
            };
            chkTinhTrang.DataBindings.Add(gt);

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }


        public DataTable DonHang()
        {
            return data.DonHang();
        }
        public DataTable DonHang(int maDH)
        {
            return data.DonHang(maDH);
        }
        public DataTable DonHang_SoDT(string phone)
        {
            return data.DonHang_SoDT(phone);
        }


        public DataTable ThanhTienTheoMaDH(int maDH)
        {
            return data.ThanhTienTheoMaDH(maDH);
        }

        public DataTable DonHang_Report(int maDH)
        {
            return data.DonHang_Report(maDH);
        }

        public DataTable DonHangSell(int maKH, DateTime createdDate, int maNV)
        {
            return data.DonHangSell(maKH, createdDate, maNV);
        }

        //Load bảng Linq
        public List<DonHang> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }

        //Thêm Linq
        public bool ThemLinq(int maNV, string createdDate, int maKH, string nguoiNhan, string email, string phone, string address, decimal tongTien, int trangThai)
        {
            if (data.ThemLinq(maNV, createdDate, maKH, nguoiNhan, email, phone, address, tongTien, trangThai) == true) 
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maDH)
        {
            if (data.XoaLinq(maDH) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maDH, int maNV, string createdDate, int maKH, string nguoiNhan, string email, string phone, string address, decimal tongTien, int trangThai)
        {
            if (data.UpdateLinq(maDH, maNV, createdDate, maKH, nguoiNhan, email, phone, address, tongTien, trangThai) == true)
            {
                return true;
            }
            return false;
        }

        public ThuCung LayTCTheoMa(int maTC)
        {
            return data.LayTCTheoMa(maTC);
        }

        public bool Them(DonHangDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
            
        }

        public bool Sua(DonHangDTO info, int maDH)
        {
            if (data.Sua(info, maDH))
            {
                return true;
            }
            return false;
        }

        public bool SuaDonHang(DonHangDTO info, int maDH)
        {
            if (data.SuaDonHang(info, maDH))
            {
                return true;
            }
            return false;
            
        }

        public bool Xoa(DonHangDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
            
        }

    }
}
