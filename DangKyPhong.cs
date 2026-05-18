using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
   
    public partial class DangKyPhong : Form
    {
        
        private string _maPhongChon  = "";
        private decimal _giaThuePhong = 0;

        public DangKyPhong()
        {
            InitializeComponent();
            GanSuKien();
            ApDungHieuUng();
        }

        private void GanSuKien()
        {
            this.btnLoc.Click    += btnLoc_Click;
            this.btnDangKy.Click += btnDangKy_Click;
            this.btnHuy.Click    += (s, e) => this.Close();

            this.btnDangKy.MouseEnter += (s, e) =>
                btnDangKy.BackColor = Color.FromArgb(0, 180, 230);
            this.btnDangKy.MouseLeave += (s, e) =>
                btnDangKy.BackColor = Color.FromArgb(0, 210, 255);

            this.btnHuy.MouseEnter += (s, e) =>
                btnHuy.BackColor = Color.FromArgb(60, 80, 120);
            this.btnHuy.MouseLeave += (s, e) =>
                btnHuy.BackColor = Color.FromArgb(40, 52, 88);

        
            this.dgvPhongTrong.SelectionChanged += dgvPhongTrong_SelectionChanged;

            
            this.dtpNgayBatDau.ValueChanged  += (s, e) => TinhGiaUocTinh();
            this.dtpNgayKetThuc.ValueChanged += (s, e) => TinhGiaUocTinh();
        }

        private void ApDungHieuUng()
        {
            SetRounded(panelPhongChon, 6);
            SetRounded(panelGhiChu,   6);
            SetRounded(btnDangKy,     8);
            SetRounded(btnHuy,        8);
            SetRounded(btnLoc,        6);
        }

    
        private void DangKyPhong_Load(object sender, EventArgs e)
        {
            
            dtpNgayBatDau.Value  = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddMonths(6);

            cboLocLoai.SelectedIndex = 0;
            TaiDanhSachPhongTrong();

           
            KiemTraHopDongHienTai();
        }

        private void KiemTraHopDongHienTai()
        {
            string query = @"SELECT COUNT(1) FROM HopDong
                             WHERE MaSV = @maSV AND TrangThai = N'Đang hiệu lực'";
            SqlParameter[] p = { new SqlParameter("@maSV", SessionManager.MaTaiKhoan) };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, p));

            if (count > 0)
            {
             
                btnDangKy.Enabled = false;
                btnDangKy.Text    = "⚠️ BẠN ĐÃ CÓ PHÒNG";
                btnDangKy.BackColor = Color.FromArgb(80, 60, 60);
                lblGiaUocTinh.Text = "⚠️ Bạn đang có hợp đồng phòng. Vui lòng gia hạn hoặc liên hệ quản lý.";
                lblGiaUocTinh.ForeColor = Color.FromArgb(255, 120, 80);
            }
        }

      
        private void TaiDanhSachPhongTrong()
        {
            string loai = cboLocLoai.SelectedItem?.ToString();

            string dieuKienLoai = (loai != null && loai != "Tất cả")
                ? " AND LoaiPhong = @loai" : "";

            string query = @"SELECT MaPhong             AS [Mã phòng],
                                    TenPhong            AS [Tên phòng],
                                    LoaiPhong           AS [Loại phòng],
                                    Tang                AS [Tầng],
                                    SoNguoiToiDa        AS [Sức chứa],
                                    SoNguoiHienTai      AS [Đang ở],
                                    FORMAT(GiaThue,'N0') + ' ₫' AS [Giá/tháng]
                             FROM Phong
                             WHERE TrangThai = N'Còn chỗ'"
                            + dieuKienLoai + " ORDER BY Tang, MaPhong";

            SqlParameter[] p = (dieuKienLoai != "")
                ? new SqlParameter[] { new SqlParameter("@loai", loai) }
                : null;

            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);
            dgvPhongTrong.DataSource = dt;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            TaiDanhSachPhongTrong();
        }

        
        private void dgvPhongTrong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhongTrong.SelectedRows.Count == 0) return;
            DataGridViewRow row = dgvPhongTrong.SelectedRows[0];

            _maPhongChon = row.Cells["Mã phòng"]?.Value?.ToString() ?? "";
            string tenPhong = row.Cells["Tên phòng"]?.Value?.ToString() ?? "";
            txtPhongChon.Text = $"{_maPhongChon} – {tenPhong}";

            
            string query = "SELECT GiaThue FROM Phong WHERE MaPhong = @maPhong";
            SqlParameter[] p = { new SqlParameter("@maPhong", _maPhongChon) };
            object val = DatabaseHelper.ExecuteScalar(query, p);
            _giaThuePhong = (val != null) ? Convert.ToDecimal(val) : 0;

            TinhGiaUocTinh();
        }

    
        private void TinhGiaUocTinh()
        {
            if (_giaThuePhong <= 0 || dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            {
                lblGiaUocTinh.Text = "💰 Giá ước tính: ---";
                return;
            }

            
            int soThang = ((dtpNgayKetThuc.Value.Year  - dtpNgayBatDau.Value.Year) * 12)
                        + (dtpNgayKetThuc.Value.Month - dtpNgayBatDau.Value.Month);
            if (soThang < 1) soThang = 1;

            decimal tongTien = _giaThuePhong * soThang;
            lblGiaUocTinh.Text =
                $"💰 Giá ước tính: {tongTien:N0} ₫  ({soThang} tháng × {_giaThuePhong:N0} ₫)";
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(_maPhongChon))
            { HienThiLoi("Vui lòng chọn phòng từ danh sách!"); return; }

            
            if (dtpNgayKetThuc.Value <= dtpNgayBatDau.Value)
            { HienThiLoi("Ngày kết thúc phải sau ngày bắt đầu!"); return; }

            if (dtpNgayBatDau.Value < DateTime.Today)
            { HienThiLoi("Ngày bắt đầu không được ở quá khứ!"); return; }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận đăng ký phòng {_maPhongChon}?\n" +
                $"Từ: {dtpNgayBatDau.Value:dd/MM/yyyy}  đến: {dtpNgayKetThuc.Value:dd/MM/yyyy}\n" +
                lblGiaUocTinh.Text,
                "Xác nhận đăng ký",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnDangKy.Enabled = false;
            btnDangKy.Text    = "Đang xử lý...";

            try
            {
               
                string maHD = "HD" + DateTime.Now.ToString("yyMMddHHmm");

                string queryNV = "SELECT TOP 1 MaNV FROM NhanVien WHERE TrangThai = 1";
                object maNVObj = DatabaseHelper.ExecuteScalar(queryNV);
                if (maNVObj == null)
                {
                    HienThiLoi("Chưa có nhân viên trong hệ thống!\nVui lòng liên hệ quản lý.");
                    return;
                }
                string maNV = maNVObj.ToString();

                string query = @"INSERT INTO HopDong
                                    (MaHD, MaSV, MaPhong, MaNV,
                                     NgayBatDau, NgayKetThuc, TienCoc, GhiChu, TrangThai)
                                 VALUES
                                    (@maHD, @maSV, @maPhong, @maNV,
                                     @ngayBD, @ngayKT, 0, @ghiChu, N'Đang hiệu lực')";

                SqlParameter[] p = {
                    new SqlParameter("@maHD",    maHD),
                    new SqlParameter("@maSV",    SessionManager.MaTaiKhoan),
                    new SqlParameter("@maPhong", _maPhongChon),
                    new SqlParameter("@maNV",    maNV),
                    new SqlParameter("@ngayBD",  dtpNgayBatDau.Value.Date),
                    new SqlParameter("@ngayKT",  dtpNgayKetThuc.Value.Date),
                    new SqlParameter("@ghiChu",  txtGhiChu.Text.Trim())
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, p);

                if (rows > 0)
                {
                    
                    string updatePhong = @"UPDATE Phong SET
                                            SoNguoiHienTai = SoNguoiHienTai + 1,
                                            TrangThai = CASE
                                                WHEN SoNguoiHienTai + 1 >= SoNguoiToiDa THEN N'Đầy'
                                                ELSE N'Còn chỗ' END
                                           WHERE MaPhong = @maPhong";
                    SqlParameter[] pUpdate = { new SqlParameter("@maPhong", _maPhongChon) };
                    DatabaseHelper.ExecuteNonQuery(updatePhong, pUpdate);

                    MessageBox.Show(
                        $"Đăng ký phòng thành công!\nMã hợp đồng: {maHD}",
                        "✅ Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    HienThiLoi("Đăng ký thất bại! Vui lòng thử lại.");
                }
            }
            finally
            {
                btnDangKy.Enabled = true;
                btnDangKy.Text    = "✅ ĐĂNG KÝ PHÒNG";
            }
        }

        
        private void HienThiLoi(string thongBao)
        {
            MessageBox.Show(thongBao, "⚠️ Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SetRounded(Control ctrl, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(ctrl.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(ctrl.Width - radius * 2, ctrl.Height - radius * 2,
                        radius * 2, radius * 2, 0, 90);
            path.AddArc(0, ctrl.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }
    }
}
