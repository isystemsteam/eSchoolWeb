var appService = {
    editClass: 'EditClass',
    viewClass: 'ViewClass',
    viewSection: 'ViewSection',
    editSection: 'EditSection',
    editRole: 'EditRole',
    viewRole: 'ViewRole',
    editPrivilege: 'EditPrivileges',
    rolesPrivilegeForModule: 'PrivilegesForModule',
    editClassSection: "EditClassSection",
    viewClassSections: "ViewClassSections",
    saveClassSections: "SaveClassSections",
    SaveRolesPrivileges: "SaveRolesPrivileges",
    editAcademicYear: "EditAcademicYear",
    getAcademicYears: "ViewAcademicYear",
    searchApplications: "application/SearchApplications",
    init: function (keyName) {
        return applicationRootUrl + appService[keyName];
    }
};

//For application services
var applicationService = {
    searchApplication: "application/SearchApplications",
    get: function (keyName) {
        return applicationRootUrl + this[keyName];
    }
};

//templates ids
var templates = {
    rolesPrivilege: 'tempRolesPrivilege'
};

var ajaxParam = function (name, value) {
    this.name = name;
    this.value = value;
};