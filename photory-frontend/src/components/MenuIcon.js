import React from 'react'
import './MenuIcon.css';
import Szívem from "../assets/Szívem.png";
import Cam from "../assets/cam1.png";
function MenuIcon() {
    return (
        <div className="menuIcon">
            <img loading="lazy" className ="logo" src={Cam} />
        </div>
    )
}

export default MenuIcon
