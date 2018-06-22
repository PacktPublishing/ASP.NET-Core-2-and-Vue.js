<template>
  <div>
    <h1>V-On Multiple Events Example</h1>
    <button v-on="{ click: clickHandler, mouseover: hoverHandler }">Click or hover</button>
  </div>
</template>

<script>
export default {
  name: 'v-on-multiple',
  methods: {
    clickHandler () {
      alert('Button clicked!')
    },
    hoverHandler () {
      alert('Button hovered!')
    }
  }
}
</script>
