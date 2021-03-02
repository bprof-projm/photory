import { render } from '@testing-library/react';
import React, {Component} from 'react';
import {useHistory} from 'react-router-dom';
import './Register.scss';

const USERNAME = null;


function Register(props){

    let history = useHistory();

    function handleSubmit(props){
        var fullname = document.getElementById('fullname').value;
        var username = document.getElementById('username').value;
        var birthdate = document.getElementById('birthdate').value;
        var email = document.getElementById('email').value;
        var password = document.getElementById('password').value;
        var confpassword = document.getElementById('confpassword').value;
        var jsonBody = JSON.stringify({
            fullname: fullname,
            username: username,
            birthdate: birthdate,
            email: email,
            password: password,
            confpassword: confpassword
        });
        /*const request = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: jsonBody
        };
        fetch('http://localhost:5001/register', request)
        .then(response => response.json())
        .then(res => this.setState(state => {
            const user = null;
            const data = null;
            const error = null;
            if (res.DidRegister == true){
                USERNAME = res.UserName;
                useHistory().push('/');
            }
            else if (res.DidRegister == false){
                error = res.ErrorMsg;
            }
        }));*/    
        history.push('/');   
    }
   

        return(
            <div className="container">
                <h1>Register Form</h1>
                <form id="register" onSubmit={handleSubmit}>
                    <ul>
                        <li>
                        <label>Full Name:</label>
                        <input id="fullname" type="text" name="fullname"/>
                        </li>
                        <li>
                        <label>Username:</label>
                        <input id="username" type="text" name="username"/>
                        </li>
                        <li>
                        <label>Birth Date:</label>
                        <input id="birthdate" type="date" name="birthdate"/>
                        </li>                    
                        <li>
                        <label>email address:</label>
                        <input id="email" type="email" name="email"/>
                        </li>                       
                        <li>
                        <label>Password:</label>
                        <input id="password" type="password" name="password"/>
                        </li>
                        <li>
                        <label>Confirm Password:</label>
                        <input id="confpassword" type="password" name="confpassword"/>
                        </li>
                        <li>
                            <input type="submit" value="submit" />
                        </li>
                    </ul>                    
                </form>                           
            </div>
        );

}
export default Register;