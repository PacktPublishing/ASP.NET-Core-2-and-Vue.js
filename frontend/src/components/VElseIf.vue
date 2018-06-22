<template>
  <div>
    <h1>V-Else-If Example</h1>
    <button @click="showIf()">Show If</button>
    <button @click="showElseIf()">Show Else If</button>
    <button @click="showElse()">Show Else</button>
    <div v-if="show">
      v-if example
    </div>
    <div v-else-if="show2">
      v-else-if example
    </div>
    <div v-else>
      v-else example
    </div>
  </div>
</template>

<script>
export default {
  name: 'v-else',
  data () {
    return {
      show: true,
      show2: false
    }
  },
  methods: {
    showIf () {
      this.show = true
      this.show2 = false
    },
    showElseIf () {
      this.show = false
      this.show2 = true
    },
    showElse () {
      this.show = false
      this.show2 = false
    }
  }
}
</script>
