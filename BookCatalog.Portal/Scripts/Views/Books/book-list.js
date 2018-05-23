var BookList = BookList || {};

(function (me) {
    me.btnAddId = "btnAdd";
    me.tblId = "tblBooks";
    me.btnEditClass = "btn-edit";
    me.btnDeleteClass = "btn-delete";

    me.getAllUrl = "/Books/GetAll";
    me.editAuthorUrl = "/Authors/Edit";

    var grid = null;

    me.ShowAddButton = function () {
        $("#" + me.btnAddId).show();
    };

    me.HideAddButton = function () {
        $("#" + me.btnAddId).hide();
    };
    
    var bindEvents = function () {
        $("#" + me.btnAddId).click(function () {
            $(document).trigger("details.show");
        });

        $(document).on("details.hide", function () {
            me.ShowAddButton();
        });

        $(document).on("details.show", function () {
            me.HideAddButton();
        });

        $(document).on("details.saved details.deleted", function () {
            if (grid != null) DataGrid.Refresh(grid);
        });
    };

    var bindGridEvents = function () {
        $("." + me.btnEditClass).click(function (e) {
            var id = $(e.currentTarget).attr("key");
            $(document).trigger("details.get", id);
        });

        $("." + me.btnDeleteClass).click(function (e) {
            var id = $(e.currentTarget).attr("key");
            $(document).trigger("details.delete", id);
        });
    };

    var initializeDatatable = function () {
        grid = DataGrid.Initialize(me.tblId,
        {
            processing: true,
            serverSide: true,
            ajax: {
                url: me.getAllUrl,
                dataSrc: 'data',
                type: "POST"
            },
            columns: [
                { "data": "Title", "title": "Title" },
                { "data": "ReleaseDate", "title": "Release Date" },
                { "data": "Ranking", "title": "Ranking" },
                { "data": "PageCount", "title": "Pages" },
                { "data": "Authors", "title": "Authors", "orderable": false },
                { "data": "Id", "title": "", "orderable": false }
            ],
            columnDefs: [
            {
                "targets": 1,
                "render": DataGrid.Renders.Date
            },
            {
                "targets": 4,
                "render": function (data, type, row) {
                    if (data == null) return '';

                    var authors = [];

                    for (var i = 0; i < data.length; i++) {
                        var firstName = '', lastName = '';

                        if(data[i].FirstName != null) firstName = data[i].FirstName + ' ';
                        if(data[i].LastName != null) lastName = data[i].LastName;

                        var text = firstName + lastName;

                        authors.push('<a href="' + me.editAuthorUrl + '/' + data[i].Id + '">' + text + '</a>');
                    }

                    return authors.join(', ');
                }
            },
            {
                "targets": 5,
                "render": DataGrid.Renders.ComplexButtons,
                "parameters": {
                    "renders": [DataGrid.Renders.EditButton, DataGrid.Renders.DeleteButton]
                },
                "width": "9%"
            },
            {
                "targets": "_all",
                "className": "align-middle"
            }],
            drawCallback: function (settings, json) {
                bindGridEvents();
            }
        });
    };

    me.Initialize = function () {
        initializeDatatable();
        bindEvents();
    };

})(BookList);