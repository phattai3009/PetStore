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
    public class ChiTietPNBLL
    {
        ChiTietPNDAO data = new ChiTietPNDAO();

        public DataTable ChiTietPhieuNhap(int maPN)
        {
            return data.ChiTietPhieuNhap(maPN);
        }

        public DataTable ChiTietPhieuNhapTheoNgay(DateTime ngayNhap)
        {
            return data.ChiTietPhieuNhapTheoNgay(ngayNhap);
        }

        public DataTable DSPNTheoMaTC(int maTC)
        {
            return data.DSPNTheoMaTC(maTC);
        }

        //Thêm Linq
        public bool ThemLinq(int maPN, int maGiong, int maTC, decimal giaNhap)
        {
            if (data.ThemLinq(maPN, maGiong, maTC, giaNhap) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maTC)
        {
            if (data.XoaLinq(maTC) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maGiong, int maTC, decimal giaNhap)
        {
            if (data.UpdateLinq(maGiong, maTC, giaNhap) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(ChiTietPhieuNhapDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(ChiTietPhieuNhapDTO info, int maTC)
        {
            if (data.Sua(info, maTC))
            {
                return true;
            }
            return false;
        }

        public bool Xoa(ChiTietPhieuNhapDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }
    }
}
