import React from 'react';
import { Link } from 'react-router-dom';

import { connect } from 'react-redux';
import { setCurrentUser } from '../../redux/user/user.actions';

import './header.styles.scss';

function Header({ currentUser, setCurrentUser }){    
    return(
        <div className='header' style={{ backgroundColor: (currentUser.userAccess === 2 ? 'black' : 'rgb(248, 248, 248)')}}>
            <div className='logo-container' style={{ color: (currentUser.userAccess === 2 ? 'white' : '')}}>
                LOGO
            </div> 
            {currentUser.userAccess === 2 ? (<span className='notif-rank-admin'>Admin UI</span>) : (
            currentUser.userAccess === 1 ? (<span className='notif-rank-group-admin'>Group-admin UI</span>) : null)}            
            <div className='options'>                
                <div className='dropdown'>
                    <div style={{ marginLeft: '60px' }} className={`option${currentUser.userAccess === 2 ? '-admin' : ''}`}>
                    {currentUser.userName}
                    </div>
                    <Link className={`option-dropdown${currentUser.userAccess === 2 ? '-admin' : ''}`} to='/signin' onClick={() => setCurrentUser(null)} >
                        Sign out
                    </Link>
                </div>   
                {currentUser.userAccess === 2 && (
                <Link className='option-admin' to='/creategroup'>
                    Create group
                </Link>)}   
            </div>
        </div>
    );    
}

const mapStateToProps = state => ({
    currentUser: state.user.currentUser
});

const mapDispatchToProps = dispatch => ({
    setCurrentUser: user => dispatch(setCurrentUser(user))
});

export default connect(mapStateToProps, mapDispatchToProps)(Header);