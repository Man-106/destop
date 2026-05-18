using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    
    public partial class ThongTinPhongSinhVien : Form
    {
        public ThongTinPhongSinhVien()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            this.btnTimKiem.Click += btnTimKiem_Click;
            this.btnDongCua.Click += (s, e) => this.Close();

            this.btnTimKiem.MouseEnter += (s, e) =>
                btnTimKiem.BackColor = Color.FromArgb(0, 180, 230);
            this.btnTimKiem.MouseLeave += (s, e) =>
                btnTimKiem.BackColor = Color.FromArgb(0, 210, 255);

            this.btnDongCua.MouseEnter += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(60, 80, 120);
            this.btnDongCua.MouseLeave += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(40, 52, 88);

            this.dgvDanhSach.SelectionChanged += dgvDanhSach_SelectionChanged;
        }

        private void ThongTinPhong_Load(object sender, EventArgs e)
        {
            cboLocLoai.SelectedIndex  = 0;
            cboLocTrang.SelectedIndex = 0;
            TaiDanhSachPhong();
            ThietLapCotBang();
        }

        private void ThietLapCotBang()
        {
        }
        private void TaiDanhSachPhong()
        {
            string loai  = cboLocLoai.SelectedItem?.ToString();
            string trang = cboLocTrang.SelectedItem?.ToString();

            string query = @"SELECT MaPhong       AS [Mã phòng],
                                    TenPhong      AS [Tên phòng],
                                    LoaiPhong     AS [Loại phòng],
                                    Tang          AS [Tầng],
                                    SoNguoiToiDa  AS [Sức chứa],
                                    SoNguoiHienTai AS [Đang ở],
                                    FORMAT(GiaThue, 'N0') + ' ₫' AS [Giá thuê/tháng],
                                    TrangThai     AS [Trạng thái]
                             FROM Phong
                             WHERE 1=1";

            string dieuKienLoai  = (loai  != null && loai  != "Tất cả") ? " AND LoaiPhong = @loai"  : "";
            string dieuKienTrang = (trang != null && trang != "Tất cả") ? " AND TrangThai = @trang" : "";
            query += dieuKienLoai + dieuKienTrang + " ORDER BY Tang, MaPhong";

            SqlParameter[] p = null;
            if (dieuKienLoai != "" && dieuKienTrang != "")
            {
                p = new SqlParameter[] {
                    new SqlParameter("@loai",  loai),
                    new SqlParameter("@trang", trang)
                };
            }
            else if (dieuKienLoai != "")
            {
                p = new SqlParameter[] { new SqlParameter("@loai", loai) };
            }
            else if (dieuKienTrang != "")
            {
                p = new SqlParameter[] { new SqlParameter("@trang", trang) };
            }

            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            dgvDanhSach.DataSource = dt;

            TomauTrangThai();
        }

        private void TomauTrangThai()
        {
            foreach (DataGridViewRow row in dgvDanhSach.Rows)
            {
                string trangThai = row.Cells["Trạng thái"]?.Value?.ToString() ?? "";
                if (trangThai == "Còn chỗ")
                    row.Cells["Trạng thái"].Style.ForeColor = Color.FromArgb(0, 255, 128);
                else if (trangThai == "Đầy")
                    row.Cells["Trạng thái"].Style.ForeColor = Color.FromArgb(255, 120, 80);
                else
                    row.Cells["Trạng thái"].Style.ForeColor = Color.FromArgb(255, 200, 50);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDanhSachPhong();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            DataGridViewRow row = dgvDanhSach.SelectedRows[0];

            string maPhong = row.Cells["Mã phòng"]?.Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maPhong)) return;

            string query = "SELECT MoTa FROM Phong WHERE MaPhong = @maPhong";
            SqlParameter[] p = { new SqlParameter("@maPhong", maPhong) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            string moTa = (dt.Rows.Count > 0) ? dt.Rows[0]["MoTa"]?.ToString() : "---";

            lblTenPhong.Text  = "Tên phòng: " + (row.Cells["Tên phòng"]?.Value ?? "---");
            lblLoaiPhong.Text = "Loại: "       + (row.Cells["Loại phòng"]?.Value ?? "---");
            lblSoNguoi.Text   = "Số người: "   + (row.Cells["Đang ở"]?.Value ?? "0")
                                               + "/" + (row.Cells["Sức chứa"]?.Value ?? "0");
            lblGiaThue.Text   = "Giá thuê: "   + (row.Cells["Giá thuê/tháng"]?.Value ?? "---");
            lblTrangThai.Text = "Trạng thái: " + (row.Cells["Trạng thái"]?.Value ?? "---");
            lblMoTa.Text      = "Mô tả: "      + (string.IsNullOrEmpty(moTa) ? "Không có" : moTa);

            string trangThai = row.Cells["Trạng thái"]?.Value?.ToString() ?? "";
            if (trangThai == "Còn chỗ")
                lblTrangThai.ForeColor = Color.FromArgb(0, 255, 128);
            else if (trangThai == "Đầy")
                lblTrangThai.ForeColor = Color.FromArgb(255, 120, 80);
            else
                lblTrangThai.ForeColor = Color.FromArgb(255, 200, 50);
        }
    }
}
