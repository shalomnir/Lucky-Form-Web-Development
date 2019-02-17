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
        $("#commentForm").validate({

            rules: {
                email: {
                    required: true,
                    email: true,
                },
                password: {
                    required: true,
                    strongPassword: true
                },                
                first_name: {
                    required: true,
                    nowhitespace: true,
                    lettersonly: true
                },
                last_name: {
                    required: true,
                    nowhitespace: true,
                    lettersonly: true                
                },
                mobile_number: {
                    required: true,
                    digits: true,
                    phonesUK: true
                }                                              
            },
            messages: {
                email: {
                    required: 'Please enter an email address.',
                    email: 'Please enter a <em>valid</em> email address.',
                    remote: $.validator.format("{0} is already associated with an account.")
                }
            }
        });

        
    });
