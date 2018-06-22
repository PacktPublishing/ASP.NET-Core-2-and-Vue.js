<template>
  <div>
    <h1>V-On PreventDefault Shorthand Example</h1>
    <button @click.prevent.stop="clickHandler">Click me!</button>
  </div>
</template>

<script>
export default {
  name: 'events',
  methods: {
    clickHandler () {
      alert('Button clicked!')
    }
  }
}
</script>