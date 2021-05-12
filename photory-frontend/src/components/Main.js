import React , { useState , useEffect }  from 'react'
import "./Main.css";
import { TextField, Button, Date } from "@material-ui/core";
import { Link, Redirect , useHistory } from "react-router-dom";
import axios from "../axios";

function Main() {

    const [groups, setGroups] = useState(null);
    
    useEffect(() => {
        axios.get("/GetAllGroup").then((res)=>{
            setGroups(res.data);
        }).catch((err)=>{
            console.log(err.message);
        });
    }, []);

    useEffect(()=>{
        console.log(groups);
    },[groups]);

    return (
        <div>
            
        </div>
    )
}

export default Main
