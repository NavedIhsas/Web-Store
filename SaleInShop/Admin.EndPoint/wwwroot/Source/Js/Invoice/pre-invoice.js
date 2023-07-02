


const ProductListCookie = "productList";
const AccountClubCookie = "AccountClubList";

$(document).ready(function () {
    $(".datePicker").persianDatepicker({
        initialValueType: 'persian',
        format: 'YYYY/MM/DD',
        autoClose: true,
    });
    bindDatatable();
    deleteCookie(ProductListCookie);
    //deleteCookie(AccountClubCookie);
    //document.getElementById("custom-menu").click();
});



const table = $('#property-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    order: [[2, 'desc']],
    searching: false,
    dom: 'Bfrtip',
    buttons: [
        {
            extend: 'print',
            text: 'چاپ',
            autoPrint: true,
            title: '<center><h3>پیش فاکتور</h3></center>',
            exportOptions: {
                columns: [1, 2, 3, 4, 5]
            },
            messageTop: function () {
                var find = document.getElementById("cardPrint").innerHTML;
                return find;
            },
            messageBottom: function () {
                return 'این یک متن تست در پایین صفحه چاپ هست'
            },
            repeatingHead: {
                logo: 'https://www.google.co.in/logos/doodles/2018/world-cup-2018-day-22-5384495837478912-s.png',
                logoPosition: 'right',
                logoStyle: '',
                title: '<h3>پیش فاکتور</h3>'
            },

            customize: function (win) {
                $(win.document.body).find('table').addClass('display').css('font-size', '9px');
                $(win.document.body).find('tr:nth-child(odd) td').each(function (index) {
                    $(this).css('background-color', '#D0D0D0');
                });
                $(win.document.body).find('h1').css('text-align', 'center');
            }
        }
        , {

            extend: 'excel',
            text: 'خروجی Excel',
            title: 'پیش فاکتور',
            exportOptions: {
                columns: [5, 4, 3, 2, 1]
            },
            messageTop: function () {
                return "شماره فاکتور 234555 و مشتری آقای حسین انصاری میباشد";
            },
            messageBottom: function () {
                return 'این یک متن تست در پایین صفحه چاپ هست'
            },
        }
    ]
});


function submitPrint() {
    debugger
    table.button('.buttons-print').trigger();
}

function openCity(evt, cityName) {
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
                    "searchable": true
                },
                {
                    "data": "PrdLvlName",
                    "autoWidth": true,
                    "searchable": true
                },

                {
                    "data": "PrdPricePerUnit1",
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

        return ` <a onClick="addProductToList('${data.PrdUid}','${data.PrdName}','${data.PrdPricePerUnit1},'${data.AccClubDiscount}')" type="button" >
        <svg style="color:green" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-plus"><line x1="12" y1="5" x2="12" y2="19"></line><line x1="5" y1="12" x2="19" y2="12"></line></svg>
    </a>
    `
    };

}

function openDetails(evt, name) {

    var i, tabcontent, tablinks;
    $("#productName").append("");
    $.ajax({

        url: "?handler=ProductLevel&productLvl=" + name,
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
                                                  <button onClick="addProductToList('${x.prdUid}','${x.prdName}','${x.prdPricePerUnit1}')" type="button" class="btn btn-success" style="background: burlywood;">
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

function updateTable(obj) {

    table.clear().draw();
    var amount = 0;
    obj.forEach(x => {
        const result =
            `
    <tr>
        <td></td>
        <td>${x.name ?? ""}</td>
        <td>${x.value ?? ""}</td>
        <td>${x.price}</td>
        <td></td>
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
        amount += parseInt(x.price);

        debugger
        var footer = document.getElementsByTagName("tfoot");
        if (footer.length !== 0)
            footer[0].parentNode.removeChild(footer[0]);

        $("#property-dataTable").append($('<tfoot />').append($("<tr> <td>مجموع:</td> <td></td><td></td> <td>" + parseInt(amount) + "</td> <td></td> <td></td> <td></td> <td></td> <tr>").clone()));


        //);
        //                        $('#property-dataTable').append("<tfoot id='footer'> <tr> <td>مجموع:</td> <td></td><td></td> <td>" + parseInt(amount) + "</td> <td></td> <td></td> <td></td> <td></td> <tr> ")
        //                         
    });
}

function addProductToList(id, name, price,discount) {

    var account = getCookie(AccountClubCookie);
    if (account == "") {
        notify("top center", "لطفا ابتدا مشتری را انتخاب کنید", "error");
        return false;
    }

    var obj =
        [
            {
                id: id,
                name: name,
                price: price,
                discount: discount,
                value: 1,
                des: "",
            }
        ];

    var cookie = getCookie(ProductListCookie);
    if (cookie === "")
        setCookie(ProductListCookie, obj);

    else {
        var parse = JSON.parse(cookie);
        const found = parse.find(element => element.id === id);
        if (found !== undefined) {

            found.value = found.value + 1;
            obj = parse.filter(element => element.id !== id);
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
    const found = parse.find(element => element.id === id);
    if (found !== undefined) {
        parse = parse.filter(element => element.id !== id);
        setCookie(ProductListCookie, parse);
        updateTable(parse);
    }
}

function addDesToPrdList() {
    var id = $("#prodcutDes").val();
    var value = $("#descript").val();
    var cookie = getCookie(ProductListCookie);
    var parse = JSON.parse(cookie);
    const found = parse.find(element => element.id === id);
    var obj = parse.filter(element => element.id !== id);
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
        return `<center><a onClick="addAccountClub('${data.AccClbUid}','${data.AccClbName}')" class="btn btn-warning btn-rounded btn-sm">انتخاب مشتری</a>&nbsp; `
    };

}


function addAccountClub(id, name) {
    deleteCookie(AccountClubCookie);

    var accound = {
        accClbUid: id,
        accClbName: name,
      
    };

    setCookie(AccountClubCookie, accound);
    notify('top center', 'مشترک مورد نظر انتخاب شد', 'success');
    getAccountClub();
    $("#AccClbList").modal('hide');

}

function getAccountClub() {

    var account = getParseCookie(AccountClubCookie);
    $("#accClubName").text('مشتری: ' + account.accClbName)
}


