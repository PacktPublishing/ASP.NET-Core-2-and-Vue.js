<template>
  <b-container class="pt-4">
    <b-button variant="outline-secondary" @click.prevent="back">
      <i class="fas fa-arrow-left"></i>
      Back to results
    </b-button>
    <b-row class="pt-4">
      <b-col cols="5">
        <b-row>
          <b-col class="mb-2" v-for="(image, index) in product.images" :key="index" :cols="index === 0 ? 12 : 4">
            <img class="img-fluid" 
              :src="image" 
              :alt="product.name" 
              @click="openGallery(index)" />
          </b-col>
        </b-row>
      </b-col>

      <b-col cols="7">
        <h2>{{ product.name }}</h2>

        <p class="mt-4 mb-4">
          {{ product.shortDescription }}
        </p>

        <h5>Features</h5>
        <ul>
          <li v-for="feature in product.features" :key="feature">{{ feature }}</li>
        </ul>

        <h5>Variants</h5>
        <b-form-group label="Colour">
          <b-form-select :options="product.colours" v-model="colour" />
        </b-form-group>

        <b-form-group label="Capacity">
          <b-form-select :options="product.storage" v-model="capacity" />
        </b-form-group>

        <p class="mt-4 mb-4">
          <b>Price:</b> {{ variant.price | currency }}
        </p>

        <b-button variant="primary" @click="addProductToCart">Add to cart</b-button>
      </b-col>
    </b-row>
    <b-row>
      <b-col cols="12">
        <h3 class="mt-4">Product details</h3>
        <p class="mt-4 mb-4">
          {{ product.description }}
        </p>
      </b-col>
    </b-row>

    <transition name="fade" mode="out-in">
      <gallery v-if="open" :images="product.images" :initial="index" @close="open = false" />
    </transition>
  </b-container>
</template>

<script>
import Gallery from "./Gallery.vue";

export default {
  name: "product-details",
  props: {
    product: {
      type: Object,
      required: true
    }
  },
  components: {
    Gallery
  },
  created() {
    this.colour = this.product.colours[0].value;
    this.capacity = this.product.storage[0].value;
  },
  data() {
    return {
      open: false,
      index: 0,
      colour: null,
      capacity: null
    };
  },
  computed: {
    variant() {
      return this.product.variants.find(
        v => v.colourId == this.colour && v.storageId == this.capacity
      );
    }
  },
  methods: {
    back() {
      this.$router.go(-1);
    },
    openGallery(index) {
      this.index = index;
      this.open = true;
    },
    addProductToCart() {
      this.$store.dispatch("addProductToCart", this.variant);
      this.$toastr("success", "Product added to cart successfully.");
    }
  }
};
</script>

<style lang="scss" scoped>
img {
  cursor: pointer;
}
</style>
