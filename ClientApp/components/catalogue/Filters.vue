<template>
  <div class="filters mb-4">
    <h5 class="mt-4">Filters</h5>
    <b-btn variant="outline-secondary" @click.prevent="reset"><i class="fas fa-sync mr-2"></i> Reset</b-btn>
    <b-list-group class="mt-4">
      <filter-accordion>
        <span slot="header">Brand</span>
        <b-row slot="body">
          <b-col cols="6">
            <div :class="{ 'filter-item': true,  'active': brands.length === 0 }" @click="clearBrands">All</div>
          </b-col>
          <b-col cols="6" v-for="item in filters.brands" :key="item">
            <div :class="{ 'filter-item': true, 'active': brands.indexOf(item) > -1 }" @click="filterBrand(item)">{{ item }}</div>
          </b-col>
        </b-row>
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Price</span>
        <div class="slider" slot="body">
          <vue-slider 
            :value="price"
            formatter="£{value}" 
            :min=0
            :max=1000
            :interval=50
            :lazy=true
            width="90%"
            @callback="filterPrice">
          </vue-slider>
        </div>
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Screen size</span>
        <div class="slider" slot="body">
          <vue-slider
            :value="screenSize"
            formatter="{value} in"
            :min=0
            :max=7
            :lazy=true
            width="90%"
            @callback="filterScreenSize">
          </vue-slider>
        </div>
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Capacity</span>
        <b-row slot="body">
          <b-col cols="6">
            <div :class="{ 'filter-item': true, 'active': capacity.length === 0 }" @click="clearCapacity">All</div>
          </b-col>
          <b-col cols="6" v-for="item in filters.storage" :key="item">
            <div :class="{ 'filter-item': true, 'active': capacity.indexOf(item) > -1 }" @click="filterCapacity(item)">{{ item }}</div>
          </b-col>
        </b-row>
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Colour</span>
        <b-row slot="body">
          <b-col cols="6">
            <div :class="{ 'filter-item': true,  'active': colours.length === 0 }" @click="clearColours">All</div>
          </b-col>
          <b-col cols="6" v-for="item in filters.colours" :key="item">
            <div :class="{ 'filter-item': true, 'active': colours.indexOf(item) > -1 }" @click="filterColour(item)">{{ item }}</div>
          </b-col>
        </b-row>
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Operating system</span>
        <b-row slot="body">
          <b-col cols="6">
            <div :class="{ 'filter-item': true,  'active': os.length === 0 }" @click="clearOS">All</div>
          </b-col>
          <b-col cols="6" v-for="item in filters.os" :key="item">
            <div :class="{ 'filter-item': true, 'active': os.indexOf(item) > -1 }" @click="filterOS(item)">{{ item }}</div>
          </b-col>
        </b-row>
      </filter-accordion>
      <filter-accordion>
        <span slot="header">Features</span>
        <b-row slot="body">
          <b-col cols="6">
            <div :class="{ 'filter-item': true,  'active': features.length === 0 }" @click="clearFeatures">All</div>
          </b-col>
          <b-col cols="6" v-for="item in filters.features" :key="item">
            <div :class="{ 'filter-item': true, 'active': features.indexOf(item) > -1 }" @click="filterFeature(item)">{{ item }}</div>
          </b-col>
        </b-row>
      </filter-accordion>
    </b-list-group>
  </div>
</template>

<script>
import FilterAccordion from "./FilterAccordion.vue";
import vueSlider from "vue-slider-component";

export default {
  name: "filters",
  props: {
    filters: {
      type: Object,
      required: true
    }
  },
  components: {
    FilterAccordion,
    vueSlider
  },
  computed: {
    brands() {
      return this.$route.query.brands || "";
    },
    price() {
      return [
        this.$route.query.minPrice || 0,
        this.$route.query.maxPrice || 1000
      ];
    },
    screenSize() {
      return [
        this.$route.query.minScreen || 0,
        this.$route.query.maxScreen || 7
      ];
    },
    capacity() {
      return this.$route.query.capacity || "";
    },
    colours() {
      return this.$route.query.colours || "";
    },
    os() {
      return this.$route.query.os || "";
    },
    features() {
      return this.$route.query.features || "";
    }
  },
  methods: {
    reset() {
      this.$router.push({ query: {} });
    },
    clearBrands() {
      if (this.brands.length) {
        let query = Object.assign({}, this.$route.query);
        delete query.brands;

        this.$router.push({ query: query });
      }
    },
    filterBrand(brand) {
      let query = Object.assign({}, this.$route.query);
      let split = query.brands ? query.brands.split("|") : [];

      if (split.indexOf(brand) > -1) {
        let index = split.indexOf(brand);
        split.splice(index, 1);
      } else {
        split.push(brand);
      }

      if (split.length) {
        let joined = split.join("|");
        query.brands = joined;
      } else {
        delete query.brands;
      }

      this.$router.push({ query: query });
    },
    filterPrice(prices) {
      let query = Object.assign({}, this.$route.query);
      query.minPrice = prices[0];
      query.maxPrice = prices[1];

      this.$router.push({ query: query });
    },
    filterScreenSize(sizes) {
      let query = Object.assign({}, this.$route.query);
      query.minScreen = sizes[0];
      query.maxScreen = sizes[1];

      this.$router.push({ query: query });
    },
    clearCapacity() {
      if (this.capacity.length) {
        let query = Object.assign({}, this.$route.query);
        delete query.capacity;

        this.$router.push({ query: query });
      }
    },
    filterCapacity(capacity) {
      let parsed = capacity.substring(0, capacity.indexOf("GB"));
      let query = Object.assign({}, this.$route.query);
      let split = query.capacity ? query.capacity.split("|") : [];

      if (split.indexOf(parsed) > -1) {
        let index = split.indexOf(parsed);
        split.splice(index, 1);
      } else {
        split.push(parsed);
      }

      if (split.length) {
        let joined = split.join("|");
        query.capacity = joined;
      } else {
        delete query.capacity;
      }

      this.$router.push({ query: query });
    },
    clearColours() {
      if (this.colours.length) {
        let query = Object.assign({}, this.$route.query);
        delete query.colours;

        this.$router.push({ query: query });
      }
    },
    filterColour(colour) {
      let query = Object.assign({}, this.$route.query);
      let split = query.colours ? query.colours.split("|") : [];

      if (split.indexOf(colour) > -1) {
        let index = split.indexOf(colour);
        split.splice(index, 1);
      } else {
        split.push(colour);
      }

      if (split.length) {
        let joined = split.join("|");
        query.colours = joined;
      } else {
        delete query.colours;
      }

      this.$router.push({ query: query });
    },
    clearOS() {
      if (this.os.length) {
        let query = Object.assign({}, this.$route.query);
        delete query.os;

        this.$router.push({ query: query });
      }
    },
    filterOS(os) {
      let query = Object.assign({}, this.$route.query);
      let split = query.os ? query.os.split("|") : [];

      if (split.indexOf(os) > -1) {
        let index = split.indexOf(os);
        split.splice(index, 1);
      } else {
        split.push(os);
      }

      if (split.length) {
        let joined = split.join("|");
        query.os = joined;
      } else {
        delete query.os;
      }

      this.$router.push({ query: query });
    },
    clearFeatures() {
      if (this.features.length) {
        let query = Object.assign({}, this.$route.query);
        delete query.features;

        this.$router.push({ query: query });
      }
    },
    filterFeature(feature) {
      let query = Object.assign({}, this.$route.query);
      let split = query.features ? query.features.split("|") : [];

      if (split.indexOf(feature) > -1) {
        let index = split.indexOf(feature);
        split.splice(index, 1);
      } else {
        split.push(feature);
      }

      if (split.length) {
        let joined = split.join("|");
        query.features = joined;
      } else {
        delete query.features;
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

.slider {
  padding: 35px 0 10px 10px;
}
</style>
