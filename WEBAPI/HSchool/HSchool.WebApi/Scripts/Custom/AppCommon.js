jQuery.fn.AppCommon = new function ($) {
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
                var data = $.fn.AppCommon.utility.createParameters(parameters);
                //to show ajax processing
                $(document).ajaxStart(function () {
                    $.fn.AppCommon.ajax.processing.show();
                }).ajaxStop(function () {
                    $.fn.AppCommon.ajax.processing.hide();
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
            post: function (uri, data, successcallback, errorcallback) {
            },
            //to bind form for ajax call
            bind: function (formName, beforecallback, successcallback, errorcallback, loading) {
                debugger
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
            }
        }
    }
    return plugin;
}($);