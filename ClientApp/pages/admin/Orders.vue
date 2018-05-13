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

