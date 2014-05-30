var canvas = document.getElementById("canvas");
canvas.width = 600;
canvas.height = 600;
var ctx = canvas.getContext("2d");

var Color = {
    Face: "#9dccd7",
    Cap: "#446d97",
    Black: "black",
    Bicycle: "#337d8f",
    House: "#975b5b",
}

//face
ctx.beginPath();
ctx.save();
ctx.scale(1, 0.9);
ctx.arc(100, 195, 65, 0, 2 * Math.PI);
ctx.restore();
ctx.fillStyle = Color.Face;
ctx.fill();
ctx.strokeStyle = Color.Cap;
ctx.stroke();
//eyes
ctx.lineWidth = 2;
ctx.beginPath();
ctx.save();
ctx.scale(1, 0.7);
ctx.arc(70, 215, 12, 0, 2 * Math.PI);
ctx.moveTo(132, 210);
ctx.arc(120, 215, 12, 0, 2 * Math.PI);
ctx.restore();
ctx.strokeStyle = Color.Black;
ctx.stroke();

ctx.beginPath();
ctx.save();
ctx.scale(0.5, 1);
ctx.arc(130, 151, 5, 0, 2 * Math.PI);
ctx.moveTo(235, 151);
ctx.arc(230, 151, 5, 0, 2 * Math.PI);
ctx.restore();
ctx.stroke();
ctx.fillStyle = Color.Black;
ctx.fill();
//nose
ctx.beginPath();
ctx.lineJoin = "round";
ctx.moveTo(95, 155);
ctx.lineTo(80, 185);
ctx.lineTo(95, 185);
ctx.stroke();
//mouth
ctx.beginPath();
ctx.save();
ctx.rotate(Math.PI / 20);
ctx.scale(1, 0.35);
ctx.arc(120, 550, 20, 0, Math.PI * 2);
ctx.restore();
ctx.stroke();
//cap platform
ctx.beginPath();
ctx.strokeStyle = Color.Black;
ctx.save();
ctx.scale(1, 0.2);
ctx.arc(95, 590, 67, 0, 2 * Math.PI);
ctx.restore();
ctx.fillStyle = Color.Cap;
ctx.fill();
ctx.stroke();
//cap cylinder
ctx.beginPath();
ctx.save();
ctx.scale(1, 0.4);
ctx.arc(100, 115, 35, 0, 2 *Math.PI);
ctx.restore();
ctx.save();
ctx.scale(1, 0.4);
ctx.arc(100, 265, 35, 0, Math.PI);
ctx.restore();
ctx.lineTo(65, 45);
ctx.moveTo(135, 100);
ctx.lineTo(135, 45);
ctx.fill();
ctx.stroke();

//bicycle
//tyres
ctx.beginPath();
ctx.lineWidth = 1.3;
ctx.strokeStyle = Color.Bicycle;
ctx.arc(300, 200, 33, 0, 2 * Math.PI);
ctx.moveTo(400, 200);
ctx.fillStyle = Color.Face;
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.arc(420, 200, 33, 0, 2 * Math.PI);
ctx.fill();
ctx.stroke();
//frame
ctx.beginPath();
ctx.moveTo(300, 200);
ctx.lineTo(346, 160);
ctx.moveTo(343, 148);
ctx.lineTo(355, 200);
ctx.lineTo(300, 200);
ctx.moveTo(330, 148);
ctx.lineTo(355, 148);
ctx.moveTo(346,160);
ctx.lineTo(410, 160);
ctx.moveTo(420, 200);
ctx.lineTo(405, 140);
ctx.lineTo(420, 125);
ctx.moveTo(405, 140);
ctx.lineTo(385, 145);
ctx.moveTo(355, 200);
ctx.lineTo(410, 160);
ctx.stroke();
//pedals
ctx.beginPath();
ctx.arc(355, 200, 8, 0, 2 * Math.PI);
ctx.moveTo(350, 195);
ctx.lineTo(344, 189);
ctx.moveTo(360, 205);
ctx.lineTo(366, 211);
ctx.stroke();

//house
ctx.strokeStyle = Color.Black;
ctx.fillStyle = Color.House;
ctx.lineWidth = 1.5;
ctx.beginPath();
ctx.fillRect(50, 400, 200, 160);
ctx.strokeRect(50, 400, 200, 160);
ctx.moveTo(50, 400);
ctx.lineTo(150, 280);
ctx.lineTo(250, 400);
ctx.closePath();
ctx.fill();
ctx.stroke();
//chimney
ctx.beginPath();
ctx.clearRect(190,315, 16,45);
ctx.moveTo(190, 360);
ctx.lineTo(190, 315);
ctx.lineTo(206, 315);
ctx.lineTo(206, 360);
ctx.fill();
ctx.stroke();
ctx.beginPath();
ctx.save();
ctx.scale(1, 0.3);
ctx.arc(198, 1050, 8, 0, 2 * Math.PI);
ctx.restore();
ctx.fill();
ctx.stroke();
//windows
ctx.beginPath();
ctx.fillStyle = Color.Black;
ctx.fillRect(65, 415, 70, 56);
ctx.moveTo(64, 443);
ctx.strokeStyle = Color.House;
ctx.lineTo(136, 443);
ctx.moveTo(100, 415);
ctx.lineTo(100, 471);
ctx.stroke();
var houseWindow = ctx.getImageData(65, 415, 70, 56);
ctx.putImageData(houseWindow, 155, 415);
ctx.putImageData(houseWindow, 155, 485);
//door
ctx.strokeStyle = Color.Black;
ctx.beginPath();
ctx.moveTo(70, 560);
ctx.lineTo(70, 505);
ctx.quadraticCurveTo(95, 480, 120, 505);
ctx.lineTo(120, 560);
ctx.moveTo(95, 560);
ctx.lineTo(95, 492);
ctx.stroke();

ctx.beginPath();
ctx.arc(87, 535, 3, 0, 2 * Math.PI);
ctx.stroke();
ctx.beginPath();
ctx.arc(103, 535, 3, 0, 2 * Math.PI);
ctx.stroke();






