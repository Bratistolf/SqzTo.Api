import React, {Component} from 'react';
import { NavLink} from 'react-router-dom';
import './header.scss'
import Logo from 'pictures/svg/lemon.png'

class Header extends Component {
    render() {
        return (
            <div className = "header">
                <div className = "header-content">
                <NavLink to={'/'}>
                    <img src = {Logo} alt = "logo-icon"/>
                </NavLink>     
                    <nav>
                        <NavLink exact to="/signup">{"SignUp"}</NavLink>
                        <NavLink exact to="/signin">{"SignIn"}</NavLink>    
                    </nav>
                </div>
            </div>
        );
    }
}


export default Header