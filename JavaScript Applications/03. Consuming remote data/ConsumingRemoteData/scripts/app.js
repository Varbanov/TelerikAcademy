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


function showCountries(countries) {
    var fragment = document.createDocumentFragment();
    var div = document.createElement('div');
    var i;

    for (i = 0; i < countries.length; i++) {
        div.innerHTML = countries[i].name;
        fragment.appendChild(div.cloneNode(true));
    }

    document.body.appendChild(fragment);
};

require(['httpRequestModule', 'q'], function (httpRequestModule, Q) {
    var urlOfCountries = 'https://gist.githubusercontent.com/Keeguon/2310008/raw/865a58f59b9db2157413e7d3d949914dbf5a237d/countries.json';

    var countries = httpRequestModule.getJson(urlOfCountries);
    //.then(showCountries)
    //.done();



    var p = 1;
    for (var i = 0; i < 10000000; i++) {
        p++;
    }

    debugger;


});

