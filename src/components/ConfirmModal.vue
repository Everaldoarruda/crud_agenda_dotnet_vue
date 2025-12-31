<template>
  <transition name="modal-fade">
    <div v-if="visible" class="modal-overlay" @click.self="cancel">
      <div class="modal-container">
        <div class="modal-header">
          <span class="modal-icon">?</span>
          <h3>{{ title }}</h3>
        </div>
        <div class="modal-body">
          <p>{{ message }}</p>
        </div>
        <div class="modal-footer">
          <button @click="cancel" class="btn-cancel">Cancelar</button>
          <button @click="confirm" class="btn-confirm">Confirmar</button>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  name: 'ConfirmModal',
  props: {
    visible: {
      type: Boolean,
      default: false
    },
    title: {
      type: String,
      default: 'Confirmação'
    },
    message: {
      type: String,
      default: 'Tem certeza que deseja continuar?'
    }
  },
  methods: {
    confirm() {
      this.$emit('confirm');
      this.$emit('update:visible', false);
    },
    cancel() {
      this.$emit('cancel');
      this.$emit('update:visible', false);
    }
  }
};
</script>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.5);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 1000;
}

.modal-container {
  background: #ffffff;
  border-radius: 12px;
  box-shadow: 0 10px 40px rgba(0, 0, 0, 0.2);
  max-width: 400px;
  width: 90%;
  overflow: hidden;
}

.modal-header {
  padding: 24px 24px 16px;
  text-align: center;
}

.modal-icon {
  width: 50px;
  height: 50px;
  background: #fff3cd;
  color: #856404;
  border-radius: 50%;
  display: inline-flex;
  align-items: center;
  justify-content: center;
  font-size: 24px;
  font-weight: bold;
  margin-bottom: 16px;
}

.modal-header h3 {
  margin: 0;
  color: #212529;
  font-size: 1.25rem;
  font-weight: 600;
}

.modal-body {
  padding: 0 24px 24px;
  text-align: center;
}

.modal-body p {
  margin: 0;
  color: #6c757d;
  font-size: 15px;
  line-height: 1.5;
}

.modal-footer {
  padding: 16px 24px;
  background: #f8f9fa;
  display: flex;
  gap: 12px;
  justify-content: center;
}

.modal-footer button {
  padding: 10px 24px;
  border-radius: 6px;
  font-size: 14px;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.2s ease;
  border: none;
}

.btn-cancel {
  background: #6c757d;
  color: #ffffff;
}

.btn-cancel:hover {
  background: #545b62;
}

.btn-confirm {
  background: #dc3545;
  color: #ffffff;
}

.btn-confirm:hover {
  background: #c82333;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.3s ease;
}

.modal-fade-enter-from,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active .modal-container,
.modal-fade-leave-active .modal-container {
  transition: transform 0.3s ease;
}

.modal-fade-enter-from .modal-container,
.modal-fade-leave-to .modal-container {
  transform: scale(0.9);
}
</style>
