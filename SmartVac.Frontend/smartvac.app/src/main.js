import { createApp } from 'vue';
import App from './App.vue';
import router from './router'; // Если используется vue-router

const app = createApp(App);

app.use(router); // Подключаем маршрутизатор
app.mount('#app');