// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
//var elem = document.getElementById("labErr");
//alert

// Write your JavaScript code.

var logBtn = document.getElementById("logBtn");

logBtn.onclick = function () {
    var login = document.getElementById("loginInput");
    var pass = document.getElementById("passwordInput");
    alert(login.value);
}

