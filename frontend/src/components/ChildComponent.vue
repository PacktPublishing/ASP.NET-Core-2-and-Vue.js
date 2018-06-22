<template>
  <div class="product">
    <h1>Child Component Example</h1>
    {{ name }}
  </div>
</template>

<script>
export default {
  name: 'product',
  props: ['name']
}
</script>