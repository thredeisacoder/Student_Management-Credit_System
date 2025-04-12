namespace QLDSV_HTC.GUI
{
    partial class FormLopTinChi
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
            this.panelControl = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panelKhoa = new System.Windows.Forms.Panel();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.panelInput = new System.Windows.Forms.Panel();
            this.chkHuyLop = new System.Windows.Forms.CheckBox();
            this.nudSoSVToiThieu = new System.Windows.Forms.NumericUpDown();
            this.lblSoSVToiThieu = new System.Windows.Forms.Label();
            this.cboGiangVien = new System.Windows.Forms.ComboBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.nudNhom = new System.Windows.Forms.NumericUpDown();
            this.lblNhom = new System.Windows.Forms.Label();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.nudHocKy = new System.Windows.Forms.NumericUpDown();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.txtNienKhoa = new System.Windows.Forms.TextBox();
            this.lblNienKhoa = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvLopTinChi = new System.Windows.Forms.DataGridView();
            this.panelControl.SuspendLayout();
            this.panelKhoa.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoSVToiThieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHocKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.btnThoat);
            this.panelControl.Controls.Add(this.btnPhucHoi);
            this.panelControl.Controls.Add(this.btnGhi);
            this.panelControl.Controls.Add(this.btnXoa);
            this.panelControl.Controls.Add(this.btnSua);
            this.panelControl.Controls.Add(this.btnThem);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(784, 40);
            this.panelControl.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(675, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Location = new System.Drawing.Point(575, 10);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(75, 23);
            this.btnPhucHoi.TabIndex = 4;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(475, 10);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 23);
            this.btnGhi.TabIndex = 3;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(375, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(275, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(175, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panelKhoa
            // 
            this.panelKhoa.Controls.Add(this.cboKhoa);
            this.panelKhoa.Controls.Add(this.lblKhoa);
            this.panelKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelKhoa.Location = new System.Drawing.Point(0, 40);
            this.panelKhoa.Name = "panelKhoa";
            this.panelKhoa.Size = new System.Drawing.Size(784, 40);
            this.panelKhoa.TabIndex = 1;
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(100, 10);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(250, 21);
            this.cboKhoa.TabIndex = 1;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(50, 13);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(35, 13);
            this.lblKhoa.TabIndex = 0;
            this.lblKhoa.Text = "Khoa:";
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.chkHuyLop);
            this.panelInput.Controls.Add(this.nudSoSVToiThieu);
            this.panelInput.Controls.Add(this.lblSoSVToiThieu);
            this.panelInput.Controls.Add(this.cboGiangVien);
            this.panelInput.Controls.Add(this.lblGiangVien);
            this.panelInput.Controls.Add(this.nudNhom);
            this.panelInput.Controls.Add(this.lblNhom);
            this.panelInput.Controls.Add(this.cboMonHoc);
            this.panelInput.Controls.Add(this.lblMonHoc);
            this.panelInput.Controls.Add(this.nudHocKy);
            this.panelInput.Controls.Add(this.lblHocKy);
            this.panelInput.Controls.Add(this.txtNienKhoa);
            this.panelInput.Controls.Add(this.lblNienKhoa);
            this.panelInput.Controls.Add(this.lblTitle);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(0, 80);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(784, 220);
            this.panelInput.TabIndex = 2;
            // 
            // chkHuyLop
            // 
            this.chkHuyLop.AutoSize = true;
            this.chkHuyLop.Location = new System.Drawing.Point(500, 180);
            this.chkHuyLop.Name = "chkHuyLop";
            this.chkHuyLop.Size = new System.Drawing.Size(64, 17);
            this.chkHuyLop.TabIndex = 13;
            this.chkHuyLop.Text = "Hủy lớp";
            this.chkHuyLop.UseVisualStyleBackColor = true;
            // 
            // nudSoSVToiThieu
            // 
            this.nudSoSVToiThieu.Location = new System.Drawing.Point(500, 150);
            this.nudSoSVToiThieu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoSVToiThieu.Name = "nudSoSVToiThieu";
            this.nudSoSVToiThieu.Size = new System.Drawing.Size(100, 20);
            this.nudSoSVToiThieu.TabIndex = 12;
            this.nudSoSVToiThieu.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblSoSVToiThieu
            // 
            this.lblSoSVToiThieu.AutoSize = true;
            this.lblSoSVToiThieu.Location = new System.Drawing.Point(400, 153);
            this.lblSoSVToiThieu.Name = "lblSoSVToiThieu";
            this.lblSoSVToiThieu.Size = new System.Drawing.Size(78, 13);
            this.lblSoSVToiThieu.TabIndex = 11;
            this.lblSoSVToiThieu.Text = "Số SV tối thiểu:";
            // 
            // cboGiangVien
            // 
            this.cboGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangVien.FormattingEnabled = true;
            this.cboGiangVien.Location = new System.Drawing.Point(500, 120);
            this.cboGiangVien.Name = "cboGiangVien";
            this.cboGiangVien.Size = new System.Drawing.Size(250, 21);
            this.cboGiangVien.TabIndex = 10;
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new System.Drawing.Point(400, 123);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(61, 13);
            this.lblGiangVien.TabIndex = 9;
            this.lblGiangVien.Text = "Giảng viên:";
            // 
            // nudNhom
            // 
            this.nudNhom.Location = new System.Drawing.Point(100, 150);
            this.nudNhom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNhom.Name = "nudNhom";
            this.nudNhom.Size = new System.Drawing.Size(100, 20);
            this.nudNhom.TabIndex = 8;
            this.nudNhom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.lblNhom.Location = new System.Drawing.Point(50, 153);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(38, 13);
            this.lblNhom.TabIndex = 7;
            this.lblNhom.Text = "Nhóm:";
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(100, 120);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(250, 21);
            this.cboMonHoc.TabIndex = 6;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(50, 123);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(52, 13);
            this.lblMonHoc.TabIndex = 5;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // nudHocKy
            // 
            this.nudHocKy.Location = new System.Drawing.Point(500, 80);
            this.nudHocKy.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudHocKy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHocKy.Name = "nudHocKy";
            this.nudHocKy.Size = new System.Drawing.Size(100, 20);
            this.nudHocKy.TabIndex = 4;
            this.nudHocKy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(400, 83);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(44, 13);
            this.lblHocKy.TabIndex = 3;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // txtNienKhoa
            // 
            this.txtNienKhoa.Location = new System.Drawing.Point(100, 80);
            this.txtNienKhoa.Name = "txtNienKhoa";
            this.txtNienKhoa.Size = new System.Drawing.Size(150, 20);
            this.txtNienKhoa.TabIndex = 2;
            // 
            // lblNienKhoa
            // 
            this.lblNienKhoa.AutoSize = true;
            this.lblNienKhoa.Location = new System.Drawing.Point(50, 83);
            this.lblNienKhoa.Name = "lblNienKhoa";
            this.lblNienKhoa.Size = new System.Drawing.Size(58, 13);
            this.lblNienKhoa.TabIndex = 1;
            this.lblNienKhoa.Text = "Niên khóa:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(300, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH LỚP TÍN CHỈ";
            // 
            // dgvLopTinChi
            // 
            this.dgvLopTinChi.AllowUserToAddRows = false;
            this.dgvLopTinChi.AllowUserToDeleteRows = false;
            this.dgvLopTinChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLopTinChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLopTinChi.Location = new System.Drawing.Point(0, 300);
            this.dgvLopTinChi.MultiSelect = false;
            this.dgvLopTinChi.Name = "dgvLopTinChi";
            this.dgvLopTinChi.ReadOnly = true;
            this.dgvLopTinChi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLopTinChi.Size = new System.Drawing.Size(784, 261);
            this.dgvLopTinChi.TabIndex = 3;
            this.dgvLopTinChi.SelectionChanged += new System.EventHandler(this.dgvLopTinChi_SelectionChanged);
            // 
            // FormLopTinChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dgvLopTinChi);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelKhoa);
            this.Controls.Add(this.panelControl);
            this.Name = "FormLopTinChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lớp tín chỉ";
            this.Load += new System.EventHandler(this.FormLopTinChi_Load);
            this.panelControl.ResumeLayout(false);
            this.panelKhoa.ResumeLayout(false);
            this.panelKhoa.PerformLayout();
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoSVToiThieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHocKy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLopTinChi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panelKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.CheckBox chkHuyLop;
        private System.Windows.Forms.NumericUpDown nudSoSVToiThieu;
        private System.Windows.Forms.Label lblSoSVToiThieu;
        private System.Windows.Forms.ComboBox cboGiangVien;
        private System.Windows.Forms.Label lblGiangVien;
        private System.Windows.Forms.NumericUpDown nudNhom;
        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.NumericUpDown nudHocKy;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.TextBox txtNienKhoa;
        private System.Windows.Forms.Label lblNienKhoa;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvLopTinChi;
    }
}
