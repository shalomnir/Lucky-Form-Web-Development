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
    var innnerIndex = 0;
    $(".table").each(function () {
        if (index > res.length - 1) {
            return false;
        }
        $(this).find(".nums_row").each(function () {
            $(this).find("input").each(function () {
                //alert(res[index].split(",")[innnerIndex] + "\n" + this.value);
                if ((res[index].split(",")[innnerIndex]).indexOf(this.value) != -1) {
                    $(this).parent().addClass("clicked");
                }
            });
            innnerIndex++;
        });
        index++;
        innnerIndex = 0;
    });
}
