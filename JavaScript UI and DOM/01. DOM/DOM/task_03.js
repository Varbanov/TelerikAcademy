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
}
