/// <reference path="Slider.js" />



$("document").ready(
    function () {
        
        $(".number").click(
            function () {
                var limit = 1;
                if ($(this).parent().hasClass("regular_numbers")){
                    limit = 6;
                }              
               
                if (countChosenNumbers($(this).parent()) >= limit && !$(this).hasClass("clicked")){
                    //error border
                    
                }
                else{
                    if ($(this).hasClass("clicked")){
                        $(this).removeClass("clicked");
                        $(this).children().attr('checked', false)
                    }                    
                    else{
                        $(this).addClass("clicked");
                        $(this).children().attr('checked', true)
                    }
                }      
                
                tableValidition($(this));                    
            });
        $(".trash_icon").click(
            function () {              
                clearAllNumbers($(this).parents('#inner_table'));
                tableValidition($(this));
            });
        $(".quick_pick_button").click(
            function () {
                clearAllNumbers($(this).parents('#inner_table'));
                CheckRandomNumbers($(this).parents('#top_table').siblings('.regular_numbers'));
                CheckRandomNumbers($(this).parents('#top_table').siblings('.strong_numbers'));

                tableValidition($(this));
            });
        
        $(".submit_tables").click(
            function () {
                var form = $(this).parents('form:first');                
                if(!formValidation(form))
                {
                    alert("not valid");
                    return;
                }
                else if (!(perfectTableCount(form) > 0 && perfectTableCount(form) % 2 == 0))
                {
                    alert("nor pairs");
                    return;
                }
                form.submit();
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
    if (countChosenNumbers(element.parents('#inner_table')) < 7 && countChosenNumbers(element.parents('#inner_table')) > 0) {
        element.parents('#table').addClass("table_error");
    }
    else if (countChosenNumbers(element.parents('#inner_table')) == 0) {
        element.parents('#table').removeClass("table_error");
        element.parents('#table').removeClass("table_perfect");

    }
    else {
        element.parents('#table').removeClass("table_error");
        element.parents('#table').addClass("table_perfect");
    }
}
function countChosenNumbers(element)
{
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
    var limit = 7;
    var checkedCount = 1;
    if (element.hasClass("regular_numbers")) {
        limit = 37;
        checkedCount = 6;
    }   
    for (var i = 0; i < checkedCount; i++)
    {
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