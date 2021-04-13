import React from 'react';
import { withRouter } from 'react-router-dom';

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
        
    }

    componentDidMount(){
       
    }

    render(){
        return(
            <div className='register-and-sign-in-page'>
                <div className='rs-options-container'>
                    <button className='rs-option' onClick={() => this.history.push('signin')}>Sign in</button>
                    <button className='rs-option'>Register</button>
                </div>
                <div className='rs-mode-container'>
                    <label>with server:</label>
                    <button className='rs-mode' onClick={this.handleModChange}>On</button>
                </div>
            </div>
        );
    }

}
export default withRouter(RegisterAndSignInPage);