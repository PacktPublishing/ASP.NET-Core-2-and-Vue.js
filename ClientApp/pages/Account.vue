<template>
  <b-container class="page pt-4">
    <h1>My Account</h1>
    <order-list :orders="orders" />
  </b-container>
</template>

<script>
import axios from "axios";
import OrderList from "../components/shared/OrderList.vue";

export default {
  name: "account",
  components: {
    OrderList
  },
  computed: {
    orders() {
      return this.$store.state.orders;
    }
  },
  asyncData({ store }) {
    return store.dispatch("fetchOrders");
  }
};
</script>

