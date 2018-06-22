<template>
  <div>
    <h1>Expressions Example</h1>
    {{ firstName + ' ' + lastName }}
  </div>
</template>

<script>
export default {
  name: 'expressions',
  data () {
    return {
      firstName: 'Stu',
      lastName: 'Ratcliffe'
    }
  }
}
</script>