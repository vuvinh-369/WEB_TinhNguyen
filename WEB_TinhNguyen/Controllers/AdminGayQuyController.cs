using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEB_TinhNguyen.Data;
using WEB_TinhNguyen.Models;

namespace WEB_TinhNguyen.Controllers
{
    public class AdminGayQuyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminGayQuyController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // 1. DANH SÁCH CHIẾN DỊCH THEO NĂM
        public async Task<IActionResult> Index()
        {
            var list = await _context.ChienDichs.OrderByDescending(c => c.Nam).ToListAsync();
            return View(list);
        }

        // 2. MỞ TRANG CẤU HÌNH (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var chienDich = await _context.ChienDichs.FindAsync(id);
            if (chienDich == null) return NotFound();

            var config = await _context.CauHinhGayQuys
                .Include(c => c.KenhDongGops)
                .Include(c => c.NhaTaiTroGayQuys)
                .FirstOrDefaultAsync(c => c.IDChienDich == id);

            // Nếu chưa có cấu hình cho năm này thì khởi tạo dữ liệu mẫu mặc định giống hệt trang gốc
            if (config == null)
            {
                config = new CauHinhGayQuy
                {
                    IDChienDich = id,
                    Hero_LinkAnh = "/gallery/2025/bro02087.jpg",
                    Hero_MoTa = "Có nhiều cách để bạn kề vai, sát cánh cùng dự án. Mọi sự ủng hộ thông qua các \"Gói yêu thương\", hiện kim, nhu yếu phẩm hay chỉ một lời chúc tốt đẹp đều là những mảnh ghép làm nên một mùa Trung thu diệu kỳ cho trẻ em nhỏ có hoàn cảnh khó khăn!",
                    BaoCao_LinkNut = "https://drive.google.com/drive/folders/1atXjIPlv9Q6k45q5CQ-s9joMiOGtI9YQ?usp=drive_link"
                };
                _context.CauHinhGayQuys.Add(config);
                await _context.SaveChangesAsync();

                // Thêm 2 kênh đóng góp mặc định
                _context.KenhDongGops.AddRange(
                    new KenhDongGop
                    {
                        IDCauHinhGQ = config.IDCauHinhGQ,
                        TenKenh = "Quyên góp trực tiếp",
                        MoTa = $"BTC chỉ sử dụng DUY NHẤT một tài khoản này để tiếp nhận quyên góp trực tiếp từ 10/8/{chienDich.Nam} đến hết 25/9/{chienDich.Nam}",
                        LoaiIcon = "bank",
                        MauIcon = "#2e7d32",
                        MauNenIcon = "#dcfce7",
                        TextNut = "QR Tài khoản",
                        LoaiHanhDong = "qr",
                        TenNganHang = "MBBank (Ngân hàng Quân Đội)",
                        SoTaiKhoan = "0924044283",
                        TenChuTaiKhoan = "NGUYỄN ANH HÀO",
                        NoiDungChuyenKhoan = "[Họ và tên]_[Đơn vị]_gopLangbiang",
                        LinkAnhQR = "https://ik.imagekit.io/ij9ocagrc/kho/QRCK-A.Ha-o-636KHTNdal43FQMQOVKE0khAuEiX4h_OMj08ZkCK.webp",
                        ThuTu = 1
                    },
                    new KenhDongGop
                    {
                        IDCauHinhGQ = config.IDCauHinhGQ,
                        TenKenh = "Quyên góp hiện vật",
                        MoTa = "Quà Trung thu, nhu yếu phẩm,... Vui lòng liên hệ Zalo 0827.564.956 (Anh Phạm Minh Phát - đại diện Ban sáng lập Dự án) hoặc Fanpage",
                        LoaiIcon = "gift",
                        MauIcon = "#d97706",
                        MauNenIcon = "#fef3c7",
                        TextNut = "Liên hệ Fanpage",
                        LoaiHanhDong = "link",
                        LinkNgoai = "https://www.facebook.com/profile.php?id=61580211752903",
                        ThuTu = 2
                    }
                );
                await _context.SaveChangesAsync();

                // Load lại
                config = await _context.CauHinhGayQuys
                    .Include(c => c.KenhDongGops)
                    .Include(c => c.NhaTaiTroGayQuys)
                    .FirstOrDefaultAsync(c => c.IDChienDich == id);
            }

            var vm = new CauHinhGayQuyVM
            {
                IDCauHinhGQ = config.IDCauHinhGQ,
                IDChienDich = config.IDChienDich,
                TenChienDich = chienDich.TieuDe,
                NamChienDich = chienDich.Nam,

                FontTieuDe = config.FontTieuDe,
                FontNoiDung = config.FontNoiDung,
                MauChuDao = config.MauChuDao,

                Hero_Nhan = config.Hero_Nhan,
                Hero_MauChuNhan = config.Hero_MauChuNhan,
                Hero_MauNenNhan = config.Hero_MauNenNhan,
                Hero_TieuDe = config.Hero_TieuDe,
                Hero_MauTieuDe = config.Hero_MauTieuDe,
                Hero_CoChuTieuDe = config.Hero_CoChuTieuDe,
                Hero_MoTa = config.Hero_MoTa,
                Hero_MauMoTa = config.Hero_MauMoTa,
                Hero_TextNut = config.Hero_TextNut,
                Hero_LinkNut = config.Hero_LinkNut,
                Hero_MauNutStart = config.Hero_MauNutStart,
                Hero_MauNutEnd = config.Hero_MauNutEnd,
                Hero_LinkAnhCu = config.Hero_LinkAnh,
                Hero_MauNenStart = config.Hero_MauNenStart,
                Hero_MauNenMid = config.Hero_MauNenMid,
                Hero_MauNenEnd = config.Hero_MauNenEnd,

                DongGop_Nhan = config.DongGop_Nhan,
                DongGop_TieuDe = config.DongGop_TieuDe,
                DongGop_MauTieuDe = config.DongGop_MauTieuDe,
                DongGop_MoTa = config.DongGop_MoTa,
                DongGop_MauMoTa = config.DongGop_MauMoTa,
                DongGop_GhiChuChanTrang = config.DongGop_GhiChuChanTrang,

                BaoCao_MauNen = config.BaoCao_MauNen,
                BaoCao_Nhan = config.BaoCao_Nhan,
                BaoCao_TieuDe = config.BaoCao_TieuDe,
                BaoCao_MauTieuDe = config.BaoCao_MauTieuDe,
                BaoCao_MoTa = config.BaoCao_MoTa,
                BaoCao_MauMoTa = config.BaoCao_MauMoTa,
                BaoCao_TextNut = config.BaoCao_TextNut,
                BaoCao_LinkNut = config.BaoCao_LinkNut,

                TaiTro_Nhan = config.TaiTro_Nhan,
                TaiTro_TieuDe = config.TaiTro_TieuDe,
                TaiTro_TieuDeNoiBat = config.TaiTro_TieuDeNoiBat,
                TaiTro_MauTieuDe = config.TaiTro_MauTieuDe,
                TaiTro_MoTa = config.TaiTro_MoTa,

                KenhDongGops = config.KenhDongGops?.OrderBy(k => k.ThuTu).Select(k => new KenhDongGopVM
                {
                    TenKenh = k.TenKenh,
                    MoTa = k.MoTa,
                    LoaiIcon = k.LoaiIcon,
                    MauIcon = k.MauIcon,
                    MauNenIcon = k.MauNenIcon,
                    MauTieuDe = k.MauTieuDe,
                    MauMoTa = k.MauMoTa,
                    MauNenCard = k.MauNenCard,
                    TextNut = k.TextNut,
                    LoaiHanhDong = k.LoaiHanhDong,
                    LinkNgoai = k.LinkNgoai,
                    LinkAnhQRCu = k.LinkAnhQR,
                    TenNganHang = k.TenNganHang,
                    SoTaiKhoan = k.SoTaiKhoan,
                    TenChuTaiKhoan = k.TenChuTaiKhoan,
                    NoiDungChuyenKhoan = k.NoiDungChuyenKhoan,
                    GhiChuThem = k.GhiChuThem
                }).ToList() ?? new(),

                NhaTaiTros = config.NhaTaiTroGayQuys?.OrderBy(n => n.ThuTu).Select(n => new NhaTaiTroGayQuyVM
                {
                    NhomTaiTro = n.NhomTaiTro,
                    TenDonVi = n.TenDonVi,
                    LinkLogoCu = n.LinkLogo,
                    LinkWebsite = n.LinkWebsite,
                    GioiThieu = n.GioiThieu
                }).ToList() ?? new()
            };

            return View(vm);
        }

        // 3. LƯU CẤU HÌNH (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CauHinhGayQuyVM vm)
        {
            var config = await _context.CauHinhGayQuys
                .Include(c => c.KenhDongGops)
                .Include(c => c.NhaTaiTroGayQuys)
                .FirstOrDefaultAsync(c => c.IDCauHinhGQ == vm.IDCauHinhGQ);

            if (config == null) return NotFound();

            // Cập nhật thông tin chung & Hero
            config.FontTieuDe = vm.FontTieuDe;
            config.FontNoiDung = vm.FontNoiDung;
            config.MauChuDao = vm.MauChuDao;

            config.Hero_Nhan = vm.Hero_Nhan;
            config.Hero_MauChuNhan = vm.Hero_MauChuNhan;
            config.Hero_MauNenNhan = vm.Hero_MauNenNhan;
            config.Hero_TieuDe = vm.Hero_TieuDe;
            config.Hero_MauTieuDe = vm.Hero_MauTieuDe;
            config.Hero_CoChuTieuDe = vm.Hero_CoChuTieuDe;
            config.Hero_MoTa = vm.Hero_MoTa;
            config.Hero_MauMoTa = vm.Hero_MauMoTa;
            config.Hero_TextNut = vm.Hero_TextNut;
            config.Hero_LinkNut = vm.Hero_LinkNut;
            config.Hero_MauNutStart = vm.Hero_MauNutStart;
            config.Hero_MauNutEnd = vm.Hero_MauNutEnd;
            config.Hero_MauNenStart = vm.Hero_MauNenStart;
            config.Hero_MauNenMid = vm.Hero_MauNenMid;
            config.Hero_MauNenEnd = vm.Hero_MauNenEnd;

            if (vm.Hero_FileAnh != null)
                config.Hero_LinkAnh = await SaveFileAsync(vm.Hero_FileAnh, "gayquy");
            else
                config.Hero_LinkAnh = vm.Hero_LinkAnhCu;

            // Cập nhật Section 2: Cách thức đóng góp
            config.DongGop_Nhan = vm.DongGop_Nhan;
            config.DongGop_TieuDe = vm.DongGop_TieuDe;
            config.DongGop_MauTieuDe = vm.DongGop_MauTieuDe;
            config.DongGop_MoTa = vm.DongGop_MoTa;
            config.DongGop_MauMoTa = vm.DongGop_MauMoTa;
            config.DongGop_GhiChuChanTrang = vm.DongGop_GhiChuChanTrang;

            // Cập nhật Section 3: Báo cáo thu chi
            config.BaoCao_MauNen = vm.BaoCao_MauNen;
            config.BaoCao_Nhan = vm.BaoCao_Nhan;
            config.BaoCao_TieuDe = vm.BaoCao_TieuDe;
            config.BaoCao_MauTieuDe = vm.BaoCao_MauTieuDe;
            config.BaoCao_MoTa = vm.BaoCao_MoTa;
            config.BaoCao_MauMoTa = vm.BaoCao_MauMoTa;
            config.BaoCao_TextNut = vm.BaoCao_TextNut;
            config.BaoCao_LinkNut = vm.BaoCao_LinkNut;

            // Cập nhật Section 4: Đơn vị tài trợ
            config.TaiTro_Nhan = vm.TaiTro_Nhan;
            config.TaiTro_TieuDe = vm.TaiTro_TieuDe;
            config.TaiTro_TieuDeNoiBat = vm.TaiTro_TieuDeNoiBat;
            config.TaiTro_MauTieuDe = vm.TaiTro_MauTieuDe;
            config.TaiTro_MoTa = vm.TaiTro_MoTa;

            // Xử lý danh sách Kênh Đóng Góp (Repeater)
            _context.KenhDongGops.RemoveRange(config.KenhDongGops);
            if (vm.KenhDongGops != null)
            {
                int order = 1;
                foreach (var item in vm.KenhDongGops)
                {
                    if (string.IsNullOrWhiteSpace(item.TenKenh)) continue;

                    string qrLink = item.LinkAnhQRCu;
                    if (item.FileAnhQR != null)
                        qrLink = await SaveFileAsync(item.FileAnhQR, "gayquy_qr");

                    _context.KenhDongGops.Add(new KenhDongGop
                    {
                        IDCauHinhGQ = config.IDCauHinhGQ,
                        TenKenh = item.TenKenh,
                        MoTa = item.MoTa,
                        LoaiIcon = item.LoaiIcon,
                        MauIcon = item.MauIcon,
                        MauNenIcon = item.MauNenIcon,
                        MauTieuDe = item.MauTieuDe,
                        MauMoTa = item.MauMoTa,
                        MauNenCard = item.MauNenCard,
                        TextNut = item.TextNut,
                        LoaiHanhDong = item.LoaiHanhDong,
                        LinkNgoai = item.LinkNgoai,
                        LinkAnhQR = qrLink,
                        TenNganHang = item.TenNganHang,
                        SoTaiKhoan = item.SoTaiKhoan,
                        TenChuTaiKhoan = item.TenChuTaiKhoan,
                        NoiDungChuyenKhoan = item.NoiDungChuyenKhoan,
                        GhiChuThem = item.GhiChuThem,
                        ThuTu = order++
                    });
                }
            }

            // Xử lý danh sách Nhà Tài Trợ (Repeater)
            _context.NhaTaiTroGayQuys.RemoveRange(config.NhaTaiTroGayQuys);
            if (vm.NhaTaiTros != null)
            {
                int order = 1;
                foreach (var item in vm.NhaTaiTros)
                {
                    if (string.IsNullOrWhiteSpace(item.TenDonVi)) continue;

                    string logoLink = item.LinkLogoCu;
                    if (item.FileLogo != null)
                        logoLink = await SaveFileAsync(item.FileLogo, "sponsors");

                    _context.NhaTaiTroGayQuys.Add(new NhaTaiTroGayQuy
                    {
                        IDCauHinhGQ = config.IDCauHinhGQ,
                        NhomTaiTro = string.IsNullOrWhiteSpace(item.NhomTaiTro) ? "Đơn vị đồng hành" : item.NhomTaiTro.Trim(),
                        TenDonVi = item.TenDonVi,
                        LinkLogo = logoLink,
                        LinkWebsite = item.LinkWebsite,
                        GioiThieu = item.GioiThieu,
                        ThuTu = order++
                    });
                }
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = $"Đã lưu cấu hình trang Đóng góp - Gây quỹ cho chiến dịch {vm.TenChienDich} thành công!";
            return RedirectToAction(nameof(Index));
        }

        // HÀM HỖ TRỢ LƯU FILE ẢNH
        private async Task<string> SaveFileAsync(IFormFile file, string subFolder)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", subFolder);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string ext = Path.GetExtension(file.FileName);
            string uniqueName = $"{Guid.NewGuid():N}{ext}";
            string filePath = Path.Combine(uploadsFolder, uniqueName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return $"/uploads/{subFolder}/{uniqueName}";
        }
    }
}