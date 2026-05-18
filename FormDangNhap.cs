using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public partial class FormDangNhap : Form
    {
        private bool _isPasswordVisible = false;

        public FormDangNhap()
        {
            InitializeComponent();
            GanSuKien();
            ApDungHieuUng();
        }

 
        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void GanSuKien()
        {
            this.btnDongY.Click    += btnDongY_Click;
            this.btnDangKy.Click   += btnDangKy_Click;
            this.btnShowPass.Click += btnShowPass_Click;

            this.txtTenDangNhap.KeyDown += (s, e) =>
            { if (e.KeyCode == Keys.Enter) txtMatKhau.Focus(); };
            this.txtMatKhau.KeyDown += (s, e) =>
            { if (e.KeyCode == Keys.Enter) btnDongY_Click(s, e); };

            this.btnDongY.MouseEnter += (s, e) =>
                btnDongY.BackColor = Color.FromArgb(0, 180, 230);
            this.btnDongY.MouseLeave += (s, e) =>
                btnDongY.BackColor = Color.FromArgb(0, 210, 255);

            this.txtTenDangNhap.Enter += (s, e) =>
                panelTxtMaSV.BackColor = Color.FromArgb(35, 48, 82);
            this.txtTenDangNhap.Leave += (s, e) =>
                panelTxtMaSV.BackColor = Color.FromArgb(28, 36, 64);
            this.txtMatKhau.Enter += (s, e) =>
                panelTxtPass.BackColor = Color.FromArgb(35, 48, 82);
            this.txtMatKhau.Leave += (s, e) =>
                panelTxtPass.BackColor = Color.FromArgb(28, 36, 64);
        }

        private void ApDungHieuUng()
        {
            SetRounded(panelTxtMaSV, 6);
            SetRounded(panelTxtPass, 6);
            SetRounded(btnDongY, 8);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTenDangNhap.Text.Trim();
            string matKhau  = txtMatKhau.Text;

            if (string.IsNullOrEmpty(taiKhoan))
            {
                HienThiLoi("Vui lòng nhập tài khoản!");
                txtTenDangNhap.Focus(); return;
            }
            if (string.IsNullOrEmpty(matKhau))
            {
                HienThiLoi("Vui lòng nhập mật khẩu!");
                txtMatKhau.Focus(); return;
            }

            btnDongY.Enabled = false;
            btnDongY.Text    = "Đang kiểm tra...";

            try
            {
                
                DataTable dtNV = LayThongTinNhanVien(taiKhoan, matKhau);
                if (dtNV != null && dtNV.Rows.Count > 0)
                {
                    SessionManager.MaTaiKhoan = dtNV.Rows[0]["MaNV"].ToString();
                    SessionManager.HoTen      = dtNV.Rows[0]["HoTen"].ToString();
                    SessionManager.VaiTro     = VaiTro.QuanTriVien;

                    MessageBox.Show(
                        $"Xin chào Quản trị viên {SessionManager.HoTen}!",
                        "✅ Đăng nhập thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    TrangChinhAdmin adminForm = new TrangChinhAdmin();
                    this.Hide();
                    adminForm.Show();
                    return;
                }

              
                DataTable dtSV = LayThongTinSinhVien(taiKhoan, matKhau);
                if (dtSV != null && dtSV.Rows.Count > 0)
                {
                    SessionManager.MaTaiKhoan = dtSV.Rows[0]["MaSV"].ToString();
                    SessionManager.HoTen      = dtSV.Rows[0]["HoTen"].ToString();
                    SessionManager.VaiTro     = VaiTro.SinhVien;

                    MessageBox.Show(
                        $"Xin chào {SessionManager.HoTen}!",
                        "✅ Đăng nhập thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TrangChinhSinhVien svForm = new TrangChinhSinhVien();
                    this.Hide();
                    svForm.Show();
                    return;
                }

                HienThiLoi("Tài khoản hoặc mật khẩu không chính xác!");
                txtMatKhau.Clear();
                txtMatKhau.Focus();
            }
            finally
            {
                btnDongY.Enabled = true;
                btnDongY.Text    = "ĐĂNG NHẬP";
            }
        }

        private DataTable LayThongTinNhanVien(string taiKhoan, string matKhau)
        {
            string query = @"SELECT MaNV, HoTen, ChucVu 
                             FROM NhanVien 
                             WHERE TenDangNhap = @tk 
                             AND   MatKhau     = @mk 
                             AND   TrangThai   = 1";
            SqlParameter[] p = {
                new SqlParameter("@tk", taiKhoan),
                new SqlParameter("@mk", matKhau)
            };
            return DatabaseHelper.ExecuteQuery(query, p);
        }

        private DataTable LayThongTinSinhVien(string taiKhoan, string matKhau)
        {
            string query = @"SELECT MaSV, HoTen, Lop, Khoa 
                             FROM SinhVien 
                             WHERE TenDangNhap = @tk 
                             AND   MatKhau     = @mk 
                             AND   TrangThai   = 1";
            SqlParameter[] p = {
                new SqlParameter("@tk", taiKhoan),
                new SqlParameter("@mk", matKhau)
            };
            return DatabaseHelper.ExecuteQuery(query, p);
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FormDangKySinhVien formDK = new FormDangKySinhVien();
            this.Hide();
            formDK.Show();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            _isPasswordVisible = !_isPasswordVisible;
            txtMatKhau.UseSystemPasswordChar = !_isPasswordVisible;
            btnShowPass.Text = _isPasswordVisible ? "🙈" : "👁";
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
