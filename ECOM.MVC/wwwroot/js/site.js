// ===== SITE.JS - Modern E-COM =====

document.addEventListener('DOMContentLoaded', function () {

    // ===== Active Category Link =====
    const currentPath = window.location.pathname;
    document.querySelectorAll('.cat-link').forEach(link => {
        if (link.href && currentPath.includes(encodeURIComponent(link.getAttribute('asp-route-category') || ''))) {
            link.classList.add('active');
        }
    });

    // ===== Smooth scroll for anchor links =====
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const targetId = this.getAttribute('href').substring(1);
            const target = document.getElementById(targetId);
            if (target) {
                e.preventDefault();
                target.scrollIntoView({ behavior: 'smooth', block: 'start' });
            }
        });
    });

    // ===== Toast Notification System =====
    window.showToast = function (message, type = 'success') {
        const toast = document.createElement('div');
        toast.className = `ecom-toast ecom-toast--${type}`;
        toast.innerHTML = `
            <i class="fas fa-${type === 'success' ? 'check-circle' : type === 'error' ? 'times-circle' : 'info-circle'}"></i>
            <span>${message}</span>
        `;

        if (!document.getElementById('ecom-toast-container')) {
            const container = document.createElement('div');
            container.id = 'ecom-toast-container';
            container.style.cssText = `
                position: fixed;
                top: 80px;
                right: 20px;
                z-index: 9999;
                display: flex;
                flex-direction: column;
                gap: 8px;
            `;
            document.body.appendChild(container);
        }

        const toastStyle = `
            display: flex;
            align-items: center;
            gap: 10px;
            padding: 14px 20px;
            background: white;
            border-radius: 12px;
            box-shadow: 0 8px 24px rgba(0,0,0,0.12);
            font-family: 'DM Sans', sans-serif;
            font-size: 14px;
            font-weight: 500;
            color: #1A1A2E;
            min-width: 280px;
            border-left: 4px solid ${type === 'success' ? '#38A169' : type === 'error' ? '#E53E3E' : '#FF6B00'};
            animation: slideInRight 0.3s ease;
            transition: all 0.3s ease;
        `;

        toast.style.cssText = toastStyle;

        const icon = toast.querySelector('i');
        if (icon) {
            icon.style.color = type === 'success' ? '#38A169' : type === 'error' ? '#E53E3E' : '#FF6B00';
            icon.style.fontSize = '18px';
        }

        document.getElementById('ecom-toast-container').appendChild(toast);

        setTimeout(() => {
            toast.style.opacity = '0';
            toast.style.transform = 'translateX(20px)';
            setTimeout(() => toast.remove(), 300);
        }, 3000);
    };

    // ===== Add to Cart Animation =====
    document.querySelectorAll('.btn-add-cart, .addCart').forEach(btn => {
        btn.addEventListener('click', function (e) {
            const originalContent = this.innerHTML;
            this.innerHTML = '<i class="fas fa-check"></i> Sepete Eklendi';
            this.style.background = 'linear-gradient(135deg, #38A169, #2F8A5B)';
            this.disabled = true;

            setTimeout(() => {
                this.innerHTML = originalContent;
                this.style.background = '';
                this.disabled = false;
            }, 2000);
        });
    });

    // ===== Quantity Input Validation =====
    document.querySelectorAll('.order-count').forEach(input => {
        input.addEventListener('change', function () {
            if (parseInt(this.value) < 1) this.value = 1;
            if (parseInt(this.value) > 99) this.value = 99;
        });
    });

    // ===== Image Zoom on Product Page =====
    const mainImg = document.querySelector('.product-main-img img');
    if (mainImg) {
        mainImg.addEventListener('mousemove', function (e) {
            const rect = this.getBoundingClientRect();
            const x = ((e.clientX - rect.left) / rect.width) * 100;
            const y = ((e.clientY - rect.top) / rect.height) * 100;
            this.style.transformOrigin = `${x}% ${y}%`;
        });
    }

    // ===== Back to Top =====
    const backToTop = document.createElement('button');
    backToTop.innerHTML = '<i class="fas fa-arrow-up"></i>';
    backToTop.style.cssText = `
        position: fixed;
        bottom: 28px;
        right: 28px;
        width: 44px;
        height: 44px;
        background: linear-gradient(135deg, #FF6B00, #E55A00);
        color: white;
        border: none;
        border-radius: 50%;
        cursor: pointer;
        box-shadow: 0 4px 14px rgba(255,107,0,0.35);
        display: none;
        align-items: center;
        justify-content: center;
        font-size: 14px;
        z-index: 999;
        transition: all 0.2s ease;
    `;
    document.body.appendChild(backToTop);

    window.addEventListener('scroll', () => {
        backToTop.style.display = window.scrollY > 400 ? 'flex' : 'none';
    });

    backToTop.addEventListener('click', () => {
        window.scrollTo({ top: 0, behavior: 'smooth' });
    });

    backToTop.addEventListener('mouseenter', () => {
        backToTop.style.transform = 'translateY(-3px)';
    });

    backToTop.addEventListener('mouseleave', () => {
        backToTop.style.transform = 'translateY(0)';
    });
});

// ===== CSS Animation Keyframes =====
const style = document.createElement('style');
style.textContent = `
    @keyframes slideInRight {
        from { opacity: 0; transform: translateX(20px); }
        to { opacity: 1; transform: translateX(0); }
    }
`;
document.head.appendChild(style);
