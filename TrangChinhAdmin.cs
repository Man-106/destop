// ============================================================
//  FILE: TrangChinhAdmin.cs
//  Dashboard Admin day du chuc nang:
//    - 4 the thong ke tu database (SQL khong dau)
//    - 5 nut mo form quan ly thuc su
//    - Dang xuat, lam moi
//  Tuong thich: C# 7.3 / .NET 4.7.2
// ============================================================
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public partial class TrangChinhAdmin : Form
    {
        public TrangChinhAdmin()
        {
            InitializeComponent();
            lblChaoMung.Text = "QUAN LY KY TUC XA  —  " + SessionManager.HoTen;
            this.Text = "Quan Ly Ky Tuc Xa — " + SessionManager.HoTen;
            TaiThongKe();
        }

        // ════════════════════════════════════════════════════════════════
        //  THONG KE DASHBOARD  (dung SQL khong dau)
        // ════════════════════════════════════════════════════════════════
        private void TaiThongKe()
        {
            try
            {
                // Sử dụng dấu $"" để ghép tên nút và số đếm trong ngoặc đơn ( )
                btnQuanLySinhVienAdmin.Text = $"Quản lý sinh viên ({LaySo("SELECT COUNT(1) FROM SinhVien WHERE TrangThai=1")})";
                btnQuanLyPhongAdmin.Text = $"Quản lý phòng ({LaySo("SELECT COUNT(1) FROM Phong WHERE TrangThai=N'Con cho'")})";

                // Bạn có thể áp dụng tương tự cho các nút còn lại:
                btnQuanLyHopDongAdmin.Text = $"Quản lý hợp đồng ({LaySo("SELECT COUNT(1) FROM HopDong WHERE TrangThai=N'Dang hieu luc'")})";
                btnQuanLyHoaDonAdmin.Text = $"Quản lý hóa đơn ({LaySo("SELECT COUNT(1) FROM HoaDon WHERE TrangThai=N'Chua thanh toan'")})";
                btnQuanLyViPhamAdmin.Text = $"Quản lý vi phạm ({LaySo("SELECT COUNT(1) FROM ViPham WHERE TrangThai=N'Chua xu ly'")})";
            }
            catch
            {
                // Nếu lỗi DB, hiển thị số (0) tạm thời để giao diện không bị lỗi chữ
                btnQuanLySinhVienAdmin.Text = "Quản lý sinh viên (0)";
                btnQuanLyPhongAdmin.Text = "Quản lý phòng (0)";
                btnQuanLyHopDongAdmin.Text = "Quản lý hợp đồng (0)";
                btnQuanLyHoaDonAdmin.Text = "Quản lý hóa đơn (0)";
                btnQuanLyViPhamAdmin.Text = "Quản lý vi phạm (0)";
            }
        }

        private int LaySo(string sql)
        {
            object v = DatabaseHelper.ExecuteScalar(sql);
            return (v == null || v == DBNull.Value) ? 0 : Convert.ToInt32(v);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnQuanLySinhVienAdmin.Text = "...";
            btnQuanLyPhongAdmin.Text = "...";
            btnQuanLyHoaDonAdmin.Text = "...";
            btnQuanLyHoaDonAdmin.Text = "...";
            TaiThongKe();
        }

        // ════════════════════════════════════════════════════════════════
        //  MO FORM CHUC NANG  —  sau khi dong thi lam moi dashboard
        // ════════════════════════════════════════════════════════════════
        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            MoForm(new FormQuanLySinhVienAdmin());
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            MoForm(new FormQuanLyPhongAdmin());
        }

        private void btnQuanLyHopDong_Click(object sender, EventArgs e)
        {
            MoForm(new FormQuanLyHopDongAdmin());
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            MoForm(new FormQuanLyHoaDonAdmin());
        }

        private void btnQuanLyViPham_Click(object sender, EventArgs e)
        {
            MoForm(new FormQuanLyViPhamAdmin());
        }

        // Mo form dang Show (khong Show Dialog) va lam moi khi dong
        private void MoForm(Form form)
        {
            form.FormClosed += (s, e) => TaiThongKe();
            form.Show();
        }

        // ════════════════════════════════════════════════════════════════
        //  DANG XUAT
        // ════════════════════════════════════════════════════════════════
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co chac muon dang xuat?", "Xac nhan",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SessionManager.DangXuat();
                new FormDangNhap().Show();
                this.Close();
            }
        }
    }
}