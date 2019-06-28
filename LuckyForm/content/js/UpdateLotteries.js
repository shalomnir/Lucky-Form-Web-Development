$("document").ready(
    function () {      
        $(".lotteries_type li").click(
            function () {
                $(this).siblings().css("border", "none");
                $(this).css("border-bottom", "3px solid #1A5C7A");
                $("#add").css("visibility", "visible");
                var index = $(this).index();
                $("#add").attr("href", "/Home/AddLotteryInType?Type=" + index);
                $.ajax({
                    url: '/Home/GetLotteryByType?Type=' + index,
                    dataType: "html",
                    success: function (data) {
                        $('.lotteries_wrapper').html(data);
                    }
                });
            });
       

    });
