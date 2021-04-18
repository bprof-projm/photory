import { UserActionTypes } from './user.types';

export const setCurrentUser = user => ({
    type: UserActionTypes.SET_CURRENT_USER,
    payload: user
});

export const setNewPassword = password => ({
    type: UserActionTypes.SET_NEW_PASSWORD,
    payload: password
});