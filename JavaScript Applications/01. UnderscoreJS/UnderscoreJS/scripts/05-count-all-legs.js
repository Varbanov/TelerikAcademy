/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//05.By a given array of animals, find the total number of legs. Each animal can have 2, 4, 6, 8 or 100 legs

define(['data/animals', 'underscore'], function (animals, _) {

    var legs = _.reduce(animals.animals, function(memo, animal){ 
        return memo + animal.legs; 
    }, 0);


    //fit the handlebars template
    var result = [];
    result.push({ legs: legs });

    return {
        animals: result,
        task: '05.By a given array of animals, find the total number of legs. Each animal can have 2, 4, 6, 8 or 100 legs: ',
    };
})