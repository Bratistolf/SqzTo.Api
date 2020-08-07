import React, {Component} from 'react';
import { Route, Redirect, Switch } from "react-router-dom";
import {BrowserRouter} from 'react-router-dom';
import {Home, Auth} from "pages";

const App = props => {
  const  isAuth  = true;
  return (
    <div className="wrapper">
      <BrowserRouter>
        <Switch>
          <Route
            exact
            path={["/signin", "/signup", "/signup/verify"]}
            component={Auth}
          />
          <Route
            path="/"
            component = {Home}
            //render={() => (isAuth ? <Home /> : <Redirect to="/signin" />)}
          />
        </Switch>
      </BrowserRouter>
    </div>
  );
};


export default App;
