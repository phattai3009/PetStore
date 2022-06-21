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
    public class DonDatMuaBLL
    {
        DonDatMuaDAO data = new DonDatMuaDAO();

        public DataTable DsDDM()
        {
            return data.DsDDM();
        }

        public DataTable LayMaDDMMoiNhat()
        {
            return data.LayMaDDMMoiNhat();
        }
        public DataTable DonDatMua()
        {
            return data.DonDatMua();
        }

        public DataTable DonDatMuaTheoMa(int maDDM)
        {
            return data.DonDatMuaTheoMa(maDDM);
        }
        //Thêm Linq
        public bool ThemLinq(int maNCC, int maNV, DateTime createDate, DateTime ngayCapNhat, string noiDung)
        {
            if (data.ThemLinq(maNCC, maNV, createDate, ngayCapNhat, noiDung) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maDDM)
        {
            if (data.XoaLinq(maDDM) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maDDM, int maNCC, int maNV, DateTime createDate, DateTime ngayCapNhat, string noiDung)
        {
            if (data.UpdateLinq(maDDM, maNCC, maNV, createDate, ngayCapNhat, noiDung) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(DonDatMuaDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(DonDatMuaDTO info, int maDDM)
        {
            if (data.Sua(info, maDDM))
            {
                return true;
            }
            return false;
        }

        public bool Xoa(DonDatMuaDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }
    }
}
