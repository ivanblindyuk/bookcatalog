var Config = Config || {};

(function (me) {
    me.KnownValues = {
        DateFormat: "dd.mm.yyyy"
    };

    me.Plugins = {};

    me.Layout = function () {
        me.Plugins.DatePicker.Init();
        me.Plugins.DatePicker.EmbedValidationMessage();
    };
})(Config);

(function (me) {
    me.DatePicker = {
        Init: function () {
            $('[data-role="datepicker"]').datepicker({
                uiLibrary: 'bootstrap4',
                iconsLibrary: 'fontawesome',
                format: Config.KnownValues.DateFormat
            });
        },
        EmbedValidationMessage: function () {
            var wrapper = $('[data-role="datepicker"]').parent();
            var messageElement = $(wrapper).siblings(".invalid-feedback");

            wrapper.append(messageElement);
        }
    };
})(Config.Plugins);