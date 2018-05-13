<template>
  <form-input-base :label="label">
    <div class="typeahead">
      <input
        ref="input"
        :value="value"
        :name="name"
        :class="classes"
        @blur="blur"
        @focus="focus"
        @keydown.enter.prevent="enter"
        @keydown.down.prevent="down"
        @keydown.up.prevent="up"
        @input="input" />

      <div v-if="error" class="invalid-feedback">
        {{ error }}
      </div>

      <b-list-group v-if="open" class="suggestions">
        <b-list-group-item
          v-for="(suggestion, index) in matches"  
          :key="index"
          :active="index === current"
          @mousedown.prevent="click(index)"
          button>
          {{ suggestion }}  
        </b-list-group-item>
      </b-list-group>
    </div>
  </form-input-base>
</template>

<script>
import FormInputBase from "./FormInputBase.vue";

export default {
  name: "typeahead",
  extends: FormInputBase,
  components: {
    FormInputBase
  },
  props: {
    items: {
      type: Array,
      required: true
    }
  },
  data() {
    return {
      current: -1,
      focused: false
    };
  },
  computed: {
    matches() {
      return this.items.filter(str => {
        return str.toLowerCase().indexOf(this.value.toLowerCase()) >= 0;
      });
    },
    open() {
      return (
        this.value.length > 0 &&
        this.focused &&
        !this.items.some(item => item === this.value)
      );
    }
  },
  methods: {
    input(event) {
      this.$emit("input", event.target.value);

      this.items.map(item => {
        if (item.toLowerCase() === event.target.value.toLowerCase()) {
          this.$emit("input", item);
        }
      });
    },
    click(index) {
      this.$emit("input", this.matches[index]);
      this.$refs.input.$el.focus();
    },
    enter() {
      if (this.current >= 0) {
        this.$emit("input", this.matches[this.current]);
      }
    },
    up() {
      if (this.current >= 0) this.current--;
    },
    down() {
      if (this.current < this.matches.length - 1) this.current++;
    },
    focus() {
      this.focused = true;
      this.$emit("focus");
    },
    blur() {
      this.focused = false;
      this.$emit("blur");
    }
  }
};
</script>

<style lang="scss" scoped>
.typeahead {
  position: relative;

  .suggestions {
    position: absolute;
    top: 42px;
    right: 0;
    left: 0;
    z-index: 1;
    -webkit-box-shadow: 0px 2px 10px 0px rgba(204, 204, 204, 1);
    -moz-box-shadow: 0px 2px 10px 0px rgba(204, 204, 204, 1);
    box-shadow: 0px 2px 10px 0px rgba(204, 204, 204, 1);
  }
}
</style>

