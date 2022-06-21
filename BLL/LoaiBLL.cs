using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class LoaiBLL
    {
        LoaiDAO data = new LoaiDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaLoai,
                                  TextBox txtTenLoai,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_TenLoai(tuKhoa);

            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", bS1, "MaLoai", false, DataSourceUpdateMode.Never);

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", bS1, "TenLoai", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }
        public DataTable DanhSach()
        {
            return data.DanhSach();
        }

        public List<Loai> LoadCboLoai(int maLoai)
        {
            return data.LoadCboLoai(maLoai);
        }

        //Load bảng Linq
        public List<Loai> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }



        //Thêm Linq
        public bool ThemLinq(string tenLoai)
        {
            if (data.ThemLinq(tenLoai) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maLoai)
        {
            if (data.XoaLinq(maLoai) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maLoai, string tenLoai)
        {
            if (data.UpdateLinq(maLoai, tenLoai) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(LoaiDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(LoaiDTO info, int maLoai)
        {
            if (data.Sua(info, maLoai))
            {
                return true;
            }
            return false;
            
        }

        public bool Xoa(LoaiDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
        }
    }
}
