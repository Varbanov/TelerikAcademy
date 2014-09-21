/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/require.js" />
/// <reference path="httpRequestModule.js" />
/// <reference path="libs/sha1.js" />

(function () {
    require.config({
        paths: {
            'q': 'libs/q',
            'httpRequest': 'libs/httpRequestObject',
            'httpRequestModule': 'libs/httpRequestModule',
            'jquery': 'libs/jquery.min',
            'sammy': 'libs/sammy',
            'handlebars': 'libs/handlebars-v1.3.0',
            'underscore': 'libs/underscore',
            'datasorter': 'datasorter',
            'template-renderer': 'template-renderer',
        }
    })
})();

require(['jquery', 'sammy', 'httpRequestModule', 'datasorter', 'template-renderer'], function ($, sammy, httpRequestModule, datasorter, templateRenderer) {

    var url = 'http://jsapps.bgcoder.com/post';
    var app = sammy('#main', function () {
        this.get('#/', function () {

            httpRequestModule.getJson(url)
                .then(function (data) {
                    var sorted = datasorter(data, 'postDate');
                    templateRenderer(sorted, 'template', 'main');
                }, function (error) {
                    console.log('Error happened while connecting the server');
                })
        })

        this.get('#/register', function () {
            
            var userName = $('#name').val();
            var pass = $('#password').val();
            var user = {
                username: userName,
                authCode: CryptoJS.SHA1(userName + pass).toString(),
            }

            var url = 'http://jsapps.bgcoder.com/user/';

            httpRequestModule.postJson(url, user)
                .then(function () {
                    $('#result').html("Successfully registered user " + user.username);
                }, function (error) {
                    $('#result').html('Error while registering user: ' + user.username + " Type of error: " + JSON.parse(error).message);
                })
        });

        this.get('#/login', function () {
            var userName = $('#name').val();
            var pass = $('#password').val();
            var user = {
                username: userName,
                authCode: CryptoJS.SHA1(userName + pass).toString(),
            }

            var url = 'http://jsapps.bgcoder.com/auth/';

            httpRequestModule.postJson(url, user)
                .then(function (success) {
                    $('#result').html("Successfully logged in with user user " + user.username);
                    var data = JSON.parse(success);
                    sessionStorage.setItem('sessionKey', data.sessionKey);
                    sessionStorage.setItem('username', data.username);
                }, function (error) {
                    $('#result').html('Error while logging in user: ' + user.username + " Type of error: " + JSON.parse(error).message);
                })
        });

        this.get('#/post', function () {
            var url = 'http://jsapps.bgcoder.com/post/';

            var body = $('#message').val();
            var title = $('#title').val();
            var data = {
                title: title,
                body: body,
            };

            post(data, url);

            function post(data, url) {
                var def = $.Deferred();
                $.ajax({
                    url: url,
                    type: 'POST',
                    beforeSend: function (request) {
                        request.setRequestHeader("X-SessionKey", sessionStorage.sessionKey);
                    },

                    data: data,
                    success: function (data) {
                        def.resolve(data);
                    },
                    error: function (data) {
                        console.log(data);
                        def.reject(data);
                    }
                })
                return def.resolve();
            }
        });

        this.get('#/logout', function () {
            var url = 'http://jsapps.bgcoder.com/user/';

            post(url);

            function post(url) {
                var def = $.Deferred();
                $.ajax({
                    url: url,
                    type: 'PUT',
                    data: true,
                    headers: { "X-SessionKey": sessionStorage.sessionKey },
                    success: function (data) {
                        $('#result').html("Successfully logged out " + sessionStorage.username);
                        sessionStorage.clear();
                        def.resolve(data);
                    },
                    error: function (error) {
                        $('#result').html("Could not log out. Error type" + error);
                        def.reject(error);
                    }
                })
                return def.resolve();
            }
        });
    });

    app.run('#/');
});

require(['jquery', 'datasorter', 'template-renderer', 'httpRequestModule'], function ($, datasorter, templateRenderer, httpRequestModule) {
    $('.sorting input').on('click', function () {
        if ($(this).is(':checked')) {
            var that = $(this);
            httpRequestModule.getJson('http://jsapps.bgcoder.com/post')
                .then(function (data) {

                    var sorted, reversed;
                    debugger;

                    switch (that.val()) {
                        case '0':
                            sorted = datasorter(data, 'postDate');
                            break;
                        case '1':
                            sorted = datasorter(data, 'title');
                            break;
                        case '2':
                            sorted = datasorter(data, 'postDate');
                            reversed = datasorter(sorted, 'title', 1);
                            break;
                        case '3':
                            sorted = datasorter(data, 'postDate');
                            reversed = datasorter(sorted, 'title');
                            break;

                        default: throw ('invalid sorting type');
                            break;
                    }

                    $('#main').empty();
                    if (that.val() !== '2' && that.val() !== '3') {
                        templateRenderer(sorted, 'template', 'main');
                    } else {
                        templateRenderer(reversed, 'template', 'main');
                    }

                })


        }
    })

})
