using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public class FormQuanLyPhongAdmin : Form
    {
        private DataGridView dgv;
        private TextBox txtTK;
        private Label lblTong, lblStat;
        private Button btnThem, btnSua, btnXoa, btnXemSV, btnLamMoi;

        public FormQuanLyPhongAdmin()
        {
            XayDungGD();
            TaiDanhSach();
        }

        private void XayDungGD()
        {
            this.Text = "Quan ly Phong";
            this.BackColor = Color.FromArgb(14, 20, 42);
            this.ClientSize = new System.Drawing.Size(1200, 620);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = FormHelper.TaoDGV();

            string ph = "Tim ma phong, ten, loai, trang thai...";
            txtTK = FormHelper.TaoTxt(ph, 15, 14, 340);

            lblTong = new Label { Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(140, 170, 210), Location = new System.Drawing.Point(365, 17), Size = new System.Drawing.Size(190, 22) };
            lblStat = new Label { Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 200, 150), Location = new System.Drawing.Point(15, 42), Size = new System.Drawing.Size(620, 20) };

            btnThem = FormHelper.TaoNut("+ Them", Color.FromArgb(0, 150, 100), 650, 10, 100, 33);
            btnSua = FormHelper.TaoNut("Sua", Color.FromArgb(0, 130, 200), 760, 10, 90, 33);
            btnXoa = FormHelper.TaoNut("Xoa", Color.FromArgb(190, 45, 60), 860, 10, 90, 33);
            btnXemSV = FormHelper.TaoNut("Xem SV", Color.FromArgb(130, 70, 200), 960, 10, 100, 33);
            btnLamMoi = FormHelper.TaoNut("Lam moi", Color.FromArgb(55, 75, 125), 1070, 10, 100, 33);

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnXemSV.Click += BtnXemSV_Click;
            btnLamMoi.Click += (s, e) => { FormHelper.ResetTxt(txtTK, ph); TaiDanhSach(); };
            txtTK.TextChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK));
            dgv.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) BtnXemSV_Click(s, e); };

            var panelTop = new Panel { BackColor = Color.FromArgb(18, 24, 44), Dock = DockStyle.Top, Height = 65 };
            panelTop.Controls.AddRange(new Control[] { txtTK, lblTong, lblStat, btnThem, btnSua, btnXoa, btnXemSV, btnLamMoi });

            var lblTitle = FormHelper.TaoLabelTitle("Quan ly Phong", Color.FromArgb(0, 200, 130));
            this.Controls.Add(dgv);
            this.Controls.Add(panelTop);
            this.Controls.Add(lblTitle);
        }

        private void TaiDanhSach(string kw = "")
        {
            string q = @"SELECT p.MaPhong [Ma Phong], p.TenPhong [Ten Phong], p.LoaiPhong [Loai],
                         p.Tang [Tang], p.SoNguoiToiDa [Suc Chua], p.SoNguoiHienTai [Hien Tai],
                         (p.SoNguoiToiDa - p.SoNguoiHienTai) [Cho Trong],
                         CAST(p.GiaThue AS NVARCHAR) + N' d' [Gia Thue/T],
                         p.TrangThai [Trang Thai], ISNULL(p.MoTa,'') [Mo Ta]
                         FROM Phong p";
            SqlParameter[] p2 = null;
            if (!string.IsNullOrEmpty(kw))
            {
                q += " WHERE p.MaPhong LIKE @kw OR p.TenPhong LIKE @kw OR p.LoaiPhong LIKE @kw OR p.TrangThai LIKE @kw";
                p2 = new SqlParameter[] { new SqlParameter("@kw", "%" + kw + "%") };
            }
            q += " ORDER BY p.Tang, p.MaPhong";
            var dt = DatabaseHelper.ExecuteQuery(q, p2);
            dgv.DataSource = dt;
            lblTong.Text = "Tong: " + dt.Rows.Count + " phong";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string tt = row.Cells["Trang Thai"].Value?.ToString();
                row.DefaultCellStyle.ForeColor =
                    tt == "Day" ? Color.FromArgb(255, 100, 100) :
                    tt == "Dang sua chua" ? Color.FromArgb(255, 200, 0) :
                                           Color.FromArgb(80, 220, 140);
            }

            int cc = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Phong WHERE TrangThai=N'Con cho'") ?? 0);
            int d = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Phong WHERE TrangThai=N'Day'") ?? 0);
            int sc = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Phong WHERE TrangThai=N'Dang sua chua'") ?? 0);
            lblStat.Text = "Con cho: " + cc + "    Day: " + d + "    Sua chua: " + sc;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            using (var f = new FormChiTietPhong(null))
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach(FormHelper.LayTK(txtTK));
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            string ma = LayMa(); if (ma == null) return;
            using (var f = new FormChiTietPhong(ma))
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach(FormHelper.LayTK(txtTK));
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string ma = LayMa(); if (ma == null) return;
            string ten = dgv.CurrentRow.Cells["Ten Phong"].Value?.ToString();
            int hd = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM HopDong WHERE MaPhong=@m AND TrangThai=N'Dang hieu luc'",
                new SqlParameter[] { new SqlParameter("@m", ma) }));
            if (hd > 0) { Warn("Phong " + ten + " dang co hop dong hieu luc, khong the xoa!"); return; }
            if (MessageBox.Show("Xoa phong " + ma + " - " + ten + "?", "Xac nhan",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Phong WHERE MaPhong=@m",
                    new SqlParameter[] { new SqlParameter("@m", ma) });
                TaiDanhSach(FormHelper.LayTK(txtTK));
            }
        }

        private void BtnXemSV_Click(object sender, EventArgs e)
        {
            string ma = LayMa(); if (ma == null) return;
            string ten = dgv.CurrentRow.Cells["Ten Phong"].Value?.ToString();
            using (var f = new FormSinhVienPhong(ma, ten)) f.ShowDialog();
        }

        private string LayMa()
        {
            if (dgv.CurrentRow == null) { Warn("Vui long chon mot dong!"); return null; }
            return dgv.CurrentRow.Cells["Ma Phong"].Value?.ToString();
        }

        private void Warn(string m) =>
            MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    
    public class FormChiTietPhong : Form
    {
        private readonly string _ma;
        private TextBox txtMa, txtTen, txtSo, txtGia, txtMoTa;
        private ComboBox cboLoai, cboTang, cboTT;
        private Button btnLuu, btnHuy;

        public FormChiTietPhong(string maPhong)
        {
            _ma = maPhong;
            XayDung();
            if (_ma != null) TaiTT();
        }

        private void XayDung()
        {
            this.Text = _ma == null ? "Them Phong" : "Sua Phong";
            this.BackColor = Color.FromArgb(18, 24, 44);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            int y = 55; int tx = 155; int tw = 290;
            var title = new Label { Text = _ma == null ? "THEM PHONG MOI" : "CHINH SUA PHONG", Font = new Font("Segoe UI", 13F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 200, 130), Size = new System.Drawing.Size(460, 38), Location = new System.Drawing.Point(0, 10), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(title);

            Action<string, int> LB = (t, top) => this.Controls.Add(new Label { Text = t, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 210, 255), Location = new System.Drawing.Point(15, top + 3), AutoSize = true });
            Func<int, TextBox> TB = (top) => { var t = new TextBox { Font = new Font("Segoe UI", 10F), BackColor = Color.FromArgb(28, 36, 64), ForeColor = Color.FromArgb(220, 233, 255), BorderStyle = BorderStyle.FixedSingle, Location = new System.Drawing.Point(tx, top), Size = new System.Drawing.Size(tw, 28) }; this.Controls.Add(t); return t; };
            Func<int, string[], ComboBox> CB = (top, items) => { var c = new ComboBox { Font = new Font("Segoe UI", 10F), BackColor = Color.FromArgb(28, 36, 64), ForeColor = Color.FromArgb(220, 233, 255), Location = new System.Drawing.Point(tx, top), Size = new System.Drawing.Size(200, 28), DropDownStyle = ComboBoxStyle.DropDownList }; c.Items.AddRange(items); c.SelectedIndex = 0; this.Controls.Add(c); return c; };

            LB("Ma Phong *", y); txtMa = TB(y); txtMa.ReadOnly = (_ma != null); y += 38;
            LB("Ten Phong *", y); txtTen = TB(y); y += 38;
            LB("Loai Phong *", y); cboLoai = CB(y, new string[] { "4 nguoi", "6 nguoi", "8 nguoi", "2 nguoi", "VIP" }); y += 38;
            LB("Tang *", y); cboTang = CB(y, new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }); y += 38;
            LB("Suc chua *", y); txtSo = TB(y); y += 38;
            LB("Gia thue/thang *", y); txtGia = TB(y); y += 38;
            LB("Trang thai *", y); cboTT = CB(y, new string[] { "Con cho", "Day", "Dang sua chua" }); y += 38;
            LB("Mo ta", y); txtMoTa = TB(y); y += 38;

            btnLuu = new Button { Text = "Luu", BackColor = Color.FromArgb(0, 150, 100), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx, y + 10), Size = new System.Drawing.Size(135, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnHuy = new Button { Text = "Huy", BackColor = Color.FromArgb(150, 40, 50), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx + 150, y + 10), Size = new System.Drawing.Size(135, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnHuy.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnLuu); this.Controls.Add(btnHuy);
            this.ClientSize = new System.Drawing.Size(460, y + 65);
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void TaiTT()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM Phong WHERE MaPhong=@m",
                new SqlParameter[] { new SqlParameter("@m", _ma) });
            if (dt.Rows.Count == 0) return;
            var r = dt.Rows[0];
            txtMa.Text = r["MaPhong"].ToString();
            txtTen.Text = r["TenPhong"].ToString();
            cboLoai.Text = r["LoaiPhong"].ToString();
            cboTang.Text = r["Tang"].ToString();
            txtSo.Text = r["SoNguoiToiDa"].ToString();
            txtGia.Text = r["GiaThue"].ToString();
            cboTT.Text = r["TrangThai"].ToString();
            txtMoTa.Text = r["MoTa"]?.ToString();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim(), ten = txtTen.Text.Trim();
            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten)) { Warn("Ma va Ten phong khong duoc de trong!"); return; }
            int so; if (!int.TryParse(txtSo.Text.Trim(), out so) || so < 1) { Warn("Suc chua phai la so nguyen duong!"); return; }
            decimal gia; if (!decimal.TryParse(txtGia.Text.Trim(), out gia) || gia < 0) { Warn("Gia thue khong hop le!"); return; }
            try
            {
                if (_ma == null)
                {
                    int ex = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Phong WHERE MaPhong=@m", new SqlParameter[] { new SqlParameter("@m", ma) }));
                    if (ex > 0) { Warn("Ma phong da ton tai!"); return; }
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Phong(MaPhong,TenPhong,LoaiPhong,Tang,SoNguoiToiDa,SoNguoiHienTai,GiaThue,MoTa,TrangThai) VALUES(@ma,@ten,@loai,@tang,@so,0,@gia,@mo,@tt)",
                        new SqlParameter[] { new SqlParameter("@ma", ma), new SqlParameter("@ten", ten), new SqlParameter("@loai", cboLoai.Text), new SqlParameter("@tang", int.Parse(cboTang.Text)), new SqlParameter("@so", so), new SqlParameter("@gia", gia), new SqlParameter("@mo", txtMoTa.Text.Trim()), new SqlParameter("@tt", cboTT.Text) });
                    MessageBox.Show("Them phong thanh cong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DatabaseHelper.ExecuteNonQuery("UPDATE Phong SET TenPhong=@ten,LoaiPhong=@loai,Tang=@tang,SoNguoiToiDa=@so,GiaThue=@gia,MoTa=@mo,TrangThai=@tt WHERE MaPhong=@ma",
                        new SqlParameter[] { new SqlParameter("@ten", ten), new SqlParameter("@loai", cboLoai.Text), new SqlParameter("@tang", int.Parse(cboTang.Text)), new SqlParameter("@so", so), new SqlParameter("@gia", gia), new SqlParameter("@mo", txtMoTa.Text.Trim()), new SqlParameter("@tt", cboTT.Text), new SqlParameter("@ma", ma) });
                    MessageBox.Show("Cap nhat phong thanh cong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Warn(string m) => MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

   
    public class FormSinhVienPhong : Form
    {
        public FormSinhVienPhong(string maPhong, string tenPhong)
        {
            this.Text = "Sinh vien phong " + maPhong + " - " + tenPhong;
            this.BackColor = Color.FromArgb(14, 20, 42);
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.StartPosition = FormStartPosition.CenterParent;

            var dgv = FormHelper.TaoDGV();
            string q = @"SELECT sv.MaSV [Ma SV], sv.HoTen [Ho Ten], sv.GioiTinh [GT],
                         sv.SoDienThoai [So DT], sv.Email, sv.Lop,
                         CONVERT(varchar,hd.NgayBatDau,103) [Ngay vao],
                         CONVERT(varchar,hd.NgayKetThuc,103) [Ngay het HD],
                         hd.TrangThai [TT HD]
                         FROM HopDong hd
                         JOIN SinhVien sv ON hd.MaSV = sv.MaSV
                         WHERE hd.MaPhong = @m
                         ORDER BY hd.TrangThai, sv.HoTen";
            var dt = DatabaseHelper.ExecuteQuery(q, new SqlParameter[] { new SqlParameter("@m", maPhong) });
            dgv.DataSource = dt;

            var lbl = new Label
            {
                Text = "Phong: " + maPhong + " - " + tenPhong + "  |  So SV: " + dt.Rows.Count,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 200, 130),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                BackColor = Color.FromArgb(10, 15, 35)
            };
            this.Controls.Add(dgv);
            this.Controls.Add(lbl);
        }
    }
}