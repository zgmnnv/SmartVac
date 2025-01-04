import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/components/Home.vue';
import Registration from '@/components/Registration.vue';
import Login from '@/components/Login.vue';

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', component: Home },
        { path: '/registration', component: Registration },
        { path: '/login', component: Login },
    ],
});

async function checkAuth(to, from, next) {
    const token = localStorage.getItem('access_token');
    const isAuthenticated = !!token; // Проверяем наличие токена

    if (to.matched.some(record => record.meta.requiresAuth)) {
        // Если маршрут требует аутентификацию
        if (isAuthenticated) {
            // Если пользователь аутентифицирован, разрешаем переход
            next();
        } else {
            // Если не аутентифицирован, отправляем на страницу входа
            next({ name: 'login' });
        }
    } else {
        // Если маршрут не требует аутентификацию
        if (isAuthenticated && to.name === 'login') {
            // Если пользователь аутентифицирован и пытается зайти на страницу входа, отправляем на аккаунт
            next({ name: 'account' });
        } else {
            // В остальных случаях просто разрешаем переход
            next();
        }
    }
}

router.beforeEach(checkAuth);

export default router;