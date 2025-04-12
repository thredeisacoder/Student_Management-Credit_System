using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class KhoaDAL
    {
        public static List<Khoa> GetAllKhoa()
        {
            List<Khoa> khoas = new List<Khoa>();
            string query = "SELECT * FROM Khoa";
            
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);
            
            foreach (DataRow row in dataTable.Rows)
            {
                Khoa khoa = new Khoa
                {
                    MaKhoa = row["MAKHOA"].ToString(),
                    TenKhoa = row["TENKHOA"].ToString()
                };
                
                khoas.Add(khoa);
            }
            
            return khoas;
        }
        
        public static Khoa GetKhoaByMaKhoa(string maKhoa)
        {
            string query = "SELECT * FROM Khoa WHERE MAKHOA = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", maKhoa)
            };
            
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);
            
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                
                Khoa khoa = new Khoa
                {
                    MaKhoa = row["MAKHOA"].ToString(),
                    TenKhoa = row["TENKHOA"].ToString()
                };
                
                return khoa;
            }
            
            return null;
        }
        
        public static bool InsertKhoa(Khoa khoa)
        {
            string query = "INSERT INTO Khoa (MAKHOA, TENKHOA) VALUES (@MaKhoa, @TenKhoa)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", khoa.MaKhoa),
                new SqlParameter("@TenKhoa", khoa.TenKhoa)
            };
            
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);
            
            return rowsAffected > 0;
        }
        
        public static bool UpdateKhoa(Khoa khoa)
        {
            string query = "UPDATE Khoa SET TENKHOA = @TenKhoa WHERE MAKHOA = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", khoa.MaKhoa),
                new SqlParameter("@TenKhoa", khoa.TenKhoa)
            };
            
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);
            
            return rowsAffected > 0;
        }
        
        public static bool DeleteKhoa(string maKhoa)
        {
            string query = "DELETE FROM Khoa WHERE MAKHOA = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", maKhoa)
            };
            
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);
            
            return rowsAffected > 0;
        }
    }
}
