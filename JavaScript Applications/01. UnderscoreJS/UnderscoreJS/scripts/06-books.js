/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//06.By a given collection of books, find the most popular author (the author with the highest number of books)

define(['data/books', 'underscore'], function (books, _) {
    var groupedByAuthor = _.chain(books.books)
         .groupBy(function (book) {
             return book.author;
         })
         .max(function (group) {
             return group.length;
         })
         .value();

    //to fit the handlebars template
    var result = [];
    result.push(groupedByAuthor[0]);

    return {
        books: result,
        task: '06. By a given collection of books, find the most popular author (the author with the highest number of books)',
    };
})