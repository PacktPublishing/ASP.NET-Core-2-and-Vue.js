<template>
  <div>
    <h1>Bind Example</h1>
    <input v-bind:value="message" />
  </div>
</template>

<script>
export default {
  name: "data-binding",
  data() {
    return {
      message: "Hands on Vue.js and ASP.NET Core"
    };
  }
};
</script>