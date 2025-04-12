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
    public partial class FormSinhVien : Form
    {
        private List<Khoa> khoas;
        private List<Lop> lops;
        private List<SinhVien> sinhViens;
        private bool isAdding = false;
        private bool isEditing = false;

        public FormSinhVien()
        {
            InitializeComponent();
        }

        private void FormSinhVien_Load(object sender, EventArgs e)
        {
            // Load data
            LoadKhoa();
            LoadLop();
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

        private void LoadLop()
        {
            try
            {
                if (cboKhoa.SelectedValue != null)
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();

                    // Get Lop by MaKhoa
                    lops = LopBLL.GetLopsByMaKhoa(maKhoa);

                    // Bind to ComboBox
                    cboLop.DataSource = lops;
                    cboLop.DisplayMember = "TenLop";
                    cboLop.ValueMember = "MaLop";

                    // Select the first item
                    if (lops.Count > 0)
                    {
                        cboLop.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Lop: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (cboLop.SelectedValue != null)
                {
                    string maLop = cboLop.SelectedValue.ToString();

                    // Get SinhVien by MaLop
                    sinhViens = SinhVienBLL.GetSinhViensByMaLop(maLop);

                    // Bind to DataGridView
                    dgvSinhVien.DataSource = sinhViens;

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
            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["Ho"].HeaderText = "Họ";
            dgvSinhVien.Columns["Ten"].HeaderText = "Tên";
            dgvSinhVien.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvSinhVien.Columns["Phai"].HeaderText = "Phái";
            dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvSinhVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvSinhVien.Columns["DaNghiHoc"].HeaderText = "Đã nghỉ học";
            dgvSinhVien.Columns["Password"].HeaderText = "Mật khẩu";

            // Set column widths
            dgvSinhVien.Columns["MaSV"].Width = 80;
            dgvSinhVien.Columns["Ho"].Width = 120;
            dgvSinhVien.Columns["Ten"].Width = 80;
            dgvSinhVien.Columns["MaLop"].Width = 80;
            dgvSinhVien.Columns["Phai"].Width = 60;
            dgvSinhVien.Columns["NgaySinh"].Width = 100;
            dgvSinhVien.Columns["DiaChi"].Width = 150;
            dgvSinhVien.Columns["DaNghiHoc"].Width = 80;
            dgvSinhVien.Columns["Password"].Width = 80;

            // Format date column
            dgvSinhVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Format boolean columns
            DataGridViewCheckBoxColumn phaiColumn = new DataGridViewCheckBoxColumn();
            phaiColumn.DataPropertyName = "Phai";
            phaiColumn.HeaderText = "Phái";
            phaiColumn.Width = 60;
            phaiColumn.TrueValue = true;
            phaiColumn.FalseValue = false;
            phaiColumn.ReadOnly = true;

            DataGridViewCheckBoxColumn daNghiHocColumn = new DataGridViewCheckBoxColumn();
            daNghiHocColumn.DataPropertyName = "DaNghiHoc";
            daNghiHocColumn.HeaderText = "Đã nghỉ học";
            daNghiHocColumn.Width = 80;
            daNghiHocColumn.TrueValue = true;
            daNghiHocColumn.FalseValue = false;
            daNghiHocColumn.ReadOnly = true;

            // Replace columns
            int phaiIndex = dgvSinhVien.Columns["Phai"].Index;
            int daNghiHocIndex = dgvSinhVien.Columns["DaNghiHoc"].Index;

            dgvSinhVien.Columns.Remove("Phai");
            dgvSinhVien.Columns.Remove("DaNghiHoc");

            dgvSinhVien.Columns.Insert(phaiIndex, phaiColumn);
            dgvSinhVien.Columns.Insert(daNghiHocIndex, daNghiHocColumn);

            // Hide Password column
            dgvSinhVien.Columns["Password"].Visible = false;
        }

        private void SetControlState(bool isEditMode)
        {
            // Set controls state based on mode
            cboKhoa.Enabled = !isEditMode;
            cboLop.Enabled = !isEditMode;
            txtMaSV.Enabled = isEditMode && isAdding;
            txtHo.Enabled = isEditMode;
            txtTen.Enabled = isEditMode;
            rdoNam.Enabled = isEditMode;
            rdoNu.Enabled = isEditMode;
            dtpNgaySinh.Enabled = isEditMode;
            txtDiaChi.Enabled = isEditMode;
            chkDaNghiHoc.Enabled = isEditMode;
            txtPassword.Enabled = isEditMode;

            // Set buttons state
            btnThem.Enabled = !isEditMode;
            btnSua.Enabled = !isEditMode && dgvSinhVien.SelectedRows.Count > 0;
            btnXoa.Enabled = !isEditMode && dgvSinhVien.SelectedRows.Count > 0;
            btnGhi.Enabled = isEditMode;
            btnPhucHoi.Enabled = isEditMode;
            btnThoat.Enabled = true;

            // Set DataGridView state
            dgvSinhVien.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtMaSV.Text = "";
            txtHo.Text = "";
            txtTen.Text = "";
            rdoNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Text = "";
            chkDaNghiHoc.Checked = false;
            txtPassword.Text = "123456";
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            // Update buttons state
            btnSua.Enabled = !isAdding && !isEditing && dgvSinhVien.SelectedRows.Count > 0;
            btnXoa.Enabled = !isAdding && !isEditing && dgvSinhVien.SelectedRows.Count > 0;

            // Display selected SinhVien
            if (dgvSinhVien.SelectedRows.Count > 0 && !isAdding && !isEditing)
            {
                DataGridViewRow row = dgvSinhVien.SelectedRows[0];
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHo.Text = row.Cells["Ho"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                
                bool phai = Convert.ToBoolean(row.Cells["Phai"].Value);
                rdoNam.Checked = !phai;
                rdoNu.Checked = phai;
                
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                chkDaNghiHoc.Checked = Convert.ToBoolean(row.Cells["DaNghiHoc"].Value);
                txtPassword.Text = row.Cells["Password"].Value.ToString();
            }
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLop();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
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

            // Focus on MaSV
            txtMaSV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count > 0)
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
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                string maSV = dgvSinhVien.SelectedRows[0].Cells["MaSV"].Value.ToString();
                string hoTen = dgvSinhVien.SelectedRows[0].Cells["Ho"].Value.ToString() + " " + dgvSinhVien.SelectedRows[0].Cells["Ten"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete SinhVien '{hoTen}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = SinhVienBLL.DeleteSinhVien(maSV);
                        if (success)
                        {
                            MessageBox.Show("SinhVien deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearInputs();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting SinhVien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Mã SV cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
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

            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Create new SinhVien
                    SinhVien sinhVien = new SinhVien
                    {
                        MaSV = txtMaSV.Text.Trim(),
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        MaLop = cboLop.SelectedValue.ToString(),
                        Phai = rdoNu.Checked,
                        NgaySinh = dtpNgaySinh.Value,
                        DiaChi = txtDiaChi.Text.Trim(),
                        DaNghiHoc = chkDaNghiHoc.Checked,
                        Password = txtPassword.Text.Trim()
                    };

                    // Insert SinhVien
                    bool success = SinhVienBLL.InsertSinhVien(sinhVien);
                    if (success)
                    {
                        MessageBox.Show("SinhVien added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputs();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
                else if (isEditing)
                {
                    // Create SinhVien with updated values
                    SinhVien sinhVien = new SinhVien
                    {
                        MaSV = txtMaSV.Text.Trim(),
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        MaLop = cboLop.SelectedValue.ToString(),
                        Phai = rdoNu.Checked,
                        NgaySinh = dtpNgaySinh.Value,
                        DiaChi = txtDiaChi.Text.Trim(),
                        DaNghiHoc = chkDaNghiHoc.Checked,
                        Password = txtPassword.Text.Trim()
                    };

                    // Update SinhVien
                    bool success = SinhVienBLL.UpdateSinhVien(sinhVien);
                    if (success)
                    {
                        MessageBox.Show("SinhVien updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        isAdding = false;
                        isEditing = false;
                        SetControlState(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving SinhVien: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            // Cancel adding/editing
            isAdding = false;
            isEditing = false;

            // Reset inputs
            if (dgvSinhVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvSinhVien.SelectedRows[0];
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtHo.Text = row.Cells["Ho"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                
                bool phai = Convert.ToBoolean(row.Cells["Phai"].Value);
                rdoNam.Checked = !phai;
                rdoNu.Checked = phai;
                
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                chkDaNghiHoc.Checked = Convert.ToBoolean(row.Cells["DaNghiHoc"].Value);
                txtPassword.Text = row.Cells["Password"].Value.ToString();
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
