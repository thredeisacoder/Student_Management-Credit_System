using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class DangKyDAL
    {
        public static List<DangKy> GetAllDangKy()
        {
            List<DangKy> dangKys = new List<DangKy>();
            string query = "SELECT * FROM Dangky";

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                DangKy dangKy = new DangKy
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    MaSV = row["MASV"].ToString(),
                    Diem_CC = row["DIEM_CC"] != DBNull.Value ? Convert.ToInt32(row["DIEM_CC"]) : 0,
                    Diem_GK = row["DIEM_GK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_GK"]) : 0,
                    Diem_CK = row["DIEM_CK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_CK"]) : 0,
                    HuyDangKy = Convert.ToBoolean(row["HUYDANGKY"])
                };

                dangKys.Add(dangKy);
            }

            return dangKys;
        }

        public static List<DangKy> GetDangKysByMaLTC(int maLTC)
        {
            List<DangKy> dangKys = new List<DangKy>();
            string query = "SELECT * FROM Dangky WHERE MALTC = @MaLTC AND HUYDANGKY = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                DangKy dangKy = new DangKy
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    MaSV = row["MASV"].ToString(),
                    Diem_CC = row["DIEM_CC"] != DBNull.Value ? Convert.ToInt32(row["DIEM_CC"]) : 0,
                    Diem_GK = row["DIEM_GK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_GK"]) : 0,
                    Diem_CK = row["DIEM_CK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_CK"]) : 0,
                    HuyDangKy = Convert.ToBoolean(row["HUYDANGKY"])
                };

                dangKys.Add(dangKy);
            }

            return dangKys;
        }

        public static List<DangKy> GetDangKysByMaSV(string maSV)
        {
            List<DangKy> dangKys = new List<DangKy>();
            string query = "SELECT * FROM Dangky WHERE MASV = @MaSV AND HUYDANGKY = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", maSV)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                DangKy dangKy = new DangKy
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    MaSV = row["MASV"].ToString(),
                    Diem_CC = row["DIEM_CC"] != DBNull.Value ? Convert.ToInt32(row["DIEM_CC"]) : 0,
                    Diem_GK = row["DIEM_GK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_GK"]) : 0,
                    Diem_CK = row["DIEM_CK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_CK"]) : 0,
                    HuyDangKy = Convert.ToBoolean(row["HUYDANGKY"])
                };

                dangKys.Add(dangKy);
            }

            return dangKys;
        }

        public static DangKy GetDangKyByMaLTCAndMaSV(int maLTC, string maSV)
        {
            string query = "SELECT * FROM Dangky WHERE MALTC = @MaLTC AND MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC),
                new SqlParameter("@MaSV", maSV)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                DangKy dangKy = new DangKy
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    MaSV = row["MASV"].ToString(),
                    Diem_CC = row["DIEM_CC"] != DBNull.Value ? Convert.ToInt32(row["DIEM_CC"]) : 0,
                    Diem_GK = row["DIEM_GK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_GK"]) : 0,
                    Diem_CK = row["DIEM_CK"] != DBNull.Value ? Convert.ToSingle(row["DIEM_CK"]) : 0,
                    HuyDangKy = Convert.ToBoolean(row["HUYDANGKY"])
                };

                return dangKy;
            }

            return null;
        }

        public static bool InsertDangKy(DangKy dangKy)
        {
            string query = "INSERT INTO Dangky (MALTC, MASV, DIEM_CC, DIEM_GK, DIEM_CK, HUYDANGKY) " +
                          "VALUES (@MaLTC, @MaSV, @Diem_CC, @Diem_GK, @Diem_CK, @HuyDangKy)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", dangKy.MaLTC),
                new SqlParameter("@MaSV", dangKy.MaSV),
                new SqlParameter("@Diem_CC", dangKy.Diem_CC),
                new SqlParameter("@Diem_GK", dangKy.Diem_GK),
                new SqlParameter("@Diem_CK", dangKy.Diem_CK),
                new SqlParameter("@HuyDangKy", dangKy.HuyDangKy)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool UpdateDangKy(DangKy dangKy)
        {
            string query = "UPDATE Dangky SET DIEM_CC = @Diem_CC, DIEM_GK = @Diem_GK, DIEM_CK = @Diem_CK, " +
                          "HUYDANGKY = @HuyDangKy WHERE MALTC = @MaLTC AND MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", dangKy.MaLTC),
                new SqlParameter("@MaSV", dangKy.MaSV),
                new SqlParameter("@Diem_CC", dangKy.Diem_CC),
                new SqlParameter("@Diem_GK", dangKy.Diem_GK),
                new SqlParameter("@Diem_CK", dangKy.Diem_CK),
                new SqlParameter("@HuyDangKy", dangKy.HuyDangKy)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool DeleteDangKy(int maLTC, string maSV)
        {
            string query = "UPDATE Dangky SET HUYDANGKY = 1 WHERE MALTC = @MaLTC AND MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC),
                new SqlParameter("@MaSV", maSV)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool UpdateDiemDangKy(int maLTC, string maSV, int diemCC, float diemGK, float diemCK)
        {
            string query = "UPDATE Dangky SET DIEM_CC = @Diem_CC, DIEM_GK = @Diem_GK, DIEM_CK = @Diem_CK " +
                          "WHERE MALTC = @MaLTC AND MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC),
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@Diem_CC", diemCC),
                new SqlParameter("@Diem_GK", diemGK),
                new SqlParameter("@Diem_CK", diemCK)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
