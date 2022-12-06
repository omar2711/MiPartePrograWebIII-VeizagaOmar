var target;

$('.custom-select--collapse').on('change', function () {

    $('.custom-select--collapse option').each(function () {
        if ($(this).is(':selected')) {
            target = $(this).attr("data-target");
        }

        if ($(this).val() == "") {
            $(target).collapse('hide');
        } else {
            $(target).collapse('toggle');
        }
    });

    console.log("TARGET = " + target);
});