// ============================================================
//  FILE: FormQuanLySinhVien.cs
//  Tuong thich: C# 7.3 / .NET Framework 4.7.2
// ============================================================
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DU_AN_DESKTOP_CUOI_KY
{
    public class FormQuanLySinhVienAdmin : Form
    {
        private DataGridView dgv;
        private TextBox txtTK;
        private Label lblTong;
        private Button btnThem, btnSua, btnXoa, btnDoiTT, btnLamMoi;

        public FormQuanLySinhVienAdmin()
        {
            XayDungGD();
            TaiDanhSach();
        }

        private void XayDungGD()
        {
            this.Text = "Quan ly Sinh vien";
            this.BackColor = Color.FromArgb(14, 20, 42);
            this.ClientSize = new System.Drawing.Size(1260, 620);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            dgv = FormHelper.TaoDGV();

            string ph = "Tim ma SV, ho ten, email, lop...";
            txtTK = FormHelper.TaoTxt(ph, 15, 14, 380);

            lblTong = new Label
            {
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(140, 170, 210),
                Location = new System.Drawing.Point(405, 17),
                Size = new System.Drawing.Size(240, 22)
            };

            btnThem = FormHelper.TaoNut("+ Them", Color.FromArgb(0, 150, 100), 650, 10, 105, 33);
            btnSua = FormHelper.TaoNut("Sua", Color.FromArgb(0, 130, 200), 765, 10, 90, 33);
            btnDoiTT = FormHelper.TaoNut("Doi TT", Color.FromArgb(190, 130, 0), 865, 10, 110, 33);
            btnXoa = FormHelper.TaoNut("Xoa", Color.FromArgb(190, 45, 60), 985, 10, 90, 33);
            btnLamMoi = FormHelper.TaoNut("Lam moi", Color.FromArgb(55, 75, 125), 1085, 10, 100, 33);

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnDoiTT.Click += BtnDoiTT_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            txtTK.TextChanged += (s, e) => TaiDanhSach(FormHelper.LayTK(txtTK));
            dgv.CellDoubleClick += DGV_DblClick;

            var panelTop = new Panel
            {
                BackColor = Color.FromArgb(18, 24, 44),
                Dock = DockStyle.Top,
                Height = 55
            };
            panelTop.Controls.AddRange(new Control[]
                { txtTK, lblTong, btnThem, btnSua, btnDoiTT, btnXoa, btnLamMoi });

            var lblTitle = FormHelper.TaoLabelTitle("Quan ly Sinh vien", Color.FromArgb(0, 210, 255));

            this.Controls.Add(dgv);
            this.Controls.Add(panelTop);
            this.Controls.Add(lblTitle);
        }

        private void TaiDanhSach(string kw = "")
        {
            string q = @"SELECT MaSV [Ma SV], HoTen [Ho Ten], GioiTinh [GT],
                         CONVERT(varchar,NgaySinh,103) [Ngay Sinh], CCCD,
                         SoDienThoai [So DT], Email, Lop, Khoa,
                         DiaChi [Dia Chi],
                         CONVERT(varchar,NgayDangKy,103) [Ngay DK],
                         CASE TrangThai WHEN 1 THEN N'Dang o' ELSE N'Da roi' END [TT]
                         FROM SinhVien";
            SqlParameter[] p = null;
            if (!string.IsNullOrEmpty(kw))
            {
                q += " WHERE MaSV LIKE @kw OR HoTen LIKE @kw OR Email LIKE @kw OR SoDienThoai LIKE @kw OR Lop LIKE @kw";
                p = new SqlParameter[] { new SqlParameter("@kw", "%" + kw + "%") };
            }
            q += " ORDER BY MaSV";

            var dt = DatabaseHelper.ExecuteQuery(q, p);
            dgv.DataSource = dt;
            lblTong.Text = "Tong: " + dt.Rows.Count + " sinh vien";

            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Cells["TT"].Value?.ToString() == "Da roi")
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(130, 130, 150);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            using (var f = new FormChiTietSinhVien(null))
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach(FormHelper.LayTK(txtTK));
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            string ma = LayMa(); if (ma == null) return;
            using (var f = new FormChiTietSinhVien(ma))
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach(FormHelper.LayTK(txtTK));
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string ma = LayMa(); if (ma == null) return;
            string ten = dgv.CurrentRow.Cells["Ho Ten"].Value?.ToString();
            int hd = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(1) FROM HopDong WHERE MaSV=@m AND TrangThai=N'Dang hieu luc'",
                new SqlParameter[] { new SqlParameter("@m", ma) }));
            if (hd > 0) { Warn("SV " + ten + " dang co hop dong, khong the xoa!"); return; }
            if (MessageBox.Show("Xoa SV " + ma + " - " + ten + "?", "Xac nhan",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM SinhVien WHERE MaSV=@m",
                    new SqlParameter[] { new SqlParameter("@m", ma) });
                TaiDanhSach(FormHelper.LayTK(txtTK));
            }
        }

        private void BtnDoiTT_Click(object sender, EventArgs e)
        {
            string ma = LayMa(); if (ma == null) return;
            string tt = dgv.CurrentRow.Cells["TT"].Value?.ToString();
            int ttMoi = (tt == "Dang o") ? 0 : 1;
            DatabaseHelper.ExecuteNonQuery("UPDATE SinhVien SET TrangThai=@t WHERE MaSV=@m",
                new SqlParameter[] { new SqlParameter("@t", ttMoi), new SqlParameter("@m", ma) });
            TaiDanhSach(FormHelper.LayTK(txtTK));
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            FormHelper.ResetTxt(txtTK, "Tim ma SV, ho ten, email, lop...");
            TaiDanhSach();
        }

        private void DGV_DblClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string ma = dgv.Rows[e.RowIndex].Cells["Ma SV"].Value?.ToString();
            if (string.IsNullOrEmpty(ma)) return;
            using (var f = new FormChiTietSinhVien(ma))
                if (f.ShowDialog() == DialogResult.OK) TaiDanhSach(FormHelper.LayTK(txtTK));
        }

        private string LayMa()
        {
            if (dgv.CurrentRow == null) { Warn("Vui long chon mot dong!"); return null; }
            return dgv.CurrentRow.Cells["Ma SV"].Value?.ToString();
        }

        private void Warn(string m) =>
            MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    // ════════════════════════════════════════════════════════
    //  FORM THEM / SUA SINH VIEN
    // ════════════════════════════════════════════════════════
    public class FormChiTietSinhVien : Form
    {
        private readonly string _ma;
        private TextBox txtMa, txtHoTen, txtCCCD, txtSDT, txtEmail,
                         txtLop, txtKhoa, txtDiaChi, txtMK;
        private ComboBox cboGT;
        private DateTimePicker dtpNS;
        private Button btnLuu, btnHuy;

        public FormChiTietSinhVien(string maSV)
        {
            _ma = maSV;
            XayDung();
            if (_ma != null) TaiTT();
        }

        private void XayDung()
        {
            this.Text = _ma == null ? "Them Sinh Vien" : "Sua Sinh Vien";
            this.BackColor = Color.FromArgb(18, 24, 44);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            int y = 55; int tx = 155; int tw = 320;

            var title = new Label
            {
                Text = _ma == null ? "THEM SINH VIEN MOI" : "CHINH SUA SINH VIEN",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 210, 255),
                Size = new System.Drawing.Size(490, 38),
                Location = new System.Drawing.Point(0, 10),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            this.Controls.Add(title);

            // Helper tao label
            Action<string, int> LB = (t, top) => this.Controls.Add(new Label
            {
                Text = t,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 210, 255),
                Location = new System.Drawing.Point(15, top + 3),
                AutoSize = true
            });

            // Helper tao textbox
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

            LB("Ma SV *", y); txtMa = TB(y); txtMa.ReadOnly = (_ma != null); y += 38;
            LB("Ho Ten *", y); txtHoTen = TB(y); y += 38;

            LB("Gioi tinh *", y);
            cboGT = new ComboBox
            {
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(28, 36, 64),
                ForeColor = Color.FromArgb(220, 233, 255),
                Location = new System.Drawing.Point(tx, y),
                Size = new System.Drawing.Size(180, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboGT.Items.AddRange(new object[] { "Nam", "Nu" });
            cboGT.SelectedIndex = 0;
            this.Controls.Add(cboGT); y += 38;

            LB("Ngay sinh *", y);
            dtpNS = new DateTimePicker
            {
                Font = new Font("Segoe UI", 10F),
                Location = new System.Drawing.Point(tx, y),
                Size = new System.Drawing.Size(180, 28),
                Format = DateTimePickerFormat.Short,
                MaxDate = DateTime.Today.AddYears(-16)
            };
            dtpNS.Value = DateTime.Today.AddYears(-20);
            this.Controls.Add(dtpNS); y += 38;

            LB("CCCD * (12 so)", y); txtCCCD = TB(y); y += 38;
            LB("So DT * (10 so)", y); txtSDT = TB(y); y += 38;
            LB("Email *", y); txtEmail = TB(y); y += 38;
            LB("Lop *", y); txtLop = TB(y); y += 38;
            LB("Khoa *", y); txtKhoa = TB(y); y += 38;
            LB("Dia chi", y); txtDiaChi = TB(y); y += 38;

            if (_ma == null)
            {
                LB("Mat khau * (>=6)", y);
                txtMK = TB(y);
                txtMK.UseSystemPasswordChar = true;
                y += 38;
            }

            btnLuu = new Button { Text = "Luu", BackColor = Color.FromArgb(0, 150, 100), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx, y + 10), Size = new System.Drawing.Size(150, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnLuu.FlatAppearance.BorderSize = 0;
            btnHuy = new Button { Text = "Huy", BackColor = Color.FromArgb(150, 40, 50), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.White, Location = new System.Drawing.Point(tx + 165, y + 10), Size = new System.Drawing.Size(150, 38), Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            btnHuy.FlatAppearance.BorderSize = 0;
            this.Controls.Add(btnLuu); this.Controls.Add(btnHuy);
            this.ClientSize = new System.Drawing.Size(490, y + 65);
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
        }

        private void TaiTT()
        {
            var dt = DatabaseHelper.ExecuteQuery("SELECT * FROM SinhVien WHERE MaSV=@m",
                new SqlParameter[] { new SqlParameter("@m", _ma) });
            if (dt.Rows.Count == 0) return;
            var r = dt.Rows[0];
            txtMa.Text = r["MaSV"].ToString();
            txtHoTen.Text = r["HoTen"].ToString();
            cboGT.Text = r["GioiTinh"].ToString();
            try { dtpNS.Value = Convert.ToDateTime(r["NgaySinh"]); } catch { }
            txtCCCD.Text = r["CCCD"].ToString();
            txtSDT.Text = r["SoDienThoai"].ToString();
            txtEmail.Text = r["Email"].ToString();
            txtLop.Text = r["Lop"].ToString();
            txtKhoa.Text = r["Khoa"].ToString();
            txtDiaChi.Text = r["DiaChi"].ToString();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string lop = txtLop.Text.Trim();
            string khoa = txtKhoa.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(ma)) { Warn("Nhap Ma SV!"); return; }
            if (string.IsNullOrEmpty(hoTen)) { Warn("Nhap Ho Ten!"); return; }
            if (cccd.Length != 12) { Warn("CCCD phai du 12 so!"); return; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^0\d{9}$"))
            { Warn("So DT khong hop le (10 so, bat dau 0)!"); return; }
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { Warn("Email khong hop le!"); return; }
            if (string.IsNullOrEmpty(lop)) { Warn("Nhap Lop!"); return; }
            if (string.IsNullOrEmpty(khoa)) { Warn("Nhap Khoa!"); return; }

            try
            {
                if (_ma == null) // THEM MOI
                {
                    string mk = txtMK?.Text ?? "";
                    if (mk.Length < 6) { Warn("Mat khau phai >= 6 ky tu!"); return; }
                    int ex = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                        "SELECT COUNT(1) FROM SinhVien WHERE MaSV=@m OR CCCD=@c OR Email=@e",
                        new SqlParameter[] { new SqlParameter("@m", ma), new SqlParameter("@c", cccd), new SqlParameter("@e", email) }));
                    if (ex > 0) { Warn("Ma SV, CCCD hoac Email da ton tai!"); return; }

                    DatabaseHelper.ExecuteNonQuery(@"INSERT INTO SinhVien(MaSV,HoTen,GioiTinh,NgaySinh,CCCD,SoDienThoai,Email,DiaChi,Lop,Khoa,TenDangNhap,MatKhau,NgayDangKy,TrangThai)
                        VALUES(@ma,@ht,@gt,@ns,@cc,@sdt,@em,@dc,@lp,@kh,@ma,@mk,GETDATE(),1)",
                        new SqlParameter[] { new SqlParameter("@ma",ma), new SqlParameter("@ht",hoTen),
                            new SqlParameter("@gt",cboGT.Text), new SqlParameter("@ns",dtpNS.Value.Date),
                            new SqlParameter("@cc",cccd), new SqlParameter("@sdt",sdt),
                            new SqlParameter("@em",email), new SqlParameter("@dc",string.IsNullOrEmpty(diaChi)?"Chua cap nhat":diaChi),
                            new SqlParameter("@lp",lop), new SqlParameter("@kh",khoa), new SqlParameter("@mk",mk) });
                    MessageBox.Show("Them sinh vien thanh cong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // SUA
                {
                    DatabaseHelper.ExecuteNonQuery(@"UPDATE SinhVien SET HoTen=@ht,GioiTinh=@gt,NgaySinh=@ns,CCCD=@cc,SoDienThoai=@sdt,Email=@em,DiaChi=@dc,Lop=@lp,Khoa=@kh WHERE MaSV=@ma",
                        new SqlParameter[] { new SqlParameter("@ht",hoTen), new SqlParameter("@gt",cboGT.Text),
                            new SqlParameter("@ns",dtpNS.Value.Date), new SqlParameter("@cc",cccd),
                            new SqlParameter("@sdt",sdt), new SqlParameter("@em",email),
                            new SqlParameter("@dc",string.IsNullOrEmpty(diaChi)?"Chua cap nhat":diaChi),
                            new SqlParameter("@lp",lop), new SqlParameter("@kh",khoa), new SqlParameter("@ma",ma) });
                    MessageBox.Show("Cap nhat thanh cong!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Warn(string m) =>
            MessageBox.Show(m, "Canh bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}