var canvas = document.getElementById("canvas");
canvas.width = 600;
canvas.height = 400;
var ctx = canvas.getContext("2d");
var width = canvas.width;
var height = canvas.height;
ctx.fillStyle = "#92e933";
canvas.style.backgroundColor = "#d4dcd9";

var Direction = {
    RightUp: "RightUp",
    RightDown: "RightDown",
    LeftUp: "LeftUp",
    LeftDown: "LeftDown",
};

var radius = 10;
var currentX = radius;
var currentY = radius;
var currentDirection = Direction.RightDown;
var step = 3;

requestAnimationFrame(FlyEngine);

function FlyEngine() {
    ctx.clearRect(0, 0, width, height);
    ctx.beginPath();
    ctx.arc(currentX, currentY, radius, 0, 2 * Math.PI);
    ctx.fill();

    if (currentDirection == Direction.RightDown) {
        var updatedY = currentY + radius + step;
        var updatedX = currentX + radius + step;
        var inRangeX = updatedX >= 0 && updatedX <= width;
        var inRangeY = updatedY >= 0 && updatedY <= height;

        if (inRangeX && inRangeY) {
            currentX += step;
            currentY += step;
        } else if (!inRangeX) {
            currentDirection = Direction.LeftDown;
        } else if (!inRangeY) {
            currentDirection = Direction.RightUp;
        }

        requestAnimationFrame(FlyEngine);
    } else if (currentDirection == Direction.RightUp) {
        var updatedX = currentX + radius + step;
        var updatedY = currentY - radius - step;
        var inRangeX = updatedX >= 0 && updatedX <= width;
        var inRangeY = updatedY >= 0 && updatedY <= height;

        if (inRangeX && inRangeY) {
            currentX += step;
            currentY -= step;
        } else if (!inRangeX) {
            currentDirection = Direction.LeftUp;
        } else if (!inRangeY) {
            currentDirection = Direction.RightDown;
        }

        requestAnimationFrame(FlyEngine);
    } else if (currentDirection == Direction.LeftDown) {
        var updatedX = currentX - radius - step;
        var updatedY = currentY + radius + step;
        var inRangeX = updatedX >= 0 && updatedX <= width;
        var inRangeY = updatedY >= 0 && updatedY <= height;

        if (inRangeX && inRangeY) {
            currentX -= step;
            currentY += step;
        } else if (!inRangeX) {
            currentDirection = Direction.RightDown;
        } else if (!inRangeY) {
            currentDirection = Direction.LeftUp;
        }

        requestAnimationFrame(FlyEngine);
    } else if (currentDirection = Direction.LeftUp) {
        var updatedX = currentX - radius - step;
        var updatedY = currentY - radius - step;
        var inRangeX = updatedX >= 0 && updatedX <= width;
        var inRangeY = updatedY >= 0 && updatedY <= height;

        if (inRangeX && inRangeY) {
            currentX -= step;
            currentY -= step;
        } else if (!inRangeX) {
            currentDirection = Direction.RightUp;
        } else if (!inRangeY) {
            currentDirection = Direction.LeftDown;
        }

        requestAnimationFrame(FlyEngine);
    }
}