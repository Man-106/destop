namespace DU_AN_DESKTOP_CUOI_KY
{
    partial class DangKyPhong
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
            this.lblTitle          = new System.Windows.Forms.Label();
            this.lblDanhSach       = new System.Windows.Forms.Label();
            this.lblLocLoai        = new System.Windows.Forms.Label();
            this.cboLocLoai        = new System.Windows.Forms.ComboBox();
            this.btnLoc            = new System.Windows.Forms.Button();
            this.dgvPhongTrong     = new System.Windows.Forms.DataGridView();
            this.lblThongTinDK     = new System.Windows.Forms.Label();
            this.lblPhongChon      = new System.Windows.Forms.Label();
            this.panelPhongChon    = new System.Windows.Forms.Panel();
            this.txtPhongChon      = new System.Windows.Forms.TextBox();
            this.lblNgayBatDau     = new System.Windows.Forms.Label();
            this.dtpNgayBatDau     = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKetThuc    = new System.Windows.Forms.Label();
            this.dtpNgayKetThuc    = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu         = new System.Windows.Forms.Label();
            this.panelGhiChu       = new System.Windows.Forms.Panel();
            this.txtGhiChu         = new System.Windows.Forms.TextBox();
            this.lblGiaUocTinh     = new System.Windows.Forms.Label();
            this.btnDangKy         = new System.Windows.Forms.Button();
            this.btnHuy            = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongTrong)).BeginInit();
            this.panelPhongChon.SuspendLayout();
            this.panelGhiChu.SuspendLayout();
            this.SuspendLayout();

            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblTitle.Location  = new System.Drawing.Point(20, 16);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(560, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "🏠 Đăng Ký Phòng Ký Túc Xá";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblDanhSach.AutoSize  = true;
            this.lblDanhSach.BackColor = System.Drawing.Color.Transparent;
            this.lblDanhSach.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblDanhSach.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblDanhSach.Location  = new System.Drawing.Point(20, 72);
            this.lblDanhSach.Name      = "lblDanhSach";
            this.lblDanhSach.TabIndex  = 1;
            this.lblDanhSach.Text      = "DANH SÁCH PHÒNG CÒNTX CHỖ";

            this.lblLocLoai.AutoSize  = true;
            this.lblLocLoai.BackColor = System.Drawing.Color.Transparent;
            this.lblLocLoai.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLocLoai.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblLocLoai.Location  = new System.Drawing.Point(20, 94);
            this.lblLocLoai.Name      = "lblLocLoai";
            this.lblLocLoai.TabIndex  = 2;
            this.lblLocLoai.Text      = "LỌC THEO LOẠI PHÒNG";

            this.cboLocLoai.BackColor     = System.Drawing.Color.FromArgb(28, 36, 64);
            this.cboLocLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoai.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocLoai.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocLoai.ForeColor     = System.Drawing.Color.FromArgb(180, 210, 240);
            this.cboLocLoai.Items.AddRange(new object[] { "Tất cả", "4 người", "6 người", "8 người" });
            this.cboLocLoai.Location      = new System.Drawing.Point(20, 114);
            this.cboLocLoai.Name          = "cboLocLoai";
            this.cboLocLoai.Size          = new System.Drawing.Size(200, 30);
            this.cboLocLoai.TabIndex      = 3;

            this.btnLoc.BackColor              = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnLoc.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor              = System.Drawing.Color.FromArgb(10, 14, 26);
            this.btnLoc.Location               = new System.Drawing.Point(234, 111);
            this.btnLoc.Name                   = "btnLoc";
            this.btnLoc.Size                   = new System.Drawing.Size(100, 34);
            this.btnLoc.TabIndex               = 4;
            this.btnLoc.Text                   = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;

            this.dgvPhongTrong.AllowUserToAddRows          = false;
            this.dgvPhongTrong.AllowUserToDeleteRows       = false;
            this.dgvPhongTrong.BackgroundColor             = System.Drawing.Color.FromArgb(18, 24, 44);
            this.dgvPhongTrong.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvPhongTrong.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.dgvPhongTrong.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.dgvPhongTrong.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPhongTrong.ColumnHeadersHeight         = 36;
            this.dgvPhongTrong.DefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(22, 30, 54);
            this.dgvPhongTrong.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(180, 210, 240);
            this.dgvPhongTrong.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvPhongTrong.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 160);
            this.dgvPhongTrong.GridColor                   = System.Drawing.Color.FromArgb(40, 52, 88);
            this.dgvPhongTrong.Location                    = new System.Drawing.Point(20, 158);
            this.dgvPhongTrong.MultiSelect                 = false;
            this.dgvPhongTrong.Name                        = "dgvPhongTrong";
            this.dgvPhongTrong.ReadOnly                    = true;
            this.dgvPhongTrong.RowHeadersVisible           = false;
            this.dgvPhongTrong.RowTemplate.Height          = 30;
            this.dgvPhongTrong.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongTrong.Size                        = new System.Drawing.Size(560, 200);
            this.dgvPhongTrong.TabIndex                    = 5;

            this.lblThongTinDK.AutoSize  = true;
            this.lblThongTinDK.BackColor = System.Drawing.Color.Transparent;
            this.lblThongTinDK.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblThongTinDK.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblThongTinDK.Location  = new System.Drawing.Point(20, 370);
            this.lblThongTinDK.Name      = "lblThongTinDK";
            this.lblThongTinDK.TabIndex  = 6;
            this.lblThongTinDK.Text      = "THÔNG TIN ĐĂNG KÝ";

            this.lblPhongChon.AutoSize  = true;
            this.lblPhongChon.BackColor = System.Drawing.Color.Transparent;
            this.lblPhongChon.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPhongChon.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblPhongChon.Location  = new System.Drawing.Point(20, 394);
            this.lblPhongChon.Name      = "lblPhongChon";
            this.lblPhongChon.TabIndex  = 7;
            this.lblPhongChon.Text      = "PHÒNG CHỌN";

            this.panelPhongChon.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.panelPhongChon.Controls.Add(this.txtPhongChon);
            this.panelPhongChon.Location  = new System.Drawing.Point(20, 414);
            this.panelPhongChon.Name      = "panelPhongChon";
            this.panelPhongChon.Size      = new System.Drawing.Size(250, 44);
            this.panelPhongChon.TabIndex  = 8;

            this.txtPhongChon.BackColor   = System.Drawing.Color.FromArgb(28, 36, 64);
            this.txtPhongChon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhongChon.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPhongChon.ForeColor   = System.Drawing.Color.FromArgb(0, 210, 255);
            this.txtPhongChon.Location    = new System.Drawing.Point(10, 9);
            this.txtPhongChon.Name        = "txtPhongChon";
            this.txtPhongChon.ReadOnly    = true;
            this.txtPhongChon.Size        = new System.Drawing.Size(230, 25);
            this.txtPhongChon.TabIndex    = 0;
            this.txtPhongChon.Text        = "(Chọn phòng ở bảng trên)";

            this.lblNgayBatDau.AutoSize  = true;
            this.lblNgayBatDau.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayBatDau.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNgayBatDau.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblNgayBatDau.Location  = new System.Drawing.Point(290, 394);
            this.lblNgayBatDau.Name      = "lblNgayBatDau";
            this.lblNgayBatDau.TabIndex  = 9;
            this.lblNgayBatDau.Text      = "NGÀY BẮT ĐẦU";

            this.dtpNgayBatDau.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayBatDau.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(290, 414);
            this.dtpNgayBatDau.Name     = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size     = new System.Drawing.Size(130, 31);
            this.dtpNgayBatDau.TabIndex = 10;

            this.lblNgayKetThuc.AutoSize  = true;
            this.lblNgayKetThuc.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayKetThuc.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNgayKetThuc.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblNgayKetThuc.Location  = new System.Drawing.Point(438, 394);
            this.lblNgayKetThuc.Name      = "lblNgayKetThuc";
            this.lblNgayKetThuc.TabIndex  = 11;
            this.lblNgayKetThuc.Text      = "NGÀY KẾT THÚC";

            this.dtpNgayKetThuc.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgayKetThuc.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(438, 414);
            this.dtpNgayKetThuc.Name     = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.Size     = new System.Drawing.Size(142, 31);
            this.dtpNgayKetThuc.TabIndex = 12;

            this.lblGhiChu.AutoSize  = true;
            this.lblGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.lblGhiChu.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblGhiChu.Location  = new System.Drawing.Point(20, 472);
            this.lblGhiChu.Name      = "lblGhiChu";
            this.lblGhiChu.TabIndex  = 13;
            this.lblGhiChu.Text      = "GHI CHÚ (tuỳ chọn)";

            this.panelGhiChu.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.panelGhiChu.Controls.Add(this.txtGhiChu);
            this.panelGhiChu.Location  = new System.Drawing.Point(20, 492);
            this.panelGhiChu.Name      = "panelGhiChu";
            this.panelGhiChu.Size      = new System.Drawing.Size(560, 44);
            this.panelGhiChu.TabIndex  = 14;

            this.txtGhiChu.BackColor  = System.Drawing.Color.FromArgb(28, 36, 64);
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGhiChu.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGhiChu.ForeColor   = System.Drawing.Color.FromArgb(180, 210, 240);
            this.txtGhiChu.Location    = new System.Drawing.Point(10, 9);
            this.txtGhiChu.Name        = "txtGhiChu";
            this.txtGhiChu.Size        = new System.Drawing.Size(540, 25);
            this.txtGhiChu.TabIndex    = 0;

            this.lblGiaUocTinh.AutoSize  = true;
            this.lblGiaUocTinh.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaUocTinh.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiaUocTinh.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128);
            this.lblGiaUocTinh.Location  = new System.Drawing.Point(20, 550);
            this.lblGiaUocTinh.Name      = "lblGiaUocTinh";
            this.lblGiaUocTinh.TabIndex  = 15;
            this.lblGiaUocTinh.Text      = "💰 Giá ước tính: ---";

            this.btnDangKy.BackColor              = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnDangKy.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font                   = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangKy.ForeColor              = System.Drawing.Color.FromArgb(10, 14, 26);
            this.btnDangKy.Location               = new System.Drawing.Point(20, 590);
            this.btnDangKy.Name                   = "btnDangKy";
            this.btnDangKy.Size                   = new System.Drawing.Size(260, 46);
            this.btnDangKy.TabIndex               = 16;
            this.btnDangKy.Text                   = "✅ ĐĂNG KÝ PHÒNG";
            this.btnDangKy.UseVisualStyleBackColor = false;

            this.btnHuy.BackColor              = System.Drawing.Color.FromArgb(40, 52, 88);
            this.btnHuy.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font                   = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHuy.ForeColor              = System.Drawing.Color.FromArgb(180, 210, 240);
            this.btnHuy.Location               = new System.Drawing.Point(300, 590);
            this.btnHuy.Name                   = "btnHuy";
            this.btnHuy.Size                   = new System.Drawing.Size(280, 46);
            this.btnHuy.TabIndex               = 17;
            this.btnHuy.Text                   = "✖ HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 24, 44);
            this.ClientSize          = new System.Drawing.Size(600, 654);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDanhSach);
            this.Controls.Add(this.lblLocLoai);    this.Controls.Add(this.cboLocLoai);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.dgvPhongTrong);
            this.Controls.Add(this.lblThongTinDK);
            this.Controls.Add(this.lblPhongChon);  this.Controls.Add(this.panelPhongChon);
            this.Controls.Add(this.lblNgayBatDau); this.Controls.Add(this.dtpNgayBatDau);
            this.Controls.Add(this.lblNgayKetThuc); this.Controls.Add(this.dtpNgayKetThuc);
            this.Controls.Add(this.lblGhiChu);     this.Controls.Add(this.panelGhiChu);
            this.Controls.Add(this.lblGiaUocTinh);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnHuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "DangKyPhong";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Đăng Ký Phòng";
            this.Load           += new System.EventHandler(this.DangKyPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongTrong)).EndInit();
            this.panelPhongChon.ResumeLayout(false); this.panelPhongChon.PerformLayout();
            this.panelGhiChu.ResumeLayout(false);    this.panelGhiChu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Label           lblDanhSach;
        private System.Windows.Forms.Label           lblLocLoai;
        private System.Windows.Forms.ComboBox        cboLocLoai;
        private System.Windows.Forms.Button          btnLoc;
        private System.Windows.Forms.DataGridView    dgvPhongTrong;
        private System.Windows.Forms.Label           lblThongTinDK;
        private System.Windows.Forms.Label           lblPhongChon;
        private System.Windows.Forms.Panel           panelPhongChon;
        private System.Windows.Forms.TextBox         txtPhongChon;
        private System.Windows.Forms.Label           lblNgayBatDau;
        private System.Windows.Forms.DateTimePicker  dtpNgayBatDau;
        private System.Windows.Forms.Label           lblNgayKetThuc;
        private System.Windows.Forms.DateTimePicker  dtpNgayKetThuc;
        private System.Windows.Forms.Label           lblGhiChu;
        private System.Windows.Forms.Panel           panelGhiChu;
        private System.Windows.Forms.TextBox         txtGhiChu;
        private System.Windows.Forms.Label           lblGiaUocTinh;
        private System.Windows.Forms.Button          btnDangKy;
        private System.Windows.Forms.Button          btnHuy;
    }
}
