using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV_HTC.BLL;
using QLDSV_HTC.DAL;
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.GUI
{
    public partial class FormDanhSachSinhVienDangKy : Form
    {
        private List<Khoa> khoas;
        private List<LopTinChi> lopTinChis;
        private List<DangKy> dangKys;

        public FormDanhSachSinhVienDangKy()
        {
            InitializeComponent();
        }

        private void FormDanhSachSinhVienDangKy_Load(object sender, EventArgs e)
        {
            // Load data
            LoadKhoa();
            LoadNienKhoaHocKy();
        }

        private void LoadKhoa()
        {
            try
            {
                // Get all Khoa
                khoas = KhoaBLL.GetAllKhoa();

                // Bind to ComboBox
                cboKhoa.DataSource = khoas;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "MaKhoa";

                // Select the first item
                if (khoas.Count > 0)
                {
                    cboKhoa.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Khoa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNienKhoaHocKy()
        {
            // Add some sample NienKhoa values
            cboNienKhoa.Items.Add("2020-2021");
            cboNienKhoa.Items.Add("2021-2022");
            cboNienKhoa.Items.Add("2022-2023");
            cboNienKhoa.Items.Add("2023-2024");
            cboNienKhoa.Items.Add("2024-2025");

            // Select the first item
            if (cboNienKhoa.Items.Count > 0)
            {
                cboNienKhoa.SelectedIndex = 0;
            }

            // Add HocKy values
            cboHocKy.Items.Add("1");
            cboHocKy.Items.Add("2");
            cboHocKy.Items.Add("3");

            // Select the first item
            if (cboHocKy.Items.Count > 0)
            {
                cboHocKy.SelectedIndex = 0;
            }
        }

        private void btnLocLTC_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoa.SelectedValue != null && cboNienKhoa.SelectedItem != null && cboHocKy.SelectedItem != null)
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();
                    string nienKhoa = cboNienKhoa.SelectedItem.ToString();
                    int hocKy = Convert.ToInt32(cboHocKy.SelectedItem.ToString());

                    // Get LopTinChi by MaKhoa, NienKhoa, and HocKy
                    lopTinChis = new List<LopTinChi>();
                    foreach (LopTinChi ltc in LopTinChiBLL.GetLopTinChisByMaKhoa(maKhoa))
                    {
                        if (ltc.NienKhoa == nienKhoa && ltc.HocKy == hocKy && !ltc.HuyLop)
                        {
                            lopTinChis.Add(ltc);
                        }
                    }

                    // Create DataTable for display
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("MaLTC", typeof(int));
                    dataTable.Columns.Add("MaMH", typeof(string));
                    dataTable.Columns.Add("TenMH", typeof(string));
                    dataTable.Columns.Add("Nhom", typeof(int));
                    dataTable.Columns.Add("HoTenGV", typeof(string));

                    foreach (LopTinChi ltc in lopTinChis)
                    {
                        // Get MonHoc info
                        MonHoc monHoc = MonHocBLL.GetMonHocByMaMH(ltc.MaMH);

                        // Get GiangVien info
                        GiangVien giangVien = GiangVienBLL.GetGiangVienByMaGV(ltc.MaGV);

                        // Add row to DataTable
                        dataTable.Rows.Add(
                            ltc.MaLTC,
                            ltc.MaMH,
                            monHoc != null ? monHoc.TenMH : "",
                            ltc.Nhom,
                            giangVien != null ? giangVien.Ho + " " + giangVien.Ten : ""
                        );
                    }

                    // Bind to DataGridView
                    dgvLopTinChi.DataSource = dataTable;

                    // Format DataGridView
                    FormatLopTinChiDataGridView();

                    // Show LopTinChi panel
                    panelLopTinChi.Visible = true;

                    // Hide report panel
                    panelReport.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading LopTinChi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatLopTinChiDataGridView()
        {
            // Set column headers
            dgvLopTinChi.Columns["MaLTC"].HeaderText = "Mã LTC";
            dgvLopTinChi.Columns["MaMH"].HeaderText = "Mã MH";
            dgvLopTinChi.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvLopTinChi.Columns["Nhom"].HeaderText = "Nhóm";
            dgvLopTinChi.Columns["HoTenGV"].HeaderText = "Giảng viên";

            // Set column widths
            dgvLopTinChi.Columns["MaLTC"].Width = 80;
            dgvLopTinChi.Columns["MaMH"].Width = 80;
            dgvLopTinChi.Columns["TenMH"].Width = 150;
            dgvLopTinChi.Columns["Nhom"].Width = 60;
            dgvLopTinChi.Columns["HoTenGV"].Width = 150;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLopTinChi.SelectedRows.Count > 0)
                {
                    int maLTC = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["MaLTC"].Value);
                    string maMH = dgvLopTinChi.SelectedRows[0].Cells["MaMH"].Value.ToString();
                    string tenMH = dgvLopTinChi.SelectedRows[0].Cells["TenMH"].Value.ToString();
                    int nhom = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["Nhom"].Value);

                    // Get LopTinChi info
                    LopTinChi lopTinChi = LopTinChiBLL.GetLopTinChiByMaLTC(maLTC);

                    if (lopTinChi != null)
                    {
                        // Get DangKy by MaLTC
                        dangKys = DangKyDAL.GetDangKysByMaLTC(maLTC);

                        // Create DataTable for report
                        DataTable dataTable = new DataTable();
                        dataTable.Columns.Add("STT", typeof(int));
                        dataTable.Columns.Add("MaSV", typeof(string));
                        dataTable.Columns.Add("HoTen", typeof(string));
                        dataTable.Columns.Add("Phai", typeof(string));
                        dataTable.Columns.Add("MaLop", typeof(string));
                        dataTable.Columns.Add("DiemCC", typeof(int));
                        dataTable.Columns.Add("DiemGK", typeof(float));
                        dataTable.Columns.Add("DiemCK", typeof(float));
                        dataTable.Columns.Add("DiemHetMon", typeof(float));

                        int stt = 1;
                        foreach (DangKy dk in dangKys)
                        {
                            // Skip if HuyDangKy is true
                            if (dk.HuyDangKy)
                                continue;

                            // Get SinhVien info
                            SinhVien sinhVien = SinhVienBLL.GetSinhVienByMaSV(dk.MaSV);

                            if (sinhVien == null)
                                continue;

                            // Add row to DataTable
                            dataTable.Rows.Add(
                                stt++,
                                dk.MaSV,
                                sinhVien.Ho + " " + sinhVien.Ten,
                                sinhVien.Phai ? "Nữ" : "Nam",
                                sinhVien.MaLop,
                                dk.Diem_CC,
                                dk.Diem_GK,
                                dk.Diem_CK,
                                dk.DiemHetMon
                            );
                        }

                        // Bind to DataGridView
                        dgvSinhVien.DataSource = dataTable;

                        // Format DataGridView
                        FormatSinhVienDataGridView();

                        // Set report title
                        string tenKhoa = cboKhoa.Text;
                        string nienKhoa = cboNienKhoa.SelectedItem.ToString();
                        int hocKy = Convert.ToInt32(cboHocKy.SelectedItem.ToString());

                        lblReportTitle.Text = $"DANH SÁCH SINH VIÊN ĐĂNG KÝ LỚP TÍN CHỈ";
                        lblReportSubtitle.Text = $"Môn học: {tenMH} - Nhóm: {nhom} - Niên khóa: {nienKhoa} - Học kỳ: {hocKy}";

                        // Show report panel
                        panelReport.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatSinhVienDataGridView()
        {
            // Set column headers
            dgvSinhVien.Columns["STT"].HeaderText = "STT";
            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["HoTen"].HeaderText = "Họ tên";
            dgvSinhVien.Columns["Phai"].HeaderText = "Phái";
            dgvSinhVien.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvSinhVien.Columns["DiemCC"].HeaderText = "Điểm CC";
            dgvSinhVien.Columns["DiemGK"].HeaderText = "Điểm GK";
            dgvSinhVien.Columns["DiemCK"].HeaderText = "Điểm CK";
            dgvSinhVien.Columns["DiemHetMon"].HeaderText = "Điểm hết môn";

            // Set column widths
            dgvSinhVien.Columns["STT"].Width = 50;
            dgvSinhVien.Columns["MaSV"].Width = 80;
            dgvSinhVien.Columns["HoTen"].Width = 150;
            dgvSinhVien.Columns["Phai"].Width = 60;
            dgvSinhVien.Columns["MaLop"].Width = 80;
            dgvSinhVien.Columns["DiemCC"].Width = 80;
            dgvSinhVien.Columns["DiemGK"].Width = 80;
            dgvSinhVien.Columns["DiemCK"].Width = 80;
            dgvSinhVien.Columns["DiemHetMon"].Width = 100;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // TODO: Implement printing functionality
            MessageBox.Show("Printing functionality not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
