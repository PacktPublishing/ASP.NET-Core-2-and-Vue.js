<template>
  <b-container class="pt-4">
    <b-media>
      <img slot="aside" :src="product.thumbnail" :alt="product.name" />

      <h2>{{ product.name }}</h2>

      <p class="mt-4 mb-4">
        {{ product.shortDescription }}
      </p>

      <p class="mt-4 mb-4">{{ product.price }}</p>

      <b-button variant="primary">Add to cart</b-button>
    </b-media>

    <h3 class="mt-4">Product details</h3>
    <p class="mt-4 mb-4">
      {{ product.description }}
    </p>
  </b-container>
</template>

<script>
export default {
  name: "product-details",
  props: {
    product: {
      type: Object,
      required: true
    }
  }
};
</script>
