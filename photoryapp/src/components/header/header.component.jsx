import React from 'react';
import { Link } from 'react-router-dom';

import { getUser, setUser } from '../../functions.js';

import './header.styles.scss';

function Header(){
    const currentUser = getUser();
    return(
        <div className='header' style={{ backgroundColor: (currentUser.userAccess === 2 ? 'black' : 'rgb(248, 248, 248)')}}>
            <div className='logo-container' style={{ color: (currentUser.userAccess === 2 ? 'white' : '')}}>
                LOGO
            </div> 
            {currentUser.userAccess === 2 ? (<span className='notif-rank-admin'>Admin UI</span>) : (
            currentUser.userAccess === 1 ? (<span className='notif-rank-group-admin'>Group-admin UI</span>) : null)}            
            <div className='options'>
                <div className='dropdown'>
                    <div className={`option${currentUser.userAccess === 2 ? '-admin' : ''}`}>
                    {currentUser.userName}
                    </div>
                    <Link className={`option-dropdown${currentUser.userAccess === 2 ? '-admin' : ''}`} to='/signin' onClick={() => setUser(null)} >
                        Sign out
                    </Link>
                </div>          
            </div>
        </div>
    );    
}
export default Header;