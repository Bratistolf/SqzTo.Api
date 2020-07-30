import React from 'react';

import {Block, Input, Button} from "components"



const SqzLinkCreator = ({
    sendUrl,
    inputValue,
    onChangeInput,
}) =>{
    return (
        <div className = "main-url-creater">
            <Block>
                <Input placeholder = "ВВЕДИТЕ СВОЙ URL" value = {inputValue} onChange = {onChangeInput}/>
            </Block>
            <Button onClick = {sendUrl}>
                СОКРАТИТЬ
            </Button>
        </div>
    );
}

export {SqzLinkCreator};