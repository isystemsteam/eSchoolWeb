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
                this.subjects.loadGrid();
                break;
            case "5":
                this.classSubject.load();
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
    displayBox: function (isEdit) {
        if (!isEdit) {
            $("#" + adminView.editControlId).hide();
            $("#" + adminView.viewContainerId).show();
        } else {
            $("#" + adminView.viewContainerId).hide();
            $("#" + adminView.editControlId).show();
        }
        $('.datepicker').datepicker({ format: 'dd/mm/yyyy', startDate: '-3d' });
        $('.custom-text input[type="text"], .custom-text input[type="password"]').editAnimate();
        $('select').selectpicker('refresh');
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
            if (jQuery.fn.Validation.validateForm("formClassEdit")) {
                $('#formClassEdit').submit();
            }
        },
        editCancel: function () {
            adminView.classes.loadGrid();
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
            if (jQuery.fn.Validation.validateForm("formSectionEdit")) {
                $('#formSectionEdit').submit();
            }
        },
        editCancel: function () {
            adminView.sections.loadGrid();
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
            var classId = $(obj).val();

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
            var classId = $("#ddlClasses").val();
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

    //academic years
    academicYear: {
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
                        adminView.academicYear.loadGrid();
                    }
                    jQuery.fn.appCommon.UI.displayMessage(result.Message, 3);
                };

                //ajax form errorcallback
                var _errorcallback = function () { };
                //bind ajax form
                $.fn.appCommon.ajax.bind("formAcademicYear", _beforecallback, _successcallback, _errorcallback);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            $.fn.appCommon.ajax.getForm(appService.init("editAcademicYear"), parameters, _successcallback, null);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
            };
            $.fn.appCommon.ajax.getForm(appService.init("getAcademicYears"), null, _successcallback, null);
        },
        cancel: function () {
            this.loadGrid();
        }
    },
    //Academic years -End
    //Subjects - Begin
    subjects: {
        load: function () {
            adminView.subjects.loadGrid();
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
                        adminView.subjects.loadGrid();
                    }
                    jQuery.fn.appCommon.UI.displayMessage(result.Message, 3);
                };

                //ajax form errorcallback
                var _errorcallback = function () { };
                //bind ajax form
                $.fn.appCommon.ajax.bind(ADMINFORMS.EDIT_SUBJECT, _beforecallback, _successcallback, _errorcallback);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            $.fn.appCommon.ajax.getForm(appService.editSubject, parameters, _successcallback, null);
        },
        loadGrid: function () {
            var _successcallback = function (result) {
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
            };
            $.fn.appCommon.ajax.getForm(appService.viewSubject, null, _successcallback, null);
        },
        saveSubject: function () {
            if (jQuery.fn.Validation.validateForm(ADMINFORMS.EDIT_SUBJECT)) {
                $('#' + ADMINFORMS.EDIT_SUBJECT).submit();
            }
        },
        editCancel: function () {
            adminView.subjects.loadGrid();
        }
    },
    classSubject: {
        load: function () {
            adminView.classSubject.loadGrid();
        },
        configure: function (id) {
            var _successcallback = function (result) {
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
            };
            var parameters = [];
            parameters.push(new ajaxParam("id", id));
            parameters.push(new ajaxParam("sectionId", 0));
            $.fn.appCommon.ajax.getForm(appService.editClassSubject, parameters, _successcallback, null);
        },
        loadGrid: function (classId, sectionId) {
            var _successcallback = function (result) {
                $("#" + adminView.viewContainerId).html(result);
                adminView.displayBox(false);
            };
            $.fn.appCommon.ajax.getForm(appService.viewClassSubject, null, _successcallback, null);
        },
        saveClassSubject: function () {

        },
        editCancel: function () {

        },
        selectViewClass: function () {

        },
        selectViewSection: function () {

        },
        selectEditClass: function (obj) {
            var classId = $(obj).val();
            this.bindEditClassSubjects(classId, 0);
        },
        bindEditClassSubjects: function (classId, sectionId) {
            var successcallback = function (result) {
                //js render - template 
                var template = $.templates("#tempClassSectionSubject");
                var htmlOutput = template.render(result);
                $("#divEditClassSubject").html(htmlOutput).show();

                //bind events
                $("#btnUpdateClassSectionSubject").click(function () {
                    adminView.classSubject.saveClassSections();
                });
            };
            var parameters = [];
            parameters.push(new ajaxParam("classId", classId));
            parameters.push(new ajaxParam("sectionId", sectionId));
            $.fn.appCommon.ajax.get(appService.ViewSubjectsForClass, parameters, 'json', successcallback, adminView.handleException);
        }
    }
};