namespace DU_AN_DESKTOP_CUOI_KY
{
    partial class HoaDonSinhVien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle         = new System.Windows.Forms.Label();
            this.lblLocThang      = new System.Windows.Forms.Label();
            this.cboLocThang      = new System.Windows.Forms.ComboBox();
            this.lblLocTrang      = new System.Windows.Forms.Label();
            this.cboLocTrang      = new System.Windows.Forms.ComboBox();
            this.btnLoc           = new System.Windows.Forms.Button();
            this.dgvHoaDon        = new System.Windows.Forms.DataGridView();
            this.lblChiTiet       = new System.Windows.Forms.Label();
            this.panelChiTiet     = new System.Windows.Forms.Panel();
            this.lblThangNam      = new System.Windows.Forms.Label();
            this.lblTienPhong     = new System.Windows.Forms.Label();
            this.lblTienDien      = new System.Windows.Forms.Label();
            this.lblTienNuoc      = new System.Windows.Forms.Label();
            this.lblTienDichVu    = new System.Windows.Forms.Label();
            this.lblTongTien      = new System.Windows.Forms.Label();
            this.lblHanThanhToan  = new System.Windows.Forms.Label();
            this.lblTrangThaiHD   = new System.Windows.Forms.Label();
            this.lblTongNo        = new System.Windows.Forms.Label();
            this.btnDongCua       = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.panelChiTiet.SuspendLayout();
            this.SuspendLayout();

            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblTitle.Location  = new System.Drawing.Point(20, 16);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(760, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "🧾 Hóa Đơn Tiền Phòng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblLocThang.AutoSize  = true;
            this.lblLocThang.BackColor = System.Drawing.Color.Transparent;
            this.lblLocThang.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLocThang.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblLocThang.Location  = new System.Drawing.Point(20, 72);
            this.lblLocThang.Name      = "lblLocThang";
            this.lblLocThang.TabIndex  = 1;
            this.lblLocThang.Text      = "LỌC THEO THÁNG/NĂM";

            this.cboLocThang.BackColor     = System.Drawing.Color.FromArgb(28, 36, 64);
            this.cboLocThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocThang.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocThang.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocThang.ForeColor     = System.Drawing.Color.FromArgb(180, 210, 240);
            this.cboLocThang.Location      = new System.Drawing.Point(20, 92);
            this.cboLocThang.Name          = "cboLocThang";
            this.cboLocThang.Size          = new System.Drawing.Size(160, 30);
            this.cboLocThang.TabIndex      = 2;

            this.lblLocTrang.AutoSize  = true;
            this.lblLocTrang.BackColor = System.Drawing.Color.Transparent;
            this.lblLocTrang.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLocTrang.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblLocTrang.Location  = new System.Drawing.Point(200, 72);
            this.lblLocTrang.Name      = "lblLocTrang";
            this.lblLocTrang.TabIndex  = 3;
            this.lblLocTrang.Text      = "TRẠNG THÁI";

            this.cboLocTrang.BackColor     = System.Drawing.Color.FromArgb(28, 36, 64);
            this.cboLocTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrang.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocTrang.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTrang.ForeColor     = System.Drawing.Color.FromArgb(180, 210, 240);
            this.cboLocTrang.Items.AddRange(new object[] {
                "Tất cả", "Chưa thanh toán", "Đã thanh toán", "Quá hạn" });
            this.cboLocTrang.Location      = new System.Drawing.Point(200, 92);
            this.cboLocTrang.Name          = "cboLocTrang";
            this.cboLocTrang.Size          = new System.Drawing.Size(180, 30);
            this.cboLocTrang.TabIndex      = 4;

            this.btnLoc.BackColor              = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnLoc.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor              = System.Drawing.Color.FromArgb(10, 14, 26);
            this.btnLoc.Location               = new System.Drawing.Point(398, 89);
            this.btnLoc.Name                   = "btnLoc";
            this.btnLoc.Size                   = new System.Drawing.Size(110, 34);
            this.btnLoc.TabIndex               = 5;
            this.btnLoc.Text                   = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;

            this.lblTongNo.AutoSize  = true;
            this.lblTongNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTongNo.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongNo.ForeColor = System.Drawing.Color.FromArgb(255, 120, 80);
            this.lblTongNo.Location  = new System.Drawing.Point(530, 92);
            this.lblTongNo.Name      = "lblTongNo";
            this.lblTongNo.TabIndex  = 6;
            this.lblTongNo.Text      = "Tổng còn nợ: ---";

            this.dgvHoaDon.AllowUserToAddRows          = false;
            this.dgvHoaDon.AllowUserToDeleteRows       = false;
            this.dgvHoaDon.BackgroundColor             = System.Drawing.Color.FromArgb(18, 24, 44);
            this.dgvHoaDon.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHoaDon.ColumnHeadersHeight         = 36;
            this.dgvHoaDon.DefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(22, 30, 54);
            this.dgvHoaDon.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(180, 210, 240);
            this.dgvHoaDon.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHoaDon.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 160);
            this.dgvHoaDon.GridColor                   = System.Drawing.Color.FromArgb(40, 52, 88);
            this.dgvHoaDon.Location                    = new System.Drawing.Point(20, 136);
            this.dgvHoaDon.MultiSelect                 = false;
            this.dgvHoaDon.Name                        = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly                    = true;
            this.dgvHoaDon.RowHeadersVisible           = false;
            this.dgvHoaDon.RowTemplate.Height          = 30;
            this.dgvHoaDon.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size                        = new System.Drawing.Size(760, 240);
            this.dgvHoaDon.TabIndex                    = 7;

            this.lblChiTiet.AutoSize  = true;
            this.lblChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.lblChiTiet.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblChiTiet.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblChiTiet.Location  = new System.Drawing.Point(20, 388);
            this.lblChiTiet.Name      = "lblChiTiet";
            this.lblChiTiet.TabIndex  = 8;
            this.lblChiTiet.Text      = "CHI TIẾT HÓA ĐƠN ĐƯỢC CHỌN";

            this.panelChiTiet.BackColor = System.Drawing.Color.FromArgb(22, 30, 54);
            this.panelChiTiet.Controls.Add(this.lblThangNam);
            this.panelChiTiet.Controls.Add(this.lblTienPhong);
            this.panelChiTiet.Controls.Add(this.lblTienDien);
            this.panelChiTiet.Controls.Add(this.lblTienNuoc);
            this.panelChiTiet.Controls.Add(this.lblTienDichVu);
            this.panelChiTiet.Controls.Add(this.lblTongTien);
            this.panelChiTiet.Controls.Add(this.lblHanThanhToan);
            this.panelChiTiet.Controls.Add(this.lblTrangThaiHD);
            this.panelChiTiet.Location  = new System.Drawing.Point(20, 408);
            this.panelChiTiet.Name      = "panelChiTiet";
            this.panelChiTiet.Size      = new System.Drawing.Size(760, 100);
            this.panelChiTiet.TabIndex  = 9;

            
            this.lblThangNam.AutoSize  = true;
            this.lblThangNam.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThangNam.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblThangNam.Location  = new System.Drawing.Point(12, 10);
            this.lblThangNam.Name      = "lblThangNam";
            this.lblThangNam.Text      = "Tháng/Năm: ---";

            this.lblTienPhong.AutoSize  = true;
            this.lblTienPhong.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTienPhong.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblTienPhong.Location  = new System.Drawing.Point(12, 32);
            this.lblTienPhong.Name      = "lblTienPhong";
            this.lblTienPhong.Text      = "Tiền phòng: ---";

            this.lblTienDien.AutoSize  = true;
            this.lblTienDien.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTienDien.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblTienDien.Location  = new System.Drawing.Point(12, 54);
            this.lblTienDien.Name      = "lblTienDien";
            this.lblTienDien.Text      = "Tiền điện: ---";

            this.lblTienNuoc.AutoSize  = true;
            this.lblTienNuoc.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTienNuoc.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblTienNuoc.Location  = new System.Drawing.Point(12, 76);
            this.lblTienNuoc.Name      = "lblTienNuoc";
            this.lblTienNuoc.Text      = "Tiền nước: ---";

           
            this.lblTienDichVu.AutoSize  = true;
            this.lblTienDichVu.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTienDichVu.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblTienDichVu.Location  = new System.Drawing.Point(300, 10);
            this.lblTienDichVu.Name      = "lblTienDichVu";
            this.lblTienDichVu.Text      = "Tiền dịch vụ: ---";

            this.lblTongTien.AutoSize  = true;
            this.lblTongTien.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblTongTien.Location  = new System.Drawing.Point(300, 32);
            this.lblTongTien.Name      = "lblTongTien";
            this.lblTongTien.Text      = "Tổng tiền: ---";

            this.lblHanThanhToan.AutoSize  = true;
            this.lblHanThanhToan.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHanThanhToan.ForeColor = System.Drawing.Color.FromArgb(255, 200, 50);
            this.lblHanThanhToan.Location  = new System.Drawing.Point(300, 54);
            this.lblHanThanhToan.Name      = "lblHanThanhToan";
            this.lblHanThanhToan.Text      = "Hạn thanh toán: ---";

            this.lblTrangThaiHD.AutoSize  = true;
            this.lblTrangThaiHD.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiHD.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128);
            this.lblTrangThaiHD.Location  = new System.Drawing.Point(300, 76);
            this.lblTrangThaiHD.Name      = "lblTrangThaiHD";
            this.lblTrangThaiHD.Text      = "Trạng thái: ---";

            this.btnDongCua.BackColor              = System.Drawing.Color.FromArgb(40, 52, 88);
            this.btnDongCua.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnDongCua.FlatAppearance.BorderSize = 0;
            this.btnDongCua.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongCua.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDongCua.ForeColor              = System.Drawing.Color.FromArgb(180, 210, 240);
            this.btnDongCua.Location               = new System.Drawing.Point(630, 524);
            this.btnDongCua.Name                   = "btnDongCua";
            this.btnDongCua.Size                   = new System.Drawing.Size(150, 40);
            this.btnDongCua.TabIndex               = 10;
            this.btnDongCua.Text                   = "✖ ĐÓNG";
            this.btnDongCua.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 24, 44);
            this.ClientSize          = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLocThang);   this.Controls.Add(this.cboLocThang);
            this.Controls.Add(this.lblLocTrang);   this.Controls.Add(this.cboLocTrang);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.lblTongNo);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.panelChiTiet);
            this.Controls.Add(this.btnDongCua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "HoaDon";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Hóa Đơn";
            this.Load           += new System.EventHandler(this.HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label         lblTitle;
        private System.Windows.Forms.Label         lblLocThang;
        private System.Windows.Forms.ComboBox      cboLocThang;
        private System.Windows.Forms.Label         lblLocTrang;
        private System.Windows.Forms.ComboBox      cboLocTrang;
        private System.Windows.Forms.Button        btnLoc;
        private System.Windows.Forms.Label         lblTongNo;
        private System.Windows.Forms.DataGridView  dgvHoaDon;
        private System.Windows.Forms.Label         lblChiTiet;
        private System.Windows.Forms.Panel         panelChiTiet;
        private System.Windows.Forms.Label         lblThangNam;
        private System.Windows.Forms.Label         lblTienPhong;
        private System.Windows.Forms.Label         lblTienDien;
        private System.Windows.Forms.Label         lblTienNuoc;
        private System.Windows.Forms.Label         lblTienDichVu;
        private System.Windows.Forms.Label         lblTongTien;
        private System.Windows.Forms.Label         lblHanThanhToan;
        private System.Windows.Forms.Label         lblTrangThaiHD;
        private System.Windows.Forms.Button        btnDongCua;
    }
}
