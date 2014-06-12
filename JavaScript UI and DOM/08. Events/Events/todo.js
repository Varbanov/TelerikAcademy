/// <reference path="jquery-2.1.1.min.js" />
var $addBtn = $('#add');
var removeBtn = $('#remove');
var $deleteBtn = $('#delete');
var $hideBtn = $('#hide');
var $showBtn = $('#show');
$addBtn.on('click', onAddClick);
$deleteBtn.on('click', onDeleteClick);
$hideBtn.on('click', onHideClick);
$showBtn.on('click', onShowClick);

function onAddClick() {
    var $input = $('input').val();
    if ($input.trim() != "") {
        var $elem = $('<a />')
            .attr('href', '#')
            .html($input)
        .on('click', function (event) {
            $(event.target).toggleClass('selected');
        });

        $(document.body).append($elem);
    }
}

function onDeleteClick() {
    $('.selected').remove();
}

function onHideClick() {
    $('.selected').hide();
    $('.selected').toggleClass('selected');
}

function onShowClick() {
    $('a').show();
}






