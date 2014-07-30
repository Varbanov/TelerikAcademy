/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/q.js" />
/// <reference path="libs/require.js" />
/// <reference path="httpRequestModule.js" />

//Create a module that exposes methodsfor performing HTTP requests
//by given URL and headers - getJSON and postJSON. 
//Both methods should work with promises.

(function () {
    require.config({
        paths: {
            'q': 'libs/q',
            'httpRequest': 'httpRequestObjectCreator',
            'httpRequestModule': 'httpRequestModule',
        }
    })
})();

require(['httpRequestModule'], function (httpRequestModule) {

    var africanCountriesUrl = 'http://restcountries.eu/rest/v1/region/africa';

    httpRequestModule.getJson(africanCountriesUrl)
        .then(showCountries);
});

function showCountries(countries) {
    var fragment = document.createDocumentFragment();
    var i;
    var div = document.createElement('div');

    for (i = 0; i < countries.length; i++) {
        div.innerHTML = countries[i].name;
        fragment.appendChild(div.cloneNode(true));
    }

    document.body.appendChild(fragment);
};