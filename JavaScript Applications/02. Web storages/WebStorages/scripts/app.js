/// <reference path="libs/require.js" />
/// <reference path="libs/jquery.min.js" />

(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery.min',
            'number': 'random-number-generator',
            'validator': 'input-validator',
            'winLogic': 'on-win-logic',
            'underscore': 'libs/underscore',
            'handlebars': 'libs/handlebars-v1.3.0',
        }
    })
})();

require(['jquery', 'number', 'validator', 'winLogic'], function ($, number, validator, winLogic) {

    var currentScores = 0;
    var scoresContainer = '#scoresTable';

    //localStorage.clear();

    $('#messageBox').html('Please enter a 4-digit number with different digits (1000-9999)');

    $('#input').on('input', function () {
        $('#num').html(number);
        var guessNumber = $(this).val();
        var digits = {};
        var i;
        var j;
        var bulls = 0;
        var cows = 0;

        if (!validator(guessNumber)) {
            $('#messageBox').html('Invalid input. Please enter a 4-digit number with different digits (1000-9999)');
            return;
        }

        currentScores += 1;

        if (guessNumber === number) {
            winLogic(currentScores, 'scoresTable', 'template');
            currentScores = 0;
        }

        for (i = 0; i < number.length; i++) {
            if (number[i] === guessNumber[i]) {
                bulls++;
            } else {
                for (j = 0; j < number.length; j++) {
                    if (guessNumber[i] === number[j]) {
                        cows++;
                    }
                }
            }
        }

        $('#messageBox').html('bulls: ' + bulls + ' cows: ' + cows);
    })
})