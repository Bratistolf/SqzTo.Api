import React from 'react';

import {Block, Input, Button, Links} from "components"



const SqzLinkCreator = ({
    sendUrl,
    inputValue,
    onChangeInput,
    sqzLinks
}) =>{
    return (
        <div className = "main-url-creater">
            <Block>
                <Input placeholder = "ВВЕДИТЕ СВОЙ URL" value = {inputValue} onChange = {onChangeInput}/>
                <Links  links = {sqzLinks}/>
            </Block>
            <Button onClick = {sendUrl}>
                СОКРАТИТЬ
            </Button>
        </div>
    );
}

export {SqzLinkCreator};