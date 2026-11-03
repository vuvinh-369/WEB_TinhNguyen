// HIỆU ỨNG HOA ĐÀO RƠI - Trăng Sáng Langbiang
(function () {
    const canvas = document.createElement('canvas');
    canvas.id = 'daoCanvas';
    canvas.style.position = 'fixed';
    canvas.style.top = '0';
    canvas.style.left = '0';
    canvas.style.width = '100vw';
    canvas.style.height = '100vh';
    canvas.style.pointerEvents = 'none'; // Người dùng vẫn click chuột xuyên qua được
    canvas.style.zIndex = '9999'; // Nằm đè lên mọi thứ
    document.body.appendChild(canvas);

    const ctx = canvas.getContext('2d');
    let width = canvas.width = window.innerWidth;
    let height = canvas.height = window.innerHeight;

    const petals = [];
    const numPetals = 45; // Số lượng cánh hoa đào

    // Khởi tạo thông số cho từng cánh hoa
    for (let i = 0; i < numPetals; i++) {
        petals.push({
            x: Math.random() * width,
            y: Math.random() * height - height,
            size: Math.random() * 6 + 5,      // Kích thước (to hơn xíu)
            speedY: Math.random() * 1.2 + 0.5, // Tốc độ rơi
            speedX: Math.random() * 1.5 - 0.75, // Lực gió tạt ngang
            angle: Math.random() * 360,       // Góc xoay ban đầu
            spin: Math.random() * 2 - 1       // Tốc độ xoay
        });
    }

    // Hàm vẽ 1 cánh hoa đào (Màu hồng gradient)
    function drawPeachPetal(x, y, size, angle) {
        ctx.save();
        ctx.translate(x, y);
        ctx.rotate(angle * Math.PI / 180);

        ctx.beginPath();
        // Cánh hoa đào thường hơi thuôn dài
        ctx.ellipse(0, 0, size, size * 0.65, 0, 0, 2 * Math.PI);
        
        // Tạo dải màu hồng gradient từ cuống ra rìa cánh hoa
        let grad = ctx.createRadialGradient(0, 0, 0, 0, 0, size);
        grad.addColorStop(0, "rgba(255, 105, 180, 0.95)"); // Hồng đậm (Hot Pink) ở giữa
        grad.addColorStop(1, "rgba(255, 192, 203, 0.6)");  // Hồng nhạt (Pink) ở viền
        
        ctx.fillStyle = grad;
        ctx.fill();
        
        // Viền cánh hoa mờ mờ ảo ảo
        ctx.lineWidth = 0.5;
        ctx.strokeStyle = "rgba(219, 112, 147, 0.3)";
        ctx.stroke();

        ctx.restore();
    }

    // Hàm cập nhật chuyển động (Animation)
    function update() {
        ctx.clearRect(0, 0, width, height);

        for (let i = 0; i < numPetals; i++) {
            let p = petals[i];
            drawPeachPetal(p.x, p.y, p.size, p.angle);

            p.y += p.speedY;
            // Thêm hàm sin() tạo hiệu ứng lượn sóng lả lướt trong gió
            p.x += Math.sin(p.y * 0.01) + p.speedX; 
            p.angle += p.spin;

            // Nếu hoa rơi quá đáy màn hình -> đưa lặp lại lên trên đỉnh
            if (p.y > height) {
                p.y = -20;
                p.x = Math.random() * width;
            }
            // Nếu gió tạt quá viền phải/trái màn hình -> vòng lại
            if (p.x > width + 20) p.x = -20;
            if (p.x < -20) p.x = width + 20;
        }
        requestAnimationFrame(update);
    }

    // Đảm bảo canvas không bị co giãn vỡ hạt khi resize thu phóng màn hình
    window.addEventListener('resize', () => {
        width = canvas.width = window.innerWidth;
        height = canvas.height = window.innerHeight;
    });

    // Kích hoạt
    update();
})();