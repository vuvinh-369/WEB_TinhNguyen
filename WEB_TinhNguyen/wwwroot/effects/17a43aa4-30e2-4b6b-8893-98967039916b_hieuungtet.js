// HIỆU ỨNG RƠI ICON NGÀY TẾT (HOA MAI, ĐÀO, LỒNG ĐÈN, LÌ XÌ) - Trăng Sáng Langbiang
(function () {
    const canvas = document.createElement('canvas');
    canvas.id = 'tetCanvas';
    canvas.style.position = 'fixed';
    canvas.style.top = '0';
    canvas.style.left = '0';
    canvas.style.width = '100vw';
    canvas.style.height = '100vh';
    canvas.style.pointerEvents = 'none'; // Người dùng vẫn tương tác web bình thường
    canvas.style.zIndex = '9999'; // Nằm đè lên mọi thứ
    document.body.appendChild(canvas);

    const ctx = canvas.getContext('2d');
    let width = canvas.width = window.innerWidth;
    let height = canvas.height = window.innerHeight;

    const items = [];
    // Các Icon/Emoji đặc trưng của ngày Tết
    const emojis = ['🌸', '🌼', '🏮', '🧧', '✨', '💰']; 
    const numItems = 35; // Số lượng vật thể rơi trên màn hình

    // Khởi tạo các vật thể
    for (let i = 0; i < numItems; i++) {
        items.push({
            x: Math.random() * width,
            y: Math.random() * height - height,
            size: Math.random() * 15 + 15, // Kích thước từ 15px đến 30px
            speedY: Math.random() * 1.2 + 0.6, // Tốc độ rơi
            speedX: Math.random() * 1 - 0.5, // Gió tạt ngang
            angle: Math.random() * 360,
            spin: Math.random() * 2 - 1,
            emoji: emojis[Math.floor(Math.random() * emojis.length)] // Random ngẫu nhiên icon
        });
    }

    // Hàm cập nhật và vẽ
    function draw() {
        ctx.clearRect(0, 0, width, height);

        for (let i = 0; i < numItems; i++) {
            let p = items[i];
            
            ctx.save();
            ctx.translate(p.x, p.y);
            // Xoay nhẹ lồng đèn và bao lì xì cho tự nhiên
            ctx.rotate(p.angle * Math.PI / 180); 
            ctx.font = p.size + "px Arial";
            ctx.textAlign = "center";
            ctx.textBaseline = "middle";
            ctx.fillText(p.emoji, 0, 0);
            ctx.restore();

            // Cập nhật vị trí rơi
            p.y += p.speedY;
            // Hiệu ứng đung đưa trái phải (giống lá rụng)
            p.x += Math.sin(p.y * 0.015) + p.speedX; 
            p.angle += p.spin;

            // Nếu rớt qua khỏi màn hình, quay lại trên đỉnh
            if (p.y > height + 30) {
                p.y = -30;
                p.x = Math.random() * width;
            }
            // Vòng lặp viền trái phải
            if (p.x > width + 30) p.x = -30;
            if (p.x < -30) p.x = width + 30;
        }
        requestAnimationFrame(draw);
    }

    // Tự căn chỉnh lại kích thước khi phóng to/thu nhỏ trình duyệt
    window.addEventListener('resize', () => {
        width = canvas.width = window.innerWidth;
        height = canvas.height = window.innerHeight;
    });

    draw();
})();