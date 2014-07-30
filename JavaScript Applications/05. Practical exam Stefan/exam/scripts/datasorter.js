/// <reference path="libs/underscore.js" />

define(['underscore'], function (_) {
    var sorter = function (data, prop, order) {
        var sorted = _.chain(data)
                   .sortBy(function (item) {
                       if (prop.toLowerCase().indexOf('date')) {
                           var date = new Date(item.prop);
                           return date;
                       }
                       else {
                           return item.prop;
                       }

                   }).value();
        if (order) {
            var reversed = _.chain(sorted)
                .reverse()
                .value();
            return reversed;
        }

        return sorted;
    };

    return sorter;
})