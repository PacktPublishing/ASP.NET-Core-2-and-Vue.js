<template>
  <b-container class="page pt-4">
    <h1>My Account</h1>
    <order-list :orders="orders" />
  </b-container>
</template>

<script>
import axios from "axios";
import OrderList from "../components/account/OrderList.vue";

export default {
  name: "account",
  components: {
    OrderList
  },
  data() {
    return {
      orders: null
    };
  },
  methods: {
    setData(orders) {
      this.orders = orders;
    }
  },
  beforeRouteEnter(to, from, next) {
    const vm = this;
    axios.get("/api/orders").then(response => {
      next(vm => vm.setData(response.data));
    });
  }
};
</script>

