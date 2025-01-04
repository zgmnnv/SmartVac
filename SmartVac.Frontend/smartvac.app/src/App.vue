<template>
  <div class="smart-vaccine">
    <router-view/>
  </div>
</template>

<script>
import { createRouter, createWebHistory } from 'vue-router';
import Home from '@/components/Home.vue';
import Registration from '@/components/Registration.vue';
import Login from '@/components/Login.vue';

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {path: '/', component: Home},
    {path: '/registration', component: Registration},
    {path: '/login', component: Login},
  ],
});

export default {
  name: "SmartVaccine",
  components: {Home, Registration, Login},
  setup() {
    return {};
  },
};
</script>