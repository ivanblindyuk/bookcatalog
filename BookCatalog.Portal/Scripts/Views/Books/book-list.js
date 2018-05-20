﻿var BookList = BookList || {};

(function (me) {
    me.btnAddId = "btnAdd";
    me.tblId = "tblBooks";
    me.btnEditClass = "btn-edit";
    me.btnDeleteClass = "btn-delete";

    me.getAllUrl = "/Books/GetAll";

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
            ajax: {
                url: me.getAllUrl,
                dataSrc: ''
            },
            columns: [
                { "data": "Title" },
                { "data": "ReleaseDate" },
                { "data": "Ranking" },
                { "data": "PageCount" },
                { "data": "Authors" },
                { "data": "Id" }
            ],
            columnDefs: [
            {
                "targets": 1,
                "render": DataGrid.Renders.Date
            },
            {
                "targets": 5,
                "render": DataGrid.Renders.ComplexButtons,
                "parameters": {
                    "renders": [DataGrid.Renders.EditButton, DataGrid.Renders.DeleteButton]
                },
                "sorting": false,
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