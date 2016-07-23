$(document).ready(function () {

});
var applicationSearch = {
    init: function () {

    },
    handleException: function (xhr, message, error) {
    },
    searchApplication: function () {
        debugger
        var searchRequest = {
            ApplicationId: $("#txtApplicationId").val() != null && $("#txtApplicationId").val() != '' ? $("#txtApplicationId").val() : null,
            AppliedDate: $("#txtAppliedDate").val() != null && $("#txtAppliedDate").val() != '' ? $("#txtAppliedDate").val() : null,
            ClassId: $("#ddlClass").val() != '0' ? $("#ddlClass").val() : null,
            ApplicationStatus: $("#ddlApplicationStatus").val() != '0' ? $("#ddlApplicationStatus").val() : null,
            FirstName: $("#txtFirstName").val() != '' ? $("#txtFirstName").val() : null,
            LastName: $("#txtLastName").val() != '' ? $("#txtLastName").val() : null,
        };

        var rows = [
                { Cells: [{ Value: "Pariventhan" }, { Value: "31" }] },
                { Cells: [{ Value: "Poonguzhali" }, { Value: "23" }] },
                { Cells: [{ Value: "Pagalavan" }, { Value: "0.9" }] }
        ];
        $("#divSearchResult").GridView({
            data: { Columns: [{ Name: "Name" }, { Name: "Age" }], Rows: rows },
            postData: searchRequest,
            templateName: "gridViewTemplate",
            dataType: "application\json",
            uri: "ApplicationSearch",
            isLocalData: false
        });
    }
};