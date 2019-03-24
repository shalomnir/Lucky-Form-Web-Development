﻿
$("document").ready(
    function () {
        formID = $(".chance_form").data('formid');
        $(".card_img").click(
            function () {
                var limit = 6;
                if (formID === 10 || formID === 11) {
                    limit = 1;
                }
                var limit = 1;
                if (formID == 12) {
                    limit = 4;
                }
                

                if (countChosenNumbers($(this).parent()) >= limit && !$(this).hasClass("clicked")) {
                    //error border
                }
                else {
                    if ($(this).hasClass("clicked")) {
                        $(this).removeClass("clicked");
                        $(this).siblings(".card_img").removeClass("not_clicked");
                        $(this).siblings("input").attr('checked', false)
                    }
                    else {
                        $(this).addClass("clicked");
                        $(this).siblings(".card_img").addClass("not_clicked");
                        $(this).prev("input").attr('checked', true)
                    }
                }

                tableValidition($(this));
            });
        $(".submit_tables").click(
            function () {
                var form = $(this).parents('form:first');             
                if (formID === 11) {
                    if (perfectTableCount(form) < 4) {
                        //alert("must fill all tables");
                        form.find('.card_type').each(function (i) {
                            if (!$(this).hasClass("table_perfect")) {
                                $(this).addClass("table_error");
                                $(this).removeClass("table_error");
                                $(this).addClass("table_error");
                                $(this).removeClass("table_error");
                                
                                
                                //$(this).animate({ transform: 'scale(1.2)'}, "slow");
                                //$(this).animate({ height: '+=40px'}, "slow");
                            }
                        });
                        return;
                    }
                }
                form.submit();
                if (formType === 10) {
                    if (!formValidation(form)) {
                        alert("not valid");
                        return;
                    }
                    form.submit();
                }
                else {
                    if (!formValidation(form)) {
                        alert("not valid");
                        return;
                    }
                    else if (!perfectTableCount(form) > 0) {
                        alert("zero");
                        return;
                    }
                    form.submit();
                }
            });

    });

function perfectTableCount(form) {
    var count = 0;
    form.find('.card_type').each(function (i) {       
        if ($(this).hasClass("table_perfect")) {
            count++;
        }

    });
    return count;
}
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
    element.parents('.card_type').addClass("table_error");
    var reqNums = 1;
    if (formID === 10 || formID === 11) {
        reqNums = 1;
    }
    if (countChosenNumbers(element.parents('.card_type')) === 0) {
        element.parents('.card_type').removeClass("table_error");
        element.parents('.card_type').removeClass("table_perfect");
        return false;
    
    }
    else {
        element.parents('.card_type').removeClass("table_error");
        element.parents('.card_type').addClass("table_perfect");
        return true;
    }
}

function formValidation(form) {
    var isValid = true;
    form.find('.card_type').each(function () {
        if (!tableValidition($(this))) {
            isValid = false;
            $(this).addClass("table_error");
        }

    });
    return isValid;
}
