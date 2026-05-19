using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public class FormQuanLyHoaDonAdmin : Form
    {
        private DataGridView dgv;
        private TextBox txtTK;
        private Label lblTong, lblStat;
        private Button btnThem, btnThanhToan, btnXemCT, btnLamMoi;
        private ComboBox cboLoc;

        public FormQuanLyHoaDonAdmin()
        {
            XayDungGD();
            TaiDanhSach();
        }

        private void XayDungGD()
        {
            this.Text = "Quan ly Hoa don";
            this.BackColor = Color.FromArgb(14, 20, 42);
            this.ClientSize = new System.Drawing.Size(1260, 620);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = FormHelper.TaoDGV();

            string ph = "Tim ma hoa don, ma SV, ten SV...";
            txtTK = FormHelper.TaoTxt(ph, 15, 14, 295);

            cboLoc = new ComboBox { Font = new Font("Segoe UI", 9F), BackColor = Color.FromArgb(35, 48, 82), ForeColor = Color.FromArgb(220, 233, 255), Location = new System.Drawing.Point(320, 14), Size = new System.Drawing.Size(195, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoc.Items.AddRange(new object[] { "Tat ca", "Chua thanh toan", "Da thanh toan", "Qua han" });
            cboLoc.SelectedIndex = 0;

            lblTong = new Label { Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(140, 170, 210), Location = new System.Drawing.Point(525, 17), Size = new System.Drawing.Size(195, 22) };
            lblStat = new Label { Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(255, 200, 100), Location = new System.Drawing.Point(15, 42), Size = new System.Drawing.Size(700, 20) };

            btnThem = FormHelper.TaoNut("+ Tao HD", Color.FromArgb(0, 150, 100), 720, 10, 105, 33);
            btnThanhToan = FormHelper.TaoNut("Thanh toan", Color.FromArgb(0, 130, 200), 835, 10, 120, 33);
            btnXemCT = FormHelper.TaoNut("Chi tiet", Color.FromArgb(100, 60, 200), 965, 10, 105, 33);
            btnLamMoi = FormHelper.TaoNut("Lam moi", Color.FromArgb(55, 75, 125), 1080, 10, 100, 33);

            btnThem.Click += BtnThem_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
            btnXemCT.Click += BtnXemCT_Click;
            btnLamMoi.Click += (s, e) => { FormHelper.ResetTxt(txtTK, ph); cboLoc.SelectedIndex = 0; TaiDanhSach(); };
            txtTK.TextChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            cboLoc.SelectedIndexChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            dgv.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) BtnXemCT_Click(s, e); };

            var panelTop = new Panel { BackColor = Color.FromArgb(18, 24, 44), Dock = DockStyle.Top, Height = 65 };
            panelTop.Controls.AddRange(new Control[] { txtTK, cboLoc, lblTong, lblStat, btnThem, btnThanhToan, btnXemCT, btnLamMoi });
            var lblTitle = FormHelper.TaoLabelTitle("Quan ly Hoa don", Color.FromArgb(255, 180, 0));
            this.Controls.Add(dgv); this.Controls.Add(panelTop); this.Controls.Add(lblTitle);
        }

        private void TaiDanhSach(string kw = "", string tt = "Tat ca")
        {
            string q = @"SELECT h.MaHD_HoaDon [Ma HD], sv.MaSV [Ma SV], sv.HoTen [Ho Ten SV],
                         p.TenPhong [Ten Phong], h.ThangNam [Thang/Nam],
                         CAST(h.TienPhong AS NVARCHAR) + N' d' [Tien Phong],
                         CAST(h.TienDien  AS NVARCHAR) + N' d' [Tien Dien],
                         CAST(h.TienNuoc  AS NVARCHAR) + N' d' [Tien Nuoc],
                         CAST(h.TienDichVu AS NVARCHAR) + N' d' [DV],
                         CAST(h.TongTien  AS NVARCHAR) + N' d' [Tong Tien],
                         CONVERT(varchar,h.HanThanhToan,103) [Han TT],
                         CASE WHEN h.NgayThanhToan IS NULL THEN N'Chua TT' ELSE CONVERT(varchar,h.NgayThanhToan,103) END [Ngay TT],
                         h.TrangThai [Trang Thai]
                         FROM HoaDon h
                         JOIN SinhVien sv ON h.MaSV    = sv.MaSV
                         JOIN Phong    p  ON h.MaPhong = p.MaPhong
                         WHERE 1=1";
            var ps = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(kw)) { q += " AND (h.MaHD_HoaDon LIKE @kw OR sv.MaSV LIKE @kw OR sv.HoTen LIKE @kw)"; ps.Add(new SqlParameter("@kw", "%" + kw + "%")); }
            if (tt != "Tat ca") { q += " AND h.TrangThai=@tt"; ps.Add(new SqlParameter("@tt", tt)); }
            q += " ORDER BY h.ThangNam DESC, sv.HoTen";
            var dt = DatabaseHelper.ExecuteQuery(q, ps.ToArray());
            dgv.DataSource = dt;
            lblTong.Text = "Tong: " + dt.Rows.Count + " hoa don";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string s = row.Cells["Trang Thai"].Value?.ToString();
                row.DefaultCellStyle.ForeColor =
                    s == "Da thanh toan" ? Color.FromArgb(80, 220, 140) :
                    s == "Qua han" ? Color.FromArgb(255, 100, 100) : Color.FromArgb(255, 200, 0);
            }

            int chua = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HoaDon WHERE TrangThai=N'Chua thanh toan'") ?? 0);
            int da = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HoaDon WHERE TrangThai=N'Da thanh toan'") ?? 0);
            int qh = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HoaDon WHERE TrangThai=N'Qua han'") ?? 0);
            object no = DatabaseHelper.ExecuteScalar("SELECT SUM(TongTien) FROM HoaDon WHERE TrangThai IN (N'Chua thanh toan',N'Qua han')");
            decimal tongNo = (no == null || no == DBNull.Value) ? 0 : Convert.ToDecimal(no);
            lblStat.Text = "Chua TT: " + chua + "    Da TT: " + da + "    Qua han: " + qh + "    Tong no: " + tongNo.ToString("N0") + " d";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            using (var f = new FormTaoHoaDonAdmin())
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach();
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon hoa don!"); return; }
            string ma = dgv.CurrentRow.Cells["Ma HD"].Value?.ToString();
            string tt = dgv.CurrentRow.Cells["Trang Thai"].Value?.ToString();
            if (tt == "Da thanh toan") { Warn("Hoa don nay da duoc thanh toan!"); return; }
            if (MessageBox.Show("Xac nhan thanh toan hoa don " + ma + "?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseHelper.ExecuteNonQuery("UPDATE HoaDon SET TrangThai=N'Da thanh toan',NgayThanhToan=GETDATE() WHERE MaHD_HoaDon=@m",
                    new SqlParameter[] { new SqlParameter("@m", ma) });
                TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
                MessageBox.Show("Da thanh toan!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnXemCT_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon hoa don!"); return; }
            string info = "";
            foreach (DataGridViewCell cell in dgv.CurrentRow.Cells)
                info += string.Format("{0,-22}: {1}\n", dgv.Columns[cell.ColumnIndex].HeaderText, cell.Value);
            MessageBox.Show(info, "Chi tiet Hoa don", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Warn(string m) => MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public class FormTaoHoaDonAdmin : Form
    {
        private TextBox txtMaHD, txtDien, txtNuoc, txtDV, txtGhiChu;
        private ComboBox cboHD;
        private DateTimePicker dtpHan;
        private Label lblTT, lblTP, lblTong;
        private Button btnLuu, btnHuy;
        private DataTable _dtHD = new DataTable();
        private decimal _gia = 0;
        private string _maPhong = "", _maSV = "", _maHD = "";

        public FormTaoHoaDonAdmin()
        {
            XayDung();
            TaiHD();
        }

        private void XayDung()
        {
            this.Text = "Tao Hoa Don";
            this.BackColor = Color.FromArgb(18, 24, 44);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            int y = 55; int tx = 165; int tw = 315;
            var title = new Label { Text = "TAO HOA DON HANG THANG", Font = new Font("Segoe UI", 13F, FontStyle.Bold), ForeColor = Color.FromArgb(255, 180, 0), Size = new System.Drawing.Size(500, 38), Location = new System.Drawing.Point(0, 10), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(title);

            Action<string, int> LB = (t, top) => this.Controls.Add(new Label { Text = t, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 210, 255), Location = new System.Drawing.Point(15, top + 3), AutoSize = true });
            Func<int, TextBox> TB = (top) => { var t = new TextBox { Font = new Font("Segoe UI", 10F), BackColor = Color.FromArgb(28, 36, 64), ForeColor = Color.FromArgb(220, 233, 255), BorderStyle = BorderStyle.FixedSingle, Location = new System.Drawing.Point(tx, top), Size = new System.Drawing.Size(tw, 28) }; this.Controls.Add(t); return t; };

            LB("Ma HD hoa don *", y); txtMaHD = TB(y); y += 38;

            LB("Hop dong *", y);
            cboHD = new ComboBox { Font = new Font("Segoe UI", 9F), BackColor = Color.FromArgb(28, 36, 64), ForeColor = Color.FromArgb(220, 233, 255), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(tw, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cboHD.SelectedIndexChanged += (s, e) => CapNhat();
            this.Controls.Add(cboHD); y += 38;

            lblTT = new Label { Font = new Font("Segoe UI", 8F, FontStyle.Italic), ForeColor = Color.FromArgb(0, 200, 130), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(tw, 18), Text = "Chon hop dong..." };
            this.Controls.Add(lblTT); y += 22;
            lblTP = new Label { Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(255, 180, 0), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(tw, 20), Text = "Tien phong: 0 d" };
            this.Controls.Add(lblTP); y += 28;

            LB("Tien dien", y); txtDien = TB(y); txtDien.Text = "0"; txtDien.TextChanged += Tinh; y += 38;
            LB("Tien nuoc", y); txtNuoc = TB(y); txtNuoc.Text = "0"; txtNuoc.TextChanged += Tinh; y += 38;
            LB("Tien dich vu", y); txtDV = TB(y); txtDV.Text = "0"; txtDV.TextChanged += Tinh; y += 38;

            LB("Han thanh toan *", y);
            dtpHan = new DateTimePicker { Font = new Font("Segoe UI", 10F), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(190, 28), Format = DateTimePickerFormat.Short };
            dtpHan.Value = DateTime.Today.AddDays(15);
            this.Controls.Add(dtpHan); y += 38;

            lblTong = new Label { Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 255, 180), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(tw, 26), Text = "Tong tien: 0 d" };
            this.Controls.Add(lblTong); y += 34;

            LB("Ghi chu", y); txtGhiChu = TB(y); y += 38;

            btnLuu = new Button { Text = "Luu", BackColor = Color.FromArgb(0, 150, 100), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx, y + 8), Size = new System.Drawing.Size(148, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnHuy = new Button { Text = "Huy", BackColor = Color.FromArgb(150, 40, 50), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx + 163, y + 8), Size = new System.Drawing.Size(148, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnHuy.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnLuu); this.Controls.Add(btnHuy);
            this.ClientSize = new System.Drawing.Size(500, y + 58);
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void TaiHD()
        {
            _dtHD = DatabaseHelper.ExecuteQuery(@"SELECT hd.MaHD, sv.MaSV, sv.HoTen, p.TenPhong, p.GiaThue, hd.MaPhong
                FROM HopDong hd JOIN SinhVien sv ON hd.MaSV=sv.MaSV JOIN Phong p ON hd.MaPhong=p.MaPhong
                WHERE hd.TrangThai=N'Dang hieu luc' ORDER BY hd.MaHD");
            cboHD.Items.Clear();
            foreach (DataRow r in _dtHD.Rows)
                cboHD.Items.Add(r["MaHD"] + " | " + r["MaSV"] + " - " + r["HoTen"] + " | " + r["TenPhong"]);
            if (cboHD.Items.Count > 0) cboHD.SelectedIndex = 0;
        }

        private void CapNhat()
        {
            int i = cboHD.SelectedIndex;
            if (i < 0 || i >= _dtHD.Rows.Count) return;
            var r = _dtHD.Rows[i];
            _gia = Convert.ToDecimal(r["GiaThue"]);
            _maPhong = r["MaPhong"].ToString();
            _maSV = r["MaSV"].ToString();
            _maHD = r["MaHD"].ToString();
            lblTT.Text = "SV: " + r["MaSV"] + " - " + r["HoTen"] + "  |  " + r["TenPhong"];
            lblTP.Text = "Tien phong: " + _gia.ToString("N0") + " d";
            Tinh(null, null);
        }

        private void Tinh(object sender, EventArgs e)
        {
            decimal dien, nuoc, dv;
            decimal.TryParse(txtDien.Text, out dien);
            decimal.TryParse(txtNuoc.Text, out nuoc);
            decimal.TryParse(txtDV.Text, out dv);
            lblTong.Text = "Tong tien: " + (_gia + dien + nuoc + dv).ToString("N0") + " d";
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            if (string.IsNullOrEmpty(maHD)) { Warn("Nhap ma hoa don!"); return; }
            if (cboHD.SelectedIndex < 0) { Warn("Chon hop dong!"); return; }
            decimal dien, nuoc, dv;
            if (!decimal.TryParse(txtDien.Text, out dien) || dien < 0) { Warn("Tien dien khong hop le!"); return; }
            if (!decimal.TryParse(txtNuoc.Text, out nuoc) || nuoc < 0) { Warn("Tien nuoc khong hop le!"); return; }
            if (!decimal.TryParse(txtDV.Text, out dv) || dv < 0) { Warn("Tien dich vu khong hop le!"); return; }

            int dup = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HoaDon WHERE MaHD_HoaDon=@m", new SqlParameter[] { new SqlParameter("@m", maHD) }));
            if (dup > 0) { Warn("Ma hoa don da ton tai!"); return; }

            try
            {
                DatabaseHelper.ExecuteNonQuery(@"INSERT INTO HoaDon(MaHD_HoaDon,MaHD,MaSV,MaPhong,ThangNam,TienPhong,TienDien,TienNuoc,TienDichVu,HanThanhToan,TrangThai,GhiChu,MaNV)
                    VALUES(@mh,@hd,@ms,@mp,@tn,@tp,@td,@tn2,@dv,@han,N'Chua thanh toan',@gc,@mn)",
                    new SqlParameter[] { new SqlParameter("@mh", maHD), new SqlParameter("@hd", _maHD), new SqlParameter("@ms", _maSV), new SqlParameter("@mp", _maPhong), new SqlParameter("@tn", DateTime.Today.ToString("yyyy-MM")), new SqlParameter("@tp", _gia), new SqlParameter("@td", dien), new SqlParameter("@tn2", nuoc), new SqlParameter("@dv", dv), new SqlParameter("@han", dtpHan.Value.Date), new SqlParameter("@gc", txtGhiChu.Text.Trim()), new SqlParameter("@mn", SessionManager.MaTaiKhoan) });
                MessageBox.Show("Tao hoa don thanh cong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Warn(string m) => MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}