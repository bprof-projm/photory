import React from 'react';
import { withRouter } from "react-router-dom";

import axios from "../../axios";

import CustomForm from "../custom-form/custom-form.component.jsx";

import { setNewPass } from '../../functions.js';

class Register extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            email: '',
            fullname: '',
            username: '',
            birthdate: ''
        }
        this.history = this.props.history;
    }

    handleChange = (e) => {
        const { value, name } = e.target;
        this.setState({ [name]: value });
    };

    handleSubmit = (e) => {
        e.preventDefault();

        const data ={
            Email: this.state.email,
            FullName: this.state.fullname,
            UserName: this.state.username,
            BirthDate: this.state.birthdate
        }
        axios.post('/Auth/Register', data)
        .then(res => {
            window.localStorage.setItem('reload', JSON.stringify(true));
            console.log(res);
            setNewPass(res[2]);            
        })
        .catch(error => {
            console.log(error);
        })
    }

    render(){

        const inputs = [
            {
              id: "a10ff0c6-4113-4ad2-9a0a-4f5b5aca0595",
              name: "email",
              type: "email",
              label: "email",
              value: this.state.email,
              required: true,
              onChange: this.handleChange,
            },
            {
              id: "78b345b0-c227-4e65-a99f-9faef6bbc22f",
              name: "fullname",
              type: "text",
              label: "fullname",
              value: this.state.fullname,
              required: true,
              onChange: this.handleChange,
            },
            {
                id: "78b345b0-c227-4e65-a99f-9faef6bbc654",
                name: "username",
                type: "text",
                label: "username",
                value: this.state.username,
                required: true,
                onChange: this.handleChange,
              },
              {
                id: "78b345b0-c227-4e65-a99f-9faef6bbc555",
                name: "birthdate",
                type: "date",
                InputLabelProps: { shrink: true },
                label: "birthdate",
                value: this.state.birthdate,
                required: true,
                onChange: this.handleChange,
              }
          ];
      
          const buttons = [
            {
              id: "09d28880-1776-4f5a-8f63-b253ef73f5bf",
              type: "submit",
              value: "Submit Form",
              children: "Register",
            },
          ];

        return(
            <div className='register'>
               <h2 style={{ marginLeft: "30px" }}>Register your new account</h2>
                <CustomForm
                    inputs={inputs}
                    buttons={buttons}
                    onSubmition={this.handleSubmit}
                />
            </div>
        );
    }
}
export default withRouter(Register);