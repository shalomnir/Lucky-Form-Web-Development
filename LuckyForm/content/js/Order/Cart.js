$("document").ready(
    function () {
        $(".view_form_button").click(
            function () {
                var detId = $(this).parents(".product_details").data('detid');
                var formId = $(this).parents(".product_details").data('formid');
                $.ajax({

                    url: '/Order/ViewFormByID?detId=' + detId + '&formId=' + formId,
                    dataType: "html",
                    success: function (data) {
                        $('.cart_wrapper').html(data);
                    }
                });
                $(".cart_wrapper").css("display", "table");
                $(".form_wrapper").css("display", "table-row");
            });

    });
