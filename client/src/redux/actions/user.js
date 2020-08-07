//import { openNotification } from 'utils/helpers';
import { userApi } from 'utils/api';

const Actions = {
  setUserData: data => ({
    type: 'USER:SET_DATA',
    payload: data,
  }),
  setIsAuth: bool => ({
    type: 'USER:SET_IS_AUTH',
    payload: bool,
  }),
  clearState: () => ({
    type: 'USER:LOGOUT'
  }),

  fetchUserData: () => dispatch => {
      userApi
      .getMe()
      .then(({ data }) => {
        console.log("Запрос даты юзера");
        dispatch(Actions.setUserData(data));
      })
      .catch(err => {
        if (err.response.status === 403) {
          dispatch(Actions.setIsAuth(false));
          delete window.localStorage.token;
        }
      });
  },
  fetchUserLogin: postData => dispatch => {
    return userApi
      .signIn(postData)
      .then(({ data }) => {
        if(data.status === 'error'){return data;}
        const { token } = data;
        window.axios.defaults.headers.common['token'] = token;
        window.localStorage['token'] = token;
        dispatch(Actions.fetchUserData());
        dispatch(Actions.setIsAuth(true));
        return data;
      })
  },
  fetchUserRegister: postData => () => {
    return userApi.signUp(postData);
  },
  userLogOut: () => dispatch => {
    //window.axios.defaults.headers.delete;
    //window.localStorage.clear();
    dispatch(Actions.clearState());
  }
};

export default Actions;