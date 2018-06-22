<template>
  <span>
    <h1>Style Binding Example</h1>
    <div :class="{ 'blue': isBlue }"></div>
  </span>
</template>

<script>
export default {
  name: 'v-bind',
  computed: {
    isBlue () {
      return Math.random(0, 1) > 0.5
    }
  }
}
</script>

<style scoped>
div {
  background: red;
  height: 50px;
  width: 100px;
}

div.blue {
  background: blue;
}
</style>