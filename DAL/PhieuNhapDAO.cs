using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class PhieuNhapDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable PhieuNhap()
        {
            string sql = "SELECT * FROM PhieuNhap";
            return data.QuerySQL(sql);
        }

        public DataTable PhieuNhapTheoMa(int maPN)
        {
            string sql = "SELECT * FROM PhieuNhap WHERE MaPN = " + maPN + "";
            return data.QuerySQL(sql);
        }

        public DataTable LayMaPNTheoNgay(DateTime ngayNhap)
        {
            string sql = "SELECT MaPN FROM PhieuNhap WHERE NgayNhap = '" + ngayNhap.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
            return data.QuerySQL(sql);
        }

        public DataTable LayMaDDMTheoNgay(DateTime ngayNhap)
        {
            string sql = "SELECT MaDDM FROM PhieuNhap WHERE NgayNhap = '" + ngayNhap.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'";
            return data.QuerySQL(sql);
        }

        public DataTable PhieuNhapChiTiet()
        {
            string sql = "SELECT MaPN, MaDDM, NgayNhap, TongSLNhap, TongTienNhap FROM PhieuNhap";
            return data.QuerySQL(sql);
        }

        //Thêm Linq
        public bool ThemLinq(int maDDM, int maNV, DateTime ngayNhap, DateTime ngayCapNhat, string noiDung)
        {
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.MaDDM = maDDM;
                pn.MaNV = maNV;
                pn.NgayNhap = ngayNhap;
                pn.NgayCapNhat = ngayCapNhat;
                pn.NoiDung = noiDung;

                db.PhieuNhaps.InsertOnSubmit(pn);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maPN)
        {
            try
            {
                var xoa = db.PhieuNhaps.Single(t => t.MaPN == maPN);
                db.PhieuNhaps.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maPN, int maDDM, int maNV, DateTime ngayCapNhat, string noiDung)
        {
            try
            {
                var update = db.PhieuNhaps.Single(t => t.MaPN == maPN);
                update.MaDDM = maDDM;
                update.MaNV = maNV;
                update.NgayCapNhat = ngayCapNhat;
                update.NoiDung = noiDung;
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                string ma = e.ToString();
                return false;
            }
        }

        public bool Them(PhieuNhapDTO info)
        {
            try
            {
                string sql = "INSERT INTO PhieuNhap(MaDDM, MaNV, NgayNhap, NgayCapNhat, NoiDung)" +
                " VALUES(" + info.MaDDM + ", " + info.MaNV + ",'" + info.NgayNhap.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', N'" + info.NoiDung + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Sua(PhieuNhapDTO info, int maPN)
        {
            try
            {
                string sql = "UPDATE PhieuNhap SET MaDDM = " + info.MaDDM + ", MaNV = " + info.MaNV + ", NgayCapNhat = '" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', NoiDung = N'" + info.NoiDung + "' WHERE MaPN = " + maPN;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Xoa(PhieuNhapDTO info)
        {
            try
            {
                string sql = "DELETE FROM PhieuNhap WHERE MaPN = " + info.MaPN;
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
