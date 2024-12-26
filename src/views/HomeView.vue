<template>
    <div class="home">
        <h1>Bem-vindo à Agenda</h1>
        <Button label="Visualizar Contatos" icon="pi pi-users" @click="goToContatos"/>
    </div>
</template>

<script>
import Button from 'primevue/button';
import { useRouter } from 'vue-router';

export default {
    components: { Button },
    setup() {
        const router = useRouter();

        const goToContatos = () => {
            router.push('/contatos');
        };

        return { goToContatos };
    },
};
</script>

<style scoped>
.home {
    text-align: center;
    padding: 2rem;
}
</style>
