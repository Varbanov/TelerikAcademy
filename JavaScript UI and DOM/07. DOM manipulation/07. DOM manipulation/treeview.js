
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
    var lis = document.getElementsByTagName("li");
    for (var i = 0, len = lis.length; i < len; i++) {
        var tempChild = lis[i].firstElementChild;
        while (tempChild) {
            tempChild.style.display = "none";
            tempChild = tempChild.nextElementSibling;
        }

        lis[i].addEventListener('click', onClickExpandOrCollapse, false);
    }
})();

function onClickExpandOrCollapse(event) {
    //prevent from applying the function on all parent elements
    event.stopPropagation();
    var tempChild = this.firstElementChild;
    while (tempChild) {
        if (tempChild.style.display == 'none') {
            tempChild.style.display = 'block';
        }
        else {
            tempChild.style.display = 'none';
        }
        tempChild = tempChild.nextElementSibling;

    }

}
