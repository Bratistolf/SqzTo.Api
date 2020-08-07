import React from 'react';
import classNames from "classnames"

import {Block, Input, Button, Links} from "components"



const SqzLinkCreator = ({
    sendUrl,
    inputValue,
    onChangeInput,
    sqzLinks,
    err
}) =>{

    return (
        <div className = "main-url-creater">
            <Block>
                <Input className = {classNames('input', err? 'error' : '') } placeholder = "ВВЕДИТЕ СВОЙ URL" value = {inputValue} onChange = {onChangeInput}/>
                {err == true? <span>ошибка введённого URL</span> : null}
                <Button onClick = {sendUrl}>
                СОКРАТИТЬ
                </Button>
                <Links  links = {sqzLinks}/>
            </Block>
        </div>
    );
}

export {SqzLinkCreator};