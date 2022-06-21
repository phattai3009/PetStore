using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class ThuCungDAO
    {
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();
        private Connect data = new Connect();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM ThuCung";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTrangThai()
        {
            string sql = "SELECT * FROM ThuCung Where TrangThai = 0";
            return data.QuerySQL(sql);
        }

        public string LayTenTC(int maTC)
        {
            return db.ThuCungs.SingleOrDefault(t => t.MaTC == maTC).TenTC;
        }

        public string LayGiaBanTC(int maTC)
        {
            return db.ThuCungs.SingleOrDefault(t => t.MaTC == maTC).GiaBan.ToString();
        }

        public DataTable DanhSachTCTheoMa(int maTC)
        {
            string sql = "SELECT * FROM ThuCung WHERE MaTC = " + maTC + "";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTCTheoMa()
        {
            string sql = "SELECT Top 1 MaTC FROM ThuCung ORDER BY MaTC DESC";
            return data.QuerySQL(sql);
        }

        public DataTable LayMaTCTheoNgay(DateTime createDate, int maGiong)
        {
            string sql = "SELECT * FROM ThuCung WHERE CreateDate = '" + createDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "' AND MaGiong = " + maGiong + "";
            return data.QuerySQL(sql);
        }


        public DataTable DanhSachTCTheoMaTen(string maTenTC)
        {
            string sql = "SELECT * FROM ThuCung WHERE MaTC LIKE '%" + maTenTC + "%' OR TenTC LIKE '%" + maTenTC + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable CapNhatGiongSoLuongTon(int maGiong)
        {

            string sql = "EXEC sp_CapNhatGiongSoLuongTon " + maGiong + "";
            return data.QuerySQL(sql);
        }

        //Load bảng Linq
        public List<ThuCung> DanhSachLinq()
        {
            return db.ThuCungs.Select(t => t).ToList();
        }


        public DataTable DanhSachTC()
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, TrangThai FROM ThuCung";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTCSell()
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, Anh, MoTa FROM ThuCung Where TrangThai = 0";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTCSell(int maLoai)
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, Anh, MoTa FROM ThuCung Where TrangThai = 0 AND MaLoai = " + maLoai + "";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTCSell(int maLoai, decimal giaBan)
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, Anh, MoTa FROM ThuCung Where TrangThai = 0 AND MaLoai = " + maLoai + " AND GiaBan BETWEEN 0 AND " + giaBan + "";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSachTC(string tenTC)
        {
            string sql = "SELECT MaTC, TenTC, GiaBan, TrangThai FROM ThuCung WHERE TenTC LIKE '%" + tenTC + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_MaTC(string tenTC)
        {
            string sql = "SELECT * FROM ThuCung WHERE TenTC LIKE '%" + tenTC + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable ThongKeThuCungBanChay(DateTime frmdate, DateTime todate)
        {
            string sql = "EXEC sp_ThongKeThuCungBanChay '" + frmdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "'";
            return data.QuerySQL(sql);
        }

        //Thêm Linq
        public bool ThemLinq(string tenTC, decimal giaBan, string moTa, string anh, DateTime createDate, DateTime ngayCapNhat, int maGiong, int maLoai, int trangThai)
        {
            try
            {
                ThuCung tc = new ThuCung();
                tc.TenTC = tenTC;
                tc.GiaBan = giaBan;
                tc.MoTa = moTa;
                tc.Anh = anh;
                tc.CreateDate = createDate;
                tc.NgayCapNhat = ngayCapNhat;
                tc.MaGiong = maGiong;
                tc.MaLoai = maLoai;
                tc.TrangThai = trangThai;
                db.ThuCungs.InsertOnSubmit(tc);
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
                var xoa = db.ThuCungs.Single(t => t.MaTC == maTC);
                db.ThuCungs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maTC, string tenTC, decimal giaBan, string moTa, string anh, DateTime createDate, DateTime ngayCapNhat, int maGiong, int maLoai, int trangThai)
        {
            try
            {
                var update = db.ThuCungs.Single(t => t.MaTC == maTC);
                update.TenTC = tenTC;
                update.GiaBan = giaBan;
                update.MoTa = moTa;
                update.Anh = anh;
                update.CreateDate = createDate;
                update.NgayCapNhat = ngayCapNhat;
                update.MaGiong = maGiong;
                update.MaLoai = maLoai;
                update.TrangThai = trangThai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinqChiTiet(int maTC, string tenTC, decimal giaBan, DateTime ngayCapNhat, int maGiong, int maLoai)
        {
            try
            {
                var update = db.ThuCungs.Single(t => t.MaTC == maTC);
                update.TenTC = tenTC;
                update.GiaBan = giaBan;
                update.NgayCapNhat = ngayCapNhat;
                update.MaGiong = maGiong;
                update.MaLoai = maLoai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateNgayBan(int maTC, DateTime ngayBan)
        {
            try
            {
                var update = db.ThuCungs.Single(t => t.MaTC == maTC);
                update.NgayBan = ngayBan;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(ThuCungDTO info)
        {
            try
            {
                string sql = "INSERT INTO ThuCung(TenTC, GiaBan, MoTa, Anh, CreateDate, NgayCapNhat, NgayBan, MaGiong, MaLoai, TrangThai) " +
                   "VALUES(N'" + info.TenTC + "', " + info.GiaBan + ", N'" + info.MoTa + "', N'" + info.Anh + "'" +
                   ", N'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', N'" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', N'" + info.NgayBan.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + info.MaGiong + ", " + info.MaLoai + ", '" + info.TrangThai + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch 
            {
                return false;               
            }
            
        }

        public bool ThemTCChiTiet(ThuCungDTO info)
        {
            try
            {
                string sql = "INSERT INTO ThuCung(TenTC, GiaBan, Anh, CreateDate, NgayCapNhat, MaGiong, MaLoai, TrangThai) " +
                   "VALUES(N'" + info.TenTC + "', " + info.GiaBan + ", N'" + info.Anh + "'" +
                   ", N'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', N'" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + info.MaGiong + ", " + info.MaLoai + ", " + info.TrangThai + ")";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Sua(ThuCungDTO info, int maTC)
        {
            try
            {
                string sql = "UPDATE ThuCung SET TenTC = N'" + info.TenTC + "', GiaBan = " + info.GiaBan + "" +
               ", MoTa = N'" + info.MoTa + "', Anh = N'" + info.Anh + "', NgayCapNhat = N'" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
               " MaGiong = " + info.MaGiong + ", MaLoai = " + info.MaLoai + ", TrangThai = '" + info.TrangThai + "' WHERE MaTC = " + maTC;
                data.ExecuteSQL(sql);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool SuaThuCungChiTiet(ThuCungDTO info, int maTC)
        {
            try
            {
                string sql = "UPDATE ThuCung SET TenTC = N'" + info.TenTC + "', GiaBan = " + info.GiaBan + "" +
               ", Anh = N'" + info.Anh + "', NgayCapNhat = N'" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " +
               " MaGiong = " + info.MaGiong + ", MaLoai = " + info.MaLoai + ", TrangThai = " + info.TrangThai + " WHERE MaTC = " + maTC;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaTrangThai(ThuCungDTO info, int maTC)
        {
            try
            {
                string sql = "UPDATE ThuCung SET TrangThai = " + info.TrangThai + " WHERE MaTC = " + maTC;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Xoa(ThuCungDTO info)
        {
            string sql = "DELETE FROM ThuCung WHERE MaTC = " + info.MaTC;
            data.ExecuteSQL(sql);
        }
    }
}
