/// <reference path="libs/q.js" />

define(['httpRequest', 'q'], function (httpRequest, Q) {
    var makeRequest = function (options) {

        //options
        options = options || {};

        var requestUrl = options.url;
        var type = options.type || 'GET';
        var success = options.success || function () {
        };
        var error = options.error || function () {
        };
        var contentType = options.contentType || '';
        var accept = options.accept || '';
        var data = options.data || null;

        //set request event
        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState === 4) {
                switch (Math.floor(httpRequest.status / 100)) {
                    case 2:
                        success(httpRequest.responseText);
                        break;
                    default:
                        error(httpRequest.responseText);
                        break;
                }
            }
        };

        //request
        httpRequest.open(type, requestUrl, true);
        httpRequest.setRequestHeader('Content-Type', contentType);
        httpRequest.setRequestHeader('Accept', accept);

        return httpRequest.send(data);
    };

    //postJSON interface
    postJson = function (url, jsonObj) {
        var deferred = Q.defer();
        var options = {
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(jsonObj),
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (result) {
                deferred.reject(result);
            }
        };

        makeRequest(options);
        return deferred.promise;
    }

    //getJSON interface
    getJson = function (url) {
        var deferred = Q.defer();
        var options = {
            url: url,
            contentType: 'application/json',
            success: function (result) {
                var jsonResult = JSON.parse(result);
                deferred.resolve(jsonResult);
            },
            error: function (result) {
                deferred.reject(result);
            }
        };

        makeRequest(options);
        return deferred.promise;
        //return options.success();
    }

    return {
        getJson: getJson,
        postJson: postJson,
    }
});
