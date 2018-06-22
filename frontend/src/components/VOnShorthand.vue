<template>
  <div>
    <h1>V-On Shorthand Example</h1>
    <button @click="clickHandler()">Click me!</button>
    <form @submit="submitHandler()">
      <input type="text" />
    </form>
  </div>
</template>

<script>
export default {
  name: 'v-on',
  methods: {
    clickHandler () {
      alert('Button clicked!')
    },
    submitHandler () {
      alert('Form submitted!')
    }
  }
}
</script>
