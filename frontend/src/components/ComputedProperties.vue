<template>
  <div>
    <h1>Computed Properties Example</h1>
    {{ fullName }}
  </div>
</template>

<script>
export default {
  name: 'computed-properties',
  data () {
    return {
      firstName: 'Stu',
      lastName: 'Ratcliffe'
    }
  },
  computed: {
    fullName () {
      return `${this.firstName} ${this.lastName}`
    }
  }
}
</script>