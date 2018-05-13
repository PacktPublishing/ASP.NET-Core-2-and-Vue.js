<template>
  <div class="form-group">
    <label v-if="label">{{ label }}</label>
    <slot><!--input will eventually go here --></slot>
  </div>
</template>

<script>
export default {
  name: "form-input-base",
  props: {
    label: {
      type: String
    },
    name: {
      type: String
    },
    value: {
      type: [String, Array]
    },
    error: {
      type: String
    }
  },
  computed: {
    classes() {
      return {
        "form-control": true,
        "is-valid": !!!this.error && this.value.length > 0,
        "is-invalid": !!this.error
      };
    }
  }
};
</script>