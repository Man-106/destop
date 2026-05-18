// ============================================================
//  FILE: TrangChinhSinhVien.cs
//  Tuong thich voi TrangChinhSinhVien_Designer.cs goc
//  (sidebar layout, 6 nut chuc nang)
//  Tuong thich: C# 7.3 / .NET 4.7.2
// ============================================================
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public partial class TrangChinhSinhVien : Form
    {
        public TrangChinhSinhVien()
        {
            InitializeComponent();
            GanSuKien();
        }

        private void GanSuKien()
        {
            this.btnDangXuat.Click += btnDangXuat_Click;
            this.btnThongTinCaNhan.Click += (s, e) => MoForm(new ThongTinCaNhanSinhVien());
            this.btnThongTinPhong.Click += (s, e) => MoForm(new ThongTinPhongSinhVien());
            this.btnDangKyPhong.Click += (s, e) => MoForm(new DangKyPhong());
            this.btnGiaHanPhong.Click += (s, e) => MoForm(new GiaHanPhongSinhVien());
            this.btnHoaDon.Click += (s, e) => MoForm(new HoaDonSinhVien());
            this.btnViPham.Click += (s, e) => MoForm(new ViPhamSinhVien());

            GanHieuUngMenu(btnThongTinCaNhan);
            GanHieuUngMenu(btnThongTinPhong);
            GanHieuUngMenu(btnDangKyPhong);
            GanHieuUngMenu(btnGiaHanPhong);
            GanHieuUngMenu(btnHoaDon);
            GanHieuUngMenu(btnViPham);
        }

        private void GanHieuUngMenu(Button btn)
        {
            Color normal = Color.FromArgb(22, 30, 54);
            Color hover = Color.FromArgb(35, 48, 82);
            btn.MouseEnter += (s, e) => btn.BackColor = hover;
            btn.MouseLeave += (s, e) => btn.BackColor = normal;
        }

        // Mo form con kieu ShowDialog de nguoi dung quay lai trang chinh
        private void MoForm(Form formCon)
        {
            formCon.ShowDialog(this);
        }

        private void TrangChinhSinhVien_Load(object sender, EventArgs e)
        {
            lblThongTin.Text =
                "Xin chao, " + SessionManager.HoTen +
                "!  |  Ma SV: " + SessionManager.MaTaiKhoan;
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