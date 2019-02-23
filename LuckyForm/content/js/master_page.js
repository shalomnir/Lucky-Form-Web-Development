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

        
        $.validator.setDefaults({
            highlight: function (element) {              
                $(element).siblings()                  
                  .addClass('has-error');
                $(element)                   
                  .closest('.form-group')
                  .addClass('has-error');
            },
            unhighlight: function(element) {
                $(element)
                  .closest('.form-group')
                   .removeClass('has-error');
                $(element).siblings()
                    .removeClass('has-error');
            },
            errorPlacement: function (error, element) {
                if (element.prop('type') === 'checkbox') {
                    error.insertAfter(element.parent());
                } else if (element.prop('name') === 'password') {
                    error.insertAfter(element.parent());
                } else {
                    error.insertAfter(element);
                }
            }
        });
        $.validator.addMethod('lettersOnly', function (value, element) {
            return this.optional(element)
                || value.length >= 2               
            && value.match(new RegExp("^[a-zA-Z\s]+$"));
        }, 'Your password must contain at least 2 characters and can contain letters only\.')

        $.validator.addMethod('strongPassword', function(value, element) {
            return this.optional(element) 
              || value.length >= 6
              && /\d/.test(value)
              && /[a-z]/i.test(value);
        }, 'Your password must be at least 6 characters long and contain at least one number and one char\'.')
        function costumValidate() {
            $("#verified_form_sign_up,#verified_form_login").each(function () {
                $(this).validate({
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
                            lettersOnly: true
                        },

                        last_name: {
                            required: true,
                            lettersOnly: true
                        },

                        mobile_number: {
                            required: true,
                            digits: true,
                            
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
        }
        costumValidate();        
        var form = $("#verified_form_sign_up,#verified_form_login");
        form.submit(function () {
            if (form.valid()) {
                $("#loading").show();                
                $(".sign_up_button").css("display", "none");
            }
        });
        
    });

        

