import React, {Component} from 'react';
import {Link} from 'react-router-dom';

class Home extends Component{
    render(){
        return(
            <div>
                <p>Home Page</p>
                <Link to="/register">
                    <button>
                        Register
                    </button>
                </Link>
            </div>
        );
    }
}
export default Home;