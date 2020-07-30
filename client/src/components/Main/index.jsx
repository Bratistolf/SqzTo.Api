import React, {Component} from "react"
import { Route, Switch } from "react-router-dom";

import UrlCreater from "modules/UrlCreater/containers"
import './main.scss'

class Main extends Component {
    render() {
        return (
            <div className = "main">
                {/* <Switch >
                    <Route exact path="/" component={UrlCreater}/>
                </Switch> */}
                <UrlCreater/>
            </div>
        );
    }
}

export default Main