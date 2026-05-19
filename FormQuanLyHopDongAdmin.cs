using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public class FormQuanLyHopDongAdmin : Form
    {
        private DataGridView dgv;
        private TextBox txtTK;
        private Label lblTong, lblStat;
        private Button btnThem, btnHuy, btnXemCT, btnLamMoi;
        private ComboBox cboLoc;

        public FormQuanLyHopDongAdmin()
        {
            XayDungGD();
            TaiDanhSach();
        }

        private void XayDungGD()
        {
            this.Text = "Quan ly Hop dong";
            this.BackColor = Color.FromArgb(14, 20, 42);
            this.ClientSize = new System.Drawing.Size(1260, 620);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = FormHelper.TaoDGV();

            string ph = "Tim ma HD, ma SV, ten SV, ma phong...";
            txtTK = FormHelper.TaoTxt(ph, 15, 14, 310);

            cboLoc = new ComboBox
            {
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(35, 48, 82),
                ForeColor = Color.FromArgb(220, 233, 255),
                Location = new System.Drawing.Point(335, 14),
                Size = new System.Drawing.Size(175, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboLoc.Items.AddRange(new object[] { "Tat ca", "Dang hieu luc", "Het han", "Da huy" });
            cboLoc.SelectedIndex = 0;

            lblTong = new Label { Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(140, 170, 210), Location = new System.Drawing.Point(520, 17), Size = new System.Drawing.Size(200, 22) };
            lblStat = new Label { Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(150, 200, 255), Location = new System.Drawing.Point(15, 42), Size = new System.Drawing.Size(680, 20) };

            btnThem = FormHelper.TaoNut("+ Tao HD", Color.FromArgb(0, 150, 100), 720, 10, 105, 33);
            btnHuy = FormHelper.TaoNut("Huy HD", Color.FromArgb(190, 45, 60), 835, 10, 100, 33);
            btnXemCT = FormHelper.TaoNut("Chi tiet", Color.FromArgb(100, 60, 200), 945, 10, 105, 33);
            btnLamMoi = FormHelper.TaoNut("Lam moi", Color.FromArgb(55, 75, 125), 1060, 10, 100, 33);

            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
            btnXemCT.Click += BtnXemCT_Click;
            btnLamMoi.Click += (s, e) => { FormHelper.ResetTxt(txtTK, ph); cboLoc.SelectedIndex = 0; TaiDanhSach(); };
            txtTK.TextChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            cboLoc.SelectedIndexChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            dgv.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) BtnXemCT_Click(s, e); };

            var panelTop = new Panel { BackColor = Color.FromArgb(18, 24, 44), Dock = DockStyle.Top, Height = 65 };
            panelTop.Controls.AddRange(new Control[] { txtTK, cboLoc, lblTong, lblStat, btnThem, btnHuy, btnXemCT, btnLamMoi });
            var lblTitle = FormHelper.TaoLabelTitle("Quan ly Hop dong", Color.FromArgb(150, 100, 255));
            this.Controls.Add(dgv); this.Controls.Add(panelTop); this.Controls.Add(lblTitle);
        }

        private void TaiDanhSach(string kw = "", string tt = "Tat ca")
        {
            string q = @"SELECT hd.MaHD [Ma HD], sv.MaSV [Ma SV], sv.HoTen [Ho Ten SV],
                         p.MaPhong [Ma Phong], p.TenPhong [Ten Phong], nv.HoTen [NV Lap],
                         CONVERT(varchar,hd.NgayBatDau,103) [Ngay BD],
                         CONVERT(varchar,hd.NgayKetThuc,103) [Ngay KT],
                         CAST(hd.TienCoc AS NVARCHAR) + N' d' [Tien Coc],
                         hd.TrangThai [Trang Thai],
                         CONVERT(varchar,hd.NgayTao,103) [Ngay Tao]
                         FROM HopDong hd
                         JOIN SinhVien sv ON hd.MaSV    = sv.MaSV
                         JOIN Phong    p  ON hd.MaPhong = p.MaPhong
                         JOIN NhanVien nv ON hd.MaNV    = nv.MaNV
                         WHERE 1=1";
            var ps = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(kw))
            {
                q += " AND (hd.MaHD LIKE @kw OR sv.MaSV LIKE @kw OR sv.HoTen LIKE @kw OR p.MaPhong LIKE @kw)";
                ps.Add(new SqlParameter("@kw", "%" + kw + "%"));
            }
            if (tt != "Tat ca") { q += " AND hd.TrangThai=@tt"; ps.Add(new SqlParameter("@tt", tt)); }
            q += " ORDER BY hd.NgayTao DESC";
            var dt = DatabaseHelper.ExecuteQuery(q, ps.ToArray());
            dgv.DataSource = dt;
            lblTong.Text = "Tong: " + dt.Rows.Count + " hop dong";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string s = row.Cells["Trang Thai"].Value?.ToString();
                row.DefaultCellStyle.ForeColor =
                    s == "Dang hieu luc" ? Color.FromArgb(80, 220, 140) :
                    s == "Het han" ? Color.FromArgb(255, 200, 0) : Color.FromArgb(180, 80, 80);
            }

            int hL = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HopDong WHERE TrangThai=N'Dang hieu luc'") ?? 0);
            int hH = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HopDong WHERE TrangThai=N'Het han'") ?? 0);
            int hC = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HopDong WHERE TrangThai=N'Da huy'") ?? 0);
            lblStat.Text = "Dang hieu luc: " + hL + "    Het han: " + hH + "    Da huy: " + hC;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            using (var f = new FormTaoHopDongAdmin())
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon hop dong!"); return; }
            string ma = dgv.CurrentRow.Cells["Ma HD"].Value?.ToString();
            string tt = dgv.CurrentRow.Cells["Trang Thai"].Value?.ToString();
            if (tt != "Dang hieu luc") { Warn("Chi huy duoc hop dong dang hieu luc!"); return; }
            if (MessageBox.Show("Huy hop dong " + ma + "?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var dt = DatabaseHelper.ExecuteQuery("SELECT MaPhong FROM HopDong WHERE MaHD=@m", new SqlParameter[] { new SqlParameter("@m", ma) });
                if (dt.Rows.Count > 0)
                {
                    string mp = dt.Rows[0]["MaPhong"].ToString();
                    DatabaseHelper.ExecuteNonQuery("UPDATE HopDong SET TrangThai=N'Da huy' WHERE MaHD=@m", new SqlParameter[] { new SqlParameter("@m", ma) });
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Phong SET SoNguoiHienTai=CASE WHEN SoNguoiHienTai>0 THEN SoNguoiHienTai-1 ELSE 0 END, TrangThai=CASE WHEN SoNguoiHienTai<=1 THEN N'Con cho' ELSE TrangThai END WHERE MaPhong=@p",
                        new SqlParameter[] { new SqlParameter("@p", mp) });
                }
                TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
                MessageBox.Show("Da huy hop dong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnXemCT_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon hop dong!"); return; }
            string info = "";
            foreach (DataGridViewCell cell in dgv.CurrentRow.Cells)
                info += string.Format("{0,-22}: {1}\n", dgv.Columns[cell.ColumnIndex].HeaderText, cell.Value);
            MessageBox.Show(info, "Chi tiet Hop dong", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Warn(string m) => MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

 
    public class FormTaoHopDongAdmin : Form
    {
        private TextBox txtMaHD, txtMaSV, txtTienCoc, txtGhiChu;
        private ComboBox cboPhong;
        private DateTimePicker dtpBD, dtpKT;
        private Label lblGia;
        private Button btnLuu, btnHuy;
        private DataTable _dtPhong = new DataTable();

        public FormTaoHopDongAdmin()
        {
            XayDung();
            TaiPhong();
        }

        private void XayDung()
        {
            this.Text = "Tao Hop Dong Moi";
            this.BackColor = Color.FromArgb(18, 24, 44);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            int y = 55; int tx = 160; int tw = 320;
            var title = new Label { Text = "TAO HOP DONG THUE PHONG", Font = new Font("Segoe UI", 13F, FontStyle.Bold), ForeColor = Color.FromArgb(150, 100, 255), Size = new System.Drawing.Size(500, 38), Location = new System.Drawing.Point(0, 10), TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            this.Controls.Add(title);

            Action<string, int> LB = (t, top) => this.Controls.Add(new Label { Text = t, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(0, 210, 255), Location = new System.Drawing.Point(15, top + 3), AutoSize = true });
            Func<int, TextBox> TB = (top) => { var t = new TextBox { Font = new Font("Segoe UI", 10F), BackColor = Color.FromArgb(28, 36, 64), ForeColor = Color.FromArgb(220, 233, 255), BorderStyle = BorderStyle.FixedSingle, Location = new System.Drawing.Point(tx, top), Size = new System.Drawing.Size(tw, 28) }; this.Controls.Add(t); return t; };

            LB("Ma HD *", y); txtMaHD = TB(y); y += 38;
            LB("Ma SV *", y); txtMaSV = TB(y); y += 38;

            LB("Phong *", y);
            cboPhong = new ComboBox { Font = new Font("Segoe UI", 9F), BackColor = Color.FromArgb(28, 36, 64), ForeColor = Color.FromArgb(220, 233, 255), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(tw, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cboPhong.SelectedIndexChanged += (s, e) => CapNhatGia();
            this.Controls.Add(cboPhong); y += 38;

            lblGia = new Label { Font = new Font("Segoe UI", 9F, FontStyle.Italic), ForeColor = Color.FromArgb(0, 200, 130), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(tw, 20), Text = "Chon phong de xem gia thue" };
            this.Controls.Add(lblGia); y += 26;

            LB("Ngay bat dau *", y);
            dtpBD = new DateTimePicker { Font = new Font("Segoe UI", 10F), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(190, 28), Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpBD); y += 38;

            LB("Ngay ket thuc *", y);
            dtpKT = new DateTimePicker { Font = new Font("Segoe UI", 10F), Location = new System.Drawing.Point(tx, y), Size = new System.Drawing.Size(190, 28), Format = DateTimePickerFormat.Short };
            dtpKT.Value = DateTime.Today.AddMonths(6);
            this.Controls.Add(dtpKT); y += 38;

            LB("Tien coc", y); txtTienCoc = TB(y); txtTienCoc.Text = "0"; y += 38;
            LB("Ghi chu", y); txtGhiChu = TB(y); y += 38;

            btnLuu = new Button { Text = "Luu", BackColor = Color.FromArgb(0, 150, 100), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx, y + 10), Size = new System.Drawing.Size(150, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnHuy = new Button { Text = "Huy", BackColor = Color.FromArgb(150, 40, 50), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx + 165, y + 10), Size = new System.Drawing.Size(150, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnHuy.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnLuu); this.Controls.Add(btnHuy);
            this.ClientSize = new System.Drawing.Size(500, y + 65);
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e2) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void TaiPhong()
        {
            _dtPhong = DatabaseHelper.ExecuteQuery(
                "SELECT MaPhong, TenPhong, LoaiPhong, GiaThue FROM Phong WHERE TrangThai=N'Con cho' ORDER BY MaPhong");
            cboPhong.Items.Clear();
            foreach (DataRow r in _dtPhong.Rows)
                cboPhong.Items.Add(r["MaPhong"] + " - " + r["TenPhong"] + " (" + r["LoaiPhong"] + ")");
            if (cboPhong.Items.Count > 0) cboPhong.SelectedIndex = 0;
        }

        private void CapNhatGia()
        {
            int i = cboPhong.SelectedIndex;
            if (i < 0 || i >= _dtPhong.Rows.Count) return;
            decimal gia = Convert.ToDecimal(_dtPhong.Rows[i]["GiaThue"]);
            lblGia.Text = "Gia thue: " + gia.ToString("N0") + " d/thang";
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim(), maSV = txtMaSV.Text.Trim();
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSV)) { Warn("Ma HD va Ma SV khong duoc de trong!"); return; }
            if (cboPhong.SelectedIndex < 0) { Warn("Chon phong!"); return; }
            if (dtpKT.Value <= dtpBD.Value) { Warn("Ngay ket thuc phai sau ngay bat dau!"); return; }
            decimal coc; if (!decimal.TryParse(txtTienCoc.Text, out coc) || coc < 0) { Warn("Tien coc khong hop le!"); return; }

            string maPhong = _dtPhong.Rows[cboPhong.SelectedIndex]["MaPhong"].ToString();

            int svEx = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM SinhVien WHERE MaSV=@m AND TrangThai=1", new SqlParameter[] { new SqlParameter("@m", maSV) }));
            if (svEx == 0) { Warn("Ma SV khong ton tai hoac da bi vo hieu!"); return; }

            int hdEx = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HopDong WHERE MaSV=@m AND TrangThai=N'Dang hieu luc'", new SqlParameter[] { new SqlParameter("@m", maSV) }));
            if (hdEx > 0) { Warn("SV nay da co hop dong dang hieu luc!"); return; }

            int dup = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM HopDong WHERE MaHD=@m", new SqlParameter[] { new SqlParameter("@m", maHD) }));
            if (dup > 0) { Warn("Ma hop dong da ton tai!"); return; }

            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO HopDong(MaHD,MaSV,MaPhong,MaNV,NgayBatDau,NgayKetThuc,TienCoc,GhiChu,TrangThai) VALUES(@mh,@ms,@mp,@mn,@bd,@kt,@tc,@gc,N'Dang hieu luc')",
                    new SqlParameter[] { new SqlParameter("@mh", maHD), new SqlParameter("@ms", maSV), new SqlParameter("@mp", maPhong), new SqlParameter("@mn", SessionManager.MaTaiKhoan), new SqlParameter("@bd", dtpBD.Value.Date), new SqlParameter("@kt", dtpKT.Value.Date), new SqlParameter("@tc", coc), new SqlParameter("@gc", txtGhiChu.Text.Trim()) });

                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Phong SET SoNguoiHienTai=SoNguoiHienTai+1, TrangThai=CASE WHEN SoNguoiHienTai+1>=SoNguoiToiDa THEN N'Day' ELSE N'Con cho' END WHERE MaPhong=@p",
                    new SqlParameter[] { new SqlParameter("@p", maPhong) });

                MessageBox.Show("Tao hop dong thanh cong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex) { MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Warn(string m) => MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}