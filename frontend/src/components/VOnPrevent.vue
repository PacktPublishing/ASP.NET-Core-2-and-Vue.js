<template>
  <div>
    <h1>V-On PreventDefault Example</h1>
    <button @click="clickHandler">Click me!</button>
  </div>
</template>
<script>
export default {
  name: 'events',
  methods: {
    clickHandler (event) {
      event.preventDefault()
      event.stopPropagation()
      alert('Button clicked!')
    }
  }
}
</script>