import React, { useState } from 'react';
import {urlApi} from 'utils/api';

import {SqzLinkCreator as BaseSqzLinkCreator} from "../components/SqzLinkCreator";

const SqzLinkContainer = () => {
    
    const [inputValue, setInputValue] = useState("");
    
    const handleChangeInput = e => {
        setInputValue(e.target.value);
      };

    const onSendUrl = () => {
        console.log(inputValue);
        if (inputValue)
            urlApi
            .getSqzLink({
                url: inputValue
            })
            .catch(data => {
                console.log(data);
            })
    };


    return (
        <BaseSqzLinkCreator
            sendUrl = {onSendUrl}
            inputValue = {inputValue}
            onChangeInput = {handleChangeInput}
        />
    );
}

export default SqzLinkContainer;