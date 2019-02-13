﻿/// <reference path="D:\nir\Lucky-Form-Web-Development\LuckyForm\Views/Home/Index.cshtml" />

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
                
                $.ajax({
                    url: '/Home/GetFormsInType?Type=' + index,
                    dataType: "html",                   
                    success: function (data) {
                        $('#LotteryContent').html(data);
                    }
                });
            });

       
    });