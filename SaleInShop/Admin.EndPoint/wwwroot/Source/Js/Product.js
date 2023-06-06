﻿$('#detailsProduct').on('hidden.bs.modal', function () {
    debugger
    $(this).find('form').trigger('reset');
})

const table = $('#property-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    searching: false,
});

function showModal(id) {
    $("#detailsProduct").modal('show')
    $.ajax({
        type: "GET",
        url: "?handler=Details&id=" + id,
        success: function (result) {
            debugger
            $("#productName").text($("#productName").text() + result.prdName);

            $("#price2").val($("#price2").val() + result.prdPricePerUnit2.toLocaleString());
            $("#price3").val($("#price3").val() + result.prdPricePerUnit3.toLocaleString());
            $("#price4").val($("#price4").val() + result.prdPricePerUnit4.toLocaleString());
            $("#price5").val($("#price5").val() + result.prdPricePerUnit5.toLocaleString());


            table.clear().draw();
            result.properties.forEach(x => {
                const list =
                    `
                                                  <tr>
                                                      <td>${x.propertyName ?? ""}</td>
                                                       <td>${x.value ?? ""}</td>
                                                
                                                    </tr>
                                                                         `
                table.row.add($(list)).draw();
            });
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


$("input[name='Command.PrdDiscountType']").change(function () {
    debugger
    $("#dicountDis").text("تخفیف را به " + this.value + " " + "وارد کنید  ")
});




$("#submit-property").on("click", function (env) {
    env.preventDefault();
    debugger
    var value = $("#propertyValue").val();
    var id = $("#propertyName").val();
    if (value==="" || id==0) {
        notify("top center", "فرم را به درستی پر کنید", "error")
        return false;
    }

   
    var name = $("#propertyName option:selected").text();
    $.ajax({
        type: "get",
        url: "/Products/Create?handler=Property&id=" + id + "&name=" + name + "&value=" + value,

        success: function (list) {
            debugger
            if (list === "Duplicate") {
                notify("top center", "این ویژگی از قبل وجود دارد", "warning");
                return false;
            }
            table.clear().draw();
            $("#propertyName").val(0);
            $("#propertyValue").val("");
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
        url: "/Products/Create?handler=removeProperty&id=" + id,
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


function CheckControl() {
    debugger
}




function readURL(input) {
   
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = (function (theFile) {
          
            $('#imgCourse').attr('src', theFile.target.result);

            var image = new Image();
            image.src = theFile.target.result;

            image.onload = function () {
                // access image size here
                if (this.width === 600 && this.height === 600) {
                    {

                    }
                } else {
                    notify("top center", "طول و عرض عکس باید 600 در 600 پیکسل باشد","error")
                   
                }

            };
        });

        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgCourseUp").change(function () {
    readURL(this);
});
