<template>
  <div>
    <h1>Form Input Value Example</h1>
    <input type="text" :value="value" />
    <p>
      Current value is: {{ value }}
    </p>
  </div>
</template>

<script>
export default {
  name: 'form-input-value',
  data () {
    return {
      value: 'Input Value'
    }
  }
}
</script>
