var Modal = Modal || {};

(function (me) {
    me.Messages = {};
    me.Confirmation = {};

    (function (self) {
        self.Show = function (text, onconfirm) {
            $('#modalConfirmation').off('show.bs.modal').on('show.bs.modal', function (event) {
                var modal = $(this);
                modal.find('.modal-body').text(text);

                modal.find("[name='btnOk']").off("click").on("click", function (event) {
                    onconfirm();
                });
            });

            $('#modalConfirmation').modal('show');
        };

        self.Hide = function () {
            $('#modalConfirmation').modal('hide');
        };
    })(me.Confirmation);

    (function (self) {
        self.BookDeleteConfirmation = "Are you sure about deleting this book?";
        self.BookEditConfirmation = "Data lost may occur. Are you sure?";
    })(me.Messages);
})(Modal);