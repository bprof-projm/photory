

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
    
    return fetch('http://localhost:5000/' + controller, request).then(respond => respond.json());
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