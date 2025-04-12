using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class MonHocDAL
    {
        public static List<MonHoc> GetAllMonHoc()
        {
            List<MonHoc> monHocs = new List<MonHoc>();
            string query = "SELECT * FROM Monhoc";

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                MonHoc monHoc = new MonHoc
                {
                    MaMH = row["MAMH"].ToString(),
                    TenMH = row["TENMH"].ToString(),
                    SoTiet_LT = Convert.ToInt32(row["SOTIET_LT"]),
                    SoTiet_TH = Convert.ToInt32(row["SOTIET_TH"])
                };

                monHocs.Add(monHoc);
            }

            return monHocs;
        }

        public static MonHoc GetMonHocByMaMH(string maMH)
        {
            string query = "SELECT * FROM Monhoc WHERE MAMH = @MaMH";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMH", maMH)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                MonHoc monHoc = new MonHoc
                {
                    MaMH = row["MAMH"].ToString(),
                    TenMH = row["TENMH"].ToString(),
                    SoTiet_LT = Convert.ToInt32(row["SOTIET_LT"]),
                    SoTiet_TH = Convert.ToInt32(row["SOTIET_TH"])
                };

                return monHoc;
            }

            return null;
        }

        public static bool InsertMonHoc(MonHoc monHoc)
        {
            string query = "INSERT INTO Monhoc (MAMH, TENMH, SOTIET_LT, SOTIET_TH) VALUES (@MaMH, @TenMH, @SoTiet_LT, @SoTiet_TH)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMH", monHoc.MaMH),
                new SqlParameter("@TenMH", monHoc.TenMH),
                new SqlParameter("@SoTiet_LT", monHoc.SoTiet_LT),
                new SqlParameter("@SoTiet_TH", monHoc.SoTiet_TH)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool UpdateMonHoc(MonHoc monHoc)
        {
            string query = "UPDATE Monhoc SET TENMH = @TenMH, SOTIET_LT = @SoTiet_LT, SOTIET_TH = @SoTiet_TH WHERE MAMH = @MaMH";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMH", monHoc.MaMH),
                new SqlParameter("@TenMH", monHoc.TenMH),
                new SqlParameter("@SoTiet_LT", monHoc.SoTiet_LT),
                new SqlParameter("@SoTiet_TH", monHoc.SoTiet_TH)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool DeleteMonHoc(string maMH)
        {
            string query = "DELETE FROM Monhoc WHERE MAMH = @MaMH";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaMH", maMH)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }
    }
}
