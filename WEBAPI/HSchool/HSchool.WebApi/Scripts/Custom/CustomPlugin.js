//Plugin to disable the field
$.fn.disabled = function () {
    var settings = $.extend({

    });

    return this.each(function () {
        $(this).attr("disabled", "disabled");
    });
};

//edit animation
$.fn.editAnimate = function () {
    var settings = $.extend({
    });

    return this.each(function () {
        //Focus in action
        $(this).focusin(function () {
            $(this).prev('label').addClass('top-placeholder-text');
        });

        //Focus out action
        $(this).focusout(function () {
            if ($(this).val() == '' || $(this).val == null) {
                $(this).prev('label').removeClass('top-placeholder-text');
            }
        });

        //Default view
        if ($(this).val() != '' && $(this).val != null) {
            $(this).prev('label').addClass('top-placeholder-text');
        }
    });
};

//reset values
$.fn.resetInput = function () {
    var settings = $.extend({

    });

    return this.each(function () {
        $(this).val('');
    });
};