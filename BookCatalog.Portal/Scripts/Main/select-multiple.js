function selectMultiple(elementId) {
    var me = this;

    me.Id = elementId;
    me.Element = $("#" + me.Id)[0];

    me.Initialize = function (options, ajaxOptions) {
        if (me.Element.selectize) me.Element.selectize.destroy();

        var defaults = Config.Plugins.Multiselect.Defaults;
        var opts = $.extend(options, defaults);

        if (ajaxOptions) {
            var loadOpts = me.LoadCallback(ajaxOptions);
            opts = $.extend(opts, loadOpts);
        }

        $(me.Element).selectize(opts);
    };

    me.Refresh = function (possibleOptions, selectedItems) {
        me.Element.selectize.clear();
        me.Element.selectize.addOption(possibleOptions);
        me.Element.selectize.addItems(selectedItems);
    };

    me.LoadCallback = function (ajaxOptions) {
        return {
            load: function (query, callback) {
                if (!query.length) return callback();

                var data = {};
                data[ajaxOptions.query] = query;

                $.ajax({
                    url: ajaxOptions.url,
                    type: 'POST',
                    data: data,
                    success: function (res) {
                        callback(res);
                    }
                });
            }
        }
    };

    return {
        Id: me.Id,
        Initialize: me.Initialize,
        Refresh: me.Refresh
    };
};