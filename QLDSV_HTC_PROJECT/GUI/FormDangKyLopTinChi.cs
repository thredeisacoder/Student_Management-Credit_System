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
    public partial class FormDangKyLopTinChi : Form
    {
        private SinhVien sinhVien;
        private List<LopTinChi> lopTinChis;
        private List<DangKy> dangKys;

        public FormDangKyLopTinChi()
        {
            InitializeComponent();
        }

        private void FormDangKyLopTinChi_Load(object sender, EventArgs e)
        {
            // Set initial state
            SetControlState(false);
            
            // Load NienKhoa and HocKy ComboBox
            LoadNienKhoaHocKy();
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

        private void SetControlState(bool isStudentLoaded)
        {
            // Set controls state based on whether a student is loaded
            txtMaSV.Enabled = !isStudentLoaded;
            btnTimSV.Enabled = !isStudentLoaded;
            
            cboNienKhoa.Enabled = isStudentLoaded;
            cboHocKy.Enabled = isStudentLoaded;
            btnLocLTC.Enabled = isStudentLoaded;
            
            dgvLopTinChi.Enabled = isStudentLoaded;
            btnDangKy.Enabled = isStudentLoaded && dgvLopTinChi.SelectedRows.Count > 0;
            btnHuyDangKy.Enabled = isStudentLoaded && dgvDangKy.SelectedRows.Count > 0;
            
            // Clear student info if not loaded
            if (!isStudentLoaded)
            {
                txtHoTen.Text = "";
                txtMaLop.Text = "";
                dgvLopTinChi.DataSource = null;
                dgvDangKy.DataSource = null;
            }
        }

        private void btnTimSV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            
            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Mã SV cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return;
            }
            
            try
            {
                // Get SinhVien by MaSV
                sinhVien = SinhVienBLL.GetSinhVienByMaSV(maSV);
                
                if (sinhVien != null)
                {
                    // Display student info
                    txtHoTen.Text = sinhVien.Ho + " " + sinhVien.Ten;
                    txtMaLop.Text = sinhVien.MaLop;
                    
                    // Set control state
                    SetControlState(true);
                    
                    // Load registered courses
                    LoadDangKy();
                }
                else
                {
                    MessageBox.Show("Student not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaSV.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error finding student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocLTC_Click(object sender, EventArgs e)
        {
            if (cboNienKhoa.SelectedItem == null || cboHocKy.SelectedItem == null)
            {
                MessageBox.Show("Please select NienKhoa and HocKy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string nienKhoa = cboNienKhoa.SelectedItem.ToString();
            int hocKy = Convert.ToInt32(cboHocKy.SelectedItem.ToString());
            
            try
            {
                // Get LopTinChi by NienKhoa and HocKy
                lopTinChis = LopTinChiBLL.GetLopTinChisByNienKhoaAndHocKy(nienKhoa, hocKy);
                
                // Create DataTable for display
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("MaLTC", typeof(int));
                dataTable.Columns.Add("MaMH", typeof(string));
                dataTable.Columns.Add("TenMH", typeof(string));
                dataTable.Columns.Add("Nhom", typeof(int));
                dataTable.Columns.Add("HoTenGV", typeof(string));
                dataTable.Columns.Add("SoSVToiThieu", typeof(short));
                dataTable.Columns.Add("SoSVDangKy", typeof(int));
                dataTable.Columns.Add("ConSlot", typeof(bool));
                
                foreach (LopTinChi ltc in lopTinChis)
                {
                    // Skip if HuyLop is true
                    if (ltc.HuyLop)
                        continue;
                    
                    // Get MonHoc info
                    MonHoc monHoc = MonHocBLL.GetMonHocByMaMH(ltc.MaMH);
                    
                    // Get GiangVien info
                    GiangVien giangVien = GiangVienBLL.GetGiangVienByMaGV(ltc.MaGV);
                    
                    // Get number of registered students
                    int soSVDangKy = LopTinChiBLL.GetSoSVDangKy(ltc.MaLTC);
                    
                    // Check if student is already registered
                    bool isRegistered = false;
                    foreach (DangKy dk in dangKys)
                    {
                        if (dk.MaLTC == ltc.MaLTC && !dk.HuyDangKy)
                        {
                            isRegistered = true;
                            break;
                        }
                    }
                    
                    // Skip if already registered
                    if (isRegistered)
                        continue;
                    
                    // Add row to DataTable
                    dataTable.Rows.Add(
                        ltc.MaLTC,
                        ltc.MaMH,
                        monHoc != null ? monHoc.TenMH : "",
                        ltc.Nhom,
                        giangVien != null ? giangVien.Ho + " " + giangVien.Ten : "",
                        ltc.SoSVToiThieu,
                        soSVDangKy,
                        true
                    );
                }
                
                // Bind to DataGridView
                dgvLopTinChi.DataSource = dataTable;
                
                // Format DataGridView
                FormatLopTinChiDataGridView();
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
            dgvLopTinChi.Columns["SoSVToiThieu"].HeaderText = "Số SV tối thiểu";
            dgvLopTinChi.Columns["SoSVDangKy"].HeaderText = "Số SV đăng ký";
            dgvLopTinChi.Columns["ConSlot"].HeaderText = "Còn slot";
            
            // Set column widths
            dgvLopTinChi.Columns["MaLTC"].Width = 80;
            dgvLopTinChi.Columns["MaMH"].Width = 80;
            dgvLopTinChi.Columns["TenMH"].Width = 150;
            dgvLopTinChi.Columns["Nhom"].Width = 60;
            dgvLopTinChi.Columns["HoTenGV"].Width = 150;
            dgvLopTinChi.Columns["SoSVToiThieu"].Width = 100;
            dgvLopTinChi.Columns["SoSVDangKy"].Width = 100;
            dgvLopTinChi.Columns["ConSlot"].Width = 80;
            
            // Format boolean column
            DataGridViewCheckBoxColumn conSlotColumn = new DataGridViewCheckBoxColumn();
            conSlotColumn.DataPropertyName = "ConSlot";
            conSlotColumn.HeaderText = "Còn slot";
            conSlotColumn.Width = 80;
            conSlotColumn.TrueValue = true;
            conSlotColumn.FalseValue = false;
            conSlotColumn.ReadOnly = true;
            
            // Replace column
            int conSlotIndex = dgvLopTinChi.Columns["ConSlot"].Index;
            dgvLopTinChi.Columns.Remove("ConSlot");
            dgvLopTinChi.Columns.Insert(conSlotIndex, conSlotColumn);
        }

        private void LoadDangKy()
        {
            try
            {
                // Get DangKy by MaSV
                dangKys = DangKyBLL.GetDangKysByMaSV(sinhVien.MaSV);
                
                // Create DataTable for display
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("MaLTC", typeof(int));
                dataTable.Columns.Add("MaMH", typeof(string));
                dataTable.Columns.Add("TenMH", typeof(string));
                dataTable.Columns.Add("NienKhoa", typeof(string));
                dataTable.Columns.Add("HocKy", typeof(int));
                dataTable.Columns.Add("Nhom", typeof(int));
                dataTable.Columns.Add("HoTenGV", typeof(string));
                
                foreach (DangKy dk in dangKys)
                {
                    // Skip if HuyDangKy is true
                    if (dk.HuyDangKy)
                        continue;
                    
                    // Get LopTinChi info
                    LopTinChi ltc = LopTinChiBLL.GetLopTinChiByMaLTC(dk.MaLTC);
                    
                    if (ltc == null)
                        continue;
                    
                    // Get MonHoc info
                    MonHoc monHoc = MonHocBLL.GetMonHocByMaMH(ltc.MaMH);
                    
                    // Get GiangVien info
                    GiangVien giangVien = GiangVienBLL.GetGiangVienByMaGV(ltc.MaGV);
                    
                    // Add row to DataTable
                    dataTable.Rows.Add(
                        ltc.MaLTC,
                        ltc.MaMH,
                        monHoc != null ? monHoc.TenMH : "",
                        ltc.NienKhoa,
                        ltc.HocKy,
                        ltc.Nhom,
                        giangVien != null ? giangVien.Ho + " " + giangVien.Ten : ""
                    );
                }
                
                // Bind to DataGridView
                dgvDangKy.DataSource = dataTable;
                
                // Format DataGridView
                FormatDangKyDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading DangKy: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDangKyDataGridView()
        {
            // Set column headers
            dgvDangKy.Columns["MaLTC"].HeaderText = "Mã LTC";
            dgvDangKy.Columns["MaMH"].HeaderText = "Mã MH";
            dgvDangKy.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvDangKy.Columns["NienKhoa"].HeaderText = "Niên khóa";
            dgvDangKy.Columns["HocKy"].HeaderText = "Học kỳ";
            dgvDangKy.Columns["Nhom"].HeaderText = "Nhóm";
            dgvDangKy.Columns["HoTenGV"].HeaderText = "Giảng viên";
            
            // Set column widths
            dgvDangKy.Columns["MaLTC"].Width = 80;
            dgvDangKy.Columns["MaMH"].Width = 80;
            dgvDangKy.Columns["TenMH"].Width = 150;
            dgvDangKy.Columns["NienKhoa"].Width = 100;
            dgvDangKy.Columns["HocKy"].Width = 60;
            dgvDangKy.Columns["Nhom"].Width = 60;
            dgvDangKy.Columns["HoTenGV"].Width = 150;
        }

        private void dgvLopTinChi_SelectionChanged(object sender, EventArgs e)
        {
            // Update button state
            btnDangKy.Enabled = dgvLopTinChi.SelectedRows.Count > 0;
        }

        private void dgvDangKy_SelectionChanged(object sender, EventArgs e)
        {
            // Update button state
            btnHuyDangKy.Enabled = dgvDangKy.SelectedRows.Count > 0;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (dgvLopTinChi.SelectedRows.Count > 0)
            {
                int maLTC = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["MaLTC"].Value);
                string maMH = dgvLopTinChi.SelectedRows[0].Cells["MaMH"].Value.ToString();
                string tenMH = dgvLopTinChi.SelectedRows[0].Cells["TenMH"].Value.ToString();
                
                try
                {
                    // Create new DangKy
                    DangKy dangKy = new DangKy
                    {
                        MaLTC = maLTC,
                        MaSV = sinhVien.MaSV,
                        Diem_CC = 0,
                        Diem_GK = 0,
                        Diem_CK = 0,
                        HuyDangKy = false
                    };
                    
                    // Insert DangKy
                    bool success = DangKyBLL.InsertDangKy(dangKy);
                    
                    if (success)
                    {
                        MessageBox.Show($"Registered for {tenMH} successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Refresh data
                        LoadDangKy();
                        btnLocLTC_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error registering for course: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.SelectedRows.Count > 0)
            {
                int maLTC = Convert.ToInt32(dgvDangKy.SelectedRows[0].Cells["MaLTC"].Value);
                string tenMH = dgvDangKy.SelectedRows[0].Cells["TenMH"].Value.ToString();
                
                DialogResult result = MessageBox.Show($"Are you sure you want to cancel registration for {tenMH}?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Delete DangKy
                        bool success = DangKyBLL.DeleteDangKy(maLTC, sinhVien.MaSV);
                        
                        if (success)
                        {
                            MessageBox.Show($"Cancelled registration for {tenMH} successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            // Refresh data
                            LoadDangKy();
                            btnLocLTC_Click(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error cancelling registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
