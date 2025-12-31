import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5225/api',
    headers: {
        'Content-Type': 'application/json'
    }
});

export default {
    getContatos() {
        return api.get('/contatos');
    },
    getContato(id) {
        return api.get(`/contatos/${id}`);
    },
    createContato(contato) {
        return api.post('/contatos', contato);
    },
    updateContato(id, contato) {
        return api.put(`/contatos/${id}`, contato);
    },
    deleteContato(id) {
        return api.delete(`/contatos/${id}`);
    }
};
