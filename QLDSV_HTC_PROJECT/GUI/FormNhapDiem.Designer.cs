namespace QLDSV_HTC.GUI
{
    partial class FormNhapDiem
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
            this.btnLocLTC = new System.Windows.Forms.Button();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.cboNienKhoa = new System.Windows.Forms.ComboBox();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.panelLopTinChi = new System.Windows.Forms.Panel();
            this.lblDanhSachLTC = new System.Windows.Forms.Label();
            this.dgvLopTinChi = new System.Windows.Forms.DataGridView();
            this.panelDiem = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.lblDanhSachSV = new System.Windows.Forms.Label();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.panelTitle.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.panelLopTinChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).BeginInit();
            this.panelDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
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
            this.lblTitle.Text = "NHẬP ĐIỂM SINH VIÊN";
            // 
            // panelFilter
            // 
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
            this.panelFilter.Size = new System.Drawing.Size(984, 80);
            this.panelFilter.TabIndex = 1;
            // 
            // btnLocLTC
            // 
            this.btnLocLTC.Location = new System.Drawing.Point(700, 30);
            this.btnLocLTC.Name = "btnLocLTC";
            this.btnLocLTC.Size = new System.Drawing.Size(75, 23);
            this.btnLocLTC.TabIndex = 6;
            this.btnLocLTC.Text = "Lọc";
            this.btnLocLTC.UseVisualStyleBackColor = true;
            this.btnLocLTC.Click += new System.EventHandler(this.btnLocLTC_Click);
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(550, 30);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(100, 21);
            this.cboHocKy.TabIndex = 5;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(500, 33);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(44, 13);
            this.lblHocKy.TabIndex = 4;
            this.lblHocKy.Text = "Học Kỳ:";
            // 
            // cboNienKhoa
            // 
            this.cboNienKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNienKhoa.FormattingEnabled = true;
            this.cboNienKhoa.Location = new System.Drawing.Point(350, 30);
            this.cboNienKhoa.Name = "cboNienKhoa";
            this.cboNienKhoa.Size = new System.Drawing.Size(120, 21);
            this.cboNienKhoa.TabIndex = 3;
            this.cboNienKhoa.SelectedIndexChanged += new System.EventHandler(this.cboNienKhoa_SelectedIndexChanged);
            // 
            // lblNienKhoa
            // 
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Location = new System.Drawing.Point(300, 33);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(58, 13);
            this.lblNienKhoa.TabIndex = 2;
            this.lblNienKhoa.Text = "Niên Khóa:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(150, 30);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(120, 21);
            this.cboKhoa.TabIndex = 1;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(100, 33);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(35, 13);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Khoa:";
            // 
            // panelLopTinChi
            // 
            this.panelLopTinChi.Controls.Add(this.lblDanhSachLTC);
            this.panelLopTinChi.Controls.Add(this.dgvLopTinChi);
            this.panelLopTinChi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLopTinChi.Location = new System.Drawing.Point(0, 120);
            this.panelLopTinChi.Name = "panelLopTinChi";
            this.panelLopTinChi.Size = new System.Drawing.Size(984, 200);
            this.panelLopTinChi.TabIndex = 2;
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
            this.dgvLopTinChi.Size = new System.Drawing.Size(784, 150);
            this.dgvLopTinChi.TabIndex = 0;
            this.dgvLopTinChi.SelectionChanged += new System.EventHandler(this.dgvLopTinChi_SelectionChanged);
            // 
            // panelDiem
            // 
            this.panelDiem.Controls.Add(this.btnThoat);
            this.panelDiem.Controls.Add(this.btnGhi);
            this.panelDiem.Controls.Add(this.lblDanhSachSV);
            this.panelDiem.Controls.Add(this.dgvDiem);
            this.panelDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDiem.Location = new System.Drawing.Point(0, 320);
            this.panelDiem.Name = "panelDiem";
            this.panelDiem.Size = new System.Drawing.Size(984, 341);
            this.panelDiem.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(550, 300);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 23);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(350, 300);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(100, 23);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "Ghi Điểm";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // lblDanhSachSV
            // 
            this.lblDanhSachSV.AutoSize = true;
            this.lblDanhSachSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachSV.Location = new System.Drawing.Point(100, 10);
            this.lblDanhSachSV.Name = "lblDanhSachSV";
            this.lblDanhSachSV.Size = new System.Drawing.Size(214, 16);
            this.lblDanhSachSV.TabIndex = 1;
            this.lblDanhSachSV.Text = "Danh sách sinh viên đăng ký";
            // 
            // dgvDiem
            // 
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Location = new System.Drawing.Point(100, 30);
            this.dgvDiem.MultiSelect = false;
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(784, 250);
            this.dgvDiem.TabIndex = 0;
            this.dgvDiem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellEndEdit);
            // 
            // FormNhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panelDiem);
            this.Controls.Add(this.panelLopTinChi);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTitle);
            this.Name = "FormNhapDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập điểm sinh viên";
            this.Load += new System.EventHandler(this.FormNhapDiem_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelLopTinChi.ResumeLayout(false);
            this.panelLopTinChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).EndInit();
            this.panelDiem.ResumeLayout(false);
            this.panelDiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button btnLocLTC;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.ComboBox cboNienKhoa;
        private System.Windows.Forms.Label lblNienKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Panel panelLopTinChi;
        private System.Windows.Forms.Label lblDanhSachLTC;
        private System.Windows.Forms.DataGridView dgvLopTinChi;
        private System.Windows.Forms.Panel panelDiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Label lblDanhSachSV;
        private System.Windows.Forms.DataGridView dgvDiem;
    }
}
