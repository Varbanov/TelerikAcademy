function OnCheckBtnClick() {
    var txt = document.getElementById("area");
    txt.innerHTML = "This is a text area."
    txt.style.backgroundColor = document.getElementById("background").value;
    txt.style.color = document.getElementById("font").value;
}