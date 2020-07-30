import { axios } from "core";


export default {
    getSqzLink: ({url}) => axios.post("/api/Url",{
        url: url,
    }),
};