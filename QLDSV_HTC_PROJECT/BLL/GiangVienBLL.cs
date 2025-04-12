using System;
using System.Collections.Generic;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.BLL
{
    public class GiangVienBLL
    {
        public static List<GiangVien> GetAllGiangVien()
        {
            try
            {
                return GiangVienDAL.GetAllGiangVien();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all GiangVien: " + ex.Message);
            }
        }

        public static List<GiangVien> GetGiangViensByMaKhoa(string maKhoa)
        {
            try
            {
                return GiangVienDAL.GetGiangViensByMaKhoa(maKhoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving GiangVien by MaKhoa: " + ex.Message);
            }
        }

        public static GiangVien GetGiangVienByMaGV(string maGV)
        {
            try
            {
                return GiangVienDAL.GetGiangVienByMaGV(maGV);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving GiangVien by MaGV: " + ex.Message);
            }
        }

        public static bool InsertGiangVien(GiangVien giangVien)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(giangVien.MaGV))
                {
                    throw new Exception("MaGV cannot be empty");
                }

                if (string.IsNullOrEmpty(giangVien.Ho))
                {
                    throw new Exception("Ho cannot be empty");
                }

                if (string.IsNullOrEmpty(giangVien.Ten))
                {
                    throw new Exception("Ten cannot be empty");
                }

                if (string.IsNullOrEmpty(giangVien.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }

                // Check if MaGV already exists
                GiangVien existingGiangVien = GiangVienDAL.GetGiangVienByMaGV(giangVien.MaGV);
                if (existingGiangVien != null)
                {
                    throw new Exception("MaGV already exists");
                }

                // Check if MaKhoa exists
                Khoa khoa = KhoaDAL.GetKhoaByMaKhoa(giangVien.MaKhoa);
                if (khoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }

                return GiangVienDAL.InsertGiangVien(giangVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting GiangVien: " + ex.Message);
            }
        }

        public static bool UpdateGiangVien(GiangVien giangVien)
        {
            try
            {
                // Validate data
                if (string.IsNullOrEmpty(giangVien.MaGV))
                {
                    throw new Exception("MaGV cannot be empty");
                }

                if (string.IsNullOrEmpty(giangVien.Ho))
                {
                    throw new Exception("Ho cannot be empty");
                }

                if (string.IsNullOrEmpty(giangVien.Ten))
                {
                    throw new Exception("Ten cannot be empty");
                }

                if (string.IsNullOrEmpty(giangVien.MaKhoa))
                {
                    throw new Exception("MaKhoa cannot be empty");
                }

                // Check if MaGV exists
                GiangVien existingGiangVien = GiangVienDAL.GetGiangVienByMaGV(giangVien.MaGV);
                if (existingGiangVien == null)
                {
                    throw new Exception("MaGV does not exist");
                }

                // Check if MaKhoa exists
                Khoa khoa = KhoaDAL.GetKhoaByMaKhoa(giangVien.MaKhoa);
                if (khoa == null)
                {
                    throw new Exception("MaKhoa does not exist");
                }

                return GiangVienDAL.UpdateGiangVien(giangVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating GiangVien: " + ex.Message);
            }
        }

        public static bool DeleteGiangVien(string maGV)
        {
            try
            {
                // Check if MaGV exists
                GiangVien existingGiangVien = GiangVienDAL.GetGiangVienByMaGV(maGV);
                if (existingGiangVien == null)
                {
                    throw new Exception("MaGV does not exist");
                }

                // Check if there are any LopTinChi associated with this GiangVien
                List<LopTinChi> lopTinChis = new List<LopTinChi>();
                foreach (LopTinChi lopTinChi in LopTinChiDAL.GetAllLopTinChi())
                {
                    if (lopTinChi.MaGV == maGV)
                    {
                        lopTinChis.Add(lopTinChi);
                    }
                }

                if (lopTinChis.Count > 0)
                {
                    throw new Exception("Cannot delete GiangVien because there are LopTinChi associated with it");
                }

                return GiangVienDAL.DeleteGiangVien(maGV);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting GiangVien: " + ex.Message);
            }
        }

        public static bool CheckLogin(string maGV, string password)
        {
            try
            {
                return GiangVienDAL.CheckLogin(maGV, password);
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking login: " + ex.Message);
            }
        }
    }
}
