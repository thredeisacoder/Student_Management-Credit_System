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
    public partial class FormKhoa : Form
    {
        private List<Khoa> khoas;
        private bool isAdding = false;
        private bool isEditing = false;

        public FormKhoa()
        {
            InitializeComponent();
        }

        private void FormKhoa_Load(object sender, EventArgs e)
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
                // Get all Khoa
                khoas = KhoaBLL.GetAllKhoa();

                // Bind to DataGridView
                dgvKhoa.DataSource = khoas;

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
            dgvKhoa.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dgvKhoa.Columns["TenKhoa"].HeaderText = "Tên khoa";

            // Set column widths
            dgvKhoa.Columns["MaKhoa"].Width = 100;
            dgvKhoa.Columns["TenKhoa"].Width = 200;

            // Auto size mode
            dgvKhoa.Columns["MaKhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvKhoa.Columns["TenKhoa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SetControlState(bool isEditMode)
        {
            // Set controls state based on mode
            txtMaKhoa.Enabled = isEditMode && isAdding;
            txtTenKhoa.Enabled = isEditMode;

            // Set buttons state
            btnThem.Enabled = !isEditMode;
            btnSua.Enabled = !isEditMode && dgvKhoa.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditMode && dgvKhoa.SelectedRows.Count > 0;
            btnGhi.Enabled = isEditMode;
            btnPhucHoi.Enabled = isEditMode;
            btnThoat.Enabled = true;

            // Set DataGridView state
            dgvKhoa.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
        }

        private void dgvKhoa_SelectionChanged(object sender, EventArgs e)
        {
            // Update buttons state
            btnSua.Enabled = !isAdding && !isEditing && dgvKhoa.SelectedRows.Count > 0;
            btnXoa.Enabled = !isAdding && !isEditing && dgvKhoa.SelectedRows.Count > 0;

            // Display selected Khoa
            if (dgvKhoa.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow row = dgvKhoa.SelectedRows[0];
                txtMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();
                txtTenKhoa.Text = row.Cells["TenKhoa"].Value.ToString();
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

            // Focus on MaKhoa
            txtMaKhoa.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvKhoa.SelectedRows.Count > 0)
            {
                // Set mode
                isAdding = false;
                isEditing = true;

                // Set control state
                SetControlState(true);

                // Focus on TenKhoa
                txtTenKhoa.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKhoa.SelectedRows.Count > 0)
            {
                string maKhoa = dgvKhoa.SelectedRows[0].Cells["MaKhoa"].Value.ToString();
                string tenKhoa = dgvKhoa.SelectedRows[0].Cells["TenKhoa"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete Khoa '{tenKhoa}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = KhoaBLL.DeleteKhoa(maKhoa);
                        if (success)
                        {
                            MessageBox.Show("Khoa deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting Khoa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtMaKhoa.Text.Trim()))
            {
                MessageBox.Show("Mã khoa cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKhoa.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtTenKhoa.Text.Trim()))
            {
                MessageBox.Show("Tên khoa cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhoa.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Create new Khoa
                    Khoa khoa = new Khoa
                    {
                        MaKhoa = txtMaKhoa.Text.Trim(),
                        TenKhoa = txtTenKhoa.Text.Trim()
                    };

                    // Insert Khoa
                    bool success = KhoaBLL.InsertKhoa(khoa);
                    if (success)
                    {
                        MessageBox.Show("Khoa added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
                else if (isEditing)
                {
                    // Create Khoa with updated values
                    Khoa khoa = new Khoa
                    {
                        MaKhoa = txtMaKhoa.Text.Trim(),
                        TenKhoa = txtTenKhoa.Text.Trim()
                    };

                    // Update Khoa
                    bool success = KhoaBLL.UpdateKhoa(khoa);
                    if (success)
                    {
                        MessageBox.Show("Khoa updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving Khoa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            // Cancel adding/editing
            isAdding = false;
            isEditing = false;

            // Reset inputs
            if (dgvKhoa.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvKhoa.SelectedRows[0];
                txtMaKhoa.Text = row.Cells["MaKhoa"].Value.ToString();
                txtTenKhoa.Text = row.Cells["TenKhoa"].Value.ToString();
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
