
var formType = "0";
$("document").ready(
    function () {
        formID = $(".chance_form").data('formid');
        $(".card_img").click(
            function () {

                var limit = 6;
                if (formID == 10) {
                    limit = 1;
                }
                

                if (countChosenNumbers($(this).parent()) >= limit && !$(this).hasClass("clicked")) {
                    //error border

                }
                else {
                    if ($(this).hasClass("clicked")) {
                        $(this).removeClass("clicked");
                        $(this).siblings("input").attr('checked', false)
                    }
                    else {
                        $(this).addClass("clicked");
                        $(this).siblings("input").attr('checked', true)
                    }
                }

                tableValidition($(this));
            });

    });


function countChosenNumbers(element)
{
    var count = 0;
    element.find('.card_img').each(function () {
        if ($(this).hasClass("clicked")) {
            count++;
        }// "this" is the current element in the loop
    });  
    return count;
}
function tableValidition(element) {

    var reqNums = 1;
    if (formType === 10) {
        reqNums = 1;
    }

    if (countChosenNumbers(element.parents('.card_type')) < reqNums && countChosenNumbers(element.parents('.card_type')) > 0) {
        element.parents('.card_type').addClass("table_error");
    }
    else if (countChosenNumbers(element.parents('.card_type')) == 0) {
        element.parents('.card_type').removeClass("table_error");
        element.parents('.card_type').removeClass("table_perfect");

    }
    else {
        element.parents('.card_type').removeClass("table_error");
        element.parents('.card_type').addClass("table_perfect");
    }
}