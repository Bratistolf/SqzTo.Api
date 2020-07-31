import { axios } from "core";


export default {
    createSqzLink: ({url}) => 
        axios.post("/v1/sqzlink", {url}),
    getSqzLink: route => 
        axios.get("/v1/sqzlink/"+ route)   
};