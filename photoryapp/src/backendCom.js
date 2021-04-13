
const SERVER_URL = 'http://localhost:5000/';

export const GetAllUsers_fetch = async () =>{
    const request = {
        mode: 'no-cors',
        method: 'GET',
        headers: { 
            'Content-Type': 'application/json',
            //'Authorization': 'Roles, Customer'
        },        
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
        }               

    } catch(error){
        console.log(error);
        return;
    }
}