<template>
  <div class="product">
    <h1>Prop Validation Example</h1>
    {{ name }} - {{ description }} - {{ price }}
  </div>
</template>

<script>
export default {
  name: 'validation',
  props: {
    name: {
      type: String,
      required: true
    },
    description: {
      type: String,
      required: true
    },
    price: {
      type: Number,
      required: true
    }
  }
}
</script>