import { getDefaultNormalizer, render } from '@testing-library/react';
import React, {Component} from 'react';
import {useHistory, Link} from 'react-router-dom';
import './Register.scss';
import { fetchToBackend } from '../../functions.js';

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
        fetchToBackend("Register", "get", null)
        .then(result => this.setState(state =>{            
            var error = result.error;
            return{              
                error
            };
        }));              
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