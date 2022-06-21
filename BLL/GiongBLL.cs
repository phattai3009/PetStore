using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class GiongBLL
    {
        GiongDAO data = new GiongDAO();
        LoaiDAO dataLoai = new LoaiDAO();

        public void HienThiVaoDGV(BindingNavigator bN,
                                  DataGridView dGV,
                                  ComboBox cboMaLoai,
                                  TextBox txtMaGiong,
                                  TextBox txtTenGiong,
                                  NumericUpDown numSoLuongTon,
                                  RichTextBox txtMoTa,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_TenGiong(tuKhoa);

            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("SelectedValue", bS1, "MaLoai", false, DataSourceUpdateMode.Never);

            txtMaGiong.DataBindings.Clear();
            txtMaGiong.DataBindings.Add("Text", bS1, "MaGiong", false, DataSourceUpdateMode.Never);

            txtTenGiong.DataBindings.Clear();
            txtTenGiong.DataBindings.Add("Text", bS1, "TenGiong", false, DataSourceUpdateMode.Never);

            numSoLuongTon.DataBindings.Clear();
            numSoLuongTon.DataBindings.Add("Value", bS1, "SoLuongTon", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bS1, "MoTa", false, DataSourceUpdateMode.Never);


            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public void HienThiVaoComboBox(ComboBox cboGiong)
        {
            cboGiong.DataSource = dataLoai.DanhSach();
            cboGiong.ValueMember = "MaLoai";
            cboGiong.DisplayMember = "TenLoai";

        }
        public DataTable LayMaLoai(int maGiong)
        {
            return data.LayMaLoai(maGiong);
        }

        public DataTable DanhSach()
        {
            return data.DanhSach();
        }
        public DataTable DanhSach(int maGiong)
        {
            return data.DanhSach(maGiong);
        }

        public DataTable LoadCboGiong(int maLoai)
        {
            return data.LoadCboGiong(maLoai);
        }

        //Load bảng Linq
        public List<Giong> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }

        //Thêm Linq
        public bool ThemLinq(int maLoai, string tenGiong, int soLuongTon, string moTa)
        {
            if (data.ThemLinq(maLoai, tenGiong, soLuongTon, moTa) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maGiong)
        {
            if (data.XoaLinq(maGiong) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maLoai, int maGiong, string tenGiong, int soLuongTon, string moTa)
        {
            if (data.UpdateLinq(maLoai, maGiong, tenGiong, soLuongTon, moTa) == true)
            {
                return true;
            }
            return false;
        }


        public bool Them(GiongDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
            
        }

        public bool Sua(GiongDTO info,int maGiong)
        {
            if (data.Sua(info, maGiong))
            {
                return true;
            }
            return false;
            
        }

        public bool Xoa(GiongDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
            
        }
    }
}
