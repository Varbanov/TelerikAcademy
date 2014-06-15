/// <reference path="jquery-2.1.1.min.js" />
var data = fillData();

(function slider(data, width, height) {
    var current = 0;

    var $container = $('<div/>')
        .css('width', width)
        .css('height', height)
        .css('border', '1px solid black')
        .css('background-color', '#eaeaea')
        .css('border-radius', 20)
        .css('position', 'relative')


    var $leftArrow = $('<img/>')
        .attr('src', 'left.png')
        .attr('width', 40)
        .css('position', 'relative')
        .css('top', 180)
        .css('left', 20)
        .appendTo($container)
        .on('click', function () {
            current--;
            if (current < 0) {
                current = data.length - 1;
            }
            $('.content').html(data[current]);
        })

    var $rightArrow = $('<img/>')
        .attr('src', 'right.png')
        .attr('width', 40)
        .css('position', 'relative')
        .css('top', 180)
        .css('left', 500)
        .appendTo($container)
        .on('click', function () {
            current++;
            current = current % data.length;
            $('.content').html(data[current]);
        })

    var $content = $('<div/>')
        .addClass('content')
        .css('position', 'relative')
        .css('width', 440)
        .css('height', 386)
        .css('top', -40)
        .css('left', 80)
        .css('border', '1px solid black')
        .css('text-align', 'center')
        .css('vertical-align', 'middle')
        .html(data[current])
        .appendTo($container);

    //$($content.html())
    //    .css('position', 'relative')
    //    .css('left', 0)
    //    .css('right', 0)
    //    .css('top', 0)
    //    .css('bottom', 0)
    //    .css('margin', 'auto')

    $('img')
     .css('position', 'relative')
        .css('left', 0)
        .css('right', 0)
        .css('top', 0)
        .css('bottom', 0)
        .css('margin', 'auto')



    $(document.body).append($container);

})(data, 600, 400);

function fillData() {
    var data = [];

    var imageUrls = [
        'http://www.webdesignmash.com/trial/wp-content/uploads/2010/09/colourful-autumn-photography-04.jpg',
        'http://personal.psu.edu/tao5048/JPG.jpg',
        'http://upload.wikimedia.org/wikipedia/commons/c/c9/Moon.jpg',
        'http://asterisk.apod.com/download/file.php?id=7077&sid=fc1b7c80061296fa0867afdb245669e6&mode=view'
    ];

    for (var i = 0; i < imageUrls.length; i++) {
        var img = $('<img/>')
            .attr('src', imageUrls[i]).attr('width', '200px')
        data.push(img);
    }

    var div = $('<div/>').text("The div");
    data.push(div);
    var anchor = $('<a>Weather<a/>')
        .attr('href', '#');
    data.push(anchor);

    var table = '<table border="1"><tr><th colspan="3">Title goes here</th><td>A</td><td>B</td></tr><tbody><tr><td rowspan="3">C</td><td>D</td><td>E</td><td>F</td><td>G</td></tr><tr><td>H</td><td colspan="2">I</td><td rowspan="2">J</td></tr><tr><td>K</td><td>L</td><td>M</td></tr><tr><td>N</td><td colspan="4">O</td></tr></tbody></table>';
    data.push(table);
    return data;
}
