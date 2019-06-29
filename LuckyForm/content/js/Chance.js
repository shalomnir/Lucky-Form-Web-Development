
$("document").ready(
    function () {
        formID = $(".chance_form").data('formid');
        var limit = 4;
        if (formID === 10 || formID === 11) {
            limit = 1;
        }
        $(".card_img").click(
            function () {
                var countCards = countChosenNumbers($(this).parent());
                
                if ($(this).hasClass("clicked")) {
                    $(this).removeClass("clicked");
                    $(this).siblings(".card_img").removeClass("not_clicked");
                    $(this).siblings("input").attr('checked', false)
                }
                else if (countCards >= limit)
                {
                    $(this).siblings(".card_img:not(.clicked)").addClass("not_clicked");
                }
                else {                                      
                    $(this).addClass("clicked");
                    if (formID !== 12 || countChosenNumbers($(this).parent()) >= limit) {
                        $(this).siblings(".card_img:not(.clicked)").addClass("not_clicked");
                    }
                    $(this).prev("input").attr('checked', true)                    
                }

                

                tableValidition($(this));
            });
        
        $(".submit_tables").click(
            function () {
                var form = $(this).parents('form:first');
                
                $("#first_row").val(countChosenNumbers($(".chance_form .card_type:nth-child(2)")));                
                $("#second_row").val(countChosenNumbers($(".chance_form .card_type:nth-child(3)")));
                $("#third_row").val(countChosenNumbers($(".chance_form .card_type:nth-child(4)")));
                $("#fourth_row").val(countChosenNumbers($(".chance_form .card_type:nth-child(5)")));

                if (formID === 10) {
                    
                    if (!formValidation(form)) {

                        ("Invalid form, read instruction");
                        return;
                    }
                    form.submit();
                }
                else if (formID === 11) {
                   
                    if (perfectTableCount(form) < 4) {
                        alert("You must fill all the tables");
                        form.find('.card_type').each(function (i) {
                            if (!$(this).hasClass("table_perfect")) {
                                $(this).addClass("table_error");                                                                                                                          
                            }
                        });
                        return;
                    }
                    form.submit();
                }

                else {
                    
                    if (!formValidation(form) || perfectTableCount(form) < 4) {
                        alert("You must fill all the tables");
                        form.find('.card_type').each(function (i) {
                            if (!$(this).hasClass("table_perfect")) {
                                $(this).addClass("table_error");
                            }
                        });
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
    element.find("input[type='checkbox']").each(function () {
        if ($(this).is(":checked")) {
            
            count++;
        }// "this" is the current element in the loop
    }); 
    return count;
}
function tableValidition(element) {
    element.parents('.card_type').addClass("table_error");
    var reqNums = 1;   
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
    if (formID === 10 || formID === 12) {
        if (perfectTableCount(form) === 0) {
            isValid = false;
            alert("fill min one table");
        }
    }
    else if (formID === 11) {
        form.find('.card_type').each(function () {
            if (!$(this).hasClass("table_perfect")) {
                isValid = false;
                $(this).addClass("table_error");
                alert("must fill all tables");
            }
        });
    }   
    return isValid;
}
