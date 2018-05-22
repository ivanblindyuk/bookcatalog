var DataGrid = DataGrid || {};

(function (me) {
    me.Renders = {};

    me.Refresh = function (grid) {
        grid.ajax.reload();
    };

    me.Initialize = function (id, options) {
        return $('#' + id).DataTable(options);
    };
})(DataGrid);

(function (me) {
    me.Date = function (data, type, row) {
        if (data == null) return '';
        else return Config.Convert.Date.JsonToString(data);
    };

    me.DeleteButton = function (data, type, row) {
        return '<button class="btn btn-outline-danger btn-delete" key="' + data + '"><i class="fa-trash fa-fw fas"></i></button>';
    };

    me.EditButton = function (data, type, row) {
        return '<button class="btn btn-outline-warning btn-edit" key="' + data + '"><i class="fa-pencil-alt fa-fw fas"></i></button>';
    };

    me.EditAction = function (data, type, row, meta) {
        if (!meta) return '';

        var parameters = getParameters(meta.settings.oInit.columnDefs, meta.col);
        if (parameters == null) return '';

        var url = parameters.editUrl + "/" + data;

        return '<a class="btn btn-outline-warning btn-edit" href="' + url + '" key="' + data + '"><i class="fa-pencil-alt fa-fw fas"></i></a>';
    };

    me.Complex = function (data, type, row, meta) {
        if (!meta) return '';

        var parameters = getParameters(meta.settings.oInit.columnDefs, meta.col);
        if (parameters == null) return '';

        var renders = parameters.renders;

        var template = '';

        for (var i = 0; i < renders.length; i++) {
            template += renders[i](data, type, row, meta);
        }

        return template;
    };

    me.ComplexButtons = function (data, type, row, meta) {
        var template = '<div class="btn-toolbar">';

        template += me.Complex(data, type, row, meta);
        template += "</div>";

        return template;

    };

    var getParameters = function (colDefs, colIndex) {
        var targetDef = $.grep(colDefs, function (item, index) {
            var targets = item.targets;

            if ($.isArray(targets)) {
                return $.inArray(colIndex, colDefs) != -1 && item.parameters;
            }
            else {
                return targets == colIndex && item.parameters;
            }
        });

        if (targetDef.length > 0) return targetDef[0].parameters;
        else return null;
    };
})(DataGrid.Renders);