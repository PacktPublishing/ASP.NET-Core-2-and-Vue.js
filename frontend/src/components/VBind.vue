<template>
  <div>
    <h1>Bind Example</h1>
    <div v-bind:text-content.prop="message"></div>
  </div>
</template>

<script>
export default {
  name: 'v-bind',
  data () {
    return {
      message: 'Hands on Vue.js and ASP.NET Core'
    }
  }
}
</script>