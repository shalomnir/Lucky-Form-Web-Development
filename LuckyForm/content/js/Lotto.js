$("document").ready(
    function () {
        var counter
        $(".number").click(
            function () {
                var limit = 1;
                if ($(this).parent().hasClass("regular_numbers"))
                {
                    limit = 6;
                }                
                if (countChosenNumbers($(this).parent()) >= limit && !$(this).hasClass("clicked"))
                {

                }
                else
                {
                    if ($(this).hasClass("clicked"))
                    {
                        $(this).removeClass("clicked");
                        $(this).children().attr('checked', false)
                    }
                    
                    else
                    {
                        $(this).addClass("clicked");
                        $(this).children().attr('checked', true)
                    }
                }
                
                    
            });
    });

function countChosenNumbers(element)
{
    var count = 0;
    element.children('.number').each(function () {
        if ($(this).hasClass("clicked")) {
            count++;
        }// "this" is the current element in the loop
    });
   
    return count;
}