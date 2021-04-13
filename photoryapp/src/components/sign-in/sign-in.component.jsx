import React from 'react';
import { withRouter } from 'react-router-dom';

import CustomForm from '../custom-form/custom-form.component.jsx';

import USERS_DATA from '../../pages/sign-in/users.data.js';
import { signIn_fetch, GetAllUsers_fetch } from '../../backendCom.js';
import { getMode, validateUser } from '../../functions.js';

class SignIn extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            email_name: '',
            password: '', 
            error: ''           
        };
        this.history = this.props.history;    
        this.mode = getMode();   
    }

    handleChange = e => {
        const { value, name } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit = e => {       
        e.preventDefault();

        if (this.mode){
            signIn_fetch().then(result => {
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
                    this.history.push('/groups');
                }
            });
       }
       else{
            const result = validateUser(this.state.email_name, this.state.password);
            if (result){
                this.setState({ email_name: '', password: '', error: '' });
                this.history.push('/groups');
            }
            else {
                this.setState({ email_name: '', password: '', error: 'The email/username or the password was wrong!' });
            }
       }
         
    }

    componentDidMount(){
        if (this.mode){
            GetAllUsers_fetch().then(result => {
                console.log(result);
                if (result === null){
                    console.log('SERVER ERROR');
                }
                else if (result.error){
                    console.log(result.statusText);
                }
                else {
                    console.log(result.users);
                }
            });
        }
        else{
            console.log(USERS_DATA);
        }
    }

    render(){   
        
        const inputs = [
            {
                id: 'a10ff0c6-4113-4ad2-9a0a-4f5b5aca0595',
                name: 'email_name',
                type: 'text',
                label: 'email/username',
                value: this.state.email_name,
                required: true,
                onChange: this.handleChange
            },
            {
                id: '78b345b0-c227-4e65-a99f-9faef6bbc22f',
                name: 'password',
                type: 'password',
                label: 'password',
                value: this.state.password,
                required: true,
                onChange: this.handleChange
            }
        ];

        const buttons = [
            {
                id: '09d28880-1776-4f5a-8f63-b253ef73f5bf',
                type: 'submit',
                value: 'Submit Form',
                children: 'Sign in'
            }
        ];

        return(
            <div className='sign-in'>
               <h2 style={{ marginLeft: '30px' }}>Sign in with your account</h2>
                <CustomForm inputs={inputs} buttons={buttons} onSubmition={this.handleSubmit} />
            </div>
        )
    }
}
export default withRouter(SignIn);