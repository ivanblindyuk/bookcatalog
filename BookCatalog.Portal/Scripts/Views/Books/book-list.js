var BookList = BookList || {};

(function (me) {
    me.btnAddId = "btnAdd";
    me.btnEditClass = "btn-edit";
    me.btnDeleteClass = "btn-delete";

    me.ShowAddButton = function () {
        $("#" + me.btnAddId).show();
    };

    me.HideAddButton = function () {
        $("#" + me.btnAddId).hide();
    };

    var bindEvents = function () {
        $("#" + me.btnAddId).click(function () {
            $(document).trigger("details.show");
        });

        $("." + me.btnEditClass).click(function (e) {
            var id = $(e.currentTarget).attr("key");
            $(document).trigger("details.get", id);
        });

        $("." + me.btnDeleteClass).click(function (e) {
            var id = $(e.currentTarget).attr("key");
            $(document).trigger("details.delete", id);
        });

        $(document).on("details.hide", function () {
            me.ShowAddButton();
        });

        $(document).on("details.show", function () {
            me.HideAddButton();
        });
    };

    me.Initialize = function () {
        bindEvents();
    };

})(BookList);