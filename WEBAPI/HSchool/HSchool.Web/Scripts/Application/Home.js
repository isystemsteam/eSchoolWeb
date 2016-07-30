$(document).ready(function () {
    //bootstrap datetime picker
    var highestBox = 0;
    $('.column').each(function () {
        if ($(this).height() > highestBox) {
            highestBox = $(this).height();
        }
    });
    $('.column').height(highestBox);    
    $('.datepicker').datepicker({ format: 'dd/mm/yyyy', startDate: '-3d' });
});
