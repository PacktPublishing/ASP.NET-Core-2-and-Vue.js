<template>
  <div>
    <h1>V-Show Example</h1>
    <button @click="toggle()">Toggle Show</button>
    <div v-show="show">
      v-show example
    </div>
  </div>
</template>

<script>
export default {
  name: 'v-show',
  data () {
    return {
      show: false
    }
  },
  methods: {
    toggle () {
      this.show = !this.show
    }
  }
}
</script>
