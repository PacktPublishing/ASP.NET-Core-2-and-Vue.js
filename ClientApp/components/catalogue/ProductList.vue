<template>
  <div class="products">
    <b-container>
      <h1 class="mt-4 mb-4">Products</h1>
      <b-row>
        <b-col class="mb-4" sm="6" v-for="product in products" :key="product.id">
          <b-media class="product">
            <img slot="aside" :src="product.thumbnail" :alt="product.name" @click="view(product)" />

            <h2 class="mt-2" @click="view(product)">{{ product.name }}</h2>

            <p class="mt-4 mb-4">
              {{ product.shortDescription }}
            </p>

            <p class="mt-4 mb-4">{{ product.price }}</p>

            <b-button variant="primary">Add to cart</b-button>
          </b-media>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
export default {
  name: "product-list",
  props: {
    products: {
      type: Array,
      required: true
    }
  },
  methods: {
    view(product) {
      this.$router.push(`/products/${product.slug}`);
    }
  }
};
</script>

<style lang="scss" scoped>
.product {
  border: 3px solid #eee;

  img,
  h2 {
    cursor: pointer;
  }
}
</style>
