$(document).ready(function () {
    $(".actionAdminLeft").click(function () {
        var linkId = $(this).attr("linkId");
        adminView.init(linkId, "divEditContainer");
    });
});

var adminView = {
    editControlId: "divEditContainer",
    loadGridId: "divViewContainer",
    init: function (typeId, controlId) {
        $("#" + this.editControlId).html("");
        $("#" + this.loadGridId).html("");
        switch (typeId) {
            case "1":
                this.classes.load();
                break;
            case "2":
                this.sections.load();
                break;
            case "3":
                this.classSections.load();
                break;
            case "4":
                break;
            case "5":
                break;
            case "6":
                break;
            case "7":
                this.roles.load();
                break;
            case "8":
                this.rolesPrivileges.load();
                break;
        }
    },
    //Classes
    classes: {
        load: function () {
            adminView.classes.loadGrid();
        },
        edit: function (id) {
            //load success
            var successcallback = function (result) {
                $("#" + adminView.editControlId).html(result);

                //ajax form before submit call
                var _beforecallback = function () { };

                //ajax form success callback
                var _successcallback = function (result) {
                    if (result != null && result.IsSuccess) {
                        adminView.classes.loadGrid();
                    }
                    jQuery.fn.appCommon.UI.displayMessage(result.Message, 3);
                };

                //ajax form errorcallback
                var _errorcallback = function () { };
                //bind ajax form
                $.fn.appCommon.ajax.bind("formClassEdit", _beforecallback, _successcallback, _errorcallback);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            $.fn.appCommon.ajax.getForm(appService.editClass, parameters, successcallback, null);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminView.loadGridId).html(result);
            };
            $.fn.appCommon.ajax.getForm(appService.viewClass, null, _successcallback, null);
        },
        saveClass: function () {
            $('#formClassEdit').submit();
        }
    },
    //Sections
    sections: {
        load: function () {
            adminView.sections.loadGrid();
        },
        edit: function (id) {
            //load success
            var _successcallback = function (result) {
                $("#" + adminView.editControlId).html(result);

                //ajax form before submit call
                var _beforecallback = function () { };

                //ajax form success callback
                var _successcallback = function (result) {
                    if (result != null && result.IsSuccess) {
                        adminView.sections.loadGrid();
                    }
                    jQuery.fn.appCommon.UI.displayMessage(result.Message, 3);
                };

                //ajax form errorcallback
                var _errorcallback = function () { };
                //bind ajax form
                $.fn.appCommon.ajax.bind("formSectionEdit", _beforecallback, _successcallback, _errorcallback);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            $.fn.appCommon.ajax.getForm(appService.editSection, parameters, _successcallback, null);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminView.loadGridId).html(result);
            };
            $.fn.appCommon.ajax.getForm(appService.viewSection, null, _successcallback, null);
        },
        saveSections: function () {
            $('#formSectionEdit').submit();
        }
    },
    //Class Sections
    classSections: {
        load: function () {
            adminView.classSections.edit(0);
            adminView.classSections.loadGrid();
        },
        edit: function (id) {
            //load success
            var successcallback = function (result) {
                $("#" + adminView.controlId).html(result);

                //ajax form before submit call
                var _beforecallback = function () { };

                //ajax form success callback
                var _successcallback = function () {
                    if (result != null && result.IsSuccess) {
                        adminView.sections.loadGrid();
                    }
                    jQuery.fn.appCommon.UI.displayMessage(result.Message, 3);
                };

                //ajax form errorcallback
                var _errorcallback = function () { };

                //bind ajax form
                $.fn.appCommon.ajax.bind("formSectionEdit", _beforecallback, _successcallback, _errorcallback);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            $.fn.appCommon.ajax.getForm(appService.editClass, parameters, successcallback, null);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminView.loadGridId).html(result);
            };
            $.fn.appCommon.ajax.getForm(appService.viewClass, [], _successcallback, null);
        }
    },
    //Roles
    roles: {
        load: function () {
            this.loadGrid();
        },
        edit: function (id) {
            var _successcallback = function (result) {
                $("#" + adminView.editControlId).html(result);

                //ajax form before submit call
                var _beforecallback = function () { };

                //ajax form success callback
                var _successcallback = function (result) {
                    if (result != null && result.IsSuccess) {
                        adminView.roles.loadGrid();
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
                $("#" + adminView.loadGridId).html(result);
            };
            $.fn.appCommon.ajax.getForm(appService.viewRole, null, _successcallback, null);
        },
        saveApplicationRole: function () {
            $('#formApplicationRoleEdit').submit();
        },
        privileges: {
            loadPrivilegesForModule: function (moduleId) {

            },
            setPrivilege: function () {
            },
            savePrivilege: function () {
            }
        }
    },
    rolesPrivileges: {
        load: function () {
            this.edit();
        },
        edit: function () {
            var successcallback = function (result) {
                $("#" + adminView.editControlId).html(result);

                //bind events
                $(".clsAppModuleItem").click(function () {
                    var moduleId = $(this).attr("moduleid");
                    $("#txtModuleName").val($(this).text());
                    $(".divModulesContainer").hide();
                    adminView.rolesPrivileges.loadPrivilegesForModule(moduleId);
                });

            };
            $.fn.appCommon.ajax.getForm(appService.editPrivilege, null, successcallback, null);
        },
        loadPrivilegesForModule: function (moduleId) {
            var successcallback = function (result) {
                var data = JSON.parse(result);
                //js render - template 
                var template = $.templates("#tempRolesPrivilege");
                var htmlOutput = template.render(data);
                $("#divRolesPrivilegesContainer").html(htmlOutput);
            };

            var parameters = [];
            parameters.push(new ajaxParam("moduleId", moduleId));
            $.fn.appCommon.ajax.getForm(appService.rolesPrivilegeForModule, parameters, successcallback, null);
        },
        loadGrid: function () {
        },
        saveRolesPermissions: function () {
        },
        selectModule: function (obj) {
            var moduleId = $(obj).attr("moduleid");
            var _successcallback = function (result) {
                debugger
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