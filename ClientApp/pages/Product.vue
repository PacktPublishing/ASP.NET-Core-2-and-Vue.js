<template>
  <div class="page">
    <product-details v-if="product" :product="product" />
  </div>
</template>

<script>
import axios from "axios";
import ProductDetails from "../components/product/Details.vue";

export default {
  name: "product",
  components: {
    ProductDetails
  },
  computed: {
    product() {
      return this.$store.state.product;
    }
  },
  asyncData({ store, route }) {
    return store.dispatch("fetchProduct", route.params.slug);
  }
};
</script>
