document.addEventListener("DOMContentLoaded", function () {
    const links = document.querySelectorAll(".menu-container ul li a");

    links.forEach(link => {
        link.addEventListener("click", function () {
            // Önce tüm öğelerden active sınıfını kaldır
            links.forEach(l => l.classList.remove("active"));

            // Tıklanan öğeye active sınıfını ekle
            this.classList.add("active");
        });
    });
});