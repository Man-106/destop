namespace DU_AN_DESKTOP_CUOI_KY
{
    partial class ThongTinPhongSinhVien
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
            this.lblTitle      = new System.Windows.Forms.Label();
            this.lblLocLoai    = new System.Windows.Forms.Label();
            this.cboLocLoai    = new System.Windows.Forms.ComboBox();
            this.lblLocTrang   = new System.Windows.Forms.Label();
            this.cboLocTrang   = new System.Windows.Forms.ComboBox();
            this.btnTimKiem    = new System.Windows.Forms.Button();
            this.dgvDanhSach   = new System.Windows.Forms.DataGridView();
            this.lblChiTiet    = new System.Windows.Forms.Label();
            this.panelChiTiet  = new System.Windows.Forms.Panel();
            this.lblTenPhong   = new System.Windows.Forms.Label();
            this.lblLoaiPhong  = new System.Windows.Forms.Label();
            this.lblSoNguoi    = new System.Windows.Forms.Label();
            this.lblGiaThue    = new System.Windows.Forms.Label();
            this.lblMoTa       = new System.Windows.Forms.Label();
            this.lblTrangThai  = new System.Windows.Forms.Label();
            this.btnDongCua    = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.panelChiTiet.SuspendLayout();
            this.SuspendLayout();

            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblTitle.Location  = new System.Drawing.Point(20, 16);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(860, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "🏠 Thông Tin Phòng Ký Túc Xá";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblLocLoai.AutoSize  = true;
            this.lblLocLoai.BackColor = System.Drawing.Color.Transparent;
            this.lblLocLoai.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLocLoai.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblLocLoai.Location  = new System.Drawing.Point(20, 74);
            this.lblLocLoai.Name      = "lblLocLoai";
            this.lblLocLoai.TabIndex  = 1;
            this.lblLocLoai.Text      = "LOẠI PHÒNG";

            this.cboLocLoai.BackColor     = System.Drawing.Color.FromArgb(28, 36, 64);
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocLoai.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocLoai.ForeColor     = System.Drawing.Color.FromArgb(180, 210, 240);
            this.cboLocLoai.Items.AddRange(new object[] { "Tất cả", "4 người", "6 người", "8 người" });
            this.cboLocLoai.Location      = new System.Drawing.Point(20, 94);
            this.cboLocLoai.Name          = "cboLocLoai";
            this.cboLocLoai.Size          = new System.Drawing.Size(180, 30);
            this.cboLocLoai.TabIndex      = 2;

            this.lblLocTrang.AutoSize  = true;
            this.lblLocTrang.BackColor = System.Drawing.Color.Transparent;
            this.lblLocTrang.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLocTrang.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblLocTrang.Location  = new System.Drawing.Point(220, 74);
            this.lblLocTrang.Name      = "lblLocTrang";
            this.lblLocTrang.TabIndex  = 3;
            this.lblLocTrang.Text      = "TRẠNG THÁI";

            this.cboLocTrang.BackColor     = System.Drawing.Color.FromArgb(28, 36, 64);
            this.cboLocTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrang.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocTrang.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTrang.ForeColor     = System.Drawing.Color.FromArgb(180, 210, 240);
            this.cboLocTrang.Items.AddRange(new object[] { "Tất cả", "Còn chỗ", "Đầy", "Đang sửa chữa" });
            this.cboLocTrang.Location      = new System.Drawing.Point(220, 94);
            this.cboLocTrang.Name          = "cboLocTrang";
            this.cboLocTrang.Size          = new System.Drawing.Size(180, 30);
            this.cboLocTrang.TabIndex      = 4;

            this.btnTimKiem.BackColor              = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnTimKiem.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor              = System.Drawing.Color.FromArgb(10, 14, 26);
            this.btnTimKiem.Location               = new System.Drawing.Point(420, 91);
            this.btnTimKiem.Name                   = "btnTimKiem";
            this.btnTimKiem.Size                   = new System.Drawing.Size(130, 34);
            this.btnTimKiem.TabIndex               = 5;
            this.btnTimKiem.Text                   = "🔍 Lọc";
            this.btnTimKiem.UseVisualStyleBackColor = false;

            this.dgvDanhSach.AllowUserToAddRows          = false;
            this.dgvDanhSach.AllowUserToDeleteRows       = false;
            this.dgvDanhSach.BackgroundColor             = System.Drawing.Color.FromArgb(18, 24, 44);
            this.dgvDanhSach.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvDanhSach.ColumnHeadersHeight         = 36;
            this.dgvDanhSach.DefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(22, 30, 54);
            this.dgvDanhSach.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(180, 210, 240);
            this.dgvDanhSach.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDanhSach.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 160);
            this.dgvDanhSach.GridColor                   = System.Drawing.Color.FromArgb(40, 52, 88);
            this.dgvDanhSach.Location                    = new System.Drawing.Point(20, 140);
            this.dgvDanhSach.MultiSelect                 = false;
            this.dgvDanhSach.Name                        = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly                    = true;
            this.dgvDanhSach.RowHeadersVisible           = false;
            this.dgvDanhSach.RowTemplate.Height          = 32;
            this.dgvDanhSach.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size                        = new System.Drawing.Size(860, 280);
            this.dgvDanhSach.TabIndex                    = 6;

            this.panelChiTiet.BackColor = System.Drawing.Color.FromArgb(22, 30, 54);
            this.panelChiTiet.Location  = new System.Drawing.Point(20, 434);
            this.panelChiTiet.Name      = "panelChiTiet";
            this.panelChiTiet.Size      = new System.Drawing.Size(860, 90);
            this.panelChiTiet.TabIndex  = 7;
            this.panelChiTiet.Controls.Add(this.lblTenPhong);
            this.panelChiTiet.Controls.Add(this.lblLoaiPhong);
            this.panelChiTiet.Controls.Add(this.lblSoNguoi);
            this.panelChiTiet.Controls.Add(this.lblGiaThue);
            this.panelChiTiet.Controls.Add(this.lblMoTa);
            this.panelChiTiet.Controls.Add(this.lblTrangThai);

            this.lblChiTiet.AutoSize  = true;
            this.lblChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.lblChiTiet.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblChiTiet.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblChiTiet.Location  = new System.Drawing.Point(20, 416);
            this.lblChiTiet.Name      = "lblChiTiet";
            this.lblChiTiet.TabIndex  = 8;
            this.lblChiTiet.Text      = "CHI TIẾT PHÒNG ĐƯỢC CHỌN";

            this.lblTenPhong.AutoSize  = true;
            this.lblTenPhong.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTenPhong.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblTenPhong.Location  = new System.Drawing.Point(10, 10);
            this.lblTenPhong.Name      = "lblTenPhong";
            this.lblTenPhong.Text      = "Tên phòng: ---";

            this.lblLoaiPhong.AutoSize  = true;
            this.lblLoaiPhong.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoaiPhong.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblLoaiPhong.Location  = new System.Drawing.Point(10, 34);
            this.lblLoaiPhong.Name      = "lblLoaiPhong";
            this.lblLoaiPhong.Text      = "Loại: ---";

            this.lblSoNguoi.AutoSize  = true;
            this.lblSoNguoi.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoNguoi.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblSoNguoi.Location  = new System.Drawing.Point(10, 58);
            this.lblSoNguoi.Name      = "lblSoNguoi";
            this.lblSoNguoi.Text      = "Số người: ---/---";

            this.lblGiaThue.AutoSize  = true;
            this.lblGiaThue.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGiaThue.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblGiaThue.Location  = new System.Drawing.Point(300, 10);
            this.lblGiaThue.Name      = "lblGiaThue";
            this.lblGiaThue.Text      = "Giá thuê: ---";

            this.lblTrangThai.AutoSize  = true;
            this.lblTrangThai.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128);
            this.lblTrangThai.Location  = new System.Drawing.Point(300, 34);
            this.lblTrangThai.Name      = "lblTrangThai";
            this.lblTrangThai.Text      = "Trạng thái: ---";

            this.lblMoTa.AutoSize  = true;
            this.lblMoTa.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(120, 150, 190);
            this.lblMoTa.Location  = new System.Drawing.Point(300, 58);
            this.lblMoTa.Name      = "lblMoTa";
            this.lblMoTa.Text      = "Mô tả: ---";

            this.btnDongCua.BackColor              = System.Drawing.Color.FromArgb(40, 52, 88);
            this.btnDongCua.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnDongCua.FlatAppearance.BorderSize = 0;
            this.btnDongCua.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongCua.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDongCua.ForeColor              = System.Drawing.Color.FromArgb(180, 210, 240);
            this.btnDongCua.Location               = new System.Drawing.Point(730, 540);
            this.btnDongCua.Name                   = "btnDongCua";
            this.btnDongCua.Size                   = new System.Drawing.Size(150, 40);
            this.btnDongCua.TabIndex               = 9;
            this.btnDongCua.Text                   = "✖ ĐÓNG";
            this.btnDongCua.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 24, 44);
            this.ClientSize          = new System.Drawing.Size(900, 596);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLocLoai);    this.Controls.Add(this.cboLocLoai);
            this.Controls.Add(this.lblLocTrang);   this.Controls.Add(this.cboLocTrang);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.panelChiTiet);
            this.Controls.Add(this.btnDongCua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "ThongTinPhong";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Thông Tin Phòng";
            this.Load           += new System.EventHandler(this.ThongTinPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label            lblTitle;
        private System.Windows.Forms.Label            lblLocLoai;
        private System.Windows.Forms.ComboBox         cboLocLoai;
        private System.Windows.Forms.Label            lblLocTrang;
        private System.Windows.Forms.ComboBox         cboLocTrang;
        private System.Windows.Forms.Button           btnTimKiem;
        private System.Windows.Forms.DataGridView     dgvDanhSach;
        private System.Windows.Forms.Label            lblChiTiet;
        private System.Windows.Forms.Panel            panelChiTiet;
        private System.Windows.Forms.Label            lblTenPhong;
        private System.Windows.Forms.Label            lblLoaiPhong;
        private System.Windows.Forms.Label            lblSoNguoi;
        private System.Windows.Forms.Label            lblGiaThue;
        private System.Windows.Forms.Label            lblMoTa;
        private System.Windows.Forms.Label            lblTrangThai;
        private System.Windows.Forms.Button           btnDongCua;
    }
}
