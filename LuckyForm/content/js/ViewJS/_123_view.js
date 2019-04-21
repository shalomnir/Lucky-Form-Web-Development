$("document").ready(
    function () {
        $(".number").addClass("disabled");
        $(".number").title = "You can not edit in the view"

        $(".trash_icon").addClass("disabled");
        $(".trash_icon").title = "You can not edit in the view"

        $(".quick_pick_button").addClass("disabled");
        $(".quick_pick_button").title = "You can not edit in the view"

        $(".submit_tables").css("display", "none");

    });
