using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiongDTO
    {
        public GiongDTO()
        {
            Loai = new LoaiDTO();
        }

        private LoaiDTO loai;
        internal LoaiDTO Loai
        {
            get { return loai; }
            set { loai = value; }
        }

        private int maLoai;
        private int maGiong;
        private string tenGiong;
        private int soLuongTon;
        private string moTa;

        public int MaLoai { get => maLoai; set => maLoai = value; }
        public int MaGiong { get => maGiong; set => maGiong = value; }
        public string TenGiong { get => tenGiong; set => tenGiong = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public int SoLuongTon { get => soLuongTon; set => soLuongTon = value; }
    }
}
