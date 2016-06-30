var applicationForm = {
    listBox: {
        show: function (obj) {
            $(obj).next(".ulListBox").show();
        },
        hide: function (obj) {
            if ($(obj).hasClass("liItem")) {
            } else {
                //$(obj).next(".ulListBox").hide();
            }
        },
        onSelect: function (obj) {
            var text = $(obj).text();
            var textBox = $(obj).parent(".ulListBox").prev(".txtValueBox");
            var hiddenBox = $(textBox).parent(".divListBox").prev(".hiddenListBox");
            $(textBox).val(text);
            $(hiddenBox).val(text);
            $(obj).parent(".ulListBox").hide();
        }
    },
    showList: function (obj) {
    },
    hideList: function (obj) {
    }
};