import React from "react"

import './block.scss'

const Block = ({children}) => (
    <div className="block">
        <div className = "block-content">
            {children}
        </div>
    </div>
  );

export default Block