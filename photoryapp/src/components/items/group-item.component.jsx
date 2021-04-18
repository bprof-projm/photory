import React from 'react';
import { withRouter } from 'react-router-dom';

import './group-item.styles.scss';

function GroupItem({ group }){            
    return(
    <div className='group-item-container'>                
        <div 
            className='group-item'            
        >        
            <div className='group-image' style={{ backgroundImage: `url(https://dummyimage.com/500x150/000/fff)` }} />
            <h4>{group.groupName}</h4>            
        </div>        
    </div>
    );
}
export default withRouter(GroupItem);