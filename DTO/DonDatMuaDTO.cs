using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonDatMuaDTO
    {
        private int maDDM;
        private int maNCC;
        private int maNV;
        private DateTime createDate;
        private DateTime ngayCapNhat;
        private string noiDung;
        private int tongSLMua;
        private decimal tongTienMua; 

        public int MaDDM { get => maDDM; set => maDDM = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public int TongSLMua { get => tongSLMua; set => tongSLMua = value; }
        public decimal TongTienMua { get => tongTienMua; set => tongTienMua = value; }
    }
}
