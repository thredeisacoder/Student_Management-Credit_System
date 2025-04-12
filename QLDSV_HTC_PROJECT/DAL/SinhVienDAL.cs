using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class SinhVienDAL
    {
        public static List<SinhVien> GetAllSinhVien()
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            string query = "SELECT * FROM Sinhvien WHERE DANGHIHOC = 0";

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                SinhVien sinhVien = new SinhVien
                {
                    MaSV = row["MASV"].ToString(),
                    Ho = row["HO"].ToString(),
                    Ten = row["TEN"].ToString(),
                    MaLop = row["MALOP"].ToString(),
                    Phai = Convert.ToBoolean(row["PHAI"]),
                    NgaySinh = Convert.ToDateTime(row["NGAYSINH"]),
                    DiaChi = row["DIACHI"].ToString(),
                    DaNghiHoc = Convert.ToBoolean(row["DANGHIHOC"]),
                    Password = row["PASSWORD"].ToString()
                };

                sinhViens.Add(sinhVien);
            }

            return sinhViens;
        }

        public static List<SinhVien> GetSinhViensByMaLop(string maLop)
        {
            List<SinhVien> sinhViens = new List<SinhVien>();
            string query = "SELECT * FROM Sinhvien WHERE MALOP = @MaLop AND DANGHIHOC = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLop", maLop)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                SinhVien sinhVien = new SinhVien
                {
                    MaSV = row["MASV"].ToString(),
                    Ho = row["HO"].ToString(),
                    Ten = row["TEN"].ToString(),
                    MaLop = row["MALOP"].ToString(),
                    Phai = Convert.ToBoolean(row["PHAI"]),
                    NgaySinh = Convert.ToDateTime(row["NGAYSINH"]),
                    DiaChi = row["DIACHI"].ToString(),
                    DaNghiHoc = Convert.ToBoolean(row["DANGHIHOC"]),
                    Password = row["PASSWORD"].ToString()
                };

                sinhViens.Add(sinhVien);
            }

            return sinhViens;
        }

        public static SinhVien GetSinhVienByMaSV(string maSV)
        {
            string query = "SELECT * FROM Sinhvien WHERE MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", maSV)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                SinhVien sinhVien = new SinhVien
                {
                    MaSV = row["MASV"].ToString(),
                    Ho = row["HO"].ToString(),
                    Ten = row["TEN"].ToString(),
                    MaLop = row["MALOP"].ToString(),
                    Phai = Convert.ToBoolean(row["PHAI"]),
                    NgaySinh = Convert.ToDateTime(row["NGAYSINH"]),
                    DiaChi = row["DIACHI"].ToString(),
                    DaNghiHoc = Convert.ToBoolean(row["DANGHIHOC"]),
                    Password = row["PASSWORD"].ToString()
                };

                return sinhVien;
            }

            return null;
        }

        public static bool InsertSinhVien(SinhVien sinhVien)
        {
            string query = "INSERT INTO Sinhvien (MASV, HO, TEN, MALOP, PHAI, NGAYSINH, DIACHI, DANGHIHOC, PASSWORD) " +
                          "VALUES (@MaSV, @Ho, @Ten, @MaLop, @Phai, @NgaySinh, @DiaChi, @DaNghiHoc, @Password)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", sinhVien.MaSV),
                new SqlParameter("@Ho", sinhVien.Ho),
                new SqlParameter("@Ten", sinhVien.Ten),
                new SqlParameter("@MaLop", sinhVien.MaLop),
                new SqlParameter("@Phai", sinhVien.Phai),
                new SqlParameter("@NgaySinh", sinhVien.NgaySinh),
                new SqlParameter("@DiaChi", sinhVien.DiaChi),
                new SqlParameter("@DaNghiHoc", sinhVien.DaNghiHoc),
                new SqlParameter("@Password", sinhVien.Password)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool UpdateSinhVien(SinhVien sinhVien)
        {
            string query = "UPDATE Sinhvien SET HO = @Ho, TEN = @Ten, MALOP = @MaLop, PHAI = @Phai, " +
                          "NGAYSINH = @NgaySinh, DIACHI = @DiaChi, DANGHIHOC = @DaNghiHoc, PASSWORD = @Password " +
                          "WHERE MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", sinhVien.MaSV),
                new SqlParameter("@Ho", sinhVien.Ho),
                new SqlParameter("@Ten", sinhVien.Ten),
                new SqlParameter("@MaLop", sinhVien.MaLop),
                new SqlParameter("@Phai", sinhVien.Phai),
                new SqlParameter("@NgaySinh", sinhVien.NgaySinh),
                new SqlParameter("@DiaChi", sinhVien.DiaChi),
                new SqlParameter("@DaNghiHoc", sinhVien.DaNghiHoc),
                new SqlParameter("@Password", sinhVien.Password)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool DeleteSinhVien(string maSV)
        {
            string query = "UPDATE Sinhvien SET DANGHIHOC = 1 WHERE MASV = @MaSV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", maSV)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool CheckLogin(string maSV, string password)
        {
            string query = "SELECT COUNT(*) FROM Sinhvien WHERE MASV = @MaSV AND PASSWORD = @Password AND DANGHIHOC = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSV", maSV),
                new SqlParameter("@Password", password)
            };

            int count = Convert.ToInt32(DatabaseConnection.ExecuteScalar(query, parameters));

            return count > 0;
        }
    }
}
