import { createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Contatos from '../views/Contatos.vue';

const routes = [
    { path: '/', 
        name: 'Home', 
        component: Home 
    },

    { path: '/contatos', 
        name: 'Contatos', 
        component: Contatos },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
