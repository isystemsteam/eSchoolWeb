$(document).ready(function () {
    internalUser.loadForm(ADMINFORMS.INTERNAL_USER);
});

var internalUser = {
    loadForm: function (formName) {
        var _beforeCallBack = function () {

        };

        var _successCallback = function (result) {
            if (result != null && result.Instance != null && result.Instance != '') {
                jQuery.fn.appCommon.route.redirect("application/success/" + result.Instance);
            }
        };

        jQuery.fn.appCommon.ajax.bind(formName, _beforeCallBack, _successCallback, null, null, null);
    },
    saveInternalUser: function () {
        if (jQuery.fn.Validation.validateForm(ADMINFORMS.INTERNAL_USER)) {
            $("#" + ADMINFORMS.INTERNAL_USER).submit();
        }
    },
    reset: function () {

    }
};