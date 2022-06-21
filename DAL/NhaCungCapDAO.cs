using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class NhaCungCapDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable NhaCungCap()
        {
            string sql = "SELECT * FROM NhaCungCap";
            return data.QuerySQL(sql);
        }

        public DataTable NhaCungCap2(string tuKhoa)
        {
            string sql = "SELECT * FROM NhaCungCap WHERE TenNCC LIKE N'%" + tuKhoa + "%'";
            return data.QuerySQL(sql);
        }

        public DataTable NhaCungCap(int maNCC)
        {
            string sql = "SELECT * FROM NhaCungCap Where MaNCC = " + maNCC + "";
            return data.QuerySQL(sql);
        }


        //Thêm Linq
        public bool ThemLinq(string tenNCC, string phone, string email, string address)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.TenNCC = tenNCC;
                ncc.Email = email;
                ncc.Phone = phone;
                ncc.Address = address;


                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maNCC)
        {
            try
            {
                var xoa = db.NhaCungCaps.Single(t => t.MaNCC == maNCC);
                db.NhaCungCaps.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maNCC, string tenNCC, string phone, string email, string address)
        {
            try
            {
                var update = db.NhaCungCaps.Single(t => t.MaNCC == maNCC);
                update.TenNCC = tenNCC;
                update.Email = email;
                update.Phone = phone;
                update.Address = address;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Them(NhaCungCapDTO info)
        {
            string sql = "INSERT INTO NhaCungCap(TenNCC, Phone, Email, Address)" + " VALUES (N'" + info.TenNCC + "', '" + info.Phone + "', N'" + info.Email + "', N'" + info.Address + "')";
            data.ExecuteSQL(sql);
        }
    }
}
