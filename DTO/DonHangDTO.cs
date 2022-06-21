using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangDTO
    {
        private int maDH;
        private int maNV;
        private DateTime createdDate;
        private int maKH;
        private string nguoiNhan;
        private string email;
        private string phone;
        private string address;
        private decimal tongTien;
        private int trangThai;

        public int MaDH { get => maDH; set => maDH = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string NguoiNhan { get => nguoiNhan; set => nguoiNhan = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}
