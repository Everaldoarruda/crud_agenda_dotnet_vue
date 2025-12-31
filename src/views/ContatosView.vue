<template>
    <div class="contatos-container">
      <h1>Agenda Everaldo</h1>
      
      <!-- Toast de Notificação -->
      <Toast 
        v-if="toast.show" 
        :message="toast.message" 
        :type="toast.type" 
        @closed="toast.show = false"
      />

      <!-- Modal de Confirmação -->
      <ConfirmModal 
        :visible="confirmModal.show"
        :title="confirmModal.title"
        :message="confirmModal.message"
        @confirm="confirmDelete"
        @cancel="confirmModal.show = false"
        @update:visible="confirmModal.show = $event"
      />
      
      <div class="add-form">
        <h2>{{ editMode ? 'Editar Contato' : 'Adicionar Contato' }}</h2>
        <form @submit.prevent="saveContato">
          <input v-model="novoContato.nome" placeholder="Nome" required />
          <input v-model="novoContato.email" placeholder="Email" type="email" required />
          <input v-model="novoContato.telefone" placeholder="Telefone" required />
          <div class="form-actions">
            <button type="submit" class="save-btn">{{ editMode ? 'Atualizar' : 'Adicionar' }}</button>
            <button v-if="editMode" type="button" @click="cancelEdit" class="cancel-btn">Cancelar</button>
          </div>
        </form>
      </div>

      <div class="contatos-list">
        <h2>Lista de Contatos</h2>
        <div v-if="contatos.length === 0" class="empty-message">
          Nenhum contato cadastrado.
        </div>
        <ul v-else>
          <li v-for="contato in contatos" :key="contato.id" class="contato-item">
            <div class="contato-info">
              <strong>{{ contato.nome }}</strong>
              <span>{{ contato.email }}</span>
              <span>{{ contato.telefone }}</span>
            </div>
            <div class="action-buttons">
              <button @click="editContato(contato)" class="edit-btn">Editar</button>
              <button @click="showDeleteConfirm(contato.id)" class="delete-btn">Excluir</button>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </template>
  
  <script>
  import api from '../services/api';
  import Toast from '../components/Toast.vue';
  import ConfirmModal from '../components/ConfirmModal.vue';
  
  export default {
    components: {
      Toast,
      ConfirmModal
    },
    data() {
      return {
        contatos: [],
        novoContato: {
          nome: '',
          email: '',
          telefone: ''
        },
        editMode: false,
        editId: null,
        toast: {
          show: false,
          message: '',
          type: 'success'
        },
        confirmModal: {
          show: false,
          title: 'Excluir Contato',
          message: 'Tem certeza que deseja excluir este contato?',
          deleteId: null
        }
      };
    },
    methods: {
      showToast(message, type = 'success') {
        this.toast = { show: true, message, type };
      },
      async fetchContatos() {
        try {
          const response = await api.getContatos();
          this.contatos = response.data;
        } catch (error) {
          console.error('Erro ao buscar contatos:', error);
          this.showToast('Erro ao buscar contatos. Verifique se o backend está rodando.', 'error');
        }
      },
      async saveContato() {
        try {
          if (this.editMode) {
            await api.updateContato(this.editId, this.novoContato);
            this.showToast('Contato atualizado com sucesso!', 'success');
            this.editMode = false;
            this.editId = null;
          } else {
            await api.createContato(this.novoContato);
            this.showToast('Contato adicionado com sucesso!', 'success');
          }
          this.novoContato = { nome: '', email: '', telefone: '' };
          this.fetchContatos();
        } catch (error) {
          console.error('Erro ao salvar contato:', error);
          this.showToast('Erro ao salvar contato.', 'error');
        }
      },
      editContato(contato) {
        this.editMode = true;
        this.editId = contato.id;
        this.novoContato = {
          id: contato.id,
          nome: contato.nome, 
          email: contato.email, 
          telefone: contato.telefone 
        };
        window.scrollTo({ top: 0, behavior: 'smooth' });
      },
      cancelEdit() {
        this.editMode = false;
        this.editId = null;
        this.novoContato = { nome: '', email: '', telefone: '' };
      },
      showDeleteConfirm(id) {
        this.confirmModal.deleteId = id;
        this.confirmModal.show = true;
      },
      async confirmDelete() {
        try {
          await api.deleteContato(this.confirmModal.deleteId);
          this.fetchContatos();
          this.showToast('Contato excluído com sucesso!', 'success');
        } catch (error) {
          console.error('Erro ao excluir contato:', error);
          this.showToast('Erro ao excluir contato.', 'error');
        }
        this.confirmModal.show = false;
        this.confirmModal.deleteId = null;
      }
    },
    created() {
      this.fetchContatos();
    }
  };
  </script>

  <style scoped>
  .contatos-container {
    max-width: 800px;
    margin: 0 auto;
    padding: 30px 20px;
    background: #ffffff;
  }

  h1 {
    color: #212529;
    text-align: center;
    font-size: 2rem;
    margin-bottom: 30px;
    font-weight: 700;
  }

  h2 {
    color: #212529;
    font-size: 1.25rem;
    margin-bottom: 20px;
    font-weight: 600;
  }

  .add-form {
    background: #ffffff;
    padding: 25px;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    margin-bottom: 30px;
    border: 1px solid #dee2e6;
  }

  form {
    display: flex;
    flex-direction: column;
    gap: 15px;
  }

  .form-actions {
    display: flex;
    gap: 15px;
    margin-top: 10px;
  }

  input {
    padding: 12px 14px;
    border: 1px solid #ced4da;
    border-radius: 6px;
    font-size: 14px;
    transition: border-color 0.2s ease;
    background: #ffffff;
    color: #212529;
  }

  input:focus {
    outline: none;
    border-color: #007bff;
    box-shadow: 0 0 0 3px rgba(0, 123, 255, 0.15);
  }

  input::placeholder {
    color: #6c757d;
  }

  button {
    padding: 10px 20px;
    color: #ffffff;
    border: none;
    border-radius: 6px;
    cursor: pointer;
    font-size: 14px;
    font-weight: 600;
    transition: all 0.2s ease;
  }

  .save-btn {
    background: #28a745;
    flex: 1;
  }

  .save-btn:hover {
    background: #218838;
  }

  .cancel-btn {
    background: #6c757d;
  }

  .cancel-btn:hover {
    background: #545b62;
  }

  .action-buttons {
    display: flex;
    gap: 8px;
  }

  .edit-btn {
    background: #007bff;
    padding: 8px 16px;
  }

  .edit-btn:hover {
    background: #0056b3;
  }

  .contatos-list {
    background: #ffffff;
    padding: 25px;
    border-radius: 8px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    border: 1px solid #dee2e6;
  }

  ul {
    list-style: none;
    padding: 0;
    margin: 0;
  }

  .contato-item {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 15px;
    border-bottom: 1px solid #dee2e6;
    transition: background-color 0.2s ease;
    background: #ffffff;
  }

  .contato-item:hover {
    background: #f8f9fa;
  }

  .contato-item:last-child {
    border-bottom: none;
  }

  .contato-info {
    display: flex;
    flex-direction: column;
    gap: 4px;
  }

  .contato-info strong {
    color: #212529;
    font-size: 16px;
    font-weight: 600;
  }

  .contato-info span {
    color: #6c757d;
    font-size: 14px;
  }

  .delete-btn {
    background: #dc3545;
    padding: 8px 16px;
  }

  .delete-btn:hover {
    background: #c82333;
  }

  .empty-message {
    text-align: center;
    color: #6c757d;
    padding: 30px;
    font-size: 15px;
  }
  </style>
  