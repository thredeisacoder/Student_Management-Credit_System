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
    public partial class FormGiangVien : Form
    {
        private List<Khoa> khoas;
        private List<GiangVien> giangViens;
        private bool isAdding = false;
        private bool isEditing = false;

        public FormGiangVien()
        {
            InitializeComponent();
        }

        private void FormGiangVien_Load(object sender, EventArgs e)
        {
            // Load data
            LoadKhoa();
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

        private void LoadData()
        {
            try
            {
                if (cboKhoa.SelectedValue != null)
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();

                    // Get GiangVien by MaKhoa
                    giangViens = GiangVienBLL.GetGiangViensByMaKhoa(maKhoa);

                    // Bind to DataGridView
                    dgvGiangVien.DataSource = giangViens;

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
            dgvGiangVien.Columns["MaGV"].HeaderText = "Mã GV";
            dgvGiangVien.Columns["Ho"].HeaderText = "Họ";
            dgvGiangVien.Columns["Ten"].HeaderText = "Tên";
            dgvGiangVien.Columns["HocVi"].HeaderText = "Học vị";
            dgvGiangVien.Columns["HocHam"].HeaderText = "Học hàm";
            dgvGiangVien.Columns["ChuyenMon"].HeaderText = "Chuyên môn";
            dgvGiangVien.Columns["MaKhoa"].HeaderText = "Mã khoa";

            // Set column widths
            dgvGiangVien.Columns["MaGV"].Width = 80;
            dgvGiangVien.Columns["Ho"].Width = 120;
            dgvGiangVien.Columns["Ten"].Width = 80;
            dgvGiangVien.Columns["HocVi"].Width = 80;
            dgvGiangVien.Columns["HocHam"].Width = 80;
            dgvGiangVien.Columns["ChuyenMon"].Width = 150;
            dgvGiangVien.Columns["MaKhoa"].Width = 80;

            // Auto size mode
            dgvGiangVien.Columns["MaGV"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGiangVien.Columns["Ho"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGiangVien.Columns["Ten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGiangVien.Columns["HocVi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGiangVien.Columns["HocHam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGiangVien.Columns["ChuyenMon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGiangVien.Columns["MaKhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SetControlState(bool isEditMode)
        {
            // Set controls state based on mode
            cboKhoa.Enabled = !isEditMode;
            txtMaGV.Enabled = isEditMode && isAdding;
            txtHo.Enabled = isEditMode;
            txtTen.Enabled = isEditMode;
            txtHocVi.Enabled = isEditMode;
            txtHocHam.Enabled = isEditMode;
            txtChuyenMon.Enabled = isEditMode;

            // Set buttons state
            btnThem.Enabled = !isEditMode;
            btnSua.Enabled = !isEditMode && dgvGiangVien.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditMode && dgvGiangVien.SelectedRows.Count > 0;
            btnGhi.Enabled = isEditMode;
            btnPhucHoi.Enabled = isEditMode;
            btnThoat.Enabled = true;

            // Set DataGridView state
            dgvGiangVien.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtMaGV.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            txtHocVi.Text = "";
            txtHocHam.Text = "";
            txtChuyenMon.Text = "";
        }

        private void dgvGiangVien_SelectionChanged(object sender, EventArgs e)
        {
            // Update buttons state
            btnSua.Enabled = !isAdding && !isEditing && dgvGiangVien.SelectedRows.Count > 0;
            btnXoa.Enabled = !isAdding && !isEditing && dgvGiangVien.SelectedRows.Count > 0;

            // Display selected GiangVien
            if (dgvGiangVien.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow row = dgvGiangVien.SelectedRows[0];
                txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                txtHo.Text = row.Cells["Ho"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtHocVi.Text = row.Cells["HocVi"].Value.ToString();
                txtHocHam.Text = row.Cells["HocHam"].Value.ToString();
                txtChuyenMon.Text = row.Cells["ChuyenMon"].Value.ToString();
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            // Focus on MaGV
            txtMaGV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvGiangVien.SelectedRows.Count > 0)
            {
                // Set mode
                isAdding = false;
                isEditing = true;

                // Set control state
                SetControlState(true);

                // Focus on Ho
                txtHo.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvGiangVien.SelectedRows.Count > 0)
            {
                string maGV = dgvGiangVien.SelectedRows[0].Cells["MaGV"].Value.ToString();
                string hoTen = dgvGiangVien.SelectedRows[0].Cells["Ho"].Value.ToString() + " " + dgvGiangVien.SelectedRows[0].Cells["Ten"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete GiangVien '{hoTen}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = GiangVienBLL.DeleteGiangVien(maGV);
                        if (success)
                        {
                            MessageBox.Show("GiangVien deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting GiangVien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtMaGV.Text.Trim()))
            {
                MessageBox.Show("Mã GV cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaGV.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtHo.Text.Trim()))
            {
                MessageBox.Show("Họ cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
                MessageBox.Show("Tên cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Create new GiangVien
                    GiangVien giangVien = new GiangVien
                    {
                        MaGV = txtMaGV.Text.Trim(),
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        HocVi = txtHocVi.Text.Trim(),
                        HocHam = txtHocHam.Text.Trim(),
                        ChuyenMon = txtChuyenMon.Text.Trim(),
                        MaKhoa = cboKhoa.SelectedValue.ToString()
                    };

                    // Insert GiangVien
                    bool success = GiangVienBLL.InsertGiangVien(giangVien);
                    if (success)
                    {
                        MessageBox.Show("GiangVien added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
                else if (isEditing)
                {
                    // Create GiangVien with updated values
                    GiangVien giangVien = new GiangVien
                    {
                        MaGV = txtMaGV.Text.Trim(),
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        HocVi = txtHocVi.Text.Trim(),
                        HocHam = txtHocHam.Text.Trim(),
                        ChuyenMon = txtChuyenMon.Text.Trim(),
                        MaKhoa = cboKhoa.SelectedValue.ToString()
                    };

                    // Update GiangVien
                    bool success = GiangVienBLL.UpdateGiangVien(giangVien);
                    if (success)
                    {
                        MessageBox.Show("GiangVien updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving GiangVien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            // Cancel adding/editing
            isAdding = false;
            isEditing = false;

            // Reset inputs
            if (dgvGiangVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvGiangVien.SelectedRows[0];
                txtMaGV.Text = row.Cells["MaGV"].Value.ToString();
                txtHo.Text = row.Cells["Ho"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtHocVi.Text = row.Cells["HocVi"].Value.ToString();
                txtHocHam.Text = row.Cells["HocHam"].Value.ToString();
                txtChuyenMon.Text = row.Cells["ChuyenMon"].Value.ToString();
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
