var formType = "0";
var formId = "0"
$("document").ready(
    function () {
      

        $(".number").addClass("disabled");
        $(".number").title = "You can not edit in the view"

        $(".trash_icon").addClass("disabled");
        $(".trash_icon").title = "You can not edit in the view"

        $(".quick_pick_button button").addClass("disabled");
        $(".quick_pick_button button").title = "You can not edit in the view"
      
        $(".submit_tables").css("display", "none");

        
        $.ajax({
            url: '/Order/GetBetsById?detId=' + $("#form_wrapper").data('detid'),
            dataType: "text",
            success: function (data) {
                
                PaintNumbers(data);
            }
        });
       
        
    });
function PaintNumbers(str) {
    var res = str.split("#");
    var index = 0;
    var reg = "";
    var strong = "";
    $(".inner_table").each(function () {
        if (index > res.length - 1) {
            return false;
        }
        reg = res[index].split("*")[0];
        
        $(this).find(".regular_numbers").find('input').each(function () {           
            if ((reg.split(",")).indexOf(this.value) != -1) {
                
                $(this).parent().addClass("clicked");
            }
        });
        strong = res[index].split("*")[1];
        $(this).find(".strong_numbers").find('input').each(function () {

            if (strong.indexOf(this.value) != -1) {
                $(this).parent().addClass("clicked");
            }
        });        
        index++;
    });
}
