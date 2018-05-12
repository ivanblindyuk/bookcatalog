(function () {
    $(document)
        .bind("ajaxSend", function () {
            LoadingSpinner.BlockUI();
        })
        .bind("ajaxComplete", function () {
            LoadingSpinner.UnblockUI();
    });
})();
