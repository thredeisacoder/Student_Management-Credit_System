using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.BLL
{
    public class LopBLL
    {
        public static List<Lop> GetAllLop()
        {
            try
            {
                return LopDAL.GetAllLop();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all Lop: " + ex.Message);
            }
        }
        
        public static List<Lop> GetLopsByMaKhoa(string maKhoa)
        {
            try
            {
                return LopDAL.GetLopsByMaKhoa(maKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Lop by MaKhoa: " + ex.Message);
            }
        }
        
        public static Lop GetLopByMaLop(string maLop)
        {
            try
            {
                return LopDAL.GetLopByMaLop(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Lop by MaLop: " + ex.Message);
            }
        }
        
        public static bool InsertLop(Lop lop)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(lop.MaLop))
                {
                    throw new Exception("MaLop cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lop.TenLop))
                {
                    throw new Exception("TenLop cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lop.KhoaHoc))
                {
                    throw new Exception("KhoaHoc cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lop.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }
                
                // Check if MaLop already exists
                Lop existingLop = LopDAL.GetLopByMaLop(lop.MaLop);
                if (existingLop != null)
                {
                    throw new Exception("MaLop already exists");
                }
                
                // Check if MaKhoa exists
                Khoa khoa = KhoaDAL.GetKhoaByMaKhoa(lop.MaKhoa);
                if (khoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }
                
                return LopDAL.InsertLop(lop);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    throw new Exception("TenLop already exists");
                }
                
                throw new Exception("Error inserting Lop: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Lop: " + ex.Message);
            }
        }
        
        public static bool UpdateLop(Lop lop)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(lop.MaLop))
                {
                    throw new Exception("MaLop cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lop.TenLop))
                {
                    throw new Exception("TenLop cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lop.KhoaHoc))
                {
                    throw new Exception("KhoaHoc cannot be empty");
                }
                
                if (string.IsNullOrEmpty(lop.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }
                
                // Check if MaLop exists
                Lop existingLop = LopDAL.GetLopByMaLop(lop.MaLop);
                if (existingLop == null)
                {
                    throw new Exception("MaLop does not exist");
                }
                
                // Check if MaKhoa exists
                Khoa khoa = KhoaDAL.GetKhoaByMaKhoa(lop.MaKhoa);
                if (khoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }
                
                return LopDAL.UpdateLop(lop);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    throw new Exception("TenLop already exists");
                }
                
                throw new Exception("Error updating Lop: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Lop: " + ex.Message);
            }
        }
        
        public static bool DeleteLop(string maLop)
        {
            try
            {
                // Check if MaLop exists
                Lop existingLop = LopDAL.GetLopByMaLop(maLop);
                if (existingLop == null)
                {
                    throw new Exception("MaLop does not exist");
                }
                
                // Check if there are any SinhVien associated with this Lop
                List<SinhVien> sinhViens = SinhVienDAL.GetSinhViensByMaLop(maLop);
                if (sinhViens.Count > 0)
                {
                    throw new Exception("Cannot delete Lop because there are SinhVien associated with it");
                }
                
                return LopDAL.DeleteLop(maLop);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Lop: " + ex.Message);
            }
        }
    }
}
