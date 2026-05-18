using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
 
    public partial class GiaHanPhongSinhVien : Form
    {
    
        private string  _maHD          = "";
        private string  _maPhong       = "";
        private decimal _giaThue       = 0;
        private DateTime _ngayHetHan   = DateTime.Today;

        public GiaHanPhongSinhVien()
        {
            InitializeComponent();
            GanSuKien();
            ApDungHieuUng();
        }

        private void GanSuKien()
        {
            this.btnGiaHan.Click  += btnGiaHan_Click;
            this.btnDongCua.Click += (s, e) => this.Close();

            this.btnGiaHan.MouseEnter += (s, e) =>
                btnGiaHan.BackColor = Color.FromArgb(0, 180, 230);
            this.btnGiaHan.MouseLeave += (s, e) =>
                btnGiaHan.BackColor = Color.FromArgb(0, 210, 255);

            this.btnDongCua.MouseEnter += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(60, 80, 120);
            this.btnDongCua.MouseLeave += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(40, 52, 88);

          
            this.dtpNgayGiaHan.ValueChanged += (s, e) => TinhChiPhiGiaHan();
        }

        private void ApDungHieuUng()
        {
            SetRounded(panelGhiChu,  6);
            SetRounded(btnGiaHan,    8);
            SetRounded(btnDongCua,   8);
        }

        private void GiaHanPhong_Load(object sender, EventArgs e)
        {
            TaiThongTinHopDong();
        }

        private void TaiThongTinHopDong()
        {
            string query = @"SELECT hd.MaHD, hd.MaPhong, p.TenPhong,
                                    hd.NgayKetThuc, hd.TrangThai, p.GiaThue
                             FROM HopDong hd
                             JOIN Phong p ON hd.MaPhong = p.MaPhong
                             WHERE hd.MaSV = @maSV AND hd.TrangThai = N'Đang hiệu lực'";

            SqlParameter[] p = { new SqlParameter("@maSV", SessionManager.MaTaiKhoan) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);

            if (dt.Rows.Count == 0)
            {
               
                lblMaHD.Text         = "Mã hợp đồng: Chưa có";
                lblPhongHienTai.Text = "Phòng: Bạn chưa đăng ký phòng nào";
                lblNgayHetHan.Text   = "Ngày kết thúc: ---";
                lblTrangThaiHD.Text  = "Trạng thái: Không có hợp đồng";
                lblTrangThaiHD.ForeColor = Color.FromArgb(255, 120, 80);

                btnGiaHan.Enabled     = false;
                btnGiaHan.BackColor   = Color.FromArgb(60, 60, 60);
                lblGiaUocTinh.Text    = "Vui lòng đăng ký phòng trước.";
                lblGiaUocTinh.ForeColor = Color.FromArgb(255, 120, 80);
                return;
            }

            DataRow row      = dt.Rows[0];
            _maHD            = row["MaHD"].ToString();
            _maPhong         = row["MaPhong"].ToString();
            _giaThue         = Convert.ToDecimal(row["GiaThue"]);
            _ngayHetHan      = Convert.ToDateTime(row["NgayKetThuc"]);

            lblMaHD.Text         = "Mã hợp đồng: " + _maHD;
            lblPhongHienTai.Text = $"Phòng: {_maPhong} – {row["TenPhong"]}";
            lblNgayHetHan.Text   = "Ngày kết thúc: " + _ngayHetHan.ToString("dd/MM/yyyy");
            lblTrangThaiHD.Text  = "Trạng thái: " + row["TrangThai"];

          
            dtpNgayGiaHan.MinDate = _ngayHetHan.AddDays(1);
            dtpNgayGiaHan.Value   = _ngayHetHan.AddMonths(6);

            TinhChiPhiGiaHan();
        }

        private void TinhChiPhiGiaHan()
        {
            if (_giaThue <= 0 || _ngayHetHan == DateTime.MinValue) return;

            DateTime ngayMoi = dtpNgayGiaHan.Value;
            if (ngayMoi <= _ngayHetHan)
            {
                lblGiaUocTinh.Text = "⚠️ Ngày gia hạn phải sau ngày kết thúc hiện tại!";
                lblGiaUocTinh.ForeColor = Color.FromArgb(255, 120, 80);
                return;
            }

            int soThang = ((ngayMoi.Year - _ngayHetHan.Year) * 12)
                        + (ngayMoi.Month - _ngayHetHan.Month);
            if (soThang < 1) soThang = 1;

            decimal tongTien = _giaThue * soThang;
            lblGiaUocTinh.Text      = $"💰 Chi phí gia hạn: {tongTien:N0} ₫  ({soThang} tháng × {_giaThue:N0} ₫)";
            lblGiaUocTinh.ForeColor = Color.FromArgb(0, 255, 128);
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maHD))
            { HienThiLoi("Không tìm thấy hợp đồng hợp lệ!"); return; }

            DateTime ngayMoi = dtpNgayGiaHan.Value;
            if (ngayMoi <= _ngayHetHan)
            { HienThiLoi("Ngày gia hạn phải sau ngày kết thúc hiện tại!"); return; }

            DialogResult confirm = MessageBox.Show(
                $"Xác nhận gia hạn hợp đồng {_maHD}?\n" +
                $"Ngày kết thúc mới: {ngayMoi:dd/MM/yyyy}\n" +
                lblGiaUocTinh.Text,
                "Xác nhận gia hạn",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            btnGiaHan.Enabled = false;
            btnGiaHan.Text    = "Đang xử lý...";

            try
            {
                string query = @"UPDATE HopDong SET
                                    NgayKetThuc = @ngayMoi,
                                    GhiChu = ISNULL(GhiChu,'') + ' | Gia hạn: ' + @ghiChu
                                 WHERE MaHD = @maHD";

                SqlParameter[] p = {
                    new SqlParameter("@ngayMoi", ngayMoi.Date),
                    new SqlParameter("@ghiChu",  txtGhiChu.Text.Trim() == ""
                                                    ? ngayMoi.ToString("dd/MM/yyyy")
                                                    : txtGhiChu.Text.Trim()),
                    new SqlParameter("@maHD",    _maHD)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, p);
                if (rows > 0)
                {
                    MessageBox.Show(
                        $"Gia hạn phòng thành công!\nHợp đồng {_maHD} có hiệu lực đến {ngayMoi:dd/MM/yyyy}.",
                        "✅ Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    HienThiLoi("Gia hạn thất bại! Vui lòng thử lại.");
                }
            }
            finally
            {
                btnGiaHan.Enabled = true;
                btnGiaHan.Text    = "🔄 GIA HẠN";
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
