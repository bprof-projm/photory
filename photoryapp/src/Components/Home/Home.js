import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import Navbar from '../Navbar/Navbar';

class Home extends Component{
    render(){
        return(
            <div>
                <Navbar text1="Browser" link1="/browser" text2="Something" link2="#" text3='Register' link3="/register"/>
            </div>
        );
    }
}
export default Home;