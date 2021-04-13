import { Button, TextField } from '@material-ui/core';
import React from 'react';

import './custom-form.styles.scss';

const CustomForm = ({ inputs, buttons, onSubmition, ...otherProps }) => (
    <form {...otherProps}>
        {
            inputs.map(({ id, label, style, ...otherInputProps }) => (
                <li key={id}>                    
                    {/* <label style={style} >{label}</label> */}
                    <TextField label={label} style={style}  {...otherInputProps} />
                </li>
            ))
        }
        {
            buttons.map(({ id, children, otherButtonProps }) => (
                <li key={id}>
                    <Button onClick={onSubmition} color="primary" {...otherButtonProps} >{children}</Button>
                </li>
            ))
        }
    </form>
)
export default CustomForm;