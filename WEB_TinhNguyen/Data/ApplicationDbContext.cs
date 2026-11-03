using Microsoft.EntityFrameworkCore;
using WEB_TinhNguyen.Models;

namespace WEB_TinhNguyen.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Khai báo các bảng để Entity Framework tạo trong Database
        public DbSet<ChienDich> ChienDichs { get; set; }
        public DbSet<CauHinhTrangChu> CauHinhTrangChus { get; set; }
        public DbSet<CauHinhAnhNoi> CauHinhAnhNois { get; set; }
        public DbSet<BannerTrangChu> BannerTrangChus { get; set; }
        public DbSet<ChuongTrinhDemNguoc> ChuongTrinhDemNguocs { get; set; }
        public DbSet<CauHinhKyUc> CauHinhKyUcs { get; set; }
        public DbSet<AnhKyUc> AnhKyUcs { get; set; }
        public DbSet<NhaTaiTroKyUc> NhaTaiTroKyUcs { get; set; }
        public DbSet<CauHinhChuongTrinh> CauHinhChuongTrinhs { get; set; }
        public DbSet<ChangChuongTrinh> ChangChuongTrinhs { get; set; }
        public DbSet<ChiTietLoTrinh> ChiTietLoTrinhs { get; set; }
        public DbSet<CauHinhGayQuy> CauHinhGayQuys { get; set; }
        public DbSet<KenhDongGop> KenhDongGops { get; set; }
        public DbSet<NhaTaiTroGayQuy> NhaTaiTroGayQuys { get; set; }
        public DbSet<CauHinhBanToChuc> CauHinhBanToChucs { get; set; }
        public DbSet<ThanhVienBanToChuc> ThanhVienBanToChucs { get; set; }
        public DbSet<CauHinhTinTuc> CauHinhTinTucs { get; set; }
        public DbSet<BaiVietTinTuc> BaiVietTinTucs { get; set; }
        public DbSet<ThuVienHieuUng> ThuVienHieuUngs { get; set; }
        // Bạn có thể thêm DbSet cho các bảng khác (TinTuc, NhaTaiTro...) ở đây sau
    }
}