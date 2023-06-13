
var quill = new Quill('#editor-container', {
    modules: {
        toolbar: [
            [{ header: [1, 2, false] }],
            ['bold', 'italic', 'underline'],
            ['image', 'code-block']
        ]
    },
    placeholder: 'توضیحات را وارد نمایید...',
    theme: 'snow'  // or 'bubble'
});


const table = $('#property-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    searching: false,
});


const pictureTable = $('#picture-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    searching: false,
});

var secondUpload = new FileUploadWithPreview('mySecondImage');




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
    var input = $("input[name='Command.PrdDiscount");
    input.prop('disabled', false);

    if (this.value == 0)
        input.prop('max', 100);
    else input.prop('max', null);

    var text = "";
    if (this.value == 0)
        text = "درصد";
    else text = "مبلغ"

    $("#dicountDis").text("تخفیف را به " + text + " " + "وارد کنید  ")
});




$("#submit-property").on("click", function (env) {
    env.preventDefault();
    debugger
    var value = $("#propertyValue").val();
    var id = $("#propertyName").val();
    if (value === "" || id == 0) {
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


$("#submit-propertyEdit").on("click", function (env) {
    env.preventDefault();
    debugger
    var value = $("#propertyValue").val();
    var id = $("#propertyName").val();
    if (value === "" || id == 0) {
        notify("top center", "فرم را به درستی پر کنید", "error")
        return false;
    }


    var name = $("#propertyName option:selected").text();
    $.ajax({
        type: "get",
        url: "?handler=AddProperty&propertyId=" + id + "&name=" + name + "&value=" + value,

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
            <button type="button" class="btn btn-sm btn-danger btn-rounded" onclick="(removePropertyEdit('${x.id}'))">حذف</button>
        </td>
    </tr>
    `
                table.row.add($(result)).draw();
            });

        }

    });

})


function removePropertyEdit(id) {

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
                               <button type="button" class="btn btn-sm btn-danger btn-rounded" onclick="(removePropertyEdit('${x.id}'))">حذف</button>
                            </td>
                       </tr>
                                            `
                table.row.add($(result)).draw();
            });

        }
    })
}


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


function removePicture(id) {

    $.ajax({
        url: "?handler=RemovePictures&id=" + id,
        type: "get",
        success: function (list) {
            debugger
            pictureTable.clear().draw();
            list.forEach(x => {
                const result =
                    `
                     <tr>
                         <td> <img src="data:image/png;base64,${x.imageBase64 ?? ""}" alt="" style="max-width:80px; max-height:100px" /></td>
                           
                          <td>
                               <button type="button" class="btn btn-sm btn-danger btn-rounded" onclick="(removePicture('${x.id}'))">حذف</button>
                            </td>
                       </tr>
                                            `
                pictureTable.row.add($(result)).draw();
            });

        }
    })
}


function CheckControl(value) {
    debugger
    $.ajax({
        url: "?handler=CheckCode&Code=" + value,
        type: "Get",
        success: function (result) {
            debugger
            $("#validateCode").text("")
            $("#validateCode").text(result)
        }
    })
}




function readURL(input) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = (function (theFile) {

            var image = new Image();
            image.src = theFile.target.result;

            var preview = document.getElementById("preViewImg");
            preview.src = image.src;

            image.onload = function () {
                if (this.width === 600 && this.height === 600) {
                    {

                        $("#validateImg").text("")
                        //TO Do validation
                    }
                } else {
                    $("#validateImg").text("سایز عکس معتبر نیست")

                }
            };
        });
        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgCourseUp").change(function () {
    readURL(this);
});

var submitForm1 = false;
var submitForm2 = false;
var submitForm3 = false;

$("#first-form").on('click', function (env) {
    env.preventDefault();

    debugger
    var form = $("#createForm");
    form.validate();
    if (form.valid() === false) {

        var elements = document.getElementsByClassName("input-validation-error");
        for (var i = 0; i < elements.length; i++) {
            elements[i].style.backgroundColor = "ivory";
            elements[i].style.border = "none";
            elements[i].style.outline = "1px solid red";
            elements[i].style.borderRadius = "5px";
        }

        return false;
    }
    var vali = form.validate();

    if (!vali.valid()) {
        notify("top center", "فرم را به درستی پر کنید", "error");
        return false;
    }


    if ($("#productUnit").prop('checked') == true) {

        var unit2 = $("#FkProductUnit2").val();
        var Coefficient = $("#PrdCoefficient").val();
        var bigger = $("input[name='inlineRadioOptions']").val();

        $("#Command_FkProductUnit2").val(unit2);
        $("#Command_PrdCoefficient").val(Coefficient);
        $("#Command_PrdIsUnit1Bigger").val(bigger);

        if (unit2 === "" || Coefficient === "") {
            notify("top center", "واحد شمارش 2 و ضریب آن را وارد کنید!", "error")
            return false;
        }
    };
    notify("top center", "فرم تایید شد", "success");
    $("#justify-profile-tab").removeClass("disabled");
    submitForm1 = true;

});



$("#second-form").on('click', function (env) {
    env.preventDefault();

    var form = $("#createForm");
    form.validate();
    if (form.valid() === false) {

        var elements = document.getElementsByClassName("input-validation-error");
        for (var i = 0; i < elements.length; i++) {
            elements[i].style.backgroundColor = "ivory";
            elements[i].style.border = "none";
            elements[i].style.outline = "1px solid red";
            elements[i].style.borderRadius = "5px";
        }

        return false;
    }
    var vali = form.validate();

    if (!vali.valid()) {
        notify("top center", "فرم را به درستی پر کنید", "error");
        return false;
    }

    debugger
    var editor_content = quill.container.innerHTML
    $("#Command_WebDescription").val(editor_content);
    notify("top center", "فرم تایید شد", "success");
    $("#justify-contact-tab").removeClass("disabled");
    $("#justify-pictures-tab").removeClass("disabled");

    submitForm2 = true;

});


$("#final-submit").on('click', function (env) {
    env.preventDefault();

    if (!submitForm1 || !submitForm2) {
        notify("top center", "ابتدا فرم ها را تایید کنید", "error");
        return false;
    }
   
   
    debugger
    var form = $("#createForm");
    form.validate();
    if (form.valid() === false) {

        var elements = document.getElementsByClassName("input-validation-error");
        for (var i = 0; i < elements.length; i++) {
            elements[i].style.backgroundColor = "ivory";
            elements[i].style.border = "none";
            elements[i].style.outline = "1px solid red";
            elements[i].style.borderRadius = "5px";
        }
        return false;
    }
    var vali = form.validate();

    if (!vali.valid()) {

        var elements = document.getElementsByClassName("input-validation-error");
        for (var i = 0; i < elements.length; i++) {
            elements[i].style.backgroundColor = "ivory";
            elements[i].style.border = "none";
            elements[i].style.outline = "1px solid red";
            elements[i].style.borderRadius = "5px";
        }

        notify("top center", "فرم را به درستی پر کنید", "error");
        return false;
    }

    $.ajax({
        url: '',
        data: new FormData(document.forms.createForm),
        contentType: false,
        processData: false,
        type: 'POST',
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },

        success: function (result) {
            debugger
            if (result.isSucceeded) {
                notify("top center", "اطلاعات با موفقیت ثبت شد", "success");
                window.location.href = "/Products/Index";
            } else {
                notify("top center", result.message, "error");
            }

        }

    });
});