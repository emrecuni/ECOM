var verifyCode = document.getElementById('verifyOtpCode');

(function () {
    var form = document.getElementById('resetPassword');
    var password = document.getElementById('password');
    var rePassword = document.getElementById('rePassword');
    var errorEl = document.getElementById('passwordMatchError');

    // Rule: min 8 chars, at least one uppercase, one lowercase, one digit
    var passwordRule = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$/;

    function validate() {
        var isValid = true;
        errorEl.style.display = 'none';
        password.setCustomValidity('');
        rePassword.setCustomValidity('');

        if (password.value && !passwordRule.test(password.value)) {
            password.setCustomValidity('Parola en az 8 karakter olmalı ve büyük harf, küçük harf, rakam içermelidir.');
            isValid = false;
        }

        if (rePassword.value && password.value !== rePassword.value) {
            errorEl.style.display = 'block';
            rePassword.setCustomValidity('Parolalar eşleşmiyor.');
            isValid = false;
        }

        return isValid;
    }

    password.addEventListener('input', validate);
    rePassword.addEventListener('input', validate);

    form.addEventListener('submit', function (e) {
        if (!validate()) {
            e.preventDefault();
        }
    });
})();