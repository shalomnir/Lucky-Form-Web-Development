var position = 1;
$("document").ready(
    function () {
        $(".next").click(
            function () {
                position++;
                update();
            });       
    });
function update() {

    $("#sliderContainer").first().css('margin-left', '-=300px');
}