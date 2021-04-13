import { getDefaultNormalizer, render } from '@testing-library/react';
import React, {Component} from 'react';
import {useHistory, Link} from 'react-router-dom';
import './Register.scss';
import { validateRegisterForm, registerRespond } from '../../functions.js';

let USERNAME = null;
let HIDDENATTRI_REG = "";
let HIDDENATTRI_NEXT = "hidden";

class Register extends Component{
    constructor(props){
        super(props)
        this.state = {
            target: null,
            warning: null                          
        }
    }

    validate = () =>{
        validateRegisterForm()
        .then(result => this.setState(state =>{            
            var target = result.target;
            var warning = result.warning;

            registerRespond(target);

            return{              
                target,
                warning
            };
        })); 
      }

    showpassword = () =>{
        var input = document.getElementById('password');
        var btn = document.getElementById('btn-show');
        if (input.type == "password"){
            input.type = "text";
            btn.innerText = "Hide";            
        }
        else {
            input.type = "password";       
            btn.innerText = "Show";     
        }
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
                        <button id="btn-show" type="button" onClick={this.showpassword}>Show</button>
                        </li>                        
                        <li>
                            <button type="button" hidden={HIDDENATTRI_REG} onClick={this.validate.bind(this)}>Register</button>
                            <Link to="/">
                                <button type="button" hidden={HIDDENATTRI_NEXT}>Next</button>
                            </Link>                            
                        </li>
                    </ul>                    
                </form>   
                <p>{this.state.warning}</p>                                                  
            </div>
        );
    }
}
export default Register;