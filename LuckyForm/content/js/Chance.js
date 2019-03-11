$("document").ready(
    function () {
        $("img.card_type_img").click(
            function () {
                var limit = 1;
                if ($(this).parent().hasClass("strong_numbers")) {
                    limit = 1;
                }
                if (formType === 3) {
                    limit = 17;
                }

                if (countChosenNumbers($(this).parent()) >= limit && !$(this).hasClass("clicked")) {
                    //error border

                }
                else {
                    if ($(this).hasClass("clicked")) {
                        $(this).removeClass("clicked");
                        $(this).children().attr('checked', false)
                    }
                    else {
                        $(this).addClass("clicked");
                        $(this).children().attr('checked', true)
                    }
                }

                tableValidition($(this));
            });

    });
