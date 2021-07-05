import { TextField, withStyles } from '@material-ui/core';
import React from 'react';

const CustomTextField = withStyles({
    root: {
        '& .MuiOutlinedInput-root': {
            '& fieldset': {
                borderRadius: `30px`,
            },
        },
    },
})(TextField);

const TextInput = (props) => {
    return (
        <CustomTextField
            variant="outlined"
            color="primary"
            {...props}
        />
    )
}

export default TextInput
