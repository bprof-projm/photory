import React, {useState} from 'react';
import './Home.css';
import Szívem from '../assets/szívem.jpg'
import { TextField , Button } from '@material-ui/core';
import { Link } from 'react-router-dom';
import axios from '../axios';


function Home() {
    const [email,setEmail] = useState('');
    const [password,setPassword] = useState('');

    const loginHandler = () =>{
        const data = {
            ValidationName:email,
            Password:password
        }

        axios.put('/Auth/Login', data).then((res)=>{
            console.log(res);
        }).catch((err)=>{
            console.log(err.message);
        });

    }

    return (
        <div className='home'>
            <div className='home_left'>
                <img loading='lazy' src={Szívem} />
            </div>
            <div className='home_right' >
                <TextField  label="Email/User Name" value={email} onChange={(e)=>{setEmail(e.target.value)}}/>
                <TextField  label="Password" value={password} onChange={(e)=>{setPassword(e.target.value)}}/>
                <Button onClick={loginHandler}>
                    Login
                </Button>
                <p>
                    If you dont have an account , please <Link to="/register" style={{color:'black'}}>register</Link> 
                </p>
            </div>
        </div>
    )
}

export default Home
