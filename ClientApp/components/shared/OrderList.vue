<template>
  <div>
    <h3>Orders</h3>
    <table class="table table-striped table-hover">
      <thead>
        <tr>
          <th>Order #</th>
          <th v-if="isAdmin">Customer</th>
          <th>Placed</th>
          <th>Items</th>
          <th>Total</th>
          <th>Payment status</th>
        </tr>
      </thead>
      <tbody>
        <template v-if="orders && orders.length > 0">
          <tr v-for="order in orders" :key="order.id">
            <td>{{ order.id }}</td>
            <td v-if="isAdmin">{{ order.customer }}</td>
            <td>{{ order.placed | date }}</td>
            <td>{{ order.items }}</td>
            <td>{{ order.total | currency }}</td>
            <td>{{ order.paymentStatus }}</td>
          </tr>
        </template>
        <tr v-else>
          <td v-if="isAdmin" colspan="6">There are no orders to display.</td>
          <td v-else colspan="5">You haven't placed any orders yet!</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "order-list",
  props: {
    orders: {
      type: Array,
      required: false
    }
  },
  computed: {
    isAdmin() {
      return this.$store.getters.isInRole("Admin");
    }
  }
};
</script>

