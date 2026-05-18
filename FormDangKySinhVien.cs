using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public partial class FormDangKySinhVien : Form
    {
        private bool _showPass1 = false;
        private bool _showPass2 = false;

        public FormDangKySinhVien()
        {
            InitializeComponent();
            GanSuKien();
            ApDungHieuUng();
        }

        private void GanSuKien()
        {
            this.btnDangKy.Click  += btnDangKy_Click;
            this.btnDangNhap.Click += btnDangNhap_Click;
            this.btnShowPass.Click  += btnShowPass_Click;
            this.btnShowPass2.Click += btnShowPass2_Click;

            this.txtMaSV.KeyDown         += (s, e) => { if (e.KeyCode == Keys.Enter) txtHoTen.Focus(); };
            this.txtHoTen.KeyDown        += (s, e) => { if (e.KeyCode == Keys.Enter) txtEmail.Focus(); };
            this.txtEmail.KeyDown        += (s, e) => { if (e.KeyCode == Keys.Enter) txtSDT.Focus(); };
            this.txtSDT.KeyDown          += (s, e) => { if (e.KeyCode == Keys.Enter) txtMatKhau.Focus(); };
            this.txtMatKhau.KeyDown      += (s, e) => { if (e.KeyCode == Keys.Enter) txtXacNhanMatKhau.Focus(); };
            this.txtXacNhanMatKhau.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnDangKy_Click(s, e); };

            this.btnDangKy.MouseEnter += (s, e) => btnDangKy.BackColor = Color.FromArgb(0, 180, 230);
            this.btnDangKy.MouseLeave += (s, e) => btnDangKy.BackColor = Color.FromArgb(0, 210, 255);

            HieuUngFocus(txtMaSV,           panelMaSV);
            HieuUngFocus(txtHoTen,          panelHoTen);
            HieuUngFocus(txtEmail,          panelEmail);
            HieuUngFocus(txtSDT,            panelSDT);
            HieuUngFocus(txtMatKhau,        panelMatKhau);
            HieuUngFocus(txtXacNhanMatKhau, panelXacNhan);
        }

        private void HieuUngFocus(System.Windows.Forms.TextBox txt,
                                   System.Windows.Forms.Panel panel)
        {
            txt.Enter += (s, e) => panel.BackColor = Color.FromArgb(35, 48, 82);
            txt.Leave += (s, e) => panel.BackColor = Color.FromArgb(28, 36, 64);
        }

        private void ApDungHieuUng()
        {
            SetRounded(panelMaSV,    6);
            SetRounded(panelHoTen,   6);
            SetRounded(panelEmail,   6);
            SetRounded(panelSDT,     6);
            SetRounded(panelMatKhau, 6);
            SetRounded(panelXacNhan, 6);
            SetRounded(btnDangKy,    8);
        }

       
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string maSV   = txtMaSV.Text.Trim();
            string hoTen  = txtHoTen.Text.Trim();
            string email  = txtEmail.Text.Trim();
            string sdt    = txtSDT.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhan = txtXacNhanMatKhau.Text;

            if (string.IsNullOrEmpty(maSV))
            { HienThiLoi("Vui lòng nhập mã sinh viên!"); txtMaSV.Focus(); return; }

            if (string.IsNullOrEmpty(hoTen))
            { HienThiLoi("Vui lòng nhập họ tên!"); txtHoTen.Focus(); return; }

            if (string.IsNullOrEmpty(email) || !KiemTraEmail(email))
            { HienThiLoi("Email không hợp lệ!\nVí dụ: example@gmail.com"); txtEmail.Focus(); return; }

            if (string.IsNullOrEmpty(sdt) || !KiemTraSDT(sdt))
            { HienThiLoi("Số điện thoại không hợp lệ!\nPhải có 10 số, bắt đầu bằng 0."); txtSDT.Focus(); return; }

            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6)
            { HienThiLoi("Mật khẩu phải có ít nhất 6 ký tự!"); txtMatKhau.Focus(); return; }

            if (matKhau != xacNhan)
            { HienThiLoi("Mật khẩu xác nhận không khớp!"); txtXacNhanMatKhau.Focus(); return; }

            btnDangKy.Enabled = false;
            btnDangKy.Text    = "Đang xử lý...";

            try
            {
                if (KiemTraMaSVTonTai(maSV))
                {
                    HienThiLoi("Mã sinh viên này đã được đăng ký!\nVui lòng dùng mã khác.");
                    txtMaSV.Focus(); return;
                }

                if (KiemTraEmailTonTai(email))
                {
                    HienThiLoi("Email này đã được đăng ký!\nVui lòng dùng email khác.");
                    txtEmail.Focus(); return;
                }

                bool ketQua = ThemSinhVienMoi(maSV, hoTen, email, sdt, matKhau);

                if (ketQua)
                {
                    MessageBox.Show(
                        $"Đăng ký thành công!\nChào mừng {hoTen} đã tham gia.\n\nVui lòng đăng nhập để tiếp tục.",
                        "✅ Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormDangNhap formDN = new FormDangNhap();
                    formDN.Show();
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
                btnDangKy.Text    = "ĐĂNG KÝ";
            }
        }

        private bool KiemTraMaSVTonTai(string maSV)
        {
            string query = "SELECT COUNT(1) FROM SinhVien WHERE MaSV = @maSV";
            SqlParameter[] p = { new SqlParameter("@maSV", maSV) };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, p));
            return count > 0;
        }

        private bool KiemTraEmailTonTai(string email)
        {
            string query = "SELECT COUNT(1) FROM SinhVien WHERE Email = @email";
            SqlParameter[] p = { new SqlParameter("@email", email) };
            int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, p));
            return count > 0;
        }

        private bool ThemSinhVienMoi(string maSV, string hoTen,
                                      string email, string sdt, string matKhau)
        {
            string query = @"
                INSERT INTO SinhVien 
                    (MaSV, HoTen, GioiTinh, NgaySinh, CCCD, 
                     SoDienThoai, Email, DiaChi, Lop, Khoa, 
                     TenDangNhap, MatKhau, NgayDangKy, TrangThai)
                VALUES 
                    (@maSV, @hoTen, N'Nam', GETDATE(), N'000000000000',
                     @sdt, @email, N'Chưa cập nhật', N'Chưa cập nhật', N'Chưa cập nhật',
                     @maSV, @matKhau, GETDATE(), 1)";

            SqlParameter[] p = {
                new SqlParameter("@maSV",    maSV),
                new SqlParameter("@hoTen",   hoTen),
                new SqlParameter("@sdt",     sdt),
                new SqlParameter("@email",   email),
                new SqlParameter("@matKhau", matKhau)
            };

            int rows = DatabaseHelper.ExecuteNonQuery(query, p);
            return rows > 0;
        }

        private bool KiemTraEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool KiemTraSDT(string sdt)
        {
            return Regex.IsMatch(sdt, @"^0\d{9}$");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap formDN = new FormDangNhap();
            formDN.Show();
            this.Close();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            _showPass1 = !_showPass1;
            txtMatKhau.UseSystemPasswordChar = !_showPass1;
            btnShowPass.Text = _showPass1 ? "🙈" : "👁";
        }

        private void btnShowPass2_Click(object sender, EventArgs e)
        {
            _showPass2 = !_showPass2;
            txtXacNhanMatKhau.UseSystemPasswordChar = !_showPass2;
            btnShowPass2.Text = _showPass2 ? "🙈" : "👁";
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
