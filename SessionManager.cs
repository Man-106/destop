namespace DU_AN_DESKTOP_CUOI_KY
{
    public static class SessionManager
    {
        public static string MaTaiKhoan { get; set; }
        public static string HoTen      { get; set; }
        public static VaiTro VaiTro     { get; set; }

        public static bool DaDangNhap    => !string.IsNullOrEmpty(MaTaiKhoan);
        public static bool LaQuanTriVien => VaiTro == VaiTro.QuanTriVien;
        public static bool LaSinhVien    => VaiTro == VaiTro.SinhVien;

        public static void DangXuat()
        {
            MaTaiKhoan = null;
            HoTen      = null;
            VaiTro     = VaiTro.SinhVien;
        }
    }

    public enum VaiTro
    {
        QuanTriVien,
        SinhVien
    }
}
