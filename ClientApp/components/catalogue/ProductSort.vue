<template>
  <div>
    <span class="label mr-2">Sort by</span>
    <b-dropdown class="dropdown" right :text="items[selected]">
      <b-dropdown-item v-for="(item, index) in items" :key="index" @click="select(index)">{{ item }}</b-dropdown-item>
    </b-dropdown>
  </div>
</template>

<script>
export default {
  name: "product-sort",
  data() {
    return {
      items: [
        "Cost (Low to high)",
        "Cost (High to low)",
        "Name (A - Z)",
        "Name (Z - A)"
      ]
    };
  },
  computed: {
    selected() {
      return this.$route.query.sort || 0;
    }
  },
  methods: {
    select(index) {
      if (index === 0) {
        let query = Object.assign({}, this.$route.query);
        delete query.sort;

        this.$router.push({ query: query });
      } else {
        let query = Object.assign({}, this.$route.query);
        query.sort = index;

        this.$router.push({ query: query });
      }
    }
  }
};
</script>

<style lang="scss" scoped>
.label,
.dropdown {
  vertical-align: middle;
}
</style>
