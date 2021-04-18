import React from 'react';
import { withRouter } from 'react-router-dom';

import FacebookLogin from 'react-facebook-login';

import { setMode } from '../../functions.js';

import './register-and-sign-in.styles.scss';

class RegisterAndSignInPage extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            withServer: true
        };
        this.history = this.props.history;        
    }

    handleModChange = e =>{
        e.preventDefault();
        this.setState(state => { 
            setMode(!state.withServer);           
            if (!state.withServer === false){
                e.target.innerText = 'Off';
                e.target.style.backgroundColor = 'red';
            }
            else {
                e.target.innerText = 'On';
                e.target.style.backgroundColor = 'green';
            }
            return{
                withServer: !state.withServer
            };
        });
    }

    componentDidMount(){
        let modeBtn = document.getElementsByClassName('rs-mode')[0];
        modeBtn.innerText = 'On';
        modeBtn.style.backgroundColor = 'green';    
        setMode(true);                         
    }

    responseFacebook = (response) => {
        console.log(response);
    }

    render(){
        return(
            <div className='register-and-sign-in-page'>
                <div className='rs-options-container'>
                    <button className='rs-option' onClick={() => this.history.push('signin')}>Sign in</button>
                    <button className='rs-option' onClick={() => this.history.push('register')}>Register</button>
                </div>
                <div className='rs-mode-container'>
                    <label>with server:</label>
                    <button className='rs-mode' onClick={this.handleModChange}>On</button>
                </div>
                <FacebookLogin
                    appId="1088597931155576"
                    autoLoad={true}
                    fields="name,email,picture"                    
                    callback={this.responseFacebook} />
            </div>
        );
    }

}
export default withRouter(RegisterAndSignInPage);