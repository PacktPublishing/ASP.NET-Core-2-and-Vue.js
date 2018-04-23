<template>
  <div>
    <h4 class="d-flex justify-content-between align-items-center mb-3">
      <span class="text-muted">Your cart</span>
      <span class="badge badge-secondary badge-pill">{{ itemCount }}</span>
    </h4>
    <ul class="list-group mb-3">
      <li v-for="(item, index) in items" :key="index" class="list-group-item d-flex justify-content-between lh-condensed">
        <div>
          <h6 class="my-0">{{ item.name }} <span class="text-muted">({{ item.quantity }})</span></h6>
          <small class="text-muted">{{ item.colour }}, {{ item.capacity }}</small>
        </div>
        <span class="text-muted">{{ item.price * item.quantity | currency }}</span>
      </li>
      <li class="list-group-item d-flex justify-content-between">
        <span>Total:</span>
        <strong>{{ total | currency }}</strong>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "cart-summary",
  computed: {
    itemCount() {
      return this.$store.getters.shoppingCartItemCount;
    },
    total() {
      return this.$store.getters.shoppingCartTotal;
    },
    items() {
      return this.$store.state.cart;
    }
  }
};
</script>

