import { axios } from "core";

export default {
  signIn: postData => axios.post("api/user/signin", postData),
  signUp: postData => axios.post("api/user/signup", postData),
  verifyHash: hash => axios.get("api/user/verify?hash=" + hash),
};