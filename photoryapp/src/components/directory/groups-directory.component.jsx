import React from 'react';

import axios from '../../axios';

import { getToken } from '../../functions';

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
        
        //curl -X GET "https://localhost:44336/GetAllGroup" -H  "accept: text/plain" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJoZWdlZHVzLm1hdGVAbmlrLnVuaS1vYnVkYS5odSIsImp0aSI6IjA2ODZkNDQ0LTE1MDMtNGNlOC1hMTc5LTBhNDg0MTM3ZTU4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMDIxNzRjZjDigJM5NDEy4oCTNGNmZS1hZmJmLTU5ZjcwNmQ3MmNmNiIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNjE4MzM1ODY1LCJpc3MiOiJodHRwOi8vd3d3LnNlY3VyaXR5Lm9yZyIsImF1ZCI6Imh0dHA6Ly93d3cuc2VjdXJpdHkub3JnIn0.56ImgZjlxdy-t2P2Bx2h-S99QOZbNoWptLGuVQDCOyg"
        
        const headers={
            'Authorization': 'Bearer ' + getToken()
        }
        
        axios.get('/GetAllGroup',{ headers: headers })
        .then(res => {
            console.log(res);
            this.setState({ groups: res.data });
        })
        .catch(error => {
            console.log(error);
        })
         
    }  
        
    render(){                
        return(
            <>            
            <h2>Groups</h2> 
            <div className='group-directory'>
                {
                    this.state.groups !== [] ? (
                        this.state.groups.map((group) => (
                            <h2>{group.groupName}</h2>
                        ))
                    )
                    :null
                }
                </div>            
            </>
        );
    }
}
export default Directory;
