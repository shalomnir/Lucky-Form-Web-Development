$("document").ready(
    function () {
        $.ajax({
            url: '/Home/GetFormsInType?Type=0',
            dataType: "html",
            success: function (data) {
                $('#LotteryContent').html(data);
            }
        });
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
