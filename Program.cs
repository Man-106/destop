

using System;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!DatabaseHelper.KiemTraKetNoi())
            {
                Application.Exit();
                return;
            }

            Application.Run(new FormDangNhap());
        }
    }
}