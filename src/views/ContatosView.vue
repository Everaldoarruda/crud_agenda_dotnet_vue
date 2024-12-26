<template>
    <div>
      <h1>Contatos</h1>
      <ul>
        <li v-for="contato in contatos" :key="contato.id">
          {{ contato.nome }} - {{ contato.email }} - {{ contato.telefone }}
          <button @click="deleteContato(contato.id)">Excluir</button>
        </li>
      </ul>
      <form @submit.prevent="addContato">
        <input v-model="novoContato.nome" placeholder="Nome" />
        <input v-model="novoContato.email" placeholder="Email" />
        <input v-model="novoContato.telefone" placeholder="Telefone" />
        <button type="submit">Adicionar</button>
      </form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        contatos: [],
        novoContato: {
          nome: '',
          email: '',
          telefone: ''
        }
      };
    },
    methods: {
      async fetchContatos() {
        const response = await axios.get('https://localhost:5001/api/contatos');
        this.contatos = response.data;
      },
      async addContato() {
        await axios.post('https://localhost:5001/api/contatos', this.novoContato);
        this.novoContato = { nome: '', email: '', telefone: '' };
        this.fetchContatos();
      },
      async deleteContato(id) {
        await axios.delete(`https://localhost:5001/api/contatos/${id}`);
        this.fetchContatos();
      }
    },
    created() {
      this.fetchContatos();
    }
  };
  </script>
  