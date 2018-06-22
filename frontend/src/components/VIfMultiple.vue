<template>
  <div>
    <h1>V-If Multiple Example</h1>
    <button @click="toggle()">Toggle Show</button>
    <template v-if="show">
      <div class="first">First</div>
      <div class="second">Second</div>
      <div class="third">Third</div>
    </template>
  </div>
</template>

<script>
export default {
  name: 'v-if-multiple',
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
