import React from 'react';
import { withRouter } from 'react-router-dom';

class SignIn extends React.Component{
    constructor(props){
        super(props);

        this.state = {
            email_name: '',
            password: '',            
        };
        this.history = this.props.history;       
    }

    handleChange = e => {
        const { value, name } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit = e => {       
        e.preventDefault();
    }

    componentDidMount(){
     
    }

    render(){               
        return(
            <div className='sign-in'>
               <h2>SIGN IN PAGE</h2>
            </div>
        )
    }
}
export default withRouter(SignIn);