const ProductListCookie = "productList";
const AccountClubCookie = "AccountClubList";

$(document).ready(function () {
    $(".datePicker").persianDatepicker({
        initialValueType: 'persian',
        format: 'YYYY/MM/DD',
        autoClose: true,
    });
  
    bindDatatable();
    deleteAllCookies();
    deleteCookie(ProductListCookie);
    deleteCookie(AccountClubCookie);
    //document.getElementById("custom-menu").click();
});


const table = $('#property-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    order: [[2, 'desc']],
    searching: false,
});

const invoiceTable = $('.invoiceDet-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    order: [[2, 'desc']],
    searching: false,
});

$("#submitPrint").on('click', function () {

    swal({
        title: 'این فاکتور تسویه نشده است!',
        text: "آیا مطمئن هستید که میخواهید ادامه دهید؟",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'ادامه',
        cancelButtonText: 'لغو',
        padding: '2em',
    }).then(function (result) {

        if (result.value) {

            $.ajax({
                url: '/Invoice/Pre-Invoice',
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
                        $("#invoiceStatus").removeClass("d-none").text("وضعیت فاکتور: ثبت اولیه");
                        $("#invoicePayStatus").removeClass("d-none").text("وضعیت تسویه: تسویه نشده");
                        document.querySelectorAll(".invoicePay").removeClass("d-none").forEach(el => el.removeClass("d-none"));


                        swal(
                            'موفق!',
                            result.message,
                            'success'
                        );
                    }
                    else {
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
})


function getProductModal(evt, cityName) {
    var account = getCookie(AccountClubCookie);
    if (account == "") {
        notify("top center", "لطفا ابتدا مشتری را انتخاب کنید", "error");
        return false;
    }
    else {
        getProduct(evt, cityName);
        $("#CustomMenu").modal('show');
    }
}


function getProduct(evt, cityName) {

    var account = getCookie(AccountClubCookie);
    if (account == "") {
        notify("top center", "لطفا ابتدا مشتری را انتخاب کنید", "error");
        return false;
    }

    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";


    try {

        reinitialise("dataTable_1");
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
                        "data": "PrdName",
                        "autoWidth": true,
                        "searchable": true,

                    },
                    {
                        "data": "PrdLvlName",
                        "autoWidth": true,
                        "searchable": true
                    },

                    {
                        "data": "Price",
                        "autoWidth": true,
                        "searchable": true,
                        render: function (data, row, full) {

                            if (data == null)
                                return "تعریف نشده";
                            return data;
                        },
                    },


                    {
                        data: null,
                        render: function (data, row, full) {
                            if (full.Price == null)
                                return "ابتدا قیمت را در این سطح تعریف کنید";
                            return generateButton(data);
                        },
                    }

                ]
            });


    } catch (e) {

    }

    function generateButton(data) {

        return ` <a onClick="addProductToList('${data.PrdUid}','${data.PrdName}','${data.Price}','${data.DiscountPercent}','${data.TaxValue}')" type="button" >
        <svg style="color:green" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-plus"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
    </a>
    `
    };

}

function openDetails(evt, name, accclubType) {

    var i, tabcontent, tablinks;
    $("#productName").append("");
    $.ajax({

        url: "?handler=ProductLevel&productLvl=" + name + "&accClbType=" + accclubType,
        type: "get",
        success: function (result) {

            result.forEach(x => {
                const list = `

                         <div id="${x.prdUid}" class="product-group product1">
                             <div class="row">
                                 <div class="card-deck product-content">
                                     <div class="card ">
                                        <span >
                                            <div class="btn-group" role="group" aria-label="Basic example">
                                                <button type="button" class="btn btn-info">${x.prdName}</button>
                                                  <button onClick="addProductToList('${x.prdUid}','${x.prdName}','${x.prdPricePerUnit1}','${x.accClubDiscount}')" type="button" class="btn btn-success" style="background: burlywood;">
                                                   <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-plus"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
                                                </button>
                                             </div>
                                         </span>
                                     </div>
                                 </div>
                             </div>
                         </div>
                         `

                $("#productName").append(list);
                document.getElementById(x.prdUid).style.display = "block";
            });
        }
    });

    tabcontent = document.getElementsByClassName("product-group");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("group");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    evt.currentTarget.className += " active";

}


function calculateTax(tax, totalAmount) {
    debugger
    return (totalAmount * tax) / 100;
}


function updateTable(obj) {
    debugger
    var amount = 0, total = 0, priceWithDiscount = 0, paidAmount = 0, getTax = 0;
    var totalPriceWithDiscount = 0, totalPaidAmount = 0, totalGetTax = 0, rowNo = 0, accClbUid;

    table.clear().draw();
    var footer = document.getElementsByTagName("tfoot");
    if (footer.length !== 0)
        footer[0].parentNode.removeChild(footer[0]);

    obj.forEach(x => {

        amount += parseInt(x.price);
        total += parseInt(x.total);
        priceWithDiscount = Math.abs(parseInt(((parseInt(x.discount) * total) / 100) - total));
        discountAmount = parseInt((parseInt(x.discount) * total) / 100);
        getTax = calculateTax(x.tax, total);
        paidAmount = Math.abs(parseInt(priceWithDiscount - getTax));

        totalPriceWithDiscount += priceWithDiscount;
        totalPaidAmount += paidAmount;
        totalGetTax += getTax;
        const result =
            `
    <tr>
        <td>${rowNo += 1}</td>
        <td>${x.name ?? ""}</td>
        <td>${x.value ?? ""}</td>
        <td>${parseInt(x.price).toLocaleString()}</td>
        <td>${parseInt(x.total).toLocaleString()}</td>
        <td>${x.discount}</td>
        <td>${priceWithDiscount.toLocaleString()}</td>
        <td>${getTax.toLocaleString()}</td>
        <td>${paidAmount.toLocaleString()}</td>

        <td></td>
        <td> <a type="button" class="" onclick="(ProuctListDes('${x.productId}'))">...</a></td>
        <td>

            <a class="" onClick="removeProductList('${x.productId}')" title="حذف">
                <svg style="color:#e7515a" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-trash-2">
                    <polyline points="3 6 5 6 21 6"></polyline>
                    <path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path>
                    <line x1="10" y1="11" x2="10" y2="17"></line>
                    <line x1="14" y1="11" x2="14" y2="17"></line>
                </svg>
            </a>
        </td>
    </tr>
    `
        table.row.add($(result)).draw();

        var footer = document.getElementsByTagName("tfoot");
        if (footer.length !== 0)
            footer[0].parentNode.removeChild(footer[0]);

        $(".property-dataTable").append($('<tfoot />').append($("<tr> <td>مجموع:</td> <td></td><td></td> <td>" + parseInt(amount).toLocaleString() + "</td> <td>" + parseInt(total).toLocaleString() + "</td><td></td> <td>" + Math.abs(totalPriceWithDiscount).toLocaleString() + "</td> <td>" + Math.abs(totalGetTax).toLocaleString() + "</td> <td>" + Math.abs(totalPaidAmount).toLocaleString() + "</td> <tr>").clone()));

        var invoice =
        {
            // accUid: accClbUid,
            amount: amount,
            total: total,
            priceWithDiscount: priceWithDiscount,
            paidAmount: paidAmount,
            tax: getTax,
            totalPriceWithDiscount: Math.abs(totalPriceWithDiscount),
            totalPaidAmount: Math.abs(totalPaidAmount),
            totalGetTax: Math.abs(totalGetTax),
            totalDiscountAmount: discountAmount,
        };

        setCookie("invoice", invoice);

    });
}

function addProductToList(id, name, price, discount, tax) {
    debugger
    var discountAmount = parseInt((discount * price) / 100);
    var getTax = parseInt(calculateTax(tax, price));
    var priceWithDiscount = Math.abs(parseInt(((discount) * price) / 100) - price);
    var paidAmount = Math.abs(parseInt(priceWithDiscount - getTax));
    var account = getCookie(AccountClubCookie);
    if (account == "") {
        notify("top center", "لطفا ابتدا مشتری را انتخاب کنید", "error");
        return false;
    }

    var obj =
        [
            {
                productId: id,
                taxPercent: tax,
                name: name,
                price: price,
                discount: discount,
                total: price,
                value: 1,
                discountAmount: discountAmount,
                paidAmount: paidAmount,
                tax: tax,
                des: "",
            }
        ];

    var cookie = getCookie(ProductListCookie);
    if (cookie === "")
        setCookie(ProductListCookie, obj);

    else {
        var parse = JSON.parse(cookie);
        const found = parse.find(element => element.productId === id);
        if (found !== undefined) {

            found.value = found.value + 1;
            found.total = found.value * price;

            var priceWithDiscount = Math.abs(parseInt(((found.discount) * found.total) / 100) - found.total);
            found.discountAmount = parseInt(((found.discount) * found.total) / 100);
            found.tax = parseInt(calculateTax(found.tax, found.total));
            found.paidAmount = Math.abs(parseInt(priceWithDiscount - found.tax));

            obj = parse.filter(element => element.productId !== id);
            obj.push(found);
            setCookie(ProductListCookie, obj);
        }
        else {

            obj.push.apply(obj, parse);
            setCookie(ProductListCookie, obj);
        }
    }
    updateTable(obj);
    $("#productList").removeClass("d-none")
}


function removeProductList(id) {

    var parse = JSON.parse(getCookie(ProductListCookie));
    const found = parse.find(element => element.productId === id);
    if (found !== undefined) {
        parse = parse.filter(element => element.productId !== id);
        setCookie(ProductListCookie, parse);
        updateTable(parse);
    }
}

function addDesToPrdList() {
    var id = $("#prodcutDes").val();
    var value = $("#descript").val();
    var cookie = getCookie(ProductListCookie);
    var parse = JSON.parse(cookie);
    const found = parse.find(element => element.productId === id);
    var obj = parse.filter(element => element.productId !== id);
    found.des = value;
    obj.push(found);
    setCookie(ProductListCookie, obj);
}

function ProuctListDes(id) {
    $("#productListDes").modal('show');
    $("#prodcutDes").val("");
    $("#prodcutDes").val(id);
}


$("#addAccountClub").on('click', function (evn) {
    $("#AccClbList").modal('show');
})


function bindDatatable() {
    datatable = $('#dataTable_2')
        .DataTable({
            "sAjaxSource": "/BaseData/CreateAccountClub?handler=Data",
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
                    "data": "AccClbName",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "AccClbCode",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "ShamsiBirthDay",
                    "autoWidth": true,
                    "searchable": true
                },

                {
                    "data": "AccClubType",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "AccClubDiscount",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "AccRatioText",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "AccClbMobile",
                    "autoWidth": true,
                    "searchable": true
                },
                {
                    "data": "AccClbSexText",
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
        return `<center><a onClick="addAccountClub('${data.AccClbUid}','${data.AccClbName}','${data.AccClubDiscount}','${data.AccClubType}','${data.AccClbMobile}','${data.AccClbAddress}','${data.AccClbCode}','${data.AccTypePriceLevel}')" class="btn btn-warning btn-rounded btn-sm">انتخاب مشتری</a>&nbsp; `
    };

}


function addAccountClub(id, name, discount, type, mobile, address, code, accTypePriceLevel) {
    deleteCookie(AccountClubCookie);

    var accound = {
        accClbUid: id,
        accClbName: name,
        accClubDiscount: discount,
        type: type,
        mobile: mobile,
        address: address,
        code: code,
        accTypePriceLevel: accTypePriceLevel
    };

    setCookie(AccountClubCookie, accound);
   // notify('top center', 'مشترک مورد نظر انتخاب شد', 'success');
    getAccountClub();
    $("#AccClbList").modal('hide');
  
}

function getAccountClub() {
    var account = getParseCookie(AccountClubCookie);
    $("#accClubDetails").removeClass("d-none");
    $("#accClubName").text('مشتری: ' + account.accClbName + '- ' + account.code)
    $("#accClubType").text('نوع اشتراک: ' + account.type)
    $("#accClubMobile").text('موبایل: ' + account.mobile)
    $("#accClubAddress").text('آدرس: ' + account.address)
}


// invlice list from dataBase



function InvoiceList() {
    bindInvoiceDatatable();
    $("#invoiceList").modal('show');

}




function bindInvoiceDatatable() {

    reinitialise("invoice-dataTable");
    dataTable = $('#invoice-dataTable')
        .DataTable({
            "sAjaxSource": "/Invoice/Pre-Invoice?handler=InvoiceList",
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
                    "data": "CreationDate",
                    "autoWidth": true,
                    "searchable": true
                }, {
                    "data": "Number",
                    "autoWidth": true,
                    "searchable": true
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
                    render: function (data, row, full) {
                        return generateRemoveButton(data);
                    },
                }

            ]
        });

    function generateRemoveButton(data) {
        return `<center><a class="btn btn-danger btn-rounded btn-sm">حذف</a>&nbsp;<a  onclick="invoiceDetails('${data.Id}')" class="btn btn-success btn-rounded btn-sm">انتخاب</a>&nbsp; `
    };

}


function invoiceDetails(invoiceId) {
  
    $.ajax({
        url: "?handler=invoiceDetails&InvoiceId=" + invoiceId,
        type: "Get",
        success: function (result) {
            if (result.isSucceeded) {
                setCookie(ProductListCookie, result.data);
                updateInvoiceTable(result.data);
                debugger
                var account = result.data[0];
                addAccountClub(account.accountId, account.accountName, account.accountDiscount, account.accountType, account.mobile, account.address, account.accountCode, account.priceLevel);
              
                $("#invoiceList").modal('hide');
            } else {
                notify("top center", result.message, "error");
                return false;
            }

        }
    })
}


function updateInvoiceTable(obj) {
    var amount = 0, total = 0, priceWithDiscount = 0, paidAmount = 0, getTax = 0;
    var totalPriceWithDiscount = 0, totalPaidAmount = 0, totalGetTax = 0, rowNo = 0;

    table.clear().draw();
    var footer = document.getElementsByTagName("tfoot");
    if (footer.length !== 0)
        footer[0].parentNode.removeChild(footer[0]);

    obj.forEach(x => {

        amount += parseInt(x.price);
        total += parseInt(x.total);
        priceWithDiscount = Math.abs(parseInt(((parseInt(x.discount) * total) / 100) - total));
        discountAmount = parseInt((parseInt(x.discount) * total) / 100);
        getTax = calculateTax(x.tax, total);
        paidAmount = Math.abs(parseInt(priceWithDiscount - getTax));

        totalPriceWithDiscount += priceWithDiscount;
        totalPaidAmount += paidAmount;
        totalGetTax += getTax;
        const result =
            `
    <tr>
        <td>${rowNo += 1}</td>
        <td>${x.name ?? ""}</td>
        <td>${x.value ?? ""}</td>
        <td>${parseInt(x.price).toLocaleString()}</td>
        <td>${parseInt(x.total).toLocaleString()}</td>
        <td>${x.discount}</td>
        <td>${priceWithDiscount.toLocaleString()}</td>
        <td>${getTax.toLocaleString()}</td>
        <td>${paidAmount.toLocaleString()}</td>

        <td></td>
        <td> <a type="button" class="" onclick="(ProuctListDes('${x.id}'))">...</a></td>
        <td>

            <a class="" onClick="removeProductList('${x.id}')" title="حذف">
                <svg style="color:#e7515a" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-trash-2">
                    <polyline points="3 6 5 6 21 6"></polyline>
                    <path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path>
                    <line x1="10" y1="11" x2="10" y2="17"></line>
                    <line x1="14" y1="11" x2="14" y2="17"></line>
                </svg>
            </a>
        </td>
    </tr>
    `
        table.row.add($(result)).draw();

        var footer = document.getElementsByTagName("tfoot");
        if (footer.length !== 0)
            footer[0].parentNode.removeChild(footer[0]);

        $("#property-dataTable").append($('<tfoot />').append($("<tr> <td>مجموع:</td> <td></td><td></td> <td>" + parseInt(amount).toLocaleString() + "</td> <td>" + parseInt(total).toLocaleString() + "</td><td></td> <td>" + Math.abs(totalPriceWithDiscount).toLocaleString() + "</td> <td>" + Math.abs(totalGetTax).toLocaleString() + "</td> <td>" + Math.abs(totalPaidAmount).toLocaleString() + "</td> <tr>").clone()));

        var invoice =
        {
            amount: amount,
            total: total,
            priceWithDiscount: priceWithDiscount,
            paidAmount: paidAmount,
            tax: getTax,
            totalPriceWithDiscount: Math.abs(totalPriceWithDiscount),
            totalPaidAmount: Math.abs(totalPaidAmount),
            totalGetTax: Math.abs(totalGetTax),
        };

        setCookie("invoice", invoice);

    });
}
