-- ============================================================
--  DATABASE: QUAN LY KY TUC XA
--  Tac gia : Vo Tiec Cuong
--  Ngay    : 2026
--  DBMS    : SQL Server 2019+
--  *** Da chinh sua gia tri TrangThai khop voi code C# ***
-- ============================================================

-- ── 1. TAO DATABASE ─────────────────────────────────────────
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLyKTX')
BEGIN
    CREATE DATABASE QuanLyKTX;
END
GO

USE QuanLyKTX;
GO

-- ============================================================
--  XOA BANG THEO THU TU NGUOC (tranh loi khoa ngoai)
-- ============================================================
IF OBJECT_ID('ViPham',  'U') IS NOT NULL DROP TABLE ViPham;
IF OBJECT_ID('HoaDon',  'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('HopDong', 'U') IS NOT NULL DROP TABLE HopDong;
IF OBJECT_ID('Phong',   'U') IS NOT NULL DROP TABLE Phong;
IF OBJECT_ID('SinhVien','U') IS NOT NULL DROP TABLE SinhVien;
IF OBJECT_ID('NhanVien','U') IS NOT NULL DROP TABLE NhanVien;
GO

-- ============================================================
--  BANG 1: NhanVien
-- ============================================================
CREATE TABLE NhanVien (
    MaNV        VARCHAR(10)   NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    GioiTinh    NVARCHAR(5)   NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nu')),
    NgaySinh    DATE          NOT NULL,
    SoDienThoai VARCHAR(10)   NOT NULL,
    Email       VARCHAR(100)  NOT NULL,
    ChucVu      NVARCHAR(50)  NOT NULL,
    TenDangNhap VARCHAR(50)   NOT NULL UNIQUE,
    MatKhau     VARCHAR(255)  NOT NULL,
    NgayVaoLam  DATE          NOT NULL DEFAULT GETDATE(),
    TrangThai   BIT           NOT NULL DEFAULT 1,   -- 1: Dang lam, 0: Nghi viec
    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)
);
GO

-- ============================================================
--  BANG 2: SinhVien
-- ============================================================
CREATE TABLE SinhVien (
    MaSV        VARCHAR(10)    NOT NULL,
    HoTen       NVARCHAR(100)  NOT NULL,
    GioiTinh    NVARCHAR(5)    NOT NULL CHECK (GioiTinh IN (N'Nam', N'Nu')),
    NgaySinh    DATE           NOT NULL,
    CCCD        VARCHAR(12)    NOT NULL UNIQUE,
    SoDienThoai VARCHAR(10)    NOT NULL,
    Email       VARCHAR(100)   NOT NULL,
    DiaChi      NVARCHAR(200)  NOT NULL,
    Lop         NVARCHAR(20)   NOT NULL,
    Khoa        NVARCHAR(100)  NOT NULL,
    TenDangNhap VARCHAR(50)    NOT NULL UNIQUE,
    MatKhau     VARCHAR(255)   NOT NULL,
    NgayDangKy  DATETIME       NOT NULL DEFAULT GETDATE(),
    TrangThai   BIT            NOT NULL DEFAULT 1,  -- 1: Dang o, 0: Da roi
    CONSTRAINT PK_SinhVien PRIMARY KEY (MaSV)
);
GO

-- ============================================================
--  BANG 3: Phong
--  TrangThai khop voi code C#:
--    'Con cho'       (FormQuanLyPhong)
--    'Day'           (FormQuanLyPhong)
--    'Dang sua chua' (FormQuanLyPhong)
-- ============================================================
CREATE TABLE Phong (
    MaPhong        VARCHAR(10)   NOT NULL,
    TenPhong       NVARCHAR(50)  NOT NULL,
    LoaiPhong      NVARCHAR(50)  NOT NULL,
    Tang           INT           NOT NULL,
    SoNguoiToiDa   INT           NOT NULL,
    SoNguoiHienTai INT           NOT NULL DEFAULT 0,
    GiaThue        DECIMAL(10,2) NOT NULL,
    MoTa           NVARCHAR(300) NULL,
    TrangThai      NVARCHAR(20)  NOT NULL DEFAULT N'Con cho'
        CHECK (TrangThai IN (N'Con cho', N'Day', N'Dang sua chua')),
    CONSTRAINT PK_Phong PRIMARY KEY (MaPhong)
);
GO

-- ============================================================
--  BANG 4: HopDong
--  TrangThai khop voi code C#:
--    'Dang hieu luc' (FormQuanLyHopDong)
--    'Het han'       (FormQuanLyHopDong)
--    'Da huy'        (FormQuanLyHopDong)
-- ============================================================
CREATE TABLE HopDong (
    MaHD        VARCHAR(10)   NOT NULL,
    MaSV        VARCHAR(10)   NOT NULL,
    MaPhong     VARCHAR(10)   NOT NULL,
    MaNV        VARCHAR(10)   NOT NULL,
    NgayBatDau  DATE          NOT NULL,
    NgayKetThuc DATE          NOT NULL,
    TienCoc     DECIMAL(10,2) NOT NULL DEFAULT 0,
    GhiChu      NVARCHAR(300) NULL,
    TrangThai   NVARCHAR(20)  NOT NULL DEFAULT N'Dang hieu luc'
        CHECK (TrangThai IN (N'Dang hieu luc', N'Het han', N'Da huy')),
    NgayTao     DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_HopDong    PRIMARY KEY (MaHD),
    CONSTRAINT FK_HD_SinhVien FOREIGN KEY (MaSV)    REFERENCES SinhVien(MaSV),
    CONSTRAINT FK_HD_Phong    FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_HD_NhanVien FOREIGN KEY (MaNV)    REFERENCES NhanVien(MaNV),
    CONSTRAINT CHK_HopDong_Ngay CHECK (NgayKetThuc > NgayBatDau)
);
GO

-- ============================================================
--  BANG 5: HoaDon
--  TrangThai khop voi code C#:
--    'Chua thanh toan' (FormQuanLyHoaDon)
--    'Da thanh toan'   (FormQuanLyHoaDon)
--    'Qua han'         (FormQuanLyHoaDon)
-- ============================================================
CREATE TABLE HoaDon (
    MaHD_HoaDon  VARCHAR(10)   NOT NULL,
    MaHD         VARCHAR(10)   NOT NULL,
    MaSV         VARCHAR(10)   NOT NULL,
    MaPhong      VARCHAR(10)   NOT NULL,
    ThangNam     VARCHAR(7)    NOT NULL,   -- YYYY-MM
    TienPhong    DECIMAL(10,2) NOT NULL,
    TienDien     DECIMAL(10,2) NOT NULL DEFAULT 0,
    TienNuoc     DECIMAL(10,2) NOT NULL DEFAULT 0,
    TienDichVu   DECIMAL(10,2) NOT NULL DEFAULT 0,
    TongTien     AS (TienPhong + TienDien + TienNuoc + TienDichVu) PERSISTED,
    HanThanhToan DATE          NOT NULL,
    NgayThanhToan DATE         NULL,
    TrangThai    NVARCHAR(20)  NOT NULL DEFAULT N'Chua thanh toan'
        CHECK (TrangThai IN (N'Chua thanh toan', N'Da thanh toan', N'Qua han')),
    GhiChu       NVARCHAR(300) NULL,
    MaNV         VARCHAR(10)   NOT NULL,
    NgayTao      DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_HoaDon       PRIMARY KEY (MaHD_HoaDon),
    CONSTRAINT FK_HoaDon_HD    FOREIGN KEY (MaHD)    REFERENCES HopDong(MaHD),
    CONSTRAINT FK_HoaDon_SV    FOREIGN KEY (MaSV)    REFERENCES SinhVien(MaSV),
    CONSTRAINT FK_HoaDon_Phong FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong),
    CONSTRAINT FK_HoaDon_NV    FOREIGN KEY (MaNV)    REFERENCES NhanVien(MaNV)
);
GO

-- ============================================================
--  BANG 6: ViPham
--  TrangThai khop voi code C#:
--    'Chua xu ly'  (FormQuanLyViPham)
--    'Da xu ly'    (FormQuanLyViPham)
--    'Da nop phat' (FormQuanLyViPham)
-- ============================================================
CREATE TABLE ViPham (
    MaVP       VARCHAR(10)   NOT NULL,
    MaSV       VARCHAR(10)   NOT NULL,
    MaNV       VARCHAR(10)   NOT NULL,
    LoaiViPham NVARCHAR(100) NOT NULL,
    MoTa       NVARCHAR(500) NOT NULL,
    NgayViPham DATE          NOT NULL,
    MucPhat    DECIMAL(10,2) NOT NULL DEFAULT 0,
    TrangThai  NVARCHAR(20)  NOT NULL DEFAULT N'Chua xu ly'
        CHECK (TrangThai IN (N'Chua xu ly', N'Da xu ly', N'Da nop phat')),
    NgayXuLy   DATE          NULL,
    GhiChu     NVARCHAR(300) NULL,
    NgayTao    DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_ViPham      PRIMARY KEY (MaVP),
    CONSTRAINT FK_VP_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    CONSTRAINT FK_VP_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

-- ============================================================
--  DU LIEU MAU - Nhan vien admin de dang nhap lan dau
-- ============================================================
INSERT INTO NhanVien (MaNV, HoTen, GioiTinh, NgaySinh, SoDienThoai, Email,
                      ChucVu, TenDangNhap, MatKhau, NgayVaoLam, TrangThai)
VALUES
('NV001', N'Quan Tri Vien', N'Nam', '2000-01-01', '0900000001',
 'admin@ktx.edu.vn', N'Quan ly', 'admin', '123456', GETDATE(), 1),

('NV002', N'Nguyen Van Quan Ly', N'Nam', '1985-05-15', '0900000002',
 'quanly@ktx.edu.vn', N'Ke toan', 'quanly', '123456', GETDATE(), 1);
GO

-- ============================================================
--  DU LIEU MAU - Phong
-- ============================================================
INSERT INTO Phong (MaPhong, TenPhong, LoaiPhong, Tang, SoNguoiToiDa, SoNguoiHienTai, GiaThue, MoTa, TrangThai)
VALUES
('P101', N'Phong 101', N'4 nguoi', 1, 4, 0, 800000,  N'Phong tieu chuan tang 1', N'Con cho'),
('P102', N'Phong 102', N'4 nguoi', 1, 4, 0, 800000,  N'Phong tieu chuan tang 1', N'Con cho'),
('P103', N'Phong 103', N'6 nguoi', 1, 6, 0, 650000,  N'Phong 6 nguoi tang 1',    N'Con cho'),
('P201', N'Phong 201', N'4 nguoi', 2, 4, 0, 850000,  N'Phong tieu chuan tang 2', N'Con cho'),
('P202', N'Phong 202', N'4 nguoi', 2, 4, 0, 850000,  N'Phong tieu chuan tang 2', N'Con cho'),
('P203', N'Phong 203', N'6 nguoi', 2, 6, 0, 700000,  N'Phong 6 nguoi tang 2',    N'Con cho'),
('P301', N'Phong 301', N'2 nguoi', 3, 2, 0, 1200000, N'Phong doi tang 3',        N'Con cho'),
('P302', N'Phong 302', N'VIP',     3, 2, 0, 1500000, N'Phong VIP tang 3',        N'Con cho'),
('P401', N'Phong 401', N'8 nguoi', 4, 8, 0, 500000,  N'Phong 8 nguoi tang 4',    N'Con cho'),
('P402', N'Phong 402', N'8 nguoi', 4, 8, 0, 500000,  N'Phong 8 nguoi tang 4',    N'Dang sua chua');
GO

-- ============================================================
--  VIEW phu hop voi gia tri moi (khong dau)
-- ============================================================
CREATE OR ALTER VIEW V_ThongTinPhong AS
SELECT
    p.MaPhong, p.TenPhong, p.LoaiPhong, p.Tang,
    p.SoNguoiToiDa, p.SoNguoiHienTai,
    (p.SoNguoiToiDa - p.SoNguoiHienTai) AS SoChoTrong,
    p.GiaThue, p.TrangThai
FROM Phong p;
GO

CREATE OR ALTER VIEW V_HopDongHienLuc AS
SELECT
    hd.MaHD, sv.MaSV, sv.HoTen AS TenSinhVien, sv.SoDienThoai,
    p.MaPhong, p.TenPhong, p.LoaiPhong, p.GiaThue,
    hd.NgayBatDau, hd.NgayKetThuc, hd.TrangThai
FROM HopDong hd
JOIN SinhVien sv ON hd.MaSV    = sv.MaSV
JOIN Phong    p  ON hd.MaPhong = p.MaPhong
WHERE hd.TrangThai = N'Dang hieu luc';
GO

CREATE OR ALTER VIEW V_HoaDonChuaThanhToan AS
SELECT
    h.MaHD_HoaDon, sv.HoTen AS TenSinhVien, sv.SoDienThoai,
    p.TenPhong, h.ThangNam, h.TongTien, h.HanThanhToan,
    DATEDIFF(DAY, h.HanThanhToan, GETDATE()) AS SoNgayTreHan
FROM HoaDon h
JOIN SinhVien sv ON h.MaSV    = sv.MaSV
JOIN Phong    p  ON h.MaPhong = p.MaPhong
WHERE h.TrangThai = N'Chua thanh toan';
GO

CREATE OR ALTER VIEW V_ViPhamChuaXuLy AS
SELECT
    vp.MaVP, sv.HoTen AS TenSinhVien, sv.Lop,
    vp.LoaiViPham, vp.MoTa, vp.NgayViPham, vp.MucPhat,
    nv.HoTen AS NhanVienGhiNhan
FROM ViPham vp
JOIN SinhVien sv ON vp.MaSV = sv.MaSV
JOIN NhanVien nv ON vp.MaNV = nv.MaNV
WHERE vp.TrangThai = N'Chua xu ly';
GO

-- ============================================================
--  KIEM TRA NHANH
-- ============================================================
SELECT 'NhanVien' AS Bang, COUNT(*) AS SoBan FROM NhanVien
UNION ALL
SELECT 'Phong',    COUNT(*) FROM Phong
UNION ALL
SELECT 'SinhVien', COUNT(*) FROM SinhVien
UNION ALL
SELECT 'HopDong',  COUNT(*) FROM HopDong
UNION ALL
SELECT 'HoaDon',   COUNT(*) FROM HoaDon
UNION ALL
SELECT 'ViPham',   COUNT(*) FROM ViPham;
GO

PRINT N'Tao database QuanLyKTX thanh cong!';
PRINT N'Tai khoan admin mac dinh: TenDangNhap = admin | MatKhau = 123456';
GO