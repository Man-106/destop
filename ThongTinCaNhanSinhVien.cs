using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
 
    public partial class ThongTinCaNhanSinhVien : Form
    {
        public ThongTinCaNhanSinhVien()
        {
            InitializeComponent();
            GanSuKien();
            ApDungHieuUng();
        }

        private void GanSuKien()
        {
            this.btnLuuThongTin.Click += btnLuuThongTin_Click;
            this.btnDongCua.Click     += (s, e) => this.Close();

            this.btnLuuThongTin.MouseEnter += (s, e) =>
                btnLuuThongTin.BackColor = Color.FromArgb(0, 180, 230);
            this.btnLuuThongTin.MouseLeave += (s, e) =>
                btnLuuThongTin.BackColor = Color.FromArgb(0, 210, 255);

            this.btnDongCua.MouseEnter += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(60, 80, 120);
            this.btnDongCua.MouseLeave += (s, e) =>
                btnDongCua.BackColor = Color.FromArgb(40, 52, 88);

            HieuUngFocus(txtHoTen,  panelHoTen);
            HieuUngFocus(txtCCCD,   panelCCCD);
            HieuUngFocus(txtSDT,    panelSDT);
            HieuUngFocus(txtEmail,  panelEmail);
            HieuUngFocus(txtDiaChi, panelDiaChi);
            HieuUngFocus(txtLop,    panelLop);
            HieuUngFocus(txtKhoa,   panelKhoa);
        }

        private void HieuUngFocus(TextBox txt, Panel panel)
        {
            txt.Enter += (s, e) => panel.BackColor = Color.FromArgb(35, 48, 82);
            txt.Leave += (s, e) => panel.BackColor = Color.FromArgb(28, 36, 64);
        }

        private void ApDungHieuUng()
        {
            SetRounded(panelMaSV,   6);
            SetRounded(panelHoTen,  6);
            SetRounded(panelCCCD,   6);
            SetRounded(panelSDT,    6);
            SetRounded(panelEmail,  6);
            SetRounded(panelDiaChi, 6);
            SetRounded(panelLop,    6);
            SetRounded(panelKhoa,   6);
            SetRounded(btnLuuThongTin, 8);
            SetRounded(btnDongCua,     8);
        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            TaiThongTinSinhVien();
        }

        private void TaiThongTinSinhVien()
        {
            string maSV = SessionManager.MaTaiKhoan;
            string query = @"SELECT MaSV, HoTen, GioiTinh, NgaySinh, CCCD,
                                    SoDienThoai, Email, DiaChi, Lop, Khoa
                             FROM SinhVien
                             WHERE MaSV = @maSV";

            SqlParameter[] p = { new SqlParameter("@maSV", maSV) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, p);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            DataRow row = dt.Rows[0];
            txtMaSV.Text       = row["MaSV"].ToString();
            txtHoTen.Text      = row["HoTen"].ToString();
            cboGioiTinh.Text   = row["GioiTinh"].ToString();
            dtpNgaySinh.Value  = Convert.ToDateTime(row["NgaySinh"]);
            txtCCCD.Text       = row["CCCD"].ToString();
            txtSDT.Text        = row["SoDienThoai"].ToString();
            txtEmail.Text      = row["Email"].ToString();
            txtDiaChi.Text     = row["DiaChi"].ToString();
            txtLop.Text        = row["Lop"].ToString();
            txtKhoa.Text       = row["Khoa"].ToString();
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            string hoTen  = txtHoTen.Text.Trim();
            string cccd   = txtCCCD.Text.Trim();
            string sdt    = txtSDT.Text.Trim();
            string email  = txtEmail.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string lop    = txtLop.Text.Trim();
            string khoa   = txtKhoa.Text.Trim();

            // Validate
            if (string.IsNullOrEmpty(hoTen))
            { HienThiLoi("Vui lòng nhập họ tên!"); txtHoTen.Focus(); return; }

            if (string.IsNullOrEmpty(cccd) || cccd.Length != 12 || !long.TryParse(cccd, out _))
            { HienThiLoi("Số CCCD phải đúng 12 chữ số!"); txtCCCD.Focus(); return; }

            if (string.IsNullOrEmpty(sdt) || !Regex.IsMatch(sdt, @"^0\d{9}$"))
            { HienThiLoi("Số điện thoại không hợp lệ!\nPhải có 10 số, bắt đầu bằng 0."); txtSDT.Focus(); return; }

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { HienThiLoi("Email không hợp lệ!"); txtEmail.Focus(); return; }

            if (string.IsNullOrEmpty(diaChi))
            { HienThiLoi("Vui lòng nhập địa chỉ!"); txtDiaChi.Focus(); return; }

            if (string.IsNullOrEmpty(lop))
            { HienThiLoi("Vui lòng nhập lớp!"); txtLop.Focus(); return; }

            if (string.IsNullOrEmpty(khoa))
            { HienThiLoi("Vui lòng nhập khoa!"); txtKhoa.Focus(); return; }

            btnLuuThongTin.Enabled = false;
            btnLuuThongTin.Text    = "Đang lưu...";

            try
            {
                string query = @"UPDATE SinhVien SET
                                    HoTen       = @hoTen,
                                    GioiTinh    = @gioiTinh,
                                    NgaySinh    = @ngaySinh,
                                    CCCD        = @cccd,
                                    SoDienThoai = @sdt,
                                    Email       = @email,
                                    DiaChi      = @diaChi,
                                    Lop         = @lop,
                                    Khoa        = @khoa
                                 WHERE MaSV = @maSV";

                SqlParameter[] p = {
                    new SqlParameter("@hoTen",    hoTen),
                    new SqlParameter("@gioiTinh", cboGioiTinh.Text),
                    new SqlParameter("@ngaySinh", dtpNgaySinh.Value.Date),
                    new SqlParameter("@cccd",     cccd),
                    new SqlParameter("@sdt",      sdt),
                    new SqlParameter("@email",    email),
                    new SqlParameter("@diaChi",   diaChi),
                    new SqlParameter("@lop",      lop),
                    new SqlParameter("@khoa",     khoa),
                    new SqlParameter("@maSV",     SessionManager.MaTaiKhoan)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, p);
                if (rows > 0)
                {
                    SessionManager.HoTen = hoTen;
                    MessageBox.Show("Cập nhật thông tin thành công!",
                        "✅ Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HienThiLoi("Cập nhật thất bại! Vui lòng thử lại.");
                }
            }
            finally
            {
                btnLuuThongTin.Enabled = true;
                btnLuuThongTin.Text    = "💾 LƯU THÔNG TIN";
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
