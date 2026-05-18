// ============================================================
//  FILE: FormHelper.cs  -  them vao project
//  Static helper: tao DataGridView va Button chuan dark theme
//  Tuong thich: C# 7.3 / .NET Framework 4.7.2
// ============================================================
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    internal static class FormHelper
    {
        // Tao DataGridView dark theme chuan
        internal static DataGridView TaoDGV()
        {
            var dgv = new DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(10, 15, 35);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 210, 255);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(10, 15, 35);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(22, 30, 55);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(210, 225, 250);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 180);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(28, 38, 68);

            dgv.GridColor = Color.FromArgb(40, 55, 95);
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(18, 24, 44);
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 30;
            return dgv;
        }

        // Tao Button dark theme chuan
        internal static Button TaoNut(string text, Color backColor, int x, int y, int w = 110, int h = 33)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = backColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(w, h),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        // Tao TextBox dark theme (khong dung PlaceholderText vi .NET 4.7.2)
        internal static TextBox TaoTxt(string placeholder, int x, int y, int w, int h = 28)
        {
            var txt = new TextBox
            {
                Text = placeholder,
                ForeColor = Color.FromArgb(100, 120, 160),
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(35, 48, 82),
                BorderStyle = BorderStyle.FixedSingle,
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(w, h)
            };
            txt.GotFocus += (s, e) =>
            {
                if (txt.ForeColor == Color.FromArgb(100, 120, 160))
                { txt.Text = ""; txt.ForeColor = Color.FromArgb(220, 233, 255); }
            };
            txt.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                { txt.Text = placeholder; txt.ForeColor = Color.FromArgb(100, 120, 160); }
            };
            return txt;
        }

        // Lay tu khoa tu TextBox (bo qua neu dang hien placeholder)
        internal static string LayTK(TextBox txt)
        {
            if (txt.ForeColor == Color.FromArgb(100, 120, 160)) return "";
            return txt.Text.Trim();
        }

        // Reset TextBox ve placeholder
        internal static void ResetTxt(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.FromArgb(100, 120, 160);
        }

        // Tao Label tieu de section
        internal static Label TaoLabelTitle(string text, Color foreColor)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = foreColor,
                Dock = DockStyle.Top,
                Height = 48,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                BackColor = Color.FromArgb(10, 15, 35)
            };
        }
    }
}