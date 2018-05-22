var AuthorList = AuthorList || {};

(function (me) {
    me.tblId = "tblAuthors";
    me.btnDeleteClass = "btn-delete";

    me.getAllUrl = "/Authors/GetAll";
    me.editUrl = "/Authors/Edit";
    me.deleteUrl = "/Authors/Delete";

    var grid = null;

    me.Delete = function (id) {
        Modal.Confirmation.Show(Modal.Messages.AuthorDeleteConfirmation, function () {
            deleteConfirmed(id);
        });
    };

    var deleteConfirmed = function (id) {
        $.post(me.deleteUrl, { id: id }, function () {
            if (grid != null) DataGrid.Refresh(grid);
        });
    };
    
    var bindGridEvents = function () {
        $("." + me.btnDeleteClass).click(function (e) {
            var id = $(e.currentTarget).attr("key");
            me.Delete(id);
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
                { "data": "FirstName", "title": "First Name" },
                { "data": "LastName", "title": "Last Name" },
                { "data": "BookCount", "title": "Books", "orderable": false },
                { "data": "Id", "title": "", "orderable": false }
            ],
            columnDefs: [
            {
                "targets": 3,
                "render": DataGrid.Renders.ComplexButtons,
                "parameters": {
                    "renders": [DataGrid.Renders.EditAction, DataGrid.Renders.DeleteButton],
                    "editUrl": me.editUrl
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
    };
})(AuthorList);