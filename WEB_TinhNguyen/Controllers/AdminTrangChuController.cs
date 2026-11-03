using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEB_TinhNguyen.Data;
using WEB_TinhNguyen.Models;

namespace WEB_TinhNguyen.Controllers
{
    public class AdminTrangChuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminTrangChuController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private async Task<string?> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;
            if (file.Length > 2 * 1024 * 1024) throw new Exception($"File {file.FileName} vượt quá giới hạn 2MB.");

            string uploadsFolder = Path.Combine(_env.WebRootPath, "gallery");
            if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return "/gallery/" + uniqueFileName;
        }

        // ==========================================================
        // 1. HIỂN THỊ DANH SÁCH CHIẾN DỊCH
        // ==========================================================
        public async Task<IActionResult> Index()
        {
            var chienDichs = await _context.ChienDichs.OrderByDescending(c => c.Nam).ToListAsync();
            return View(chienDichs);
        }

        // ==========================================================
        // 2. THÊM CHIẾN DỊCH MỚI
        // ==========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChienDich(int Nam, string TieuDe)
        {
            if (_context.ChienDichs.Any(c => c.Nam == Nam))
            {
                TempData["Error"] = $"Chiến dịch năm {Nam} đã tồn tại trong hệ thống!";
                return RedirectToAction(nameof(Index));
            }

            var newChienDich = new ChienDich
            {
                Nam = Nam,
                TieuDe = TieuDe,
                TenHienThiMenu = "Mùa " + Nam,
                TrangThaiHoatDong = false
            };

            _context.ChienDichs.Add(newChienDich);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Đã thêm thành công chiến dịch năm {Nam}!";
            return RedirectToAction(nameof(Index));
        }

        // ==========================================================
        // 3. BẬT / TẮT TRẠNG THÁI HIỂN THỊ 
        // ==========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var chienDich = await _context.ChienDichs.FindAsync(id);
            if (chienDich == null) return NotFound();

            if (!chienDich.TrangThaiHoatDong)
            {
                var cacChienDichKhac = await _context.ChienDichs.Where(c => c.IDChienDich != id).ToListAsync();
                foreach (var cd in cacChienDichKhac)
                {
                    cd.TrangThaiHoatDong = false;
                }

                chienDich.TrangThaiHoatDong = true;
                TempData["Success"] = $"Đã BẬT chiến dịch năm {chienDich.Nam} làm Trang chủ hiển thị cho người dùng!";
            }
            else
            {
                chienDich.TrangThaiHoatDong = false;
                TempData["Success"] = $"Đã TẮT chiến dịch năm {chienDich.Nam}. (Lưu ý: Hiện tại trang chủ đang không có chiến dịch nào được bật).";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ==========================================================
        // 4. XÓA CHIẾN DỊCH
        // ==========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChienDich(int id)
        {
            var chienDich = await _context.ChienDichs.FindAsync(id);
            if (chienDich != null)
            {
                _context.ChienDichs.Remove(chienDich);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Đã xóa thành công toàn bộ dữ liệu chiến dịch năm {chienDich.Nam}!";
            }
            return RedirectToAction(nameof(Index));
        }

        // ==========================================================
        // 5. CẤU HÌNH CHI TIẾT (EDIT) - GET
        // ==========================================================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var chienDich = await _context.ChienDichs.FindAsync(id);
            if (chienDich == null) return NotFound();

            var cauHinh = await _context.CauHinhTrangChus
                .Include(c => c.BannerTrangChus)
                .Include(c => c.ChuongTrinhDemNguocs)
                .Include(c => c.CauHinhAnhNois)
                .Include(c => c.TVKhoanhKhacs)
                .Include(c => c.TinTucs)
                .Include(c => c.NhaTaiTros)
                .Include(c => c.FAQs)
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.IDChienDich == id);

            if (cauHinh == null)
            {
                cauHinh = new CauHinhTrangChu { IDChienDich = id };
                _context.CauHinhTrangChus.Add(cauHinh);
                await _context.SaveChangesAsync();
            }

            var emptyEvents = cauHinh.ChuongTrinhDemNguocs?
                .Where(x => string.IsNullOrWhiteSpace(x.TieuDeChinh) && string.IsNullOrWhiteSpace(x.TieuDePhu) && string.IsNullOrWhiteSpace(x.MoTa))
                .ToList();
            if (emptyEvents != null && emptyEvents.Any())
            {
                _context.Set<ChuongTrinhDemNguoc>().RemoveRange(emptyEvents);
                await _context.SaveChangesAsync();
            }

            var vm = new CauHinhTrangChuVM
            {
                IDCauHinh = cauHinh.IDCauHinh,
                IDChienDich = cauHinh.IDChienDich,
                TenChienDich = chienDich.TieuDe,
                TieuDePhu = cauHinh.TieuDePhu,
                TieuDeChinh = cauHinh.TieuDeChinh,
                DoanVanMoTa = cauHinh.DoanVanMoTa,
                LinkAnhBiaCu = cauHinh.LinkAnhBia,
                TocDoChuyenSlide = cauHinh.TocDoChuyenSlide > 0 ? cauHinh.TocDoChuyenSlide : 4000,
                MauChuDao = cauHinh.MauChuDao ?? "#2e7d32",
                MauNhan = cauHinh.MauNhan ?? "#4caf50",
                MauChu = cauHinh.MauChu ?? "#1b5e20",
                MauNenStart = cauHinh.MauNenStart ?? "#ffffff",
                MauNenMid = cauHinh.MauNenMid ?? "#f8fafc",
                MauNenEnd = cauHinh.MauNenEnd ?? "#f3f4f6",
                FontTieuDe = cauHinh.FontTieuDe ?? "Dancing Script",
                FontNoiDung = cauHinh.FontNoiDung ?? "Be Vietnam Pro",
                HienThiCanvas3D = cauHinh.HienThiCanvas3D,
                HienThiLaRoi = cauHinh.HienThiLaRoi,
                VeDuAn_TieuDe = cauHinh.VeDuAn_TieuDe,
                VeDuAn_NoiDung = cauHinh.VeDuAn_NoiDung,
                VeDuAn_LinkAnhCu = cauHinh.VeDuAn_LinkAnh,
                VeDuAn_MauTieuDe = cauHinh.VeDuAn_MauTieuDe ?? "#1b5e20",
                VeDuAn_MauChu = cauHinh.VeDuAn_MauChu ?? "#374151",
                VeDuAn_MauNenTag = cauHinh.VeDuAn_MauNenTag ?? "#4caf50",
                IDHieuUng = cauHinh.IDHieuUng,
                HienThiMascot = cauHinh.HienThiMascot,
                LinkAnhMascotCu = cauHinh.LinkAnhMascot,
                ViTriMascot = cauHinh.ViTriMascot ?? "right",
                Banners = cauHinh.BannerTrangChus?.Where(x => !string.IsNullOrWhiteSpace(x.LinkAnh)).Select(x => new BannerTrangChuVM { LinkAnhCu = x.LinkAnh, TieuDeAlt = x.TieuDeAlt }).ToList() ?? new(),
                ChuongTrinhs = cauHinh.ChuongTrinhDemNguocs?.Where(x => !string.IsNullOrWhiteSpace(x.TieuDeChinh) || !string.IsNullOrWhiteSpace(x.TieuDePhu) || !string.IsNullOrWhiteSpace(x.MoTa)).Select(x => new ChuongTrinhDemNguocVM { TieuDePhu = x.TieuDePhu, TieuDeChinh = x.TieuDeChinh, MoTa = x.MoTa, ThoiGianHienThi = x.ThoiGianHienThi, ThoiGianBatDau = x.ThoiGianBatDau, ThoiGianKetThuc = x.ThoiGianKetThuc, MauNenStart = x.MauNenStart, MauNenEnd = x.MauNenEnd, MauChu = x.MauChu, EpKetThuc = x.EpKetThuc }).ToList() ?? new(),
                AnhNois = cauHinh.CauHinhAnhNois?.Where(x => !string.IsNullOrWhiteSpace(x.LinkAnh)).Select(x => new CauHinhAnhNoiVM { LinkAnhCu = x.LinkAnh, TieuDeAlt = x.TieuDeAlt, ChieuSau = x.ChieuSau, ViTriTop = x.ViTriTop, CanLe = x.CanLe, KhoangCachLe = x.KhoangCachLe, KichThuoc = x.KichThuoc, DoTreAnimation = x.DoTreAnimation, GocXoay = x.GocXoay }).ToList() ?? new(),
                TVKhoanhKhacs = cauHinh.TVKhoanhKhacs?.Where(x => !string.IsNullOrWhiteSpace(x.LinkAnh) || !string.IsNullOrWhiteSpace(x.TieuDe)).Select(x => new TVKhoanhKhacVM { TieuDe = x.TieuDe, MoTa = x.MoTa, LinkAnhCu = x.LinkAnh }).ToList() ?? new(),
                TinTucs = cauHinh.TinTucs?.Where(x => !string.IsNullOrWhiteSpace(x.TieuDe)).Select(x => new TinTucTrangChuVM { TieuDe = x.TieuDe, TrichDan = x.TrichDan, ThePhanLoai = x.ThePhanLoai, LinkChuyenHuong = x.LinkChuyenHuong, LuotThich = x.LuotThich, LinkAnhCu = x.LinkAnh, NoiDungChiTiet = x.NoiDungChiTiet, MauTieuDe = x.MauTieuDe ?? "#1b5e20", KichCoTieuDe = x.KichCoTieuDe ?? "18px" }).ToList() ?? new(),
                NhaTaiTros = cauHinh.NhaTaiTros?.Where(x => !string.IsNullOrWhiteSpace(x.TenDonVi)).Select(x => new NhaTaiTroTrangChuVM { TenDonVi = x.TenDonVi, NhomTaiTro = x.NhomTaiTro, LinkLogoCu = x.LinkLogo }).ToList() ?? new(),
                FAQs = cauHinh.FAQs?.Where(x => !string.IsNullOrWhiteSpace(x.CauHoi)).Select(x => new FAQTrangChuVM { CauHoi = x.CauHoi, CauTraLoi = x.CauTraLoi }).ToList() ?? new()
            };

            // LẤY DANH SÁCH HIỆU ỨNG TỪ DB ĐỂ TRUYỀN RA DROPDOWN
            ViewBag.DanhSachHieuUng = await _context.ThuVienHieuUngs.ToListAsync();
            return View(vm);
        }

        // ==========================================================
        // 6. CẤU HÌNH CHI TIẾT (EDIT) - POST
        // ==========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CauHinhTrangChuVM vm)
        {
            ModelState.Clear();
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var cauHinh = await _context.CauHinhTrangChus.FindAsync(vm.IDCauHinh);
                if (cauHinh == null) return RedirectToAction(nameof(Index));

                cauHinh.TieuDeChinh = vm.TieuDeChinh;
                cauHinh.TieuDePhu = vm.TieuDePhu;
                cauHinh.DoanVanMoTa = vm.DoanVanMoTa;
                cauHinh.TocDoChuyenSlide = vm.TocDoChuyenSlide > 0 ? vm.TocDoChuyenSlide : 4000;
                cauHinh.MauChuDao = vm.MauChuDao;
                cauHinh.MauNhan = vm.MauNhan;
                cauHinh.MauChu = vm.MauChu;
                cauHinh.MauNenStart = vm.MauNenStart;
                cauHinh.MauNenMid = vm.MauNenMid;
                cauHinh.MauNenEnd = vm.MauNenEnd;
                cauHinh.FontTieuDe = vm.FontTieuDe;
                cauHinh.FontNoiDung = vm.FontNoiDung;
                cauHinh.HienThiCanvas3D = vm.HienThiCanvas3D;
                cauHinh.HienThiLaRoi = vm.HienThiLaRoi;
                cauHinh.IDHieuUng = vm.IDHieuUng;
                // LƯU CẤU HÌNH LINH VẬT
                cauHinh.HienThiMascot = vm.HienThiMascot;
                cauHinh.ViTriMascot = vm.ViTriMascot;
                if (vm.FileAnhMascot != null)
                    cauHinh.LinkAnhMascot = await UploadFileAsync(vm.FileAnhMascot);
                else
                    cauHinh.LinkAnhMascot = vm.LinkAnhMascotCu;
                cauHinh.NgayCapNhat = DateTime.Now;

                if (vm.FileAnhBia != null) cauHinh.LinkAnhBia = await UploadFileAsync(vm.FileAnhBia);
                else cauHinh.LinkAnhBia = vm.LinkAnhBiaCu;

                cauHinh.VeDuAn_TieuDe = vm.VeDuAn_TieuDe;
                cauHinh.VeDuAn_NoiDung = vm.VeDuAn_NoiDung;
                cauHinh.VeDuAn_MauTieuDe = vm.VeDuAn_MauTieuDe;
                cauHinh.VeDuAn_MauChu = vm.VeDuAn_MauChu;
                cauHinh.VeDuAn_MauNenTag = vm.VeDuAn_MauNenTag;
                if (vm.VeDuAn_FileAnh != null) cauHinh.VeDuAn_LinkAnh = await UploadFileAsync(vm.VeDuAn_FileAnh);
                else cauHinh.VeDuAn_LinkAnh = vm.VeDuAn_LinkAnhCu;

                // XÓA DATA CŨ
                _context.Set<BannerTrangChu>().RemoveRange(_context.Set<BannerTrangChu>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                _context.Set<ChuongTrinhDemNguoc>().RemoveRange(_context.Set<ChuongTrinhDemNguoc>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                _context.Set<CauHinhAnhNoi>().RemoveRange(_context.Set<CauHinhAnhNoi>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                _context.Set<TVKhoanhKhac>().RemoveRange(_context.Set<TVKhoanhKhac>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                _context.Set<TinTucTrangChu>().RemoveRange(_context.Set<TinTucTrangChu>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                _context.Set<NhaTaiTroTrangChu>().RemoveRange(_context.Set<NhaTaiTroTrangChu>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                _context.Set<FAQTrangChu>().RemoveRange(_context.Set<FAQTrangChu>().Where(x => x.IDCauHinh == cauHinh.IDCauHinh));
                await _context.SaveChangesAsync();

                // LƯU DATA MỚI
                if (vm.Banners != null) { foreach (var item in vm.Banners) { string imgPath = item.FileAnh != null ? await UploadFileAsync(item.FileAnh) : item.LinkAnhCu; if (!string.IsNullOrWhiteSpace(imgPath)) _context.Set<BannerTrangChu>().Add(new BannerTrangChu { IDCauHinh = cauHinh.IDCauHinh, LinkAnh = imgPath, TieuDeAlt = item.TieuDeAlt?.Trim() }); } }
                if (vm.ChuongTrinhs != null) { foreach (var item in vm.ChuongTrinhs) { if (string.IsNullOrWhiteSpace(item.TieuDeChinh) && string.IsNullOrWhiteSpace(item.TieuDePhu) && string.IsNullOrWhiteSpace(item.MoTa)) continue; _context.Set<ChuongTrinhDemNguoc>().Add(new ChuongTrinhDemNguoc { IDCauHinh = cauHinh.IDCauHinh, TieuDePhu = item.TieuDePhu?.Trim(), TieuDeChinh = item.TieuDeChinh?.Trim(), MoTa = item.MoTa?.Trim(), ThoiGianHienThi = item.ThoiGianHienThi?.Trim(), ThoiGianBatDau = item.ThoiGianBatDau, ThoiGianKetThuc = item.ThoiGianKetThuc, MauNenStart = item.MauNenStart ?? "#ffffff", MauNenEnd = item.MauNenEnd ?? "#f8fafc", MauChu = item.MauChu ?? "#2e7d32", EpKetThuc = item.EpKetThuc }); } }
                if (vm.AnhNois != null) { foreach (var item in vm.AnhNois) { string imgPath = item.FileAnh != null ? await UploadFileAsync(item.FileAnh) : item.LinkAnhCu; if (string.IsNullOrWhiteSpace(imgPath)) continue; _context.Set<CauHinhAnhNoi>().Add(new CauHinhAnhNoi { IDCauHinh = cauHinh.IDCauHinh, LinkAnh = imgPath, TieuDeAlt = item.TieuDeAlt, ViTriTop = item.ViTriTop ?? "0%", CanLe = item.CanLe ?? "left", KhoangCachLe = item.KhoangCachLe ?? "0px", KichThuoc = item.KichThuoc ?? "100px", DoTreAnimation = item.DoTreAnimation ?? "0s", GocXoay = item.GocXoay ?? "0deg", ChieuSau = item.ChieuSau, TrangThai = true }); } }
                if (vm.TVKhoanhKhacs != null) { foreach (var item in vm.TVKhoanhKhacs) { string imgPath = item.FileAnh != null ? await UploadFileAsync(item.FileAnh) : item.LinkAnhCu; if (string.IsNullOrWhiteSpace(imgPath) && string.IsNullOrWhiteSpace(item.TieuDe)) continue; _context.Set<TVKhoanhKhac>().Add(new TVKhoanhKhac { IDCauHinh = cauHinh.IDCauHinh, TieuDe = item.TieuDe?.Trim(), MoTa = item.MoTa?.Trim(), LinkAnh = imgPath }); } }
                if (vm.TinTucs != null) { foreach (var item in vm.TinTucs) { if (string.IsNullOrWhiteSpace(item.TieuDe)) continue; string imgPath = item.FileAnh != null ? await UploadFileAsync(item.FileAnh) : item.LinkAnhCu; _context.Set<TinTucTrangChu>().Add(new TinTucTrangChu { IDCauHinh = cauHinh.IDCauHinh, TieuDe = item.TieuDe?.Trim(), TrichDan = item.TrichDan?.Trim(), ThePhanLoai = item.ThePhanLoai?.Trim(), LinkChuyenHuong = item.LinkChuyenHuong?.Trim(), LuotThich = item.LuotThich, LinkAnh = imgPath, NoiDungChiTiet = item.NoiDungChiTiet, MauTieuDe = item.MauTieuDe ?? "#1b5e20", KichCoTieuDe = item.KichCoTieuDe ?? "18px" }); } }
                if (vm.NhaTaiTros != null) { foreach (var item in vm.NhaTaiTros) { string imgPath = item.FileLogo != null ? await UploadFileAsync(item.FileLogo) : item.LinkLogoCu; if (string.IsNullOrWhiteSpace(item.TenDonVi) && string.IsNullOrWhiteSpace(imgPath)) continue; _context.Set<NhaTaiTroTrangChu>().Add(new NhaTaiTroTrangChu { IDCauHinh = cauHinh.IDCauHinh, TenDonVi = item.TenDonVi?.Trim(), NhomTaiTro = string.IsNullOrWhiteSpace(item.NhomTaiTro) ? "Đơn vị đồng hành" : item.NhomTaiTro.Trim(), LinkLogo = imgPath }); } }
                if (vm.FAQs != null) { foreach (var item in vm.FAQs) { if (string.IsNullOrWhiteSpace(item.CauHoi)) continue; _context.Set<FAQTrangChu>().Add(new FAQTrangChu { IDCauHinh = cauHinh.IDCauHinh, CauHoi = item.CauHoi.Trim(), CauTraLoi = item.CauTraLoi?.Trim() }); } }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                TempData["Success"] = "Đã cập nhật thành công toàn bộ nội dung Trang chủ!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["Error"] = "Lỗi lưu dữ liệu: " + ex.Message;
                return View(vm);
            }
        }

        // ==========================================================
        // 7. UPLOAD FILE HIỆU ỨNG NHANH TRỰC TIẾP TỪ TRANG CẤU HÌNH
        // ==========================================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadHieuUngNhanh(int idChienDich, string tenHieuUng, IFormFile fileJS)
        {
            if (fileJS != null && fileJS.Length > 0 && fileJS.FileName.EndsWith(".js"))
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "effects");
                if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileJS.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileJS.CopyToAsync(fileStream);
                }

                var hieuUng = new ThuVienHieuUng
                {
                    TenHieuUng = tenHieuUng,
                    LinkFileJS = "/effects/" + uniqueFileName,
                    TrangThai = true
                };

                _context.ThuVienHieuUngs.Add(hieuUng);
                await _context.SaveChangesAsync();

                TempData["Success"] = $"Đã tải lên hiệu ứng '{tenHieuUng}' thành công. Bạn có thể chọn nó trong danh sách!";
            }
            else
            {
                TempData["Error"] = "Vui lòng chọn đúng file mã lệnh .js hợp lệ!";
            }

            return RedirectToAction("Edit", new { id = idChienDich });
        }
    }
}