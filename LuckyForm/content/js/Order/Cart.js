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
        $(".pay").click(function () {
            $(this).parents("form").submit();
        });
        $(function () {
            $("input[name = 'name']").keydown(function (e) {
                if (e.shiftKey || e.ctrlKey || e.altKey) {
                    e.preventDefault();
                } else {
                    var key = e.keyCode;
                    if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                        e.preventDefault();
                    }
                }
            });
        });
        $(".number_only").on("keypress keyup blur", function (event) {
            $(this).val($(this).val().replace(/[^\d].+/, ""));
            if ((event.which < 48 || event.which > 57)) {
                event.preventDefault();
            }
        });
    });
