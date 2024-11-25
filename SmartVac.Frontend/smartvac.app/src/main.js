import { createApp } from 'vue';
import App from './App.vue';
import router from './router'; // Если используется vue-router

// Создаём приложение и монтируем в #app
createApp(App).use(router).mount('#app');
