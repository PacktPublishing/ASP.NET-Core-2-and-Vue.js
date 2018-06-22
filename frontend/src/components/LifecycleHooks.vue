<template>
  <div>
    <h1>Lifecycle Hooks Example</h1>
    <i>Check the console!</i>
  </div>
</template>

<script>
export default {
  name: 'lifecycle-hooks',
  beforeCreate () {
    console.log('before create')
  },
  created () {
    console.log('created')
  },
  beforeMount () {
    console.log('before mount')
  },
  mounted () {
    console.log('mounted')
  },
  beforeUpdate () {
    console.log('before update')
  },
  updated () {
    console.log('updated')
  },
  beforeDestroy () {
    console.log('before destroy')
  },
  destroyed () {
    console.log('destroyed')
  }
}
</script>