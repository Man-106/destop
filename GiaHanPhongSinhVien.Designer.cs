namespace DU_AN_DESKTOP_CUOI_KY
{
    partial class GiaHanPhongSinhVien
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
            this.lblHopDongHienTai = new System.Windows.Forms.Label();
            this.panelHopDong      = new System.Windows.Forms.Panel();
            this.lblMaHD           = new System.Windows.Forms.Label();
            this.lblPhongHienTai   = new System.Windows.Forms.Label();
            this.lblNgayHetHan     = new System.Windows.Forms.Label();
            this.lblTrangThaiHD    = new System.Windows.Forms.Label();
            this.lblGiaHanMoi      = new System.Windows.Forms.Label();
            this.lblNgayGiaHan     = new System.Windows.Forms.Label();
            this.dtpNgayGiaHan     = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu         = new System.Windows.Forms.Label();
            this.panelGhiChu       = new System.Windows.Forms.Panel();
            this.txtGhiChu         = new System.Windows.Forms.TextBox();
            this.lblGiaUocTinh     = new System.Windows.Forms.Label();
            this.btnGiaHan         = new System.Windows.Forms.Button();
            this.btnDongCua        = new System.Windows.Forms.Button();
            this.panelHopDong.SuspendLayout();
            this.panelGhiChu.SuspendLayout();
            this.SuspendLayout();

            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblTitle.Location  = new System.Drawing.Point(30, 20);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(440, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "🔄 Gia Hạn Phòng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblHopDongHienTai.AutoSize  = true;
            this.lblHopDongHienTai.BackColor = System.Drawing.Color.Transparent;
            this.lblHopDongHienTai.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblHopDongHienTai.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblHopDongHienTai.Location  = new System.Drawing.Point(30, 78);
            this.lblHopDongHienTai.Name      = "lblHopDongHienTai";
            this.lblHopDongHienTai.TabIndex  = 1;
            this.lblHopDongHienTai.Text      = "HỢP ĐỒNG HIỆN TẠI";

            this.panelHopDong.BackColor = System.Drawing.Color.FromArgb(22, 30, 54);
            this.panelHopDong.Controls.Add(this.lblMaHD);
            this.panelHopDong.Controls.Add(this.lblPhongHienTai);
            this.panelHopDong.Controls.Add(this.lblNgayHetHan);
            this.panelHopDong.Controls.Add(this.lblTrangThaiHD);
            this.panelHopDong.Location  = new System.Drawing.Point(30, 98);
            this.panelHopDong.Name      = "panelHopDong";
            this.panelHopDong.Size      = new System.Drawing.Size(440, 110);
            this.panelHopDong.TabIndex  = 2;

            this.lblMaHD.AutoSize  = true;
            this.lblMaHD.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblMaHD.Location  = new System.Drawing.Point(12, 12);
            this.lblMaHD.Name      = "lblMaHD";
            this.lblMaHD.Text      = "Mã hợp đồng: ---";

            this.lblPhongHienTai.AutoSize  = true;
            this.lblPhongHienTai.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhongHienTai.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblPhongHienTai.Location  = new System.Drawing.Point(12, 36);
            this.lblPhongHienTai.Name      = "lblPhongHienTai";
            this.lblPhongHienTai.Text      = "Phòng: ---";

            this.lblNgayHetHan.AutoSize  = true;
            this.lblNgayHetHan.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayHetHan.ForeColor = System.Drawing.Color.FromArgb(255, 200, 50);
            this.lblNgayHetHan.Location  = new System.Drawing.Point(12, 60);
            this.lblNgayHetHan.Name      = "lblNgayHetHan";
            this.lblNgayHetHan.Text      = "Ngày kết thúc: ---";

            this.lblTrangThaiHD.AutoSize  = true;
            this.lblTrangThaiHD.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiHD.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128);
            this.lblTrangThaiHD.Location  = new System.Drawing.Point(12, 84);
            this.lblTrangThaiHD.Name      = "lblTrangThaiHD";
            this.lblTrangThaiHD.Text      = "Trạng thái: ---";

            this.lblGiaHanMoi.AutoSize  = true;
            this.lblGiaHanMoi.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaHanMoi.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblGiaHanMoi.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblGiaHanMoi.Location  = new System.Drawing.Point(30, 222);
            this.lblGiaHanMoi.Name      = "lblGiaHanMoi";
            this.lblGiaHanMoi.TabIndex  = 3;
            this.lblGiaHanMoi.Text      = "GIA HẠN ĐẾN NGÀY";

            this.lblNgayGiaHan.AutoSize  = true;
            this.lblNgayGiaHan.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayGiaHan.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNgayGiaHan.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblNgayGiaHan.Location  = new System.Drawing.Point(30, 244);
            this.lblNgayGiaHan.Name      = "lblNgayGiaHan";
            this.lblNgayGiaHan.TabIndex  = 4;
            this.lblNgayGiaHan.Text      = "NGÀY KẾT THÚC MỚI";

            this.dtpNgayGiaHan.Font     = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpNgayGiaHan.Format   = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayGiaHan.Location = new System.Drawing.Point(30, 264);
            this.dtpNgayGiaHan.Name     = "dtpNgayGiaHan";
            this.dtpNgayGiaHan.Size     = new System.Drawing.Size(200, 34);
            this.dtpNgayGiaHan.TabIndex = 5;

            this.lblGhiChu.AutoSize  = true;
            this.lblGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.lblGhiChu.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblGhiChu.Location  = new System.Drawing.Point(30, 312);
            this.lblGhiChu.Name      = "lblGhiChu";
            this.lblGhiChu.TabIndex  = 6;
            this.lblGhiChu.Text      = "GHI CHÚ";

            this.panelGhiChu.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.panelGhiChu.Controls.Add(this.txtGhiChu);
            this.panelGhiChu.Location  = new System.Drawing.Point(30, 332);
            this.panelGhiChu.Name      = "panelGhiChu";
            this.panelGhiChu.Size      = new System.Drawing.Size(440, 44);
            this.panelGhiChu.TabIndex  = 7;

            this.txtGhiChu.BackColor  = System.Drawing.Color.FromArgb(28, 36, 64);
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGhiChu.Font        = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGhiChu.ForeColor   = System.Drawing.Color.FromArgb(180, 210, 240);
            this.txtGhiChu.Location    = new System.Drawing.Point(10, 9);
            this.txtGhiChu.Name        = "txtGhiChu";
            this.txtGhiChu.Size        = new System.Drawing.Size(420, 25);
            this.txtGhiChu.TabIndex    = 0;

            this.lblGiaUocTinh.AutoSize  = true;
            this.lblGiaUocTinh.BackColor = System.Drawing.Color.Transparent;
            this.lblGiaUocTinh.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiaUocTinh.ForeColor = System.Drawing.Color.FromArgb(0, 255, 128);
            this.lblGiaUocTinh.Location  = new System.Drawing.Point(30, 390);
            this.lblGiaUocTinh.Name      = "lblGiaUocTinh";
            this.lblGiaUocTinh.TabIndex  = 8;
            this.lblGiaUocTinh.Text      = "💰 Chi phí gia hạn: ---";

            this.btnGiaHan.BackColor              = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnGiaHan.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnGiaHan.FlatAppearance.BorderSize = 0;
            this.btnGiaHan.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaHan.Font                   = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnGiaHan.ForeColor              = System.Drawing.Color.FromArgb(10, 14, 26);
            this.btnGiaHan.Location               = new System.Drawing.Point(30, 430);
            this.btnGiaHan.Name                   = "btnGiaHan";
            this.btnGiaHan.Size                   = new System.Drawing.Size(200, 46);
            this.btnGiaHan.TabIndex               = 9;
            this.btnGiaHan.Text                   = "🔄 GIA HẠN";
            this.btnGiaHan.UseVisualStyleBackColor = false;

            this.btnDongCua.BackColor              = System.Drawing.Color.FromArgb(40, 52, 88);
            this.btnDongCua.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnDongCua.FlatAppearance.BorderSize = 0;
            this.btnDongCua.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongCua.Font                   = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDongCua.ForeColor              = System.Drawing.Color.FromArgb(180, 210, 240);
            this.btnDongCua.Location               = new System.Drawing.Point(250, 430);
            this.btnDongCua.Name                   = "btnDongCua";
            this.btnDongCua.Size                   = new System.Drawing.Size(220, 46);
            this.btnDongCua.TabIndex               = 10;
            this.btnDongCua.Text                   = "✖ ĐÓNG";
            this.btnDongCua.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 24, 44);
            this.ClientSize          = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHopDongHienTai);
            this.Controls.Add(this.panelHopDong);
            this.Controls.Add(this.lblGiaHanMoi);
            this.Controls.Add(this.lblNgayGiaHan);
            this.Controls.Add(this.dtpNgayGiaHan);
            this.Controls.Add(this.lblGhiChu);     this.Controls.Add(this.panelGhiChu);
            this.Controls.Add(this.lblGiaUocTinh);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnDongCua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "GiaHanPhong";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Gia Hạn Phòng";
            this.Load           += new System.EventHandler(this.GiaHanPhong_Load);
            this.panelHopDong.ResumeLayout(false);
            this.panelHopDong.PerformLayout();
            this.panelGhiChu.ResumeLayout(false);
            this.panelGhiChu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label           lblTitle;
        private System.Windows.Forms.Label           lblHopDongHienTai;
        private System.Windows.Forms.Panel           panelHopDong;
        private System.Windows.Forms.Label           lblMaHD;
        private System.Windows.Forms.Label           lblPhongHienTai;
        private System.Windows.Forms.Label           lblNgayHetHan;
        private System.Windows.Forms.Label           lblTrangThaiHD;
        private System.Windows.Forms.Label           lblGiaHanMoi;
        private System.Windows.Forms.Label           lblNgayGiaHan;
        private System.Windows.Forms.DateTimePicker  dtpNgayGiaHan;
        private System.Windows.Forms.Label           lblGhiChu;
        private System.Windows.Forms.Panel           panelGhiChu;
        private System.Windows.Forms.TextBox         txtGhiChu;
        private System.Windows.Forms.Label           lblGiaUocTinh;
        private System.Windows.Forms.Button          btnGiaHan;
        private System.Windows.Forms.Button          btnDongCua;
    }
}
