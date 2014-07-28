﻿define(function () {
    var httpRequest = (function () {
        var xmlHttpFactories;
        xmlHttpFactories = [
            function () {
                return new XMLHttpRequest();
            },
            function () {
                return new ActiveXObject("Msxml3.XMLHTTP");
            },
            function () {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            },
            function () {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            },
            function () {
                return new ActiveXObject("Msxml2.XMLHTTP");
            },
            function () {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        ];
        return function () {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();


    return httpRequest();
});