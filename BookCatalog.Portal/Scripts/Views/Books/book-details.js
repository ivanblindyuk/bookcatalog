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
        RankingRange: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1],

        Id: ko.observable(0),
        Title: ko.observable().extend({ required: true }),
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
        if (!me.IsValid()) {
            me.Validate();
            return;
        }

        var mapping = {
            'ignore': ["IsVisible", "RankingRange", "Authors"]
        };

        var model = ko.mapping.toJS(me.VM, mapping);

        $.post(me.saveUrl, model, function () {
            $(document).trigger("details.hide");
        });
    };

    me.Get = function (id) {
        if (me.VM.Id() > 0 && id != me.VM.Id()) {
            Modal.Confirmation.Show(Modal.Messages.BookEditConfirmation, function () {
                getConfirmed(id);
            });
        }
        else {
            getConfirmed(id);
        }
    };

    var getConfirmed = function (id) {
        $.get(me.getUrl + "/" + id, function (result) {
            var mapping = {
                ReleaseDate: {
                    update: function (options) {
                        if (options.data == null) return null;
                        else return moment(options.data).format("DD.MM.YYYY");
                    }
                }
            };

            ko.mapping.fromJS(result, mapping, me.VM);

            if (!me.VM.IsVisible())
                $(document).trigger("details.show");
        });
    };

    me.Delete = function (id) {
        Modal.Confirmation.Show(Modal.Messages.BookDeleteConfirmation, function () {
            deleteConfirmed(id);
        });
    };

    var deleteConfirmed = function (id) {
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

    var initializeValidation = function () {
        me.VMErrors = ko.validation.group(me.VM);
    };

    me.IsValid = function () {
        return me.VMErrors().length === 0;
    };

    me.Validate = function () {
        me.VMErrors.showAllMessages();
    };

    me.Initialize = function () {
        bindEvents();
        initializeValidation();

        ko.applyBindings(me.VM, $("#" + me.formId)[0]);
    };

})(BookDetails);