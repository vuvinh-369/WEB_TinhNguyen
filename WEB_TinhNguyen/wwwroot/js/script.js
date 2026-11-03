const slides = [
  { src: "assets/joy.jpg", alt: "Các em nhỏ trong hoạt động của Trăng Sáng Langbiang", caption: "Khoảnh khắc yêu thương · Langbiang 2025" },
  { src: "assets/lanterns.jpg", alt: "Em nhỏ nhận quà trong chương trình Langbiang", caption: "Niềm vui giản dị · Langbiang 2025" },
  { src: "assets/journey.jpg", alt: "Các em nhỏ và tình nguyện viên cùng tham gia hoạt động", caption: "Cùng nhau tạo nên kỷ niệm · Langbiang 2025" }
];

const heroImage = document.querySelector("#hero-image");
const heroCaption = document.querySelector("#hero-caption");
const slideCount = document.querySelector("#slide-count");
let currentSlide = 0;

function showSlide(index) {
  currentSlide = (index + slides.length) % slides.length;
  const slide = slides[currentSlide];
  heroImage.src = slide.src;
  heroImage.alt = slide.alt;
  heroCaption.textContent = slide.caption;
  slideCount.innerHTML = `${String(currentSlide + 1).padStart(2, "0")} <span>/ 03</span>`;
}

document.querySelector("#prev-slide").addEventListener("click", () => showSlide(currentSlide - 1));
document.querySelector("#next-slide").addEventListener("click", () => showSlide(currentSlide + 1));

const header = document.querySelector(".site-header");
const menuButton = document.querySelector(".menu-toggle");
const nav = document.querySelector("#main-nav");

function closeMenu() {
  menuButton.setAttribute("aria-expanded", "false");
  menuButton.setAttribute("aria-label", "Mở menu");
  nav.classList.remove("is-open");
}

menuButton.addEventListener("click", () => {
  const isOpen = menuButton.getAttribute("aria-expanded") === "true";
  menuButton.setAttribute("aria-expanded", String(!isOpen));
  menuButton.setAttribute("aria-label", isOpen ? "Mở menu" : "Đóng menu");
  nav.classList.toggle("is-open", !isOpen);
});

nav.querySelectorAll("a").forEach(link => link.addEventListener("click", closeMenu));
document.addEventListener("keydown", event => {
  if (event.key === "Escape") closeMenu();
});
window.addEventListener("scroll", () => header.classList.toggle("is-scrolled", window.scrollY > 20), { passive: true });

const themeButton = document.querySelector(".theme-toggle");
let savedTheme;
try { savedTheme = localStorage.getItem("trang-sang-theme"); } catch { savedTheme = null; }
const initialTheme = savedTheme || (window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light");

function setTheme(theme) {
  document.documentElement.dataset.theme = theme;
  themeButton.setAttribute("aria-label", theme === "dark" ? "Chuyển sang giao diện ngày" : "Chuyển sang giao diện đêm");
  document.querySelector('meta[name="theme-color"]').content = theme === "dark" ? "#0c1712" : "#fdfcf5";
}

setTheme(initialTheme);
themeButton.addEventListener("click", () => {
  const theme = document.documentElement.dataset.theme === "dark" ? "light" : "dark";
  setTheme(theme);
  try { localStorage.setItem("trang-sang-theme", theme); } catch {}
});
