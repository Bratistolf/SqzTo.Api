import React from 'react';

import {Block, Input, Button} from "components"

const SignUpForm = (props) => {
    return (
        <Block>
            <h1>РЕГИСТРАЦИЯ</h1>
            <Input placeholder='ИМЯ ПОЛЬЗОВАТЕЛЯ / КОМПАНИИ' />
            <Input placeholder='E-MAIL' type = 'email'/>
            <Input placeholder='ПАРОЛЬ' type = 'password' />
            <Input placeholder='ПОДВЕРЖДЕНИЕ ПАРОЛЯ' type = 'password'/>
            <Button> Зарегистрироваться </Button>
        </Block>
    );
}

export default SignUpForm;