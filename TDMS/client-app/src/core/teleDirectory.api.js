import { httpClient } from "@/core/httpClient.js"
//import axios from 'axios';
const postTeleDirectory = (data) => {
   
    const response = httpClient.post("TeleDirectory", data);
    // console.log(response);
    return response;

}
const putTeleDirectory = (data) => {
    
    const response = httpClient.put("TeleDirectory", data);
    console.log(response);
    return response;

}
const getTeleDirectory = () => {
    const response = httpClient.get("TeleDirectory");
    return response;
}
const deleteTeleDirectory = (id) => {
    const response = httpClient.delete("TeleDirectory/"+id);
    return response;
}
export {
    postTeleDirectory,
    getTeleDirectory,
    putTeleDirectory,
    deleteTeleDirectory
}

