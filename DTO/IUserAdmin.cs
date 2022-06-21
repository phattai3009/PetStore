using System;

namespace DTO
{
    public interface IUserAdmin
    {
        string Cmnd { get; set; }
        DateTime CreateDate { get; set; }
        string DiaChi { get; set; }
        string Email { get; set; }
        string HoTen { get; set; }
        int Id { get; set; }
        int MaQuyen { get; set; }
        DateTime NgaySinh { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
        decimal TienLuong { get; set; }
        string UserName { get; set; }
    }
}