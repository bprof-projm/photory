
const SERVER_URL = 'http://localhost:5000/';

export const GetAllUsers_fetch = async () =>{  //-------------------------GETALLUSERS
    const request = {        
        method: 'GET',
        /*headers: { 
            'Content-Type': 'application/json',
            //'Authorization': 'Roles, Customer'
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Headers': '*'
        },*/     
    };
    
    const controller = 'User';

    const result = {
        error: false,
        statusText: '',
        users: []
    };

    try{
        const rawResponse = await fetch(SERVER_URL + controller, request);
        if (!rawResponse.ok){
            result.error = true;
            result.statusText = rawResponse.statusText;
            return result;
        }
        else{
            const response = await rawResponse.json();
            result.users = response;
            return result;
        }               

    } catch(error){
        console.log(error);
        return null;
    }
}

export const signIn_fetch = async (email_name, password) => {  //-------------------------SIGNIN
    const elements = {
        validationName: email_name,
        password: password
    };
    
    const request = {
        mode: 'no-cors',
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(elements)
    }

    const controller = 'Auth';   
    const route = 'Login';  
    
    var result = {
        error: false,        
        statusText: '',        
        user: null        
    };

    try{
        const rawResponse = await fetch(SERVER_URL + controller + '/' + route, request);
        console.log('MOVED');
        if (!rawResponse.ok){
            console.log('fetch WRONG');
            console.log(rawResponse.ok);
            result.error = true;
            result.statusText = rawResponse.statusText;
            return result;
        }
        else{
            console.log('fetch OK');
            console.log(rawResponse.ok);
            const response = await rawResponse.json();
            if (response === false){
                return result;
            } 
            else {
                //result.user = response; 
                console.log('fetch RESULT');
                console.log(response);                
                return result;  
            }
        }               

    } catch(error){
        console.log('ERROR');
        console.log(error);
        return null;
    }
}