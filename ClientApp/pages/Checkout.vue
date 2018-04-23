<template>
  <b-container class="page pt-4">
    <h1>Checkout</h1>
    <checkout-success v-if="success" :order="order" />
    <b-row v-else>
      <b-col cols="4" order="2">
        <cart-summary />
      </b-col>
      <b-col cols="8">
        <checkout-form @success="onSuccess" />
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import CartSummary from "../components/checkout/CartSummary.vue";
import CheckoutForm from "../components/checkout/CheckoutForm.vue";
import CheckoutSuccess from "../components/checkout/CheckoutSuccess.vue";

export default {
  name: "checkout",
  components: {
    CartSummary,
    CheckoutForm,
    CheckoutSuccess
  },
  data() {
    return {
      success: false,
      order: null
    };
  },
  methods: {
    onSuccess(order) {
      this.success = true;
      this.order = order;
      window.scrollTo(0, 0);
    }
  }
};
</script>
