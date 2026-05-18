using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public partial class ViPhamSinhVien : Form
    {
        public ViPhamSinhVien()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            this.btnLoc.Click     += btnLoc_Click;
            this.btnDongCua.Click += (s, e) => this.Close();

            this.btnLoc.MouseEnter += (s, e) =>
                btnLoc.BackColor = Color.FromArgb(0, 180, 230);
            this.btnLoc.MouseLeave += (s, e) =>
                btnLoc.BackColor = Color.FromArgb(0, 210, 255);

            this.btnDongCua.MouseEnter += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(60, 80, 120);
            this.btnDongCua.MouseLeave += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(40, 52, 88);

            this.dgvViPham.SelectionChanged += dgvViPham_SelectionChanged;
        }

        private void ViPham_Load(object sender, EventArgs e)
        {
            cboLocTrang.SelectedIndex = 0;
            TaiDanhSachViPham();
            TinhTongPhatConLai();
        }

        private void TaiDanhSachViPham()
        {
            string trang    = cboLocTrang.SelectedItem?.ToString();
            string dkTrang  = (trang != null && trang != "Tất cả") ? " AND vp.TrangThai = @trang" : "";

            string query = @"SELECT vp.MaVP            AS [Mã VP],
                                    vp.LoaiViPham      AS [Loại vi phạm],
                                    vp.NgayViPham      AS [Ngày VP],
                                    FORMAT(vp.MucPhat,'N0') + ' ₫' AS [Mức phạt],
                                    vp.TrangThai       AS [Trạng thái],
                                    nv.HoTen           AS [NV ghi nhận]
                             FROM ViPham vp
                             JOIN NhanVien nv ON vp.MaNV = nv.MaNV
                             WHERE vp.MaSV = @maSV"
                            + dkTrang
                            + " ORDER BY vp.NgayViPham DESC";

            SqlParameter[] p = (dkTrang != "")
                ? new SqlParameter[] {
                    new SqlParameter("@maSV",  SessionManager.MaTaiKhoan),
                    new SqlParameter("@trang", trang) }
                : new SqlParameter[] {
                    new SqlParameter("@maSV",  SessionManager.MaTaiKhoan) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            dgvViPham.DataSource = dt;
            TomauTrangThai();
        }

        private void TomauTrangThai()
        {
            foreach (DataGridViewRow row in dgvViPham.Rows)
            {
                string tt = row.Cells["Trạng thái"]?.Value?.ToString() ?? "";
                Color mau;
                if (tt == "Đã nộp phạt")
                    mau = Color.FromArgb(0, 255, 128);
                else if (tt == "Chưa xử lý")
                    mau = Color.FromArgb(255, 80, 80);
                else
                    mau = Color.FromArgb(255, 200, 50);

                row.Cells["Trạng thái"].Style.ForeColor = mau;
            }
        }

        private void TinhTongPhatConLai()
        {
            string query = @"SELECT ISNULL(SUM(MucPhat),0)
                             FROM ViPham
                             WHERE MaSV = @maSV
                             AND TrangThai IN (N'Chưa xử lý', N'Đã xử lý')";
            SqlParameter[] p = { new SqlParameter("@maSV", SessionManager.MaTaiKhoan) };
            object val = DatabaseHelper.ExecuteScalar(query, p);
            decimal tongPhat = (val != null) ? Convert.ToDecimal(val) : 0;

            lblTongPhat.Text      = $"Tổng tiền phạt còn lại: {tongPhat:N0} ₫";
            lblTongPhat.ForeColor = (tongPhat > 0)
                ? Color.FromArgb(255, 120, 80)
                : Color.FromArgb(0, 255, 128);
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            TaiDanhSachViPham();
            TinhTongPhatConLai();
        }

        private void dgvViPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvViPham.SelectedRows.Count == 0) return;
            DataGridViewRow row = dgvViPham.SelectedRows[0];

            string maVP = row.Cells["Mã VP"]?.Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maVP)) return;

            string query = @"SELECT vp.MaVP, vp.LoaiViPham, vp.MoTa,
                                    vp.NgayViPham, vp.MucPhat, vp.TrangThai,
                                    vp.NgayXuLy, vp.GhiChu
                             FROM ViPham vp
                             WHERE vp.MaVP = @maVP";
            SqlParameter[] p = { new SqlParameter("@maVP", maVP) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            if (dt.Rows.Count == 0) return;

            DataRow dr = dt.Rows[0];
            lblMaVP.Text       = "Mã vi phạm: "  + dr["MaVP"];
            lblLoaiViPham.Text = "Loại vi phạm: " + dr["LoaiViPham"];
            lblMoTa.Text       = "Mô tả: "        + dr["MoTa"];
            lblNgayViPham.Text = "Ngày vi phạm: " + Convert.ToDateTime(dr["NgayViPham"]).ToString("dd/MM/yyyy");
            lblMucPhat.Text    = "Mức phạt: "     + $"{Convert.ToDecimal(dr["MucPhat"]):N0} ₫";
            lblTrangThaiVP.Text = "Trạng thái: "  + dr["TrangThai"];

            object ngayXL = dr["NgayXuLy"];
            lblNgayXuLy.Text = "Ngày xử lý: " + (ngayXL == DBNull.Value ? "Chưa xử lý" : Convert.ToDateTime(ngayXL).ToString("dd/MM/yyyy"));

            object ghiChu = dr["GhiChu"];
            lblGhiChuVP.Text = "Ghi chú: " + (ghiChu == DBNull.Value || string.IsNullOrEmpty(ghiChu.ToString()) ? "Không có" : ghiChu.ToString());

            string tt = dr["TrangThai"].ToString();
            lblTrangThaiVP.ForeColor = (tt == "Đã nộp phạt")
                ? Color.FromArgb(0, 255, 128)
                : (tt == "Chưa xử lý" ? Color.FromArgb(255, 80, 80) : Color.FromArgb(255, 200, 50));
        }
    }
}
