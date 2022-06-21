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
    public class ChiTietDDMBLL
    {
        ChiTietDDMDAO data = new ChiTietDDMDAO();

        public DataTable ChiTietDDM()
        {
            return data.ChiTietDDM();
        }

        public DataTable ChiTietDDM(int maDDM)
        {
            return data.ChiTietDDM(maDDM);
        }

        public DataTable DsGiongTheoDDM(int maDDM)
        {
            return data.DsGiongTheoDDM(maDDM);
        }

        public DataTable DsGiaMuaSL(int maDDM, int maGiong)
        {
            return data.DsGiaMuaSL(maDDM, maGiong);
        }

        public DataTable DsMuaDuSL(int maDDM, int maGiong)
        {
            return data.DsMuaDuSL(maDDM, maGiong);
        }

        public DataTable DsMuaSL(int maDDM, int maGiong)
        {
            return data.DsMuaSL(maDDM, maGiong);
        }

        //Thêm Linq
        public bool ThemLinq(int maDDM, int maGiong, decimal giaMua, int soLuong)
        {
            if (data.ThemLinq(maDDM, maGiong, giaMua, soLuong) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maDDM, int maGiong)
        {
            if (data.XoaLinq(maDDM, maGiong) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maDDM, int maGiong, decimal giaMua, int soLuong)
        {
            if (data.UpdateLinq(maDDM, maGiong, giaMua, soLuong) == true) 
            {
                return true;
            }
            return false;
        }

        public bool Them(ChiTietDDMDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(ChiTietDDMDTO info, int maDDM, int maGiong)
        {
            if (data.Sua(info, maDDM, maGiong))
            {
                return true;
            }
            return false;
        }

        public bool Xoa(ChiTietDDMDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }
    }
}
