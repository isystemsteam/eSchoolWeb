$(document).ready(function () {
    $(".actionAdminLeft").click(function () {
        var linkId = $(this).attr("linkId");
        adminManagment.init(linkId, "divEditContainer");
    });
});

var adminManagment = {
    editControlId: "divEditContainer",
    viewContainerId: "divViewContainer",
    init: function (typeId, controlId) {
        $("#" + this.editControlId).html("");
        $("#" + this.viewContainerId).html("");
        switch (typeId) {
            case "1":
                this.roles.load();
                break;
            case "2":
                this.rolesPrivileges.load();
                break;
            case "3":
                this.settings.load();
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                this.academicYear.load();
                break;
            case "7":
                this.roles.load();
                break;
            case "8":
                this.rolesPrivileges.load();
                break;
            case "9":
                break;
        }
    },
    handleException: function (xhr, error, messgage) {
    },
    //Roles
    roles: {
        load: function () {
            this.loadGrid();
        },
        edit: function (id) {
            var _successcallback = function (result) {
                $("#" + adminManagment.editControlId).html(result);
                adminManagment.displayBox(true);
                //ajax form before submit call
                var _beforecallback = function () { };

                //ajax form success callback
                var _successcallback = function (result) {
                    if (result != null && result.IsSuccess) {
                        adminManagment.roles.loadGrid();
                    }
                    jQuery.fn.appCommon.UI.displayMessage(result.Message, 3);
                };

                //ajax form errorcallback
                var _errorcallback = function () { };
                //bind ajax form
                $.fn.appCommon.ajax.bind("formApplicationRoleEdit", _beforecallback, _successcallback, _errorcallback);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            $.fn.appCommon.ajax.getForm(appService.editRole, parameters, _successcallback, null);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminManagment.viewContainerId).html(result);
                adminManagment.displayBox(false);
            };
            $.fn.appCommon.ajax.getForm(appService.viewRole, null, _successcallback, null);
        },
        saveApplicationRole: function () {
            if (jQuery.fn.Validation.validateForm("formApplicationRoleEdit")) {
                $('#formApplicationRoleEdit').submit();
            }
        },
        editCancel: function () {
            this.loadGrid();
        }
    },
    //Roles - End
    //Role Privileges
    rolesPrivileges: {
        load: function () {
            this.edit();
        },
        edit: function () {
            var successcallback = function (result) {
                $("#" + adminManagment.editControlId).html(result);
                adminManagment.displayBox(true);
                //bind events
                $(".clsAppModuleItem").click(function () {
                    var moduleId = $(this).attr("moduleid");
                    $("#txtModuleName").val($(this).text());
                    $(".divModulesContainer").hide();
                    adminManagment.rolesPrivileges.loadPrivilegesForModule(moduleId);
                });

            };
            $.fn.appCommon.ajax.getForm(appService.editPrivilege, null, successcallback, null);
        },
        loadPrivilegesForModule: function (moduleId) {
            var successcallback = function (result) {
                var data = JSON.parse(result);
                $.views.settings.debugMode(true);
                //js render - template 
                var template = $.templates("#tempRolesPrivilege");
                var htmlOutput = template.render(data);
                $("#divRolesPrivilegesContainer").html(htmlOutput);
            };
            $("#hdnModuleId").val(moduleId);
            var parameters = [];
            parameters.push(new ajaxParam("moduleId", moduleId));
            $.fn.appCommon.ajax.getForm(appService.rolesPrivilegeForModule, parameters, successcallback, null);
        },
        loadPrivilegesForRoles: function (obj) {
            var roleId = $(obj).val();
            var successcallback = function (result) {
                var data = JSON.parse(result);
                $.views.settings.debugMode(true);
                //js render - template 
                var template = $.templates("#tempRolesPrivilege");
                var htmlOutput = template.render(data);
                $("#divRolesPrivilegesContainer").html(htmlOutput);
            };
            //$("#hdnModuleId").val(moduleId);
            var parameters = [];
            parameters.push(new ajaxParam("roleId", roleId));
            $.fn.appCommon.ajax.getForm(appService.rolesPrivilegeForModule, parameters, successcallback, null);
        },
        saveRolePrivileges: function () {
            var jsonObj = [];
            var moduleId = $("#hdnModuleId").val();
            var trRows = $(".trRolesActive");
            $(trRows).each(function (index, item) {
                var privileges = [];
                var roleId = $(item).find(".hdnRoleId").val();
                var rowCheckBoxes = $(item).find(".chkRoleEnabled");
                if (rowCheckBoxes != null && rowCheckBoxes.length > 0) {
                    for (var roleCheckCounter = 0; roleCheckCounter < rowCheckBoxes.length; roleCheckCounter++) {
                        if (rowCheckBoxes[roleCheckCounter].checked) {
                            var privilegeId = $(rowCheckBoxes[roleCheckCounter]).attr("privilegeid");
                            privileges.push(privilegeId);
                        }
                    }
                    var rolePrivilege = { PrivilgeIds: privileges, RoleId: roleId, ModuleId: moduleId, RowNumber: index + 1 };
                    jsonObj.push(rolePrivilege);
                }
            });

            //success callback for save
            var successcallback = function (result) {
                if (result != null) {
                    $.fn.appCommon.UI.displayMessage(result.Reason, null);
                }
            };

            //parameters save
            var parameters = [];
            parameters.push(new ajaxParam("rolesPrivileges", jsonObj));
            $.fn.appCommon.ajax.post(appService.SaveRolesPrivileges, parameters, 'application/json', successcallback, adminManagment.handleException);

        },
        selectModule: function (obj) {
            var moduleId = $(obj).attr("moduleid");
            var _successcallback = function (result) {

            };
            var parameters = [];
            parameters.push(new ajaxParam("moduleid", moduleId));
            $.fn.appCommon.ajax.get(appService.init("rolesPrivilegeForModule"), parameters, 'json', _successcallback, null);
        },
        roleBoxFocus: function () {
            $(".divModulesContainer").show();
        },
        roleBoxBlur: function () {
            $(".divModulesContainer").hide();
        }
    },
    //Role Previlige - End
    //settings
    settings: {
        load: function () {
        },
        edit: function (id) {
        },
        loadGrid: function () {
        },
        saveSettings: function () {
        }
    }
};