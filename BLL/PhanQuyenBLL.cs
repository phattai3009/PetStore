using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Windows.Forms;

namespace BLL
{
    public class PhanQuyenBLL
    {
        PhanQuyenDAO data = new PhanQuyenDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaQuyen,
                                  TextBox txtTenQuyen,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_TenQuyen(tuKhoa);

            txtMaQuyen.DataBindings.Clear();
            txtMaQuyen.DataBindings.Add("Text", bS1, "MaQuyen", false, DataSourceUpdateMode.Never);

            txtTenQuyen.DataBindings.Clear();
            txtTenQuyen.DataBindings.Add("Text", bS1, "TenQuyen", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        //Load bảng Linq
        public List<PhanQuyen> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }

        //Thêm Linq
        public bool ThemLinq(string tenQuyen)
        {
            if (data.ThemLinq(tenQuyen) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int id)
        {
            if (data.XoaLinq(id) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maQuyen, string tenQuyen)
        {
            if (data.UpdateLinq(maQuyen, tenQuyen) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(PhanQuyenDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
            
        }

        public bool Sua(PhanQuyenDTO info, int maQuyen)
        {
            if (data.Sua(info, maQuyen))
            {
                return true;
            }
            return false;
            
        }

        public bool Xoa(PhanQuyenDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
            
        }
    }
}
