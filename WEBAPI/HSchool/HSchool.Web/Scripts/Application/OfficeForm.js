$(document).ready(function () {
    officeForm.init();
});

var officeForm = {
    formName: "formOfficeUse",
    init: function () {
        this.loadForm(this.formName);
    },
    loadForm: function (formName) {
        var _beforeCallBack = function () {

        };

        var _successCallback = function (result) {
            if (result != null && result.Instance != null && result.Instance != '') {
                jQuery.fn.appCommon.UI.displayMessage(result.Message, null);
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