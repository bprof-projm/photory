import React from 'react';
import { withRouter } from 'react-router-dom';

import FacebookLogin from 'react-facebook-login';

import { setMode } from '../../functions.js';

import './register-and-sign-in.styles.scss';
import axios from 'axios';

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

        const data = {
            accessToken: response.accessToken
        }
        axios.post('/ExternalAuth', data)
        .then(res => {
            console.log(res);  
            this.setState({ token: res.data?.token });
            console.log(this.state.token);  
            this.props.setToken(res.data?.token); 
            var decoded = jwt_decode(this.state.token);
            console.log(decoded);
            var userId = '';
            var role = '';
            Object.keys(decoded).forEach(function (key) {
                let res = key.split("/");
                if (res.length > 1) {
                    if (res[res.length - 1] === 'nameidentifier') {
                      userId = decoded[key];                       
                    }     
                    else if (res[res.length - 1] === 'role') {
                      if (decoded[key] === 'Customer'){
                        role = 'User';
                      }
                      else {
                        role = decoded[key];
                      }                                           
                    }              
                }
            });
                        
            const headers={
                'Authorization': 'Bearer ' + this.state.token
            };
            axios.get(`/${role}/${userId}`, { headers: headers })
            .then(res => {
                console.log(res.data);
                this.props.setCurrentUser(res.data);
                this.props.setNewPassword('');
                this.history.push("/groups");   
            })
            .catch(error => {
                console.log(error);
            })               
        })
        .then(error => {
            console.log(error);
        })
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
                    appId="287947399346523"
                    autoLoad={true}
                    fields="name,email,picture"                    
                    callback={this.responseFacebook} />
            </div>
        );
    }

}
const mapDispatchToProps = dispatch => ({
    setCurrentUser: user => dispatch(setCurrentUser(user)),
    setNewPassword: password => dispatch(setNewPassword(password)),
    setToken: token => dispatch(setToken(token))
  });
  
  export default withRouter(connect(mapStateToProps, mapDispatchToProps)(RegisterAndSignInPage));