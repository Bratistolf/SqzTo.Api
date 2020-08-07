import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router } from "react-router-dom";
import {Provider} from 'react-redux'
import { userActions } from "redux/actions";

import App from './App';
import store from 'redux/store'

import "./index.scss"

//store.dispatch(userActions.fetchUserData());

ReactDOM.render(
  <Provider store = {store}>
    <React.StrictMode>
      <App />
    </React.StrictMode> 
  </Provider>,
  document.getElementById('root')
);
