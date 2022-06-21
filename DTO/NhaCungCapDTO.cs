using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCapDTO
    {
        private int maNCC;
        private string tenNCC;
        private string phone;
        private string email;
        private string address;

        public int MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
    }
}
