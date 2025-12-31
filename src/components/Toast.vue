<template>
  <transition name="toast-fade">
    <div v-if="visible" :class="['toast', type]">
      <span class="toast-icon">{{ icon }}</span>
      <span class="toast-message">{{ message }}</span>
    </div>
  </transition>
</template>

<script>
export default {
  name: 'Toast',
  props: {
    message: {
      type: String,
      default: ''
    },
    type: {
      type: String,
      default: 'success' // success, error, warning
    },
    duration: {
      type: Number,
      default: 3000
    }
  },
  data() {
    return {
      visible: false
    };
  },
  computed: {
    icon() {
      const icons = {
        success: '✓',
        error: '✕',
        warning: '!'
      };
      return icons[this.type] || '✓';
    }
  },
  methods: {
    show() {
      this.visible = true;
      setTimeout(() => {
        this.visible = false;
        this.$emit('closed');
      }, this.duration);
    }
  },
  mounted() {
    this.show();
  }
};
</script>

<style scoped>
.toast {
  position: fixed;
  top: 20px;
  right: 20px;
  padding: 16px 24px;
  border-radius: 8px;
  display: flex;
  align-items: center;
  gap: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
  z-index: 1000;
  font-size: 15px;
  font-weight: 500;
}

.toast.success {
  background: #d4edda;
  color: #155724;
  border: 1px solid #c3e6cb;
}

.toast.error {
  background: #f8d7da;
  color: #721c24;
  border: 1px solid #f5c6cb;
}

.toast.warning {
  background: #fff3cd;
  color: #856404;
  border: 1px solid #ffeeba;
}

.toast-icon {
  width: 24px;
  height: 24px;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-weight: bold;
}

.success .toast-icon {
  background: #28a745;
  color: white;
}

.error .toast-icon {
  background: #dc3545;
  color: white;
}

.warning .toast-icon {
  background: #ffc107;
  color: #212529;
}

.toast-fade-enter-active,
.toast-fade-leave-active {
  transition: all 0.3s ease;
}

.toast-fade-enter-from,
.toast-fade-leave-to {
  opacity: 0;
  transform: translateX(100%);
}
</style>
