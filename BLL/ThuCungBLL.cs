using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Drawing;
using System.Data;

namespace BLL
{
    public class ThuCungBLL
    {
        ThuCungDAO data = new ThuCungDAO();

        GiongDAO dataGiong = new GiongDAO();
        LoaiDAO dataLoai = new LoaiDAO();

        
        public void HienThiVaoDGV(
                                  DataGridView dGV,
                                  string tenTC)
        {
            BindingSource bS = new BindingSource();

            if (tenTC == "")
                bS.DataSource = data.DanhSachTC();
            else
                bS.DataSource = data.DanhSachTC(tenTC);

            dGV.DataSource = bS;
        }

        public void HienThiVaoDGV2(BindingNavigator bN,
                                  DataGridView dGV,
                                  ComboBox cboMaLoai,
                                  ComboBox cboMaGiong,
                                  TextBox txtMaTC,
                                  TextBox txtTenTC,
                                  TextBox txtGiaBan,
                                  TextBox txtAnh,
                                  DateTimePicker dtpNgayThem,
                                  //NumericUpDown numSoLuongTon,
                                  CheckBox chkMoi,
                                  RichTextBox txtMoTa,
                                  string tuKhoa)
        {
            BindingSource bS1 = new BindingSource();

            if (tuKhoa == "")
                bS1.DataSource = data.DanhSach();
            else
                bS1.DataSource = data.DanhSach_MaTC(tuKhoa);

            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("SelectedValue", bS1, "MaLoai", false, DataSourceUpdateMode.Never);

            cboMaGiong.DataBindings.Clear();
            cboMaGiong.DataBindings.Add("SelectedValue", bS1, "MaGiong", false, DataSourceUpdateMode.Never);

            txtMaTC.DataBindings.Clear();
            txtMaTC.DataBindings.Add("Text", bS1, "MaTC", false, DataSourceUpdateMode.Never);

            txtTenTC.DataBindings.Clear();
            txtTenTC.DataBindings.Add("Text", bS1, "TenTC", false, DataSourceUpdateMode.Never);


            CultureInfo info = new CultureInfo("vi-VN");
            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("Text", bS1, "GiaBan", false, DataSourceUpdateMode.Never);
            txtGiaBan.DataBindings[0].FormattingEnabled = true;
            txtGiaBan.DataBindings[0].FormatString = "c0";

            txtAnh.DataBindings.Clear();
            txtAnh.DataBindings.Add("Text", bS1, "Anh", false, DataSourceUpdateMode.Never);

            chkMoi.DataBindings.Clear();
            Binding gt = new Binding("Checked", bS1, "TrangThai", false, DataSourceUpdateMode.Never);
            gt.Format += (s, e) =>
            {
                e.Value = 1;
            };
            chkMoi.DataBindings.Add(gt);

            dtpNgayThem.DataBindings.Clear();
            dtpNgayThem.DataBindings.Add("Value", bS1, "NgayCapNhat", false, DataSourceUpdateMode.Never);

            //numSoLuongTon.DataBindings.Clear();
            //numSoLuongTon.DataBindings.Add("Value", bS1, "SoLuongTon", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bS1, "MoTa", false, DataSourceUpdateMode.Never);

            bN.BindingSource = bS1;
            dGV.DataSource = bS1;
        }

        public void HienThiVaoComboBox(ComboBox cboLoai, ComboBox cboGiong)
        {
            cboLoai.DataSource = dataLoai.DanhSach();
            cboLoai.ValueMember = "MaLoai";
            cboLoai.DisplayMember = "TenLoai";

            cboGiong.DataSource = dataGiong.DanhSach();
            cboGiong.ValueMember = "MaGiong";
            cboGiong.DisplayMember = "TenGiong";
        }

        public string LayGiaBanTC(int maTC)
        {
            return data.LayGiaBanTC(maTC);
        }

        public DataTable DanhSach()
        {
            return data.DanhSach();
        }

        public DataTable DanhSachTrangThai()
        {
            return data.DanhSachTrangThai();
        }


        public DataTable DanhSachTCTheoMa()
        {
            return data.DanhSachTCTheoMa();
        }

        public string LayTenTC(int maTC)
        {
            return data.LayTenTC(maTC);
        }

        public bool CapNhatGiongSoLuongTon(int maGiong)
        {
            var doi = data.CapNhatGiongSoLuongTon(maGiong);
            if (doi.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        public DataTable LayMaTCTheoNgay(DateTime createDate, int maGiong)
        {
            return data.LayMaTCTheoNgay(createDate, maGiong);
        }
        public DataTable DanhSachTCTheoMaTen(string maTenTC)
        {
            return data.DanhSachTCTheoMaTen(maTenTC);
        }
        public DataTable DanhSachTCTheoMa(int maTC)
        {
            return data.DanhSachTCTheoMa(maTC);
        }


        public DataTable DanhSachTCSell()
        {
            return data.DanhSachTCSell();
        }

        public DataTable DanhSachTCSell(int maLoai)
        {
            return data.DanhSachTCSell(maLoai);
        }

        public DataTable DanhSachTCSell(int maLoai,decimal giaBan)
        {
            return data.DanhSachTCSell(maLoai, giaBan);
        }

        //Load bảng Linq
        public List<ThuCung> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }

        //Thêm Linq
        public bool ThemLinq(string tenTC, decimal giaBan, string moTa, string anh, DateTime createDate, DateTime ngayCapNhat, int maGiong, int maLoai, int trangThai)
        {
            if (data.ThemLinq(tenTC, giaBan, moTa, anh, createDate, ngayCapNhat, maGiong, maLoai, trangThai) == true)
            {
                return true;
            }
            return false;
        }

        //Xoá Linq
        public bool XoaLinq(int maTC)
        {
            if (data.XoaLinq(maTC) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateLinq(int maTC, string tenTC, decimal giaBan, string moTa, string anh, DateTime createDate, DateTime ngayCapNhat, int maGiong, int maLoai, int trangThai)
        {
            if (data.UpdateLinq(maTC, tenTC, giaBan, moTa, anh, createDate, ngayCapNhat, maGiong,maLoai,trangThai) == true)
            {
                return true;
            }
            return false;
        }

        public bool UpdateLinqChiTiet(int maTC, string tenTC, decimal giaBan, DateTime ngayCapNhat, int maGiong, int maLoai)
        {
            if (data.UpdateLinqChiTiet(maTC, tenTC, giaBan, ngayCapNhat, maGiong, maLoai) == true)
            {
                return true;
            }
            return false;
        }

        //Update Linq
        public bool UpdateNgayBan(int maTC, DateTime ngayBan)
        {
            if (data.UpdateNgayBan(maTC, ngayBan) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(ThuCungDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false; 
        }

        public bool ThemTCChiTiet(ThuCungDTO info)
        {
            if (data.ThemTCChiTiet(info))
            {
                return true;
            }
            return false;
        }

        public bool Sua(ThuCungDTO info, int maTC)
        {
            if (data.Sua(info, maTC))
            {
                return true;
            }
            return false;
           
        }

        public bool SuaTrangThai(ThuCungDTO info, int maTC)
        {
            if (data.SuaTrangThai(info, maTC))
            {
                return true;
            }
            return false;
        }

        public bool SuaThuCungChiTiet(ThuCungDTO info, int maTC)
        {
            if (data.SuaThuCungChiTiet(info, maTC))
            {
                return true;
            }
            return false;

        }

        public void Xoa(ThuCungDTO info)
        {
            data.Xoa(info);
        }
    }
}
