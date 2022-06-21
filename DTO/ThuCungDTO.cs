using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThuCungDTO
    {
        private int maTC;
        private string tenTC;
        private decimal giaBan;
        private string moTa;
        private string anh; 
        private DateTime createDate;
        private DateTime ngayCapNhat;
        private DateTime ngayBan;
        private int maGiong;
        private int maLoai;
        private int trangThai;

        public int MaTC { get => maTC; set => maTC = value; }
        public string TenTC { get => tenTC; set => tenTC = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string Anh { get => anh; set => anh = value; }
        public DateTime NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public int MaGiong { get => maGiong; set => maGiong = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }
    }
}
