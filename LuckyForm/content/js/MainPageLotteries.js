$("document").ready(
    function () {
        $(".sub_menu li").click(
            function () {

                var index = $(this).index();

                $.ajax({
                    url: '/Home/GetFormsInType?Type=' + index,
                    dataType: "html",
                    success: function (data) {
                        $('#LotteryContent').html(data);
                    }
                });
            });
        
    });
