using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLDSV_HTC.GUI;

namespace QLDSV_HTC.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Set status bar information
            tsslUsername.Text = "User: " + Program.Username;
            tsslRole.Text = "Role: " + Program.Role;
            tsslFullName.Text = "Name: " + Program.FullName;

            // Set form title
            this.Text = "Quản lý điểm sinh viên - " + Program.FullName;

            // Configure menu items based on user role
            ConfigureMenuItems();
        }

        private void ConfigureMenuItems()
        {
            // Configure menu items based on user role
            switch (Program.Role)
            {
                case "PGV": // Phòng giáo vụ
                    // Enable all menu items
                    break;

                case "KHOA": // Khoa
                    // Disable menu items for Khoa, Lop, GiangVien, SinhVien, LopTinChi
                    mnuKhoa.Enabled = false;
                    mnuLop.Enabled = false;
                    mnuGiangVien.Enabled = false;
                    mnuSinhVien.Enabled = false;
                    mnuLopTinChi.Enabled = false;
                    break;

                case "GV": // Giảng viên
                    // Giảng viên có thể nhập điểm và xem các báo cáo
                    mnuKhoa.Enabled = false;
                    mnuLop.Enabled = false;
                    mnuGiangVien.Enabled = false;
                    mnuSinhVien.Enabled = false;
                    mnuMonHoc.Enabled = false;
                    mnuLopTinChi.Enabled = false;
                    mnuDangKyLopTinChi.Enabled = false;
                    mnuTaoTaiKhoan.Enabled = false;
                    mnuSaoLuuPhucHoi.Enabled = false;
                    break;

                case "SV": // Sinh viên
                    // Only enable DangKyLopTinChi and PhieuDiem
                    mnuKhoa.Enabled = false;
                    mnuLop.Enabled = false;
                    mnuGiangVien.Enabled = false;
                    mnuSinhVien.Enabled = false;
                    mnuMonHoc.Enabled = false;
                    mnuLopTinChi.Enabled = false;
                    mnuNhapDiem.Enabled = false;
                    mnuDanhSachLopTinChi.Enabled = false;
                    mnuDanhSachSinhVienDangKy.Enabled = false;
                    mnuBangDiemMonHoc.Enabled = false;
                    mnuDanhSachHocPhi.Enabled = false;
                    mnuBangDiemTongKet.Enabled = false;
                    mnuTaoTaiKhoan.Enabled = false;
                    mnuSaoLuuPhucHoi.Enabled = false;
                    break;

                default:
                    // Disable all menu items
                    mnuKhoa.Enabled = false;
                    mnuLop.Enabled = false;
                    mnuGiangVien.Enabled = false;
                    mnuSinhVien.Enabled = false;
                    mnuMonHoc.Enabled = false;
                    mnuLopTinChi.Enabled = false;
                    mnuDangKyLopTinChi.Enabled = false;
                    mnuNhapDiem.Enabled = false;
                    mnuDanhSachLopTinChi.Enabled = false;
                    mnuDanhSachSinhVienDangKy.Enabled = false;
                    mnuBangDiemMonHoc.Enabled = false;
                    mnuPhieuDiem.Enabled = false;
                    mnuDanhSachHocPhi.Enabled = false;
                    mnuBangDiemTongKet.Enabled = false;
                    mnuTaoTaiKhoan.Enabled = false;
                    mnuSaoLuuPhucHoi.Enabled = false;
                    break;
            }
        }

        private void mnuKhoa_Click(object sender, EventArgs e)
        {
            FormKhoa formKhoa = new FormKhoa();
            formKhoa.MdiParent = this;
            formKhoa.Show();
        }

        private void mnuLop_Click(object sender, EventArgs e)
        {
            FormLop formLop = new FormLop();
            formLop.MdiParent = this;
            formLop.Show();
        }

        private void mnuGiangVien_Click(object sender, EventArgs e)
        {
            FormGiangVien formGiangVien = new FormGiangVien();
            formGiangVien.MdiParent = this;
            formGiangVien.Show();
        }

        private void mnuSinhVien_Click(object sender, EventArgs e)
        {
            FormSinhVien formSinhVien = new FormSinhVien();
            formSinhVien.MdiParent = this;
            formSinhVien.Show();
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            FormMonHoc formMonHoc = new FormMonHoc();
            formMonHoc.MdiParent = this;
            formMonHoc.Show();
        }

        private void mnuLopTinChi_Click(object sender, EventArgs e)
        {
            FormLopTinChi formLopTinChi = new FormLopTinChi();
            formLopTinChi.MdiParent = this;
            formLopTinChi.Show();
        }

        private void mnuDangKyLopTinChi_Click(object sender, EventArgs e)
        {
            FormDangKyLopTinChi formDangKyLopTinChi = new FormDangKyLopTinChi();
            formDangKyLopTinChi.MdiParent = this;
            formDangKyLopTinChi.Show();
        }

        private void mnuNhapDiem_Click(object sender, EventArgs e)
        {
            FormNhapDiem formNhapDiem = new FormNhapDiem();
            formNhapDiem.MdiParent = this;
            formNhapDiem.Show();
        }

        private void mnuDanhSachLopTinChi_Click(object sender, EventArgs e)
        {
            FormDanhSachLopTinChi formDanhSachLopTinChi = new FormDanhSachLopTinChi();
            formDanhSachLopTinChi.MdiParent = this;
            formDanhSachLopTinChi.Show();
        }

        private void mnuDanhSachSinhVienDangKy_Click(object sender, EventArgs e)
        {
            FormDanhSachSinhVienDangKy formDanhSachSinhVienDangKy = new FormDanhSachSinhVienDangKy();
            formDanhSachSinhVienDangKy.MdiParent = this;
            formDanhSachSinhVienDangKy.Show();
        }

        private void mnuBangDiemMonHoc_Click(object sender, EventArgs e)
        {
            // TODO: Open FormBangDiemMonHoc
            MessageBox.Show("FormBangDiemMonHoc not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuPhieuDiem_Click(object sender, EventArgs e)
        {
            // TODO: Open FormPhieuDiem
            MessageBox.Show("FormPhieuDiem not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuDanhSachHocPhi_Click(object sender, EventArgs e)
        {
            // TODO: Open FormDanhSachHocPhi
            MessageBox.Show("FormDanhSachHocPhi not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuBangDiemTongKet_Click(object sender, EventArgs e)
        {
            // TODO: Open FormBangDiemTongKet
            MessageBox.Show("FormBangDiemTongKet not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            // TODO: Open FormTaoTaiKhoan
            MessageBox.Show("FormTaoTaiKhoan not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuSaoLuuPhucHoi_Click(object sender, EventArgs e)
        {
            // TODO: Open FormSaoLuuPhucHoi
            MessageBox.Show("FormSaoLuuPhucHoi not implemented yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // Log out and return to login form
            Program.Username = "";
            Program.Role = "";
            Program.FullName = "";
            Program.MaKhoa = "";

            FormLogin formLogin = new FormLogin();
            this.Hide();
            formLogin.ShowDialog();
            this.Close();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            // Exit application
            Application.Exit();
        }
    }
}
