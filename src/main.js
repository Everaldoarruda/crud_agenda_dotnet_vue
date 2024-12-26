import { createApp } from 'vue';
import PrimeVue from 'pimevue/config';
import 'primevue/resources/themes/saga-blue/theme.css';
import 'primevue/resources/themes/saga-blue/theme.css';
import 'primevue/resources/primevue.min.css'; // Estilo base
import 'primeflex/primeflex.css'; // Utilitários CSS
import router from './router'; // Configuração de rotas

const app = createApp(App);
app.use(PrimeVue);
app.use(router);
app.mount('#app');
