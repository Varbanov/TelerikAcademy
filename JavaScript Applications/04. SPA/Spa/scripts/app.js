/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/require.js" />
/// <reference path="httpRequestModule.js" />

(function () {
    require.config({
        paths: {
            'q': 'libs/q',
            'httpRequest': 'libs/httpRequestObject',
            'httpRequestModule': 'libs/httpRequestModule',
            'jquery': 'libs/jquery.min',
            'sammy': 'libs/sammy',
            'handlebars': 'libs/handlebars-v1.3.0',
        }
    })
})();

require(['jquery', 'sammy', 'httpRequestModule'], function ($, sammy, httpRequestModule) {

    var url = 'http://jsapps.bgcoder.com/post';
    var app = sammy('#main', function () {
        this.get('#/', function () {

            httpRequestModule.getJson(url)
                .then(function (data) {
                    var template = document.getElementById('template').innerHTML;
                    var compiledTemplate = Handlebars.compile(template);
                    console.log('asfnhas');
                    var container = document.getElementById('main');
                    container.innerHTML = compiledTemplate({ data: data });

                }, function (error) {
                    console.log('Error happened while connecting the server');
                })
        })

        this.get('#/post', function () {
            var messageData = {
                user: $('#name').val(),
                text: $('#message').val(),
            }

            httpRequestModule.postJson(url, messageData)
                .then(function())
        });


    });

    app.run('#/');
});
