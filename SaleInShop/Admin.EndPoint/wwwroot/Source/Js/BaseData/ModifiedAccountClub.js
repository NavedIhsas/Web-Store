

$(document).ready(function () {
    $(".datePicker").persianDatepicker({
       
        initialValueType: 'persian',
        observer: true,
        format: 'YYYY/MM/DD  dddd',
        autoClose: true,
    });
});



$("#editSubmit").on('click', function (evn) {
    evn.preventDefault();
    debugger

    var form = $("#submitForm");
    form.validate();
    if (form.valid() === false) {
        return false;
    }

    $.ajax({
        url: "/BaseData/CreateAccountClub?handler=Edit",
        data: new FormData(document.forms.submitForm),
        contentType: false,
        processData: false,
        type: 'POST',
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },

        success: function (result) {
            
            if (result.isSucceeded) {
                notify("top center", "عملیات با موفقیت انجام شد", "success")
                window.location.href = "/BaseData/CreateAccountClub?handler=AccountClub";
            } else {
                notify("top center", result.message, "error")
                return false;
            }

        }
    })

})


$("#addSubmit").on('click', function (evn) {
    evn.preventDefault();
    debugger

    var form = $("#submitAddForm");
    form.validate();
    if (form.valid() === false) {
        return false;
    }


    $.ajax({
        url: "",
        data: new FormData(document.forms.submitAddForm),
        contentType: false,
        processData: false,
        type: 'POST',
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (result) {
            
            if (result.isSucceeded) {
                notify("top center", "عملیات با موفقیت انجام شد", "success")
                window.location.href = "/BaseData/CreateAccountClub?handler=AccountClub";
            } else {
                notify("top center", result.message, "error")
                return false;
            }

        }
    })

})




$("#state").on('change', function (evn) {
    evn.preventDefault();
    debugger
    var stateId = this.value;
    $.ajax({
        url: "/BaseData/CreateAccountClub?handler=Cities&stateId=" + stateId,
        type: "get",
        success: function (result) {
            $('#cities').empty();

            debugger
            result.forEach(x => {
                $('#cities').append(`<option value="${x.id}">${x.name}</option> `);

            });
        }
    });
});


