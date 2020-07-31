import React, { useState, useEffect } from 'react';
import {urlApi} from 'utils/api';

import {SqzLinkCreator as BaseSqzLinkCreator} from "../components/SqzLinkCreator";

const SqzLinkContainer = () => {
    
    const [inputValue, setInputValue] = useState("");
    const [sqzLinks, addSqzLink] = useState([])


    const handleChangeInput = e => {
        setInputValue(e.target.value);
      };

    
    const onSendUrl = () => {
        if(inputValue != "")
            urlApi
                .createSqzLink({
                    url: inputValue
                })
                .then(({data})=>{

                    let link = {
                        hash: data,
                        sqzLink: "localhost:3000/v1/sqzlink/" + data,
                        longLink: inputValue
                    };

                    if (sqzLinks.length < 3){
                        addSqzLink(sqzLinks.concat(link));
                        console.log(sqzLinks);
                    } else {
                        console.log(sqzLinks);
                        addSqzLink(sqzLinks.splice(0,1).concat(link))
                    }
                })
                .catch((err) => console.error(err))
        
    };


    return (
        <BaseSqzLinkCreator
            sendUrl = {onSendUrl}
            inputValue = {inputValue}
            onChangeInput = {handleChangeInput}
            sqzLinks = {sqzLinks}
        />
    );
}

export default SqzLinkContainer;