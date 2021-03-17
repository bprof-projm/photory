import React from 'react';
import './Browser.scss';

class Thumbnail extends React.Component{
    render(){
        return(
            <div className="thumbnail">
                <ul>
                    <li className="th-date">{this.props.date}</li>
                    <li className="th-imgholder"><img src="https://via.placeholder.com/200x100" alt="Image" /></li>
                    <li className="th-title">{this.props.title}</li>                    
                </ul>
            </div>
        );
    }
}
export default Thumbnail;