const SERVER_URL = 'http://localhost:5000/';

export function fetchToBackend(controller, method, jsonbody) {
    var request = null;
    var result = null;

    if (jsonbody != null){
        request = {
            method: method,           
            headers: {
                'Content-Type': 'application/json'
            },
            body: jsonbody
        };
    }
    else{
        request = {
            method: method,
            headers: {
                'Content-Type': 'application/json'
            }            
        };
    }
    
    return fetch(SERVER_URL + controller, request).then(respond => respond.json());
}

export function validateRegisterForm(){
    var fullname = document.getElementById('fullname').value;
    var username = document.getElementById('username').value;
    var birthdate = document.getElementById('birthdate').value;
    var email = document.getElementById('email').value;
    var password = document.getElementById('password').value; 

    if (email.includes("@") == false){
        return false;
    }

    var jsonbody = JSON.stringify({
        fullname: fullname,
        username: username,
        birthdate: birthdate,
        email: email,
        password: password           
    });

    return fetchToBackend("User", "post", jsonbody);
}

export function registerRespond(target){
    if (target != null){
        document.getElementById(target).style.borderColor = "red";
    }
    else {
        var inputs = document.getElementsByTagName('input');
        for (let i = 0; i < inputs.length; i++){
            inputs[i].style.borderColor = "none";
        }
    }
}