<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: var(--text-dark);
  margin: 0;
  padding: 0;
  min-height: 100vh;
}

body {
  margin: 0;
  padding: 0;
  background: linear-gradient(135deg, #e3f2fd 0%, #bbdefb 100%);
}
</style>
