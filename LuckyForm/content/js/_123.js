$("document").ready(
    function () {        
        $(".number").click(
            function () {
                limit = 1;
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

                tableValidition($(this).parents(".table"));
            });
        $(".trash_icon").click(
            function () {
                clearAllNumbers($(this).parents('.table'));
                tableValidition($(this).parents(".table"));
            });
        $(".quick_pick_button").click(
            function i() {
                clearAllNumbers($(this).parents('.table'));
                $(this).parents(".table").find('.nums_row').each(function () {
                    CheckRandomNumbers($(this));
                });
                
               
                tableValidition($(this).parents(".table"));
            });

        $(".submit_tables").click(
            function () {
                var form = $(this).parents('form:first');
                if (perfectTableCount(form) === 0 || !formValidation(form)) {
                    alert("ERROR");
                    return;               
                    form.submit();
                }
               
            });

    });

function formValidation(form) {

    var isValid = true;
    form.find('.table').each(function () {
        if ($(this).hasClass("table_error")) {
            isValid = false;
        }

    });
    return isValid;
}
function perfectTableCount(form) {
    var count = 0;
    form.find('.table').each(function (i) {
        if ($(this).hasClass("table_perfect")) {
            count++;
        }

    });
    return count;
}
function tableValidition(element) {

    var reqNums = 3;      

    
    if (countChosenNumbers(element) === 0) {
        element.removeClass("table_error");
        element.removeClass("table_perfect");
        
    }
    else if (countChosenNumbers(element) < reqNums ) {
        element.addClass("table_error");

    }
    else {
        element.removeClass("table_error");
        element.addClass("table_perfect");

    }
}
function countChosenNumbers(element) {
    var count = 0;
    element.find('.number').each(function () {
        if ($(this).hasClass("clicked")) {
            count++;
        }// "this" is the current element in the loop
    });
    return count;
}
function clearAllNumbers(element) {
    element.find('.number').each(function () {
        $(this).children().attr('checked', false);
        $(this).removeClass("clicked");
    });
}
function CheckRandomNumbers(element) {
    var random = -1;
    var rand_nums = [];
    var limit = 9;
    var checkedCount = 1;
    for (var i = 0; i < checkedCount; i++) {
        random = Math.floor((Math.random() * limit) + 1);
        while (jQuery.inArray(random, rand_nums) !== -1)
            random = Math.floor((Math.random() * limit) + 1);

        rand_nums[i] = random;
    }
    jQuery.each(rand_nums, function (i, val) {
        element.find('.number').eq(val - 1).addClass("clicked");
        element.find('.number').eq(val - 1).children().attr('checked', true);
    });
}