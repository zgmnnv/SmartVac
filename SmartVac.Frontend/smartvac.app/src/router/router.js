import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/components/Home.vue';
import Registration from '@/components/Registration.vue';
import Login from '@/components/Login.vue';
import Account from '@/components/Account.vue';
import Kids from "@/components/Kids.vue";
import AddKids from "@/components/AddKids.vue";
import KidsAccount from "@/components/KidsAccount.vue";


const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', component: Home },
        { path: '/registration', component: Registration },
        { path: '/login', component: Login },
        { path: '/account', component: Account },
        { path: '/kids', component: Kids },
        { path: '/add_kids', component: AddKids },
        { path: '/kids_account/:id', component: KidsAccount },

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