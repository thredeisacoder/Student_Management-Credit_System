using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class LopDAL
    {
        public static List<Lop> GetAllLop()
        {
            List<Lop> lops = new List<Lop>();
            string query = "SELECT * FROM Lop";
            
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);
            
            foreach (DataRow row in dataTable.Rows)
            {
                Lop lop = new Lop
                {
                    MaLop = row["MALOP"].ToString(),
                    TenLop = row["TENLOP"].ToString(),
                    KhoaHoc = row["KHOAHOC"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString()
                };
                
                lops.Add(lop);
            }
            
            return lops;
        }
        
        public static List<Lop> GetLopsByMaKhoa(string maKhoa)
        {
            List<Lop> lops = new List<Lop>();
            string query = "SELECT * FROM Lop WHERE MAKHOA = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", maKhoa)
            };
            
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);
            
            foreach (DataRow row in dataTable.Rows)
            {
                Lop lop = new Lop
                {
                    MaLop = row["MALOP"].ToString(),
                    TenLop = row["TENLOP"].ToString(),
                    KhoaHoc = row["KHOAHOC"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString()
                };
                
                lops.Add(lop);
            }
            
            return lops;
        }
        
        public static Lop GetLopByMaLop(string maLop)
        {
            string query = "SELECT * FROM Lop WHERE MALOP = @MaLop";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", maLop)
            };
            
            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);
            
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                
                Lop lop = new Lop
                {
                    MaLop = row["MALOP"].ToString(),
                    TenLop = row["TENLOP"].ToString(),
                    KhoaHoc = row["KHOAHOC"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString()
                };
                
                return lop;
            }
            
            return null;
        }
        
        public static bool InsertLop(Lop lop)
        {
            string query = "INSERT INTO Lop (MALOP, TENLOP, KHOAHOC, MAKHOA) VALUES (@MaLop, @TenLop, @KhoaHoc, @MaKhoa)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", lop.MaLop),
                new SqlParameter("@TenLop", lop.TenLop),
                new SqlParameter("@KhoaHoc", lop.KhoaHoc),
                new SqlParameter("@MaKhoa", lop.MaKhoa)
            };
            
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);
            
            return rowsAffected > 0;
        }
        
        public static bool UpdateLop(Lop lop)
        {
            string query = "UPDATE Lop SET TENLOP = @TenLop, KHOAHOC = @KhoaHoc, MAKHOA = @MaKhoa WHERE MALOP = @MaLop";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", lop.MaLop),
                new SqlParameter("@TenLop", lop.TenLop),
                new SqlParameter("@KhoaHoc", lop.KhoaHoc),
                new SqlParameter("@MaKhoa", lop.MaKhoa)
            };
            
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);
            
            return rowsAffected > 0;
        }
        
        public static bool DeleteLop(string maLop)
        {
            string query = "DELETE FROM Lop WHERE MALOP = @MaLop";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", maLop)
            };
            
            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);
            
            return rowsAffected > 0;
        }
    }
}
