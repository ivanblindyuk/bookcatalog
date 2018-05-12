var BookDetails = BookDetails || {};

(function (me) {
    me.formId = "frmBookDetails";
    me.btnSaveId = "btnSave";
    me.btnCancelId = "btnCancel";

    me.saveUrl = "/Books/Save";
    me.deleteUrl = "/Books/Delete";
    me.getUrl = "/Books/Get";

    me.VM = {
        IsVisible: ko.observable(false),
        Id: ko.observable(0),
        Title: ko.observable(""),
        ReleaseDate: ko.observable(null),
        Ranking: ko.observable(null),
        PageCount: ko.observable(null),
        Authors: ko.observableArray([])
    };

    me.EmptyfyModel = function () {
        me.VM.Id(0);
        me.VM.Title("");
        me.VM.ReleaseDate(null);
        me.VM.Ranking(null);
        me.VM.PageCount(null);
        me.VM.Authors([]);
    };

    me.Show = function () {
        me.VM.IsVisible(true);
    };

    me.Hide = function () {
        me.VM.IsVisible(false);
        me.EmptyfyModel();
    };

    me.Save = function () {
        var mapping = {
            'ignore': ["IsVisible", "Authors"]
        };

        var model = ko.mapping.toJS(me.VM, mapping);

        $.post(me.saveUrl, model, function () {
            $(document).trigger("details.hide");
        });
    };

    me.Get = function (id) {
        if (me.VM.Id() > 0 && id != me.VM.Id()) {

        }

        $.get(me.getUrl + "/" + id, function (result) {
            ko.mapping.fromJS(result, {}, me.VM);

            if (!me.VM.IsVisible())
                $(document).trigger("details.show");
        });
    };

    me.Delete = function (id) {
        $.post(me.deleteUrl, { id: id }, function () {
            if (id == me.VM.Id()) {
                if (me.VM.IsVisible())
                    $(document).trigger("details.hide");
            }
        });
    };

    var bindEvents = function () {
        $("#" + me.btnCancelId).click(function () {
            $(document).trigger("details.hide");
        });

        $("#" + me.btnSaveId).click(function () {
            me.Save();
        });

        $(document).on("details.hide", function () {
            me.Hide();
        });

        $(document).on("details.show", function () {
            me.Show();
        });

        $(document).on("details.get", function (e, id) {
            me.Get(id);
        });

        $(document).on("details.delete", function (e, id) {
            me.Delete(id);
        });
    };

    me.Initialize = function () {
        bindEvents();

        ko.applyBindings(me.VM, $("#" + me.formId)[0]);
    };

})(BookDetails);