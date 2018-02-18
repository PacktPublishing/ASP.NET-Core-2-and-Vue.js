<template>
  <div>
    <b-form-input
      :value="query"
      type="text"
      placeholder="Search..."
      @change="update"
      @keyup.enter.native="search">
    </b-form-input>
  </div>
</template>

<script>
export default {
  name: "search-bar",
  data() {
    return {
      value: ""
    };
  },
  computed: {
    query() {
      return this.$route.query.q || "";
    }
  },
  methods: {
    update(newVal) {
      this.value = newVal;
    },
    search() {
      let query = Object.assign({}, this.$route.query);

      if (this.value.trim()) {
        query.q = this.value;
      } else {
        delete query.q;
      }

      this.$router.push({ query: query });
    }
  }
};
</script>
