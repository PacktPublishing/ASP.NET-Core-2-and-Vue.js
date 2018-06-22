<template>
  <div>
    <h1>V-For with Index Example</h1>
    <div v-for="(item, index) in items" :key="item">
      {{ index }} - {{ item }}
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