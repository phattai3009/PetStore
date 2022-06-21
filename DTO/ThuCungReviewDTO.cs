using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThuCungReviewDTO
    {
        private int maReview;
        private int maTC;
        private int maKH;
        private string tieuDe;
        private int danhGia;
        private string noiDung;
        private DateTime createdDate;
        private int trangThai;
        private DateTime ngayDang;

        public int MaReview { get => maReview; set => maReview = value; }
        public int MaTC { get => maTC; set => maTC = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string TieuDe { get => tieuDe; set => tieuDe = value; }
        public int DanhGia { get => danhGia; set => danhGia = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public DateTime NgayDang { get => ngayDang; set => ngayDang = value; }
    }
}
