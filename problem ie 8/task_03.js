if (!document.querySelectorAll) {
           document.querySelectorAll = function(selector) {
               switch (selector[0]) {
                   case '#': return document.getElementById(selector.substr(1));
                       break;
                   case '.': return document.getElementsByClassName(selector.substr(1));
                       break;
                   default: return document.getElementsByName(selector.substr(1));
                       break;
               }
           }
       }

if (!document.querySelector) {
    document.querySelector = function (selector) {
        switch (selector[0]) {
            case '#': return document.getElementById(selector.substr(1))[0];
                break;
            case '.': return document.getElementsByClassName(selector.substr(1))[0];
                break;
            default: return document.getElementsByName(selector.substr(1))[0];
                break;
        }
    }
}