//changevalidation - to bind validation for change
//validatecontrol - input dependency control, It will be disabled if the validation failed
//validationerror - to mark red border if the validation false
jQuery.fn.Validation = new function ($) {
    var plugin = {
        //to validate fileds - Begin
        validate: {
            intField: function () {
            },
            decimalField: function (value) {
                var indexof = value.indexOf(".");
                var decimal = /^[-+]?[0-9]+$/;
                if (indexof > 0) {
                    decimal = /^[-+]?[0-9]+\.[0-9]+$/;
                }
                return decimal.test(value);
            },
            dropDownField: function () {
            },
            dateField: function (value) {
                var dateResult = false;
                var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
                if (re.test(value)) {
                    var adata = value.split('/');
                    var dd = parseInt(adata[0], 10);
                    var mm = parseInt(adata[1], 10);
                    var yyyy = parseInt(adata[2], 10);
                    var xdata = new Date(yyyy, mm - 1, dd);
                    if ((xdata.getFullYear() == yyyy) && (xdata.getMonth() == mm - 1) && (xdata.getDate() == dd))
                        dateResult = true;
                    else
                        dateResult = false;
                } else
                    dateResult = false;
                return dateResult
            },
            dateTimeField: function (value) {
                var result = true;
                try {
                    var splitTime = value.split(' ');
                    if (splitTime != null && splitTime.length > 1) {
                        //to verify the date matches
                        var dateMatches = splitTime[0].match(/^(\d{1,2})\/(\d{1,2})\/(\d{4})$/);
                        var timeMatches = splitTime[1].match(/^(\d{2}):(\d{2}):(\d{2})$/)
                        if (dateMatches == null || timeMatches == null) {
                            result = false;
                        }
                        //to get date & time
                        var year = parseInt(dateMatches[3], 10);
                        var month = parseInt(dateMatches[1], 10) - 1; // months are 0-11
                        var day = parseInt(dateMatches[2], 10);
                        var hour = parseInt(timeMatches[1], 10);
                        var minute = parseInt(timeMatches[2], 10);
                        var second = parseInt(timeMatches[3], 10);
                        //to create new date
                        var date = new Date(year, month, day, hour, minute, second);
                        //validate date & time
                        if (date.getFullYear() !== year || date.getMonth() != month || date.getDate() !== day || date.getHours() !== hour || date.getMinutes() !== minute || date.getSeconds() !== second) {
                            result = false;
                        }
                    }
                    else {
                        result = false;
                    }
                } catch (e) {
                    result = false;
                }
                return result;
            },
            ValidateStartEndDate: function (startDate, endDate) {
                var start = startDate;
                var end = endDate;
                if ((start != '' && end != '') && (start != null && end != null)) {
                    var startDate = new Date(start);
                    var endDate = new Date(end);
                    return startDate <= endDate;
                }
                return true;
            },
            //to validate mandatory - Begin
            mandatoryText: function (value) {
                var result = true;
                if (value == null || value == '') {
                    result = false;
                }
                return result;
            },
            selectFieldMandatory: function (value) {
                debugger
                var result = true;
                if (value == null || value == '' || value == '0') {
                    result = false;
                }
                return result;
            }
            //to validate mandatory - Begin
        },
        //to validate fileds - End
        //to bind form validation - Begin
        bindFormValidation: function (formName) {
            var validationResult = true;
            //to validate text required fileds - Begin
            var inputRequiredControl = $("#" + formName).find("input[required=true]");
            if (inputRequiredControl != null) {
                for (var r = 0; r < inputRequiredControl.length; r++) {
                    var inputControl = inputRequiredControl[r];
                    var isChangeValidationEnabled = $(inputControl).attr("changevalidation");
                    if (isChangeValidationEnabled) {
                        $(inputControl).change(function () {
                            var dependControl = $(inputControl).attr("validatecontrol");
                            if (!jQuery.fn.Validation.validate.mandatoryText($(inputControl).val())) {
                                $(inputControl).addClass("validationerror");
                                //to disable action
                                if (dependControl != null) {
                                    $(dependControl).attr("disabled", "disabled");
                                    $(dependControl).addClass("faiconDisabled");
                                }
                            } else {
                                $(inputControl).removeClass("validationerror");
                                if (dependControl != null) {
                                    $(dependControl).removeAttr("disabled");
                                }
                            }
                        });
                    }
                }
            }
            //to validate text required fileds - End
            //to validate date -Begin
            var dateControls = $("#" + formName).find(".datepicker");
            if (dateControls != null) {
                for (var d = 0; d < dateControls.length; d++) {
                    var dateControl = dateControls[d];
                    var isChangeValidationEnabled = $(inputControl).attr(changevalidation);
                    $(dateControl).change(function () {
                        var dateDependControl = $(dateControl).attr("validatecontrol");
                        if (!jQuery.fn.Validation.validate.dateField($(dateControl).val())) {
                            $(dateControl).addClass("validationerror");
                            //to disable action
                            if (dateDependControl != null) {
                                $(dateDependControl).attr("disabled", "disabled");
                                $(dateDependControl).addClass("faiconDisabled");
                            }
                        } else {
                            $(dateControl).removeClass("validationerror");
                            if (dateDependControl != null) {
                                $(dateDependControl).removeAttr("disabled");
                            }
                        }
                    });
                }
            }
            //to validate date -end
        },
        //to bind form validation - End
        validateForm: function (formName) {
            //to validate mandatory fields
            var validationResult = true;
            var mandatoryControls = $("#" + formName).find('input.required'); //$("#" + formName).find('input[required="True"]');
            if (mandatoryControls != null) {
                for (var m = 0; m < mandatoryControls.length; m++) {
                    var mandatoryControl = mandatoryControls[m];
                    if (!jQuery.fn.Validation.validate.mandatoryText($(mandatoryControl).val())) {
                        $(mandatoryControl).addClass("validationerror").next(".validationResult").addClass("fa-exclamation-circle");
                        validationResult = false;

                        //to bind change validation
                        $(mandatoryControl).change(function () {
                            if (jQuery.fn.Validation.validate.mandatoryText($(this).val())) {
                                $(this).removeClass("validationerror").next(".validationResult").removeClass("fa-exclamation-circle").addClass("fa-check-circle");
                            }
                            else {
                                $(this).addClass("validationerror").next(".validationResult").addClass("fa-exclamation-circle").removeClass("fa-check-circle");
                            }
                        });
                    }
                }
            }

            var selectMandatoryFields = $("#" + formName).find('select.required'); //$("#" + formName).find('select[required="True"]');
            if (selectMandatoryFields != null) {
                for (var m = 0; m < selectMandatoryFields.length; m++) {
                    var selectMandatory = selectMandatoryFields[m];
                    if (!jQuery.fn.Validation.validate.selectFieldMandatory($(selectMandatory).val())) {
                        $(selectMandatory).addClass("validationerror").parent().next(".validationResult").addClass("fa-exclamation-circle");
                        //$(selectMandatory).attr('style', 'border:red 1px solid');
                        validationResult = false;
                    } else {
                        //$(selectMandatory).attr('style', '');
                    }

                    $(selectMandatory).change(function () {
                        if (jQuery.fn.Validation.validate.selectFieldMandatory($(this).val())) {
                            //$(this).attr('style', 'border:red 1px solid');
                            $(this).removeClass("validationerror").parent().next(".validationResult").removeClass("fa-exclamation-circle").addClass("fa-check-circle");
                        } else {
                            //$(this).attr('style', '');
                            $(this).addClass("validationerror").parent().next(".validationResult").addClass("fa-exclamation-circle").removeClass("fa-check-circle");
                        }
                    });
                }
            }

            //to validate date controls
            var dateControls = $("#" + formName).find(".datepicker");
            if (dateControls != null) {
                for (var d = 0; d < dateControls.length; d++) {
                    var dateControl = dateControls[d];
                    if (!jQuery.fn.Validation.validate.dateField($(dateControl).val())) {
                        $(dateControl).addClass("validationerror").next(".validationResult").addClass("fa-exclamation-circle");
                        validationResult = false;
                    }

                    //to bind change validation
                    $(dateControl).change(function () {
                        if (jQuery.fn.Validation.validate.dateField($(this).val())) {
                            $(this).removeClass("validationerror").next(".validationResult").removeClass("fa-exclamation-circle").addClass("fa-check-circle");
                        }
                        else {
                            $(this).addClass("validationerror").next(".validationResult").addClass("fa-exclamation-circle").removeClass("fa-check-circle");
                        }
                    });
                }
            }

            var dateTimeControls = $("#" + formName).find(".datePicker2");
            if (dateTimeControls != null) {
                for (var dt = 0; dt < dateTimeControls.length; dt++) {
                    var dateTimeControl = dateTimeControls[dt];
                    if (!jQuery.fn.Validation.validate.dateTimeField($(dateTimeControl).val())) {
                        $(dateTimeControl).addClass("validationerror");
                        validationResult = false;
                    }

                    //to bind change validation
                    $(dateTimeControl).change(function () {
                        if (jQuery.fn.Validation.validate.dateTimeField($(this).val())) {
                            $(this).removeClass("validationerror");
                        }
                        else {
                            $(this).addClass("validationerror");
                        }
                    });
                }
            }

            //to validate decimal fields
            var decimalControls = $("#" + formName).find(".decimalField");
            if (decimalControls != null) {
                $(decimalControls).each(function (index) {
                    if (!jQuery.fn.Validation.validate.decimalField($(this).val())) {
                        $(dateTimeControl).addClass("validationerror").next(".validationResult").addClass("fa-exclamation-circle");
                        validationResult = false;
                    }

                    $(this).change(function () {
                        if (jQuery.fn.Validation.validate.decimalField($(this).val())) {
                            $(this).removeClass("validationerror").next(".validationResult").removeClass("fa-exclamation-circle").addClass("fa-check-circle");
                        }
                        else {
                            $(this).addClass("validationerror").next(".validationResult").addClass("fa-exclamation-circle").removeClass("fa-check-circle");
                        }
                    });
                });
            }

            var startDate = $("#" + formName).find('.startDate').val();
            var endDate = $("#" + formName).find('.endDate').val();
            if ((startDate != null && startDate != '') || (endDate != null && endDate != '')) {
                if ($.fn.Validation.validate.ValidateStartEndDate(startDate, endDate)) {
                    $('.startDate,.endDate').removeClass('validationerror');
                } else {
                    $('.startDate,.endDate').addClass('validationerror');
                    validationResult = false;
                }
            }

            return validationResult;
        }
    }
    return plugin;
}($);