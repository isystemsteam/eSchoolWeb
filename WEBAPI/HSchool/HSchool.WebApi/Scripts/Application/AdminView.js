$(document).ready(function () {
    $(".actionAdminLeft").click(function () {
        var linkId = $(this).attr("linkId");
        adminView.init(linkId, "divEditContainer");
    });
});

var adminView = {
    editControlId: "divEditContainer",
    viewContainerId: "divViewContainer",
    init: function (typeId, controlId) {
        $("#" + this.editControlId).html("");
        $("#" + this.viewContainerId).html("");
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
    handleException: function (xhr, error, messgage) {
    },
    displayBox: function (isEdit) {
        if (!isEdit) {
            $("#" + adminView.editControlId).hide();
            $("#" + adminView.viewContainerId).show();
        } else {
            $("#" + adminView.viewContainerId).hide();
            $("#" + adminView.editControlId).show();
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
                adminView.displayBox(true);
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
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
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
                adminView.displayBox(true);

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
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
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
            adminView.classSections.edit();
        },
        edit: function (id) {
            //load success
            var successcallback = function (result) {
                $("#" + adminView.editControlId).html(result);
                adminView.displayBox(true);
                $("#txtClassName").click(function () {
                    $("#divClassesContainer").show();
                });

                //bind events
                $(".clsAppClassItem").click(function () {
                    adminView.classSections.selectClass(this);
                });
            };

            $.fn.appCommon.ajax.getForm(appService.editClassSection, null, successcallback, adminView.handleException);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminView.viewContainerId).html(result).show();
                //adminView.displayBox(false);
            };
            $.fn.appCommon.ajax.getForm(appService.viewClass, [], _successcallback, null);
        },
        selectClass: function (obj) {
            var classId = $(obj).attr("classId");

            var successcallback = function (result) {
                var data = JSON.parse(result);
                //js render - template 
                var template = $.templates("#tempClassSections");
                var htmlOutput = template.render(data);
                $("#" + adminView.viewContainerId).html(htmlOutput).show();
                $("#divClassesContainer").hide();

                //bind events
                $("#btnUpdateClassSection").click(function () {
                    adminView.classSections.saveClassSections();
                });
            };
            $("#txtClassName").val($(obj).text());
            $("#txtClassId").val(classId);
            var parameters = [];
            parameters.push(new ajaxParam("classId", classId));
            $.fn.appCommon.ajax.getForm(appService.viewClassSections, parameters, successcallback, adminView.handleException);
        },
        saveClassSections: function () {
            var jsonObj = [];
            var classId = $("#txtClassId").val();
            var tablesRowsCheckBoxes = $(".clsClassSectionCollection").find("input");
            $(tablesRowsCheckBoxes).each(function (index, item) {
                var sectionId = $(item).attr("sectionid");
                if (item.checked) {
                    jsonObj.push({ ClassId: classId, SectionId: sectionId, IsActive: true, RowNumber: index + 1 });
                } else {
                    jsonObj.push({ ClassId: classId, SectionId: sectionId, IsActive: false, RowNumber: index + 1 });
                }
            });

            var parameters = [];
            parameters.push(new ajaxParam("classSections", jsonObj));

            var successcallback = function (result) {
                if (result != null) {
                    $.fn.appCommon.UI.displayMessage(result.Reason, null);
                }
                adminView.displayBox(false);
            };

            $.fn.appCommon.ajax.post(appService.saveClassSections, parameters, 'application/json', successcallback, adminView.handleException);
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
                adminView.displayBox(true);
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
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
            };
            $.fn.appCommon.ajax.getForm(appService.viewRole, null, _successcallback, null);
        },
        saveApplicationRole: function () {
            $('#formApplicationRoleEdit').submit();
        }
    },
    rolesPrivileges: {
        load: function () {
            this.edit();
        },
        edit: function () {
            var successcallback = function (result) {
                $("#" + adminView.editControlId).html(result);
                adminView.displayBox(true);
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
        loadGrid: function () {
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
            $.fn.appCommon.ajax.post(appService.SaveRolesPrivileges, parameters, 'application/json', successcallback, adminView.handleException);

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