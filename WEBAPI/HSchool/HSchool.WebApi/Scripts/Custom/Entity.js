var appService = {
    editClass: 'EditClass',
    viewClass: 'ViewClass',
    viewSection: 'ViewSection',
    editSection: 'EditSection',
    editRole: 'EditRole',
    viewRole: 'ViewRole',
    editPrivilege: 'EditPrivileges',
    rolesPrivilege: 'PrivilegesForModule',
    init: function (keyName) {
        return appService[keyName];
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