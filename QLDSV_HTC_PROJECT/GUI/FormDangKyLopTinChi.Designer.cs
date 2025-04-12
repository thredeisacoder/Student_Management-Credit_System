namespace QLDSV_HTC.GUI
{
    partial class FormDangKyLopTinChi
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSinhVien = new System.Windows.Forms.Panel();
            this.btnTimSV = new System.Windows.Forms.Button();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnLocLTC = new System.Windows.Forms.Button();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboNienKhoa = new System.Windows.Forms.ComboBox();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.panelLopTinChi = new System.Windows.Forms.Panel();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.lblDanhSachLTC = new System.Windows.Forms.Label();
            this.dgvLopTinChi = new System.Windows.Forms.DataGridView();
            this.panelDangKy = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuyDangKy = new System.Windows.Forms.Button();
            this.lblDanhSachDK = new System.Windows.Forms.Label();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.panelTitle.SuspendLayout();
            this.panelSinhVien.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelLopTinChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).BeginInit();
            this.panelDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(984, 40);
            this.panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(400, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ LỚP TÍN CHỈ";
            // 
            // panelSinhVien
            // 
            this.panelSinhVien.Controls.Add(this.btnTimSV);
            this.panelSinhVien.Controls.Add(this.txtMaLop);
            this.panelSinhVien.Controls.Add(this.lblMaLop);
            this.panelSinhVien.Controls.Add(this.txtHoTen);
            this.panelSinhVien.Controls.Add(this.lblHoTen);
            this.panelSinhVien.Controls.Add(this.txtMaSV);
            this.panelSinhVien.Controls.Add(this.lblMaSV);
            this.panelSinhVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSinhVien.Location = new System.Drawing.Point(0, 40);
            this.panelSinhVien.Name = "panelSinhVien";
            this.panelSinhVien.Size = new System.Drawing.Size(984, 80);
            this.panelSinhVien.TabIndex = 1;
            // 
            // btnTimSV
            // 
            this.btnTimSV.Location = new System.Drawing.Point(300, 20);
            this.btnTimSV.Name = "btnTimSV";
            this.btnTimSV.Size = new System.Drawing.Size(75, 23);
            this.btnTimSV.TabIndex = 6;
            this.btnTimSV.Text = "Tìm";
            this.btnTimSV.UseVisualStyleBackColor = true;
            this.btnTimSV.Click += new System.EventHandler(this.btnTimSV_Click);
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(700, 20);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.Size = new System.Drawing.Size(150, 20);
            this.txtMaLop.TabIndex = 5;
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(650, 23);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(46, 13);
            this.lblMaLop.TabIndex = 4;
            this.lblMaLop.Text = "Mã Lớp:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(450, 20);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(180, 20);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(400, 23);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(46, 13);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ Tên:";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(150, 20);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(120, 20);
            this.txtMaSV.TabIndex = 1;
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(100, 23);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(42, 13);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã SV:";
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnLocLTC);
            this.panelFilter.Controls.Add(this.cboHocKy);
            this.panelFilter.Controls.Add(this.lblHocKy);
            this.panelFilter.Controls.Add(this.cboNienKhoa);
            this.panelFilter.Controls.Add(this.lblNienKhoa);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 120);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(984, 40);
            this.panelFilter.TabIndex = 2;
            // 
            // btnLocLTC
            // 
            this.btnLocLTC.Location = new System.Drawing.Point(500, 10);
            this.btnLocLTC.Name = "btnLocLTC";
            this.btnLocLTC.Size = new System.Drawing.Size(75, 23);
            this.btnLocLTC.TabIndex = 4;
            this.btnLocLTC.Text = "Lọc";
            this.btnLocLTC.UseVisualStyleBackColor = true;
            this.btnLocLTC.Click += new System.EventHandler(this.btnLocLTC_Click);
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(350, 10);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(100, 21);
            this.cboHocKy.TabIndex = 3;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(300, 13);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(44, 13);
            this.lblHocKy.TabIndex = 2;
            this.lblHocKy.Text = "Học Kỳ:";
            // 
            // cboNienKhoa
            // 
            this.cboNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNienKhoa.FormattingEnabled = true;
            this.cboNienKhoa.Location = new System.Drawing.Point(150, 10);
            this.cboNienKhoa.Name = "cboNienKhoa";
            this.cboNienKhoa.Size = new System.Drawing.Size(120, 21);
            this.cboNienKhoa.TabIndex = 1;
            // 
            // lblNienKhoa
            // 
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Location = new System.Drawing.Point(100, 13);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(58, 13);
            this.lblNienKhoa.TabIndex = 0;
            this.lblNienKhoa.Text = "Niên Khóa:";
            // 
            // panelLopTinChi
            // 
            this.panelLopTinChi.Controls.Add(this.btnDangKy);
            this.panelLopTinChi.Controls.Add(this.lblDanhSachLTC);
            this.panelLopTinChi.Controls.Add(this.dgvLopTinChi);
            this.panelLopTinChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLopTinChi.Location = new System.Drawing.Point(0, 160);
            this.panelLopTinChi.Name = "panelLopTinChi";
            this.panelLopTinChi.Size = new System.Drawing.Size(984, 250);
            this.panelLopTinChi.TabIndex = 3;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(450, 220);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(100, 23);
            this.btnDangKy.TabIndex = 2;
            this.btnDangKy.Text = "Đăng Ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // lblDanhSachLTC
            // 
            this.lblDanhSachLTC.AutoSize = true;
            this.lblDanhSachLTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachLTC.Location = new System.Drawing.Point(100, 10);
            this.lblDanhSachLTC.Name = "lblDanhSachLTC";
            this.lblDanhSachLTC.Size = new System.Drawing.Size(177, 16);
            this.lblDanhSachLTC.TabIndex = 1;
            this.lblDanhSachLTC.Text = "Danh sách lớp tín chỉ mở";
            // 
            // dgvLopTinChi
            // 
            this.dgvLopTinChi.AllowUserToAddRows = false;
            this.dgvLopTinChi.AllowUserToDeleteRows = false;
            this.dgvLopTinChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopTinChi.Location = new System.Drawing.Point(100, 30);
            this.dgvLopTinChi.MultiSelect = false;
            this.dgvLopTinChi.Name = "dgvLopTinChi";
            this.dgvLopTinChi.ReadOnly = true;
            this.dgvLopTinChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopTinChi.Size = new System.Drawing.Size(784, 180);
            this.dgvLopTinChi.TabIndex = 0;
            this.dgvLopTinChi.SelectionChanged += new System.EventHandler(this.dgvLopTinChi_SelectionChanged);
            // 
            // panelDangKy
            // 
            this.panelDangKy.Controls.Add(this.btnThoat);
            this.panelDangKy.Controls.Add(this.btnHuyDangKy);
            this.panelDangKy.Controls.Add(this.lblDanhSachDK);
            this.panelDangKy.Controls.Add(this.dgvDangKy);
            this.panelDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDangKy.Location = new System.Drawing.Point(0, 410);
            this.panelDangKy.Name = "panelDangKy";
            this.panelDangKy.Size = new System.Drawing.Size(984, 251);
            this.panelDangKy.TabIndex = 4;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(550, 220);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuyDangKy
            // 
            this.btnHuyDangKy.Location = new System.Drawing.Point(350, 220);
            this.btnHuyDangKy.Name = "btnHuyDangKy";
            this.btnHuyDangKy.Size = new System.Drawing.Size(100, 23);
            this.btnHuyDangKy.TabIndex = 2;
            this.btnHuyDangKy.Text = "Hủy Đăng Ký";
            this.btnHuyDangKy.UseVisualStyleBackColor = true;
            this.btnHuyDangKy.Click += new System.EventHandler(this.btnHuyDangKy_Click);
            // 
            // lblDanhSachDK
            // 
            this.lblDanhSachDK.AutoSize = true;
            this.lblDanhSachDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachDK.Location = new System.Drawing.Point(100, 10);
            this.lblDanhSachDK.Name = "lblDanhSachDK";
            this.lblDanhSachDK.Size = new System.Drawing.Size(139, 16);
            this.lblDanhSachDK.TabIndex = 1;
            this.lblDanhSachDK.Text = "Danh sách đăng ký";
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.AllowUserToAddRows = false;
            this.dgvDangKy.AllowUserToDeleteRows = false;
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Location = new System.Drawing.Point(100, 30);
            this.dgvDangKy.MultiSelect = false;
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.ReadOnly = true;
            this.dgvDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangKy.Size = new System.Drawing.Size(784, 180);
            this.dgvDangKy.TabIndex = 0;
            this.dgvDangKy.SelectionChanged += new System.EventHandler(this.dgvDangKy_SelectionChanged);
            // 
            // FormDangKyLopTinChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panelDangKy);
            this.Controls.Add(this.panelLopTinChi);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelSinhVien);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormDangKyLopTinChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký lớp tín chỉ";
            this.Load += new System.EventHandler(this.FormDangKyLopTinChi_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelSinhVien.ResumeLayout(false);
            this.panelSinhVien.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelLopTinChi.ResumeLayout(false);
            this.panelLopTinChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).EndInit();
            this.panelDangKy.ResumeLayout(false);
            this.panelDangKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelSinhVien;
        private System.Windows.Forms.Button btnTimSV;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnLocLTC;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboNienKhoa;
        private System.Windows.Forms.Label lblNienKhoa;
        private System.Windows.Forms.Panel panelLopTinChi;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label lblDanhSachLTC;
        private System.Windows.Forms.DataGridView dgvLopTinChi;
        private System.Windows.Forms.Panel panelDangKy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuyDangKy;
        private System.Windows.Forms.Label lblDanhSachDK;
        private System.Windows.Forms.DataGridView dgvDangKy;
    }
}
