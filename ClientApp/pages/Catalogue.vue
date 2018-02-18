<template>
  <b-container fluid class="page">
    <b-row>
      <b-col cols="3">
        <filters v-if="products.length" :filters="filters" />
      </b-col>
      <b-col cols="9">
        <product-list v-if="products.length" :products="products" />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import axios from "axios";
import Filters from "../components/catalogue/Filters.vue";
import ProductList from "../components/catalogue/ProductList.vue";

export default {
  name: "catalogue",
  components: {
    Filters,
    ProductList
  },
  data() {
    return {
      products: [],
      filters: {
        brands: [],
        capacity: [],
        colours: [],
        os: [],
        features: []
      }
    };
  },
  methods: {
    setData(products, filters) {
      this.products = products;
      this.filters = filters;
    }
  },
  beforeRouteEnter(to, from, next) {
    axios
      .all([
        axios.get("/api/products", { params: to.query }),
        axios.get("/api/filters")
      ])
      .then(
        axios.spread((products, filters) => {
          next(vm => vm.setData(products.data, filters.data));
        })
      );
  },
  beforeRouteUpdate(to, from, next) {
    axios.get("/api/products", { params: to.query }).then(response => {
      this.products = response.data;
      next();
    });
  }
};
</script>
