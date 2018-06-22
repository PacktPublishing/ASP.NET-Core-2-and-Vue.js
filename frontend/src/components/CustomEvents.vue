<template>
  <div>
    <h1>Custom Events Example</h1>
    <person @name-changed="handleNameChange" />
  </div>
</template>

<script>
import Person from './Person.vue'

export default {
  name: 'custom-events',
  components: {
    Person
  },
  methods: {
    handleNameChange (newName) {
      alert('Name changed! - ' + newName)
    }
  }
}
</script>
