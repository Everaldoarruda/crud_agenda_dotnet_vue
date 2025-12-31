import { createRouter, createWebHistory } from 'vue-router';
import ContatosView from '../views/ContatosView.vue';

const routes = [
    { 
        path: '/', 
        name: 'Contatos', 
        component: ContatosView 
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
