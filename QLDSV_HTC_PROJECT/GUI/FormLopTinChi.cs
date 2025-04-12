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
    public partial class FormLopTinChi : Form
    {
        private List<Khoa> khoas;
        private List<MonHoc> monHocs;
        private List<GiangVien> giangViens;
        private List<LopTinChi> lopTinChis;
        private bool isAdding = false;
        private bool isEditing = false;

        public FormLopTinChi()
        {
            InitializeComponent();
        }

        private void FormLopTinChi_Load(object sender, EventArgs e)
        {
            // Load data
            LoadKhoa();
            LoadMonHoc();
            LoadGiangVien();
            LoadData();

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

        private void LoadMonHoc()
        {
            try
            {
                // Get all MonHoc
                monHocs = MonHocBLL.GetAllMonHoc();

                // Bind to ComboBox
                cboMonHoc.DataSource = monHocs;
                cboMonHoc.DisplayMember = "TenMH";
                cboMonHoc.ValueMember = "MaMH";

                // Select the first item
                if (monHocs.Count > 0)
                {
                    cboMonHoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading MonHoc: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGiangVien()
        {
            try
            {
                if (cboKhoa.SelectedValue != null)
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();

                    // Get GiangVien by MaKhoa
                    giangViens = GiangVienBLL.GetGiangViensByMaKhoa(maKhoa);

                    // Bind to ComboBox
                    cboGiangVien.DataSource = giangViens;
                    cboGiangVien.DisplayMember = "Ho";
                    cboGiangVien.ValueMember = "MaGV";

                    // Select the first item
                    if (giangViens.Count > 0)
                    {
                        cboGiangVien.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading GiangVien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (cboKhoa.SelectedValue != null)
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();

                    // Get LopTinChi by MaKhoa
                    lopTinChis = LopTinChiBLL.GetLopTinChisByMaKhoa(maKhoa);

                    // Bind to DataGridView
                    dgvLopTinChi.DataSource = lopTinChis;

                    // Format DataGridView
                    FormatDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Set column headers
            dgvLopTinChi.Columns["MaLTC"].HeaderText = "Mã LTC";
            dgvLopTinChi.Columns["NienKhoa"].HeaderText = "Niên khóa";
            dgvLopTinChi.Columns["HocKy"].HeaderText = "Học kỳ";
            dgvLopTinChi.Columns["MaMH"].HeaderText = "Mã môn học";
            dgvLopTinChi.Columns["Nhom"].HeaderText = "Nhóm";
            dgvLopTinChi.Columns["MaGV"].HeaderText = "Mã giảng viên";
            dgvLopTinChi.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dgvLopTinChi.Columns["SoSVToiThieu"].HeaderText = "Số SV tối thiểu";
            dgvLopTinChi.Columns["HuyLop"].HeaderText = "Hủy lớp";

            // Set column widths
            dgvLopTinChi.Columns["MaLTC"].Width = 80;
            dgvLopTinChi.Columns["NienKhoa"].Width = 100;
            dgvLopTinChi.Columns["HocKy"].Width = 80;
            dgvLopTinChi.Columns["MaMH"].Width = 100;
            dgvLopTinChi.Columns["Nhom"].Width = 80;
            dgvLopTinChi.Columns["MaGV"].Width = 100;
            dgvLopTinChi.Columns["MaKhoa"].Width = 80;
            dgvLopTinChi.Columns["SoSVToiThieu"].Width = 100;
            dgvLopTinChi.Columns["HuyLop"].Width = 80;

            // Format boolean column
            DataGridViewCheckBoxColumn huyLopColumn = new DataGridViewCheckBoxColumn();
            huyLopColumn.DataPropertyName = "HuyLop";
            huyLopColumn.HeaderText = "Hủy lớp";
            huyLopColumn.Width = 80;
            huyLopColumn.TrueValue = true;
            huyLopColumn.FalseValue = false;
            huyLopColumn.ReadOnly = true;

            // Replace column
            int huyLopIndex = dgvLopTinChi.Columns["HuyLop"].Index;
            dgvLopTinChi.Columns.Remove("HuyLop");
            dgvLopTinChi.Columns.Insert(huyLopIndex, huyLopColumn);

            // Add SoSVDangKy column
            DataGridViewTextBoxColumn soSVDangKyColumn = new DataGridViewTextBoxColumn();
            soSVDangKyColumn.HeaderText = "Số SV đăng ký";
            soSVDangKyColumn.Width = 100;
            soSVDangKyColumn.ReadOnly = true;
            dgvLopTinChi.Columns.Add(soSVDangKyColumn);

            // Fill SoSVDangKy column
            foreach (DataGridViewRow row in dgvLopTinChi.Rows)
            {
                int maLTC = Convert.ToInt32(row.Cells["MaLTC"].Value);
                int soSVDangKy = LopTinChiBLL.GetSoSVDangKy(maLTC);
                row.Cells["Số SV đăng ký"].Value = soSVDangKy;
            }
        }

        private void SetControlState(bool isEditMode)
        {
            // Set controls state based on mode
            cboKhoa.Enabled = !isEditMode;
            txtNienKhoa.Enabled = isEditMode;
            nudHocKy.Enabled = isEditMode;
            cboMonHoc.Enabled = isEditMode;
            nudNhom.Enabled = isEditMode;
            cboGiangVien.Enabled = isEditMode;
            nudSoSVToiThieu.Enabled = isEditMode;
            chkHuyLop.Enabled = isEditMode;

            // Set buttons state
            btnThem.Enabled = !isEditMode;
            btnSua.Enabled = !isEditMode && dgvLopTinChi.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditMode && dgvLopTinChi.SelectedRows.Count > 0;
            btnGhi.Enabled = isEditMode;
            btnPhucHoi.Enabled = isEditMode;
            btnThoat.Enabled = true;

            // Set DataGridView state
            dgvLopTinChi.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtNienKhoa.Text = "";
            nudHocKy.Value = 1;
            nudNhom.Value = 1;
            nudSoSVToiThieu.Value = 10;
            chkHuyLop.Checked = false;
        }

        private void dgvLopTinChi_SelectionChanged(object sender, EventArgs e)
        {
            // Update buttons state
            btnSua.Enabled = !isAdding && !isEditing && dgvLopTinChi.SelectedRows.Count > 0;
            btnXoa.Enabled = !isAdding && !isEditing && dgvLopTinChi.SelectedRows.Count > 0;

            // Display selected LopTinChi
            if (dgvLopTinChi.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow row = dgvLopTinChi.SelectedRows[0];
                txtNienKhoa.Text = row.Cells["NienKhoa"].Value.ToString();
                nudHocKy.Value = Convert.ToInt32(row.Cells["HocKy"].Value);
                
                string maMH = row.Cells["MaMH"].Value.ToString();
                cboMonHoc.SelectedValue = maMH;
                
                nudNhom.Value = Convert.ToInt32(row.Cells["Nhom"].Value);
                
                string maGV = row.Cells["MaGV"].Value.ToString();
                cboGiangVien.SelectedValue = maGV;
                
                nudSoSVToiThieu.Value = Convert.ToInt32(row.Cells["SoSVToiThieu"].Value);
                chkHuyLop.Checked = Convert.ToBoolean(row.Cells["HuyLop"].Value);
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGiangVien();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Set mode
            isAdding = true;
            isEditing = false;

            // Clear inputs
            ClearInputs();

            // Set control state
            SetControlState(true);

            // Focus on NienKhoa
            txtNienKhoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLopTinChi.SelectedRows.Count > 0)
            {
                // Set mode
                isAdding = false;
                isEditing = true;

                // Set control state
                SetControlState(true);

                // Focus on NienKhoa
                txtNienKhoa.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLopTinChi.SelectedRows.Count > 0)
            {
                int maLTC = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["MaLTC"].Value);
                string nienKhoa = dgvLopTinChi.SelectedRows[0].Cells["NienKhoa"].Value.ToString();
                int hocKy = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["HocKy"].Value);
                string maMH = dgvLopTinChi.SelectedRows[0].Cells["MaMH"].Value.ToString();
                int nhom = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["Nhom"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to delete LopTinChi '{nienKhoa}-{hocKy}-{maMH}-{nhom}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = LopTinChiBLL.DeleteLopTinChi(maLTC);
                        if (success)
                        {
                            MessageBox.Show("LopTinChi deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting LopTinChi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtNienKhoa.Text.Trim()))
            {
                MessageBox.Show("Niên khóa cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNienKhoa.Focus();
                return;
            }

            if (nudHocKy.Value < 1 || nudHocKy.Value > 3)
            {
                MessageBox.Show("Học kỳ must be between 1 and 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudHocKy.Focus();
                return;
            }

            if (nudNhom.Value < 1)
            {
                MessageBox.Show("Nhóm must be greater than or equal to 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudNhom.Focus();
                return;
            }

            if (nudSoSVToiThieu.Value <= 0)
            {
                MessageBox.Show("Số SV tối thiểu must be greater than 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSoSVToiThieu.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Create new LopTinChi
                    LopTinChi lopTinChi = new LopTinChi
                    {
                        NienKhoa = txtNienKhoa.Text.Trim(),
                        HocKy = Convert.ToInt32(nudHocKy.Value),
                        MaMH = cboMonHoc.SelectedValue.ToString(),
                        Nhom = Convert.ToInt32(nudNhom.Value),
                        MaGV = cboGiangVien.SelectedValue.ToString(),
                        MaKhoa = cboKhoa.SelectedValue.ToString(),
                        SoSVToiThieu = Convert.ToInt16(nudSoSVToiThieu.Value),
                        HuyLop = chkHuyLop.Checked
                    };

                    // Insert LopTinChi
                    int maLTC = LopTinChiBLL.InsertLopTinChi(lopTinChi);
                    if (maLTC > 0)
                    {
                        MessageBox.Show("LopTinChi added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
                else if (isEditing)
                {
                    // Get selected LopTinChi
                    int maLTC = Convert.ToInt32(dgvLopTinChi.SelectedRows[0].Cells["MaLTC"].Value);

                    // Create LopTinChi with updated values
                    LopTinChi lopTinChi = new LopTinChi
                    {
                        MaLTC = maLTC,
                        NienKhoa = txtNienKhoa.Text.Trim(),
                        HocKy = Convert.ToInt32(nudHocKy.Value),
                        MaMH = cboMonHoc.SelectedValue.ToString(),
                        Nhom = Convert.ToInt32(nudNhom.Value),
                        MaGV = cboGiangVien.SelectedValue.ToString(),
                        MaKhoa = cboKhoa.SelectedValue.ToString(),
                        SoSVToiThieu = Convert.ToInt16(nudSoSVToiThieu.Value),
                        HuyLop = chkHuyLop.Checked
                    };

                    // Update LopTinChi
                    bool success = LopTinChiBLL.UpdateLopTinChi(lopTinChi);
                    if (success)
                    {
                        MessageBox.Show("LopTinChi updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving LopTinChi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            // Cancel adding/editing
            isAdding = false;
            isEditing = false;

            // Reset inputs
            if (dgvLopTinChi.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLopTinChi.SelectedRows[0];
                txtNienKhoa.Text = row.Cells["NienKhoa"].Value.ToString();
                nudHocKy.Value = Convert.ToInt32(row.Cells["HocKy"].Value);
                
                string maMH = row.Cells["MaMH"].Value.ToString();
                cboMonHoc.SelectedValue = maMH;
                
                nudNhom.Value = Convert.ToInt32(row.Cells["Nhom"].Value);
                
                string maGV = row.Cells["MaGV"].Value.ToString();
                cboGiangVien.SelectedValue = maGV;
                
                nudSoSVToiThieu.Value = Convert.ToInt32(row.Cells["SoSVToiThieu"].Value);
                chkHuyLop.Checked = Convert.ToBoolean(row.Cells["HuyLop"].Value);
            }
            else
            {
                ClearInputs();
            }

            // Set control state
            SetControlState(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
