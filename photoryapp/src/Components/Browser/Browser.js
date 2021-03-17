import React, { useState } from 'react';
import Picture from '../Models/Picture.js';
import Thumbnail from './Thumbnail.js';
import Navbar from '../Navbar/Navbar';
import './Browser.scss';


function AddRange(props){
    const pictures = [];
    for (let i = 0; i < props; i++) {    
        pictures.push(new Picture("Title " + i.toString(), "2020.02.24"));
    }
    return pictures;
}

function SliceArray(limit, current, pictures) {
    const _pictures = [];
    for (let i = limit * (current - 1); i < pictures.length && i < current * limit; i++){
        _pictures.push(pictures[i]);
    }
    return _pictures;
}

class Browser extends React.Component{    
    constructor(props){
        super(props);
        this.state = {
            pictures: [],
            currentPictures: [],
            limit: 6,
            pages: 0,
            current: 1
        };        
    }

    AddPicture = () =>{
        this.setState(state => {
            //const pictures = state.pictures.concat(new Picture("Title 19", "2020.02.24"));
            const pictures = state.pictures.concat(AddRange(50)); 
            var pages = Math.ceil(pictures.length / state.limit);
            const currentPictures = SliceArray(state.limit, state.current, pictures);                    
            return {
                pictures,
                currentPictures,
                pages,                
            };         
        });
    }

    GenerateNav(pages) {
        return Array.from(Array(pages), (e, i) => {
            return <li><a onClick={() => this.OnClickNav(i + 1)}>{i + 1}</a></li>
        })    
    }

    OnClickNav = (i) =>{
        this.setState(state => {
            const current = i;
            const currentPictures = SliceArray(state.limit, current, state.pictures);
            return{
                currentPictures,
                current               
            };
        });
    }

    ContentHeader() {
        return(
            <ul className="br-header">
                <li><button type="button" onClick={this.AddPicture} >Fill</button></li>
                <li>picture amount: {this.state.pictures.length}</li>
                <li>Limit:</li>
                <li>                                   
                    <button type="button" onClick={() => this.OnClickLimit(6)}>6</button>
                    <button type="button" onClick={() => this.OnClickLimit(10)}>10</button>
                    <button type="button" onClick={() => this.OnClickLimit(14)}>14</button>
                </li>         
            </ul>
        );
    }

    OnClickLimit = (i) =>{
        this.setState(state =>{
            const current = 1;
            const limit = i;
            var pages = Math.ceil(state.pictures.length / limit);
            const currentPictures = SliceArray(limit, current, state.pictures);
            return{
                current,
                limit,
                pages,
                currentPictures
            };
        });
    }

    Content(){             
        return(
            <div className="contents">
                {this.state.currentPictures.map(item => (
                    <Thumbnail title={item.title} date={item.date} />
                ))}
            </div>        
        );
    }

    NavContent(){
        return(
            <div className="content-nav">
                <ul>
                    {this.GenerateNav(this.state.pages)}
                </ul>                
            </div>
        );
    }    

    render(){
        return(
            <div className="p-browser">
                <Navbar text1="Something1" link1="#" text2="Something2" link2="#" text3='UserName' link3="#"/>
                {this.ContentHeader()}
                {this.Content()}  
                {this.NavContent()}                                    
            </div>
        );
    }
}
export default Browser;
