using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class ChiTietDDMDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable ChiTietDDM()
        {
            string sql = "SELECT * FROM ChiTietDDM";
            return data.QuerySQL(sql);
        }

        public DataTable DsGiongTheoDDM(int maDDM)
        {
            string sql = "SELECT G.MaGiong, G.TenGiong, CTDDM.GiaMua, CTDDM.SoLuongMua FROM ChiTietDDM CTDDM, Giong G Where CTDDM.MaGiong = G.MaGiong AND CTDDM.MaDDM =" + maDDM + "";
            return data.QuerySQL(sql);
        }

        public DataTable DsGiaMuaSL(int maDDM, int maGiong)
        {
            string sql = "SELECT G.MaGiong, G.TenGiong, CTDDM.GiaMua, CTDDM.SoLuongMua FROM ChiTietDDM CTDDM, Giong G Where CTDDM.MaGiong = G.MaGiong AND CTDDM.MaDDM =" + maDDM + " AND CTDDM.MaGiong = " + maGiong + "";
            return data.QuerySQL(sql);
        }

        public DataTable DsMuaDuSL(int maDDM, int maGiong)
        {
            string sql = "SELECT Count(*) FROM ChiTietPN CTPN, PhieuNhap PN WHERE CTPN.MaPN = PN.MaPN AND MaDDM =" + maDDM + " AND MaGiong = " + maGiong + "";
            return data.QuerySQL(sql);
        }

        public DataTable DsMuaSL(int maDDM, int maGiong)
        {
            string sql = "SELECT SoLuongMua FROM ChiTietDDM WHERE MaDDM =" + maDDM + " AND MaGiong = " + maGiong + "";
            return data.QuerySQL(sql);
        }



        public DataTable ChiTietDDM(int maDDM)
        {
            string sql = "SELECT MaGiong, GiaMua, SoLuongMua FROM ChiTietDDM WHERE MaDDM = " + maDDM + "";
            return data.QuerySQL(sql);
        }

        //Thêm Linq
        public bool ThemLinq(int maDDM, int maGiong, decimal giaMua, int soLuong)
        { 
            try
            {
                ChiTietDDM ctddm = new ChiTietDDM();
                ctddm.MaDDM = maDDM;
                ctddm.MaGiong = maGiong;
                ctddm.GiaMua = giaMua;
                ctddm.SoLuongMua = soLuong;

                db.ChiTietDDMs.InsertOnSubmit(ctddm);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maDDM, int maGiong)
        {
            try
            {
                var xoa = db.ChiTietDDMs.Single(t => t.MaGiong == maGiong && t.MaDDM == maDDM);
                db.ChiTietDDMs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maDDM, int maGiong, decimal giaMua, int soLuong)
        { 
            try
            {
                var update = db.ChiTietDDMs.Single(t => t.MaGiong == maGiong);
                update.MaDDM = maDDM;
                update.GiaMua = giaMua;
                update.SoLuongMua = soLuong;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(ChiTietDDMDTO info)
        {
            try
            {
                string sql = "INSERT INTO ChiTietDDM(MaDDM, MaGiong, GiaMua, SoLuongMua)" +
                " VALUES(" + info.MaDDM + ", " + info.MaGiong + "," + info.GiaMua + ", " + info.SoLuongMua + ")";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Sua(ChiTietDDMDTO info, int maDDM, int maGiong)
        {
            try
            {
                string sql = "UPDATE ChiTietDDM SET MaDDM = " + info.MaDDM + ", GiaMua = " + info.GiaMua + ", SoLuongMua = " + info.SoLuongMua + " WHERE MaDDM = " + maDDM + " AND MaGiong = " + maGiong;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Xoa(ChiTietDDMDTO info)
        {
            try
            {
                string sql = "DELETE FROM ChiTietDDM WHERE MaDDM = " + info.MaDDM + " AND MaGiong = " + info.MaGiong;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
