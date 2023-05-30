$('#detailsProduct').on('hidden.bs.modal', function () {
    debugger
    $(this).find('form').trigger('reset');
})


function showModal(id) {
    $("#detailsProduct").modal('show')
    $.ajax({
        type: "GET",
        url: "?handler=Details&id=" + id,
        success: function (result) {

            $("#productName").text($("#productName").text() + result.prdName);

            $("#price2").val($("#price2").val() + result.prdPricePerUnit2.toLocaleString());
            $("#price3").val($("#price3").val() + result.prdPricePerUnit3.toLocaleString());
            $("#price4").val($("#price4").val() + result.prdPricePerUnit4.toLocaleString());

        }


    });
}