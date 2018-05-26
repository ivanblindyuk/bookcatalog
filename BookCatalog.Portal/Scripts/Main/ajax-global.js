(function () {
    $(document)
        .bind("ajaxSend", function () {
            LoadingSpinner.BlockUI();
        })
        .bind("ajaxComplete", function () {
            LoadingSpinner.UnblockUI();
        })
        .bind("ajaxError", function (e, details) {
            Alert.Error.Show(details.responseJSON);
        });
})();
