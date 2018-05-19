ko.validation.rules['between'] = {
    validator: function (value, params) {
        //should be required
        if (value === null || value === '' || isNaN(value)) {
            return true;
        }

        var min = params[0];
        var max = params[1];

        return +value >= min && +value <= max;
    },
    message: 'Value must be between {0} and {1}'
};

ko.validation.rules['dateFormat'] = {
    validator: function (value, params) {
        //should be required
        if (value === null || value === '') {
            return true;
        }

        var format = params;
        var date = gj.core.parseDate(value, format);

        if (isNaN(date))
            return false;

        var dateFormat = gj.core.formatDate(date, format);

        return value == dateFormat;
    },
    message: 'Invalid date'
};