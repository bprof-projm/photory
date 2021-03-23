

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
    
    return fetch('https://localhost:5001/' + controller, request).then(respond => respond.json())
}