import { httpClient } from "@/core/httpClient.js"
//import axios from 'axios';
const postTeleDirectory = (data) => {
    console.log(data);
    const response = httpClient.post("TeleDirectory",data);
    console.log(response);
    return response;

}
const getTeleDirectory = () => {

    const response = httpClient.get("TeleDirectory");

    return response;



}
export {
    postTeleDirectory,
    getTeleDirectory
}

