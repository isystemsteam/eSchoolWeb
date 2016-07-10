jQuery.fn.appCommon = new function ($) {
    var plugin = {
        //ajax start
        ajax: {
            //to partial view or view
            getForm: function (uri, parameters, successcallback, errorcallback) {
                this.get(uri, parameters, 'html', successcallback, errorcallback);
            },
            postForm: function () {
            },
            //ajax call get
            get: function (uri, parameters, datatype, successcallback, errorcallback) {
                var data = $.fn.appCommon.utility.createParameters(parameters);
                //to show ajax processing
                $(document).ajaxStart(function () {
                    $.fn.appCommon.ajax.processing.show();
                }).ajaxStop(function () {
                    $.fn.appCommon.ajax.processing.hide();
                }).ajaxSuccess(function (value, xhr, settings) {
                    if (xhr != null && xhr.responseText == "true") {
                    }
                });
                //ajax call
                $.ajax({
                    url: uri,
                    type: 'get',
                    data: data,
                    dataType: datatype,
                    success: successcallback,
                    error: errorcallback,
                    cache: false
                });
            },
            post: function (uri, parameters, datatype, successcallback, errorcallback) {
                debugger
                var data = $.fn.appCommon.utility.createParameters(parameters);
                //to show ajax processing
                $(document).ajaxStart(function () {
                    $.fn.appCommon.ajax.processing.show();
                }).ajaxStop(function () {
                    $.fn.appCommon.ajax.processing.hide();
                }).ajaxSuccess(function (value, xhr, settings) {
                    if (xhr != null && xhr.responseText == "true") {
                    }
                });
                debugger
                //ajax call
                $.ajax({
                    url: uri,
                    type: 'post',
                    data: data,
                    dataType: datatype,
                    success: successcallback,
                    error: errorcallback,
                    cache: false
                });
            },
            //to bind form for ajax call
            bind: function (formName, beforecallback, successcallback, errorcallback, loading) {
                $("#" + formName).ajaxForm({
                    beforeSubmit: function () {
                    },
                    datatype: 'application/json',
                    success: function (result, statustext, xhr, $formName) {
                        successcallback(result);
                    },
                    errorcakkback: function (xhr, textstatus, error) {
                        errorcallback(xhr, textstatus, error);
                    },
                    complete: function () {
                    }
                });
            },
            //ajax processing
            processing: {
                show: function (control) {
                    $.blockUI({ message: null });
                    $('#ajaxProgressLoader')
                        .css("position", "absolute")
                        .css("z-index", "10000")
                        .css("top", ($(window).height() - $('#ajaxProgressLoader').height()) / 2 + $(window).scrollTop() + "px")
                        .css("left", ($(window).width() - $('#ajaxProgressLoader').width()) / 2 + $(window).scrollLeft() + "px");
                    $('#ajaxProgressLoader').show();
                },
                hide: function (control) {
                    $.unblockUI();
                    $('#ajaxProgressLoader').hide();
                }
            }
        },
        //ajax end
        //dialog start
        dialog: {
            showMessage: function (message) {
                this.showMessageDialog(message, function () { }, function () { });
            },
            successDialog: function (message, okCallback, closecallback) {
            },
            errorDialog: function (errormessage, okCallback, closecallback) {
            },
            showFormDialog: function (form, formName) {
                $('#AdminDialog').html(form);
                $('#AdminDialog').dialog({
                    autoOpen: false, width: 500, resizable: false, modal: true, closeOnEscape: true, buttons: {}
                });
                $(".ui-dialog-titlebar-close").hide();
                $('#AdminDialog').dialog("option", "title", formName)
                $('#AdminDialog').dialog("open");
                jQuery.fn.appCommon.dialog.dialogCenter();
            },
            showMessageDialog: function (data, okCallback, closecallback) {
                $('#AdminDialog').html(data);
                $('#AdminDialog').dialog({
                    autoOpen: false, width: 400, resizable: false, modal: true, closeOnEscape: false,
                    buttons: {
                        "Ok": function () {
                            okCallback();
                            jQuery.fn.appCommon.dialog.closeDialog();
                        }
                    }
                });
                $(".ui-dialog-titlebar-close").hide();
                $('#AdminDialog').dialog("option", "title", "Onvia")
                $('#AdminDialog').dialog("open");
                jQuery.fn.appCommon.dialog.dialogCenter();
            },
            showMessageDialogWithCancel: function (data, dialogTitle, okCallback, closecallback) {
                $('#AdminDialog').html(data);
                $('#AdminDialog').dialog({
                    autoOpen: false, width: 400, resizable: false, modal: true, closeOnEscape: false,
                    buttons: {
                        "Ok": function () {
                            okCallback();
                            jQuery.fn.appCommon.dialog.closeDialog();
                        },
                        "Cancel": function () {
                            closecallback();
                            jQuery.fn.appCommon.dialog.closeDialog();
                        }
                    }
                });
                $(".ui-dialog-titlebar-close").hide();
                $('#AdminDialog').dialog("option", "title", dialogTitle)
                $('#AdminDialog').dialog("open");
                jQuery.fn.appCommon.dialog.dialogCenter();
            },
            showConfirmDialog: function (data, confirmCallback, cancelCallback, dialogButtonType) {
                $('#AdminDialog').html(data);
                $('#AdminDialog').dialog({
                    autoOpen: false,
                    width: 400,
                    resizable: false,
                    modal: true,
                    buttons: {
                        "Yes": function () {
                            confirmCallback();
                            jQuery.fn.appCommon.dialog.closeDialog();
                        },
                        "No": function () {
                            cancelCallback();
                            jQuery.fn.appCommon.dialog.closeDialog();
                        }
                    }
                });
                $(".ui-dialog-titlebar-close").hide();
                $('#AdminDialog').dialog("option", "title", "Onvia")
                $('#AdminDialog').dialog("open");
                jQuery.fn.appCommon.dialog.dialogCenter();
            },
            ShowDialogWithGrid: function (control, data, dialogTitle) {
                if (data != '' && data != null) {
                    $(control).html(data);
                }

                $(control).dialog({
                    autoOpen: false,
                    resizable: false,
                    modal: true,
                    width: 900,
                    buttons: {
                        "Ok": function () {
                            jQuery.fn.appCommon.dialog.CloseDialogWithGrid(control);
                        }
                    }
                });
                $(control).dialog("option", "dialogClass", "clsRefereshDialog");
                $(control).dialog("option", "title", dialogTitle)
                $(control).dialog("open");
                jQuery.fn.appCommon.dialog.dialogCenter();
            },
            CloseDialogWithGrid: function (control) {
                $(control).dialog("close");
            },
            dialogCenter: function () {
                $('.ui-dialog')
                .css("top", ($(window).height() - $('.ui-dialog').height()) / 2 + $(window).scrollTop() + "px")
                .css("left", ($(window).width() - $('.ui-dialog').width()) / 2 + $(window).scrollLeft() + "px");
            },
            closeDialog: function () {
                $('#AdminDialog').dialog("close");
                $(".ui-dialog-titlebar-close").hide();
            },
            createButtons: function (dialogButtonType, dialogType, callback, cancelCallback) {
                var buttons = null;
                if (dialogType == "confirm") {
                    switch (dialogButtonType) {
                        case "YesNo":
                            buttons =
                            {
                                "Yes": function () {
                                    confirmCallback();
                                    jQuery.fn.appCommon.dialog.closeDialog();
                                },
                                "No": function () {
                                    cancelCallback();
                                    jQuery.fn.appCommon.dialog.closeDialog();
                                }
                            }
                            break;
                    }
                } else {
                    switch (dialogButtonType) {
                        case "Save":
                            buttons = {
                                "Save": function () {
                                    okCallback();
                                    jQuery.fn.appCommon.dialog.closeDialog();
                                }
                            };
                            break;
                        default:
                            buttons = {
                                "Ok": function () {
                                    okCallback();
                                    jQuery.fn.appCommon.dialog.closeDialog();
                                }
                            };
                            break;
                    }
                }
            },
            //to display dialog for controls
            showCtrlDialog: function (dialogCtrl, dialogWidth, dialogTitle) {
                $('#' + dialogCtrl).dialog({
                    autoOpen: false,
                    width: dialogWidth,
                    resizable: false,
                    modal: true,
                    closeOnEscape: false
                });
                $(".ui-dialog-titlebar-close").hide();
                $('#' + dialogCtrl).dialog("option", "title", dialogTitle);
                $('#' + dialogCtrl).dialog("open");
                jQuery.fn.appCommon.dialog.dialogCenter();
                $("#" + dialogCtrl).show();
            },
            closeCtrlDialog: function (dialogCtrl) {
                $('#' + dialogCtrl).dialog("close");
                $(".ui-dialog-titlebar-close").hide();
                $("#" + dialogCtrl).hide();
            }
        },
        //dialog end
        //utility start
        utility: {
            //to create parameters for ajax call
            createParameters: function (parameters) {
                var data = {};
                if (parameters != null && parameters != '') {
                    for (var i = 0; i < parameters.length; i++) {
                        data[parameters[i]["name"]] = parameters[i]["value"];
                    }
                }
                return data;
            },
            replace: function () {
            },
            findIndex: function () {
            },
            format: function (stringText, params) {
                try {
                    var paramsArray = params != null ? params : [];
                    for (i = 0; i < paramsArray.length; i++) {
                        stringText = stringText.replace("{" + i + "}", params[i]);
                    }
                    return stringText;
                } catch (e) {
                    throw e;
                }
            },
            getMonthsDifference: function (d1, d2) {
                var months;
                months = (d2.getFullYear() - d1.getFullYear()) * 12;
                months -= d1.getMonth() + 1;
                months += d2.getMonth();
                return months <= 0 ? 0 : months;
            }
        },
        //utility end
        //controls add and remove attribute, add and remove classes
        controls: {
            addClass: function (elements, className) {
                $(elements).each(function () {
                    if (!$(this).hasClass(className)) {
                        $(this).addClass(className);
                    }
                });
            },
            addAttr: function (elements, attrName, attrValue) {
                $(elements).each(function () {
                    $(this).attr(attrName, attrValue);
                });
            },
            removeAttr: function (elements, attrName) {
                $(elements).each(function () {
                    $(this).removeAttr(attrName);
                });
            },
            removeClass: function (elements, className) {
                $(elements).each(function () {
                    $(this).removeClass(className);
                });
            },
            clearValue: function (elements) {
                $(elements).each(function () {
                    $(this).val('');
                });
            },
            renderEvents: function () {
                $('.datePicker').datepicker({ changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1930:+10Y' });
                $('.datePicker2').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    //dateFormat: 'mm/dd/yy',
                    yearRange: '1930:+10Y',
                    onSelect: function (dateText) {
                        var value = $(this).val();
                        value += " 12:00:00 AM";
                        $(this).val(value);
                        if ($(this).hasClass('validationerror')) {
                            $(this).removeClass('validationerror')
                        }
                    }
                });
            }
        },
        //controls - end
        //parameter
        //ajax parameters objects
        parameter: function (name, value) {
            this.name = name;
            this.value = value;
        },
        //ajax parameters objects
        //validation
        validation: {
            form: function (formname) {
                var validateResult = true;
                var inputControlResult = this.inputValidates($("#" + formname + " :input"));
                var dropdownControlsResult = this.dropDownsValidates($("#" + formname).find('select'));
                var integerResult = this.integerValidation($("#" + formname).find('.integerField'));
                var dateResult = this.dateValidation($("#" + formname).find('.dateField'));
                var decimalResult = this.decimalValidation($("#" + formname).find('.decimalField'))
                this.bindValidateEvent();
                return inputControlResult && dropdownControlsResult && integerResult && dateResult && decimalResult;
            },
            inputValidates: function (inputs) {
                var result = true;
                $(inputs).each(function (index, element) {
                    var inputType = $(this).attr('type');
                    switch (inputType) {
                        case 'text':
                            if (!jQuery.fn.OnviaValidation.validate.mandatoryText($(this))) {
                                $(this).addClass('clsInputRequired');
                                result = false;
                            }
                            break;
                    }
                });
                return result;
            },
            dropDownsValidates: function (dropDowns) {
                var result = true;
                $(dropDowns).each(function (index, element) {
                    var value = $(this).val();
                    if (value == 0 || value == '') {
                        $(this).addClass('clsSelectRequired');
                        result = false;
                    }
                });
                return result;
            },
            date: function () {
                var dateResult = false;
                var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
                if (re.test(value)) {
                    var adata = value.split('/');
                    var mm = parseInt(adata[0], 10);
                    var dd = parseInt(adata[1], 10);
                    var yyyy = parseInt(adata[2], 10);
                    var xdata = new Date(yyyy, mm - 1, dd);
                    if ((xdata.getFullYear() == yyyy) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == dd))
                        dateResult = true;
                    else
                        dateResult = false;
                } else
                    dateResult = false;
                return dateResult;
            },
            dateControl: function (dateControl) {
                var result = $.fn.appCommon.validation.date($(dateControl).val());
                if (!result) {

                }
                return result;
            },
            dateControls: function () {

            },
            integerValidation: function (integerControls) {
                var integerResult = true;
                $(integerControls).each(function (ctrl) {

                });
                return integerResult;
            },
            integerOnly: function (event) {
                event = (event) ? event : window.event;
                var charCode = (event.which) ? event.which : event.keyCode;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    console.log('false');
                    return false;
                }
                return true;
            },
            decimalValidation: function (decimalControls) {
                var decimalResult = true;
                return decimalResult;
            },
            bindValidateEvent: function () {
                //to validate & remove the text input
                $('.clsInputRequired').change(function () {
                    var value = $(this).val().trim();
                    if (value != null && value != '') {
                        $(this).removeClass("clsInputRequired");
                    }
                });

                //to validate & remove the dropdown
                $('.clsSelectRequired').change(function () {
                    var value = $(this).val();
                    if (value != 0 && value != null) {
                        $(this).removeClass("clsSelectRequired");
                    }
                });

                //to validate integer field
                $('.integerField').keypress(function (event) {
                    return jQuery.fn.appCommon.validation.integerOnly(event);
                });
            }
        },
        //end validation
        //ui
        UI: {
            toggle: function (className) {
                $('.' + className).click(function () {
                    var controlBodyId = $(this).attr('toggleId');
                    if ($("#" + controlBodyId).hasClass('active')) {
                        $("#" + controlBodyId).removeClass('active');
                    } else {
                        $("#" + controlBodyId).addClass('active');
                    }
                    //toggle icon change
                    var iElement = $(this).find('i');
                    if (iElement != null && $(iElement).hasClass('fa-angle-down')) {
                        $(iElement).removeClass('fa-angle-down active');
                        $(iElement).addClass('fa-angle-right');
                    } else if (iElement != null && $(iElement).hasClass('fa-angle-right')) {
                        $(iElement).removeClass('fa-angle-right');
                        $(iElement).addClass('fa-angle-down active');
                    }
                });
            },
            displayMessage: function (message, messageType) {
                $("#ribbonErrorMessage").html(message).show();
            }
        },
        //ui end
        //Templates -start
        templates: {
            load: function (templId, containerId, data) {
                var htmlOutput = $.templates("#" + templId).render(data);
                $("#" + containerId).html(htmlOutput);
            }
        }
        //Templates - end
    }
    return plugin;
}($);