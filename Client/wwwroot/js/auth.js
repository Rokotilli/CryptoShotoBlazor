export function SignIn(email, password, redirect) {

    var url = "/api/identity/SignIn";
    var xhr = new XMLHttpRequest();

    xhr.open("POST", url);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4)
        {
            console.log("Call '" + url + "'. Status " + xhr.status);
            if (redirect)
                location.replace(redirect);
        }
    };
    var data = {
        email: email,
        password: password
    };

    xhr.send(JSON.stringify(data));
}

export function SignUp(email, nickname, password, confirmpassword, redirect) {

    var url = "/api/identity/SignUp";
    var xhr = new XMLHttpRequest();

    xhr.open("POST", url);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            console.log("Call '" + url + "'. Status " + xhr.status);
            if (redirect)
                location.replace(redirect);
        }
    };
    var data = {
        email: email,
        nickname: nickname,
        password: password,
        confirmpassword: confirmpassword
    };

    xhr.send(JSON.stringify(data));
}

export function SignOut(redirect) {

    var url = "/api/identity/signout";
    var xhr = new XMLHttpRequest();

    xhr.open("POST", url);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4)
        {
            console.log("Call '" + url + "'. Status " + xhr.status);
            if (redirect)
                location.replace(redirect);
        }
    };

    xhr.send();
}