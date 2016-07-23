$(document).ready(function () {

});
var applicationSearch = {
    init: function () {

    },
    handleException:function(xhr,message,error){
    },
    searchApplication: function () {
        var searchRequest = {
            ApplicationId: $("#txtApplicationId").val() != null && $("#txtApplicationId").val() != '' ? $("#txtApplicationId").val() : null,
            AppliedDate: $("#txtAppliedDate").val() != null && $("#txtAppliedDate").val() != '' ? $("#txtAppliedDate").val() : null,
            ClassId: $("#ddlClass").val() != '0' ? $("#ddlClass").val() : null,
            ApplicationStatus: $("#ddlApplicationStatus").val() != '0' ? $("#ddlApplicationStatus").val() : null,
            FirstName: $("#txtFirstName").val() != '' ? $("#txtFirstName").val() : null,
            LastName: $("#txtLastName").val() != '' ? $("#txtLastName").val() : null,
        };

        var _successCallBack = function (result) {
        };

        jQuery.fn.appCommon.ajax.get(appService.init(),searchRequest,_successCallBack,applicationSearch.handleException)
    }
};