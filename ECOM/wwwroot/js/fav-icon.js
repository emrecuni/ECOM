document.addEventListener('DOMContentLoaded', function () {
    const favoriteButtons = document.querySelectorAll('.favorite-btn');

    favoriteButtons.forEach(button => {
        button.addEventListener('click', function () {
            const icon = button.querySelector('i');
            icon.style.color = icon.style.color === 'red' ? '' : 'red'; // Renk değişimi
        });
    });
});