<template>
  <div class="counter">
    <h1>Methods Example</h1>
    {{ counter }}
    <button @click="increment()">Increment</button>
  </div>  
</template>

<script>
export default {
  name: 'methods',
  data () {
    return {
      counter: 1
    }
  },
  methods: {
    increment () {
      this.counter++
    }
  }
}
</script>