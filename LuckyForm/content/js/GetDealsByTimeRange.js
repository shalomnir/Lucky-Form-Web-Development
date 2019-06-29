$("document").ready(
    function () {
        $(".deals_form button").click(
            function () {
                var form = $(this).parents('form:first');
                var startDt = document.getElementById("startDateId").value;
                var endDt = document.getElementById("endDateId").value;

                var d = new Date();

                var month = d.getMonth() + 1;
                var day = d.getDate();

                var output = d.getFullYear() + '/' +
                    (month < 10 ? '0' : '') + month + '/' +
                    (day < 10 ? '0' : '') + day;

                var empty = $(this).parent().find("input").filter(function () {
                    return this.value === "";
                });
                if (empty.length) {
                    alert("All Fields Are Required!")
                    return;
                }
                if ((new Date(startDt).getTime() > new Date(endDt).getTime()) || (new Date(startDt).getTime() > new Date(output))) {
                    alert("Enter valid dates!");
                    return;
                }
                form.submit();
            });


    });