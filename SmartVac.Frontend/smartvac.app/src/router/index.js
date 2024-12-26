import { createRouter, createWebHistory } from 'vue-router';
import App from '@/App.vue';
import Registration from '@/components/Registration.vue';
import Login from '@/components/Login.vue';
import Account from '@/components/Account.vue';

const routes = [
    { path: '/', component: App },
    { path: '/registration', name: 'Registration', component: Registration, meta: { requiresAuth: true } },
    { path: '/login', name: 'Login', component: Login, meta: { requiresAuth: false } },
    { path: '/account', name: 'Account', component: Account, beforeEnter: checkAuth, meta: { requiresAuth: true } },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

function checkAuth(to, from, next) {
    const token = localStorage.getItem('access_token');
    if (!token) {
        if (to.matched.some((route) => route.meta.requiresAuth) && !token) {
            return next({ name: 'login' });
        } else {
            if (to.name === 'login') {
                return next({ name: 'account' });
            }
        }
    }
    next();
}

// Устанавливаем глобальный перехватчик маршрутов
router.beforeEach(checkAuth);

// Экспортируем роутер
export default router;