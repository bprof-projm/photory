import { Button, TextField, Select, InputLabel } from '@material-ui/core';
import React from 'react';

import './custom-form.styles.scss';

const CustomForm = ({ inputs, buttons, selectors, onSubmition, ...otherProps }) => (
    <form {...otherProps}>
        {
            inputs.map(({ id, label, style, ...otherInputProps }) => (
                <li key={id}>                    
                    {/* <label style={style} >{label}</label> */}
                    <TextField className='input' label={label} style={style}  {...otherInputProps} />
                </li>
            ))
        }
        {
            selectors?.length ? (
                selectors.map(({ id, value, label, labelId, children, onChange, ...otherProps }) => (
                    <li key={id}>                    
                        <InputLabel id={labelId}>{label}</InputLabel>
                        <Select value={value} onChange={onChange} labelId={labelId} className='select' {...otherProps} >                        
                            {children}
                        </Select>
                    </li>
                ))
            )
            : null
        }
        {
            buttons.map(({ id, children, otherButtonProps }) => (
                <li key={id}>
                    <Button className='button' onClick={onSubmition} color="primary" {...otherButtonProps} >{children}</Button>
                </li>
            ))
        }
    </form>
)
export default CustomForm;