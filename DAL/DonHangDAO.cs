using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class DonHangDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();


        public DataTable DonHangSell(int maKH, DateTime createdDate, int maNV)
        {
            string sql = "SELECT MaDH FROM DonHang Where MaKH = " + maKH + " AND createdDate = '" + createdDate.ToString("yyyy-MM-dd HH:mm:ss:fff") + "' AND MaNV = " + maNV + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang()
        {
            string sql = "SELECT * FROM DonHang";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang(int maDH)
        {
            string sql = "SELECT * FROM DonHang WHERE MaDH = " + maDH + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_CTDH()
        {
            string sql = "SELECT DH.*, CTDH.MaTC, TC.TenTC FROM DonHang DH, ChiTietDonHang CTDH, ThuCung TC where DH.MaDH = CTDH.MaDH AND TC.MaTC = CTDH.MaTC";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_CTDH(DateTime ngaydau, DateTime ngaycuoi)
        {
            string sql = "SELECT DH.*, CTDH.MaTC, TC.TenTC FROM DonHang DH, ChiTietDonHang CTDH, ThuCung TC where DH.MaDH = CTDH.MaDH AND TC.MaTC = CTDH.MaTC AND DH.CreatedDate >= N'" + ngaydau.ToString("yyyy-MM-dd") + "' AND DH.CreatedDate <= N'" + ngaycuoi.ToString("yyyy-MM-dd") + "' ";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_MaDH()
        {
            string sql = "SELECT MaDH, CreatedDate FROM DonHang";
            return data.QuerySQL(sql);
        }

        public DataTable ThanhTienTheoMaDH(int maDH)
        {
            string sql = "SELECT TongTien FROM DonHang Where MaDH = " + maDH + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_Report(int maDH)
        {
            string sql = "SELECT ChiTietDonHang.MaDH, ThuCung.TenTC, ThuCung.GiaBan, ChiTietDonHang.ThanhTien FROM ChiTietDonHang INNER JOIN ThuCung ON ChiTietDonHang.MaTC = ThuCung.MaTC AND ChiTietDonHang.MaDH = " + maDH + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_SoDT(string soDT)
        {
            string sql = "SELECT * FROM DonHang where Phone LIKE '%" + soDT + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang(string maNV)
        {
            string sql = "SELECT * FROM DonHang where MADH = " + maNV + "";
            return data.QuerySQL(sql);
        }

        public DataTable DonHang_maKH(string maKH)
        {
            string sql = "SELECT * FROM DonHang where MAKH = " + maKH + "";
            return data.QuerySQL(sql);
        }

        public DataTable ThongKeDonHang(DateTime frmdate, DateTime todate)
        {
            string sql = "EXEC sp_ThongKeDonHang '" + frmdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "'";
            return data.QuerySQL(sql);
        }

        public DataTable ThongKeDoanhThuCuaHang(DateTime frmdate, DateTime todate)
        {
            string sql = "EXEC sp_ThongKeDoanhThuCuaHang '" + frmdate.ToString("yyyy-MM-dd") + "', '" + todate.ToString("yyyy-MM-dd") + "'";
            return data.QuerySQL(sql);
        }

        //Load DonHang Linq
        public List<DonHang> DanhSachLinq()
        {
            return db.DonHangs.Select(t => t).ToList();
        }

        public ThuCung LayTCTheoMa(int maTC)
        {
            return db.ThuCungs.SingleOrDefault(t => t.MaTC == maTC);
        }

        //Thêm Linq
        public bool ThemLinq(int maNV, string createdDate, int maKH, string nguoiNhan, string email, string phone, string address, decimal tongTien, int trangThai)
        {
            try
            {
                DonHang dh = new DonHang();
                dh.MaNV = maNV;
                dh.CreatedDate = DateTime.Parse(createdDate);
                dh.MaKH = maKH;
                dh.NguoiNhan = nguoiNhan;
                dh.Email = email;
                dh.Phone = phone;
                dh.Address = address;
                dh.TongTien = tongTien;
                dh.TrangThai = trangThai;

                db.DonHangs.InsertOnSubmit(dh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maDH)
        {
            try
            {
                var xoa = db.DonHangs.Single(t => t.MaDH == maDH);
                db.DonHangs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maDH, int maNV, string createdDate, int maKH, string nguoiNhan, string email, string phone, string address, decimal tongTien, int trangThai)
        {
            try
            {
                var update = db.DonHangs.Single(t => t.MaDH == maDH);
                update.MaNV = maNV;
                update.CreatedDate = DateTime.Now;
                update.MaKH = maKH;
                update.NguoiNhan = nguoiNhan;
                update.Email = email;
                update.Phone = phone;
                update.Address = address;
                update.TongTien = tongTien;
                update.TrangThai = trangThai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(DonHangDTO info)
        {
            try
            {
                string sql = "INSERT INTO DonHang(MaNV, CreatedDate, MaKH, NguoiNhan, Email, Phone, Address, TongTien, TrangThai)" +
                   " VALUES(" + info.MaNV + ", '" + info.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "'," + info.MaKH + ", N'" + info.NguoiNhan + "', N'" + info.Email + "', N'" + info.Phone + "', N'" + info.Address + "', CAST(N'" + info.TongTien + "'AS Decimal(18, 0)), '" + info.TrangThai + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool SuaDonHang(DonHangDTO info, int maDH)
        {
            try
            {
                string sql = "UPDATE DonHang SET MaNV =" + info.MaNV + ", CreatedDate = '" + info.CreatedDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', MaKH = " + info.MaKH + ", NguoiNhan = N'" + info.NguoiNhan + "', Email =  N'" + info.Email + "',Phone = N'" + info.Phone + "', Address = N'" + info.Address + "', TongTien = CAST(N'" + info.TongTien + "'AS Decimal(18, 0)), TrangThai = '" + info.TrangThai + "' WHERE MaDH = " + maDH;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Sua(DonHangDTO info, int maDH)
        {
            try
            {
                string sql = "UPDATE DonHang SET TrangThai = '" + info.TrangThai + "' WHERE MaDH = " + maDH;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Xoa(DonHangDTO info)
        {
            try
            {
                string sql = "DELETE FROM DonHang WHERE MaDH = " + info.MaDH;
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
