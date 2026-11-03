

-- 1. BANG CHIEN DICH (Quan ly cac mua du an)
-- Nguon: Header menu "Mua 2025", "Mua 2026" va Section "Bao cao thu - chi"
CREATE TABLE ChienDich (
    IDChienDich INT IDENTITY(1,1) PRIMARY KEY,
    Nam INT NOT NULL,                                   -- Nguon: So nam (2025, 2026)
    TieuDe NVARCHAR(255) NOT NULL,                      -- Nguon: Tieu de chien dich
    LinkBaoCaoThuChi NVARCHAR(1000) NULL,               -- Nguon: The <a> "Xem bao cao chi tiet" (Google Drive link)
    TrangThaiHoatDong BIT DEFAULT 0,                    -- Xac dinh mua chien dich nao dang chay
    NgayTao DATETIME DEFAULT GETDATE()
);

-- 2. BANG CHANG CHIEN DICH (Cac giai doan cua tung mua)
-- Nguon: Section dem nguoc thoi gian ("Chang 1 | TP. HO CHI MINH", "Chang 2...")
CREATE TABLE ChangChienDich (
    IDChang INT IDENTITY(1,1) PRIMARY KEY,
    IDChienDich INT NOT NULL,                           -- Khoa ngoai noi voi bang ChienDich
    TieuDe NVARCHAR(255) NOT NULL,                      -- Nguon: "Chang 1 | TP. HO CHI MINH"
    NhanThoiGian NVARCHAR(255) NOT NULL,                -- Nguon: "Ngay 22 thang 09 nam 2026"
    NgayDienRa DATETIME NULL,                           -- Nguon: "2026-09-22", "2026-09-26T05:30:00+07:00"
    MoTa NVARCHAR(MAX) NULL,                            -- Nguon: "Noi hanh trinh duoc khoi dong..."
    GhiChuTrangThai NVARCHAR(100) NULL,                 -- Nguon: "DA KET THUC" hoac "Hoat dong dang dien ra"
    CONSTRAINT FK_Chang_ChienDich FOREIGN KEY (IDChienDich) REFERENCES ChienDich(IDChienDich)
);

-- 3. BANG DANG KY TNV (Form Dang ky Tinh nguyen vien)
-- Nguon: Chuoi JSON cau hinh form trong the <script> ("id":"langbiang-2026")
CREATE TABLE DangKyTNV (
    IDDangKy INT IDENTITY(1,1) PRIMARY KEY,
    IDChienDich INT NOT NULL,                           -- Dang ky cho mua chien dich nao
    HoTen NVARCHAR(255) NOT NULL,                       -- Nguon JSON: {"name":"name","label":"Ho va ten"}
    Email NVARCHAR(255) NOT NULL,                       -- Nguon JSON: {"name":"email","label":"Email"}
    SoDienThoai VARCHAR(20) NOT NULL,                   -- Nguon JSON: {"name":"phone","label":"So dien thoai"}
    NgaySinh DATE NOT NULL,                             -- Nguon JSON: {"name":"dob","label":"Ngay sinh"}
    DonViCongTac NVARCHAR(255) NULL,                    -- Nguon JSON: {"name":"organization","label":"Don vi hoc tap/cong tac"}
    VaiTroMongMuon NVARCHAR(100) NOT NULL,              -- Nguon JSON: {"name":"role","label":"Ban muon tham gia voi vai tro"}
    LoiNhan NVARCHAR(MAX) NULL,                         -- Nguon JSON: {"name":"message","label":"Loi nhan"}
    LinkAnh NVARCHAR(1000) NOT NULL,                    -- Nguon JSON: {"name":"photo","label":"Anh cua ban"}
    NgayDangKy DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_DangKy_ChienDich FOREIGN KEY (IDChienDich) REFERENCES ChienDich(IDChienDich)
);

-- 4. BANG NHA TAI TRO (Don vi dong hanh)
-- Nguon: Section "DON VI TO CHUC - TAI TRO" (WESET, Pho Huynh Tram...)
CREATE TABLE NhaTaiTro (
    IDNhaTaiTro INT IDENTITY(1,1) PRIMARY KEY,
    IDChienDich INT NOT NULL,                            
    TenNhaTaiTro NVARCHAR(255) NOT NULL,                -- Nguon: alt="Pho Huynh Tram", "WESET..."
    LinkLogo NVARCHAR(1000) NOT NULL,                   -- Nguon: Hinh anh logo (src)
    PhanLoai NVARCHAR(100) NOT NULL,                    -- Nguon: "Don vi to chuc", "Don vi tai tro", "Don vi phoi hop"
    LinkTrangChu NVARCHAR(1000) NULL,                   -- Nguon: Link target URL (The <a> boc logo)
    MoTa NVARCHAR(MAX) NULL,                            -- Nguon JSON: intro cua nha tai tro
    ThuTuHienThi INT DEFAULT 0,                         -- Thu tu sap xep tren web
    CONSTRAINT FK_NhaTaiTro_ChienDich FOREIGN KEY (IDChienDich) REFERENCES ChienDich(IDChienDich)
);

-- 5. BANG TIN TUC (Bai viet & Nhat ky)
-- Nguon: Section "Ban tin - Cau chuyen tu hanh trinh"
CREATE TABLE TinTuc (
    IDTinTuc INT IDENTITY(1,1) PRIMARY KEY,
    IDChienDich INT NULL,                               -- Co the NULL neu la tin tuc chung
    TieuDe NVARCHAR(500) NOT NULL,                      -- Nguon: "TUYEN TINH NGUYEN VIEN..."
    ThePhanLoai NVARCHAR(100) NULL,                     -- Nguon: "THONG BAO 2026", "Hoat dong 2025" (The badge)
    TrichDan NVARCHAR(1000) NULL,                       -- Nguon: Doan van trich dan ngan (Excerpt)
    NoiDungHtml NVARCHAR(MAX) NULL,                     -- Noi dung bai viet chi tiet
    LinkAnhBia NVARCHAR(1000) NOT NULL,                 -- Nguon: Anh bia cua bai viet
    SoLuotThich INT DEFAULT 0,                          -- Nguon: Con so tim "52", "61" (Dung INT vi khong co User Login)
    DuongDanAo NVARCHAR(255) UNIQUE NOT NULL,           -- Nguon URL slug: href="/tin-tuc/tuyen-tinh-nguyen-vien..."
    NgayXuatBan DATE NULL,                              -- Nguon JSON: "date":"2026-08-22"
    NgayTao DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_TinTuc_ChienDich FOREIGN KEY (IDChienDich) REFERENCES ChienDich(IDChienDich)
);

-- 6. BANG THU VIEN ANH (Khoanh khac)
-- Nguon: Section "Luu giu nhung nu cuoi" & LightGallery
CREATE TABLE ThuVienAnh (
    IDAnh INT IDENTITY(1,1) PRIMARY KEY,
    IDChienDich INT NOT NULL,
    LinkAnh NVARCHAR(1000) NOT NULL,                    -- Nguon: Link anh (src, srcset)
    ChuThich NVARCHAR(255) NULL,                        -- Nguon: Caption "Nui rung Langbiang"
    MoTa NVARCHAR(500) NULL,                            -- Nguon: Doan mo ta nho
    LaAnhDoc BIT DEFAULT 0,                             -- Nguon JSON: "tall":true/false (Xep Grid CSS)
    ThuTuHienThi INT DEFAULT 0,
    CONSTRAINT FK_ThuVienAnh_ChienDich FOREIGN KEY (IDChienDich) REFERENCES ChienDich(IDChienDich)
);

-- 7. BANG CAU HOI THUONG GAP (FAQ)
-- Nguon: Section "Cau hoi thuong gap" (Accordion)
CREATE TABLE CauHoiThuongGap (
    IDCauHoi INT IDENTITY(1,1) PRIMARY KEY,
    CauHoi NVARCHAR(500) NOT NULL,                      -- Nguon: "Ai co the tham gia tro du an?"
    CauTraLoi NVARCHAR(MAX) NOT NULL,                   -- Nguon: "Tat ca cac ban tu du 18 tuoi..."
    ThuTuHienThi INT DEFAULT 0,                         -- Nguon: Sap xep UI
    TrangThaiHienThi BIT DEFAULT 1
);

-- ==============================================================================
-- BỔ SUNG TÍNH NĂNG: QUẢN LÝ ĐA TRANG CHỦ THEO NĂM & TÙY CHỈNH GIAO DIỆN
-- ==============================================================================

-- BƯỚC 1: Cập nhật bảng ChienDich hiện tại để hỗ trợ Dropdown Menu
-- Thêm cột TenHienThiMenu (Ví dụ Admin nhập: "Dự án 2025", "Dự án 2026")
ALTER TABLE ChienDich
ADD TenHienThiMenu NVARCHAR(100) NULL;

-- BƯỚC 2: Tạo bảng cấu hình riêng biệt cho từng Trang chủ (Quan hệ 1-1 với ChienDich)
CREATE TABLE CauHinhTrangChu (
    IDCauHinh INT IDENTITY(1,1) PRIMARY KEY,
    
    -- Khóa ngoại nối với ChienDich, UNIQUE đảm bảo mỗi năm chỉ có 1 cấu hình trang chủ
    IDChienDich INT NOT NULL UNIQUE, 
    
    -- 1. NHÓM CẤU HÌNH TIÊU ĐỀ (Titles)
    TieuDeChinh NVARCHAR(500) NULL,      -- VD: "Trăng sáng Langbiang"
    TieuDePhu NVARCHAR(500) NULL,        -- VD: "Cùng thắp sáng một mùa trăng yêu thương"
    DoanVanMoTa NVARCHAR(MAX) NULL,      -- VD: "Dù bạn trực tiếp lên đường hay đồng hành từ xa..."
    LinkAnhBia NVARCHAR(1000) NULL,      -- Nguồn: Link ảnh Background Hero Section của năm đó
    
    -- 2. NHÓM CẤU HÌNH MÀU SẮC (Colors - Lưu mã HEX để tiêm vào CSS Tailwind)
    MauChuDao VARCHAR(20) NULL,          -- VD: "#7cc34a" (Tương ứng biến màu 'leaf' của dự án)
    MauNen VARCHAR(20) NULL,             -- VD: "#eef8ea" (Hoặc lưu thẳng tên class background)
    MauChu VARCHAR(20) NULL,             -- VD: "#1b5e20" (Tương ứng biến màu 'forest')
    
    -- 3. NHÓM CẤU HÌNH FONT CHỮ (Fonts)
    FontTieuDe VARCHAR(100) NULL,        -- VD: "Dancing Script" (Admin nhập tên font Google Fonts)
    FontNoiDung VARCHAR(100) NULL,       -- VD: "Be Vietnam Pro"
    
    NgayCapNhat DATETIME DEFAULT GETDATE(),
    
    CONSTRAINT FK_CauHinhTrangChu_ChienDich FOREIGN KEY (IDChienDich) REFERENCES ChienDich(IDChienDich)
);