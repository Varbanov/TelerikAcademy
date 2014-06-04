if (!document.querySelector || !document.querySelectorAll) {
    document.querySelectorAll = function (query) {
        if (query[0] === '#') {
            return document.getElementById(query.substr(1));
        }
        else if (query[0] === '.') {
            return document.getElementsByClassName(query.substr(1));
        }
        else {
            return document.getElementsByTagName(query);
        }
    }

    document.querySelector = function (query) {
        return document.getElementById(query.substr(1));
    }

    //shim getElementsByClassName
    document.getElementsByClassName = function (nameOfClass) {
        var result = [];
        var elem = this.getElementsByTagName('*');
        for (var i = 0, len = elem.length; i < len; i++) {
            if ((' ' + elem[i].className + ' ').indexOf(' ' + nameOfClass + ' ') > -1) result.push(elem[i]);
        }
        return result;
    };
}

var elementById = document.querySelector("#id").innerHTML;
console.log(elementById);