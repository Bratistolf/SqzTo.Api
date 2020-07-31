import React, {Component} from 'react';
import './header.scss'
import Logo from 'pictures/svg/lemon.png'

class Header extends Component {
    render() {
        return (
            <div className = "header">
                <div className = "header-content">
                    <b>SqzTo</b>
                    <img src = {Logo} alt = "logo-icon"/>
                </div>
            </div>
        );
    }
}


export default Header