<template>
  <b-row>
    <b-col cols="6">
      <div :class="{ 'filter-item': true,  'active': selected.length === 0 }" @click="clear">All</div>
    </b-col>
    <b-col cols="6" v-for="item in items" :key="item">
      <div :class="{ 'filter-item': true, 'active': selected.indexOf(item) > -1 }" @click="filter(item)">{{ item }}</div>
    </b-col>
  </b-row>
</template>

<script>
export default {
  name: "multi-select-filter",
  props: {
    queryKey: {
      type: String,
      required: true
    },
    items: {
      type: Array,
      required: true
    }
  },
  computed: {
    selected() {
      return this.$route.query[this.queryKey] || "";
    }
  },
  methods: {
    clear() {
      if (this.selected.length) {
        let query = Object.assign({}, this.$route.query);
        delete query[this.queryKey];

        this.$router.push({ query: query });
      }
    },
    filter(item) {
      let query = Object.assign({}, this.$route.query);
      let split = query[this.queryKey] ? query[this.queryKey].split("|") : [];

      if (split.indexOf(item) > -1) {
        let index = split.indexOf(item);
        split.splice(index, 1);
      } else {
        split.push(item);
      }

      if (split.length) {
        let joined = split.join("|");
        query[this.queryKey] = joined;
      } else {
        delete query[this.queryKey];
      }

      this.$router.push({ query: query });
    }
  }
};
</script>

<style lang="scss" scoped>
.filter-item {
  margin: 10px 0;
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px;
  text-align: center;
  cursor: pointer;

  &.active {
    font-weight: bold;
    color: #17a2b8;
    border-color: #17a2b8;
  }
}
</style>
