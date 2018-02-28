<template>
  <tr>
    <td>
      <b-row align-v="center">
        <b-col cols="auto">
          <img :src="item.thumbnail" :alt="item.name" />
        </b-col>
        <b-col class="align-middle">
          <h5>{{ item.name }}</h5>
          <div>
            Colour: <strong>{{ item.colour }}</strong>  
          </div>
          <div>
            Capacity: <strong>{{ item.capacity }}</strong>
          </div>
        </b-col>
      </b-row>
    </td>
    <td>
      {{ item.price | currency }}
    </td>
    <td>
      <b-form-input type="number" :value="item.quantity" @change="setProductQuantity"></b-form-input>
    </td>
    <td>
      {{ item.price * item.quantity | currency }}
    </td>
    <td>
      <b-button variant="danger" @click="removeProductFromCart">
        <i class="fas fa-trash-alt"></i>
      </b-button>
    </td>
  </tr>
</template>

<script>
export default {
  name: "cart-item",
  props: {
    item: {
      type: Object,
      required: true
    }
  },
  methods: {
    removeProductFromCart() {
      this.$store.dispatch("removeProductFromCart", this.item);
    },
    setProductQuantity(quantity) {
      const payload = { product: this.item, quantity: parseInt(quantity) };
      this.$store.dispatch("setProductQuantity", payload);
    }
  }
};
</script>

<style lang="scss" scoped>
td {
  vertical-align: middle;
}

td:nth-child(1) {
  width: auto;
  min-width: 350px;

  img {
    width: 100px;
  }
}

td:nth-child(2) {
  width: 75px;
}

td:nth-child(3) {
  width: 75px;
}

td:nth-child(4) {
  min-width: 150px;
}

td:nth-child(5) {
  width: 125px;
}
</style>
