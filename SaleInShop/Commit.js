//<link
//    rel="stylesheet"
//    href="https://cdn.datatables.net/buttons/2.3.6/css/buttons.dataTables.min.css">


const table = $('#property-dataTable').DataTable({
    paging: false,
    ordering: true,
    info: false,
    order: [[2, 'desc']],
    searching: false,
    dom: 'Bfrtip',
    //region Buttons
    buttons: [
        {
            extend: 'print',
            text: 'چاپ',
            autoPrint: true,
            className: "buttonsToHide",
            title: '<center><h3>پیش فاکتور</h3></center>',
            exportOptions: {
                columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
                columns: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0]
            },
            messageTop: function () {
                return "شماره فاکتور 234555 و مشتری آقای حسین انصاری میباشد";
            },
            messageBottom: function () {
                return 'این یک متن تست در پایین صفحه چاپ هست'
            },
        }
    ]
    //endregion

}); 

// call print button
function submitPrint() {
    table.button('.buttons-print').trigger();
}

////<script src="https://cdn.datatables.net/buttons/2.3.6/js/buttons.print.min.js"></script>
////    <script src="https://cdn.datatables.net/buttons/2.3.6/js/dataTables.buttons.min.js"></script>
////    <script src="https://cdn.datatables.net/buttons/2.3.6/js/buttons.html5.min.js"></script>
////    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
