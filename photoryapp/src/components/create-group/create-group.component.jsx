import React from 'react';
import { withRouter } from 'react-router-dom';

import CustomForm from '../custom-form/custom-form.component.jsx';

import './create-group.styles.scss';

class CreateGroup extends React.Component{
    constructor(){
        super();
        this.state = {            
            name: '',
            imageUrl: '',
            //description: '',
            groupAdmin: '',
            age: 0,

            selectedInput: '',

            imageFile: null,

            error: false
        }              
    }

    handleChange = e =>{
        const { value, name } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit = e =>{
        e.preventDefault();
        if (this.state.selectedInput === 'img' && this.state.imageFile === null)
        {
            this.setState({ error: true })
        }
        else{
            //axios            
        }
    }

    handleRadioChange = e =>{
        const { id } = e.target;
        this.setState({ selectedInput: id });        
    }

    saveImage = (file) =>{
            
    }


    render(){
        
        const inputs = [
            {
                id: '95bd7265-7f16-42e1-a352-53eef21e5f86',
                name: 'name',
                type: 'text',
                label: 'name',
                value: this.state.name,
                required: true,
                onChange: this.handleChange
            },
            /*{
                id: 'bf985ebd-c475-4d03-b374-b8d471f051d3',
                name: 'description',
                type: 'text',
                label: 'description',
                value: this.state.description,
                required: true,
                onChange: this.handleChange
            },*/            
            {
                id: '58334e79-b0dc-4f32-9d95-2417b0e9563f',
                name: 'age',
                type: 'number',
                label: 'age limit',
                value: this.state.age,
                required: true,
                onChange: this.handleChange
            }
        ];
         if (this.state.selectedInput === 'url')
         {
             inputs.push(
                {
                    id: '92b97b1b-99d4-4346-8250-97d5d154c0eb',
                    name: 'imageUrl',
                    type: 'text',
                    label: 'image url',
                    value: this.state.imageUrl, 
                    required: true,        
                    onChange: this.handleChange,                    
                }
             );
         }
        

        const buttons = [
            {
                id: '7b61acd9-3cd7-45e9-8ba6-4f5025ae76c7',
                type: 'submit',
                value: 'Submit Form',
                children: 'Create'
            }
        ];

        return(
            <div className='create-group'>
                <h2 style={{ marginLeft: `30px`, marginTop: '25px'}}>Create a new group</h2>
                <CustomForm inputs={inputs} buttons={buttons} onSubmition={this.handleSubmit} className='text-inputs' />
                <div className='input-selector'>
                    <label style={{ display: 'block' }}>
                        cover image
                        <label style={{ marginLeft: '40px' }}>recommended size:</label>
                        <label style={{ color: 'red', marginLeft: '5px' }}>500x150</label>
                    </label>                    
                    <li className='with-url'>
                        <input id='url'name='image' type='radio' onChange={this.handleRadioChange} />
                        <label>with URL</label>
                    </li>
                    <li className='ds'><label>OR</label></li>
                    <li className='with-image'>
                        <input id='img' name='image' type='radio' onChange={this.handleRadioChange} />
                        <label>with image</label>
                    </li>
                    
                    {/*DRAG AND DROP */}

                    {this.state.selectedInput === 'img' ? this.state.error === true ? (<label style={{ color:'red' }}>Drop a jpeg or a png file above</label>) : null : null}                                    
                </div>
            </div>
        );
    }
}
export default withRouter(CreateGroup);