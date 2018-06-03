var Config = Config || {};

(function (me) {
    me.KnownValues = {
        DateFormat: "dd.mm.yyyy"
    };

    me.Plugins = {};
    me.Convert = {};

    me.Layout = function () {
        me.Plugins.DatePicker.Init();
        me.Plugins.DatePicker.EmbedValidationMessage();

        //me.Plugins.Multiselect.Init();
    };
})(Config);

(function (me) {
    me.DatePicker = {
        Init: function () {
            $('[dom-role="datepicker"]').datepicker({
                uiLibrary: 'bootstrap4',
                iconsLibrary: 'fontawesome',
                format: Config.KnownValues.DateFormat
            });
        },
        EmbedValidationMessage: function () {
            var wrapper = $('[dom-role="datepicker"]').parent();
            var messageElement = $(wrapper).siblings(".invalid-feedback");

            wrapper.append(messageElement);
        }
    };

    me.Multiselect = {
        Init: function () {
            $('[dom-role="multiselect"]').selectize(me.Multiselect.Defaults);
        },
        Defaults: {
            hideSelected: true
        }
    };
})(Config.Plugins);

(function (me) {
    me.Date = {
        JsonToString: function (data) {
            var date = gj.core.parseDate(data);
            return gj.core.formatDate(date, Config.KnownValues.DateFormat);
        }
    };
})(Config.Convert);