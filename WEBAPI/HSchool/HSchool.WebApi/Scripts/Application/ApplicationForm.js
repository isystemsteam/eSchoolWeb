$(document).ready(function () {
    applicationForm.init();
});

//For application form
var applicationForm = {
    formName: "formOnlineApplication",
    init: function () {
        this.loadForm(this.formName);
    },
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
    saveApplication: function () {
        if (jQuery.fn.Validation.validateForm(this.formName)) {
            $("#" + this.formName).submit();
        }
    }
};