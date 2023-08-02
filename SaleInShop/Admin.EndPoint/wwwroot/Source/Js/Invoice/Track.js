
$("#Search").on("click", function (evnt) {
    debugger
    reinitialise("track-dataTable");
    datatable = $('#track-dataTable')
        .DataTable({
            "sAjaxSource": "?handler=Data&fromdate=" + $("#fromDate").val().substr(0, 10) + "&toDate=" + $("#toDate").val().substr(0, 10) + "&fromHours=" + $("#fromHours").val().substr(0, 5) + "&toHours=" + $("#toHours").val().substr(0, 5),
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
                    "data": "Number",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "CreationDate",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "CreationTime",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "PaidStatus",
                    "autoWidth": true,
                    "orderable": false,
                    "searchable": false,
                    render: function (data) {
                        return genderClass(data);
                    },
                },
                {
                    "data": "Remain",
                    "autoWidth": true,
                    "orderable": false,
                    "searchable": false
                },


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
                    "data": "TotalAmount",
                    "autoWidth": true,
                    "searchable": true
                },

                {
                    data: null,
                    "orderable": false,
                    "autoWidth": true,
                    "searchable": false,
                    render: function (data, row, full) {
                        return generateActionButton(data, full);
                    },
                }

            ]
        });
    function generateActionButton(data, full) {
        debugger
        if (full.PaidStatus)
            return `<center><a class="btn btn-info btn-rounded btn-sm">جزئیات</a>&nbsp;<a onClick="PaidWay(${full.TotalAmount},${full.Name})"  id="paid" class="btn btn-success btn-rounded btn-sm" disabled>پرداخت</a>&nbsp; `
        else
            return `<center><a class="btn btn-info btn-rounded btn-sm">جزئیات</a>&nbsp;<a onClick="PaidWay(${full.TotalAmount},${full.Name})"  id="paid" class="btn btn-success btn-rounded btn-sm">پرداخت</a>&nbsp; `

    };

    function genderClass(data) {
        if (data)
            return `<p class="text-success">تسویه شده</p>`
        else
            return `<p class="text-danger">تسویه نشده</p>`
    };

})


var invoiceNumber = 0;

function PaidWay(paidAmount, accClbName) {
    debugger
    $.ajax({
        url: "/Invoice/Invoice?handler=GeneratePaymentNumber",
        type: "get",
        success: function (result) {

            invoiceNumber = result.generateNumber;

            $("#invoiceNumberPay").text(invoiceNumber);
            $("#AccountClubNamePay").text(accClbName);
            $("#amountPay").val(paidAmount)
            applyOtherPayTotal(0, paidAmount);
            result.bankList.forEach(x => {

                var list = `
                    <option value="${x.type}">${x.name}</option>
                `
                $("#bank").append(list);
            })
        }
    })
    $("#otherPaymentModal").modal('show');
}
