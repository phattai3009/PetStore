using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDDMDTO
    {
        private int maDDM;
        private int maGiong;
        private decimal giaMua;
        private int soLuongMua;
        private decimal thanhTien;
        private string moTa;

        public int MaDDM { get => maDDM; set => maDDM = value; }
        public int MaGiong { get => maGiong; set => maGiong = value; }
        public decimal GiaMua { get => giaMua; set => giaMua = value; }
        public int SoLuongMua { get => soLuongMua; set => soLuongMua = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
