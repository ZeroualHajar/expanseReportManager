$(document).ready(function () {
    $(".button-add-manager").click(function () {
        $("#get-manager-modal").modal();
    });

    $("#filter-manager-pole").keyup(function () {
        $("#manager-modal .modal-body .list-group").each(function (index, element) {
            if ($(element).find(".list-group-item-heading").text().toUpperCase().indexOf($("#filter-manager-pole").val().toUpperCase()) == -1) {
                $(element).hide();
            }
            else {
                $(element).show();
            }
        });
    });

    $(".button-add-manager").click(function () {
        var node = $(this).parents(".list-group").clone();
        $(node).find(".button-add-manager").parent().remove();
        $(node).find(".list-group-separator").remove();
        $(node).find(".row-content p").remove();

        $("#button-add-manager").attr("class", "btn btn-fab btn-warning btn-fab-mini");
        $("#button-add-manager i").text("mode_edit");

        $("#ManagerId").val($(node).attr("data-content"))

        $(".pole-manager-place").empty()
        $(".pole-manager-place").append(node);
        $("#manager-modal").modal('toggle');
    })
});