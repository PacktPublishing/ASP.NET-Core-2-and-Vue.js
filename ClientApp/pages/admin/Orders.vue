<template>
  <order-list :orders="orders" />
</template>

<script>
import axios from "axios";
import OrderList from "../../components/shared/OrderList.vue";

export default {
  name: "orders",
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

