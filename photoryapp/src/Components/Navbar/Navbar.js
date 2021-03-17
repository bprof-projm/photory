import React from 'react';
import './Navbar.scss';

function Navbar(props){
    return(
        <ul className="navbar" >
	        <li><a id="link_1" className="link-left" href="/" >Home</a></li>
	        <li><a id="link_2" className="link-left" href={props.link1} >{props.text1}</a></li>
	        <li><a id="link_3" className="link-left" href={props.link2} >{props.text2}</a></li>
	        <li><a id="link_4" className="link-right" href={props.link3} style={{float: "right"}} >{props.text3}</a></li>
        </ul>
    );
}
export default Navbar;