import USERS_DATA from './pages/sign-in/users.data.js';
import jwt_decode from 'jwt-decode';



export const setMode = mode => {
    window.localStorage.setItem('liveMode', JSON.stringify(mode));
}

export const getMode = () => {
    return JSON.parse(window.localStorage.getItem('liveMode'));
}




export const setToken = (token) => {
    window.localStorage.setItem('Token', JSON.stringify(token));
}

export const getToken = () => {
    return JSON.parse(window.localStorage.getItem('Token'));
}



const USER_COLLECTION = USERS_DATA;

export const validateUser = (email_name, password) => {
    var user = USER_COLLECTION.find(user => user.email === email_name && user.password === password);
    if (user === null || user === undefined){
        user = USER_COLLECTION.find(user => user.username === email_name && user.password === password);
    }
    if (user !== null && user !== undefined){
        console.log('found!');//-----------------------LOG        
        return true;
    }
    else {
        console.log('not found!');//-----------------------LOG       
        return false;
    }
}