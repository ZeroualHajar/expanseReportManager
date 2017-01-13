$(document).ready(function () {
    $(".button-add-customer").click(function () {
        $("#get-customer-modal").modal();
    });

    $("#filter-customer-project").keyup(function () {
        $("#customer-modal .modal-body .list-group").each(function (index, element) {
            if ($(element).find(".list-group-item-heading").text().toUpperCase().indexOf($("#filter-customer-project").val().toUpperCase()) == -1) {
                $(element).hide();
            }
            else {
                $(element).show();
            }
        });
    });

    $(".button-add-customer").click(function () {
        var node = $(this).parents(".list-group").clone();
        $(node).find(".button-add-customer").parent().remove();
        $(node).find(".list-group-separator").remove();
        $(node).find(".row-content p").remove();

        $("#button-add-customer").attr("class", "btn btn-fab btn-warning btn-fab-mini");
        $("#button-add-customer i").text("mode_edit");

        $("#Customer_Id").val($(node).attr("data-content"))

        $(".project-customer-place").empty()
        $(".project-customer-place").append(node);
        $("#customer-modal").modal('toggle');
    })


    //pole
    $(".button-add-pole").click(function () {
        $("#get-pole-modal").modal();
    });

    $("#filter-pole-project").keyup(function () {
        $("#pole-modal .modal-body .list-group").each(function (index, element) {
            if ($(element).find(".list-group-item-heading").text().toUpperCase().indexOf($("#filter-pole-project").val().toUpperCase()) == -1) {
                $(element).hide();
            }
            else {
                $(element).show();
            }
        });
    });

    $(".button-add-pole").click(function () {
        var node = $(this).parents(".list-group").clone();
        $(node).find(".button-add-pole").parent().remove();
        $(node).find(".list-group-separator").remove();
        $(node).find(".row-content p").remove();

        $("#button-add-pole").attr("class", "btn btn-fab btn-warning btn-fab-mini");
        $("#button-add-pole i").text("mode_edit");

        $("#Pole_Id").val($(node).attr("data-content"));

        $(".project-pole-place").empty();
        $(".project-pole-place").append(node);
        $("#pole-modal").modal('toggle');
    })
});