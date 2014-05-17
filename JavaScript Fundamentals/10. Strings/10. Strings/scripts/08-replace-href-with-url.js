var input = '<p>Please visit <a  href="http://academy.telerik.com" >our site</ a  > to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

function replaceHref(txt) {
    var regex = new RegExp('<\\s*a\\s*href="(.*?)".*?>(.*?)</\\s*a\\s*>');
    var match = txt.match(regex);
    while (match != null) {
        //while regex matches are found, replace them and search for a next match
        var temp = "[URL=" + match[1] + "]" + match[2] + "[/URL]";
        txt = txt.replace(match[0], temp);
        match = txt.match(regex);
    }

    return txt;
}

var replaced = replaceHref(input);
jsConsole.writeLine(replaced);