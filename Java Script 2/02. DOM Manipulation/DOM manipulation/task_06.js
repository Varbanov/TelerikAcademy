
//create nested html ul elements
(function CreateNestedElements() {
    var mainUl = document.createElement("ul");
    for (var i = 0; i < 5; i++) {
        var li = document.createElement("li");
        li.innerHTML = "Item " + (i + 1);
        if (i == 0) {
            var subUl = document.createElement("ul");
            for (var j = 0; j < 5; j++) {
                var subLi = document.createElement("li");
                subLi.innerHTML = "Sub-item " + (j + 1);

                if (j == 1) {
                    var subSubUl = document.createElement("ul");
                    for (var p = 0; p < 5; p++) {
                        var subSubLi = document.createElement("li");
                        subSubLi.innerHTML = "Sub-sub-item " + (p + 1);
                        subSubUl.appendChild(subSubLi)
                    }

                    subLi.appendChild(subSubUl);
                }

                subUl.appendChild(subLi)
            }

            li.appendChild(subUl);
        }

        mainUl.appendChild(li);
    }

    document.body.appendChild(mainUl);
})();

//solution
(function initialilyCollapseNestedDivs() {
    var nestedULs = document.querySelectorAll("li ul");
    for (var i = 0; i < nestedULs.length; i++) {
        nestedULs[i].style.display = "none";
        //nestedULs[i].setAttribute("data-expand", "none");
        nestedULs[i].parentNode.onclick = onClickExpandOrCollapse;
        var a = 6;
    }
})();

function onClickExpandOrCollapse(li) {
    
    var nestedElems = this.children;
    for (var i = 0, len = nestedElems.length; i < len; i++) {
        if (nestedElems[i] instanceof HTMLUListElement) {
            if (nestedElems[i].style.display == "none") {
                nestedElems[i].style.display = "block";
            }
            else {
                nestedElems[i].style.display = "none";
            }
        }
    }

}
