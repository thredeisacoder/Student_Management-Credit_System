namespace QLDSV_HTC.GUI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiangVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLopTinChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangKyLopTinChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhSachLopTinChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhSachSinhVienDangKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangDiemMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhieuDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhSachHocPhi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBangDiemTongKet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTaoTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaoLuuPhucHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFullName = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhMuc,
            this.mnuNghiepVu,
            this.mnuBaoCao,
            this.mnuQuanTri,
            this.mnuHeThong});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKhoa,
            this.mnuLop,
            this.mnuGiangVien,
            this.mnuSinhVien,
            this.mnuMonHoc,
            this.mnuLopTinChi});
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(74, 20);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuKhoa
            // 
            this.mnuKhoa.Name = "mnuKhoa";
            this.mnuKhoa.Size = new System.Drawing.Size(180, 22);
            this.mnuKhoa.Text = "Khoa";
            this.mnuKhoa.Click += new System.EventHandler(this.mnuKhoa_Click);
            // 
            // mnuLop
            // 
            this.mnuLop.Name = "mnuLop";
            this.mnuLop.Size = new System.Drawing.Size(180, 22);
            this.mnuLop.Text = "Lớp";
            this.mnuLop.Click += new System.EventHandler(this.mnuLop_Click);
            // 
            // mnuGiangVien
            // 
            this.mnuGiangVien.Name = "mnuGiangVien";
            this.mnuGiangVien.Size = new System.Drawing.Size(180, 22);
            this.mnuGiangVien.Text = "Giảng viên";
            this.mnuGiangVien.Click += new System.EventHandler(this.mnuGiangVien_Click);
            // 
            // mnuSinhVien
            // 
            this.mnuSinhVien.Name = "mnuSinhVien";
            this.mnuSinhVien.Size = new System.Drawing.Size(180, 22);
            this.mnuSinhVien.Text = "Sinh viên";
            this.mnuSinhVien.Click += new System.EventHandler(this.mnuSinhVien_Click);
            // 
            // mnuMonHoc
            // 
            this.mnuMonHoc.Name = "mnuMonHoc";
            this.mnuMonHoc.Size = new System.Drawing.Size(180, 22);
            this.mnuMonHoc.Text = "Môn học";
            this.mnuMonHoc.Click += new System.EventHandler(this.mnuMonHoc_Click);
            // 
            // mnuLopTinChi
            // 
            this.mnuLopTinChi.Name = "mnuLopTinChi";
            this.mnuLopTinChi.Size = new System.Drawing.Size(180, 22);
            this.mnuLopTinChi.Text = "Lớp tín chỉ";
            this.mnuLopTinChi.Click += new System.EventHandler(this.mnuLopTinChi_Click);
            // 
            // mnuNghiepVu
            // 
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangKyLopTinChi,
            this.mnuNhapDiem});
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Size = new System.Drawing.Size(74, 20);
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuDangKyLopTinChi
            // 
            this.mnuDangKyLopTinChi.Name = "mnuDangKyLopTinChi";
            this.mnuDangKyLopTinChi.Size = new System.Drawing.Size(180, 22);
            this.mnuDangKyLopTinChi.Text = "Đăng ký lớp tín chỉ";
            this.mnuDangKyLopTinChi.Click += new System.EventHandler(this.mnuDangKyLopTinChi_Click);
            // 
            // mnuNhapDiem
            // 
            this.mnuNhapDiem.Name = "mnuNhapDiem";
            this.mnuNhapDiem.Size = new System.Drawing.Size(180, 22);
            this.mnuNhapDiem.Text = "Nhập điểm";
            this.mnuNhapDiem.Click += new System.EventHandler(this.mnuNhapDiem_Click);
            // 
            // mnuBaoCao
            // 
            this.mnuBaoCao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDanhSachLopTinChi,
            this.mnuDanhSachSinhVienDangKy,
            this.mnuBangDiemMonHoc,
            this.mnuPhieuDiem,
            this.mnuDanhSachHocPhi,
            this.mnuBangDiemTongKet});
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Size = new System.Drawing.Size(61, 20);
            this.mnuBaoCao.Text = "Báo cáo";
            // 
            // mnuDanhSachLopTinChi
            // 
            this.mnuDanhSachLopTinChi.Name = "mnuDanhSachLopTinChi";
            this.mnuDanhSachLopTinChi.Size = new System.Drawing.Size(227, 22);
            this.mnuDanhSachLopTinChi.Text = "Danh sách lớp tín chỉ";
            this.mnuDanhSachLopTinChi.Click += new System.EventHandler(this.mnuDanhSachLopTinChi_Click);
            // 
            // mnuDanhSachSinhVienDangKy
            // 
            this.mnuDanhSachSinhVienDangKy.Name = "mnuDanhSachSinhVienDangKy";
            this.mnuDanhSachSinhVienDangKy.Size = new System.Drawing.Size(227, 22);
            this.mnuDanhSachSinhVienDangKy.Text = "Danh sách sinh viên đăng ký";
            this.mnuDanhSachSinhVienDangKy.Click += new System.EventHandler(this.mnuDanhSachSinhVienDangKy_Click);
            // 
            // mnuBangDiemMonHoc
            // 
            this.mnuBangDiemMonHoc.Name = "mnuBangDiemMonHoc";
            this.mnuBangDiemMonHoc.Size = new System.Drawing.Size(227, 22);
            this.mnuBangDiemMonHoc.Text = "Bảng điểm môn học";
            this.mnuBangDiemMonHoc.Click += new System.EventHandler(this.mnuBangDiemMonHoc_Click);
            // 
            // mnuPhieuDiem
            // 
            this.mnuPhieuDiem.Name = "mnuPhieuDiem";
            this.mnuPhieuDiem.Size = new System.Drawing.Size(227, 22);
            this.mnuPhieuDiem.Text = "Phiếu điểm";
            this.mnuPhieuDiem.Click += new System.EventHandler(this.mnuPhieuDiem_Click);
            // 
            // mnuDanhSachHocPhi
            // 
            this.mnuDanhSachHocPhi.Name = "mnuDanhSachHocPhi";
            this.mnuDanhSachHocPhi.Size = new System.Drawing.Size(227, 22);
            this.mnuDanhSachHocPhi.Text = "Danh sách học phí";
            this.mnuDanhSachHocPhi.Click += new System.EventHandler(this.mnuDanhSachHocPhi_Click);
            // 
            // mnuBangDiemTongKet
            // 
            this.mnuBangDiemTongKet.Name = "mnuBangDiemTongKet";
            this.mnuBangDiemTongKet.Size = new System.Drawing.Size(227, 22);
            this.mnuBangDiemTongKet.Text = "Bảng điểm tổng kết";
            this.mnuBangDiemTongKet.Click += new System.EventHandler(this.mnuBangDiemTongKet_Click);
            // 
            // mnuQuanTri
            // 
            this.mnuQuanTri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaoTaiKhoan,
            this.mnuSaoLuuPhucHoi});
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(60, 20);
            this.mnuQuanTri.Text = "Quản trị";
            // 
            // mnuTaoTaiKhoan
            // 
            this.mnuTaoTaiKhoan.Name = "mnuTaoTaiKhoan";
            this.mnuTaoTaiKhoan.Size = new System.Drawing.Size(180, 22);
            this.mnuTaoTaiKhoan.Text = "Tạo tài khoản";
            this.mnuTaoTaiKhoan.Click += new System.EventHandler(this.mnuTaoTaiKhoan_Click);
            // 
            // mnuSaoLuuPhucHoi
            // 
            this.mnuSaoLuuPhucHoi.Name = "mnuSaoLuuPhucHoi";
            this.mnuSaoLuuPhucHoi.Size = new System.Drawing.Size(180, 22);
            this.mnuSaoLuuPhucHoi.Text = "Sao lưu && Phục hồi";
            this.mnuSaoLuuPhucHoi.Click += new System.EventHandler(this.mnuSaoLuuPhucHoi_Click);
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangXuat,
            this.mnuThoat});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(69, 20);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(180, 22);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(180, 22);
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUsername,
            this.tsslRole,
            this.tsslFullName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslUsername
            // 
            this.tsslUsername.Name = "tsslUsername";
            this.tsslUsername.Size = new System.Drawing.Size(33, 17);
            this.tsslUsername.Text = "User:";
            // 
            // tsslRole
            // 
            this.tsslRole.Name = "tsslRole";
            this.tsslRole.Size = new System.Drawing.Size(33, 17);
            this.tsslRole.Text = "Role:";
            // 
            // tsslFullName
            // 
            this.tsslFullName.Name = "tsslFullName";
            this.tsslFullName.Size = new System.Drawing.Size(42, 17);
            this.tsslFullName.Text = "Name:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý điểm sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuKhoa;
        private System.Windows.Forms.ToolStripMenuItem mnuLop;
        private System.Windows.Forms.ToolStripMenuItem mnuGiangVien;
        private System.Windows.Forms.ToolStripMenuItem mnuSinhVien;
        private System.Windows.Forms.ToolStripMenuItem mnuMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuLopTinChi;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem mnuDangKyLopTinChi;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhSachLopTinChi;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhSachSinhVienDangKy;
        private System.Windows.Forms.ToolStripMenuItem mnuBangDiemMonHoc;
        private System.Windows.Forms.ToolStripMenuItem mnuPhieuDiem;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhSachHocPhi;
        private System.Windows.Forms.ToolStripMenuItem mnuBangDiemTongKet;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuTaoTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem mnuSaoLuuPhucHoi;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslUsername;
        private System.Windows.Forms.ToolStripStatusLabel tsslRole;
        private System.Windows.Forms.ToolStripStatusLabel tsslFullName;
    }
}
