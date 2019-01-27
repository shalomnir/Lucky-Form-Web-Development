/// <reference path="D:\nir\Lucky-Form-Web-Development\LuckyForm\Views/Home/Index.cshtml" />

$("document").ready(
    function () {
        // When the user scrolls the page, execute myFunction 
        window.onscroll = function () { myFunction() };
        // Get the header
        var header = document.getElementById("menu");
        // Get the offset position of the navbar
        var sticky = header.offsetTop;
        // Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
        function myFunction() {
            if (window.pageYOffset > sticky) {
                header.classList.add("sticky");
            } else {
                header.classList.remove("sticky");
            }
        }
        $(".sub_menu li").click(
            function () {
                var index = $(this).index();
                if (index == '0')
                    $('#LotteryContent').html('Views/Home/Index.cshtml');
                $.ajax({
                    url: '/Home/GetFormsInType?Type=' + index,
                    dataType: "html",
                    /*beforeSend: function () {
                        var img = "<img src='/Content/Images/wait.GIF' width=500>";
                        $('#readerDitals').html(img)
                    },*/
                   
                    success: function (data) {
                        $('#LotteryContent').html(data);
                    }
                });
            });
    });
