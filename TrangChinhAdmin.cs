
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

      
        private void TaiThongKe()
        {
            try
            {
            
                btnQuanLySinhVienAdmin.Text = $"👥 Quản lý sinh viên ({LaySo("SELECT COUNT(1) FROM SinhVien WHERE TrangThai=1")})";

                btnQuanLyPhongAdmin.Text = $"🏠 Quản lý phòng ({LaySo("SELECT COUNT(1) FROM Phong WHERE TrangThai=N'Con cho'")})";

                btnQuanLyHopDongAdmin.Text = $"📄 Quản lý hợp đồng ({LaySo("SELECT COUNT(1) FROM HopDong WHERE TrangThai=N'Dang hieu luc'")})";

                btnQuanLyHoaDonAdmin.Text = $"💰 Quản lý hóa đơn ({LaySo("SELECT COUNT(1) FROM HoaDon WHERE TrangThai=N'Chua thanh toan'")})";

                btnQuanLyViPhamAdmin.Text = $"⚠️ Quản lý vi phạm ({LaySo("SELECT COUNT(1) FROM ViPham WHERE TrangThai=N'Chua xu ly'")})";
            }
            catch (Exception ex)
            {
             
                btnQuanLySinhVienAdmin.Text = "Quản lý sinh viên";
                btnQuanLyPhongAdmin.Text = "Quản lý phòng";
                btnQuanLyHopDongAdmin.Text = "Quản lý hợp đồng";
                btnQuanLyHoaDonAdmin.Text = "Quản lý hóa đơn";
                btnQuanLyViPhamAdmin.Text = "Quản lý vi phạm";
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


        private void MoForm(Form form)
        {
            form.FormClosed += (s, e) => TaiThongKe();
            form.Show();
        }

      
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