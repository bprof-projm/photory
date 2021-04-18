import { UserActionTypes } from './user.types';

const INITIAL_STATE = {
    currentUser: null,
    password: '',
    token: ''
}

const userReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case UserActionTypes.SET_CURRENT_USER:
            return {
                ...state,
                currentUser: action.payload
            };
        
        case UserActionTypes.SET_NEW_PASSWORD:
            return {
                ...state,
                password: action.payload
            };

        case UserActionTypes.SET_TOKEN:
            return {
                ...state,
                token: action.payload
            };
        
        default:
            return state;
    }
}
export default userReducer;