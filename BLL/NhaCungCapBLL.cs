using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Windows.Forms;
using System.Data;

namespace BLL
{
    public class NhaCungCapBLL
    {
        NhaCungCapDAO data = new NhaCungCapDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  TextBox txtMaNCC,
                                  TextBox txttenNCC,
                                  TextBox txtEmail,
                                  TextBox txtSDT,
                                  TextBox txtDiaChi,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.NhaCungCap();
            else
                bS1.DataSource = data.NhaCungCap2(tuKhoa);

            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", bS1, "MaNCC", false, DataSourceUpdateMode.Never);

            txttenNCC.DataBindings.Clear();
            txttenNCC.DataBindings.Add("Text", bS1, "TenNCC", false, DataSourceUpdateMode.Never);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS1, "Email", false, DataSourceUpdateMode.Never);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bS1, "Phone", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS1, "Address", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public DataTable NhaCungCap()
        {
            return data.NhaCungCap();
        }
        public DataTable NhaCungCap(int maNCC)
        {
            return data.NhaCungCap(maNCC);
        }

        //Xoá Linq
        public bool ThemLinq(string tenNCC, string phone, string email, string address)
        {
            if (data.ThemLinq(tenNCC, phone, email, address) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maNCC)
        {
            if (data.XoaLinq(maNCC) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool UpdateLinq(int maNCC, string tenNCC, string phone, string email, string address)
        {
            if (data.UpdateLinq(maNCC, tenNCC, phone, email, address) == true)
            {
                return true;
            }
            return false;
        }

        public void Them(NhaCungCapDTO info)
        {
            data.Them(info);
        }
    }
}
