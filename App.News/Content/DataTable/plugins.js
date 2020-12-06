$(function () {
    var uiElements = function () {

        //Datatables
        var uiDatatable = function () {
            if ($(".datatable").length > 0) {
                $('.datatable').dataTable({
                    "oLanguage": {
                        "sSearch": "Search:",
                        "sProcessing": "DataTable is busy",
                        "sZeroRecords": "No Rows",
                        "sLoadingRecords": "Please wait - Loading ...",
                        "sLengthMenu": 'Show ' + '_MENU_ ',
                        "sInfoFiltered": "", // " - filtering from _MAX_ records"
                        "sInfoEmpty": "No Records",
                        "sPrevious": "<<",
                        "sNext": ">>",
                        "sLast": "Last",
                        "sFirst": "First",
                        "oPaginate":
                        {
                            "sNext": '>>',
                            "sLast": 'Last',
                            "sFirst": 'First',
                            "sPrevious": '<<'
                        }, "sInfo": "Rows _START_  -  _END_."
                        // "sInfo": "&copy"  // Show 1 to 3 footer
                    }
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

