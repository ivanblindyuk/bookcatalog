var AuthorList = AuthorList || {};

(function (me) {
    me.btnDeleteClass = "btn-delete";

    me.deleteUrl = "/Authors/Delete";

    me.Delete = function (id) {
        Modal.Confirmation.Show(Modal.Messages.AuthorDeleteConfirmation, function () {
            deleteConfirmed(id);
        });
    };

    var deleteConfirmed = function (id) {
        $.post(me.deleteUrl, { id: id }, function () {
            location.reload();
        });
    };

    var bindEvents = function () {
        $("." + me.btnDeleteClass).click(function (e) {
            var id = $(e.currentTarget).attr("key");
            me.Delete(id);
        });
    };

    me.Initialize = function () {
        bindEvents();
    };
})(AuthorList);