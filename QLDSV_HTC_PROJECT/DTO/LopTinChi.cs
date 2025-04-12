using System;

namespace QLDSV_HTC.DTO.Models
{
    public class LopTinChi
    {
        public int MaLTC { get; set; }
        public string NienKhoa { get; set; }
        public int HocKy { get; set; }
        public string MaMH { get; set; }
        public int Nhom { get; set; }
        public string MaGV { get; set; }
        public string MaKhoa { get; set; }
        public short SoSVToiThieu { get; set; }
        public bool HuyLop { get; set; }
    }
}
