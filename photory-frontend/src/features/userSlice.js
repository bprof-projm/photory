import { createSlice } from '@reduxjs/toolkit'

const initialState = {
    validationName:null , 
    password:null , 
    token:null ,
    role:null , 
    id : null
}

const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setActiveUser: (state,action) => {
            state.validationName = action.payload.validationName
            state.password = action.payload.password
            state.token =action.payload.token
            state.role = action.payload.role
            state.id = action.payload.id
        } ,
        setUserLogoutState: (state) => {
            state.validationName = null
            state.password = null
            state.token = null
            state.role = null
            state.id = null
        }
    }
});

export const {setActiveUser , setUserLogoutState} = userSlice.actions

export const selectValidationName= state => state.user.validationName
export const selectPassword= state => state.user.password
export const selectToken= state =>state.user.token
export const selectRole=state=>state.user.role
export const selectId = state => state.user.id

export default userSlice.reducer