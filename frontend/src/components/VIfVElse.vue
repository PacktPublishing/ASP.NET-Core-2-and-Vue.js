<template>
  <div>
    <h1>V-If V-Else Example</h1>
    <button @click="toggle()">Toggle Show</button>
    <div v-if="show">
      v-if example
    </div>
    <div v-else>
      v-else example
    </div>
  </div>
</template>

<script>
export default {
  name: 'v-if-v-else',
  data () {
    return {
      show: true
    }
  },
  methods: {
    toggle () {
      this.show = !this.show
    }
  }
}
</script>
