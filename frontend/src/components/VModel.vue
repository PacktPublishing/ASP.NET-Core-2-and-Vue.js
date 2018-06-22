<template>
  <div>
    <h1>V-Model Example</h1>
    <input type="text" v-model="value" />
    <p>
      Current value is: {{ value }}
    </p>
  </div>
</template>

<script>
export default {
  name: 'v-model',
  data () {
    return {
      value: 'Input Value'
    }
  }
}
</script>
