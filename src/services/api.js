import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:5001;http://localhost:5000', // Substitua pela URL do seu backend
});

export default api;
