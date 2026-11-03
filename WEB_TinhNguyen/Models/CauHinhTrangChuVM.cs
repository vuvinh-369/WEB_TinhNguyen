using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace WEB_TinhNguyen.Models
{
    // =========================================================================
    // CÁC VIEWMODELS CHO MODULE TRANG CHỦ
    // =========================================================================
    public class CauHinhTrangChuVM
    {
        public int IDCauHinh { get; set; }
        public int IDChienDich { get; set; }
        public string TenChienDich { get; set; }

        public int TocDoChuyenSlide { get; set; } = 4000;

        public string TieuDePhu { get; set; }
        public string TieuDeChinh { get; set; }
        public string DoanVanMoTa { get; set; }

        public string MauChuDao { get; set; } = "#2e7d32";
        public string MauNhan { get; set; } = "#4caf50";
        public string MauChu { get; set; } = "#1b5e20";
        public string MauNenStart { get; set; } = "#ffffff";
        public string MauNenMid { get; set; } = "#c9ecf2";
        public string MauNenEnd { get; set; } = "#fefce8";
        public string FontTieuDe { get; set; } = "Dancing Script";
        public string FontNoiDung { get; set; } = "Be Vietnam Pro";
        public bool HienThiCanvas3D { get; set; } = true;
        public bool HienThiLaRoi { get; set; } = true;

        public string LinkAnhBiaCu { get; set; }
        public IFormFile FileAnhBia { get; set; }

        public string VeDuAn_TieuDe { get; set; }
        public string VeDuAn_NoiDung { get; set; }
        public string VeDuAn_LinkAnhCu { get; set; }
        public IFormFile VeDuAn_FileAnh { get; set; }

        public string VeDuAn_MauTieuDe { get; set; } = "#1b5e20";
        public string VeDuAn_MauChu { get; set; } = "#374151";
        public string VeDuAn_MauNenTag { get; set; } = "#4caf50";
        public int? IDHieuUng { get; set; }
        // --- LINH VẬT TRANG TRÍ ---
        public bool HienThiMascot { get; set; } = true;
        public string? LinkAnhMascotCu { get; set; }
        public IFormFile? FileAnhMascot { get; set; }
        public string? ViTriMascot { get; set; } = "right";
        public List<BannerTrangChuVM> Banners { get; set; } = new List<BannerTrangChuVM>();
        public List<ChuongTrinhDemNguocVM> ChuongTrinhs { get; set; } = new List<ChuongTrinhDemNguocVM>();
        public List<CauHinhAnhNoiVM> AnhNois { get; set; } = new List<CauHinhAnhNoiVM>();
        public List<TVKhoanhKhacVM> TVKhoanhKhacs { get; set; } = new List<TVKhoanhKhacVM>();
        public List<TinTucTrangChuVM> TinTucs { get; set; } = new List<TinTucTrangChuVM>();
        public List<NhaTaiTroTrangChuVM> NhaTaiTros { get; set; } = new List<NhaTaiTroTrangChuVM>();
        public List<FAQTrangChuVM> FAQs { get; set; } = new List<FAQTrangChuVM>();
    }

    public class BannerTrangChuVM
    {
        public string LinkAnhCu { get; set; }
        public IFormFile FileAnh { get; set; }
        public string TieuDeAlt { get; set; }
    }

    public class CauHinhAnhNoiVM
    {
        public int IDAnhNoi { get; set; }
        public string LinkAnhCu { get; set; }
        public IFormFile FileAnh { get; set; }
        public string TieuDeAlt { get; set; }
        public int ChieuSau { get; set; } = -50;
        public string ViTriTop { get; set; }
        public string CanLe { get; set; } = "left";
        public string KhoangCachLe { get; set; }
        public string KichThuoc { get; set; }
        public string DoTreAnimation { get; set; } = "0s";
        public string GocXoay { get; set; } = "0deg";
    }

    public class TVKhoanhKhacVM
    {
        public string LinkAnhCu { get; set; }
        public IFormFile FileAnh { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
    }

    public class TinTucTrangChuVM
    {
        public string LinkAnhCu { get; set; }
        public IFormFile FileAnh { get; set; }
        public string TieuDe { get; set; }
        public string TrichDan { get; set; }
        public string ThePhanLoai { get; set; }
        public string LinkChuyenHuong { get; set; }
        public int LuotThich { get; set; }
        public string NoiDungChiTiet { get; set; }
        public string MauTieuDe { get; set; }
        public string KichCoTieuDe { get; set; } = "18px";
    }

    public class NhaTaiTroTrangChuVM
    {
        public string LinkLogoCu { get; set; }
        public IFormFile FileLogo { get; set; }
        public string NhomTaiTro { get; set; }
        public string TenDonVi { get; set; }
    }

    public class FAQTrangChuVM
    {
        public string CauHoi { get; set; }
        public string CauTraLoi { get; set; }
    }

    public class ChuongTrinhDemNguocVM
    {
        public string TieuDePhu { get; set; }
        public string TieuDeChinh { get; set; }
        public string MoTa { get; set; }
        public string ThoiGianHienThi { get; set; }
        public DateTime ThoiGianBatDau { get; set; } = DateTime.Now;
        public DateTime ThoiGianKetThuc { get; set; } = DateTime.Now.AddDays(1);
        public string MauNenStart { get; set; } = "#ffffff";
        public string MauNenEnd { get; set; } = "#f8fafc";
        public string MauChu { get; set; } = "#2e7d32";
        public bool EpKetThuc { get; set; }
    }

    // =========================================================================
    // CÁC VIEWMODELS CHO MODULE KÝ ỨC
    // =========================================================================

    public class CauHinhKyUcVM
    {
        public int IDCauHinhKyUc { get; set; }
        public int IDChienDich { get; set; }
        public string NamChienDich { get; set; }

        public string TieuDeChinh { get; set; }
        public string DoanVanMoTa { get; set; }
        public string NoiDungTongKetHtml { get; set; }

        public string MauChuDao { get; set; } = "#7cc34a";
        public string MauNenHienTai { get; set; } = "#c9ecf2";
        public string MauChu { get; set; } = "#1b5e20";
        public string FontTieuDe { get; set; } = "Dancing Script";

        public string LinkAnhBiaCu { get; set; }
        public IFormFile FileAnhBia { get; set; }
        public string TieuDeTongKet { get; set; }
        public string FontTieuDeTongKet { get; set; }
        public string MauTieuDeTongKet { get; set; }

        public List<AnhKyUcVM> ThuVienAnhs { get; set; } = new List<AnhKyUcVM>();
        public List<NhaTaiTroKyUcVM> NhaTaiTros { get; set; } = new List<NhaTaiTroKyUcVM>();
    }

    public class AnhKyUcVM
    {
        public string LinkAnhCu { get; set; }
        public IFormFile FileAnh { get; set; }
        public string TieuDeAnh { get; set; }
        public bool LaAnhDoc { get; set; }
    }

    public class NhaTaiTroKyUcVM
    {
        public string LinkLogoCu { get; set; }
        public IFormFile FileLogo { get; set; }
        public string TenDonVi { get; set; }
        public string PhanLoai { get; set; }
    }

    // =========================================================================
    // CÁC VIEWMODELS CHO MODULE CHƯƠNG TRÌNH
    // =========================================================================

    public class CauHinhChuongTrinhVM
    {
        public int IDCauHinhCT { get; set; }
        public int IDChienDich { get; set; }
        public string NamChienDich { get; set; }

        public string TieuDeChinh { get; set; }
        public string TieuDeNhanManh { get; set; }
        public string DoanVanMoTa { get; set; }

        public string MauChuDao { get; set; } = "#7cc34a";
        public string MauNenHienTai { get; set; } = "#c9ecf2";
        public string MauChu { get; set; } = "#1b5e20";
        public string FontTieuDe { get; set; } = "Be Vietnam Pro";

        public string LinkAnhHero1Cu { get; set; }
        public IFormFile FileAnhHero1 { get; set; }
        public string LinkAnhHero2Cu { get; set; }
        public IFormFile FileAnhHero2 { get; set; }

        public List<ChangChuongTrinhVM> Changs { get; set; } = new List<ChangChuongTrinhVM>();
    }

    public class ChangChuongTrinhVM
    {
        public string NhanThoiGian { get; set; }
        public string TieuDeChang { get; set; }
        public string MoTaChang { get; set; }
        public string DiaDiem { get; set; }
        public string LinkAnhCu { get; set; }
        public IFormFile FileAnh { get; set; }
        public List<ChiTietLoTrinhVM> LoTrinhs { get; set; } = new List<ChiTietLoTrinhVM>();
    }
    public class ChiTietLoTrinhVM
    {
        public string ThoiGian { get; set; }
        public string NoiDungHoatDong { get; set; }
    }
    // =========================================================================
    // CÁC VIEWMODELS CHO MODULE ĐÓNG GÓP / GÂY QUỸ (GAY QUY)
    // =========================================================================
    public class CauHinhGayQuyVM
    {
        public int IDCauHinhGQ { get; set; }
        public int IDChienDich { get; set; }
        public string? TenChienDich { get; set; }
        public int NamChienDich { get; set; }

        // --- CẤU HÌNH CHUNG ---
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

        public string? Hero_MoTa { get; set; } = "Có nhiều cách để bạn kề vai, sát cánh cùng dự án. Mọi sự ủng hộ thông qua các \"Gói yêu thương\", hiện kim, nhu yếu phẩm hay chỉ một lời chúc tốt đẹp đều là những mảnh ghép làm nên một mùa Trung thu diệu kỳ cho trẻ em nhỏ có hoàn cảnh khó khăn!";
        public string? Hero_MauMoTa { get; set; } = "#374151";

        public string? Hero_TextNut { get; set; } = "Đóng góp ngay";
        public string? Hero_LinkNut { get; set; } = "#ways-to-contribute";
        public string? Hero_MauNutStart { get; set; } = "#2e7d32";
        public string? Hero_MauNutEnd { get; set; } = "#7cc34a";

        public string? Hero_LinkAnhCu { get; set; }
        public IFormFile? Hero_FileAnh { get; set; }

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
        public string? BaoCao_LinkNut { get; set; } = "https://drive.google.com/drive/folders/1atXjIPlv9Q6k45q5CQ-s9joMiOGtI9YQ?usp=drive_link";

        // --- SECTION 4: ĐƠN VỊ TÀI TRỢ ---
        public string? TaiTro_Nhan { get; set; } = "Những mảnh ghép tạo nên Trăng sáng Langbiang 2026";
        public string? TaiTro_TieuDe { get; set; } = "ĐƠN VỊ TỔ CHỨC - TÀI TRỢ";
        public string? TaiTro_TieuDeNoiBat { get; set; } = "NĂM 2026";
        public string? TaiTro_MauTieuDe { get; set; } = "#1b5e20";
        public string? TaiTro_MoTa { get; set; } = "Mỗi đơn vị là một mảnh ghép quan trọng, cùng nhau thắp sáng và làm nên một mùa trăng 2026 thật trọn vẹn!";

        public List<KenhDongGopVM> KenhDongGops { get; set; } = new List<KenhDongGopVM>();
        public List<NhaTaiTroGayQuyVM> NhaTaiTros { get; set; } = new List<NhaTaiTroGayQuyVM>();
    }

    public class KenhDongGopVM
    {
        public string? TenKenh { get; set; }
        public string? MoTa { get; set; }
        public string? LoaiIcon { get; set; } = "bank";
        public string? MauIcon { get; set; } = "#2e7d32";
        public string? MauNenIcon { get; set; } = "#dcfce7";

        public string? MauTieuDe { get; set; } = "#1b5e20";
        public string? MauMoTa { get; set; } = "#374151";
        public string? MauNenCard { get; set; } = "#ffffff";

        public string? TextNut { get; set; } = "QR Tài khoản";
        public string? LoaiHanhDong { get; set; } = "qr";
        public string? LinkNgoai { get; set; }

        public string? LinkAnhQRCu { get; set; }
        public IFormFile? FileAnhQR { get; set; }
        public string? TenNganHang { get; set; }
        public string? SoTaiKhoan { get; set; }
        public string? TenChuTaiKhoan { get; set; }
        public string? NoiDungChuyenKhoan { get; set; }
        public string? GhiChuThem { get; set; }
    }

    public class NhaTaiTroGayQuyVM
    {
        public string? NhomTaiTro { get; set; }
        public string? TenDonVi { get; set; }
        public string? LinkLogoCu { get; set; }
        public IFormFile? FileLogo { get; set; }
        public string? LinkWebsite { get; set; }
        public string? GioiThieu { get; set; }
    }
    // =========================================================================
    // CÁC VIEWMODELS CHO MODULE BAN TỔ CHỨC
    // =========================================================================
    public class CauHinhBanToChucVM
    {
        public int IDCauHinhBTC { get; set; }
        public int IDChienDich { get; set; }
        public string? TenChienDich { get; set; }
        public int NamChienDich { get; set; }

        public string? FontTieuDe { get; set; } = "Dancing Script";
        public string? FontNoiDung { get; set; } = "Be Vietnam Pro";
        public string? MauNenStart { get; set; } = "#e0f2fe";
        public string? MauNenMid { get; set; } = "#c9ecf2";
        public string? MauNenEnd { get; set; } = "#fefce8";

        // Section 1: Ban Sáng Lập
        public bool HienThiBanSangLap { get; set; } = true;
        public string? SangLap_Nhan { get; set; } = "Đội ngũ";
        public string? SangLap_TieuDe { get; set; } = "Ban sáng lập";
        public string? SangLap_MauTieuDe { get; set; } = "#1b5e20";
        public string? SangLap_CoChuTieuDe { get; set; } = "54px";

        // Section 2: Sơ đồ Tổ chức (Giống ảnh mẫu)
        public bool HienThiSoDoToChuc { get; set; } = true;
        public string? SoDo_Nhan { get; set; } = "Cơ cấu tổ chức";
        public string? SoDo_TieuDe { get; set; } = "Ban Thường Trực & Điều Hành";
        public string? SoDo_MauTieuDe { get; set; } = "#1b5e20";
        public string? SoDo_DoanVanMoTa { get; set; }
        public string? SoDo_MauDuongKe { get; set; } = "#d9534f";

        // Section 3: Thành viên BTC
        public bool HienThiDanhSachBTC { get; set; } = true;
        public string? BTC_Nhan { get; set; } = "Đội ngũ";
        public string? BTC_TieuDe { get; set; } = "Thành viên Ban tổ chức";
        public string? BTC_MauTieuDe { get; set; } = "#1b5e20";
        public int SoLuongHienThiBanDau { get; set; } = 9;

        // Section 4: CTA
        public string? CTA_MoTa { get; set; } = "Muốn trở thành một phần của đội ngũ mùa 2026?";
        public string? CTA_TextNut { get; set; } = "Đăng ký làm tình nguyện viên";
        public string? CTA_LinkNut { get; set; } = "/#register";
        public string? CTA_MauNutStart { get; set; } = "#2e7d32";
        public string? CTA_MauNutEnd { get; set; } = "#7cc34a";

        // 3 Danh sách nhân sự tách biệt để Admin dễ quản lý trên 3 Tab
        public List<ThanhVienBTC_VM> BanSangLaps { get; set; } = new List<ThanhVienBTC_VM>();
        public List<ThanhVienBTC_VM> SoDoThuongTrucs { get; set; } = new List<ThanhVienBTC_VM>();
        public List<ThanhVienBTC_VM> ThanhVienBTCs { get; set; } = new List<ThanhVienBTC_VM>();
    }

    public class ThanhVienBTC_VM
    {
        public string? NhomHienThi { get; set; } = "Tree_Branch";
        public string? HoTen { get; set; }
        public string? ChucVuChinh { get; set; }
        public string? DonViCongTac { get; set; }
        public string? ChucVuPhu { get; set; }
        public string? MoTaChiTiet { get; set; }

        public string? LinkAnhCu { get; set; }
        public IFormFile? FileAnh { get; set; }
        public string? LinkFacebook { get; set; }
        public bool CoHuyHieuSao { get; set; } = false;

        public string? MauChuDaoThe { get; set; } = "#e53935";
        public string? MauNenThe { get; set; } = "#ffffff";
    }
    // =========================================================================
    // CÁC VIEWMODELS CHO MODULE TRANG BẢN TIN / TIN TỨC
    // =========================================================================
    public class CauHinhTinTucVM
    {
        public int IDCauHinhTT { get; set; }
        public int IDChienDich { get; set; }
        public string? TenChienDich { get; set; }
        public int NamChienDich { get; set; }

        // Cấu hình chung
        public string? FontTieuDe { get; set; } = "Dancing Script";
        public string? FontNoiDung { get; set; } = "Be Vietnam Pro";
        public string? MauChuDao { get; set; } = "#2e7d32";

        // Hero Section
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

        // Màu nền vùng danh sách
        public string? DanhSach_MauNenStart { get; set; } = "#fefce8";
        public string? DanhSach_MauNenEnd { get; set; } = "#ffffff";

        public List<BaiVietTinTucVM> BaiViets { get; set; } = new List<BaiVietTinTucVM>();
    }

    public class BaiVietTinTucVM
    {
        public int IDBaiViet { get; set; }
        public string? TieuDe { get; set; }
        public string? ThePhanLoai { get; set; } = "THÔNG BÁO 2026";
        public string? MauNenTag { get; set; } = "#2e7d32";
        public string? MauChuTag { get; set; } = "#ffffff";

        public string? TrichDan { get; set; }
        public string? NoiDungChiTiet { get; set; }

        public string? LinkAnhDaiDienCu { get; set; }
        public IFormFile? FileAnhDaiDien { get; set; }

        public string? LinkAnhTrongBaiCu { get; set; }
        public IFormFile? FileAnhTrongBai { get; set; }

        public string? LinkBaiVietGoc { get; set; }

        public string? MauTieuDeThe { get; set; } = "#1b5e20";
        public string? MauTieuDePopup { get; set; } = "#38bdf8";
        public string? CoChuTieuDe { get; set; } = "18px";

        public int LuotThich { get; set; } = 0;
        public string? NgayDang { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public int? IDHieuUng { get; set; } // Lưu ID hiệu ứng được chọn
    }
}