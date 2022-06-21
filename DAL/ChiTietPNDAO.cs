using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class ChiTietPNDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable ChiTietPN()
        {
            string sql = "SELECT * FROM ChiTietPN";
            return data.QuerySQL(sql);
        }
        public DataTable ChiTietPhieuNhap(int maPN)
        {
            string sql = "SELECT MaGiong, MaTC, GiaNhap FROM ChiTietPN WHERE MaPN = " + maPN + "";
            return data.QuerySQL(sql);
        }

        public DataTable DSPNTheoMaTC(int maTC)
        {
            string sql = "SELECT * FROM ChiTietPN WHERE MaTC = " + maTC + "";
            return data.QuerySQL(sql);
        }

        public DataTable ChiTietPhieuNhapTheoNgay(DateTime ngayNhap)
        {
            string sql = "SELECT CTPN.MaGiong, CTPN.MaTC, CTPN.GiaNhap FROM ChiTietPN CTPN, PhieuNhap PN WHERE CTPN.MaPN = PN.MaPN AND PN.NgayNhap = '" + ngayNhap.ToString("yyyy-MM-dd HH:mm:ss.ff") + "'";
            return data.QuerySQL(sql);
        }

        //Thêm Linq
        public bool ThemLinq(int maPN, int maGiong, int maTC, decimal giaNhap)
        {
            try
            {
                ChiTietPN ctpn = new ChiTietPN();
                ctpn.MaPN = maPN;
                ctpn.MaGiong = maGiong;
                ctpn.MaTC = maTC;
                ctpn.GiaNhap = giaNhap;

                db.ChiTietPNs.InsertOnSubmit(ctpn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maTC)
        {
            try
            {
                var xoa = db.ChiTietPNs.Single(t => t.MaTC == maTC);
                db.ChiTietPNs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maGiong, int maTC, decimal giaNhap)
        {
            try
            {
                var update = db.ChiTietPNs.Single(t => t.MaTC == maTC);
                update.MaGiong = maGiong;
                update.GiaNhap = giaNhap;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(ChiTietPhieuNhapDTO info)
        {
            try
            {
                string sql = "INSERT INTO ChiTietPN(MaPN, MaGiong, MaTC, GiaNhap)" +
                " VALUES(" + info.MaPN + ", " + info.MaGiong + "," + info.MaTC + ", " + info.GiaNhap + ")";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Sua(ChiTietPhieuNhapDTO info, int maTC)
        {
            try
            {
                string sql = "UPDATE ChiTietPN SET MaPN = " + info.MaPN + ", MaGiong = " + info.MaGiong + ", GiaNhap = " + info.GiaNhap + " WHERE MaTC = " + maTC;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Xoa(ChiTietPhieuNhapDTO info)
        {
            try
            {
                string sql = "DELETE FROM ChiTietPN WHERE MaTC = " + info.MaTC;
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
