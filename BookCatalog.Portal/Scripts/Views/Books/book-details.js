var BookDetails = BookDetails || {};

(function (me) {
    me.formId = "frmBookDetails";
    me.authorsSelectId = "drpAuthors";
    me.btnSaveId = "btnSave";
    me.btnCancelId = "btnCancel";

    me.saveUrl = "/Books/Save";
    me.deleteUrl = "/Books/Delete";
    me.getUrl = "/Books/Get";
    me.searchAuthorsUrl = "/Authors/Search";

    me.validator = null;
    me.multiselect = null;

    me.VM = {
        IsVisible: ko.observable(false),
        RankingRange: [10, 9, 8, 7, 6, 5, 4, 3, 2, 1],
        SelectedAuthors: ko.observableArray([]),

        Id: ko.observable(0),
        Title: ko.observable(),
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
        me.VM.SelectedAuthors([]);

        me.validator.HideMessages();
    };

    me.Show = function () {
        me.VM.IsVisible(true);
    };

    me.Hide = function () {
        me.VM.IsVisible(false);
        me.EmptyfyModel();
    };

    me.Focus = function () {
        $('html, body').animate({
            scrollTop: 0
        }, 500);
    };

    me.Save = function () {
        if (!me.validator.IsValid()) {
            return;
        }

        var mapping = {
            'ignore': ["IsVisible", "RankingRange", "SelectedAuthors"]
        };

        var model = ko.mapping.toJS(me.VM, mapping);

        var selectedAuthors = me.VM.SelectedAuthors();
        model.Authors = selectedToAuthors(selectedAuthors);

        $.post(me.saveUrl, model, function () {
            $(document).trigger("details.hide");
            $(document).trigger("details.saved");
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
                        else {
                            return Config.Convert.Date.JsonToString(options.data);
                        }
                    }
                }
            };

            ko.mapping.fromJS(result, mapping, me.VM);

            var selectedAuthors = authorsToSelected(result.Authors);
            me.VM.SelectedAuthors(selectedAuthors);

            me.multiselect.Refresh(result.Authors, selectedAuthors);

            if (!me.VM.IsVisible())
                $(document).trigger("details.show");

            me.Focus();
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

            $(document).trigger("details.deleted");
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
        me.validator = new modelValidation(me.VM);

        me.validator.Rules.Required(me.VM.Title, "Book title is required");
        me.validator.Rules.Date(me.VM.ReleaseDate);
        me.validator.Rules.Digit(me.VM.PageCount, "Invalid number");
        me.validator.Rules.Between(me.VM.PageCount, 1, 9999);
    };

    var initializeMultiselect = function () {
        me.multiselect = new selectMultiple(me.authorsSelectId);

        me.multiselect.Initialize({
            valueField: 'Id',
            render: {
                option: function (item, escape) {
                    return '<div><span>' + escape(item.FirstName) + ' ' + escape(item.LastName) + '</span></div>';
                },
                item: function (item, escape) {
                    return '<div><span>' + escape(item.FirstName) + ' ' + escape(item.LastName) + '</span></div>';
                },
            }            
        },
        {
            url: me.searchAuthorsUrl,
            query: 'Name'
        });
    };

    var authorsToSelected = function (authors) {
        return $.map(authors, function (author) {
            return author.Id;
        });
    };

    var selectedToAuthors = function (selected) {
        return $.map(selected, function (item) {
            return { Id: item };
        });
    };

    me.Initialize = function () {
        bindEvents();
        initializeValidation();
        initializeMultiselect();

        ko.applyBindings(me.VM, $("#" + me.formId)[0]);
    };

})(BookDetails);