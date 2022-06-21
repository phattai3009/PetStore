using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiDTO
    {
        private int maLoai;
        private string tenLoai;

        public int MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
    }
}
