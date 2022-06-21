using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPhieuNhapDTO
    {
        private int maPN;
        private int maGiong;
        private int maTC;
        private decimal giaNhap;

        public int MaPN { get => maPN; set => maPN = value; }
        public int MaGiong { get => maGiong; set => maGiong = value; }
        public int MaTC { get => maTC; set => maTC = value; }
        public decimal GiaNhap { get => giaNhap; set => giaNhap = value; }
    }
}
