import { createRouter, createWebHistory } from 'vue-router';
import Registration from '@/components/Registration.vue';
import Login from '@/components/Login.vue';

const routes = [
    { path: '/registration', name: 'Registration', component: Registration }, // Имя должно быть строкой
    { path: '/login', name: 'Login', component: Login }, // Имя должно быть строкой
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
