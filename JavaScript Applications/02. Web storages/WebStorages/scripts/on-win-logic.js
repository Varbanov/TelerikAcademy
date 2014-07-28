define(['underscore', 'handlebars'], function (_, handlebars) {
    var onWin = function (currentScore, containerSelector, templateSelector) {
        var highscoreTable = parseLocalStorage();
        var minScore;
        var name;
        var container;
        var template;

        highscoreTable = _.chain(highscoreTable)
            .sortBy(function (winner) {
                return winner.scores;
            })
            .value();

        if (highscoreTable.length >= 10) {
            minScore = highscoreTable[9].scores;
        } else if (highscoreTable.length > 0) {
            minScore = highscoreTable[highscoreTable.length - 1].scores;
        } else {
            minScore = 100000000;
        }

        debugger;

        if (currentScore <= minScore) {
            name = prompt('You won!\nPlease enter your name:');
            if (highscoreTable.length >= 10) {
                localStorage.removeItem(highscoreTable[highscoreTable.length - 1].name);
            }

            localStorage.setItem(name, currentScore);
        } else {
            alert('You won! Still you are not so good to be in the Highscore Table')
        }

        //show highscore table
        highscoreTable = _.chain(parseLocalStorage())
            .sortBy(function (winner) {
                return winner.scores;
            })
            .value();

        template = document.getElementById(templateSelector).innerHTML;
        var compiledTemplate = Handlebars.compile(template);

        var container = document.getElementById(containerSelector);

        container.innerHTML = compiledTemplate({ winner: highscoreTable });


    }

    function parseLocalStorage() {
        var highscoreTable = [];
        for (var entry in localStorage) {
            var winner = {
                name: entry,
                scores: localStorage[entry] * 1,
            };

            highscoreTable.push(winner);
        }

        return highscoreTable;
    }

    return onWin;
})