import React from 'react';
import {Link} from 'react-router-dom'
import {Block, Input, Button} from "components"
import './signin.scss'

const SignInForm = (props) => {
    return (
        <Block>
            <h1>ВХОД</h1>
            <Input placeholder='ИМЯ ПОЛЬЗОВАТЕЛЯ / E-MAIL' />
            <Input placeholder='ПАРОЛЬ' type = 'password' />
            <Button> Войти </Button>
            <Link to={'/signup'} className = 'link-to-signup'>или зарегистрируйтесь</Link> 
        </Block>
    );
}

export default SignInForm;