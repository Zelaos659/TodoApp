// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
//var elem = document.getElementById("labErr");
//alert

// Write your JavaScript code.

//var logBtn = document.getElementById("logBtn");

//logBtn.onclick = function () {
//    var login = document.getElementById("loginInput");
//    var pass = document.getElementById("passwordInput");
//    alert(login.value);
//}

function Login() {
    var login = document.getElementById("loginInput");
    var pass = document.getElementById("passwordInput");
    alert(login.value);
}

function Show(a) {
    allTasks = document.getElementById("AllTasks");
    endedTasks = document.getElementById("EndedTasks");
    if (a) {
        allTasks.classList.add("visually-hidden");
        endedTasks.classList.remove("visually-hidden");
    }
    else {
        endedTasks.classList.add("visually-hidden");
        allTasks.classList.remove("visually-hidden");
    }
}

var confirm = 0;

var url = `https://localhost:7197`;

function CompleteTask(btn) {
    AgreeClick(btn);
    if (confirm == 2) {
        MouseOutBtn(btn);
        axios.put(`${url}/Task/Complete/${btn.id}`)
            .then(response => alert(`Задача выполнена.`))
            .catch(error => alert(`Ошибка.`));
        reload_interval(500);
    }
}
function DeleteTask(btn) {
    AgreeClick(btn);
    if (confirm == 2) {
        MouseOutBtn(btn);
        axios.delete(`${url}/Task/Delete/${btn.id}`)
            .then(response => alert(`Задача удалена.`))
            .catch(error => alert(`Ошибка.`));
        reload_interval(500);
    }
}

function MouseOutBtn(btn) {
    confirm = 0;
    btn.firstChild.data = btn.name;
}

function AgreeClick(btn) {
    var text = btn.firstChild;
    text.data = "Вы уверены?";
    confirm++;
}

function reload_interval(time) {
    setTimeout(function () {
        location.reload();
    }, time);
}
