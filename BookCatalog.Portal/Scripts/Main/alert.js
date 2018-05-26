var Alert = Alert || {};

(function (me) {
    me.Error = {};

    (function (self) {
        self.Show = function (error) {
            var markup = $("#alertError").html();
            var alert = $(markup);

            var p = $("<p/>",
                { "class": "mb-0" });

            var hr = $("<hr/>",
                { "class": "my-1" });

            if ($.isArray(error)) {
                for (var i = 0; i < error.length; i++) {
                    var pClone = p.clone();
                    pClone.text(error[i]);

                    alert.append(pClone);

                    if (i != error.length - 1) {
                        hrClone = hr.clone();
                        alert.append(hrClone);
                    }
                }
            }
            else {
                p.text(error);
                alert.append(p);
            }

            $("body").append(alert);
        };

        self.Hide = function () {
            $(".alert").alert("close");
        };
    })(me.Error);
})(Alert);