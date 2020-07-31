import React from 'react';
import LinkItem from './LinkItem'

import "./links.scss"

const Links = ({links}) => {
    console.log(links);
    return (
        <div className = "links">
            {links.length?
                links.map(link =>(
                    <LinkItem
                        key = {link.hash}
                        url = {link.sqzLink}
                        longUrl = {link.longLink}
                    />
                )): null}
        </div>
    );
}

export default Links;