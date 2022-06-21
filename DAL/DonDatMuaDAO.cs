using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class DonDatMuaDAO
    {
        Connect data = new Connect();
        QuanLyPetStoreDataContext db = new QuanLyPetStoreDataContext();

        public DataTable DsDDM()
        {
            string sql = "SELECT * FROM DonDatMua";
            return data.QuerySQL(sql);
        }


        public DataTable DonDatMua()
        {
            string sql = "SELECT * FROM DonDatMua";
            return data.QuerySQL(sql);
        }

        public DataTable DonDatMuaTheoMa(int maDDM)
        {
            string sql = "SELECT * FROM DonDatMua WHERE MaDDM = " + maDDM + "";
            return data.QuerySQL(sql);
        }


        public DataTable LayMaDDMMoiNhat()
        {
            string sql = "SELECT Top 1 MaDDM FROM DonDatMua ORDER BY MaDDM DESC";
            return data.QuerySQL(sql);
        }

        //Thêm Linq
        public bool ThemLinq(int maNCC, int maNV, DateTime createDate, DateTime ngayCapNhat, string noiDung)
        {
            try
            {
                DonDatMua ddm = new DonDatMua();
                ddm.MaNCC = maNCC;
                ddm.MaNV = maNV;
                ddm.CreateDate = createDate;
                ddm.NgayCapNhat = ngayCapNhat;
                ddm.NoiDung = noiDung;

                db.DonDatMuas.InsertOnSubmit(ddm);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Xoá Linq
        public bool XoaLinq(int maDDM)
        {
            try
            {
                var xoa = db.DonDatMuas.Single(t => t.MaDDM == maDDM);
                db.DonDatMuas.DeleteOnSubmit(xoa);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Update Linq
        public bool UpdateLinq(int maDDM, int maNCC, int maNV, DateTime createDate, DateTime ngayCapNhat, string noiDung)
        {
            try
            {
                var update = db.DonDatMuas.Single(t => t.MaDDM == maDDM);
                update.MaNV = maNV;
                update.MaNCC = maNCC;
                update.CreateDate = createDate;
                update.NgayCapNhat = ngayCapNhat;
                update.NoiDung = noiDung;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Them(DonDatMuaDTO info)
        {
            try
            {
                string sql = "INSERT INTO DonDatMua(MaNCC, MaNV, CreateDate, NgayCapNhat, NoiDung)" +
                " VALUES(" + info.MaNCC + ", '" + info.MaNV + "','" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', N'" + info.NoiDung + "')";
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Sua(DonDatMuaDTO info, int maDDM)
        {
            try
            {
                string sql = "UPDATE DonDatMua SET MaNCC = " + info.MaNCC + ", MaNV = "+info.MaNV+ ", CreateDate = '" + info.CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', NgayCapNhat = '" + info.NgayCapNhat.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', NoiDung = N'" + info.NoiDung + "' WHERE MaDDM = " + maDDM;
                data.ExecuteSQL(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Xoa(DonDatMuaDTO info)
        {
            try
            {
                string sql = "DELETE FROM DonDatMua WHERE MaDDM = " + info.MaDDM;
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
