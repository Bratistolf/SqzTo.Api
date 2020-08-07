import { combineReducers } from "redux";

const reducers = ["user"];

const rootReduser = combineReducers(
  reducers.reduce((initial, value) => {
    initial[value] = require(`./${value}`).default;
    return initial;
  }, {})
);

const delegatedReduser = (state, action) => {
  if (action.type === 'USER:LOGOUT') {
    console.log(state);
    console.log(action.type);
    state = undefined;
    console.log(state);
  }
  return rootReduser(state, action)
}

export default delegatedReduser
