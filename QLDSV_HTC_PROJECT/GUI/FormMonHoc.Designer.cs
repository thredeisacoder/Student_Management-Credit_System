namespace QLDSV_HTC.GUI
{
    partial class FormMonHoc
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.nudSoTiet_TH = new System.Windows.Forms.NumericUpDown();
            this.nudSoTiet_LT = new System.Windows.Forms.NumericUpDown();
            this.lblSoTiet_TH = new System.Windows.Forms.Label();
            this.lblSoTiet_LT = new System.Windows.Forms.Label();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.lblTenMH = new System.Windows.Forms.Label();
            this.lblMaMH = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvMonHoc = new System.Windows.Forms.DataGridView();
            this.panelControl.SuspendLayout();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTiet_TH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTiet_LT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).BeginInit();
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
            this.panelControl.Size = new System.Drawing.Size(684, 40);
            this.panelControl.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(575, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Location = new System.Drawing.Point(475, 10);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(75, 23);
            this.btnPhucHoi.TabIndex = 4;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(375, 10);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 23);
            this.btnGhi.TabIndex = 3;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(275, 10);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(175, 10);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(75, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panelInput
            // 
            this.panelInput.Controls.Add(this.nudSoTiet_TH);
            this.panelInput.Controls.Add(this.nudSoTiet_LT);
            this.panelInput.Controls.Add(this.lblSoTiet_TH);
            this.panelInput.Controls.Add(this.lblSoTiet_LT);
            this.panelInput.Controls.Add(this.txtTenMH);
            this.panelInput.Controls.Add(this.txtMaMH);
            this.panelInput.Controls.Add(this.lblTenMH);
            this.panelInput.Controls.Add(this.lblMaMH);
            this.panelInput.Controls.Add(this.lblTitle);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(0, 40);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(684, 150);
            this.panelInput.TabIndex = 1;
            // 
            // nudSoTiet_TH
            // 
            this.nudSoTiet_TH.Location = new System.Drawing.Point(500, 80);
            this.nudSoTiet_TH.Name = "nudSoTiet_TH";
            this.nudSoTiet_TH.Size = new System.Drawing.Size(100, 20);
            this.nudSoTiet_TH.TabIndex = 8;
            // 
            // nudSoTiet_LT
            // 
            this.nudSoTiet_LT.Location = new System.Drawing.Point(500, 50);
            this.nudSoTiet_LT.Name = "nudSoTiet_LT";
            this.nudSoTiet_LT.Size = new System.Drawing.Size(100, 20);
            this.nudSoTiet_LT.TabIndex = 7;
            // 
            // lblSoTiet_TH
            // 
            this.lblSoTiet_TH.AutoSize = true;
            this.lblSoTiet_TH.Location = new System.Drawing.Point(400, 83);
            this.lblSoTiet_TH.Name = "lblSoTiet_TH";
            this.lblSoTiet_TH.Size = new System.Drawing.Size(94, 13);
            this.lblSoTiet_TH.TabIndex = 6;
            this.lblSoTiet_TH.Text = "Số tiết thực hành:";
            // 
            // lblSoTiet_LT
            // 
            this.lblSoTiet_LT.AutoSize = true;
            this.lblSoTiet_LT.Location = new System.Drawing.Point(400, 53);
            this.lblSoTiet_LT.Name = "lblSoTiet_LT";
            this.lblSoTiet_LT.Size = new System.Drawing.Size(85, 13);
            this.lblSoTiet_LT.TabIndex = 5;
            this.lblSoTiet_LT.Text = "Số tiết lý thuyết:";
            // 
            // txtTenMH
            // 
            this.txtTenMH.Location = new System.Drawing.Point(150, 80);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(200, 20);
            this.txtTenMH.TabIndex = 4;
            // 
            // txtMaMH
            // 
            this.txtMaMH.Location = new System.Drawing.Point(150, 50);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(150, 20);
            this.txtMaMH.TabIndex = 3;
            // 
            // lblTenMH
            // 
            this.lblTenMH.AutoSize = true;
            this.lblTenMH.Location = new System.Drawing.Point(75, 83);
            this.lblTenMH.Name = "lblTenMH";
            this.lblTenMH.Size = new System.Drawing.Size(73, 13);
            this.lblTenMH.TabIndex = 2;
            this.lblTenMH.Text = "Tên môn học:";
            // 
            // lblMaMH
            // 
            this.lblMaMH.AutoSize = true;
            this.lblMaMH.Location = new System.Drawing.Point(75, 53);
            this.lblMaMH.Name = "lblMaMH";
            this.lblMaMH.Size = new System.Drawing.Size(69, 13);
            this.lblMaMH.TabIndex = 1;
            this.lblMaMH.Text = "Mã môn học:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(250, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH MÔN HỌC";
            // 
            // dgvMonHoc
            // 
            this.dgvMonHoc.AllowUserToAddRows = false;
            this.dgvMonHoc.AllowUserToDeleteRows = false;
            this.dgvMonHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMonHoc.Location = new System.Drawing.Point(0, 190);
            this.dgvMonHoc.MultiSelect = false;
            this.dgvMonHoc.Name = "dgvMonHoc";
            this.dgvMonHoc.ReadOnly = true;
            this.dgvMonHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonHoc.Size = new System.Drawing.Size(684, 271);
            this.dgvMonHoc.TabIndex = 2;
            this.dgvMonHoc.SelectionChanged += new System.EventHandler(this.dgvMonHoc_SelectionChanged);
            // 
            // FormMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.dgvMonHoc);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.panelControl);
            this.Name = "FormMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý môn học";
            this.Load += new System.EventHandler(this.FormMonHoc_Load);
            this.panelControl.ResumeLayout(false);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTiet_TH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTiet_LT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHoc)).EndInit();
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
        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.NumericUpDown nudSoTiet_TH;
        private System.Windows.Forms.NumericUpDown nudSoTiet_LT;
        private System.Windows.Forms.Label lblSoTiet_TH;
        private System.Windows.Forms.Label lblSoTiet_LT;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Label lblTenMH;
        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvMonHoc;
    }
}
