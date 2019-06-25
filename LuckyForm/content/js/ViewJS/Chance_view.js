$("document").ready(
    function () {
       
        $(".card_img").addClass("disabled");
        $(".card_img").title = "You can not edit in the view"

        $("img.card_img").removeClass("scale_on_hover");

        $(".submit_tables").css("display", "none");
        $(".submit_tables").title = "You can not edit in the view"       
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
    $(".chance_table").find(".card_type").each(function () {
        $(this).find("input").each(function () {            
            if (((res[index]).indexOf($(this).val()) > -1)) {
                $(this).next().addClass("clicked");
            }              
        });
        index++;
    });     
}
