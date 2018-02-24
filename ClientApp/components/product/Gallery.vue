<template>
  <div class="gallery" @click="close">
    <span @click.stop="prev">
      <i class="fas fa-chevron-circle-left fa-3x prev" />
    </span>

    <div class="slide" @click.stop="next">        
      <transition name="fade" mode="out-in">
        <img class="img-fluid" 
          :src="images[index]" 
          :key="images[index]" 
          :alt="images[index]" 
        />
      </transition>
    </div>

    <span @click.stop="next">
      <i class="fas fa-chevron-circle-right fa-3x next" />
    </span>
  </div>
</template>

<script>
export default {
  name: "gallery",
  props: {
    images: {
      type: Array,
      required: true
    },
    initial: {
      type: Number,
      required: true
    }
  },
  data() {
    return {
      index: 0
    };
  },
  created() {
    this.index = this.initial;
    this.bindEvents();
  },
  methods: {
    bindEvents() {
      window.addEventListener("keyup", event => {
        switch (event.keyCode) {
          case 27:
            this.close();
            break;
          case 37:
            this.prev();
            break;
          case 39:
            this.next();
            break;
        }
      });
    },
    next() {
      if (this.index < this.images.length - 1) {
        this.index++;
      } else {
        this.index = 0;
      }
    },
    prev() {
      if (this.index > 0) {
        this.index--;
      } else {
        this.index = this.images.length - 1;
      }
    },
    close() {
      this.$emit("close");
    }
  }
};
</script>

<style lang="scss" scoped>
.gallery {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.8);
  z-index: 15000;

  .prev,
  .next {
    position: absolute;
    color: white;
    cursor: pointer;
  }

  .prev,
  .next {
    top: 50%;
    transform: translateY(-50%);
  }

  .prev {
    left: 20px;
  }

  .next {
    right: 20px;
  }

  .slide {
    position: relative;
    width: 750px;
    max-width: 90%;
    height: 422px;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    overflow: hidden;

    img {
      position: relative;
      top: 50%;
      transform: translateY(-50%);
    }
  }
}
</style>
