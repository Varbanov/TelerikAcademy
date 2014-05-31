var canvas = document.getElementById("canvas");
canvas.width = 300;
canvas.height = 200;
var ctx = canvas.getContext("2d");
var Direction = {
    Right: "right",
    Left: "left",
    Up: "up",
    Down: "down",
};

var size = 7;
var snakeLength = 5;
var snake = new Snake(canvas, snakeLength, size);
var speed = 100;
var isEaten = false;
var foodColor = "#8303dc"
var food = createFood(canvas, size);
var score = 500;
var scoresDiv = document.getElementById("scores");
var bestDiv = document.getElementById("bestScores");
bestDiv.innerHTML = "Best score: " + (localStorage.getItem("bestName") || "Unknown") + " - " + (localStorage.getItem("bestScore") || 0);

var intervalId = setInterval(snakeEngine, speed);

function Snake(canvas, snakeLength, snakeSize) {
    var context = canvas.getContext("2d");
    var positionX = 0;
    var positionY = canvas.height / 2;
    var size = snakeSize;
    var snake = [snakeLength];
    var currentDirection = Direction.Right;

    //the snake itself is an array of particles
    for (var i = 0; i < snakeLength; i++) {
        snake[i] = new SnakeParticle(positionX, positionY);
        positionX += snakeSize;
    }
    //each particle is an object holding its coordinates
    function SnakeParticle(positionX, positionY) {
        this.positionX = positionX;
        this.positionY = positionY;
    }
    //each snake particle can print itself in the given context
    SnakeParticle.prototype.print = function (context, color) {
        context.beginPath();
        context.fillStyle = color;
        context.moveTo(this.positionX, this.positionY);
        context.arc(this.positionX, this.positionY, size, 0, 2 * Math.PI);
        context.fill();
    }

    return {
        snake: snake,
        currentDirection: currentDirection,
        print: function () {
            for (var i = 0; i < this.snake.length - 1; i++) {
                this.snake[i].print(context, "#d3aa38");
            }
            this.snake[this.snake.length - 1].print(context, "#555");
        },
        update: function () {
            for (var i = 0; i < this.snake.length - 1; i++) {
                this.snake[i].positionX = this.snake[i + 1].positionX;
                this.snake[i].positionY = this.snake[i + 1].positionY;
            }

            switch (this.currentDirection) {
                case Direction.Right:
                    this.snake[snake.length - 1].positionX += size;
                    break;
                case Direction.Down:
                    this.snake[snake.length - 1].positionY += size;
                    break;
                case Direction.Up:
                    this.snake[snake.length - 1].positionY -= size;
                    break;
                case Direction.Left:
                    this.snake[snake.length - 1].positionX -= size;
                    break;
            }
        },
        grow: function () {
            var growthPositionX;
            var growthPositionY;

            //check the direction in order to put the new particle after the head, but always in the current direction
            switch (this.currentDirection) {
                case Direction.Right:
                    growthPositionX = this.snake[this.snake.length - 1].positionX + size;
                    growthPositionY = this.snake[this.snake.length - 1].positionY;
                    break;
                case Direction.Down:
                    growthPositionY = this.snake[this.snake.length - 1].positionY + size;
                    growthPositionX = this.snake[this.snake.length - 1].positionX;
                    break;
                case Direction.Up:
                    growthPositionY = this.snake[this.snake.length - 1].positionY - size;
                    growthPositionX = this.snake[this.snake.length - 1].positionX;
                    break;
                case Direction.Left:
                    growthPositionX = this.snake[this.snake.length - 1].positionX - size;
                    growthPositionY = this.snake[this.snake.length - 1].positionY;
                    break;
            }

            var particle = new SnakeParticle(growthPositionX, growthPositionY);
            this.snake.push(particle);
        },
    }
}

function snakeEngine() {
    scoresDiv.innerHTML = "Your score: " + score;
    var headX = snake.snake[snake.snake.length - 1].positionX;
    var headY = snake.snake[snake.snake.length - 1].positionY;
    var inRangeHeadX = headX >= 0 && headX <= canvas.width;
    var inRangeHeadY = headY >= 0 && headY <= canvas.height;

    if (!(inRangeHeadX && inRangeHeadY) || isEaten) {
        //game over
        writeGameover(ctx);
        saveHighestScore(score, name);
        bestDiv.innerHTML = "Best score: " + (localStorage.getItem("bestName") || "Unknown") + " - " + (localStorage.getItem("bestScore") || 0);
        clearInterval(intervalId);
        return;
    }

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    snake.print();
    food.print();
    var squareDistanceToFood = (headX - food.positionX) * (headX - food.positionX) + (headY - food.positionY) * (headY - food.positionY);

    if (squareDistanceToFood <= size * size) {
        //if the center of the snake head hits the food, move the food, get more scores and grow up
        food.positionX = generateRndNum(size, canvas.width - size / 2);
        food.positionY = generateRndNum(size, canvas.height - size / 2);
        snake.grow();
        score += 20;
    }

    document.onkeydown = checkKey;

    function checkKey(e) {
        e = e || window.event;

        if (e.keyCode == '38') {
            if (snake.currentDirection == Direction.Down) {
                isEaten = true;
            }

            snake.currentDirection = Direction.Up;
        } else if (e.keyCode == '40') {
            if (snake.currentDirection == Direction.Up) {
                isEaten = true;
            }

            snake.currentDirection = Direction.Down;
        } else if (e.keyCode == '37') {
            if (snake.currentDirection == Direction.Right) {
                isEaten = true;
            }

            snake.currentDirection = Direction.Left;
        } else if (e.keyCode == '39') {
            if (snake.currentDirection == Direction.Left) {
                isEaten = true;
            }

            snake.currentDirection = Direction.Right;
        }
    }

    snake.update();
}

//generate food sample
function createFood(canvas, size) {
    var positionX = generateRndNum(size / 2, canvas.width - size / 2);
    var positionY = generateRndNum(size / 2, canvas.height - size / 2);
    var context = canvas.getContext("2d");
    return {
        positionX: positionX,
        positionY: positionY,
        print: function () {
            context.beginPath();
            context.fillStyle = foodColor;
            context.moveTo(this.positionX, this.positionY);
            context.arc(this.positionX, this.positionY, size, 0, 2 * Math.PI);
            context.fill();
        }
    }
}

function saveHighestScore(currentScore) {
    var bestScore = localStorage.getItem("bestScore") || 0;

    if (currentScore > bestScore) {
        var name = prompt("Congratulations! You are the best so far. Please enter your name:");
        localStorage.setItem("bestScore", currentScore);
        localStorage.setItem("bestName", name);
    }
}

function writeGameover(context) {
    context.strokeStyle = "red";
    context.lineWidth = 2;
    ctx.font = "30px Arial";
    ctx.strokeText("GAME OVER", 50, 100);
}

//auxiliary function to generate random integers in a range
function generateRndNum(min, max) {
    var num = Math.floor(Math.random() * (max - min + 1)) + min;
    return num;
}