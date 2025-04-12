using System;
using System.Collections.Generic;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.BLL
{
    public class LopTinChiBLL
    {
        public static List<LopTinChi> GetAllLopTinChi()
        {
            try
            {
                return LopTinChiDAL.GetAllLopTinChi();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all LopTinChi: " + ex.Message);
            }
        }
        
        public static List<LopTinChi> GetLopTinChisByMaKhoa(string maKhoa)
        {
            try
            {
                return LopTinChiDAL.GetLopTinChisByMaKhoa(maKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving LopTinChi by MaKhoa: " + ex.Message);
            }
        }
        
        public static List<LopTinChi> GetLopTinChisByNienKhoaAndHocKy(string nienKhoa, int hocKy)
        {
            try
            {
                return LopTinChiDAL.GetLopTinChisByNienKhoaAndHocKy(nienKhoa, hocKy);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving LopTinChi by NienKhoa and HocKy: " + ex.Message);
            }
        }
        
        public static LopTinChi GetLopTinChiByMaLTC(int maLTC)
        {
            try
            {
                return LopTinChiDAL.GetLopTinChiByMaLTC(maLTC);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving LopTinChi by MaLTC: " + ex.Message);
            }
        }
        
        public static int InsertLopTinChi(LopTinChi lopTinChi)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(lopTinChi.NienKhoa))
                {
                    throw new Exception("NienKhoa cannot be empty");
                }
                
                if (lopTinChi.HocKy < 1 || lopTinChi.HocKy > 3)
                {
                    throw new Exception("HocKy must be between 1 and 3");
                }
                
                if (string.IsNullOrEmpty(lopTinChi.MaMH))
                {
                    throw new Exception("MaMH cannot be empty");
                }
                
                if (lopTinChi.Nhom < 1)
                {
                    throw new Exception("Nhom must be greater than or equal to 1");
                }
                
                if (string.IsNullOrEmpty(lopTinChi.MaGV))
                {
                    throw new Exception("MaGV cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lopTinChi.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }
                
                if (lopTinChi.SoSVToiThieu <= 0)
                {
                    throw new Exception("SoSVToiThieu must be greater than 0");
                }
                
                // Check if MaMH exists
                MonHoc monHoc = MonHocDAL.GetMonHocByMaMH(lopTinChi.MaMH);
                if (monHoc == null)
                {
                    throw new Exception("MaMH does not exist");
                }
                
                // Check if MaGV exists
                GiangVien giangVien = GiangVienDAL.GetGiangVienByMaGV(lopTinChi.MaGV);
                if (giangVien == null)
                {
                    throw new Exception("MaGV does not exist");
                }
                
                // Check if MaKhoa exists
                Khoa khoa = KhoaDAL.GetKhoaByMaKhoa(lopTinChi.MaKhoa);
                if (khoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }
                
                // Check if NienKhoa + HocKy + MaMH + Nhom already exists
                foreach (LopTinChi ltc in LopTinChiDAL.GetAllLopTinChi())
                {
                    if (ltc.NienKhoa == lopTinChi.NienKhoa &&
                        ltc.HocKy == lopTinChi.HocKy &&
                        ltc.MaMH == lopTinChi.MaMH &&
                        ltc.Nhom == lopTinChi.Nhom)
                    {
                        throw new Exception("NienKhoa + HocKy + MaMH + Nhom already exists");
                    }
                }
                
                return LopTinChiDAL.InsertLopTinChi(lopTinChi);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting LopTinChi: " + ex.Message);
            }
        }
        
        public static bool UpdateLopTinChi(LopTinChi lopTinChi)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(lopTinChi.NienKhoa))
                {
                    throw new Exception("NienKhoa cannot be empty");
                }
                
                if (lopTinChi.HocKy < 1 || lopTinChi.HocKy > 3)
                {
                    throw new Exception("HocKy must be between 1 and 3");
                }
                
                if (string.IsNullOrEmpty(lopTinChi.MaMH))
                {
                    throw new Exception("MaMH cannot be empty");
                }
                
                if (lopTinChi.Nhom < 1)
                {
                    throw new Exception("Nhom must be greater than or equal to 1");
                }
                
                if (string.IsNullOrEmpty(lopTinChi.MaGV))
                {
                    throw new Exception("MaGV cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lopTinChi.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }
                
                if (lopTinChi.SoSVToiThieu <= 0)
                {
                    throw new Exception("SoSVToiThieu must be greater than 0");
                }
                
                // Check if MaLTC exists
                LopTinChi existingLopTinChi = LopTinChiDAL.GetLopTinChiByMaLTC(lopTinChi.MaLTC);
                if (existingLopTinChi == null)
                {
                    throw new Exception("MaLTC does not exist");
                }
                
                // Check if MaMH exists
                MonHoc monHoc = MonHocDAL.GetMonHocByMaMH(lopTinChi.MaMH);
                if (monHoc == null)
                {
                    throw new Exception("MaMH does not exist");
                }
                
                // Check if MaGV exists
                GiangVien giangVien = GiangVienDAL.GetGiangVienByMaGV(lopTinChi.MaGV);
                if (giangVien == null)
                {
                    throw new Exception("MaGV does not exist");
                }
                
                // Check if MaKhoa exists
                Khoa khoa = KhoaDAL.GetKhoaByMaKhoa(lopTinChi.MaKhoa);
                if (khoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }
                
                // Check if NienKhoa + HocKy + MaMH + Nhom already exists (excluding this LopTinChi)
                foreach (LopTinChi ltc in LopTinChiDAL.GetAllLopTinChi())
                {
                    if (ltc.MaLTC != lopTinChi.MaLTC &&
                        ltc.NienKhoa == lopTinChi.NienKhoa &&
                        ltc.HocKy == lopTinChi.HocKy &&
                        ltc.MaMH == lopTinChi.MaMH &&
                        ltc.Nhom == lopTinChi.Nhom)
                    {
                        throw new Exception("NienKhoa + HocKy + MaMH + Nhom already exists");
                    }
                }
                
                return LopTinChiDAL.UpdateLopTinChi(lopTinChi);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating LopTinChi: " + ex.Message);
            }
        }
        
        public static bool DeleteLopTinChi(int maLTC)
        {
            try
            {
                // Check if MaLTC exists
                LopTinChi existingLopTinChi = LopTinChiDAL.GetLopTinChiByMaLTC(maLTC);
                if (existingLopTinChi == null)
                {
                    throw new Exception("MaLTC does not exist");
                }
                
                // Check if there are any DangKy associated with this LopTinChi
                List<DangKy> dangKys = DangKyDAL.GetDangKysByMaLTC(maLTC);
                if (dangKys.Count > 0)
                {
                    throw new Exception("Cannot delete LopTinChi because there are DangKy associated with it");
                }
                
                return LopTinChiDAL.DeleteLopTinChi(maLTC);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting LopTinChi: " + ex.Message);
            }
        }
        
        public static int GetSoSVDangKy(int maLTC)
        {
            try
            {
                return LopTinChiDAL.GetSoSVDangKy(maLTC);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting SoSVDangKy: " + ex.Message);
            }
        }
    }
}
