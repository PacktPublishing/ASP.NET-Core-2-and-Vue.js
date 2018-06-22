<template>
  <div>
    <h1>V-For Example</h1>
    <div v-for="item in items" :key="item">
      {{ item }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'v-for',
  data () {
    return {
      items: ['item1', 'item2', 'item3']
    }
  }
}
</script>
