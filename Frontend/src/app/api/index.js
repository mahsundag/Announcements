import axios from "axios";
 
const PORT = 7159;
const API_URL = `https://localhost:${PORT}/`;
 
const axiosInstance = axios.create({
  baseURL: API_URL,
  withCredentials: false,
});
 
export default axiosInstance;
 