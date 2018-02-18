<template>
  <b-list-group-item>
    <div :class="{ 'header': true, 'open': open }" @click="open = !open">  
      <slot name="header"></slot>
      <i class="fas fa-chevron-down float-right"></i>
    </div>
    <transition @enter="onEnter" @leave="onLeave">
      <div class="body mt-3 pt-2" v-if="open">
        <slot name="body"></slot>
      </div>
    </transition>
  </b-list-group-item>
</template>

<script>
import * as Velocity from "velocity-animate";

export default {
  name: "filter-accordion",
  data() {
    return {
      open: true
    };
  },
  methods: {
    onEnter(el, done) {
      Velocity(el, "slideDown", {
        duration: 200,
        easing: "ease-in-out",
        complete: done
      });
    },
    onLeave(el, done) {
      Velocity(el, "slideUp", {
        duration: 250,
        easing: "ease-in-out",
        complete: done
      });
    }
  }
};
</script>

<style lang="scss" scoped>
.header {
  font-weight: bold;
  cursor: pointer;

  .fa-chevron-down {
    position: relative;
    top: 5px;
    transition: all 0.2s ease-in-out;
  }

  &.open {
    .fa-chevron-down {
      transform: rotate(180deg);
    }
  }
}

.body {
  border-top: 1px solid #ccc;
}
</style>
