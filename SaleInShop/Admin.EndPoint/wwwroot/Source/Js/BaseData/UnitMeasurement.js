

$(document).ready(function () {
    bindDatatable();
});



$("#editSubmit").on('click', function (evn) {
    evn.preventDefault();
    debugger

    var form = $("#submitEditForm");
    form.validate();
    if (form.valid() === false) {
        return false;
    }

    $.ajax({
        url: "?handler=Edit",
        data: new FormData(document.forms.submitEditForm),
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
                window.location.href = "/BaseData/UnitMeasurement";
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
            debugger
            if (result.isSucceeded) {
                notify("top center", "عملیات با موفقیت انجام شد", "success")
                window.location.href = "/BaseData/UnitMeasurement";
            } else {
                notify("top center", result.message, "error")
                return false;
            }

        }
    })

})
function Edit(id, name, code) {
    debugger
    $("#edit").modal("show");
    $("#Command_Name").val(name);
    $("#Command_Code").val(code);
    $("#Command_Id").val(id);
}

function Add() {
    debugger
    $("#add").modal("show");

}






function Remove(id) {
    debugger

    swal({
        title: 'آیا مطمئنید؟',
        text: "این عمل قابل بازگشت نیست!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'حذف',
        padding: '2em'
    }).then(function (result) {

        if (result.value) {

            $.ajax({
                url: "?handler=Remove&id=" + id,
                type: "get",
                success: function (result) {
                    debugger
                    if (result.isSucceeded) {
                        swal(
                            'موفق!',
                            result.message,
                            'success'
                        ).then(function () {
                            window.location = "/BaseData/UnitMeasurement";
                        });
                    } else {
                        swal(
                            'خطا!',
                            result.message,
                            'error'
                        )
                    }
                }

            })

        }
    })
};

function bindDatatable() {

    datatable = $('#dataTable_1')
        .DataTable({
           
            "sAjaxSource": "?handler=Data",
            "bServerSide": true,
            "bProcessing": true,
            "bSearchable": true,
            "order": [[1, 'asc']],
            "language": {
                "oPaginate": { "sPrevious": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-right"><line x1="5" y1="12" x2="19" y2="12"></line><polyline points="12 5 19 12 12 19"></polyline></svg>', "sNext": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-arrow-left"><line x1="19" y1="12" x2="5" y2="12"></line><polyline points="12 19 5 12 12 5"></polyline></svg>' },
                "sInfo": "صفحه _PAGE_ از _PAGES_",
                "sSearch": '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search"><circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg>',
                "sSearchPlaceholder": "جستجو کنید...",
                "sLengthMenu": "نتایج :  _MENU_",
            },
            "columns": [
                {
                    "data": "Name",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "Code",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    data: null,
                    render: function (data, row, full) {
                        return generateButton(data);
                    },
                }

            ]
        });

    function generateButton(data) {
        debugger
        return `<center><button onclick="Edit('${data.Id}','${data.Name}','${data.Code}')" class="btn btn-warning btn-rounded btn-sm">ویرایش</button>&nbsp; <button onclick="Remove('${data.Id}')" class="btn btn-danger btn-rounded btn-sm"> حذف </button></center>`
    };




}

