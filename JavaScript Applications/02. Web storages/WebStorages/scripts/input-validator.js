define(function () {
    var validator = function (guessNumber) {
        var i;
        guessNumberToInt = parseInt(guessNumber);

        if (guessNumber.length !== 4 || isNaN(guessNumberToInt) || guessNumberToInt < 1000 || guessNumberToInt > 9999) {
            return false;
        }

        var digits = {};
        for (i = 0; i < guessNumber.length; i++) {
            if (digits[guessNumber[i]]) {
                return false;
            } else {
                digits[guessNumber[i]] = true;
            }
        }

        return true;
    }

    return validator;
})