import { createSlice } from '@reduxjs/toolkit'

const initialState = {
    validationName:null , 
    password:null , 
    token:null
}

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setActiveUser: (state,action) => {
            state.validationName = action.payload.validationName
            state.password = action.payload.password
            state.token =action.payload.token
        } ,
        setUserLogoutState: (state) => {
            state.validationName = null
            state.password = null
            state.token = null
        }
    }
});

export const {setActiveUser , setUserLogoutState} = userSlice.actions

export const selectValidationName= state => state.user.validationName
export const selectPassword= state => state.user.password
export const selectToken= state =>state.user.token


export default userSlice.reducer