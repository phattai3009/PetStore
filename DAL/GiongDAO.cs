using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class GiongDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();
        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM Giong";
            return data.QuerySQL(sql);
        }
        public DataTable DanhSach(int maGiong)
        {
            string sql = "SELECT * FROM Giong where MaGiong = " + maGiong + "";
            return data.QuerySQL(sql);
        }

        public DataTable LayMaLoai(int maGiong)
        {
            string sql = "SELECT * FROM Giong Where maGiong = " + maGiong + "";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_TenGiong(string tenGiong)
        {
            string sql = "SELECT * FROM Giong WHERE TenGiong LIKE '%" + tenGiong + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable LoadCboGiong(int maLoai)
        {
            string sql = "SELECT * FROM Giong WHERE MaLoai = " + maLoai + "";
            return data.QuerySQL(sql);
        }

        public List<Giong> LoadCboGiongLinq(int maLoai)
        {
            return db.Giongs.Where(t => t.MaLoai == maLoai).ToList<Giong>();
        }

        //Load Giong Linq
        public List<Giong> DanhSachLinq()
        {
            return db.Giongs.Select(t => t).ToList();
        }

        //Thêm Linq
        public bool ThemLinq(int maLoai, string tenGiong,int soLuongTon, string moTa)
        {
            try
            {
                Giong g = new Giong();
                g.MaLoai = maLoai;
                g.TenGiong = tenGiong;
                g.SoLuongTon = soLuongTon;
                g.MoTa = moTa;
                db.Giongs.InsertOnSubmit(g);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maGiong)
        {
            try
            {
                var xoa = db.Giongs.Single(t => t.MaGiong == maGiong);
                db.Giongs.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maLoai, int maGiong, string tenGiong, int soLuongTon, string moTa)
        {
            try
            {
                var update = db.Giongs.Single(t => t.MaGiong == maGiong);
                update.MaLoai = maLoai;
                update.TenGiong = tenGiong;
                update.SoLuongTon = soLuongTon;
                update.MoTa = moTa;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(GiongDTO info)
        {
            try
            {
                string sql = "INSERT INTO Giong(MaLoai, TenGiong, SoLuongTon, MoTa)" +
                " VALUES (" + info.MaLoai + ", N'" + info.TenGiong + "', " + info.SoLuongTon + ", N'" + info.MoTa + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Sua(GiongDTO info, int maGiong)
        {
            try
            {
                string sql = "UPDATE Giong SET MaLoai = '" + info.MaLoai + "', TenGiong = N'" + info.TenGiong + "', SoLuongTon = '" + info.SoLuongTon + "', MoTa = N'" + info.MoTa + "' WHERE MaGiong = " + maGiong;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Xoa(GiongDTO info)
        {
            try
            {
                string sql = "DELETE FROM Giong WHERE MaGiong = " + info.MaGiong;
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
