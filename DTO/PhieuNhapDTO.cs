using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuNhapDTO
    {
        private int maPN;
        private int maDDM;
        private int maNV;
        private DateTime ngayNhap;
        private DateTime ngayCapNhat;
        private string noiDung;
        private int tongSLNhap;
        private decimal tongTienNhap;

        public int MaPN { get => maPN; set => maPN = value; }
        public int MaDDM { get => maDDM; set => maDDM = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public int TongSLNhap { get => tongSLNhap; set => tongSLNhap = value; }
        public decimal TongTienNhap { get => tongTienNhap; set => tongTienNhap = value; }
        public DateTime NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
    }
}
