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
    public partial class FormDanhSachLopTinChi : Form
    {
        private List<Khoa> khoas;
        private List<LopTinChi> lopTinChis;

        public FormDanhSachLopTinChi()
        {
            InitializeComponent();
        }

        private void FormDanhSachLopTinChi_Load(object sender, EventArgs e)
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboKhoa.SelectedValue != null && cboNienKhoa.SelectedItem != null && cboHocKy.SelectedItem != null)
                {
                    string maKhoa = cboKhoa.SelectedValue.ToString();
                    string tenKhoa = cboKhoa.Text;
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
                    
                    // Create DataTable for report
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("STT", typeof(int));
                    dataTable.Columns.Add("MaLTC", typeof(int));
                    dataTable.Columns.Add("MaMH", typeof(string));
                    dataTable.Columns.Add("TenMH", typeof(string));
                    dataTable.Columns.Add("Nhom", typeof(int));
                    dataTable.Columns.Add("HoTenGV", typeof(string));
                    dataTable.Columns.Add("SoSVToiThieu", typeof(short));
                    dataTable.Columns.Add("SoSVDangKy", typeof(int));
                    
                    int stt = 1;
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
                            stt++,
                            ltc.MaLTC,
                            ltc.MaMH,
                            monHoc != null ? monHoc.TenMH : "",
                            ltc.Nhom,
                            giangVien != null ? giangVien.Ho + " " + giangVien.Ten : "",
                            ltc.SoSVToiThieu,
                            soSVDangKy
                        );
                    }
                    
                    // Bind to DataGridView
                    dgvLopTinChi.DataSource = dataTable;
                    
                    // Format DataGridView
                    FormatDataGridView();
                    
                    // Set report title
                    lblReportTitle.Text = $"DANH SÁCH LỚP TÍN CHỈ KHOA {tenKhoa.ToUpper()}";
                    lblReportSubtitle.Text = $"Niên khóa: {nienKhoa} - Học kỳ: {hocKy}";
                    
                    // Show report panel
                    panelReport.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            // Set column headers
            dgvLopTinChi.Columns["STT"].HeaderText = "STT";
            dgvLopTinChi.Columns["MaLTC"].HeaderText = "Mã LTC";
            dgvLopTinChi.Columns["MaMH"].HeaderText = "Mã MH";
            dgvLopTinChi.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvLopTinChi.Columns["Nhom"].HeaderText = "Nhóm";
            dgvLopTinChi.Columns["HoTenGV"].HeaderText = "Giảng viên";
            dgvLopTinChi.Columns["SoSVToiThieu"].HeaderText = "Số SV tối thiểu";
            dgvLopTinChi.Columns["SoSVDangKy"].HeaderText = "Số SV đăng ký";
            
            // Set column widths
            dgvLopTinChi.Columns["STT"].Width = 50;
            dgvLopTinChi.Columns["MaLTC"].Width = 80;
            dgvLopTinChi.Columns["MaMH"].Width = 80;
            dgvLopTinChi.Columns["TenMH"].Width = 150;
            dgvLopTinChi.Columns["Nhom"].Width = 60;
            dgvLopTinChi.Columns["HoTenGV"].Width = 150;
            dgvLopTinChi.Columns["SoSVToiThieu"].Width = 100;
            dgvLopTinChi.Columns["SoSVDangKy"].Width = 100;
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
