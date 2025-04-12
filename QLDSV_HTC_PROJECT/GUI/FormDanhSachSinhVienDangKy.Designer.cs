namespace QLDSV_HTC.GUI
{
    partial class FormDanhSachSinhVienDangKy
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
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLocLTC = new System.Windows.Forms.Button();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboNienKhoa = new System.Windows.Forms.ComboBox();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.panelLopTinChi = new System.Windows.Forms.Panel();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblDanhSachLTC = new System.Windows.Forms.Label();
            this.dgvLopTinChi = new System.Windows.Forms.DataGridView();
            this.panelReport = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvSinhVien = new System.Windows.Forms.DataGridView();
            this.lblReportSubtitle = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelLopTinChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).BeginInit();
            this.panelReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(884, 40);
            this.panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO SINH VIÊN ĐĂNG KÝ LTC";
            // 
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.btnThoat);
            this.panelFilter.Controls.Add(this.btnLocLTC);
            this.panelFilter.Controls.Add(this.cboHocKy);
            this.panelFilter.Controls.Add(this.lblHocKy);
            this.panelFilter.Controls.Add(this.cboNienKhoa);
            this.panelFilter.Controls.Add(this.lblNienKhoa);
            this.panelFilter.Controls.Add(this.cboKhoa);
            this.panelFilter.Controls.Add(this.lblKhoa);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 40);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(884, 80);
            this.panelFilter.TabIndex = 1;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(700, 30);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLocLTC
            // 
            this.btnLocLTC.Location = new System.Drawing.Point(600, 30);
            this.btnLocLTC.Name = "btnLocLTC";
            this.btnLocLTC.Size = new System.Drawing.Size(75, 23);
            this.btnLocLTC.TabIndex = 6;
            this.btnLocLTC.Text = "Lọc LTC";
            this.btnLocLTC.UseVisualStyleBackColor = true;
            this.btnLocLTC.Click += new System.EventHandler(this.btnLocLTC_Click);
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(450, 30);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(100, 21);
            this.cboHocKy.TabIndex = 5;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(400, 33);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(44, 13);
            this.lblHocKy.TabIndex = 4;
            this.lblHocKy.Text = "Học Kỳ:";
            // 
            // cboNienKhoa
            // 
            this.cboNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNienKhoa.FormattingEnabled = true;
            this.cboNienKhoa.Location = new System.Drawing.Point(250, 30);
            this.cboNienKhoa.Name = "cboNienKhoa";
            this.cboNienKhoa.Size = new System.Drawing.Size(120, 21);
            this.cboNienKhoa.TabIndex = 3;
            // 
            // lblNienKhoa
            // 
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Location = new System.Drawing.Point(200, 33);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(58, 13);
            this.lblNienKhoa.TabIndex = 2;
            this.lblNienKhoa.Text = "Niên Khóa:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(50, 30);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(120, 21);
            this.cboKhoa.TabIndex = 1;
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(10, 33);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(35, 13);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Khoa:";
            // 
            // panelLopTinChi
            // 
            this.panelLopTinChi.Controls.Add(this.btnPreview);
            this.panelLopTinChi.Controls.Add(this.lblDanhSachLTC);
            this.panelLopTinChi.Controls.Add(this.dgvLopTinChi);
            this.panelLopTinChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLopTinChi.Location = new System.Drawing.Point(0, 120);
            this.panelLopTinChi.Name = "panelLopTinChi";
            this.panelLopTinChi.Size = new System.Drawing.Size(884, 200);
            this.panelLopTinChi.TabIndex = 2;
            this.panelLopTinChi.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(400, 170);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(100, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Xem báo cáo";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblDanhSachLTC
            // 
            this.lblDanhSachLTC.AutoSize = true;
            this.lblDanhSachLTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachLTC.Location = new System.Drawing.Point(50, 10);
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
            this.dgvLopTinChi.Location = new System.Drawing.Point(50, 30);
            this.dgvLopTinChi.MultiSelect = false;
            this.dgvLopTinChi.Name = "dgvLopTinChi";
            this.dgvLopTinChi.ReadOnly = true;
            this.dgvLopTinChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopTinChi.Size = new System.Drawing.Size(784, 130);
            this.dgvLopTinChi.TabIndex = 0;
            // 
            // panelReport
            // 
            this.panelReport.Controls.Add(this.btnPrint);
            this.panelReport.Controls.Add(this.dgvSinhVien);
            this.panelReport.Controls.Add(this.lblReportSubtitle);
            this.panelReport.Controls.Add(this.lblReportTitle);
            this.panelReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReport.Location = new System.Drawing.Point(0, 320);
            this.panelReport.Name = "panelReport";
            this.panelReport.Size = new System.Drawing.Size(884, 341);
            this.panelReport.TabIndex = 3;
            this.panelReport.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(400, 300);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "In báo cáo";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvSinhVien
            // 
            this.dgvSinhVien.AllowUserToAddRows = false;
            this.dgvSinhVien.AllowUserToDeleteRows = false;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Location = new System.Drawing.Point(50, 80);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.ReadOnly = true;
            this.dgvSinhVien.Size = new System.Drawing.Size(784, 200);
            this.dgvSinhVien.TabIndex = 2;
            // 
            // lblReportSubtitle
            // 
            this.lblReportSubtitle.AutoSize = true;
            this.lblReportSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportSubtitle.Location = new System.Drawing.Point(300, 40);
            this.lblReportSubtitle.Name = "lblReportSubtitle";
            this.lblReportSubtitle.Size = new System.Drawing.Size(284, 16);
            this.lblReportSubtitle.TabIndex = 1;
            this.lblReportSubtitle.Text = "Môn học: X - Nhóm: 1 - Niên khóa: 2023-2024 - Học kỳ: 1";
            this.lblReportSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.Location = new System.Drawing.Point(300, 10);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(284, 20);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "DANH SÁCH SINH VIÊN ĐĂNG KÝ LTC";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormDanhSachSinhVienDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.panelReport);
            this.Controls.Add(this.panelLopTinChi);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormDanhSachSinhVienDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên đăng ký";
            this.Load += new System.EventHandler(this.FormDanhSachSinhVienDangKy_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelLopTinChi.ResumeLayout(false);
            this.panelLopTinChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).EndInit();
            this.panelReport.ResumeLayout(false);
            this.panelReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLocLTC;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboNienKhoa;
        private System.Windows.Forms.Label lblNienKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Panel panelLopTinChi;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblDanhSachLTC;
        private System.Windows.Forms.DataGridView dgvLopTinChi;
        private System.Windows.Forms.Panel panelReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Label lblReportSubtitle;
        private System.Windows.Forms.Label lblReportTitle;
    }
}
