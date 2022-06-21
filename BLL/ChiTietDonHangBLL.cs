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
    public class ChiTietDonHangBLL
    {

        ChiTietDonHangDAO data = new ChiTietDonHangDAO();
        DonHangDAO dhDAO = new DonHangDAO();
        ThuCungDAO tcDAO = new ThuCungDAO();

        public void HienThiVaoDGV(DataGridView dGV,
                                  int maDH)
        {
            BindingSource bS = new BindingSource();
                bS.DataSource = data.DanhSach_MaDH(maDH);

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(BindingNavigator bN,
                                  DataGridView dGV,
                                  ComboBox cboMaDH,
                                  TextBox txtMaTC,
                                  TextBox txtTenTC,
                                  TextBox txtGiaBan,
                                  string maDH)
        {
            BindingSource bS = new BindingSource();

            if (maDH.ToString() == "")
                bS.DataSource = data.DanhSach_KetHop();
            else
                bS.DataSource = data.DanhSach_KetHop(maDH);

            cboMaDH.DataBindings.Clear();
            cboMaDH.DataBindings.Add("SelectedValue", bS, "MaDH", false, DataSourceUpdateMode.Never);

            txtMaTC.DataBindings.Clear();
            txtMaTC.DataBindings.Add("Text", bS, "MaTC", false, DataSourceUpdateMode.Never);

            txtTenTC.DataBindings.Clear();
            txtTenTC.DataBindings.Add("Text", bS, "TenTC", false, DataSourceUpdateMode.Never);

            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", bS, "GiaBan", false, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings[0].FormattingEnabled = true;
            txtGiaBan.DataBindings[0].FormatString = "c0";

            dGV.DataSource = bS;
        }

        public DataTable Sell()
        {
            return data.Sell();
        }

        public void HienThiVaoComboBox(ComboBox cboMaDH, ComboBox cboThuCung)
        {
            cboMaDH.DataSource = dhDAO.DonHang();
            cboMaDH.ValueMember = "MaDH";
            cboMaDH.DisplayMember = "MaDH";

            cboThuCung.DataSource = tcDAO.DanhSach();
            cboThuCung.ValueMember = "MaTC";
            cboThuCung.DisplayMember = "TenTC";
        }

        public DataTable DanhSach(int maDH)
        {
            return data.DanhSach(maDH);
        }


        public DataTable DanhSachCT_TC(string maDH)
        {
            return data.DanhSachCT_TC(maDH);
        }

        //Kiểm tra thú cưng
        public List<ChiTietDonHang> KiemTraMaTCLinq(int maTC)
        {
            return data.KiemTraMaTCLinq(maTC);
        }

        public DataTable KiemTraMaTCCoDK(int maTC)
        {
            return data.KiemTraMaTCCoDK(maTC);
        }

        //Load bảng Linq
        public List<ChiTietDonHang> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }

        //Thêm Linq
        public bool ThemLinq(int maDH, int maTC, decimal thanhTien)
        {
            if (data.ThemLinq(maDH, maTC, thanhTien) == true)
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
        public bool UpdateLinq(int maDH, int maTC, decimal thanhTien)
        {
            if (data.UpdateLinq(maDH, maTC, thanhTien) == true)
            {
                return true;
            }
            return false;
        }
        public bool Them(ChiTietDonHangDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(ChiTietDonHangDTO info, int maDH)
        {
            if (data.Sua(info, maDH))
            {
                return true;
            }
            return false;
            
        }
        public bool SuaMaTC(ChiTietDonHangDTO info, int maTC)
        {
            if (data.SuaMaTC(info, maTC))
            {
                return true;
            }
            return false;
        }

        public bool Xoa(ChiTietDonHangDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }

        public bool XoaChiTiet(ChiTietDonHangDTO info)
        {

            if (data.XoaChiTiet(info))
            {
                return true;
            }
            return false;
           
        }
    }
}
