import React from "react";
import { Route } from "react-router-dom";

const Auth = () => (
    <section className="auth">
      <div className="auth__content">
        <Route exact path="/signin" component={'fff'} />
        <Route exact path="/signup" component={'haha'} />
      </div>
    </section>
  );
  
  export default Auth;