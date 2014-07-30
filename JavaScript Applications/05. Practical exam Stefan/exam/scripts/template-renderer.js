define(function () {
    var renderer = function (data, template, container) {
        var templateHtml = document.getElementById(template).innerHTML;
        var compiledTemplate = Handlebars.compile(templateHtml);
        var container = document.getElementById(container);
        container.innerHTML = compiledTemplate({ data: data });
    }

    return renderer;
});