import React, {Component} from 'react';
import './Register.scss';

class Register extends Component{
    constructor(props){
        super(props);
        this.state = {
            data: null
        };
    }

    getData = (e) =>{

    }

    submit = () =>{
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
        .then(data => this.getData(data));*/       
        this.setState(state => {
            const data= jsonBody;           
            return {
                data
            };         
        });
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
                            <button type="button" onClick={this.submit}>Submit</button>
                        </li>
                    </ul>                    
                </form>      
                <p>{this.state.data}</p>          
            </div>
        );
    }

}
export default Register;