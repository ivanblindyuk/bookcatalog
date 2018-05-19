function modelValidation(vm) {
    var me = this;

    me.VM = vm;
    me.Errors = ko.validation.group(me.VM);

    me.IsValid = function () {
        me.Errors.showAllMessages();
        return me.Errors().length === 0;
    };

    me.HideMessages = function () {
        me.Errors.showAllMessages(false);
    };

    me.Rules = {
        Required: function (property, message) {
            me.InitializeRule('required', property, { params: true, message: message });
        },
        Date: function (property, message) {            
            me.InitializeRule('dateFormat', property, { params: Config.KnownValues.DateFormat, message: message });
        },
        Digit: function (property, message) {
            me.InitializeRule('digit', property, { params: true, message: message });
        },
        Min: function (property, minValue, message) {
            me.InitializeRule('min', property, { params: minValue, message: message });
        },
        Max: function (property, maxValue, message) {
            me.InitializeRule('max', property, { params: maxValue, message: message });
        },
        Between: function (property, minValue, maxValue, message) {
            me.InitializeRule('between', property, { params: [minValue, maxValue], message: message });
        }
    };

    me.InitializeRule = function (name, property, options) {
        var rule = {};

        if (options.message) {
            rule[name] = options;
        }
        else {
            rule[name] = options.params;
        }

        property.extend(rule);
    };

    return {
        IsValid: me.IsValid,
        HideMessages: me.HideMessages,
        Rules: me.Rules
    };
};