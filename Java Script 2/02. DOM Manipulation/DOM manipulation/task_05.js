var tags = ["cms", "cms", "cms", "javascript", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"]
var tagCloud = generateTagCloud(tags, 17, 30);

document.body.appendChild(tagCloud);

function generateTagCloud(tagArr, min, max) {
    //convert font range to [0.. max-min]
    max -= min;

    //count occurence
    var dict = {};
    var maxOccurence = 0;
    for (var i = 0, tagsLen = tagArr.length; i < tagsLen; i++) {
        tagArr[i] = tagArr[i].toLocaleLowerCase();
        if (dict[tags[i]]) {
            dict[tags[i]]++;
        }
        else {
            dict[tags[i]] = 1;
        }
        if (dict[tags[i]] > maxOccurence) {
            maxOccurence = dict[tags[i]];
        }
    }

    //create a tagCloud div
    var div = document.createElement("div");
    div.style.width = "200px";

    //make maxOccurence zero-based [0... maxOccurence -1]
    maxOccurence--;
    //append spans with proportional font sizes in the range [min..max] to the tagCloud
    for (var key in dict) {
        if (dict.hasOwnProperty(key)) {
            var font = min + Math.round((max / maxOccurence) * (dict[key] - 1));
            var span = document.createElement("span");
            span.style.fontSize = font + "px";
            span.innerHTML = key + " ";
            div.appendChild(span);
        }
    }

    return div;
}

