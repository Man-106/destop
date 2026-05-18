namespace DU_AN_DESKTOP_CUOI_KY
{
    partial class ViPhamSinhVien
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
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblLocTrang     = new System.Windows.Forms.Label();
            this.cboLocTrang     = new System.Windows.Forms.ComboBox();
            this.btnLoc          = new System.Windows.Forms.Button();
            this.lblTongPhat     = new System.Windows.Forms.Label();
            this.dgvViPham       = new System.Windows.Forms.DataGridView();
            this.lblChiTiet      = new System.Windows.Forms.Label();
            this.panelChiTiet    = new System.Windows.Forms.Panel();
            this.lblMaVP         = new System.Windows.Forms.Label();
            this.lblLoaiViPham   = new System.Windows.Forms.Label();
            this.lblMoTa         = new System.Windows.Forms.Label();
            this.lblNgayViPham   = new System.Windows.Forms.Label();
            this.lblMucPhat      = new System.Windows.Forms.Label();
            this.lblNgayXuLy     = new System.Windows.Forms.Label();
            this.lblTrangThaiVP  = new System.Windows.Forms.Label();
            this.lblGhiChuVP     = new System.Windows.Forms.Label();
            this.btnDongCua      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).BeginInit();
            this.panelChiTiet.SuspendLayout();
            this.SuspendLayout();

            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblTitle.Location  = new System.Drawing.Point(20, 16);
            this.lblTitle.Name      = "lblTitle";
            this.lblTitle.Size      = new System.Drawing.Size(760, 44);
            this.lblTitle.TabIndex  = 0;
            this.lblTitle.Text      = "⚠️ Vi Phạm Nội Quy";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblLocTrang.AutoSize  = true;
            this.lblLocTrang.BackColor = System.Drawing.Color.Transparent;
            this.lblLocTrang.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLocTrang.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblLocTrang.Location  = new System.Drawing.Point(20, 72);
            this.lblLocTrang.Name      = "lblLocTrang";
            this.lblLocTrang.TabIndex  = 1;
            this.lblLocTrang.Text      = "LỌC TRẠNG THÁI";

            this.cboLocTrang.BackColor     = System.Drawing.Color.FromArgb(28, 36, 64);
            this.cboLocTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrang.FlatStyle     = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocTrang.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocTrang.ForeColor     = System.Drawing.Color.FromArgb(180, 210, 240);
            this.cboLocTrang.Items.AddRange(new object[] {
                "Tất cả", "Chưa xử lý", "Đã xử lý", "Đã nộp phạt" });
            this.cboLocTrang.Location      = new System.Drawing.Point(20, 92);
            this.cboLocTrang.Name          = "cboLocTrang";
            this.cboLocTrang.Size          = new System.Drawing.Size(200, 30);
            this.cboLocTrang.TabIndex      = 2;

            this.btnLoc.BackColor              = System.Drawing.Color.FromArgb(0, 210, 255);
            this.btnLoc.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor              = System.Drawing.Color.FromArgb(10, 14, 26);
            this.btnLoc.Location               = new System.Drawing.Point(238, 89);
            this.btnLoc.Name                   = "btnLoc";
            this.btnLoc.Size                   = new System.Drawing.Size(110, 34);
            this.btnLoc.TabIndex               = 3;
            this.btnLoc.Text                   = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;

            this.lblTongPhat.AutoSize  = true;
            this.lblTongPhat.BackColor = System.Drawing.Color.Transparent;
            this.lblTongPhat.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongPhat.ForeColor = System.Drawing.Color.FromArgb(255, 120, 80);
            this.lblTongPhat.Location  = new System.Drawing.Point(500, 92);
            this.lblTongPhat.Name      = "lblTongPhat";
            this.lblTongPhat.TabIndex  = 4;
            this.lblTongPhat.Text      = "Tổng tiền phạt còn lại: ---";

            this.dgvViPham.AllowUserToAddRows          = false;
            this.dgvViPham.AllowUserToDeleteRows       = false;
            this.dgvViPham.BackgroundColor             = System.Drawing.Color.FromArgb(18, 24, 44);
            this.dgvViPham.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvViPham.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(28, 36, 64);
            this.dgvViPham.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.dgvViPham.ColumnHeadersDefaultCellStyle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvViPham.ColumnHeadersHeight         = 36;
            this.dgvViPham.DefaultCellStyle.BackColor  = System.Drawing.Color.FromArgb(22, 30, 54);
            this.dgvViPham.DefaultCellStyle.ForeColor  = System.Drawing.Color.FromArgb(180, 210, 240);
            this.dgvViPham.DefaultCellStyle.Font       = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvViPham.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 160);
            this.dgvViPham.GridColor                   = System.Drawing.Color.FromArgb(40, 52, 88);
            this.dgvViPham.Location                    = new System.Drawing.Point(20, 136);
            this.dgvViPham.MultiSelect                 = false;
            this.dgvViPham.Name                        = "dgvViPham";
            this.dgvViPham.ReadOnly                    = true;
            this.dgvViPham.RowHeadersVisible           = false;
            this.dgvViPham.RowTemplate.Height          = 30;
            this.dgvViPham.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvViPham.Size                        = new System.Drawing.Size(760, 240);
            this.dgvViPham.TabIndex                    = 5;

            this.lblChiTiet.AutoSize  = true;
            this.lblChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.lblChiTiet.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblChiTiet.ForeColor = System.Drawing.Color.FromArgb(0, 210, 255);
            this.lblChiTiet.Location  = new System.Drawing.Point(20, 388);
            this.lblChiTiet.Name      = "lblChiTiet";
            this.lblChiTiet.TabIndex  = 6;
            this.lblChiTiet.Text      = "CHI TIẾT VI PHẠM ĐƯỢC CHỌN";

            this.panelChiTiet.BackColor = System.Drawing.Color.FromArgb(22, 30, 54);
            this.panelChiTiet.Controls.Add(this.lblMaVP);
            this.panelChiTiet.Controls.Add(this.lblLoaiViPham);
            this.panelChiTiet.Controls.Add(this.lblMoTa);
            this.panelChiTiet.Controls.Add(this.lblNgayViPham);
            this.panelChiTiet.Controls.Add(this.lblMucPhat);
            this.panelChiTiet.Controls.Add(this.lblNgayXuLy);
            this.panelChiTiet.Controls.Add(this.lblTrangThaiVP);
            this.panelChiTiet.Controls.Add(this.lblGhiChuVP);
            this.panelChiTiet.Location  = new System.Drawing.Point(20, 408);
            this.panelChiTiet.Name      = "panelChiTiet";
            this.panelChiTiet.Size      = new System.Drawing.Size(760, 110);
            this.panelChiTiet.TabIndex  = 7;

            this.lblMaVP.AutoSize  = true;
            this.lblMaVP.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMaVP.ForeColor = System.Drawing.Color.FromArgb(220, 233, 255);
            this.lblMaVP.Location  = new System.Drawing.Point(12, 10);
            this.lblMaVP.Name      = "lblMaVP";
            this.lblMaVP.Text      = "Mã vi phạm: ---";

            this.lblLoaiViPham.AutoSize  = true;
            this.lblLoaiViPham.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLoaiViPham.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblLoaiViPham.Location  = new System.Drawing.Point(12, 32);
            this.lblLoaiViPham.Name      = "lblLoaiViPham";
            this.lblLoaiViPham.Text      = "Loại vi phạm: ---";

            this.lblMoTa.AutoSize  = true;
            this.lblMoTa.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblMoTa.Location  = new System.Drawing.Point(12, 54);
            this.lblMoTa.Name      = "lblMoTa";
            this.lblMoTa.Text      = "Mô tả: ---";

            this.lblNgayViPham.AutoSize  = true;
            this.lblNgayViPham.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayViPham.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblNgayViPham.Location  = new System.Drawing.Point(12, 76);
            this.lblNgayViPham.Name      = "lblNgayViPham";
            this.lblNgayViPham.Text      = "Ngày vi phạm: ---";

            this.lblMucPhat.AutoSize  = true;
            this.lblMucPhat.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMucPhat.ForeColor = System.Drawing.Color.FromArgb(255, 120, 80);
            this.lblMucPhat.Location  = new System.Drawing.Point(420, 10);
            this.lblMucPhat.Name      = "lblMucPhat";
            this.lblMucPhat.Text      = "Mức phạt: ---";

            this.lblTrangThaiVP.AutoSize  = true;
            this.lblTrangThaiVP.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiVP.ForeColor = System.Drawing.Color.FromArgb(255, 200, 50);
            this.lblTrangThaiVP.Location  = new System.Drawing.Point(420, 32);
            this.lblTrangThaiVP.Name      = "lblTrangThaiVP";
            this.lblTrangThaiVP.Text      = "Trạng thái: ---";

            this.lblNgayXuLy.AutoSize  = true;
            this.lblNgayXuLy.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgayXuLy.ForeColor = System.Drawing.Color.FromArgb(180, 210, 240);
            this.lblNgayXuLy.Location  = new System.Drawing.Point(420, 54);
            this.lblNgayXuLy.Name      = "lblNgayXuLy";
            this.lblNgayXuLy.Text      = "Ngày xử lý: ---";

            this.lblGhiChuVP.AutoSize  = true;
            this.lblGhiChuVP.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChuVP.ForeColor = System.Drawing.Color.FromArgb(120, 150, 190);
            this.lblGhiChuVP.Location  = new System.Drawing.Point(420, 76);
            this.lblGhiChuVP.Name      = "lblGhiChuVP";
            this.lblGhiChuVP.Text      = "Ghi chú: ---";

            this.btnDongCua.BackColor              = System.Drawing.Color.FromArgb(40, 52, 88);
            this.btnDongCua.Cursor                 = System.Windows.Forms.Cursors.Hand;
            this.btnDongCua.FlatAppearance.BorderSize = 0;
            this.btnDongCua.FlatStyle              = System.Windows.Forms.FlatStyle.Flat;
            this.btnDongCua.Font                   = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDongCua.ForeColor              = System.Drawing.Color.FromArgb(180, 210, 240);
            this.btnDongCua.Location               = new System.Drawing.Point(630, 534);
            this.btnDongCua.Name                   = "btnDongCua";
            this.btnDongCua.Size                   = new System.Drawing.Size(150, 40);
            this.btnDongCua.TabIndex               = 8;
            this.btnDongCua.Text                   = "✖ ĐÓNG";
            this.btnDongCua.UseVisualStyleBackColor = false;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.FromArgb(18, 24, 44);
            this.ClientSize          = new System.Drawing.Size(800, 588);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLocTrang);  this.Controls.Add(this.cboLocTrang);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.lblTongPhat);
            this.Controls.Add(this.dgvViPham);
            this.Controls.Add(this.lblChiTiet);
            this.Controls.Add(this.panelChiTiet);
            this.Controls.Add(this.btnDongCua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox     = false;
            this.Name            = "ViPham";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Vi Phạm Nội Quy";
            this.Load           += new System.EventHandler(this.ViPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViPham)).EndInit();
            this.panelChiTiet.ResumeLayout(false);
            this.panelChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label         lblTitle;
        private System.Windows.Forms.Label         lblLocTrang;
        private System.Windows.Forms.ComboBox      cboLocTrang;
        private System.Windows.Forms.Button        btnLoc;
        private System.Windows.Forms.Label         lblTongPhat;
        private System.Windows.Forms.DataGridView  dgvViPham;
        private System.Windows.Forms.Label         lblChiTiet;
        private System.Windows.Forms.Panel         panelChiTiet;
        private System.Windows.Forms.Label         lblMaVP;
        private System.Windows.Forms.Label         lblLoaiViPham;
        private System.Windows.Forms.Label         lblMoTa;
        private System.Windows.Forms.Label         lblNgayViPham;
        private System.Windows.Forms.Label         lblMucPhat;
        private System.Windows.Forms.Label         lblNgayXuLy;
        private System.Windows.Forms.Label         lblTrangThaiVP;
        private System.Windows.Forms.Label         lblGhiChuVP;
        private System.Windows.Forms.Button        btnDongCua;
    }
}
