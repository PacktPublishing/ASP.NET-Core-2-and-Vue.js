<template>
  <b-container fluid class="page">
    <b-row>
      <b-col cols="3">
        <filters :filters="filters" />
      </b-col>
      <b-col cols="9">
        <div class="mt-4 flex">
          <search-bar class="search" />
          <product-sort class="ml-4" />
        </div>
        <product-list :products="sortedProducts" />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import axios from "axios";
import Filters from "../components/catalogue/Filters.vue";
import SearchBar from "../components/catalogue/SearchBar.vue";
import ProductSort from "../components/catalogue/ProductSort.vue";
import ProductList from "../components/catalogue/ProductList.vue";

export default {
  name: "catalogue",
  components: {
    Filters,
    SearchBar,
    ProductSort,
    ProductList
  },
  computed: {
    sortedProducts() {
      return this.$store.getters.sortedProducts;
    },
    filters() {
      return this.$store.state.filters;
    }
  },
  asyncData({ store, route }) {
    return Promise.all([
      store.dispatch("fetchProducts", route.query),
      store.dispatch("fetchFilters")
    ]);
  },
  beforeRouteUpdate(to, from, next) {
    this.$store.dispatch("fetchProducts", to.query).then(() => {
      next();
    });
  }
};
</script>

<style lang="scss" scoped>
.flex {
  display: flex;
  flex-direction: row;

  .search {
    flex: 1;
  }
}
</style>
