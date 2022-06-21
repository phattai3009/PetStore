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
    public class PhieuNhapBLL
    {
        PhieuNhapDAO data = new PhieuNhapDAO();

        public DataTable PhieuNhap()
        {
            return data.PhieuNhap();
        }
        public DataTable LayMaPNTheoNgay(DateTime ngayNhap)
        {
            return data.LayMaPNTheoNgay(ngayNhap);
        }
        public DataTable PhieuNhapChiTiet()
        {
            return data.PhieuNhapChiTiet();
        }

        public DataTable PhieuNhapTheoMa(int maPN)
        {
            return data.PhieuNhapTheoMa(maPN);
        }

        public DataTable LayMaDDMTheoNgay(DateTime ngayNhap)
        {
            return data.LayMaDDMTheoNgay(ngayNhap);
        }

        //Thêm Linq
        public bool ThemLinq(int maDDM, int maNV, DateTime ngayNhap, DateTime ngayCapNhat, string noiDung)
        {
            if (data.ThemLinq(maDDM, maNV, ngayNhap, ngayCapNhat, noiDung) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maPN)
        {
            if (data.XoaLinq(maPN) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maPN, int maDDM, int maNV, DateTime ngayCapNhat, string noiDung)
        {
            if (data.UpdateLinq(maPN, maDDM, maNV, ngayCapNhat, noiDung) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(PhieuNhapDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(PhieuNhapDTO info, int maPN)
        {
            if (data.Sua(info, maPN))
            {
                return true;
            }
            return false;
        }

        public bool Xoa(PhieuNhapDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }
    }
}
