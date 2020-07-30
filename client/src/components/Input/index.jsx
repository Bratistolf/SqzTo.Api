import React, {Component} from "react"

import "./input.scss"

const Input = (props) => {
    return (
        <input 
            {...props}
        className = "input-url" >
            
        </input>
    );
}

export default Input;