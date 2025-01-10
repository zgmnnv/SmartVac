import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'http://localhost:5052/api'
});

// Интерсептор для добавления токена в заголовки запросов
apiClient.interceptors.request.use(config => {
    const token = localStorage.getItem('access_token');
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
}, error => Promise.reject(error));

export default apiClient;
