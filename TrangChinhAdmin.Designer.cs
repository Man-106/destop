namespace DU_AN_DESKTOP_CUOI_KY
{
    partial class TrangChinhAdmin
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
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnQuanLySinhVienAdmin = new System.Windows.Forms.Button();
            this.btnQuanLyPhongAdmin= new System.Windows.Forms.Button();
            this.btnQuanLyHopDongAdmin = new System.Windows.Forms.Button();
            this.btnQuanLyHoaDonAdmin = new System.Windows.Forms.Button();
            this.btnQuanLyViPhamAdmin = new System.Windows.Forms.Button();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblChaoMung.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChaoMung.Location = new System.Drawing.Point(20, 15);
            this.lblChaoMung.Size = new System.Drawing.Size(760, 35);
            this.lblChaoMung.Text = "🏠 Hệ thống Quản lý Ký túc xá";
            this.lblChaoMung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


            this.btnQuanLySinhVienAdmin.Location = new System.Drawing.Point(30, 80);
            this.btnQuanLySinhVienAdmin.Size = new System.Drawing.Size(200, 60);
            this.btnQuanLySinhVienAdmin.Text = "👤 Quản lý Sinh viên";
            this.btnQuanLySinhVienAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLySinhVienAdmin.Click += new System.EventHandler(this.btnQuanLySinhVien_Click);

     
            this.btnQuanLyPhongAdmin.Location = new System.Drawing.Point(260, 80);
            this.btnQuanLyPhongAdmin.Size = new System.Drawing.Size(200, 60);
            this.btnQuanLyPhongAdmin.Text = "🚪 Quản lý Phòng";
            this.btnQuanLyPhongAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyPhongAdmin.Click += new System.EventHandler(this.btnQuanLyPhong_Click);

          
            this.btnQuanLyHopDongAdmin.Location = new System.Drawing.Point(490, 80);
            this.btnQuanLyHopDongAdmin.Size = new System.Drawing.Size(200, 60);
            this.btnQuanLyHopDongAdmin.Text = "📄 Quản lý Hợp đồng";
            this.btnQuanLyHopDongAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyHopDongAdmin.Click += new System.EventHandler(this.btnQuanLyHopDong_Click);

         
            this.btnQuanLyHoaDonAdmin.Location = new System.Drawing.Point(30, 170);
            this.btnQuanLyHoaDonAdmin.Size = new System.Drawing.Size(200, 60);
            this.btnQuanLyHoaDonAdmin.Text = "💰 Quản lý Hóa đơn";
            this.btnQuanLyHoaDonAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyHoaDonAdmin.Click += new System.EventHandler(this.btnQuanLyHoaDon_Click);

          
            this.btnQuanLyViPhamAdmin.Location = new System.Drawing.Point(260, 170);
            this.btnQuanLyViPhamAdmin.Size = new System.Drawing.Size(200, 60);
            this.btnQuanLyViPhamAdmin.Text = "⚠️ Quản lý Vi phạm";
            this.btnQuanLyViPhamAdmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnQuanLyViPhamAdmin.Click += new System.EventHandler(this.btnQuanLyViPham_Click);


            this.btnDangXuat.Location = new System.Drawing.Point(620, 390);
            this.btnDangXuat.Size = new System.Drawing.Size(150, 40);
            this.btnDangXuat.Text = "🚪 Đăng xuất";
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblChaoMung);
            this.Controls.Add(this.btnQuanLySinhVienAdmin);
            this.Controls.Add(this.btnQuanLyPhongAdmin);
            this.Controls.Add(this.btnQuanLyHopDongAdmin);
            this.Controls.Add(this.btnQuanLyHoaDonAdmin);
            this.Controls.Add(this.btnQuanLyViPhamAdmin);
            this.Controls.Add(this.btnDangXuat);
            this.Name = "TrangChinhAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Ký Túc Xá - Admin";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnQuanLySinhVienAdmin;
        private System.Windows.Forms.Button btnQuanLyPhongAdmin;
        private System.Windows.Forms.Button btnQuanLyHopDongAdmin;
        private System.Windows.Forms.Button btnQuanLyHoaDonAdmin;
        private System.Windows.Forms.Button btnQuanLyViPhamAdmin;
        private System.Windows.Forms.Label lblChaoMung;
    }
}