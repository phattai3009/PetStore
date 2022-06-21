using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class NhanVienDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM NhanVien";
            return data.QuerySQL(sql);
        }

        //Load Danh Sách UserAdmin Linq
        public List<NhanVien> DanhSachLinq()
        {
            return db.NhanViens.Select(t => t).ToList();
        }

        public List<NhanVien> KiemTraTaoTaiKhoan(string taiKhoan)
        {
            return db.NhanViens.Where(t => t.UserName == taiKhoan).ToList();
        }

        public DataTable DanhSach_Ten(string tenNV)
        {
            string sql = "SELECT * FROM NhanVien where HoTen LIKE '%" + tenNV + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable ChiTiet(string userName, string password)
        {
            string sql = "SELECT * FROM NhanVien WHERE UserName = '" + userName + "' AND Password = '" + password + "'";
            return data.QuerySQL(sql);
        }

        public DataTable DoiMatKhau(int manv, string matkhaumoi)
        {

            string sql = "EXEC sp_DoiMatKhau " + manv + ", N'" + matkhaumoi + "'";
            return data.QuerySQL(sql);
        }

        public DataTable LayThongTinTong(int manv, int thang, int nam)
        {
            string sql = "EXEC sp_LayThongTinTong " + manv + ", " + thang + ", " + nam + "";
            return data.QuerySQL(sql);
        }

        public DataTable BaoCaoDoanhThuCuaHang(int manv, int thang, int nam)
        {
            string sql = "EXEC sp_BaoCaoDoanhThuCuaHang  " + manv + ", " + thang + ", " + nam + "";
            return data.QuerySQL(sql);
        }

        //Thêm Linq
        public bool ThemLinq(string userName, string password, string name, string cmnd, DateTime ngaySinh, string address, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong)
        {
            try
            {
                NhanVien user = new NhanVien();
                user.UserName = userName;
                user.Password = password;
                user.HoTen = name;
                user.CMND = cmnd;
                user.NgaySinh = ngaySinh;
                user.Address = address;
                user.Email = email;
                user.Phone = phone;
                user.CreateDate = createDate;
                user.MaQuyen = maQuyen;
                user.TienLuong = tienLuong;
                db.NhanViens.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int id)
        {
            try
            {
                var xoa = db.NhanViens.Single(t => t.MaNV == id);
                db.NhanViens.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int id, string userName, string password, string name, string cmnd, DateTime ngaySinh, string address, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong,DateTime timeLogout)
        {
            try
            {
                var update = db.NhanViens.Single(t => t.MaNV == id);
                update.UserName = userName;
                update.Password = password;
                update.HoTen = name;
                update.CMND = cmnd;
                update.NgaySinh = ngaySinh;
                update.Address = address;
                update.Email = email;
                update.Phone = phone;
                update.CreateDate = createDate;
                update.MaQuyen = maQuyen;
                update.TienLuong = tienLuong;
                update.TimeLogout = timeLogout; 
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false; 
            }
        }



        public bool Them(NhanVienDTO info)
        {
            try
            {
                string sql = "INSERT INTO NhanVien(UserName, Password, HoTen, CMND, NgaySinh, Address, Email, Phone, CreateDate, MaQuyen, TienLuong) " +
                "VALUES(N'" + info.UserName + "', N'" + info.Password + "', N'" + info.HoTen + "', '" + info.Cmnd + "'" +
                ", N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', N'" + info.Address + "', N'" + info.Email + "', N'" + info.Phone + "', N'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + info.MaQuyen + ", " + info.TienLuong + ")";
                data.ExecuteSQL(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Sua(NhanVienDTO info, int maNV)
        {
            try
            {
                string sql = "UPDATE NhanVien SET UserName = N'" + info.UserName + "', Password = N'" + info.Password + "'" +
               ", HoTen = N'" + info.HoTen + "', CMND = '" + info.Cmnd + "', NgaySinh = N'" + info.NgaySinh.ToString("yyyy-MM-dd") + "', Address = N'" + info.Address + "'" +
               ", Email = N'" + info.Email + "', Phone = N'" + info.Phone + "', CreateDate = N'" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', MaQuyen = " + info.MaQuyen + ", TienLuong = " + info.TienLuong + " WHERE MaNV = " + maNV;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public bool Xoa(NhanVienDTO info)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNV = " + info.MaNV;
                data.ExecuteSQL(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
