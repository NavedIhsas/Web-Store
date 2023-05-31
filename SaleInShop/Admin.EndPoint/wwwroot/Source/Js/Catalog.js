

var table = $('#zero-config').DataTable({
    //ajax: "data.json",
    "oLanguage": {
        "oPaginate": { "sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>', "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>' },
        "sInfo": "صفحه _PAGE_ از _PAGES_",
        "sSearch": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>',
        "sSearchPlaceholder": "جستجو کنید...",
        "sLengthMenu": "نتایج :  _MENU_",

    },
    "stripeClasses": [],
    "lengthMenu": [7, 10, 20, 50],
    "pageLength": 7
});





function addModal() {
    $("#add-category").modal("show");
}


function getCode(value, type = false) {
    var code = "";

    if (!type) {
        code = changeGroup();
        if (code == false)
            $("#codeValue").text(value)
        else {
            {
                $("#codeValue").text(code + value)

                var str = (code + value).toString();
                $("#setCode").val(str)
            };

        }
    } else
        $("#codeValue").text(value)

}

function getMaxCode() {

    var groupId = $("#Group").val();
    var codeMax = "";
    $.ajax({
        url: "/products/Category?proLvlId=" + groupId + "&handler=MaxCode",
        type: "GET",
        async: false,
        success: function (result) {
            $("#defualCode").text("");
            $("#defualCode").text("آخرین کد ثبت شده برای این گروه: " + result);
            codeMax = result;
        }
    });
    return codeMax;
}

function checkExistCode(code) {

    var id = $("#id").val();
    var group = $("#Group").val();
    if (group === "0")
        id = group;

    var existCode = "";
    $.ajax({
        url: "/products/Category?id=" + id + "&code=" + code + "&handler=CheckCode",
        type: "GET",
        async: false,
        success: function (result) {
            existCode = result;
        }
    });
    return existCode;
}


function changeGroup() {

    var code = "";
    var groupId = $("#Group").val();
    var codeVal = $("#code").val();
    if (groupId == 0) {
        getCode(code + codeVal, true)
        return false
    };

    $.ajax({
        url: "/products/Category?proLvlId=" + groupId + "&handler=Code",
        type: "GET",
        async: false,
        success: function (result) {
            code = result;
        }
    });
    getMaxCode()
    getCode(code + codeVal, true)
    return code;
}

$("#submitForm").on("submit", function (evn) {
    evn.preventDefault();


    var form = $("#submitForm");
    form.validate();
    if (form.valid() === false) {
        return false;
    }

   var mainGroup= $("#mainGroup").val();
    var subGroup=$("#subGroup").val();

    var group = $("#Group").val();
    var code = $("#code").val();
    var codeS = $("#code").val();

    if (codeS === "" || codeS === undefined) {
        code = getMaxCode();

        if (code == null) code = "1";
        var existCode = checkExistCode(code);

        if (existCode) {

            var rplcCode = "";
            var checkFor = true;
            for (var i = 0, count = 1; checkFor === true; i++) {

                const rplcCode = code.at(-1);
                var parse = parseInt(rplcCode);
                var th = parse + 1;
                var resultCode = code.replace(/.$/, th);
                code = resultCode;
                checkFor = checkExistCode(resultCode);
            }

            debugger
            var m = getMaxCode();
            getCode(code + m);

            $("#setCode").val(code + m)

        }
    };
    $("#code").val("");
    $("#code").val(code);
    code = parseInt($("#code").val());
    debugger
    if (group === "0") {
        if (code.length > @Model.MainCodeCount ) {
    notify("top center", "کد کالا باید @Model.MainCodeCount رقمی باشد", "error");
    return false;
}

if (code.length !== mainGroup ) {
    debugger

    var setCode = code;
    for (var i = 0, count = 1; i < mainGroup -code.length; i++) {
        setCode = "0" + setCode;
        cosole.log(setCode)
    }
    code = setCode;

};

} 
            
 else {
    if (code.toString().length > @Model.SubCodeCount ) {
        notify("top center", "کد کالا باید @Model.SubCodeCount رقمی باشد", "error");
        return false;
    }


    if (code.length !== @Model.SubCodeCount ) {
        var setCode = code;
        for (var i = 0, count = 1; i < @Model.SubCodeCount-code.length; i++) {
            setCode = "0" + setCode;
        }
        code = setCode;
    }
}

$("#code").val("");
$("#code").val(code).toString();
$.ajax({
    url: '',
    data: new FormData(document.forms.submitForm),
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

            notify("top center", "عملیات با موفقیت انجام شد", "success")
            $("#add-category").modal("hide");
            $(".modal-body").html("");
            window.location.href = "/Products/Category";
        } else {
            notify("top center", result.message, "error")
            return false;
        }

    }
})

        })


function Remove(id) {
    debugger
    $.ajax({
        url: '?handler=remove&id=' + id,
        type: 'Get',
        success: function (result) {
            debugger
            if (result.isSucceeded) {
                notify("top center", "عملیات با موفقیت انجام شد", "success")
                window.location.href = "/Products/Category";
            }
            else {
                notify("top center", result.message, "error")
                return false;
            }

        }
    })

};
