export function SignIn(email, username, userid, redirect) {

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
        username: username,
        userid: userid
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

export function SendMessage(temp) {

    alert(temp);
}

export function ChangeName(username, email, redirect) {
    
    var url = "/api/identity/changename";
    var xhr = new XMLHttpRequest();

    xhr.open("PUT", url);
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
        username: username,
        email: email
    };

    xhr.send(JSON.stringify(data));
}