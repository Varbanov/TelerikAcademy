/// <reference path="../libraries/jquery-2.1.1.min.js" />

$('#after').click({ param1: $('#the-div'), param2: $('#input').val() }, insertAfter);
$('#before').click({ param1: $('#the-div'), param2: $('#input').val() }, insertBefore);

function insertAfter(event) {
    var $element = event.data.param1;
    var input = event.data.param2;
    $element.after($('#input').val());
}

function insertBefore(event) {
    var $element = event.data.param1;
    var input = event.data.param2;
    $element.before($('#input').val());
}