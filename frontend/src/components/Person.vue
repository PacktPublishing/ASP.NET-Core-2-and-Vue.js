<template>
  <div>
    <input type="text" name="name" v-model="name" />
    <button @click="save()">Save</button>
  </div>  
</template>

<script>
export default {
  name: 'person',
  data () {
    return {
      name: 'Stu Ratcliffe'
    }
  },
  methods: {
    save () {
      this.$emit('name-changed', this.name)
    }
  }
}
</script>