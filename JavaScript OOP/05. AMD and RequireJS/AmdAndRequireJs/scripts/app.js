/// <reference path="app.js" />
/// <reference path="handlebars-v1.3.0.js" />
/// <reference path="jquery-2.1.1.min.js" />
/// <reference path="require.js" />
(function () {
    require.config({
        paths: {
            'jquery': 'jquery-2.1.1.min',
            'handlebars': 'handlebars-v1.3.0',
        }
    })
    
})();

require(['controls', 'jquery', 'people'], function (controls, $, people) {
    var comboBox = new controls.ComboBox(people);
    var template = $("#template").html();
    var comboBoxHtml = comboBox.render(template);
    $('#container').html(comboBoxHtml);
});