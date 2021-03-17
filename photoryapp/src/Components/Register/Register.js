import { getDefaultNormalizer, render } from '@testing-library/react';
import React, {Component} from 'react';
import {useHistory, Link} from 'react-router-dom';
import './Register.scss';

let USERNAME = null;
let HIDDENATTRI_REG = "";
let HIDDENATTRI_NEXT = "hidden";

class Register extends Component{
    constructor(props){
        super(props)
        this.state = {
            result: false,
            error: null                           
        }
    }

    Validate = () =>{
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
            password: password
            //confpassword: confpassword
        });
        /*const request = {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: jsonBody
        };*/
        const req = {
            method: 'get',
            headers: 
            { 
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': 'http://localhost:3000',
                'Access-Control-Allow-Credentials': 'true'
            }
        };
        //req.append('Access-Control-Allow-Origin', 'http://localhost:3000');
        //req.append('Access-Control-Allow-Credentials', 'true');
        fetch('https://localhost:5001/Register', req)
        .then(res => res.json())
        .then(res => this.setState(state =>{
            var result = res.result;
            var error = res.error;
            return{
                result,
                error
            };
        }));
        //----------------------------------VALIDATION-----------------------------------
        /*fetch('https://localhost:5001/Register', request)
        .then(response => response.json())
        .then(res => this.setState(state => {  
            var result = false;   
            var error = null;        
           if (res.result == "false")
           {               
                result = false;
                switch(res.target)
                {
                    case "fullname":
                    {
                        document.getElementById('fullname').style.borderColor = 'red';                        
                        break;
                    }
                    case "username":
                    {
                        document.getElementById('username').style.borderColor = 'red';                        
                        break;
                    }
                    case "birthdate":
                    {
                        document.getElementById('birthdate').style.borderColor = 'red';                        
                        break;
                    }
                    case "email":
                    {
                        document.getElementById('email').style.borderColor = 'red';                        
                        break;
                    }
                    case "password":
                    {
                        document.getElementById('password').style.borderColor = 'red';    
                        document.getElementById('confpassword').style.borderColor = 'red';                   
                        break;
                    }
                }
                error = res.error;
           }
           else if (res.result == "true") 
           {
               result = true;        
               USERNAME = username; 
           }  
           return{
            result,
            error
           };
        }));
        //-------------------------------------------------------------------------------
        if (this.state.result == true)
        {
            USERNAME = "ASD";
            HIDDENATTRI_NEXT = "";
            HIDDENATTRI_REG = "hidden";
        }
        else
        {
            USERNAME = "Error..";
        }*/
        this.forceUpdate();
      }

    render(){
        return(
            <div className="container">
                <h1>Register Form</h1>               
                <form id="register">
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
                            <button type="button" hidden={HIDDENATTRI_REG} onClick={this.Validate.bind(this)}>Register</button>
                            <Link to="/">
                                <button type="button" hidden={HIDDENATTRI_NEXT}>Next</button>
                            </Link>                            
                        </li>
                    </ul>                    
                </form>   
                <p>{this.state.error}</p>                                                  
            </div>
        );
    }
}
export default Register;