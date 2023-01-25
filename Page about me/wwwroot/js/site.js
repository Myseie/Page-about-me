document.addEventListener("DOMContentLoaded", () => {
    var aboutBox = document.getElementById("about-box");
    aboutBox.addEventListener("click", colorChange);
})
function colorChange() {
    document.getElementById("about-box").style.color = "red";
}