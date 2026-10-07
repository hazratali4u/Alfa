$(document).ready(function () {
    $('a.menu_class').click(function () {
        $('ul.the_menu').slideToggle('medium');

    });

    $('a.menu_class').blur(function () {
        $('ul.the_menu').slideToggle('medium');
    });

    $("#closelink").click(function () {
        $('ul.the_menu').slideToggle('medium');
    });
});