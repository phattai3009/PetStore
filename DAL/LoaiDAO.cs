using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class LoaiDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();
        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM Loai";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach(int maLoai)
        {
            string sql = "SELECT * FROM Loai Where MaLoai = " + maLoai + "";
            return data.QuerySQL(sql);
        }
        public DataTable DanhSach_TenLoai(string tenLoai)
        {
            string sql = "SELECT * FROM Loai WHERE TenLoai LIKE '%" + tenLoai + "%'";
            return data.QuerySQL(sql);
        }

        public List<Loai> LoadCboLoai(int maLoai)
        {
            return db.Loais.Where(t => t.MaLoai == maLoai).ToList<Loai>();
        }

        //Load Loai Linq
        public List<Loai> DanhSachLinq()
        {
            return db.Loais.Select(t => t).ToList();
        }

        //Thêm Linq
        public bool ThemLinq(string tenLoai)
        {
            try
            {
                Loai l = new Loai();
                l.TenLoai = tenLoai;
                db.Loais.InsertOnSubmit(l);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maLoai)
        {
            try
            {
                var xoa = db.Loais.Single(t => t.MaLoai == maLoai);
                db.Loais.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maLoai, string tenLoai)
        {
            try
            {
                var update = db.Loais.Single(t => t.MaLoai == maLoai);
                update.TenLoai = tenLoai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(LoaiDTO info)
        {
            try
            {
                string sql = "INSERT INTO Loai(TenLoai)" +
                " VALUES (N'" + info.TenLoai + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Sua(LoaiDTO info, int maLoai)
        {
            try
            {
                string sql = "UPDATE Loai SET TenLoai = N'" + info.TenLoai + "' WHERE MaLoai = " + maLoai;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Xoa(LoaiDTO info)
        {
            try
            {
                string sql = "DELETE FROM Loai WHERE MaLoai = " + info.MaLoai;
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
