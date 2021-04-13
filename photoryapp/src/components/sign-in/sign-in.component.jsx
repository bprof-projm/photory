import React from "react";
import { withRouter } from "react-router-dom";
import jwt_decode from 'jwt-decode';

import axios from "../../axios";

import CustomForm from "../custom-form/custom-form.component.jsx";

import USERS_DATA from "../../pages/sign-in/users.data.js";
import { signIn_fetch, GetAllUsers_fetch } from "../../backendCom.js";
import { getMode, validateUser, setToken, setUser, getNewPass } from "../../functions.js";

import './sign-in.styles.scss';

class SignIn extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      email_name: "",
      password: "",
      error: "",
      token:''
    };
    this.history = this.props.history;
    this.mode = getMode();
    this.newpass = null;    
  } 

  handleChange = (e) => {
    const { value, name } = e.target;
    this.setState({ [name]: value });
  };

  handleSubmit = (e) => {
    e.preventDefault();

    if (this.mode) {
      /*signIn_fetch().then(result => {
                console.log(result);
                if (result === null){
                    this.setState({ email_name: '', password: '', error: 'The communication with the server was failed!' });
                }
                else if (result.error){
                    this.setState({ email_name: '', password: '', error: result.statusText });
                }
                else if (result.user === null){
                    this.setState({ email_name: '', password: '', error: 'The email/username or the password was wrong!' });
                } 
                else {            
                    this.setState({ email_name: '', password: '', error: '' });
                    //console.log(result.user.userName);
                    this.history.push('/groups');
                }
            });*/ 
        const data ={
            ValidationName: this.state.email_name,
            Password: this.state.password
        };
        axios.put('/Auth/Login', data)
        .then(res => {
            console.log(res);  
            this.setState({ token: res.data?.token });
            console.log(this.state.token);  
            setToken(this.state.token); 
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
                        role = decoded[key];                       
                    }              
                }
            });
                        
            const headers={
                'Authorization': 'Bearer ' + this.state.token
            };
            axios.get(`/${role}/${userId}`, { headers: headers })
            .then(res => {
                console.log(res.data);
                setUser(res.data);
                this.history.push("/groups");   
            })
            .catch(error => {
                console.log(error);
            })               
        })
        .catch(error => {
            console.log(error);
        })


    } else {
      const result = validateUser(this.state.email_name, this.state.password);
      if (result) {
        this.setState({ email_name: "", password: "", error: "" });
        this.history.push("/groups");
      } else {
        this.setState({
          email_name: "",
          password: "",
          error: "The email/username or the password was wrong!",
        });
      }
    }
  };

  componentDidMount() {   
    const reload = JSON.parse(window.localStorage.getItem('reload'));
    if (reload)
    {
        console.log('get new pass');
        this.newpass = getNewPass();
        window.localStorage.setItem('reload', JSON.stringify(false));
        window.location.reload(false);
    }

    axios
        .get("/Auth")
        .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          console.log(error);
        });


    if (this.mode) {
      /*GetAllUsers_fetch().then((result) => {
        console.log(result);
        if (result === null) {
          console.log("SERVER ERROR");
        } else if (result.error) {
          console.log(result.statusText);
        } else {
          console.log(result.users);
        }
      })*/
      
    } else {
      console.log(USERS_DATA);
    }
  }

  render() {
    const inputs = [
      {
        id: "a10ff0c6-4113-4ad2-9a0a-4f5b5aca0595",
        name: "email_name",
        type: "text",
        label: "email/username",
        value: this.state.email_name,
        required: true,
        onChange: this.handleChange,
      },
      {
        id: "78b345b0-c227-4e65-a99f-9faef6bbc22f",
        name: "password",
        type: "password",
        label: "password",
        value: this.state.password,
        required: true,
        onChange: this.handleChange,
      },
    ];

    const buttons = [
      {
        id: "09d28880-1776-4f5a-8f63-b253ef73f5bf",
        type: "submit",
        value: "Submit Form",
        children: "Sign in",
      },
    ];

    return (
      <div className="sign-in">
        <h2 style={{ marginLeft: "30px" }}>Sign in with your account</h2>
        <CustomForm
          inputs={inputs}
          buttons={buttons}
          onSubmition={this.handleSubmit}
        />
        {this.newpass !== null && this.newpass !== undefined ? (<span>Your new password: {this.newpass}</span>) : null}
      </div>
    );
  }
}
export default withRouter(SignIn);
