<template>
  <div>
    <h1>Interpolation Example</h1>
    {{ message }}
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