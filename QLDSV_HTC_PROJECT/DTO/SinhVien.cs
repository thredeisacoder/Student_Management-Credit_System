using System;

namespace QLDSV_HTC.DTO.Models
{
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string MaLop { get; set; }
        public bool Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public bool DaNghiHoc { get; set; }
        public string Password { get; set; }
    }
}