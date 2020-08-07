import {REGEXP_URL} from '../constants'

export default{
    checkUrl: (url) => {
        console.log(REGEXP_URL.test(url));
        return REGEXP_URL.test(url)
    },
} 