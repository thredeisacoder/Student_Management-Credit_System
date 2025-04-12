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
    public partial class FormMonHoc : Form
    {
        private List<MonHoc> monHocs;
        private bool isAdding = false;
        private bool isEditing = false;

        public FormMonHoc()
        {
            InitializeComponent();
        }

        private void FormMonHoc_Load(object sender, EventArgs e)
        {
            // Load data
            LoadData();

            // Set initial state
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                // Get all MonHoc
                monHocs = MonHocBLL.GetAllMonHoc();

                // Bind to DataGridView
                dgvMonHoc.DataSource = monHocs;

                // Format DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Set column headers
            dgvMonHoc.Columns["MaMH"].HeaderText = "Mã môn học";
            dgvMonHoc.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvMonHoc.Columns["SoTiet_LT"].HeaderText = "Số tiết lý thuyết";
            dgvMonHoc.Columns["SoTiet_TH"].HeaderText = "Số tiết thực hành";

            // Set column widths
            dgvMonHoc.Columns["MaMH"].Width = 100;
            dgvMonHoc.Columns["TenMH"].Width = 200;
            dgvMonHoc.Columns["SoTiet_LT"].Width = 100;
            dgvMonHoc.Columns["SoTiet_TH"].Width = 100;

            // Auto size mode
            dgvMonHoc.Columns["MaMH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMonHoc.Columns["TenMH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMonHoc.Columns["SoTiet_LT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMonHoc.Columns["SoTiet_TH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SetControlState(bool isEditMode)
        {
            // Set controls state based on mode
            txtMaMH.Enabled = isEditMode && isAdding;
            txtTenMH.Enabled = isEditMode;
            nudSoTiet_LT.Enabled = isEditMode;
            nudSoTiet_TH.Enabled = isEditMode;

            // Set buttons state
            btnThem.Enabled = !isEditMode;
            btnSua.Enabled = !isEditMode && dgvMonHoc.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditMode && dgvMonHoc.SelectedRows.Count > 0;
            btnGhi.Enabled = isEditMode;
            btnPhucHoi.Enabled = isEditMode;
            btnThoat.Enabled = true;

            // Set DataGridView state
            dgvMonHoc.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            nudSoTiet_LT.Value = 0;
            nudSoTiet_TH.Value = 0;
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            // Update buttons state
            btnSua.Enabled = !isAdding && !isEditing && dgvMonHoc.SelectedRows.Count > 0;
            btnXoa.Enabled = !isAdding && !isEditing && dgvMonHoc.SelectedRows.Count > 0;

            // Display selected MonHoc
            if (dgvMonHoc.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow row = dgvMonHoc.SelectedRows[0];
                txtMaMH.Text = row.Cells["MaMH"].Value.ToString();
                txtTenMH.Text = row.Cells["TenMH"].Value.ToString();
                nudSoTiet_LT.Value = Convert.ToInt32(row.Cells["SoTiet_LT"].Value);
                nudSoTiet_TH.Value = Convert.ToInt32(row.Cells["SoTiet_TH"].Value);
            }
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

            // Focus on MaMH
            txtMaMH.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                // Set mode
                isAdding = false;
                isEditing = true;

                // Set control state
                SetControlState(true);

                // Focus on TenMH
                txtTenMH.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                string maMH = dgvMonHoc.SelectedRows[0].Cells["MaMH"].Value.ToString();
                string tenMH = dgvMonHoc.SelectedRows[0].Cells["TenMH"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete MonHoc '{tenMH}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = MonHocBLL.DeleteMonHoc(maMH);
                        if (success)
                        {
                            MessageBox.Show("MonHoc deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting MonHoc: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtMaMH.Text.Trim()))
            {
                MessageBox.Show("Mã môn học cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaMH.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTenMH.Text.Trim()))
            {
                MessageBox.Show("Tên môn học cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMH.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Create new MonHoc
                    MonHoc monHoc = new MonHoc
                    {
                        MaMH = txtMaMH.Text.Trim(),
                        TenMH = txtTenMH.Text.Trim(),
                        SoTiet_LT = Convert.ToInt32(nudSoTiet_LT.Value),
                        SoTiet_TH = Convert.ToInt32(nudSoTiet_TH.Value)
                    };

                    // Insert MonHoc
                    bool success = MonHocBLL.InsertMonHoc(monHoc);
                    if (success)
                    {
                        MessageBox.Show("MonHoc added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
                else if (isEditing)
                {
                    // Create MonHoc with updated values
                    MonHoc monHoc = new MonHoc
                    {
                        MaMH = txtMaMH.Text.Trim(),
                        TenMH = txtTenMH.Text.Trim(),
                        SoTiet_LT = Convert.ToInt32(nudSoTiet_LT.Value),
                        SoTiet_TH = Convert.ToInt32(nudSoTiet_TH.Value)
                    };

                    // Update MonHoc
                    bool success = MonHocBLL.UpdateMonHoc(monHoc);
                    if (success)
                    {
                        MessageBox.Show("MonHoc updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving MonHoc: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            // Cancel adding/editing
            isAdding = false;
            isEditing = false;

            // Reset inputs
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvMonHoc.SelectedRows[0];
                txtMaMH.Text = row.Cells["MaMH"].Value.ToString();
                txtTenMH.Text = row.Cells["TenMH"].Value.ToString();
                nudSoTiet_LT.Value = Convert.ToInt32(row.Cells["SoTiet_LT"].Value);
                nudSoTiet_TH.Value = Convert.ToInt32(row.Cells["SoTiet_TH"].Value);
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
