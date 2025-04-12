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
    public partial class FormLop : Form
    {
        private List<Lop> lops;
        private List<Khoa> khoas;
        private bool isAdding = false;
        private bool isEditing = false;

        public FormLop()
        {
            InitializeComponent();
        }

        private void FormLop_Load(object sender, EventArgs e)
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

                    // Get Lop by MaKhoa
                    lops = LopBLL.GetLopsByMaKhoa(maKhoa);

                    // Bind to DataGridView
                    dgvLop.DataSource = lops;

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
            dgvLop.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvLop.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvLop.Columns["KhoaHoc"].HeaderText = "Khóa học";
            dgvLop.Columns["MaKhoa"].HeaderText = "Mã khoa";

            // Set column widths
            dgvLop.Columns["MaLop"].Width = 100;
            dgvLop.Columns["TenLop"].Width = 200;
            dgvLop.Columns["KhoaHoc"].Width = 100;
            dgvLop.Columns["MaKhoa"].Width = 100;

            // Auto size mode
            dgvLop.Columns["MaLop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLop.Columns["TenLop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLop.Columns["KhoaHoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLop.Columns["MaKhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SetControlState(bool isEditMode)
        {
            // Set controls state based on mode
            txtMaLop.Enabled = isEditMode && isAdding;
            txtTenLop.Enabled = isEditMode;
            txtKhoaHoc.Enabled = isEditMode;
            cboKhoa.Enabled = !isEditMode;

            // Set buttons state
            btnThem.Enabled = !isEditMode;
            btnSua.Enabled = !isEditMode && dgvLop.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditMode && dgvLop.SelectedRows.Count > 0;
            btnGhi.Enabled = isEditMode;
            btnPhucHoi.Enabled = isEditMode;
            btnThoat.Enabled = true;

            // Set DataGridView state
            dgvLop.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoaHoc.Text = "";
        }

        private void dgvLop_SelectionChanged(object sender, EventArgs e)
        {
            // Update buttons state
            btnSua.Enabled = !isAdding && !isEditing && dgvLop.SelectedRows.Count > 0;
            btnXoa.Enabled = !isAdding && !isEditing && dgvLop.SelectedRows.Count > 0;

            // Display selected Lop
            if (dgvLop.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow row = dgvLop.SelectedRows[0];
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
                txtKhoaHoc.Text = row.Cells["KhoaHoc"].Value.ToString();
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

            // Focus on MaLop
            txtMaLop.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                // Set mode
                isAdding = false;
                isEditing = true;

                // Set control state
                SetControlState(true);

                // Focus on TenLop
                txtTenLop.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.SelectedRows.Count > 0)
            {
                string maLop = dgvLop.SelectedRows[0].Cells["MaLop"].Value.ToString();
                string tenLop = dgvLop.SelectedRows[0].Cells["TenLop"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete Lop '{tenLop}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = LopBLL.DeleteLop(maLop);
                        if (success)
                        {
                            MessageBox.Show("Lop deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting Lop: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtMaLop.Text.Trim()))
            {
                MessageBox.Show("Mã lớp cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLop.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTenLop.Text.Trim()))
            {
                MessageBox.Show("Tên lớp cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLop.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtKhoaHoc.Text.Trim()))
            {
                MessageBox.Show("Khóa học cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKhoaHoc.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Create new Lop
                    Lop lop = new Lop
                    {
                        MaLop = txtMaLop.Text.Trim(),
                        TenLop = txtTenLop.Text.Trim(),
                        KhoaHoc = txtKhoaHoc.Text.Trim(),
                        MaKhoa = cboKhoa.SelectedValue.ToString()
                    };

                    // Insert Lop
                    bool success = LopBLL.InsertLop(lop);
                    if (success)
                    {
                        MessageBox.Show("Lop added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
                else if (isEditing)
                {
                    // Create Lop with updated values
                    Lop lop = new Lop
                    {
                        MaLop = txtMaLop.Text.Trim(),
                        TenLop = txtTenLop.Text.Trim(),
                        KhoaHoc = txtKhoaHoc.Text.Trim(),
                        MaKhoa = cboKhoa.SelectedValue.ToString()
                    };

                    // Update Lop
                    bool success = LopBLL.UpdateLop(lop);
                    if (success)
                    {
                        MessageBox.Show("Lop updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Lop: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            // Cancel adding/editing
            isAdding = false;
            isEditing = false;

            // Reset inputs
            if (dgvLop.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLop.SelectedRows[0];
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
                txtKhoaHoc.Text = row.Cells["KhoaHoc"].Value.ToString();
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
