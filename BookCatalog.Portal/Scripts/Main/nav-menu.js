var NavMenu = NavMenu || {};

(function (me) {
    me.ITEMS = {
        Books: 1,
        Authors: 2
    };

    me.VM = {
        Active: ko.observable()
    };

    me.Activate = function (itemId) {
        me.VM.Active(itemId);
    };

    me.Initialize = function () {
        ko.applyBindings(me.VM, $("nav")[0]);
    };
})(NavMenu);