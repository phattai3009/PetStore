using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoiTraDTO
    {
        private int maDT;
        private int maDH;
        private int maNV;
        private DateTime ngayDoi;
        private string lyDo;
        private string tinhTrangThuCung;

        public int MaDT { get => maDT; set => maDT = value; }
        public int MaDH { get => maDH; set => maDH = value; }
        public DateTime NgayDoi { get => ngayDoi; set => ngayDoi = value; }
        public string LyDo { get => lyDo; set => lyDo = value; }
        public string TinhTrangThuCung { get => tinhTrangThuCung; set => tinhTrangThuCung = value; }
        public int MaNV { get => maNV; set => maNV = value; }
    }
}
