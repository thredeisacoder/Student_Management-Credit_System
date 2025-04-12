using System;

namespace QLDSV_HTC.DTO.Models
{
    public class DangKy
    {
        public int MaLTC { get; set; }
        public string MaSV { get; set; }
        public int Diem_CC { get; set; }
        public float Diem_GK { get; set; }
        public float Diem_CK { get; set; }
        public bool HuyDangKy { get; set; }
        
        // Calculated property for final grade
        public float DiemHetMon
        {
            get
            {
                return Diem_CC * 0.1f + Diem_GK * 0.3f + Diem_CK * 0.6f;
            }
        }
    }
}
