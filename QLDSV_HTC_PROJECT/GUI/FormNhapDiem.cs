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
using QLDSV_HTC.DTO.Models;

namespace QLDSV_HTC.GUI
{
    public partial class FormNhapDiem : Form
    {
        private List<Khoa> khoas;
        private List<LopTinChi> lopTinChis;
        private List<DangKy> dangKys;
        private DataTable diemDataTable;

        public FormNhapDiem()
        {
            InitializeComponent();
        }

        private void FormNhapDiem_Load(object sender, EventArgs e)
        {
            // Load data
            LoadKhoa();
            LoadNienKhoaHocKy();
            
            // Set initial state
            SetControlState(false);
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

        private void LoadLopTinChi()
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
                    dataTable.Columns.Add("SoSVDangKy", typeof(int));
                    
                    foreach (LopTinChi ltc in lopTinChis)
                    {
                        // Get MonHoc info
                        MonHoc monHoc = MonHocBLL.GetMonHocByMaMH(ltc.MaMH);
                        
                        // Get GiangVien info
                        GiangVien giangVien = GiangVienBLL.GetGiangVienByMaGV(ltc.MaGV);
                        
                        // Get number of registered students
                        int soSVDangKy = LopTinChiBLL.GetSoSVDangKy(ltc.MaLTC);
                        
                        // Add row to DataTable
                        dataTable.Rows.Add(
                            ltc.MaLTC,
                            ltc.MaMH,
                            monHoc != null ? monHoc.TenMH : "",
                            ltc.Nhom,
                            giangVien != null ? giangVien.Ho + " " + giangVien.Ten : "",
                            soSVDangKy
                        );
                    }
                    
                    // Bind to DataGridView
                    dgvLopTinChi.DataSource = dataTable;
                    
                    // Format DataGridView
                    FormatLopTinChiDataGridView();
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
            dgvLopTinChi.Columns["SoSVDangKy"].HeaderText = "Số SV đăng ký";
            
            // Set column widths
            dgvLopTinChi.Columns["MaLTC"].Width = 80;
            dgvLopTinChi.Columns["MaMH"].Width = 80;
            dgvLopTinChi.Columns["TenMH"].Width = 150;
            dgvLopTinChi.Columns["Nhom"].Width = 60;
            dgvLopTinChi.Columns["HoTenGV"].Width = 150;
            dgvLopTinChi.Columns["SoSVDangKy"].Width = 100;
        }

        private void LoadDangKy()
        {
            try
            {
                if (dgvLopTinChi.SelectedRows.Count > 0)
                {
                    int maLTC = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["MaLTC"].Value);
                    
                    // Get DangKy by MaLTC
                    dangKys = DangKyBLL.GetDangKysByMaLTC(maLTC);
                    
                    // Create DataTable for display and editing
                    diemDataTable = new DataTable();
                    diemDataTable.Columns.Add("MaSV", typeof(string));
                    diemDataTable.Columns.Add("HoTen", typeof(string));
                    diemDataTable.Columns.Add("Diem_CC", typeof(int));
                    diemDataTable.Columns.Add("Diem_GK", typeof(float));
                    diemDataTable.Columns.Add("Diem_CK", typeof(float));
                    diemDataTable.Columns.Add("DiemHetMon", typeof(float));
                    
                    foreach (DangKy dk in dangKys)
                    {
                        // Skip if HuyDangKy is true
                        if (dk.HuyDangKy)
                            continue;
                        
                        // Get SinhVien info
                        SinhVien sinhVien = SinhVienBLL.GetSinhVienByMaSV(dk.MaSV);
                        
                        if (sinhVien == null)
                            continue;
                        
                        // Calculate DiemHetMon
                        float diemHetMon = dk.DiemHetMon;
                        
                        // Add row to DataTable
                        diemDataTable.Rows.Add(
                            dk.MaSV,
                            sinhVien.Ho + " " + sinhVien.Ten,
                            dk.Diem_CC,
                            dk.Diem_GK,
                            dk.Diem_CK,
                            diemHetMon
                        );
                    }
                    
                    // Bind to DataGridView
                    dgvDiem.DataSource = diemDataTable;
                    
                    // Format DataGridView
                    FormatDiemDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading DangKy: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDiemDataGridView()
        {
            // Set column headers
            dgvDiem.Columns["MaSV"].HeaderText = "Mã SV";
            dgvDiem.Columns["HoTen"].HeaderText = "Họ tên";
            dgvDiem.Columns["Diem_CC"].HeaderText = "Điểm chuyên cần";
            dgvDiem.Columns["Diem_GK"].HeaderText = "Điểm giữa kỳ";
            dgvDiem.Columns["Diem_CK"].HeaderText = "Điểm cuối kỳ";
            dgvDiem.Columns["DiemHetMon"].HeaderText = "Điểm hết môn";
            
            // Set column widths
            dgvDiem.Columns["MaSV"].Width = 80;
            dgvDiem.Columns["HoTen"].Width = 150;
            dgvDiem.Columns["Diem_CC"].Width = 100;
            dgvDiem.Columns["Diem_GK"].Width = 100;
            dgvDiem.Columns["Diem_CK"].Width = 100;
            dgvDiem.Columns["DiemHetMon"].Width = 100;
            
            // Set read-only columns
            dgvDiem.Columns["MaSV"].ReadOnly = true;
            dgvDiem.Columns["HoTen"].ReadOnly = true;
            dgvDiem.Columns["DiemHetMon"].ReadOnly = true;
            
            // Set editable columns
            dgvDiem.Columns["Diem_CC"].ReadOnly = false;
            dgvDiem.Columns["Diem_GK"].ReadOnly = false;
            dgvDiem.Columns["Diem_CK"].ReadOnly = false;
        }

        private void SetControlState(bool isLopTinChiSelected)
        {
            // Set controls state based on whether a LopTinChi is selected
            cboKhoa.Enabled = true;
            cboNienKhoa.Enabled = true;
            cboHocKy.Enabled = true;
            btnLocLTC.Enabled = true;
            
            dgvLopTinChi.Enabled = true;
            dgvDiem.Enabled = isLopTinChiSelected;
            btnGhi.Enabled = isLopTinChiSelected;
            
            // Clear diem data if no LopTinChi is selected
            if (!isLopTinChiSelected)
            {
                dgvDiem.DataSource = null;
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset LopTinChi and Diem data
            dgvLopTinChi.DataSource = null;
            dgvDiem.DataSource = null;
            SetControlState(false);
        }

        private void cboNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset LopTinChi and Diem data
            dgvLopTinChi.DataSource = null;
            dgvDiem.DataSource = null;
            SetControlState(false);
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reset LopTinChi and Diem data
            dgvLopTinChi.DataSource = null;
            dgvDiem.DataSource = null;
            SetControlState(false);
        }

        private void btnLocLTC_Click(object sender, EventArgs e)
        {
            LoadLopTinChi();
            SetControlState(false);
        }

        private void dgvLopTinChi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLopTinChi.SelectedRows.Count > 0)
            {
                LoadDangKy();
                SetControlState(true);
            }
            else
            {
                SetControlState(false);
            }
        }

        private void dgvDiem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Get the edited cell
                DataGridViewCell cell = dgvDiem.Rows[e.RowIndex].Cells[e.ColumnIndex];
                
                // Validate the value based on the column
                if (e.ColumnIndex == dgvDiem.Columns["Diem_CC"].Index)
                {
                    // Validate Diem_CC (0-10)
                    int diemCC = Convert.ToInt32(cell.Value);
                    if (diemCC < 0 || diemCC > 10)
                    {
                        MessageBox.Show("Điểm chuyên cần phải từ 0 đến 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cell.Value = 0;
                        return;
                    }
                }
                else if (e.ColumnIndex == dgvDiem.Columns["Diem_GK"].Index || e.ColumnIndex == dgvDiem.Columns["Diem_CK"].Index)
                {
                    // Validate Diem_GK and Diem_CK (0-10)
                    float diem = Convert.ToSingle(cell.Value);
                    if (diem < 0 || diem > 10)
                    {
                        MessageBox.Show("Điểm phải từ 0 đến 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cell.Value = 0;
                        return;
                    }
                }
                
                // Recalculate DiemHetMon
                int rowDiemCC = Convert.ToInt32(dgvDiem.Rows[e.RowIndex].Cells["Diem_CC"].Value);
                float rowDiemGK = Convert.ToSingle(dgvDiem.Rows[e.RowIndex].Cells["Diem_GK"].Value);
                float rowDiemCK = Convert.ToSingle(dgvDiem.Rows[e.RowIndex].Cells["Diem_CK"].Value);
                
                float diemHetMon = rowDiemCC * 0.1f + rowDiemGK * 0.3f + rowDiemCK * 0.6f;
                
                // Update DiemHetMon cell
                dgvDiem.Rows[e.RowIndex].Cells["DiemHetMon"].Value = diemHetMon;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating grade: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLopTinChi.SelectedRows.Count > 0)
                {
                    int maLTC = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["MaLTC"].Value);
                    
                    // Update grades for each student
                    foreach (DataRow row in diemDataTable.Rows)
                    {
                        string maSV = row["MaSV"].ToString();
                        int diemCC = Convert.ToInt32(row["Diem_CC"]);
                        float diemGK = Convert.ToSingle(row["Diem_GK"]);
                        float diemCK = Convert.ToSingle(row["Diem_CK"]);
                        
                        // Update DangKy
                        bool success = DangKyBLL.UpdateDiemDangKy(maLTC, maSV, diemCC, diemGK, diemCK);
                        
                        if (!success)
                        {
                            MessageBox.Show($"Failed to update grades for student {maSV}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                    MessageBox.Show("Grades updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving grades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
