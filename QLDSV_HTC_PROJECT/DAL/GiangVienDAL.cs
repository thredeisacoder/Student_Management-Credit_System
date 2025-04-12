using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class GiangVienDAL
    {
        public static List<GiangVien> GetAllGiangVien()
        {
            List<GiangVien> giangViens = new List<GiangVien>();
            string query = "SELECT * FROM Giangvien";

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                GiangVien giangVien = new GiangVien
                {
                    MaGV = row["MAGV"].ToString(),
                    Ho = row["HO"].ToString(),
                    Ten = row["TEN"].ToString(),
                    HocVi = row["HOCVI"].ToString(),
                    HocHam = row["HOCHAM"].ToString(),
                    ChuyenMon = row["CHUYENMON"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    Password = row["PASSWORD"].ToString()
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        public static List<GiangVien> GetGiangViensByMaKhoa(string maKhoa)
        {
            List<GiangVien> giangViens = new List<GiangVien>();
            string query = "SELECT * FROM Giangvien WHERE MAKHOA = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", maKhoa)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                GiangVien giangVien = new GiangVien
                {
                    MaGV = row["MAGV"].ToString(),
                    Ho = row["HO"].ToString(),
                    Ten = row["TEN"].ToString(),
                    HocVi = row["HOCVI"].ToString(),
                    HocHam = row["HOCHAM"].ToString(),
                    ChuyenMon = row["CHUYENMON"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    Password = row["PASSWORD"].ToString()
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        public static GiangVien GetGiangVienByMaGV(string maGV)
        {
            string query = "SELECT * FROM Giangvien WHERE MAGV = @MaGV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaGV", maGV)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                GiangVien giangVien = new GiangVien
                {
                    MaGV = row["MAGV"].ToString(),
                    Ho = row["HO"].ToString(),
                    Ten = row["TEN"].ToString(),
                    HocVi = row["HOCVI"].ToString(),
                    HocHam = row["HOCHAM"].ToString(),
                    ChuyenMon = row["CHUYENMON"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    Password = row["PASSWORD"].ToString()
                };

                return giangVien;
            }

            return null;
        }

        public static bool InsertGiangVien(GiangVien giangVien)
        {
            string query = "INSERT INTO Giangvien (MAGV, HO, TEN, HOCVI, HOCHAM, CHUYENMON, MAKHOA, PASSWORD) " +
                          "VALUES (@MaGV, @Ho, @Ten, @HocVi, @HocHam, @ChuyenMon, @MaKhoa, @Password)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaGV", giangVien.MaGV),
                new SqlParameter("@Ho", giangVien.Ho),
                new SqlParameter("@Ten", giangVien.Ten),
                new SqlParameter("@HocVi", giangVien.HocVi),
                new SqlParameter("@HocHam", giangVien.HocHam),
                new SqlParameter("@ChuyenMon", giangVien.ChuyenMon),
                new SqlParameter("@MaKhoa", giangVien.MaKhoa),
                new SqlParameter("@Password", giangVien.Password ?? "123456")
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool UpdateGiangVien(GiangVien giangVien)
        {
            string query = "UPDATE Giangvien SET HO = @Ho, TEN = @Ten, HOCVI = @HocVi, HOCHAM = @HocHam, " +
                          "CHUYENMON = @ChuyenMon, MAKHOA = @MaKhoa, PASSWORD = @Password WHERE MAGV = @MaGV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaGV", giangVien.MaGV),
                new SqlParameter("@Ho", giangVien.Ho),
                new SqlParameter("@Ten", giangVien.Ten),
                new SqlParameter("@HocVi", giangVien.HocVi),
                new SqlParameter("@HocHam", giangVien.HocHam),
                new SqlParameter("@ChuyenMon", giangVien.ChuyenMon),
                new SqlParameter("@MaKhoa", giangVien.MaKhoa),
                new SqlParameter("@Password", giangVien.Password ?? "123456")
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool DeleteGiangVien(string maGV)
        {
            string query = "DELETE FROM Giangvien WHERE MAGV = @MaGV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaGV", maGV)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool CheckLogin(string maGV, string password)
        {
            string query = "SELECT COUNT(*) FROM Giangvien WHERE MAGV = @MaGV AND PASSWORD = @Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaGV", maGV),
                new SqlParameter("@Password", password)
            };

            int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, parameters));

            return count > 0;
        }
    }
}
