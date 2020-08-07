import React from "react";
import { Route } from "react-router-dom";

import SignUpForm from "modules/SignUp"
import SignInForm from "modules/SignIn"

import {Header, Main} from "components"

const Auth = () => (
    <section className="auth">
      <div className="auth__content">
        <Header/>
        <Main>
          <Route exact path="/signin" component={SignInForm} />
          <Route exact path="/signup" component={SignUpForm} />
        </Main>
      </div>
    </section>
  );
  
  export default Auth;