using System;
using System.Collections.Generic;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.BLL
{
    public class DangKyBLL
    {
        public static List<DangKy> GetAllDangKy()
        {
            try
            {
                return DangKyDAL.GetAllDangKy();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all DangKy: " + ex.Message);
            }
        }
        
        public static List<DangKy> GetDangKysByMaLTC(int maLTC)
        {
            try
            {
                return DangKyDAL.GetDangKysByMaLTC(maLTC);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving DangKy by MaLTC: " + ex.Message);
            }
        }
        
        public static List<DangKy> GetDangKysByMaSV(string maSV)
        {
            try
            {
                return DangKyDAL.GetDangKysByMaSV(maSV);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving DangKy by MaSV: " + ex.Message);
            }
        }
        
        public static DangKy GetDangKyByMaLTCAndMaSV(int maLTC, string maSV)
        {
            try
            {
                return DangKyDAL.GetDangKyByMaLTCAndMaSV(maLTC, maSV);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving DangKy by MaLTC and MaSV: " + ex.Message);
            }
        }
        
        public static bool InsertDangKy(DangKy dangKy)
        {
            try
            {
                // Validate data
                if (dangKy.MaLTC <= 0)
                {
                    throw new Exception("MaLTC must be greater than 0");
                }
                
                if (string.IsNullOrEmpty(dangKy.MaSV))
                {
                    throw new Exception("MaSV cannot be empty");
                }
                
                if (dangKy.Diem_CC < 0 || dangKy.Diem_CC > 10)
                {
                    throw new Exception("Diem_CC must be between 0 and 10");
                }
                
                if (dangKy.Diem_GK < 0 || dangKy.Diem_GK > 10)
                {
                    throw new Exception("Diem_GK must be between 0 and 10");
                }
                
                if (dangKy.Diem_CK < 0 || dangKy.Diem_CK > 10)
                {
                    throw new Exception("Diem_CK must be between 0 and 10");
                }
                
                // Check if MaLTC exists
                LopTinChi lopTinChi = LopTinChiDAL.GetLopTinChiByMaLTC(dangKy.MaLTC);
                if (lopTinChi == null)
                {
                    throw new Exception("MaLTC does not exist");
                }
                
                // Check if MaSV exists
                SinhVien sinhVien = SinhVienDAL.GetSinhVienByMaSV(dangKy.MaSV);
                if (sinhVien == null)
                {
                    throw new Exception("MaSV does not exist");
                }
                
                // Check if student is still studying
                if (sinhVien.DaNghiHoc)
                {
                    throw new Exception("Student has already left school");
                }
                
                // Check if LopTinChi is not cancelled
                if (lopTinChi.HuyLop)
                {
                    throw new Exception("LopTinChi has been cancelled");
                }
                
                // Check if MaLTC + MaSV already exists
                DangKy existingDangKy = DangKyDAL.GetDangKyByMaLTCAndMaSV(dangKy.MaLTC, dangKy.MaSV);
                if (existingDangKy != null)
                {
                    throw new Exception("MaLTC + MaSV already exists");
                }
                
                return DangKyDAL.InsertDangKy(dangKy);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting DangKy: " + ex.Message);
            }
        }
        
        public static bool UpdateDangKy(DangKy dangKy)
        {
            try
            {
                // Validate data
                if (dangKy.MaLTC <= 0)
                {
                    throw new Exception("MaLTC must be greater than 0");
                }
                
                if (string.IsNullOrEmpty(dangKy.MaSV))
                {
                    throw new Exception("MaSV cannot be empty");
                }
                
                if (dangKy.Diem_CC < 0 || dangKy.Diem_CC > 10)
                {
                    throw new Exception("Diem_CC must be between 0 and 10");
                }
                
                if (dangKy.Diem_GK < 0 || dangKy.Diem_GK > 10)
                {
                    throw new Exception("Diem_GK must be between 0 and 10");
                }
                
                if (dangKy.Diem_CK < 0 || dangKy.Diem_CK > 10)
                {
                    throw new Exception("Diem_CK must be between 0 and 10");
                }
                
                // Check if MaLTC + MaSV exists
                DangKy existingDangKy = DangKyDAL.GetDangKyByMaLTCAndMaSV(dangKy.MaLTC, dangKy.MaSV);
                if (existingDangKy == null)
                {
                    throw new Exception("MaLTC + MaSV does not exist");
                }
                
                return DangKyDAL.UpdateDangKy(dangKy);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating DangKy: " + ex.Message);
            }
        }
        
        public static bool DeleteDangKy(int maLTC, string maSV)
        {
            try
            {
                // Check if MaLTC + MaSV exists
                DangKy existingDangKy = DangKyDAL.GetDangKyByMaLTCAndMaSV(maLTC, maSV);
                if (existingDangKy == null)
                {
                    throw new Exception("MaLTC + MaSV does not exist");
                }
                
                return DangKyDAL.DeleteDangKy(maLTC, maSV);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting DangKy: " + ex.Message);
            }
        }
        
        public static bool UpdateDiemDangKy(int maLTC, string maSV, int diemCC, float diemGK, float diemCK)
        {
            try
            {
                // Validate data
                if (maLTC <= 0)
                {
                    throw new Exception("MaLTC must be greater than 0");
                }
                
                if (string.IsNullOrEmpty(maSV))
                {
                    throw new Exception("MaSV cannot be empty");
                }
                
                if (diemCC < 0 || diemCC > 10)
                {
                    throw new Exception("Diem_CC must be between 0 and 10");
                }
                
                if (diemGK < 0 || diemGK > 10)
                {
                    throw new Exception("Diem_GK must be between 0 and 10");
                }
                
                if (diemCK < 0 || diemCK > 10)
                {
                    throw new Exception("Diem_CK must be between 0 and 10");
                }
                
                // Check if MaLTC + MaSV exists
                DangKy existingDangKy = DangKyDAL.GetDangKyByMaLTCAndMaSV(maLTC, maSV);
                if (existingDangKy == null)
                {
                    throw new Exception("MaLTC + MaSV does not exist");
                }
                
                return DangKyDAL.UpdateDiemDangKy(maLTC, maSV, diemCC, diemGK, diemCK);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Diem DangKy: " + ex.Message);
            }
        }
    }
}
