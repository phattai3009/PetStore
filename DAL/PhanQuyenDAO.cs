using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;


namespace DAL
{
    public class PhanQuyenDAO
    {
        private Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable DanhSach()
        {
            string sql = "SELECT * FROM PhanQuyen";
            return data.QuerySQL(sql);
        }

        public DataTable DanhSach_TenQuyen(string tenQuyen)
        {
            string sql = "SELECT * FROM PhanQuyen Where TenQuyen LIKE N'%" + tenQuyen + "%'";
            return data.QuerySQL(sql);
        }

        //Load PhanQuyen Linq
        public List<PhanQuyen> DanhSachLinq()
        {
            return db.PhanQuyens.Select(t => t).ToList();
        }

        //Thêm Linq
        public bool ThemLinq(string tenQuyen)
        {
            try
            {
                PhanQuyen pq = new PhanQuyen();
                pq.TenQuyen = tenQuyen;
                db.PhanQuyens.InsertOnSubmit(pq);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maQuyen)
        {
            try
            {
                var xoa = db.PhanQuyens.Single(t => t.MaQuyen == maQuyen);
                db.PhanQuyens.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maQuyen, string tenQuyen)
        {
            try
            {
                var update = db.PhanQuyens.Single(t => t.MaQuyen == maQuyen);
                update.TenQuyen = tenQuyen;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(PhanQuyenDTO info)
        {
            try
            {
                string sql = "INSERT INTO PhanQuyen(TenQuyen) VALUES (N'" + info.TenQuyen + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {

                return false;
            }
            
        }

        public bool Sua(PhanQuyenDTO info, int maQuyen)
        {
            try
            {
                string sql = "UPDATE PhanQuyen SET TenQuyen = N'" + info.TenQuyen + "' WHERE MaQuyen = " + maQuyen;
                data.ExecuteSQL(sql);
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        public bool Xoa(PhanQuyenDTO info)
        {
            try
            {
                string sql = "DELETE FROM PhanQuyen WHERE MaQuyen = " + info.MaQuyen;
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
