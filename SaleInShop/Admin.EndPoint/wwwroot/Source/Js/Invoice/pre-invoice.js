const ProductListCookie = "productList";
const AccountClubCookie = "AccountClubList";
const CashPaymentCookie = "CashPayment";
const InvoiceCookie = "Invoice";
const OtherPayCookie = "OtherPay";
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
    deleteCookie(OtherPayCookie);
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

const payTable = $('#dataTable-pay').DataTable({
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
            $("#type").val("790C91B5-FACE-4CD4-AD8A-2A49ECA3A68B");

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
                beforeSend: function () {
                    showLoader()
                },

                success: function (result) {

                    if (result.isSucceeded) {
                        checkStatus(result.data)
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
                ,
                error: function (error) {

                    alert(error);
                }
                ,
                complete: function () {
                    hideLoader()
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
                        "autoWidth": true,
                        "searchable": false,
                        "orderable": false,
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

        return ` <a onClick="addProductToList('${data.PrdUid}',' ','${data.PrdName}','${data.Price}','${data.DiscountPercent}','${data.TaxValue}','${data.InvoiceDiscount}','${data.InvoiceDiscountPercent}','${data.DiscountSaveToDb}')" type="button" >
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
        beforeSend: function () {
            showLoader()
        },

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
        ,
        complete: function () {
            hideLoader()
        },
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

    return (totalAmount * tax) / 100;
}



function ConvertPercentToAmount(price, percent) {
    price = parseFloat(price);
    percent = parseFloat(percent);

    var result = (percent * price) / 100;
    return result;
}

function applyTotal(totalProductCount, totalFooter, totalDiscountAmount, totalInvoiceDiscount, totalGetTax, totalPaidAmount, remain) {

    $("#total").html(" ");
    if (remain == undefined)
        remain = totalPaidAmount;
    $("#total").append(`
          <div class="col-md-12 col-sm-12 col-xs-12 table-responsive">
            <table class="table table-bordered">
             <tbody>
                     <tr class="">
                         <td class="font-weight-bold text-dark">تجمیع: </td>
                   
                        
                         <td class="bg-aliceblue text-dark">قیمت کل</td>
                         <td> <strong class="text-dark">${totalFooter.toLocaleString()}</strong></td>
                   
                         <td class="bg-aliceblue text-dark">تخفیف ردیف</td>
                         <td> <strong class=" text-danger">${totalDiscountAmount.toLocaleString()}</strong></td>
                   
                         <td class="bg-aliceblue text-dark">تخفیف فاکتور</td>
                         <td> <strong class="text-danger ">${totalInvoiceDiscount.toLocaleString()}</strong></td>
                   
                         <td class="bg-aliceblue text-dark">مالیات</td>
                         <td> <strong class="text-info">${totalGetTax.toLocaleString()}</strong></td>
                   
                         <td class="bg-aliceblue text-dark">قابل پرداخت</td>
                         <td> <strong class="text-success">${totalPaidAmount.toLocaleString()}</strong></td>

                           <td class="bg-aliceblue text-dark">مانده پرداختی</td>
                         <td> <strong class="text-success">${remain.toLocaleString()}</strong></td>
                     </tr>
                  </tbody>
              </table>
            </div>
        `).removeClass("d-none");
}

function addProductToList(id, invoiceDetailsId, name, price, discount, tax, invoiceDiscount, invoiceDiscountPercent, discountSaveToDb, value = 1, changeUser = false) {

    var discountAmount = parseFloat((discount * price) / 100);
    var getTax = parseFloat(calculateTax(tax, price));
    var priceWithDiscount = Math.abs(parseFloat(((discount) * price) / 100) - price);
    var paidAmount = Math.abs(parseFloat(priceWithDiscount + getTax));
    var account = getCookie(AccountClubCookie);
    if (account == "") {
        notify("top center", "لطفا ابتدا مشتری را انتخاب کنید", "error");
        return false;
    }

    var obj = [];
    var product =

    {
        productId: id,
        taxPercent: tax,
        name: name,
        price: price,
        discount: discount,
        total: price,
        invoiceDiscount: invoiceDiscount,
        value: value,
        discountAmount: discountAmount,
        paidAmount: paidAmount,
        tax: tax,
        invoiceDiscountPercent: invoiceDiscountPercent,
        discountSaveToDb: discountSaveToDb,
        invoiceDetailsId: invoiceDetailsId,
        des: "",
    };



    var cookie = getCookie(ProductListCookie);
    if (cookie === "") {
        obj.push(product);
        setCookie(ProductListCookie, obj);
    }

    else {
        var parse = JSON.parse(cookie);
        const found = parse.find(element => element.productId === id);
        if (found !== undefined && changeUser == false) {

            found.value = found.value + 1;
            found.total = found.value * price;

            var priceWithDiscount = Math.abs(parseFloat(((found.discount) * found.total) / 100) - found.total);
            found.discountAmount = parseFloat(((found.discount) * found.total) / 100);

            found.tax = parseFloat(calculateTax(found.taxPercent, found.total));
            found.paidAmount = Math.abs(parseFloat(priceWithDiscount + found.tax));

            obj = parse.filter(element => element.productId !== id);
            obj.push(found);
            setCookie(ProductListCookie, obj);
        }
        else {

            if (!changeUser)
                parse.push(product);

            obj.push.apply(obj, parse);

            //obj.push(parse);
            setCookie(ProductListCookie, obj);
        }
    }
    updateTable(obj);
    $("#productList").removeClass("d-none")
}


function removeProductList(id, invoiceDetailsId) {

    swal({
        title: "این محصول از لیست حذف خواهد شد",
        text: "آیا مطمئن هستید که میخواهید ادامه دهید؟",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'ادامه',
        cancelButtonText: 'لغو',
        padding: '2em',
    }).then(function (result) {

        if (result.value) {

            $.ajax({
                url: "?handler=RemoveFromProductList&id=" + invoiceDetailsId,
                type: "get",
                success: function (result) {
                    if (result.isSucceeded)
                        notify("top center", result.message, "success")
                }
            })

            var parse = JSON.parse(getCookie(ProductListCookie));
            const found = parse.find(element => element.productId === id);
            if (found !== undefined) {
                parse = parse.filter(element => element.productId !== id);
                setCookie(ProductListCookie, parse);
                updateTable(parse);
            }

        }
    })
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
                    "data": "AccTypePriceLevelText",
                    "autoWidth": true,
                    "searchable": true,
                    render: function (data, row, full) {

                        if (data == "")
                            return "تعریف نشده";
                        else return data;
                    },
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
                    "autoWidth": true,
                    "searchable": false,
                    "orderable": false,
                    render: function (data, row, full) {
                        return generateButton(data);
                    },
                }

            ]
        });

    function generateButton(data) {

        return `<center><a onClick="addAccountClub('${data.AccClbUid}','${data.AccClbTypUid}','${data.AccClbName ?? ""}','${data.AccClubDiscount}','${data.AccClubType ?? ""}','${data.AccClbMobile ?? ""}','${data.AccClbAddress ?? ""}','${data.AccClbCode ?? ""}','${data.AccTypePriceLevel}','${data.InvoiceDiscount}')" class="btn btn-warning btn-rounded btn-sm">انتخاب </a>&nbsp; `
    };
}
function addAccountClub(id, accTypeId, name, discount, type, mobile, address, code, accTypePriceLevel, invoiceDiscount, invoiceDetailsId) {

    deleteCookie(AccountClubCookie);

    var accound = {
        accClbUid: id,
        accClbTypUid: accTypeId,
        accClbName: name,
        accClubDiscount: discount,
        type: type,
        mobile: mobile,
        address: address,
        code: code,
        invoiceDiscount: invoiceDiscount,
        accTypePriceLevel: accTypePriceLevel,
        invoiceDetailsId: invoiceDetailsId,
    };

    var cookie = getCookie(ProductListCookie);
    if (cookie !== "") {

        $.ajax({
            url: "?handler=changeAccountClub&priceLevel=" + parseFloat(accTypePriceLevel),
            type: "get",
            beforeSend: function () {
                showLoader()
            },
            success: function (result) {

                if (result.isSucceeded) {
                    setCookie(ProductListCookie, result.data);
                    result.data.forEach(x => {

                        addProductToList(x.productId, invoiceDetailsId, x.name, x.price, x.discount, x.tax, x.invoiceDiscount, x.invoiceDiscountPercent, x.discountSaveToDb, x.value, true,);
                    })

                }
            }
            ,
            complete: function () {
                hideLoader()
            },
        });
    }

    setCookie(AccountClubCookie, accound);
    // notify('top center', 'مشترک مورد نظر انتخاب شد', 'success');
    getAccountClub();
    $("#AccClbList").modal('hide');

}

function getAccountClub() {


    var account = getParseCookie(AccountClubCookie);
    $("#accClubDetails").removeClass("d-none");
    $("#accClubName").text('مشتری: ' + account.accClbName ?? "" + '- ' + account.code ?? "")
    $("#accClubType").text('نوع اشتراک: ' + account.type ?? "")
    $("#accClubMobile").text('موبایل: ' + account.mobile)
    $("#accClubAddress").text('آدرس: ' + account.address ?? "")
}


// invlice list from dataBase



function InvoiceList() {
    bindInvoiceDatatable("790C91B5-FACE-4CD4-AD8A-2A49ECA3A68B", "invoice-dataTable");
    $("#invoiceList").modal('show');
}

function invoiceTempList() {
    bindInvoiceDatatable("09004CE6-3DAC-4EEB-AFE9-E1E7DDD8AD28", "invoiceTemp-dataTable");
    $("#invoiceTempList").modal('show');


}

function bindInvoiceDatatable(type, dataTableId) {

    reinitialise(dataTableId);
    dataTable = $('#' + dataTableId)
        .DataTable({
            "sAjaxSource": "/Invoice/Pre-Invoice?handler=InvoiceList&type=" + type,
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
                    "orderable": false,
                    "autoWidth": true,
                    "searchable": false,
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
        beforeSend: function () {
            showLoader()
        },
        success: function (result) {
            if (result.isSucceeded) {
                setCookie(ProductListCookie, result.data);

                updateInvoiceTable(result.data);

                var account = result.data[0];
                addAccountClub(account.accountId, account.accountTypeId, account.accountName ?? "", account.accountDiscount, account.accountType ?? "", account.mobile ?? "", account.address ?? "", account.accountCode ?? "", account.priceLevel, account.invoiceDiscount, account.invoiceDetailsId);

                $("#invoiceList").modal('hide');
            } else {
                notify("top center", result.message, "error");
                return false;
            }

        },
        complete: function () {
            hideLoader()
        },

    })
}
//// Activate an inline edit on click of a table cell
//table.on('click', 'tbody td:not(:first-child)', function (e) {
//    
//    editor.inline(this);
//});
function updateTable(obj) {

    var amount = 0, total = 0, priceWithDiscount = 0, paidAmount = 0, getTax = 0; amountFooter = 0; totalFooter = 0, totalDiscountAmount = 0;
    var totalPriceWithDiscount = 0, totalPaidAmount = 0, totalPaidAmountFooter = 0, totalGetTax = 0, rowNo = 0, accClbUid, totalCount = 0; totalInvoiceDiscount = 0;
    table.clear().draw();

    var footer = document.getElementsByTagName("tfoot");
    if (footer.length !== 0)
        footer[0].parentNode.removeChild(footer[0]);

    obj.forEach(x => {
        amount = parseFloat(x.price);
        total = parseFloat(x.total);
        totalInvoiceDiscount = x.invoiceDiscount;
        amountFooter += parseFloat(x.price);
        totalFooter += parseFloat(x.total);
        totalCount += parseFloat(x.value);

        priceWithDiscount = Math.abs(parseFloat(((parseFloat(x.discount) * total) / 100) - total));

        discountAmount = parseFloat((parseFloat(x.discount) * total) / 100);
        getTax = calculateTax(x.taxPercent, total);
        paidAmount = Math.abs(parseFloat(priceWithDiscount + getTax));
        totalDiscountAmount += discountAmount;
        totalPriceWithDiscount += priceWithDiscount;
        totalPaidAmount += paidAmount;
        totalPaidAmountFooter += paidAmount;
        totalGetTax += getTax;
        const result =
            `
    <tr>
        <td>${rowNo += 1}</td>
        <td>${x.name ?? ""}</td>
        <td>${x.value ?? ""}</td>
        <td>${parseFloat(x.price).toLocaleString()}</td>
        <td>${parseFloat(x.total).toLocaleString()}</td>
   
        <td>${x.discountSaveToDb}</td>
        <td>${priceWithDiscount.toLocaleString()}</td>
        <td>${getTax.toLocaleString()}</td>
        <td>${paidAmount.toLocaleString()}</td>

        <td>${x.invoiceDiscountPercent}</td>
        <td>${x.discount}</td>
        <td> <a type="button" class="" onclick="(ProuctListDes('${x.productId}'))">...</a></td>
        <td>

            <a class="" onClick="removeProductList('${x.productId}','${x.invoiceDetailsId}')" title="حذف">
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

        $(".property-dataTable").append($('<tfoot />').append($("<tr> <td>مجموع:</td> <td></td><td>" + totalCount + "</td> <td>" + parseFloat(amountFooter).toLocaleString() + "</td> <td>" + parseFloat(totalFooter).toLocaleString() + "</td><td></td> <td>" + Math.abs(totalPriceWithDiscount).toLocaleString() + "</td> <td>" + Math.abs(totalGetTax).toLocaleString() + "</td> <td>" + Math.abs(totalPaidAmountFooter).toLocaleString() + "</td> <tr>").clone()));

        totalInvoiceDiscount = ConvertPercentToAmount(totalPaidAmount, totalInvoiceDiscount);

        totalPaidAmount -= totalInvoiceDiscount;
        totalPaidAmount = Math.abs(totalPaidAmount);

        var InvoiceDiscountPercent = totalInvoiceDiscount;
        applyTotal(totalCount, totalFooter, totalDiscountAmount, totalInvoiceDiscount, totalGetTax, totalPaidAmount)


        var invoice =
        {
            // accUid: accClbUid,
            amount: amount,
            total: total,
            discountSaveToDb: x.discountSaveToDb,
            priceWithDiscount: priceWithDiscount,
            paidAmount: paidAmount,
            tax: getTax,
            totalPriceWithDiscount: Math.abs(totalPriceWithDiscount),
            totalPaidAmount: Math.abs(totalPaidAmount),
            totalGetTax: Math.abs(totalGetTax),
            totalDiscountAmount: totalDiscountAmount,
            InvoiceDiscountPercent: InvoiceDiscountPercent,
            totalInvoiceDiscount: totalInvoiceDiscount,
            totalCount: totalCount,
            totalFooter: totalFooter,

        };

        setCookie(InvoiceCookie, invoice);

    });
    var rows = table.rows().any();

    if (!rows)
        $("#total").html(" ");
}
function updateInvoiceTable(obj) {

    var amount = 0, total = 0, priceWithDiscount = 0, paidAmount = 0, getTax = 0; amountFooter = 0; totalFooter = 0, totalDiscountAmount = 0;
    var totalPriceWithDiscount = 0, totalPaidAmount = 0, totalGetTax = 0, rowNo = 0, accClbUid, totalCount = 0; totalInvoiceDiscount = 0;

    table.clear().draw();

    var footer = document.getElementsByTagName("tfoot");
    if (footer.length !== 0)
        footer[0].parentNode.removeChild(footer[0]);

    obj.forEach(x => {

        amount = parseFloat(x.price);
        total = parseFloat(x.total);

        totalInvoiceDiscount = x.totalInvoiceDiscount;
        amountFooter += parseFloat(x.price);
        totalFooter += parseFloat(x.total);
        totalCount += parseFloat(x.value);

        priceWithDiscount = Math.abs(parseFloat(((parseFloat(x.discount) * total) / 100) - total));
        discountAmount = parseFloat((parseFloat(x.discount) * total) / 100);
        getTax = calculateTax(x.tax, total);
        paidAmount = parseFloat(x.paidAmount),

            totalDiscountAmount += discountAmount;
        totalPriceWithDiscount += priceWithDiscount;
        totalPaidAmount = x.totalPaidAmount;
        totalGetTax == getTax;

        const result =
            `
    <tr>
        <td>${rowNo += 1}</td>
        <td>${x.name ?? ""}</td>
        <td>${x.value ?? ""}</td>
        <td>${parseFloat(x.price).toLocaleString()}</td>
        <td>${parseFloat(x.total).toLocaleString()}</td>
        <td>${x.discountSaveToDb}</td>
        <td>${priceWithDiscount.toLocaleString()}</td>
        <td>${getTax.toLocaleString()}</td>
        <td>${paidAmount.toLocaleString()}</td>
         <td>${x.invoiceDiscountPercent}</td>
        <td>${x.discount}</td>
        <td></td>
        <td> <a type="button" class="" onclick="(ProuctListDes('${x.id}'))">...</a></td>
        <td>

            <a class="" onClick="removeProductList('${x.id}','${x.invoiceDetailsId}')" title="حذف">
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

        $(".property-dataTable").append($('<tfoot />').append($("<tr> <td>مجموع:</td> <td></td><td>" + totalCount + "</td> <td>" + parseFloat(amountFooter).toLocaleString() + "</td> <td>" + parseFloat(totalFooter).toLocaleString() + "</td><td></td> <td>" + Math.abs(totalPriceWithDiscount).toLocaleString() + "</td> <td>" + Math.abs(totalGetTax).toLocaleString() + "</td> <td>" + Math.abs(totalPaidAmount).toLocaleString() + "</td> <tr>").clone()));

        // totalInvoiceDiscount = ConvertPercentToAmount(totalPaidAmount, totalInvoiceDiscount);
        //totalPaidAmount -= totalInvoiceDiscount;
        //totalPaidAmount = Math.abs(totalPaidAmount);


        applyTotal(totalCount, totalFooter, totalDiscountAmount, totalInvoiceDiscount, x.invTotalTax, x.totalPaidAmount)
        var invoice =
        {
            amount: amount,
            total: total,
            priceWithDiscount: priceWithDiscount,
            paidAmount: paidAmount,
            tax: getTax,
            totalPriceWithDiscount: Math.abs(totalPriceWithDiscount),
            totalPaidAmount: x.totalPaidAmount,
            totalGetTax: x.invTotalTax,
            totalCount: totalCount,
            totalFooter: totalFooter,
            totalDiscountAmount: totalDiscountAmount,
            totalInvoiceDiscount: totalInvoiceDiscount,
        };
        setCookie(InvoiceCookie, invoice);

        checkStatus(obj[0].status)

    });
}


$("#tempInvoice").on('click', function (evt) {

    swal({
        title: 'این فاکتور به  فاکتور موقت تبدیل خواهشد است!',
        text: "آیا مطمئن هستید که میخواهید ادامه دهید؟",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'ادامه',
        cancelButtonText: 'لغو',
        padding: '2em',
    }).then(function (result) {

        if (result.value) {

            $("#type").val("09004CE6-3DAC-4EEB-AFE9-E1E7DDD8AD28");
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
                beforeSend: function () {
                    showLoader()
                },

                success: function (result) {

                    if (result.isSucceeded) {
                        checkStatus(result.data)
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
                ,
                error: function (error) {

                    alert(error);
                }
                ,
                complete: function () {
                    hideLoader()
                }
            })

        }
    })
})



function checkStatus(status) {

    $("#invoiceStatus").removeClass("d-none");
    $("#invoicePayStatus").removeClass("d-none");
    $("#invoiceType").removeClass("d-none");

    $("#invoiceStatusText").text(status.statusSubmit);
    $("#invoicePayStatusText").text(status.statusPay);
    $("#invoiceTypeText").text(status.invoiceType);
    $("#invoiceNumber").val(status.invoiceNumber);

    if (status.statusPay == "تسویه نشده")
        document.querySelectorAll(".invoicePay").forEach(x => x.classList.remove("d-none"));
}


// payment




function applyOtherPayTotal(totalPaidAmount, remain) {

    $("#otherPaytotal").html(" ");
    if (remain == undefined)
        remain = totalPaidAmount;
    $("#otherPaytotal").append(`
          <div class="col-md-12 col-sm-12 col-xs-12 table-responsive">
            <table class="table table-bordered">
             <tbody>
                     <tr class="">
                         <td class="font-weight-bold text-dark">تجمیع: </td>
                   
                           <td class="bg-aliceblue text-dark">مانده فاکتور</td>
                         <td> <strong class="text-success">${remain.toLocaleString()}</strong></td>
                       
                         <td class="bg-aliceblue text-dark">جمع کل دریافتی</td>
                         <td> <strong class="text-success">${totalPaidAmount.toLocaleString()}</strong></td>

                     </tr>
                  </tbody>
              </table>
            </div>
        `).removeClass("d-none");
}



$("#cashPayment").on('click', function (evt) {
    //evt.preventdefault();
   
    var invoice = getParseCookie(InvoiceCookie);
    var account = getParseCookie(AccountClubCookie);
    $("#AccountClubNamePay").val(account.accClbName);
    setCookie(CashPaymentCookie, invoice);
    applyTotal(invoice.totalCount, invoice.totalFooter, invoice.totalDiscountAmount, invoice.totalInvoiceDiscount, invoice.totalGetTax, invoice.totalPaidAmount, 0)
    notify("top center", "تسویه انجام شد، برای ادامه فاکتور را ثبت کنید", "success")
})


var invoiceNumber = 0;
$("#otherPayment").on('click', function (evnt) {

    $.ajax({
        url: "?handler=GeneratePaymentNumber",
        type: "get",
        success: function (result) {
            debugger
            invoiceNumber = result.generateNumber;
            var invoice = getParseCookie(InvoiceCookie);
            var account = getParseCookie(AccountClubCookie);
            var paidAmount = invoice.totalPaidAmount;
            $("#invoiceNumberPay").text(invoiceNumber);
            $("#AccountClubNamePay").text(account.accClbName);
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

  
})

$("#bank").on("change", function (evt) {
    debugger
    var type = $("#bank").val();
    $.ajax({
        url: "?handler=pose&bankType=" + type,
        type: "Get",
        success: function (result) {
            debugger
            $("#pose").empty();
            result.forEach(x => {
                const list = `
                    <option value="${x.id}">${x.name}</option>
                `
                $("#pose").append(list)
            })
        }
    })
})

$("#cardReader").on('click', function (evnt) {
    debugger

  
    var bank = $("#bank").val();
    var bankName = $("#bank option:selected").text();
    var amount = $("#amountPay").val();
    var pose = $("#pose").val();
    if (bank == "0" || amount == "" || pose == "0" || pose==null) {

        notify("top center", "اطلاعات را به درستی وارد کنید", "error");
        return false;
    }
    var rowNo = 0;
    var des = `بابت برگه دریافت وجه شماره ${invoiceNumber} و  ${bankName} بصورت کارت - کارت خوان`;
    var invoice = getParseCookie(InvoiceCookie);
    var paidAmount = invoice.totalPaidAmount;

    var remain = paidAmount - amount;
    if (remain < 0) {
        notify("top center", "مبلغ وارد شده بیش از مبلغ از دریافتی است");
        return false;
    }

    var type = 2;


    var obj = [];
    var otherPay = {
        totalPaidAmount: applyOtherPayTotal,
        bank: bank,
        remain: remain,
        des: des,
        type: type,
        amount: amount
    };
    debugger
    var cookie = getCookie(OtherPayCookie);
    if (cookie === "")
        obj.push(otherPay);
    else
        obj.push.apply(otherPay,obj);

    if (obj.length == 0 && otherPay !== "")
        obj.push(otherPay);

    setCookie(OtherPayCookie, obj);

    //TODo connect to ReaderCard

    payTable.clear().draw();

    obj.forEach(x => {
        var result = ` <tr>
   
        <td>${rowNo += 1}</td>
        <td>${x.des}</td>
         <td>${x.amount ?? ""}</td>
        <td>${x.type}</td>
        <td>
            <a class="" title="حذف">
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
        payTable.row.add($(result)).draw();
    })
    applyOtherPayTotal(amount, remain);
})
function calculatePay(amount, type, bank, trackingCode) {



}