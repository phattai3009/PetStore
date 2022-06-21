using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDonHangDTO
    {
        private int maDH;
        private int maTC;
        //private int soLuong;
        private decimal thanhTien;

        public int MaDH { get => maDH; set => maDH = value; }
        public int MaTC { get => maTC; set => maTC = value; }
        //public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
