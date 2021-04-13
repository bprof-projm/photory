import React from 'react';

import './custom-form.styles.scss';

const CustomForm = ({ inputs, buttons, onSubmition, ...otherProps }) => (
    <form onSubmit={onSubmition} {...otherProps}>
        {
            inputs.map(({ id, label, style, ...otherInputProps }) => (
                <li key={id}>
                    <label style={style} >{label}</label>
                    <input style={style}  {...otherInputProps} />
                </li>
            ))
        }
        {
            buttons.map(({ id, children, otherButtonProps }) => (
                <li key={id}>
                    <button {...otherButtonProps} >{children}</button>
                </li>
            ))
        }
    </form>
)
export default CustomForm;