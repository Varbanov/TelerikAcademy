var url = "http://www.devbg.org/forum/index.php";

function extractHtml(input) {
    var regex = new RegExp("(.+)://(.+?)(/.*)");
    var match = input.match(regex);

    var res = {
        protocol: match[1],
        server: match[2],
        resource: match[3],
    }
    return res;
}

var res = extractHtml(url);
for (var i in res) {
    jsConsole.writeLine(res[i]);
}