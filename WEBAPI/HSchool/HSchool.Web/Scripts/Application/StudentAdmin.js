$(document).ready(function () {

});
var studentAdmin = {
    init: function () {

    },
    handleException: function (xhr, message, error) {
    },
    searchStudents: function () {
        debugger
        var searchRequest = {
            RollNumber: $("#txtRollNumber").val() != null && $("#txtRollNumber").val() != '' ? $("#txtRollNumber").val() : null,
            DateOfBirth: $("#txtDateOfBirth").val() != null && $("#txtDateOfBirth").val() != '' ? $("#txtDateOfBirth").val() : null,
            ClassId: $("#ddlClass").val() != '0' ? $("#ddlClass").val() : null,
            SectionId: $("#ddlSections").val() != '0' ? $("#ddlSections").val() : null,
            Gender: $("#ddlGender").val() != '0' ? $("#ddlGender").val() : null,
            FirstName: $("#txtFirstName").val() != '' ? $("#txtFirstName").val() : null,
            LastName: $("#txtLastName").val() != '' ? $("#txtLastName").val() : null,
        };

        $("#divSearchResult").GridView({
            data: { Columns: [{ Name: "Name" }, { Name: "Age" }], Rows: rows },
            postData: searchRequest,
            templateName: "gridViewTemplate",
            dataType: "json",
            url: "/Student/SearchStudents",
            isLocalData: false
        });
    }
};