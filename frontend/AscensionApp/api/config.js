import axios from 'axios';

const instance = axios.create({
  baseURL: 'https://localhost:6061/',
  timeout: 10000,
  headers: {'Content-Type': 'application/json'},
});

export default instance;