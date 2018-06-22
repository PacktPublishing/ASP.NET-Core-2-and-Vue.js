<template>
  <div class="product">
    <h1>Single File Component Example</h1>
    {{ name }}
  </div>
</template>


<script>
export default {
  name: 'product',
  data () {
    return {
      name: 'Hands on Vue.js and ASP.NET Core'
    }
  }
}
</script>

<style>
.product {
  font-size: 12px;
  font-weight: bold;
  color: teal;
}
</style>