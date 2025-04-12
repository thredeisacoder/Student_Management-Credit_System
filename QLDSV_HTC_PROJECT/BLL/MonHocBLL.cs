using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.BLL
{
    public class MonHocBLL
    {
        public static List<MonHoc> GetAllMonHoc()
        {
            try
            {
                return MonHocDAL.GetAllMonHoc();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all MonHoc: " + ex.Message);
            }
        }
        
        public static MonHoc GetMonHocByMaMH(string maMH)
        {
            try
            {
                return MonHocDAL.GetMonHocByMaMH(maMH);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving MonHoc by MaMH: " + ex.Message);
            }
        }
        
        public static bool InsertMonHoc(MonHoc monHoc)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(monHoc.MaMH))
                {
                    throw new Exception("MaMH cannot be empty");
                }
                
                if (string.IsNullOrEmpty(monHoc.TenMH))
                {
                    throw new Exception("TenMH cannot be empty");
                }
                
                if (monHoc.SoTiet_LT < 0)
                {
                    throw new Exception("SoTiet_LT cannot be negative");
                }
                
                if (monHoc.SoTiet_TH < 0)
                {
                    throw new Exception("SoTiet_TH cannot be negative");
                }
                
                // Check if MaMH already exists
                MonHoc existingMonHoc = MonHocDAL.GetMonHocByMaMH(monHoc.MaMH);
                if (existingMonHoc != null)
                {
                    throw new Exception("MaMH already exists");
                }
                
                return MonHocDAL.InsertMonHoc(monHoc);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    throw new Exception("TenMH already exists");
                }
                
                throw new Exception("Error inserting MonHoc: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting MonHoc: " + ex.Message);
            }
        }
        
        public static bool UpdateMonHoc(MonHoc monHoc)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(monHoc.MaMH))
                {
                    throw new Exception("MaMH cannot be empty");
                }
                
                if (string.IsNullOrEmpty(monHoc.TenMH))
                {
                    throw new Exception("TenMH cannot be empty");
                }
                
                if (monHoc.SoTiet_LT < 0)
                {
                    throw new Exception("SoTiet_LT cannot be negative");
                }
                
                if (monHoc.SoTiet_TH < 0)
                {
                    throw new Exception("SoTiet_TH cannot be negative");
                }
                
                // Check if MaMH exists
                MonHoc existingMonHoc = MonHocDAL.GetMonHocByMaMH(monHoc.MaMH);
                if (existingMonHoc == null)
                {
                    throw new Exception("MaMH does not exist");
                }
                
                return MonHocDAL.UpdateMonHoc(monHoc);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint error
                {
                    throw new Exception("TenMH already exists");
                }
                
                throw new Exception("Error updating MonHoc: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating MonHoc: " + ex.Message);
            }
        }
        
        public static bool DeleteMonHoc(string maMH)
        {
            try
            {
                // Check if MaMH exists
                MonHoc existingMonHoc = MonHocDAL.GetMonHocByMaMH(maMH);
                if (existingMonHoc == null)
                {
                    throw new Exception("MaMH does not exist");
                }
                
                // Check if there are any LopTinChi associated with this MonHoc
                List<LopTinChi> lopTinChis = new List<LopTinChi>();
                foreach (LopTinChi lopTinChi in LopTinChiDAL.GetAllLopTinChi())
                {
                    if (lopTinChi.MaMH == maMH)
                    {
                        lopTinChis.Add(lopTinChi);
                    }
                }
                
                if (lopTinChis.Count > 0)
                {
                    throw new Exception("Cannot delete MonHoc because there are LopTinChi associated with it");
                }
                
                return MonHocDAL.DeleteMonHoc(maMH);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting MonHoc: " + ex.Message);
            }
        }
    }
}
