var AuthorDetails = AuthorDetails || {};

(function (me) {
    me.formId = "frmAuthorDetails";
    me.btnSaveId = "btnSave";
    me.btnCancelId = "btnCancel";

    me.saveUrl = "/Authors/Save";
    me.listUrl = "/Authors/List";

    me.validator = null;

    me.VM = {
        Id: ko.observable(0),
        FirstName: ko.observable(),
        LastName: ko.observable()
    };

    me.EmptyfyModel = function () {
        me.VM.Id(0);
        me.VM.FirstName("");
        me.VM.LastName("");

        me.validator.HideMessages();
    };

    me.Save = function () {
        if (!me.validator.IsValid()) {
            return;
        }
        
        var model = ko.mapping.toJS(me.VM, {});

        $.post(me.saveUrl, model, function () {
            $("#" + me.btnCancelId).trigger("click");
        });
    };

    me.Cancel = function () {
        location.assign(me.listUrl);
    };

    me.Fill = function (json) {
        ko.mapping.fromJS(json, {}, me.VM);
    };
    
    var bindEvents = function () {
        $("#" + me.btnCancelId).click(function () {
            me.Cancel();
        });

        $("#" + me.btnSaveId).click(function () {
            me.Save();
        });
    };

    var initializeValidation = function () {
        me.validator = new modelValidation(me.VM);

        me.validator.Rules.Required(me.VM.FirstName, "First Name is required");
        me.validator.Rules.Required(me.VM.LastName, "Last Name is required");
    };

    me.Initialize = function () {
        bindEvents();
        initializeValidation();

        ko.applyBindings(me.VM, $("#" + me.formId)[0]);
    };
})(AuthorDetails);