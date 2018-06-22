<template>
  <div>
    <h1>V-On Example</h1>
    <button v-on:click="clickHandler()">Click me!</button>
    <form v-on:submit="submitHandler()">
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
