<template>
  <div>
    <b-form-input
      :value="query"
      type="text"
      placeholder="Search..."
      @input="update"
      @keyup.enter.native="search">
    </b-form-input>
  </div>
</template>

<script>
import _ from "lodash";

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
    search: _.debounce(function() {
      let query = Object.assign({}, this.$route.query);

      if (this.value.trim()) {
        query.q = this.value;
      } else {
        delete query.q;
      }

      this.$router.push({ query: query });
    }, 500)
  },
  watch: {
    value(newValue) {
      this.search();
    }
  }
};
</script>
