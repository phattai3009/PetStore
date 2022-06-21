using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DTO;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
    public class NhanVienBLL
    {
        public static int frmDonDatMua = 0;
        public static int frmQLNhaphangMaNV = 0;
        public static string frmMainhoVaTen = "";
        public static int frmMainquyenHan = 0;
        public static int frmMainmaNV = 0;
        public static int frmDonHangmaNV = 0;
        public static int frmDoiMKmaNV = 0;
        public static string frmDoiMKtaiKhoan = "";
        public static int frmDetailUsermaNV = 0;
        public static string frmDetailUserhoTen = "";
        public static int frmDetailUsermaQuyen = 0;
        public static DateTime frmDetailUserngaySinh = DateTime.Now;
        public static string frmDetailUsertaiKhoan = "";
        public static int frmDetailUsertienLuong = 0;
        public static string frmDetailUsercmnd = "";
        public static int frmKhachHangmaQuyen = 0;


        NhanVienDAO data = new NhanVienDAO();
        PhanQuyenDAO dataPhanQuyen = new PhanQuyenDAO();

        public void HienThiVaoDGV(BindingNavigator bN, 
                                  DataGridView dGV,
                                  TextBox txtID,
                                  TextBox txtUserName,
                                  TextBox txtPassword,
                                  TextBox txtHoTen,
                                  TextBox txtCMND,
                                  DateTimePicker dtpNgaySinh,
                                  DateTimePicker dtpNgayTao,
                                  TextBox txtDiaChi,
                                  TextBox txtEmail,
                                  TextBox txtDienThoai,
                                  ComboBox cboMaQuyen,
                                  TextBox txtTienLuong,
                                  string tuKhoa)
        {
            BindingSource bS = new BindingSource();

            if (tuKhoa == "")
                bS.DataSource = data.DanhSach();
            else
                bS.DataSource = data.DanhSach_Ten(tuKhoa);

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", bS, "MaNV", false, DataSourceUpdateMode.Never);

            txtUserName.DataBindings.Clear();
            txtUserName.DataBindings.Add("Text", bS, "UserName", false, DataSourceUpdateMode.Never);

            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add("Text", bS, "Password", false, DataSourceUpdateMode.Never);

            txtHoTen.DataBindings.Clear();
            txtHoTen.DataBindings.Add("Text", bS, "HoTen", false, DataSourceUpdateMode.Never);

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("Text", bS, "CMND", false, DataSourceUpdateMode.Never);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", bS, "NgaySinh", false, DataSourceUpdateMode.Never);

            dtpNgayTao.DataBindings.Clear();
            dtpNgayTao.DataBindings.Add("Value", bS, "CreateDate", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bS, "Address", false, DataSourceUpdateMode.Never);

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", bS, "Email", false, DataSourceUpdateMode.Never);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bS, "Phone", false, DataSourceUpdateMode.Never);

            cboMaQuyen.DataBindings.Clear();
            cboMaQuyen.DataBindings.Add("SelectedValue", bS, "MaQuyen", false, DataSourceUpdateMode.Never);

            txtTienLuong.DataBindings.Clear();
            txtTienLuong.DataBindings.Add("Text", bS, "TienLuong", false, DataSourceUpdateMode.Never);
            txtTienLuong.DataBindings[0].FormattingEnabled = true;
            txtTienLuong.DataBindings[0].FormatString = "c0";

            bN.BindingSource = bS;
            dGV.DataSource = bS;
        }

        public void HienThiVaoComboBox(ComboBox cboQuyen)
        {
            cboQuyen.DataSource = dataPhanQuyen.DanhSach();
            cboQuyen.ValueMember = "MaQuyen";
            cboQuyen.DisplayMember = "TenQuyen";

        }

        public bool DangNhap(string tenDangNhap, string matKhau)
        {
            var tK = data.ChiTiet(tenDangNhap, matKhau);
            if (tK.Rows.Count > 0)
            {
                frmDonDatMua = int.Parse(tK.Rows[0]["MaNV"].ToString());
                frmQLNhaphangMaNV = int.Parse(tK.Rows[0]["MaNV"].ToString());
                frmMainhoVaTen = tK.Rows[0]["HoTen"].ToString();
                frmMainquyenHan = int.Parse(tK.Rows[0]["MaQuyen"].ToString());
                frmMainmaNV = int.Parse(tK.Rows[0]["MaNV"].ToString());
                frmDonHangmaNV = int.Parse(tK.Rows[0]["MaNV"].ToString());
                frmDoiMKmaNV = int.Parse(tK.Rows[0]["MaNV"].ToString());
                frmDoiMKtaiKhoan = tK.Rows[0]["UserName"].ToString();
                frmDetailUsermaNV = int.Parse(tK.Rows[0]["MaNV"].ToString());
                frmDetailUserhoTen = tK.Rows[0]["HoTen"].ToString();
                frmDetailUsermaQuyen = int.Parse(tK.Rows[0]["MaQuyen"].ToString());
                frmDetailUserngaySinh = DateTime.Parse(tK.Rows[0]["NgaySinh"].ToString());
                frmDetailUsertaiKhoan = tK.Rows[0]["UserName"].ToString();
                frmDetailUsertienLuong = int.Parse(tK.Rows[0]["TienLuong"].ToString());
                frmDetailUsercmnd = tK.Rows[0]["CMND"].ToString();
                frmKhachHangmaQuyen = int.Parse(tK.Rows[0]["MaQuyen"].ToString());
                return true;
            }
            else
                return false;
        }

        public bool DoiMK(int manv, string matkhaumoi)
        {
            var tK = data.DoiMatKhau(manv, matkhaumoi);
            if (tK.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        public bool LayThongTinTong(int manv, int thang, int nam)
        {
            var tt = data.LayThongTinTong(manv, thang, nam);
            if (tt.Rows.Count > 0)
            {
                return false;
            }
            else
                return true;
        }

        //Load bảng Linq
        public List<NhanVien> DanhSachLinq()
        {
            return data.DanhSachLinq();
        }

        public List<NhanVien> KiemTraTaoTaiKhoan(string taiKhoan)
        {
            return data.KiemTraTaoTaiKhoan(taiKhoan);
        }

        //Thêm Linq
        public bool ThemLinq(string userName, string password, string name, string cmnd, DateTime ngaySinh, string address, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong)
        { 
            if (data.ThemLinq(userName, password, name, cmnd, ngaySinh, address, email, phone, createDate, maQuyen, tienLuong) == true)
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
        public bool UpdateLinq(int id, string userName, string password, string name, string cmnd, DateTime ngaySinh, string address, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong, DateTime timeLogout)
        { 
            if (data.UpdateLinq(id, userName, password, name, cmnd, ngaySinh, address, email, phone, createDate, maQuyen, tienLuong, timeLogout) == true)
            {
                return true;
            }
            return false;
        }

        public bool Them(NhanVienDTO info)
        {
            if (data.Them(info))
            {
                return true;
            }
            return false;
            
        }

        public bool Sua(NhanVienDTO info, int maNV)
        {
            if (data.Sua(info, maNV))
            {
                return true;
            }
            return false;
            
        }

        public bool Xoa(NhanVienDTO info)
        {
            if (data.Xoa(info))
            {
                return true;
            }
            return false;
            
        }
    }
}
