﻿$('#detailsProduct').on('hidden.bs.modal', function () {
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


var secondUpload = new FileUploadWithPreview('mySecondImage')



$(".checkbox").change(function () {
    if (this.checked) {
        $("#prodcut-unit").modal('show')

    }
});
$(".product-unit").change(function () {
    if (this.checked) {
        $("#related-products").modal('show')
    }
});


$("input[name='dicountType']").change(function () {
    debugger
    $("#dicountDis").text("تخفیف را به " + this.value + " " + "وارد کنید  ")
});


const table = $('#property-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    searching: false,
});


$("#submit-property").on("click", function (env) {
    env.preventDefault();
    debugger
    var form = $("#submitProperty");
    var isValid = form.validate();
    if (!isValid) {
        nofity("top center", "فرم را به درستی پر کنید", "error")
        return false;
    }

    var value = $("#propertyValue").val();
    var id = $("#propertyName").val();
    var name = $("#propertyName option:selected").text();
    $.ajax({
        type: "get",
        url: "?handler=Property&id=" + id + "&name=" + name + "&value=" + value,

        success: function (list) {
            debugger
            if (list === "Duplicate") {
                notify("top center", "این ویژگی از قبل وجود دارد", "warning");
                return false;
            }
            table.clear().draw();
            list.forEach(x => {
                const result =
                    `
    <tr>
        <td>${x.name ?? ""}</td>
        <td>${x.value ?? ""}</td>
        <td>
            <button type="button" class="btn btn-sm btn-danger btn-rounded" onclick="(removeProperty('${x.id}'))">حذف</button>
        </td>
    </tr>
    `
                table.row.add($(result)).draw();
            });

        }

    });

})


function removeProperty(id) {

    $.ajax({
        url: "?handler=removeProperty&id=" + id,
        type: "get",
        success: function (list) {
            debugger
            table.clear().draw();
            list.forEach(x => {
                const result =
                    `
                                          <tr>
                                              <td>${x.name ?? ""}</td>
                                               <td>${x.value ?? ""}</td>
                                               <td>
                                                    <button type="button" class="btn btn-sm btn-danger btn-rounded" onclick="(removeProperty('${x.id}'))">حذف</button>
                                                 </td>
                                            </tr>
                                                                 `
                table.row.add($(result)).draw();
            });

        }
    })
}
