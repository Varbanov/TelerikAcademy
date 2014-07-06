var movingShapes = (function () {
    var DIV_SIZE = 40;
    var div_count = 1;

    function add(movementType, centerX, centerY, radiusOrWidth, height) {
        var div = createDiv();

        if (movementType === 'ellipse') {
            setEllipseDiv(div);
            updatePosition("ellipse", div);
            document.body.appendChild(div);
            drawCircle();
        }
        else if (movementType === "rectangle") {
            setRectangleDiv(div);
            updatePosition("rectangle", div);
            document.body.appendChild(div);
            drawRectangle();
        }
        else {
            //some exception to be thrown
            alert("Invalid movement type!");
        }

        //engine to execute the updatePosition function infinitely
        (function engine(e) {
            timer = setInterval(function () {
                if (movementType === 'ellipse') {
                    updatePosition("ellipse", div);
                }
                else {
                    updatePosition("rectangle", div);
                }

            }, 30);
        })();

        //initialize a div, set its common attributes and return it
        function createDiv() {
            var div = document.createElement('div');
            var inner = document.createElement("span");
            inner.style.color = generateColor(0, 15);
            inner.innerHTML = div_count++;
            div.appendChild(inner);
            div.style.textAlign = "center";
            div.style.width = DIV_SIZE + "px";
            div.style.height = DIV_SIZE + "px";
            div.style.position = "absolute";
            div.style.border = "1px solid" + generateColor(0, 15);
            div.style.backgroundColor = generateColor(4, 15);

            return div;
        }

        //set ellipse div specific atrributes
        function setEllipseDiv(div) {
            div.className = "ellipse";
            var initialAngle = generateRndNum(0, 360);
            div.setAttribute('data-angle', initialAngle);
            div.style.borderRadius = "50%";
        }

        //set rectangle div specific atrributes
        function setRectangleDiv(div) {
            div.className = "rectangle";
            var upperWallY = parseInt(centerY - height / 2);
            var lowerWallY = parseInt(centerY + height / 2);
            var leftWallX = parseInt(centerX - radiusOrWidth / 2);
            var rightWallX = parseInt(centerX + radiusOrWidth / 2);

            //randomly choose a wall to start from
            //each div also knows its position (x and y) and direction
            var initialWall = generateRndNum(1, 4);
            var secondCoordinate;
            if (initialWall === 1) {
                div.setAttribute("direction", "right");
                div.setAttribute("yPosition", upperWallY);
                secondCoordinate = generateRndNum(leftWallX, rightWallX);
                div.setAttribute("xPosition", secondCoordinate);
            }
            else if (initialWall === 2) {
                div.setAttribute("direction", "down");
                div.setAttribute("xPosition", rightWallX);
                secondCoordinate = generateRndNum(upperWallY, lowerWallY);
                div.setAttribute("yPosition", secondCoordinate);
            }
            else if (initialWall === 3) {
                div.setAttribute("direction", "left");
                div.setAttribute("yPosition", lowerWallY);
                secondCoordinate = generateRndNum(leftWallX, rightWallX);
                div.setAttribute("xPosition", secondCoordinate);
            }
            else if (initialWall === 4) {
                div.setAttribute("direction", "up");
                div.setAttribute("xPosition", leftWallX);
                secondCoordinate = generateRndNum(upperWallY, lowerWallY);
                div.setAttribute("yPosition", secondCoordinate);
            }
            else {
                //exception
            }
        }

        //update position function
        function updatePosition(movementType, div) {
            if (movementType === "ellipse") {
                (function () {
                    var angleSoFar = parseInt(div.getAttribute("data-angle"));
                    var y = radiusOrWidth * Math.sin(((angleSoFar + 1) * Math.PI) / 180) + centerY;
                    var x = radiusOrWidth * Math.cos(((angleSoFar + 1) * Math.PI) / 180) + centerX;
                    div.setAttribute("data-angle", ++angleSoFar);
                    div.style.top = parseInt((y - DIV_SIZE / 2)) + "px";
                    div.style.left = parseInt((x - DIV_SIZE / 2)) + "px";
                })();
            }
            else if (movementType === "rectangle") {
                divX = div.getAttribute("xPosition");
                divY = div.getAttribute("yPosition");
                divDirection = div.getAttribute("direction");

                if (divDirection === "right") {
                    if (divX < parseInt(centerX + radiusOrWidth / 2)) {
                        //if right wall is not reached yet
                        div.setAttribute("xPosition", ++divX);
                    }
                    else {
                        div.setAttribute("yPosition", ++divY);
                        div.setAttribute("direction", "down");
                    }
                }
                else if (divDirection === "down") {
                    if (divY < parseInt(centerY + height / 2)) {
                        //if down wall is not reached yet
                        div.setAttribute("yPosition", ++divY);
                    }
                    else {
                        div.setAttribute("xPosition", --divX);
                        div.setAttribute("direction", "left");
                    }
                }
                else if (divDirection === "left") {
                    if (divX > parseInt(centerX - radiusOrWidth / 2)) {
                        //if left wall is not reached yet
                        div.setAttribute("xPosition", --divX);
                    }
                    else {
                        div.setAttribute("yPosition", --divY);
                        div.setAttribute("direction", "up");
                    }
                }
                else if (divDirection === "up") {
                    if (divY > parseInt(centerY - height / 2)) {
                        //if left wall is not reached yet
                        div.setAttribute("yPosition", --divY);
                    }
                    else {
                        div.setAttribute("xPosition", ++divX);
                        div.setAttribute("direction", "right");
                    }
                }
                div.style.top = divY + "px";
                div.style.left = divX + "px";
            }
        }

        //draw circle div
        function drawCircle() {
            var div = document.createElement("div");
            var style = div.style;
            style.border = "1px solid black";
            style.width = 2 * radiusOrWidth + "px";
            style.height = 2 * radiusOrWidth + "px";
            style.position = "absolute";
            style.top = centerY - radiusOrWidth + "px";
            style.left = centerX - radiusOrWidth + "px";
            style.borderRadius = "50%";
            document.body.appendChild(div);
        }

        //draw rectangle div
        function drawRectangle() {
            var top = parseInt(centerY - height / 2 + (DIV_SIZE / 2));
            var left = parseInt(centerX - radiusOrWidth / 2 + (DIV_SIZE / 2));
            var div = document.createElement("div");
            var style = div.style;
            style.border = "1px solid black";
            style.width = radiusOrWidth + "px";
            style.height = height + "px";
            style.position = "absolute";
            style.top = top + "px";
            style.left = left + "px";
            document.body.appendChild(div);
        }
    }

    //auxiliary function to generate random integers in a range
    function generateRndNum(min, max) {
        var num = Math.floor(Math.random() * (max - min + 1)) + min;
        return num;
    }

    //auxiliary function to generate random colors in a range
    function generateColor(min, max) {
        var color = "#";
        var chars = "0123456789ABCDEF".split('');
        for (var i = 0; i < 6; i++) {
            color += chars[generateRndNum(min, max)];
        }
        return color;
    }

    return {
        add: add,
    }
})();

//extra function for the html input button
function addEllipse() {
    var center = document.getElementById("center").value.split(" ");
    var radius = parseInt(document.getElementById("radiusOrWidth").value);
    movingShapes.add("ellipse", parseInt(center[0]), parseInt(center[1]), radius);

}

//extra function for the html input button
function addRectangle() {
    var center = document.getElementById("center").value.split(" ");
    var radius = parseInt(document.getElementById("radiusOrWidth").value);
    var height = parseInt(document.getElementById("height").value);
    movingShapes.add("rectangle", parseInt(center[0]), parseInt(center[1]), radius, height);

}

//test
movingShapes.add("ellipse", 600, 350, 100, 50);
movingShapes.add("ellipse", 220, 300, 80, 160);
movingShapes.add("rectangle", 100, 500, 100, 190);