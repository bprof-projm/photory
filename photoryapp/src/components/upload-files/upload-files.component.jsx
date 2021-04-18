import React from 'react';

import DragAndDropFile from '../drag-n-drop/drag-n-drop.component';

class UploadFiles extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            files: [], //necessary?
            size: this.props.arraySize,
            with: this.props.imgWith,
            height: this.props.imgHeight
        }
    }

    handleFiles = (files) =>{
        console.log(this.state.size);
        var currentFiles = this.state.files;        
        for (var i = 0; i < files.length && this.state.files.length < this.state.size; i++){ 
            if (files[i].type === 'image/jpeg' || files[i].type === 'image/png'){                
                currentFiles.push(files[i]);
                this.props.imageHandler(files[i]);
            }          
        }
        this.setState({ files: currentFiles });
    }

    render(){        
        return(  
            <>          
            <DragAndDropFile handleFiles={this.handleFiles} className={this.props.className}>
            <div>
                {
                    this.state.files.map((file, i) => (
                        <img key={i} src={URL.createObjectURL(file)} alt='img' style={{ with: this.state.with, height: this.state.height }} />
                    ))
                }
            </div>                        
            </DragAndDropFile>
            <button style={{ marginTop: '15px' }} onClick={() => this.setState({ files: [] })} >Clear</button>
            </>
        );
    }
}
export default UploadFiles;