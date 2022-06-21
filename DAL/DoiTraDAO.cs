using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class DoiTraDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable DoiTra()
        {
            string sql = "SELECT * FROM DoiTra";
            return data.QuerySQL(sql);
        }

        public DataTable DoiTra(string tuKhoa)
        {
            string sql = "SELECT * FROM DoiTra WHERE MaDH = " + tuKhoa + "";
            return data.QuerySQL(sql);
        }

        public DataTable KiemTraMaDHBiDoi(int maDH)
        {
            string sql = "SELECT * FROM DonHang Where MaDH = " + maDH + " AND TrangThai = 2";
            return data.QuerySQL(sql);
        }

        public DataTable KiemTraMaDHTraHang(int maDH)
        {
            string sql = "SELECT * FROM DonHang Where MaDH = " + maDH + " AND TrangThai = 3";
            return data.QuerySQL(sql);
        }

        public bool Them(DoiTraDTO info)
        {
            try
            {
                string sql = "INSERT INTO DoiTra(MaDH, MaNV, NgayDoi, LyDo, TinhTrangThuCung)" +
                " VALUES(" + info.MaDH + ", " + info.MaNV + ",'" + info.NgayDoi.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', N'" + info.LyDo + "', N'" + info.TinhTrangThuCung + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Sua(DoiTraDTO info, int maDT)
        {
            try
            {
                string sql = "UPDATE DoiTra SET MaDH = " + info.MaDH + ", MaNV = " + info.MaNV + ", NgayDoi = '" + info.NgayDoi.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', LyDo = N'" + info.LyDo + "', TinhTrangThuCung = N'" + info.TinhTrangThuCung + "' WHERE MaDT = " + maDT;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Xoa(DoiTraDTO info)
        {
            try
            {
                string sql = "DELETE FROM DoiTra WHERE maDT = " + info.MaDT;
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
