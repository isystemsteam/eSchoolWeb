var appService = {
    editClass: '/admin/EditClass',
    viewClass: '/admin/ViewClass',
    viewSection: '/admin/ViewSection',
    editSection: '/admin/EditSection',
    editRole: '/admin/EditRole',
    viewRole: '/admin/ViewRole',
    editPrivilege: '/admin/EditPrivileges',
    rolesPrivilegeForModule: '/admin/RolePrivilegesForModule',
    editClassSection: "/admin/EditClassSection",
    viewClassSections: "/admin/ViewClassSections",
    saveClassSections: "/admin/SaveClassSections",
    SaveRolesPrivileges: "/admin/SaveRolesPrivileges",
    editAcademicYear: "/admin/EditAcademicYear",
    getAcademicYears: "/admin/ViewAcademicYear",
    searchApplications: "/application/SearchApplications",
    viewSubject: "/admin/ViewSubject",
    editSubject:"/admin/EditSubject",
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