<template>
  <div class="slider">
    <vue-slider 
      :value="value"
      :formatter="formatter" 
      :min="min"
      :max="max"
      :interval="interval || 1"
      :lazy=true
      width="90%"
      @callback="filter">
    </vue-slider>
  </div>
</template>

<script>
import vueSlider from "vue-slider-component";

export default {
  name: "range-filter",
  components: {
    vueSlider
  },
  props: {
    min: {
      type: Number,
      required: true
    },
    max: {
      type: Number,
      required: true
    },
    interval: {
      type: Number
    },
    formatter: {
      type: String,
      required: true
    },
    minQueryKey: {
      type: String,
      required: true
    },
    maxQueryKey: {
      type: String,
      required: true
    }
  },
  computed: {
    value() {
      return [
        this.$route.query[this.minQueryKey] || this.min,
        this.$route.query[this.maxQueryKey] || this.max
      ];
    }
  },
  methods: {
    filter(values) {
      let query = Object.assign({}, this.$route.query);
      query[this.minQueryKey] = values[0];
      query[this.maxQueryKey] = values[1];

      this.$router.push({ query: query });
    }
  }
};
</script>

<style lang="scss" scoped>
.slider {
  padding: 35px 0 10px 10px;
}
</style>
