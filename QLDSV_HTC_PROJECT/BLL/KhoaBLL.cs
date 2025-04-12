using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.BLL
{
    public class KhoaBLL
    {
        public static List<Khoa> GetAllKhoa()
        {
            try
            {
                return KhoaDAL.GetAllKhoa();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all Khoa: " + ex.Message);
            }
        }
        
        public static Khoa GetKhoaByMaKhoa(string maKhoa)
        {
            try
            {
                return KhoaDAL.GetKhoaByMaKhoa(maKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Khoa by MaKhoa: " + ex.Message);
            }
        }
        
        public static bool InsertKhoa(Khoa khoa)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(khoa.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }
                
                if (string.IsNullOrEmpty(khoa.TenKhoa))
                {
                    throw new Exception("TenKhoa cannot be empty");
                }
                
                // Check if MaKhoa already exists
                Khoa existingKhoa = KhoaDAL.GetKhoaByMaKhoa(khoa.MaKhoa);
                if (existingKhoa != null)
                {
                    throw new Exception("MaKhoa already exists");
                }
                
                return KhoaDAL.InsertKhoa(khoa);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    throw new Exception("TenKhoa already exists");
                }
                
                throw new Exception("Error inserting Khoa: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting Khoa: " + ex.Message);
            }
        }
        
        public static bool UpdateKhoa(Khoa khoa)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(khoa.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }
                
                if (string.IsNullOrEmpty(khoa.TenKhoa))
                {
                    throw new Exception("TenKhoa cannot be empty");
                }
                
                // Check if MaKhoa exists
                Khoa existingKhoa = KhoaDAL.GetKhoaByMaKhoa(khoa.MaKhoa);
                if (existingKhoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }
                
                return KhoaDAL.UpdateKhoa(khoa);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    throw new Exception("TenKhoa already exists");
                }
                
                throw new Exception("Error updating Khoa: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Khoa: " + ex.Message);
            }
        }
        
        public static bool DeleteKhoa(string maKhoa)
        {
            try
            {
                // Check if MaKhoa exists
                Khoa existingKhoa = KhoaDAL.GetKhoaByMaKhoa(maKhoa);
                if (existingKhoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }
                
                // Check if there are any Lop associated with this Khoa
                List<Lop> lops = LopDAL.GetLopsByMaKhoa(maKhoa);
                if (lops.Count > 0)
                {
                    throw new Exception("Cannot delete Khoa because there are Lop associated with it");
                }
                
                // Check if there are any GiangVien associated with this Khoa
                List<GiangVien> giangViens = GiangVienDAL.GetGiangViensByMaKhoa(maKhoa);
                if (giangViens.Count > 0)
                {
                    throw new Exception("Cannot delete Khoa because there are GiangVien associated with it");
                }
                
                // Check if there are any LopTinChi associated with this Khoa
                List<LopTinChi> lopTinChis = LopTinChiDAL.GetLopTinChisByMaKhoa(maKhoa);
                if (lopTinChis.Count > 0)
                {
                    throw new Exception("Cannot delete Khoa because there are LopTinChi associated with it");
                }
                
                return KhoaDAL.DeleteKhoa(maKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Khoa: " + ex.Message);
            }
        }
    }
}
