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
            // sayfa ilk yüklendiğinde favori olan ürünlerde kalbi kırmızı yapan butondaki favorite-product sınıfıdır (main.css),
            // bu yüzden i'deki text-danger ile birlikte o da güncellenir
            button.toggleClass("favorite-product", result.isFavorite);
            button.find("i").toggleClass("text-danger", result.isFavorite);
        },
        error: function () {
            alert("Bir hata oluştu, lütfen tekrar deneyin.");
        }
    });
});