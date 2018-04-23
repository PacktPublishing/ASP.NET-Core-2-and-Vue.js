<template>
  <div>
    <h3 class="mt-4">Orders</h3>
    <table class="table table-striped table-hover">
      <thead>
        <tr>
          <th>Order #</th>
          <th>Placed</th>
          <th>Items</th>
          <th>Total</th>
          <th>Payment status</th>
        </tr>
      </thead>
      <tbody>
        <tr v-if="orders && orders.length > 0" v-for="order in orders" :key="order.id">
          <td>{{ order.id }}</td>
          <td>{{ order.placed | date }}</td>
          <td>{{ order.items }}</td>
          <td>{{ order.total | currency }}</td>
          <td>{{ order.paymentStatus }}</td>
        </tr>
        <tr v-else>
          <td colspan="5">You haven't placed any orders yet!</td>
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
  }
};
</script>

