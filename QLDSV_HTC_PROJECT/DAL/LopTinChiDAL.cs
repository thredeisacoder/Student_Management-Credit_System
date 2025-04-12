using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.DAL
{
    public class LopTinChiDAL
    {
        public static List<LopTinChi> GetAllLopTinChi()
        {
            List<LopTinChi> lopTinChis = new List<LopTinChi>();
            string query = "SELECT * FROM Loptinchi";

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                LopTinChi lopTinChi = new LopTinChi
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    NienKhoa = row["NIENKHOA"].ToString(),
                    HocKy = Convert.ToInt32(row["HOCKY"]),
                    MaMH = row["MAMH"].ToString(),
                    Nhom = Convert.ToInt32(row["NHOM"]),
                    MaGV = row["MAGV"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    SoSVToiThieu = Convert.ToInt16(row["SOSVTOITHIEU"]),
                    HuyLop = Convert.ToBoolean(row["HUYLOP"])
                };

                lopTinChis.Add(lopTinChi);
            }

            return lopTinChis;
        }

        public static List<LopTinChi> GetLopTinChisByMaKhoa(string maKhoa)
        {
            List<LopTinChi> lopTinChis = new List<LopTinChi>();
            string query = "SELECT * FROM Loptinchi WHERE MAKHOA = @MaKhoa";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaKhoa", maKhoa)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                LopTinChi lopTinChi = new LopTinChi
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    NienKhoa = row["NIENKHOA"].ToString(),
                    HocKy = Convert.ToInt32(row["HOCKY"]),
                    MaMH = row["MAMH"].ToString(),
                    Nhom = Convert.ToInt32(row["NHOM"]),
                    MaGV = row["MAGV"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    SoSVToiThieu = Convert.ToInt16(row["SOSVTOITHIEU"]),
                    HuyLop = Convert.ToBoolean(row["HUYLOP"])
                };

                lopTinChis.Add(lopTinChi);
            }

            return lopTinChis;
        }

        public static List<LopTinChi> GetLopTinChisByNienKhoaAndHocKy(string nienKhoa, int hocKy)
        {
            List<LopTinChi> lopTinChis = new List<LopTinChi>();
            string query = "SELECT * FROM Loptinchi WHERE NIENKHOA = @NienKhoa AND HOCKY = @HocKy AND HUYLOP = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NienKhoa", nienKhoa),
                new SqlParameter("@HocKy", hocKy)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            foreach (DataRow row in dataTable.Rows)
            {
                LopTinChi lopTinChi = new LopTinChi
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    NienKhoa = row["NIENKHOA"].ToString(),
                    HocKy = Convert.ToInt32(row["HOCKY"]),
                    MaMH = row["MAMH"].ToString(),
                    Nhom = Convert.ToInt32(row["NHOM"]),
                    MaGV = row["MAGV"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    SoSVToiThieu = Convert.ToInt16(row["SOSVTOITHIEU"]),
                    HuyLop = Convert.ToBoolean(row["HUYLOP"])
                };

                lopTinChis.Add(lopTinChi);
            }

            return lopTinChis;
        }

        public static LopTinChi GetLopTinChiByMaLTC(int maLTC)
        {
            string query = "SELECT * FROM Loptinchi WHERE MALTC = @MaLTC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC)
            };

            DataTable dataTable = DatabaseConnection.ExecuteQuery(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                LopTinChi lopTinChi = new LopTinChi
                {
                    MaLTC = Convert.ToInt32(row["MALTC"]),
                    NienKhoa = row["NIENKHOA"].ToString(),
                    HocKy = Convert.ToInt32(row["HOCKY"]),
                    MaMH = row["MAMH"].ToString(),
                    Nhom = Convert.ToInt32(row["NHOM"]),
                    MaGV = row["MAGV"].ToString(),
                    MaKhoa = row["MAKHOA"].ToString(),
                    SoSVToiThieu = Convert.ToInt16(row["SOSVTOITHIEU"]),
                    HuyLop = Convert.ToBoolean(row["HUYLOP"])
                };

                return lopTinChi;
            }

            return null;
        }

        public static int InsertLopTinChi(LopTinChi lopTinChi)
        {
            string query = "INSERT INTO Loptinchi (NIENKHOA, HOCKY, MAMH, NHOM, MAGV, MAKHOA, SOSVTOITHIEU, HUYLOP) " +
                          "VALUES (@NienKhoa, @HocKy, @MaMH, @Nhom, @MaGV, @MaKhoa, @SoSVToiThieu, @HuyLop); " +
                          "SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@NienKhoa", lopTinChi.NienKhoa),
                new SqlParameter("@HocKy", lopTinChi.HocKy),
                new SqlParameter("@MaMH", lopTinChi.MaMH),
                new SqlParameter("@Nhom", lopTinChi.Nhom),
                new SqlParameter("@MaGV", lopTinChi.MaGV),
                new SqlParameter("@MaKhoa", lopTinChi.MaKhoa),
                new SqlParameter("@SoSVToiThieu", lopTinChi.SoSVToiThieu),
                new SqlParameter("@HuyLop", lopTinChi.HuyLop)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);

            return Convert.ToInt32(result);
        }

        public static bool UpdateLopTinChi(LopTinChi lopTinChi)
        {
            string query = "UPDATE Loptinchi SET NIENKHOA = @NienKhoa, HOCKY = @HocKy, MAMH = @MaMH, " +
                          "NHOM = @Nhom, MAGV = @MaGV, MAKHOA = @MaKhoa, SOSVTOITHIEU = @SoSVToiThieu, " +
                          "HUYLOP = @HuyLop WHERE MALTC = @MaLTC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", lopTinChi.MaLTC),
                new SqlParameter("@NienKhoa", lopTinChi.NienKhoa),
                new SqlParameter("@HocKy", lopTinChi.HocKy),
                new SqlParameter("@MaMH", lopTinChi.MaMH),
                new SqlParameter("@Nhom", lopTinChi.Nhom),
                new SqlParameter("@MaGV", lopTinChi.MaGV),
                new SqlParameter("@MaKhoa", lopTinChi.MaKhoa),
                new SqlParameter("@SoSVToiThieu", lopTinChi.SoSVToiThieu),
                new SqlParameter("@HuyLop", lopTinChi.HuyLop)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static bool DeleteLopTinChi(int maLTC)
        {
            string query = "UPDATE Loptinchi SET HUYLOP = 1 WHERE MALTC = @MaLTC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC)
            };

            int rowsAffected = DatabaseConnection.ExecuteNonQuery(query, parameters);

            return rowsAffected > 0;
        }

        public static int GetSoSVDangKy(int maLTC)
        {
            string query = "SELECT COUNT(*) FROM Dangky WHERE MALTC = @MaLTC AND HUYDANGKY = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaLTC", maLTC)
            };

            object result = DatabaseConnection.ExecuteScalar(query, parameters);

            return Convert.ToInt32(result);
        }
    }
}
