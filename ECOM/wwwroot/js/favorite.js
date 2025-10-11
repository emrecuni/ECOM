$(document).off("click", ".favorite-btn"); // önceki handler'ları sil
$(document).on("click", ".favorite-btn", function (e) {
    e.preventDefault(); // Linkin sayfayı yenilemesini engeller
    console.log("Tıklandı"); // test
    var productId = $(this).data("id");
    var button = $(this);

    $.ajax({
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        url: '/Main/Favorite',  // Controller/Action
        type: 'POST',
        data: { id: productId },
        success: function (result) {
            if (result.isFavorite) {
                button.find("i").addClass("text-danger"); // Kalp kırmızı olsun
            } else {
                button.find("i").removeClass("text-danger"); // Favoriden çıkar
            }
        },
        error: function () {
            alert("Bir hata oluştu, lütfen tekrar deneyin.");
        }
    });
});