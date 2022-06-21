using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private int maKH;
        private string hoTen;
        private string taiKhoan;
        private string matKhau;
        private string email;
        private string address;
        private string dienThoai;
        private string gioiTinh;
        private DateTime ngaySinh;
        private DateTime createDate;
        private DateTime timeLogout;

        public int MaKH { get => maKH; set => maKH = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string TaiKhoan { get => taiKhoan; set => taiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime TimeLogout { get => timeLogout; set => timeLogout = value; }
    }
}
