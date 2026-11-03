using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_TinhNguyen.Models
{
    // =========================================================================
    // MODULE: TRANG CHỦ
    // =========================================================================
    [Table("ChienDich")]
    public class ChienDich
    {
        [Key]
        public int IDChienDich { get; set; }
        public int Nam { get; set; }
        public string? TieuDe { get; set; }
        public string? TenHienThiMenu { get; set; }
        public bool TrangThaiHoatDong { get; set; }

        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("CauHinhTrangChu")]
    public class CauHinhTrangChu
    {
        [Key]
        public int IDCauHinh { get; set; }
        public int IDChienDich { get; set; }

        public string? TieuDePhu { get; set; }
        public string? TieuDeChinh { get; set; }
        public string? LinkAnhBia { get; set; }
        public string? DoanVanMoTa { get; set; }

        public int TocDoChuyenSlide { get; set; } = 4000;

        public string? MauChuDao { get; set; }
        public string? MauNhan { get; set; }
        public string? MauChu { get; set; }
        public string? MauNenStart { get; set; }
        public string? MauNenMid { get; set; }
        public string? MauNenEnd { get; set; }

        public string? FontTieuDe { get; set; }
        public string? FontNoiDung { get; set; }

        public bool HienThiCanvas3D { get; set; }
        public bool HienThiLaRoi { get; set; }
        public DateTime? NgayCapNhat { get; set; }

        public string? VeDuAn_TieuDe { get; set; }
        public string? VeDuAn_NoiDung { get; set; }
        public string? VeDuAn_LinkAnh { get; set; }
        public string? VeDuAn_MauTieuDe { get; set; }
        public string? VeDuAn_MauChu { get; set; }
        public string? VeDuAn_MauNenTag { get; set; }
        // Khóa ngoại liên kết tới Kho Hiệu Ứng
        public int? IDHieuUng { get; set; }
        [ForeignKey("IDHieuUng")]
        public virtual ThuVienHieuUng? ThuVienHieuUng { get; set; }

        [ForeignKey("IDChienDich")]
        public virtual ChienDich? ChienDich { get; set; }
        // --- CẤU HÌNH LINH VẬT TẠI FOOTER ---
        public bool HienThiMascot { get; set; } = true;
        public string? LinkAnhMascot { get; set; }
        public string? ViTriMascot { get; set; } = "right"; // Giá trị: left, right, center
        public virtual ICollection<BannerTrangChu>? BannerTrangChus { get; set; }
        public virtual ICollection<ChuongTrinhDemNguoc>? ChuongTrinhDemNguocs { get; set; }
        public virtual ICollection<CauHinhAnhNoi>? CauHinhAnhNois { get; set; }
        public virtual ICollection<TVKhoanhKhac>? TVKhoanhKhacs { get; set; }
        public virtual ICollection<TinTucTrangChu>? TinTucs { get; set; }
        public virtual ICollection<NhaTaiTroTrangChu>? NhaTaiTros { get; set; }
        public virtual ICollection<FAQTrangChu>? FAQs { get; set; }
    }

    [Table("BannerTrangChu")]
    public class BannerTrangChu
    {
        [Key]
        public int IDBanner { get; set; }
        public int IDCauHinh { get; set; }
        public string? LinkAnh { get; set; }
        public string? TieuDeAlt { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("CauHinhAnhNoi")]
    public class CauHinhAnhNoi
    {
        [Key]
        public int IDAnhNoi { get; set; }
        public int IDCauHinh { get; set; }
        public string? LinkAnh { get; set; }
        public string? TieuDeAlt { get; set; }
        public int ChieuSau { get; set; }
        public string? ViTriTop { get; set; }
        public string? CanLe { get; set; }
        public string? KhoangCachLe { get; set; }
        public string? KichThuoc { get; set; }
        public string? DoTreAnimation { get; set; }
        public string? GocXoay { get; set; }
        public bool TrangThai { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("TVKhoanhKhac")]
    public class TVKhoanhKhac
    {
        [Key]
        public int IDKhoanhKhac { get; set; }
        public int IDCauHinh { get; set; }
        public string? LinkAnh { get; set; }
        public string? TieuDe { get; set; }
        public string? MoTa { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("TinTucTrangChu")]
    public class TinTucTrangChu
    {
        [Key]
        public int IDTinTuc { get; set; }
        public int IDCauHinh { get; set; }
        public string? TieuDe { get; set; }
        public string? TrichDan { get; set; }
        public string? LinkAnh { get; set; }
        public string? ThePhanLoai { get; set; }
        public string? LinkChuyenHuong { get; set; }
        public int LuotThich { get; set; }
        public string? NoiDungChiTiet { get; set; }
        public string? MauTieuDe { get; set; }
        public string? KichCoTieuDe { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("NhaTaiTroTrangChu")]
    public class NhaTaiTroTrangChu
    {
        [Key]
        public int IDNhaTaiTro { get; set; }
        public int IDCauHinh { get; set; }
        public string? NhomTaiTro { get; set; }
        public string? TenDonVi { get; set; }
        public string? LinkLogo { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("FAQTrangChu")]
    public class FAQTrangChu
    {
        [Key]
        public int IDFAQ { get; set; }
        public int IDCauHinh { get; set; }
        public string? CauHoi { get; set; }
        public string? CauTraLoi { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    [Table("ChuongTrinhDemNguoc")]
    public class ChuongTrinhDemNguoc
    {
        [Key]
        public int IDChuongTrinh { get; set; }
        public int IDCauHinh { get; set; }

        public string? TieuDePhu { get; set; }
        public string? TieuDeChinh { get; set; }
        public string? MoTa { get; set; }
        public string? ThoiGianHienThi { get; set; }

        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }

        public string? MauNenStart { get; set; }
        public string? MauNenEnd { get; set; }
        public string? MauChu { get; set; }

        public bool EpKetThuc { get; set; }

        [ForeignKey("IDCauHinh")]
        public virtual CauHinhTrangChu? CauHinhTrangChu { get; set; }
    }

    // =========================================================================
    // MODULE: KÝ ỨC (NHÌN LẠI CÁC MÙA DỰ ÁN)
    // =========================================================================
    [Table("CauHinhKyUc")]
    public class CauHinhKyUc
    {
        [Key]
        public int IDCauHinhKyUc { get; set; }
        public int IDChienDich { get; set; }

        public string? TieuDeChinh { get; set; } = "Nhìn lại mùa dự án";
        public string? DoanVanMoTa { get; set; }
        public string? NoiDungTongKetHtml { get; set; }
        public string? LinkAnhBia { get; set; }
        public string? TieuDeTongKet { get; set; }
        public string? FontTieuDeTongKet { get; set; }
        public string? MauTieuDeTongKet { get; set; }

        public string? MauChuDao { get; set; } = "#7cc34a";
        public string? MauNenHienTai { get; set; } = "#c9ecf2";
        public string? MauChu { get; set; } = "#1b5e20";
        public string? FontTieuDe { get; set; } = "Dancing Script";

        [ForeignKey("IDChienDich")]
        public virtual ChienDich? ChienDich { get; set; }

        public virtual ICollection<AnhKyUc>? AnhKyUcs { get; set; }
        public virtual ICollection<NhaTaiTroKyUc>? NhaTaiTroKyUcs { get; set; }
    }

    [Table("AnhKyUc")]
    public class AnhKyUc
    {
        [Key]
        public int IDAnh { get; set; }
        public int IDCauHinhKyUc { get; set; }
        public string? LinkAnh { get; set; }
        public string? TieuDeAnh { get; set; }
        public bool LaAnhDoc { get; set; } = false;
        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDCauHinhKyUc")]
        public virtual CauHinhKyUc? CauHinhKyUc { get; set; }
    }

    [Table("NhaTaiTroKyUc")]
    public class NhaTaiTroKyUc
    {
        [Key]
        public int IDNhaTaiTro { get; set; }
        public int IDCauHinhKyUc { get; set; }
        public string? TenDonVi { get; set; }
        public string? LinkLogo { get; set; }
        public string? PhanLoai { get; set; }

        [ForeignKey("IDCauHinhKyUc")]
        public virtual CauHinhKyUc? CauHinhKyUc { get; set; }
    }

    // =========================================================================
    // MODULE: CHƯƠNG TRÌNH HOẠT ĐỘNG
    // =========================================================================
    [Table("CauHinhChuongTrinh")]
    public class CauHinhChuongTrinh
    {
        [Key]
        public int IDCauHinhCT { get; set; }
        public int IDChienDich { get; set; }

        // HERO SECTION
        public string? TieuDeChinh { get; set; } = "Hành Trình Lan Tỏa";
        public string? TieuDeNhanManh { get; set; } = "Yêu Thương và Hy Vọng";
        public string? DoanVanMoTa { get; set; }
        public string? LinkAnhHero1 { get; set; }
        public string? LinkAnhHero2 { get; set; }

        // GIAO DIỆN (CSS)
        public string? MauChuDao { get; set; } = "#7cc34a";
        public string? MauNenHienTai { get; set; } = "#c9ecf2";
        public string? MauChu { get; set; } = "#1b5e20";
        public string? FontTieuDe { get; set; } = "Be Vietnam Pro";

        [ForeignKey("IDChienDich")]
        public virtual ChienDich? ChienDich { get; set; }
        public virtual ICollection<ChangChuongTrinh>? ChangChuongTrinhs { get; set; }
    }

    [Table("ChangChuongTrinh")]
    public class ChangChuongTrinh
    {
        [Key]
        public int IDChang { get; set; }
        public int IDCauHinhCT { get; set; }

        public string? NhanThoiGian { get; set; }
        public string? TieuDeChang { get; set; }
        public string? MoTaChang { get; set; }
        public string? DiaDiem { get; set; }
        public string? LinkAnh { get; set; }
        public virtual ICollection<ChiTietLoTrinh>? ChiTietLoTrinhs { get; set; }

        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDCauHinhCT")]
        public virtual CauHinhChuongTrinh? CauHinhChuongTrinh { get; set; }
    }
    // --- THÊM BẢNG MỚI NÀY VÀO DƯỚI CÙNG ---
    [Table("ChiTietLoTrinh")]
    public class ChiTietLoTrinh
    {
        [Key]
        public int IDLoTrinh { get; set; }
        public int IDChang { get; set; }

        public string? ThoiGian { get; set; } // VD: "13g30"
        public string? NoiDungHoatDong { get; set; } // VD: "Công tác chuẩn bị, trang trí gian hàng..."
        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDChang")]
        public virtual ChangChuongTrinh? ChangChuongTrinh { get; set; }
    }
    // =========================================================================
    // MODULE: ĐÓNG GÓP / GÂY QUỸ (GAY QUY)
    // =========================================================================
    [Table("CauHinhGayQuy")]
    public class CauHinhGayQuy
    {
        [Key]
        public int IDCauHinhGQ { get; set; }
        public int IDChienDich { get; set; }

        // --- CẤU HÌNH CHUNG (FONT & MÀU CHỦ ĐẠO) ---
        public string? FontTieuDe { get; set; } = "Be Vietnam Pro";
        public string? FontNoiDung { get; set; } = "Be Vietnam Pro";
        public string? MauChuDao { get; set; } = "#2e7d32";

        // --- SECTION 1: HERO ---
        public string? Hero_Nhan { get; set; } = "KHÔNG GIAN YÊU THƯƠNG";
        public string? Hero_MauChuNhan { get; set; } = "#2e7d32";
        public string? Hero_MauNenNhan { get; set; } = "#dcfce7";

        public string? Hero_TieuDe { get; set; } = "HÌNH THỨC TRAO GỬI YÊU THƯƠNG";
        public string? Hero_MauTieuDe { get; set; } = "#1b5e20";
        public string? Hero_CoChuTieuDe { get; set; } = "48px";

        public string? Hero_MoTa { get; set; }
        public string? Hero_MauMoTa { get; set; } = "#374151";

        public string? Hero_TextNut { get; set; } = "Đóng góp ngay";
        public string? Hero_LinkNut { get; set; } = "#ways-to-contribute";
        public string? Hero_MauNutStart { get; set; } = "#2e7d32";
        public string? Hero_MauNutEnd { get; set; } = "#7cc34a";

        public string? Hero_LinkAnh { get; set; }
        public string? Hero_MauNenStart { get; set; } = "#e0f2fe";
        public string? Hero_MauNenMid { get; set; } = "#c9ecf2";
        public string? Hero_MauNenEnd { get; set; } = "#fefce8";

        // --- SECTION 2: CÁCH THỨC ĐÓNG GÓP ---
        public string? DongGop_Nhan { get; set; } = "Kênh ủng hộ";
        public string? DongGop_TieuDe { get; set; } = "Cách thức đóng góp";
        public string? DongGop_MauTieuDe { get; set; } = "#1b5e20";
        public string? DongGop_MoTa { get; set; } = "Cùng chung tay lan tỏa yêu thương bằng phương thức phù hợp nhất với bạn.";
        public string? DongGop_MauMoTa { get; set; } = "#374151";
        public string? DongGop_GhiChuChanTrang { get; set; } = "Mọi đóng góp đều được ghi nhận và công khai minh bạch trên Fanpage của dự án.";

        // --- SECTION 3: BÁO CÁO THU CHI ---
        public string? BaoCao_MauNen { get; set; } = "#eef8ea";
        public string? BaoCao_Nhan { get; set; } = "Minh bạch";
        public string? BaoCao_TieuDe { get; set; } = "Báo cáo thu – chi";
        public string? BaoCao_MauTieuDe { get; set; } = "#1b5e20";
        public string? BaoCao_MoTa { get; set; } = "Toàn bộ khoản thu – chi mùa 2026 được cập nhật công khai trên các kênh thông tin của Dự án.";
        public string? BaoCao_MauMoTa { get; set; } = "#374151";
        public string? BaoCao_TextNut { get; set; } = "Xem báo cáo chi tiết";
        public string? BaoCao_LinkNut { get; set; }

        // --- SECTION 4: ĐƠN VỊ TÀI TRỢ & TỔ CHỨC ---
        public string? TaiTro_Nhan { get; set; } = "Những mảnh ghép tạo nên Trăng sáng Langbiang 2026";
        public string? TaiTro_TieuDe { get; set; } = "ĐƠN VỊ TỔ CHỨC - TÀI TRỢ";
        public string? TaiTro_TieuDeNoiBat { get; set; } = "NĂM 2026";
        public string? TaiTro_MauTieuDe { get; set; } = "#1b5e20";
        public string? TaiTro_MoTa { get; set; } = "Mỗi đơn vị là một mảnh ghép quan trọng, cùng nhau thắp sáng và làm nên một mùa trăng 2026 thật trọn vẹn!";

        [ForeignKey("IDChienDich")]
        public virtual ChienDich? ChienDich { get; set; }

        public virtual ICollection<KenhDongGop>? KenhDongGops { get; set; }
        public virtual ICollection<NhaTaiTroGayQuy>? NhaTaiTroGayQuys { get; set; }
    }

    [Table("KenhDongGop")]
    public class KenhDongGop
    {
        [Key]
        public int IDKenh { get; set; }
        public int IDCauHinhGQ { get; set; }

        public string? TenKenh { get; set; } // VD: Quyên góp trực tiếp
        public string? MoTa { get; set; }
        public string? LoaiIcon { get; set; } = "bank"; // bank, gift, heart, star
        public string? MauIcon { get; set; } = "#2e7d32";
        public string? MauNenIcon { get; set; } = "#dcfce7";

        public string? MauTieuDe { get; set; } = "#1b5e20";
        public string? MauMoTa { get; set; } = "#374151";
        public string? MauNenCard { get; set; } = "#ffffff";

        public string? TextNut { get; set; } = "QR Tài khoản";
        public string? LoaiHanhDong { get; set; } = "qr"; // "qr" = Mở Popup QR, "link" = Mở link ngoài
        public string? LinkNgoai { get; set; }

        // Dữ liệu cho Popup QR
        public string? LinkAnhQR { get; set; }
        public string? TenNganHang { get; set; }
        public string? SoTaiKhoan { get; set; }
        public string? TenChuTaiKhoan { get; set; }
        public string? NoiDungChuyenKhoan { get; set; }
        public string? GhiChuThem { get; set; }

        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDCauHinhGQ")]
        public virtual CauHinhGayQuy? CauHinhGayQuy { get; set; }
    }

    [Table("NhaTaiTroGayQuy")]
    public class NhaTaiTroGayQuy
    {
        [Key]
        public int IDNhaTaiTroGQ { get; set; }
        public int IDCauHinhGQ { get; set; }

        public string? NhomTaiTro { get; set; } // VD: Đơn vị tổ chức năm 2026
        public string? TenDonVi { get; set; }
        public string? LinkLogo { get; set; }
        public string? LinkWebsite { get; set; }
        public string? GioiThieu { get; set; } // Nội dung hiện lên khi click vào logo
        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDCauHinhGQ")]
        public virtual CauHinhGayQuy? CauHinhGayQuy { get; set; }
    }
    // =========================================================================
    // MODULE: BAN TỔ CHỨC (BAN TO CHUC & SO DO TO CHUC)
    // =========================================================================
    [Table("CauHinhBanToChuc")]
    public class CauHinhBanToChuc
    {
        [Key]
        public int IDCauHinhBTC { get; set; }
        public int IDChienDich { get; set; }

        // --- CẤU HÌNH CHUNG (FONT & MÀU NỀN) ---
        public string? FontTieuDe { get; set; } = "Dancing Script";
        public string? FontNoiDung { get; set; } = "Be Vietnam Pro";
        public string? MauNenStart { get; set; } = "#e0f2fe";
        public string? MauNenMid { get; set; } = "#c9ecf2";
        public string? MauNenEnd { get; set; } = "#fefce8";

        // --- SECTION 1: BAN SÁNG LẬP ---
        public bool HienThiBanSangLap { get; set; } = true;
        public string? SangLap_Nhan { get; set; } = "Đội ngũ";
        public string? SangLap_TieuDe { get; set; } = "Ban sáng lập";
        public string? SangLap_MauTieuDe { get; set; } = "#1b5e20";
        public string? SangLap_CoChuTieuDe { get; set; } = "54px";

        // --- SECTION 2: SƠ ĐỒ BAN THƯỜNG TRỰC / TRƯỞNG BAN (GIỐNG ẢNH MẪU) ---
        public bool HienThiSoDoToChuc { get; set; } = true;
        public string? SoDo_Nhan { get; set; } = "Cơ cấu tổ chức";
        public string? SoDo_TieuDe { get; set; } = "Ban Thường Trực & Điều Hành";
        public string? SoDo_MauTieuDe { get; set; } = "#1b5e20";
        public string? SoDo_DoanVanMoTa { get; set; } = "Ban Tổ chức dự án là lực lượng nòng cốt trong việc xây dựng kế hoạch, kết nối nguồn lực và trực tiếp điều phối các hoạt động tình nguyện. Với mô hình hoạt động thống nhất giữa các đơn vị đồng hành, Ban Thường trực dự án gồm:";
        public string? SoDo_MauDuongKe { get; set; } = "#d9534f"; // Màu đường kẻ nhánh sơ đồ cây

        // --- SECTION 3: DANH SÁCH BAN TỔ CHỨC & THÀNH VIÊN ---
        public bool HienThiDanhSachBTC { get; set; } = true;
        public string? BTC_Nhan { get; set; } = "Đội ngũ";
        public string? BTC_TieuDe { get; set; } = "Thành viên Ban tổ chức";
        public string? BTC_MauTieuDe { get; set; } = "#1b5e20";
        public int SoLuongHienThiBanDau { get; set; } = 9; // Số lượng hiện trước khi bấm "Xem thêm"

        // --- SECTION 4: CTA ĐĂNG KÝ TNV ---
        public string? CTA_MoTa { get; set; } = "Muốn trở thành một phần của đội ngũ mùa 2026?";
        public string? CTA_TextNut { get; set; } = "Đăng ký làm tình nguyện viên";
        public string? CTA_LinkNut { get; set; } = "/#register";
        public string? CTA_MauNutStart { get; set; } = "#2e7d32";
        public string? CTA_MauNutEnd { get; set; } = "#7cc34a";

        [ForeignKey("IDChienDich")]
        public virtual ChienDich? ChienDich { get; set; }

        public virtual ICollection<ThanhVienBanToChuc>? ThanhViens { get; set; }
    }

    [Table("ThanhVienBanToChuc")]
    public class ThanhVienBanToChuc
    {
        [Key]
        public int IDThanhVien { get; set; }
        public int IDCauHinhBTC { get; set; }

        // Phân nhóm hiển thị:
        // "Founder_Top" = Sáng lập viên to nhất ở đỉnh
        // "Founder"     = Các sáng lập viên còn lại (Zíc-zắc)
        // "Tree_Root"   = Khối Đứng đầu Sơ đồ cây (Cấp 1 - Giống ô Bà Nguyễn Đinh Minh Phương)
        // "Tree_Branch" = Các khối nhánh Sơ đồ cây (Cấp 2 - Giống 4 ô bên dưới trong ảnh mẫu)
        // "Member"      = Thành viên BTC (Card ngang nhỏ ở dưới)
        public string? NhomHienThi { get; set; } = "Tree_Branch";

        public string? HoTen { get; set; } // VD: ANH PHẠM ĐỨC TUYÊN
        public string? ChucVuChinh { get; set; } // Chữ to in đậm (VD: TRƯỞNG BAN TỔ CHỨC / CHỦ TỊCH / BÍ THƯ)
        public string? DonViCongTac { get; set; } // Dòng dưới chức vụ chính (VD: Đoàn phường Langbiang - Đà Lạt)
        public string? ChucVuPhu { get; set; } // Các gạch đầu dòng (Ngăn cách bằng dấu | hoặc xuống dòng)
        public string? MoTaChiTiet { get; set; } // Đoạn giới thiệu dài (Dùng cho Ban sáng lập)

        public string? LinkAnh { get; set; }
        public string? LinkFacebook { get; set; }
        public bool CoHuyHieuSao { get; set; } = false; // Icon ngôi sao góc trái ảnh

        // Màu sắc riêng cho từng thẻ trong Sơ đồ cây (Giống ảnh mẫu: Đỏ, Xanh dương, Xanh lá, Xanh đậm)
        public string? MauChuDaoThe { get; set; } = "#e53935";
        public string? MauNenThe { get; set; } = "#ffffff";

        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDCauHinhBTC")]
        public virtual CauHinhBanToChuc? CauHinhBanToChuc { get; set; }
    }
    // =========================================================================
    // MODULE: TRANG BẢN TIN / TIN TỨC (TIN TUC)
    // =========================================================================
    [Table("CauHinhTinTuc")]
    public class CauHinhTinTuc
    {
        [Key]
        public int IDCauHinhTT { get; set; }
        public int IDChienDich { get; set; }

        // --- CẤU HÌNH CHUNG (FONT & MÀU CHỦ ĐẠO) ---
        public string? FontTieuDe { get; set; } = "Dancing Script";
        public string? FontNoiDung { get; set; } = "Be Vietnam Pro";
        public string? MauChuDao { get; set; } = "#2e7d32";

        // --- SECTION 1: HERO BANNER ---
        public string? Hero_Nhan { get; set; } = "Bản tin";
        public string? Hero_MauChuNhan { get; set; } = "#2e7d32";
        public string? Hero_MauNenNhan { get; set; } = "#ffffff";

        public string? Hero_TieuDe { get; set; } = "Câu chuyện từ hành trình";
        public string? Hero_MauTieuDe { get; set; } = "#1b5e20";
        public string? Hero_CoChuTieuDe { get; set; } = "64px";

        public string? Hero_MoTa { get; set; } = "Những dòng nhật ký, hình ảnh và tin tức mới nhất về Trăng Sáng Langbiang. Đăng ký bản tin để không bỏ lỡ mùa 2026!";
        public string? Hero_MauMoTa { get; set; } = "#1b5e20";

        public string? Hero_MauNenStart { get; set; } = "#e0f2fe";
        public string? Hero_MauNenMid { get; set; } = "#dff2e6";
        public string? Hero_MauNenEnd { get; set; } = "#fefce8";

        // --- SECTION 2: KHU VỰC DANH SÁCH BÀI VIẾT ---
        public string? DanhSach_MauNenStart { get; set; } = "#fefce8";
        public string? DanhSach_MauNenEnd { get; set; } = "#ffffff";

        [ForeignKey("IDChienDich")]
        public virtual ChienDich? ChienDich { get; set; }

        public virtual ICollection<BaiVietTinTuc>? BaiViets { get; set; }
    }

    [Table("BaiVietTinTuc")]
    public class BaiVietTinTuc
    {
        [Key]
        public int IDBaiViet { get; set; }
        public int IDCauHinhTT { get; set; }

        public string? TieuDe { get; set; }
        public string? ThePhanLoai { get; set; } = "THÔNG BÁO 2026"; // Tag góc trái trên ảnh
        public string? MauNenTag { get; set; } = "#2e7d32";
        public string? MauChuTag { get; set; } = "#ffffff";

        public string? TrichDan { get; set; } // Đoạn mô tả ngắn ngoài thẻ
        public string? NoiDungChiTiet { get; set; } // Nội dung HTML hiện trong Popup khi bấm "Đọc tiếp"

        public string? LinkAnhDaiDien { get; set; } // Ảnh bìa của thẻ
        public string? LinkAnhTrongBai { get; set; } // Ảnh đính kèm cuối bài trong Popup (nếu không dùng TinyMCE)
        public string? LinkBaiVietGoc { get; set; } // Link bài Facebook gốc (tùy chọn)

        public string? MauTieuDeThe { get; set; } = "#1b5e20"; // Màu tiêu đề ngoài Card
        public string? MauTieuDePopup { get; set; } = "#38bdf8"; // Màu tiêu đề trong Popup (Mặc định xanh dương sáng giống ảnh 1)
        public string? CoChuTieuDe { get; set; } = "18px";

        public int LuotThich { get; set; } = 0;
        public string? NgayDang { get; set; } = "2026-08-22";
        public int ThuTu { get; set; } = 0;

        [ForeignKey("IDCauHinhTT")]
        public virtual CauHinhTinTuc? CauHinhTinTuc { get; set; }
    }
    // =========================================================================
    // MODULE: KHO HIỆU ỨNG ĐỘNG TOÀN TRANG (TẾT, NOEL, TRUNG THU...)
    // =========================================================================
    [Table("ThuVienHieuUng")]
    public class ThuVienHieuUng
    {
        [Key]
        public int IDHieuUng { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên hiệu ứng")]
        public string ? TenHieuUng { get; set; } // VD: Hoa Mai Rơi, Tuyết Rơi...

        public string? MoTa { get; set; }
        public string? LinkFileJS { get; set; } // Đường dẫn file Script chứa hiệu ứng
        public bool TrangThai { get; set; } = true;
    }
}