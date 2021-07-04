import React , { useState , useEffect }  from 'react'
import "./Main.css";
import { TextField, Button, Date } from "@material-ui/core";
import { Link, Redirect , useHistory } from "react-router-dom";
import axios from "../axios";
import {useDispatch , useSelector} from 'react-redux'
import {selectToken} from '../features/userSlice'

function Main() {

    const [groups, setGroups] = useState(null);
    
    const token = useSelector(selectToken);

    const headers = {
        Authorization:"Bearer " + token
    }
     
    

    useEffect(() => {
        console.log(headers);
        axios.get("/GetAllGroup",{headers:headers}).then((res)=>{
            setGroups(res.data);
            console.log(res.data)
        }).catch((err)=>{
            console.log(err.message);
        });
    }, []);

    /*
    useEffect(()=>{
        console.log(groups);
    },[groups]);
    */
    return (
        <div>
            
        </div>
    )
}

export default Main
