import React from 'react';

class Directory extends React.Component{
    constructor(){
        super();

        this.state = {
            groups: [],
            error: ''
        };        
    }

    componentDidMount(){
        const reload = JSON.parse(window.localStorage.getItem('reload'));
        if (reload)
        {
            window.localStorage.setItem('reload', JSON.stringify(false));
            window.location.reload(false);
        }        
         
    }  
        
    render(){                
        return(
            <>            
            <h2>Groups</h2>               
            </>
        );
    }
}
export default Directory;
