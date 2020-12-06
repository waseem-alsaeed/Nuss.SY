$(function () {
    var uiElements = function () {

        //Datatables
        var uiDatatable = function () {
            if ($(".datatable").length > 0) {
                $('.datatable').dataTable({
                    "oLanguage": {
                        "sSearch": "Ara:",
                        "sProcessing": "DataTable þu anda meþgul",
                        "sZeroRecords": "Kayit Yok",
                        "sLoadingRecords": "Lutfen bekleyin - yukleniyor ...",
                        "sLengthMenu": "K.S _MENU_ ",
                        "sInfoFiltered": "", // " - filtering from _MAX_ records"
                        "sInfoEmpty": "Veri Yok",
                        "sPrevious": "<<",
                        "sNext": ">>",
                        "sLast": "Son",
                        "sFirst": "Ilk",
                        "oPaginate":
                        {
                            "sNext": '>>',
                            "sLast": 'Son',
                            "sFirst": 'Ilk',
                            "sPrevious": '<<'
                        }, "sInfo": "Satir _START_  -  _END_   gosteriliyor."
                        // "sInfo": "&copy"  // Show 1 to 3 footer
                    },
                    "ordering": false
                });
                $(".datatable").on('page.dt', function () {
                    onresize(100);
                });
            }

            if ($(".datatable_simple").length > 0) {
                $(".datatable_simple").dataTable({ "ordering": false, "info": false, "lengthChange": false, "searching": false });
                $(".datatable_simple").on('page.dt', function () {
                    onresize(100);
                });
            }
        }//END Datatable        

        $(window).resize(function () {
            if ($(".owl-carousel").length > 0) {
                $(".owl-carousel").data('owlCarousel').destroy();
                uiOwlCarousel();
            }
        });

        return {
            init: function () {
                uiDatatable();
            }
        }

    }();
    uiElements.init();

});