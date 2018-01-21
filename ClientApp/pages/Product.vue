<template>
  <product-details :product="product" />
</template>

<script>
import ProductDetails from "../components/product/Details.vue";

export default {
  name: "product",
  components: {
    ProductDetails
  },
  data() {
    return {
      product: null
    };
  },
  mounted() {
    const slug = this.$route.params.slug;

    fetch(`/api/products/${slug}`)
      .then(response => {
        return response.json();
      })
      .then(product => {
        this.product = product;
      });
  }
};
</script>
