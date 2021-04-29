import axios from 'axios';
const httpClient = axios.create({
    baseURL:"http://localhost:50110/api/" , // process.env.APP_BASE_URL,
    headers: {
        // "Authorization": "Bearer xxxxx"
      }
});

export  {
    httpClient
}