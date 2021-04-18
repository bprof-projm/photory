import React from 'react';

class DragAndDropFile extends React.Component{
    constructor(props){
        super(props);
        this.state = {
            dragging: false
        };
        this.dragCounter = 0;
        this.dropRef = React.createRef();       
    }

    handleDragOver = (e) =>{
        e.preventDefault();
        e.stopPropagation();
    }

    handleDragIn = (e) =>{
        e.preventDefault();
        e.stopPropagation();
        this.dragCounter++;
        if (e.dataTransfer.items && e.dataTransfer.items.length > 0){
            this.setState({ dragging: true });
        }       
    }

    handleDragOut = (e) =>{
        e.preventDefault();
        e.stopPropagation();
        this.dragCounter--;
        if (this.dragCounter === 0){
            this.setState({ dragging: false });
        }
    }

    handleDrop = (e) =>{
        e.preventDefault();
        e.stopPropagation();
        this.setState({ dragging: false });
        if (e.dataTransfer.items && e.dataTransfer.items.length > 0){
            console.log(e.dataTransfer.files)
            this.props.handleFiles(e.dataTransfer.files)
            e.dataTransfer.clearData();
            this.dragCounter = 0;
        }
    }

    componentDidMount(){
        var div = this.dropRef.current;
        div.addEventListener('dragenter', this.handleDragIn);
        div.addEventListener('dragleave', this.handleDragOut);
        div.addEventListener('dragover', this.handleDragOver);
        div.addEventListener('drop', this.handleDrop);
    }

    componentWillUnmount(){
        var div = this.dropRef.current;
        div.removeEventListener('dragenter', this.handleDragIn);
        div.removeEventListener('dragleave', this.handleDragOut);
        div.removeEventListener('dragover', this.handleDragOver);
        div.removeEventListener('drop', this.handleDrop);
    }

    render(){
        return (
            <div ref={this.dropRef} className={this.props.className}>
                <div style={{ display: (this.state.dragging ? 'inline-block' : 'none') }} >DRAGGING</div>
                {this.props.children}
            </div>
        );
    }
}
export default DragAndDropFile;