import React from 'react';
import { withRouter } from 'react-router-dom';

import { getUser } from '../../functions.js';

import './group-item.styles.scss';

function GroupItem({ group, history, match, remove, getMembers }){    
    const members = getMembers(group.groupName);
    const currentUser = getUser();    
    return(
    <div className='group-item-container'>
        {currentUser.userAccess === 'Admin' ? (<button className='btn-delete' onClick={() => remove(group.groupName)} >Delete</button>) : null}
        {members.includes(members.find(member => member.username === currentUser.username)) ?
        (<div><label className='member-tag'>You are a member</label><button className='leave-tag'>Leave</button></div>) : (<button className='join-tag' >Join</button>)
        }
        <div 
            className='group-item'
            onClick={() => members.includes(members.find(member => member.username === currentUser.username)) ?
            history.push(`${match.url}/${group.groupName}`) : null}
        >        
            <div className='group-image' style={{ backgroundImage: `url(${group.imageName})` }} />
            <h4>{group.groupName}</h4>        
            <span>{group.description}</span>
        </div>        
    </div>
    );
}
export default withRouter(GroupItem);