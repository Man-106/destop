using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public class FormQuanLyViPhamAdmin : Form
    {
        private DataGridView dgv;
        private TextBox txtTK;
        private Label lblTong, lblStat;
        private Button btnThem, btnXuLy, btnXemCT, btnXoa, btnLamMoi;
        private ComboBox cboLoc;

        public FormQuanLyViPhamAdmin()
        {
            XayDungGD();
            TaiDanhSach();
        }

        private void XayDungGD()
        {
            this.Text = "Quan ly Vi pham";
            this.BackColor = Color.FromArgb(14, 20, 42);
            this.ClientSize = new System.Drawing.Size(1260, 620);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = FormHelper.TaoDGV();

            string ph = "Tim ma VP, ma SV, ho ten, loai vi pham...";
            txtTK = FormHelper.TaoTxt(ph, 15, 14, 295);

            cboLoc = new ComboBox
            {
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.FromArgb(35, 48, 82),
                ForeColor = Color.FromArgb(220, 233, 255),
                Location = new System.Drawing.Point(320, 14),
                Size = new System.Drawing.Size(185, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboLoc.Items.AddRange(new object[] { "Tat ca", "Chua xu ly", "Da xu ly", "Da nop phat" });
            cboLoc.SelectedIndex = 0;

            lblTong = new Label { Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(140, 170, 210), Location = new System.Drawing.Point(515, 17), Size = new System.Drawing.Size(195, 22) };
            lblStat = new Label { Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.FromArgb(255, 140, 140), Location = new System.Drawing.Point(15, 42), Size = new System.Drawing.Size(700, 20) };

            btnThem = FormHelper.TaoNut("+ Them VP", Color.FromArgb(0, 150, 100), 710, 10, 105, 33);
            btnXuLy = FormHelper.TaoNut("Xu ly", Color.FromArgb(0, 130, 200), 825, 10, 90, 33);
            btnXemCT = FormHelper.TaoNut("Chi tiet", Color.FromArgb(100, 60, 200), 925, 10, 105, 33);
            btnXoa = FormHelper.TaoNut("Xoa", Color.FromArgb(190, 45, 60), 1040, 10, 85, 33);
            btnLamMoi = FormHelper.TaoNut("Lam moi", Color.FromArgb(55, 75, 125), 1135, 10, 100, 33);

            btnThem.Click += BtnThem_Click;
            btnXuLy.Click += BtnXuLy_Click;
            btnXemCT.Click += BtnXemCT_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLamMoi.Click += (s, e) => { FormHelper.ResetTxt(txtTK, ph); cboLoc.SelectedIndex = 0; TaiDanhSach(); };
            txtTK.TextChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            cboLoc.SelectedIndexChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            dgv.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) BtnXemCT_Click(s, e); };

            var panelTop = new Panel { BackColor = Color.FromArgb(18, 24, 44), Dock = DockStyle.Top, Height = 65 };
            panelTop.Controls.AddRange(new Control[] { txtTK, cboLoc, lblTong, lblStat, btnThem, btnXuLy, btnXemCT, btnXoa, btnLamMoi });
            var lblTitle = FormHelper.TaoLabelTitle("Quan ly Vi pham", Color.FromArgb(255, 90, 90));
            this.Controls.Add(dgv); this.Controls.Add(panelTop); this.Controls.Add(lblTitle);
        }

        private void TaiDanhSach(string kw = "", string tt = "Tat ca")
        {
            string q = @"SELECT vp.MaVP [Ma VP], sv.MaSV [Ma SV], sv.HoTen [Ho Ten SV], sv.Lop,
                         vp.LoaiViPham [Loai Vi Pham], vp.MoTa [Mo Ta],
                         CONVERT(varchar,vp.NgayViPham,103) [Ngay VP],
                         CAST(vp.MucPhat AS NVARCHAR) + N' d' [Muc Phat],
                         vp.TrangThai [Trang Thai],
                         CASE WHEN vp.NgayXuLy IS NULL THEN N'Chua' ELSE CONVERT(varchar,vp.NgayXuLy,103) END [Ngay XL],
                         nv.HoTen [NV Ghi Nhan]
                         FROM ViPham vp
                         JOIN SinhVien sv ON vp.MaSV = sv.MaSV
                         JOIN NhanVien nv ON vp.MaNV = nv.MaNV
                         WHERE 1=1";
            var ps = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(kw))
            {
                q += " AND (vp.MaVP LIKE @kw OR sv.MaSV LIKE @kw OR sv.HoTen LIKE @kw OR vp.LoaiViPham LIKE @kw)";
                ps.Add(new SqlParameter("@kw", "%" + kw + "%"));
            }
            if (tt != "Tat ca") { q += " AND vp.TrangThai=@tt"; ps.Add(new SqlParameter("@tt", tt)); }
            q += " ORDER BY vp.NgayViPham DESC";

            var dt = DatabaseHelper.ExecuteQuery(q, ps.ToArray());
            dgv.DataSource = dt;
            lblTong.Text = "Tong: " + dt.Rows.Count + " vi pham";

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string s = row.Cells["Trang Thai"].Value?.ToString();
                row.DefaultCellStyle.ForeColor =
                    s == "Da nop phat" ? Color.FromArgb(80, 220, 140) :
                    s == "Da xu ly" ? Color.FromArgb(180, 220, 255) :
                                         Color.FromArgb(255, 100, 100);
            }

            int chua = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM ViPham WHERE TrangThai=N'Chua xu ly'") ?? 0);
            int daxl = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM ViPham WHERE TrangThai=N'Da xu ly'") ?? 0);
            int nopP = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM ViPham WHERE TrangThai=N'Da nop phat'") ?? 0);
            object tP = DatabaseHelper.ExecuteScalar("SELECT SUM(MucPhat) FROM ViPham WHERE TrangThai=N'Chua xu ly'");
            decimal tongPhat = (tP == null || tP == DBNull.Value) ? 0 : Convert.ToDecimal(tP);
            lblStat.Text = "Chua xu ly: " + chua + "    Da xu ly: " + daxl +
                           "    Da nop phat: " + nopP + "    Tong phat cho: " + tongPhat.ToString("N0") + " d";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            using (var f = new FormChiTietViPham())
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach();
        }

        private void BtnXuLy_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon vi pham!"); return; }
            string ma = dgv.CurrentRow.Cells["Ma VP"].Value?.ToString();
            string tt = dgv.CurrentRow.Cells["Trang Thai"].Value?.ToString();
            if (tt == "Da nop phat") { Warn("Vi pham nay da xu ly xong!"); return; }

            var frm = new Form
            {
                Text = "Xu ly vi pham " + ma,
                BackColor = Color.FromArgb(18, 24, 44),
                ClientSize = new System.Drawing.Size(400, 175),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false
            };
            var lbl = new Label
            {
                Text = "Chon trang thai xu ly:",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(220, 233, 255),
                Location = new System.Drawing.Point(15, 18),
                Size = new System.Drawing.Size(365, 26)
            };
            var cbo = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(28, 36, 64),
                ForeColor = Color.FromArgb(220, 233, 255),
                Location = new System.Drawing.Point(15, 52),
                Size = new System.Drawing.Size(365, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbo.Items.AddRange(new object[] { "Da xu ly", "Da nop phat" });
            cbo.SelectedIndex = 0;

            var btnOK = new Button
            {
                Text = "Xac nhan",
                BackColor = Color.FromArgb(0, 140, 100),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new System.Drawing.Point(15, 110),
                Size = new System.Drawing.Size(170, 38),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnOK.FlatAppearance.BorderSize = 0;

            var btnHuy2 = new Button
            {
                Text = "Huy",
                BackColor = Color.FromArgb(150, 40, 50),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new System.Drawing.Point(200, 110),
                Size = new System.Drawing.Size(170, 38),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnHuy2.FlatAppearance.BorderSize = 0;

            btnOK.Click += (ss, ee) =>
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE ViPham SET TrangThai=@tt, NgayXuLy=GETDATE() WHERE MaVP=@m",
                    new SqlParameter[] { new SqlParameter("@tt", cbo.Text), new SqlParameter("@m", ma) });
                frm.DialogResult = DialogResult.OK;
                frm.Close();
            };
            btnHuy2.Click += (ss, ee) => { frm.DialogResult = DialogResult.Cancel; frm.Close(); };

            frm.Controls.AddRange(new Control[] { lbl, cbo, btnOK, btnHuy2 });
            if (frm.ShowDialog() == DialogResult.OK)
                TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
        }

        private void BtnXemCT_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon vi pham!"); return; }
            string info = "";
            foreach (DataGridViewCell cell in dgv.CurrentRow.Cells)
                info += string.Format("{0,-22}: {1}\n", dgv.Columns[cell.ColumnIndex].HeaderText, cell.Value);
            MessageBox.Show(info, "Chi tiet Vi pham", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { Warn("Chon vi pham!"); return; }
            string ma = dgv.CurrentRow.Cells["Ma VP"].Value?.ToString();
            if (MessageBox.Show("Xoa vi pham " + ma + "?", "Xac nhan",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM ViPham WHERE MaVP=@m",
                    new SqlParameter[] { new SqlParameter("@m", ma) });
                TaiDanhSach(FormHelper.LayTK(txtTK), cboLoc.Text);
            }
        }

        private void Warn(string m) =>
            MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

   
    public class FormChiTietViPham : Form
    {
        private TextBox txtMaVP, txtMaSV, txtMoTa, txtMucPhat;
        private ComboBox cboLoai;
        private DateTimePicker dtpNgay;
        private Button btnLuu, btnHuy;

        public FormChiTietViPham()
        {
            XayDung();
        }

        private void XayDung()
        {
            this.Text = "Them Vi Pham";
            this.BackColor = Color.FromArgb(18, 24, 44);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            int y = 55; int tx = 160; int tw = 300;
            var title = new Label
            {
                Text = "GHI NHAN VI PHAM MOI",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 90, 90),
                Size = new System.Drawing.Size(480, 38),
                Location = new System.Drawing.Point(0, 10),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            this.Controls.Add(title);

            Action<string, int> LB = (t, top) => this.Controls.Add(new Label
            {
                Text = t,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 210, 255),
                Location = new System.Drawing.Point(15, top + 3),
                AutoSize = true
            });
            Func<int, TextBox> TB = (top) =>
            {
                var t = new TextBox
                {
                    Font = new Font("Segoe UI", 10F),
                    BackColor = Color.FromArgb(28, 36, 64),
                    ForeColor = Color.FromArgb(220, 233, 255),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new System.Drawing.Point(tx, top),
                    Size = new System.Drawing.Size(tw, 28)
                };
                this.Controls.Add(t);
                return t;
            };

            LB("Ma VP *", y); txtMaVP = TB(y); y += 38;
            LB("Ma SV *", y); txtMaSV = TB(y); y += 38;

            LB("Loai Vi Pham *", y);
            cboLoai = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(28, 36, 64),
                ForeColor = Color.FromArgb(220, 233, 255),
                Location = new System.Drawing.Point(tx, y),
                Size = new System.Drawing.Size(tw, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboLoai.Items.AddRange(new object[]
            {
                "Ve muon", "Gay on ao", "Hut thuoc trong phong",
                "Mang khach la vao", "Khong dong tien dung han",
                "Vi pham ve sinh", "Su dung dien bua bai", "Khac"
            });
            cboLoai.SelectedIndex = 0;
            this.Controls.Add(cboLoai); y += 38;

            LB("Mo ta *", y); txtMoTa = TB(y); y += 38;

            LB("Ngay vi pham *", y);
            dtpNgay = new DateTimePicker
            {
                Font = new Font("Segoe UI", 10F),
                Location = new System.Drawing.Point(tx, y),
                Size = new System.Drawing.Size(190, 28),
                Format = DateTimePickerFormat.Short
            };
            this.Controls.Add(dtpNgay); y += 38;

            LB("Muc phat (d)", y); txtMucPhat = TB(y); txtMucPhat.Text = "0"; y += 38;

            btnLuu = new Button
            {
                Text = "Luu",
                BackColor = Color.FromArgb(0, 150, 100),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new System.Drawing.Point(tx, y + 10),
                Size = new System.Drawing.Size(140, 38),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnLuu.FlatAppearance.BorderSize = 0;

            btnHuy = new Button
            {
                Text = "Huy",
                BackColor = Color.FromArgb(150, 40, 50),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new System.Drawing.Point(tx + 155, y + 10),
                Size = new System.Drawing.Size(140, 38),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            btnHuy.FlatAppearance.BorderSize = 0;

            this.Controls.Add(btnLuu);
            this.Controls.Add(btnHuy);
            this.ClientSize = new System.Drawing.Size(480, y + 62);
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaVP.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string moTa = txtMoTa.Text.Trim();

            if (string.IsNullOrEmpty(ma)) { Warn("Nhap Ma VP!"); return; }
            if (string.IsNullOrEmpty(maSV)) { Warn("Nhap Ma SV!"); return; }
            if (string.IsNullOrEmpty(moTa)) { Warn("Nhap Mo ta!"); return; }

            decimal phat;
            if (!decimal.TryParse(txtMucPhat.Text, out phat) || phat < 0)
            { Warn("Muc phat khong hop le!"); return; }

            int svEx = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM SinhVien WHERE MaSV=@m",
                new SqlParameter[] { new SqlParameter("@m", maSV) }));
            if (svEx == 0) { Warn("Ma SV khong ton tai!"); return; }

            int dup = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM ViPham WHERE MaVP=@m",
                new SqlParameter[] { new SqlParameter("@m", ma) }));
            if (dup > 0) { Warn("Ma VP da ton tai!"); return; }

            try
            {
                DatabaseHelper.ExecuteNonQuery(
                    @"INSERT INTO ViPham(MaVP,MaSV,MaNV,LoaiViPham,MoTa,NgayViPham,MucPhat,TrangThai)
                      VALUES(@mv,@ms,@mn,@lv,@mo,@nd,@mp,N'Chua xu ly')",
                    new SqlParameter[]
                    {
                        new SqlParameter("@mv", ma),
                        new SqlParameter("@ms", maSV),
                        new SqlParameter("@mn", SessionManager.MaTaiKhoan),
                        new SqlParameter("@lv", cboLoai.Text),
                        new SqlParameter("@mo", moTa),
                        new SqlParameter("@nd", dtpNgay.Value.Date),
                        new SqlParameter("@mp", phat)
                    });
                MessageBox.Show("Ghi nhan vi pham thanh cong!", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message, "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Warn(string m) =>
            MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}