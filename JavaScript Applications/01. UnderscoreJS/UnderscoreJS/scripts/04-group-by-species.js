/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//04. Write a function that by a given array of animals, groups them by species and sorts them by number of legs
define(['data/animals', 'underscore'], function (animals, _) {

    //solution
    var groupedAndSortedAnimals = _.chain(animals.animals)
        .sortBy(function (animal) {
            return animal.legs;
        }).groupBy(function (animal) {
            return animal.species;
        })
        .value();

    //just to fit the handlebars template
    var result = [];
    for (var group in groupedAndSortedAnimals) {
        
        for (var i = 0; i < groupedAndSortedAnimals[group].length; i++) {
            result.push(groupedAndSortedAnimals[group][i]);
        }
    }

    return {
        animals: result,
        task: '04. Write a function that by a given array of animals, groups them by species and sorts them by number of legs: ',
    };
})