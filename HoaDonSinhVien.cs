using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    
    public partial class HoaDonSinhVien : Form
    {
        public HoaDonSinhVien()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            this.btnLoc.Click    += btnLoc_Click;
            this.btnDongCua.Click += (s, e) => this.Close();

            this.btnLoc.MouseEnter += (s, e) =>
                btnLoc.BackColor = Color.FromArgb(0, 180, 230);
            this.btnLoc.MouseLeave += (s, e) =>
                btnLoc.BackColor = Color.FromArgb(0, 210, 255);

            this.btnDongCua.MouseEnter += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(60, 80, 120);
            this.btnDongCua.MouseLeave += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(40, 52, 88);

            this.dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            NapDanhSachThang();
            cboLocTrang.SelectedIndex = 0; 
            TaiDanhSachHoaDon();
            TinhTongNo();
        }

       
        private void NapDanhSachThang()
        {
            cboLocThang.Items.Clear();
            cboLocThang.Items.Add("Tất cả");
            DateTime thang = DateTime.Today;
            for (int i = 0; i < 12; i++)
            {
                cboLocThang.Items.Add(thang.ToString("yyyy-MM"));
                thang = thang.AddMonths(-1);
            }
            cboLocThang.SelectedIndex = 0;
        }

        private void TaiDanhSachHoaDon()
        {
            string thang = cboLocThang.SelectedItem?.ToString();
            string trang = cboLocTrang.SelectedItem?.ToString();

            string dkThang = (thang != null && thang != "Tất cả") ? " AND h.ThangNam = @thang" : "";
            string dkTrang = (trang != null && trang != "Tất cả") ? " AND h.TrangThai = @trang" : "";

            string query = @"SELECT h.MaHD_HoaDon        AS [Mã hóa đơn],
                                    h.ThangNam            AS [Tháng/Năm],
                                    p.TenPhong            AS [Phòng],
                                    FORMAT(h.TienPhong,'N0') + ' ₫'  AS [Tiền phòng],
                                    FORMAT(h.TongTien, 'N0') + ' ₫'  AS [Tổng tiền],
                                    FORMAT(h.HanThanhToan,'dd/MM/yyyy') AS [Hạn TT],
                                    h.TrangThai           AS [Trạng thái]
                             FROM HoaDon h
                             JOIN Phong p ON h.MaPhong = p.MaPhong
                             WHERE h.MaSV = @maSV"
                            + dkThang + dkTrang
                            + " ORDER BY h.ThangNam DESC";

            SqlParameter[] p;
            if (dkThang != "" && dkTrang != "")
                p = new SqlParameter[] {
                    new SqlParameter("@maSV",  SessionManager.MaTaiKhoan),
                    new SqlParameter("@thang", thang),
                    new SqlParameter("@trang", trang) };
            else if (dkThang != "")
                p = new SqlParameter[] {
                    new SqlParameter("@maSV",  SessionManager.MaTaiKhoan),
                    new SqlParameter("@thang", thang) };
            else if (dkTrang != "")
                p = new SqlParameter[] {
                    new SqlParameter("@maSV",  SessionManager.MaTaiKhoan),
                    new SqlParameter("@trang", trang) };
            else
                p = new SqlParameter[] { new SqlParameter("@maSV", SessionManager.MaTaiKhoan) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            dgvHoaDon.DataSource = dt;
            TomauTrangThai();
        }

        private void TomauTrangThai()
        {
            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                string tt = row.Cells["Trạng thái"]?.Value?.ToString() ?? "";
                Color mau;
                if (tt == "Đã thanh toán")
                    mau = Color.FromArgb(0, 255, 128);
                else if (tt == "Quá hạn")
                    mau = Color.FromArgb(255, 80, 80);
                else
                    mau = Color.FromArgb(255, 200, 50); 

                row.Cells["Trạng thái"].Style.ForeColor = mau;
            }
        }

        private void TinhTongNo()
        {
            string query = @"SELECT ISNULL(SUM(TongTien),0)
                             FROM HoaDon
                             WHERE MaSV = @maSV
                             AND TrangThai IN (N'Chưa thanh toán', N'Quá hạn')";
            SqlParameter[] p = { new SqlParameter("@maSV", SessionManager.MaTaiKhoan) };
            object val = DatabaseHelper.ExecuteScalar(query, p);
            decimal tongNo = (val != null) ? Convert.ToDecimal(val) : 0;

            lblTongNo.Text      = $"Tổng còn nợ: {tongNo:N0} ₫";
            lblTongNo.ForeColor = (tongNo > 0)
                ? Color.FromArgb(255, 120, 80)
                : Color.FromArgb(0, 255, 128);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            TaiDanhSachHoaDon();
            TinhTongNo();
        }

        private void dgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0) return;
            DataGridViewRow row = dgvHoaDon.SelectedRows[0];

            string maHoaDon = row.Cells["Mã hóa đơn"]?.Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maHoaDon)) return;

            string query = @"SELECT TienPhong, TienDien, TienNuoc, TienDichVu,
                                    TongTien, ThangNam, HanThanhToan, TrangThai
                             FROM HoaDon WHERE MaHD_HoaDon = @maHD";
            SqlParameter[] p = { new SqlParameter("@maHD", maHoaDon) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            if (dt.Rows.Count == 0) return;

            DataRow dr = dt.Rows[0];
            lblThangNam.Text     = "Tháng/Năm: "       + dr["ThangNam"];
            lblTienPhong.Text    = "Tiền phòng: "      + $"{Convert.ToDecimal(dr["TienPhong"]):N0} ₫";
            lblTienDien.Text     = "Tiền điện: "       + $"{Convert.ToDecimal(dr["TienDien"]):N0} ₫";
            lblTienNuoc.Text     = "Tiền nước: "       + $"{Convert.ToDecimal(dr["TienNuoc"]):N0} ₫";
            lblTienDichVu.Text   = "Tiền dịch vụ: "   + $"{Convert.ToDecimal(dr["TienDichVu"]):N0} ₫";
            lblTongTien.Text     = "Tổng tiền: "       + $"{Convert.ToDecimal(dr["TongTien"]):N0} ₫";
            lblHanThanhToan.Text = "Hạn thanh toán: "  + Convert.ToDateTime(dr["HanThanhToan"]).ToString("dd/MM/yyyy");
            lblTrangThaiHD.Text  = "Trạng thái: "      + dr["TrangThai"];

            string tt = dr["TrangThai"].ToString();
            lblTrangThaiHD.ForeColor = (tt == "Đã thanh toán")
                ? Color.FromArgb(0, 255, 128)
                : (tt == "Quá hạn" ? Color.FromArgb(255, 80, 80) : Color.FromArgb(255, 200, 50));
        }
    }
}
