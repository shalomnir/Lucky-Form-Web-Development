/// <reference path="Slider.js" />


var formType = "0";
var formId = "0"
$("document").ready(
    function () {
        formType = $(".regular_numbers").data('formtype');
        formId = $(".regular_numbers").data('formid');
        $(".number").click(
            function () {               
                var limit = 6;
                if (formId === 3 || formId === 4)
                    limit = 12
                else if (formId === 5 || formId === 6 || formId === 7)
                    limit = 7
                else if (formId === 8)
                    limit = 9;

                

                if ($(this).parent().hasClass("strong_numbers")) {
                    limit = 1;
                    if (formId === 5 || formId === 6)
                        limit = 7
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
               
                tableValidition($(this).parents(".inner_table"));
            });
        $(".trash_icon").click(
            function () {              
                clearAllNumbers($(this).parents('#inner_table'));
                tableValidition($(this).parents(".inner_table"));
            });
        $(".quick_pick_button").click(
            function () {
               
        clearAllNumbers($(this).parents('#inner_table'));
        CheckRandomNumbers($(this).parents('#top_table').siblings('.regular_numbers'));
        if (formType === 1)
            CheckRandomNumbers($(this).parents('#top_table').siblings('.strong_numbers'));

        tableValidition($(this).parents(".inner_table"));
    });
        
$(".submit_tables").click(
    function () {
                
        var form = $(this).parents('form:first');
        $("#reg_numbers").val(countChosenNumbers($(".regular_numbers:first")));
        $("#strong_numbers").val(countChosenNumbers($(".strong_numbers:first")));
        if (formType === 1) {                
            if (!formValidation(form)) {
                setInterval(function () {
                            
                    $(".explain").toggleClass("valid_error");
                }, 300)
                alert("not valid");
                return;
            }
            else if (!(perfectTableCount(form) > 0 && perfectTableCount(form) % 2 === 0)) {
                setInterval(function () {

                    $(".explain").toggleClass("valid_error");
                }, 300)
                alert("not pairs");
                return;
            }
                     
            form.submit();
        }
        else {
            if (!formValidation(form)) {
                setInterval(function () {

                    $(".explain").toggleClass("valid_error");
                }, 300)
                alert("not valid");
                return;
            }
            else if (!perfectTableCount(form) > 0) {
                setInterval(function () {
                    $(".explain").toggleClass("valid_error");}, 300)
                alert("zero");
                return;
            }
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
    
    var reqNums = 6;
    var strongReq = 1;
    if (formId === 3 || formId === 4)
    {
        reqNums = 8;
        strongReq = 1;
    }
    else if (formId === 5 || formId === 6 || formId === 7)
    {
        reqNums = 7;
        strongReq = 4;
    }     
    else if (formId === 8)
    {
        reqNums = 8;
    }
   
    
    if (countChosenNumbers(element) === 0)
    {
        element.parents('#table').removeClass("table_error");
        element.parents('#table').removeClass("table_perfect");
        
    }
    else if (countChosenNumbers(element.children('.regular_numbers')) < reqNums || ((countChosenNumbers(element.children('.strong_numbers')) < strongReq) && formType !== 3)) {
        element.parents('#table').addClass("table_error");
       
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

   
    if (formId === 1 || formId === 2) {
        if (element.hasClass("regular_numbers")) {
            limit = 37;
            checkedCount = 6;
        }
    }
    if (formId === 3 || formId === 4) {
        limit = 7;
        checkedCount = 1;
        if (element.hasClass("regular_numbers")) {
            limit = 37;
            checkedCount = 8;
        }
    }
    else if (formId === 5 || formId === 6 ) {
        limit = 7;
        checkedCount = 4;
        if (element.hasClass("regular_numbers")) {
            limit = 37;
            checkedCount = 7;
        }
    }
    else if(formId === 7)
    {
        limit = 70;
        checkedCount = 7;
    }
    else if (formId === 8) {
        limit = 70;
        checkedCount = 8;
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