$("document").ready(
    function () {
       
        $(".card_img").addClass("disabled");
        $(".card_img").title = "You can not edit in the view"

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
    var innnerIndex = 0;
    $(".table").each(function () {
        if (index > res.length - 1) {
            return false;
        }
        $(this).find(".card_type").each(function () {
            $(this).find("input").each(function () {
                //alert(res[index].split(",")[innnerIndex] + "\n" + this.value);
                alert(this.value);
                if ((res[index].split(",")[innnerIndex]).indexOf(this.value) !== -1) {
                    $(this).next().addClass("clicked");
                }
            });
            innnerIndex++;
        });
        index++;
        innnerIndex = 0;
    });
}
